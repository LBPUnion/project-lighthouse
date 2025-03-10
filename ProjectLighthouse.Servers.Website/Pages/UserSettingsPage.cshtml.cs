﻿#nullable enable
using System.Diagnostics.CodeAnalysis;
using LBPUnion.ProjectLighthouse.Configuration;
using LBPUnion.ProjectLighthouse.Database;
using LBPUnion.ProjectLighthouse.Files;
using LBPUnion.ProjectLighthouse.Helpers;
using LBPUnion.ProjectLighthouse.Localization;
using LBPUnion.ProjectLighthouse.Servers.Website.Pages.Layouts;
using LBPUnion.ProjectLighthouse.Types.Entities.Profile;
using LBPUnion.ProjectLighthouse.Types.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Servers.Website.Pages;

public class UserSettingsPage : BaseLayout
{

    public UserEntity? ProfileUser;
    public UserSettingsPage(DatabaseContext database) : base(database)
    {}

    [SuppressMessage("ReSharper", "SpecifyStringComparison")]
    public async Task<IActionResult> OnPost
    (
        [FromRoute] int userId,
        [FromForm] string? avatar,
        [FromForm] string? username,
        [FromForm] string? email,
        [FromForm] string profileTag,
        [FromForm] string? biography,
        [FromForm] string? timeZone,
        [FromForm] string? language
    )
    {
        this.ProfileUser = await this.Database.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (this.ProfileUser == null) return this.NotFound();

        if (this.User == null) return this.Redirect("~/user/" + userId);

        if (!this.User.IsModerator && this.User != this.ProfileUser) return this.Redirect("~/user/" + userId);

        // Deny request if in read-only mode
        if (avatar != null && ServerConfiguration.Instance.UserGeneratedContentLimits.ReadOnlyMode)
            return this.Redirect($"~/user/{userId}");

        string? avatarHash = await FileHelper.ParseBase64Image(avatar);

        if (avatarHash != null) this.ProfileUser.IconHash = avatarHash;

        if (this.User.IsAdmin) this.ProfileUser.ProfileTag = profileTag;

        if (biography != null)
        {
            // Deny request if in read-only mode
            if (ServerConfiguration.Instance.UserGeneratedContentLimits.ReadOnlyMode)
                return this.Redirect($"~/user/{userId}");

            if (this.ProfileUser.Biography != biography && biography.Length <= 512)
            {
                string filteredBio = CensorHelper.FilterMessage(biography, FilterLocation.UserBiography, this.ProfileUser.Username);

                this.ProfileUser.Biography = filteredBio;
            }
        }

        if (ServerConfiguration.Instance.Mail.MailEnabled &&
            SanitizationHelper.IsValidEmail(email) &&
            (this.User == this.ProfileUser || this.User.IsAdmin))
        {
            // if email hasn't already been used
            if (!await this.Database.Users.AnyAsync(u => u.EmailAddress != null && u.EmailAddress.ToLower() == email!.ToLower()))
            {
                if (this.ProfileUser.EmailAddress != email)
                {
                    this.ProfileUser.EmailAddress = email;
                    this.ProfileUser.EmailAddressVerified = false;
                }
            }
        }

        if (this.ProfileUser == this.User)
        {
            if (!string.IsNullOrWhiteSpace(language) && this.ProfileUser.Language != language)
            {
                if (LocalizationManager.GetAvailableLanguages().Contains(language))
                    this.ProfileUser.Language = language;
            }

            if (!string.IsNullOrWhiteSpace(timeZone) && this.ProfileUser.TimeZone != timeZone)
            {
                HashSet<string> timeZoneIds = TimeZoneInfo.GetSystemTimeZones().Select(t => t.Id).ToHashSet();
                if (timeZoneIds.Contains(timeZone)) this.ProfileUser.TimeZone = timeZone;
            }
        }


        await this.Database.SaveChangesAsync();
        return this.Redirect("~/user/" + userId);
    }

    public async Task<IActionResult> OnGet([FromRoute] int userId)
    {
        this.ProfileUser = await this.Database.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (this.ProfileUser == null) return this.NotFound();

        if (this.User == null) return this.Redirect("~/user/" + userId);

        if (!this.User.IsModerator && this.User != this.ProfileUser) return this.Redirect("~/user/" + userId);

        return this.Page();
    }
}