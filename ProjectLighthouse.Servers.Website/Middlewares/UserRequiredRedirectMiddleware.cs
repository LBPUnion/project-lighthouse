﻿using LBPUnion.ProjectLighthouse.Configuration;
using LBPUnion.ProjectLighthouse.Middlewares;
using LBPUnion.ProjectLighthouse.PlayerData.Profiles;

namespace LBPUnion.ProjectLighthouse.Servers.Website.Middlewares;

public class UserRequiredRedirectMiddleware : MiddlewareDBContext
{
    public UserRequiredRedirectMiddleware(RequestDelegate next) : base(next)
    { }

    public override async Task InvokeAsync(HttpContext ctx, Database database)
    {
        User? user = database.UserFromWebRequest(ctx.Request);
        if (user == null || pathContains(ctx, "/logout"))
        {
            await this.next(ctx);
            return;
        }

        // Request ends with a path (e.g. /css/style.css)
        if (!string.IsNullOrEmpty(Path.GetExtension(ctx.Request.Path)) || pathContains(ctx, "/gameAssets"))
        {
            await this.next(ctx);
            return;
        }

        if (user.PasswordResetRequired)
        {
            if (!pathContains(ctx, "/passwordResetRequired", "/passwordReset"))
            {
                ctx.Response.Redirect("/passwordResetRequired");
                return;
            }

            await this.next(ctx);
            return;
        }

        if (ServerConfiguration.Instance.Mail.MailEnabled)
        {
            // The normal flow is for users to set their email during login so just force them to log out
            if (user.EmailAddress == null)
            {
                ctx.Response.Redirect("/logout");
                return;
            }

            if (!user.EmailAddressVerified && !pathContains(ctx, "/login/sendVerificationEmail", "/verifyEmail"))
            {
                ctx.Response.Redirect("/login/sendVerificationEmail");
                return;
            }

            await this.next(ctx);
            return;
        }

        //TODO additional check if two factor is enabled
        if (user.TwoFactorRequired && !user.IsTwoFactorSetup && !pathContains(ctx, "/setup2fa"))
        {
            ctx.Response.Redirect("/setup2fa");
        }

        await this.next(ctx);
    }

    private static bool pathContains(HttpContext ctx, params string[] pathList)
    {
        return pathList.Any(path => ctx.Request.Path.StartsWithSegments(path));
    }
}