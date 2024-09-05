﻿#nullable enable
using LBPUnion.ProjectLighthouse.Configuration;
using LBPUnion.ProjectLighthouse.Database;
using LBPUnion.ProjectLighthouse.Files;
using LBPUnion.ProjectLighthouse.Helpers;
using LBPUnion.ProjectLighthouse.Servers.Website.Pages.Layouts;
using LBPUnion.ProjectLighthouse.Types.Entities.Level;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Servers.Website.Pages;

public class SlotSettingsPage : BaseLayout
{

    public SlotEntity? Slot;
    public SlotSettingsPage(DatabaseContext database) : base(database)
    {}

    public async Task<IActionResult> OnPost
    (
        [FromRoute] int slotId,
        [FromForm] string? avatar,
        [FromForm] string? name,
        [FromForm] string? description,
        [FromForm] string? labels,
        [FromForm] bool locked,
        [FromForm] bool copyable,
        [FromForm] bool subLevel,
        [FromForm] bool lbp1Only
    )
    {
        this.Slot = await this.Database.Slots.FirstOrDefaultAsync(u => u.SlotId == slotId);
        if (this.Slot == null) return this.NotFound();

        if (this.User == null) return this.Redirect("~/slot/" + slotId);

        if (!this.User.IsModerator && this.User != this.Slot.Creator) return this.Redirect("~/slot/" + slotId);

        // Deny request if in read-only mode
        if (ServerConfiguration.Instance.UserGeneratedContentLimits.ReadOnlyMode)
            return this.Redirect($"~/slot/{slotId}");

        string? avatarHash = await FileHelper.ParseBase64Image(avatar);

        if (avatarHash != null) this.Slot.IconHash = avatarHash;

        if (name != null)
        {
            name = CensorHelper.FilterMessage(name);
            if (this.Slot.Name != name && name.Length <= 64)
                this.Slot.Name = name;
        }

        if (description != null)
        {
            description = CensorHelper.FilterMessage(description);
            if (this.Slot.Description != description && description?.Length <= 512)
                this.Slot.Description = description;
        }

        if (labels != null)
        {
            if (this.Slot.AuthorLabels != labels)
                this.Slot.AuthorLabels = labels;
        }

        if (this.Slot.InitiallyLocked != locked) this.Slot.InitiallyLocked = locked;
        if (this.Slot.Shareable != Convert.ToInt32(copyable)) this.Slot.Shareable = Convert.ToInt32(copyable);
        if (this.Slot.SubLevel != subLevel) this.Slot.SubLevel = subLevel;
        if (this.Slot.Lbp1Only != lbp1Only) this.Slot.Lbp1Only = lbp1Only;

        // ReSharper disable once InvertIf
        if (this.Database.ChangeTracker.HasChanges())
        {
            this.Slot.LastUpdated = TimeHelper.TimestampMillis;
            await this.Database.SaveChangesAsync();
        }

        return this.Redirect("~/slot/" + slotId);
    }

    public async Task<IActionResult> OnGet([FromRoute] int slotId)
    {
        this.Slot = await this.Database.Slots.FirstOrDefaultAsync(s => s.SlotId == slotId);
        if (this.Slot == null) return this.NotFound();

        if (this.User == null) return this.Redirect("~/slot/" + slotId);

        if (!this.User.IsModerator && this.User.UserId != this.Slot.CreatorId) return this.Redirect("~/slot/" + slotId);

        return this.Page();
    }
}
