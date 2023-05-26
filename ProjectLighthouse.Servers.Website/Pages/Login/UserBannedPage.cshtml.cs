﻿using JetBrains.Annotations;
using LBPUnion.ProjectLighthouse.Database;
using LBPUnion.ProjectLighthouse.Servers.Website.Pages.Layouts;
using LBPUnion.ProjectLighthouse.Types.Entities.Moderation;
using LBPUnion.ProjectLighthouse.Types.Entities.Profile;
using LBPUnion.ProjectLighthouse.Types.Moderation.Cases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Servers.Website.Pages.Login;

public class UserBannedPage : BaseLayout
{
    public UserBannedPage(DatabaseContext database) : base(database)
    { }

    public ModerationCaseEntity ModCase = null!;

    [UsedImplicitly]
    public async Task<IActionResult> OnGet()
    {
        UserEntity? user = this.Database.UserFromWebRequest(this.Request);

        if (user == null) return this.Redirect("~/login");
        if (user.IsBanned == false) return this.Redirect("~/");

        ModerationCaseEntity? modCase = await this.Database.Cases
            .FirstOrDefaultAsync(c => c.AffectedId == user.UserId && c.Type == CaseType.UserBan);

        if (modCase == null) return this.Redirect("~/");

        this.ModCase = modCase;

        return this.Page();
    }
}