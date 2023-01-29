﻿using LBPUnion.ProjectLighthouse.Entities.Profile;
using LBPUnion.ProjectLighthouse.Entities.Token;
using LBPUnion.ProjectLighthouse.Extensions;
using LBPUnion.ProjectLighthouse.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LBPUnion.ProjectLighthouse.Servers.GameServer.Controllers;

[ApiController]
[Authorize]
[Route("LITTLEBIGPLANETPS3_XML/goodbye")]
[Produces("text/xml")]
public class LogoutController : ControllerBase
{

    private readonly Database database;

    public LogoutController(Database database)
    {
        this.database = database;
    }

    [HttpPost]
    public async Task<IActionResult> OnPost()
    {
        GameToken token = this.GetToken();

        User? user = await this.database.UserFromGameToken(token);
        if (user == null) return this.StatusCode(403, "");

        user.LastLogout = TimeHelper.TimestampMillis;

        this.database.GameTokens.RemoveWhere(t => t.TokenId == token.TokenId);
        this.database.LastContacts.RemoveWhere(c => c.UserId == token.UserId);
        await this.database.SaveChangesAsync();

        return this.Ok();
    }

    
}