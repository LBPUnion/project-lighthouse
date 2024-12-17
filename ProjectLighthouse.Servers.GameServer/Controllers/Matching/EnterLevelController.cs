#nullable enable
using System.Runtime.CompilerServices;
using LBPUnion.ProjectLighthouse.Database;
using LBPUnion.ProjectLighthouse.Extensions;
using LBPUnion.ProjectLighthouse.Helpers;
using LBPUnion.ProjectLighthouse.Configuration;
using LBPUnion.ProjectLighthouse.Migrations;
using LBPUnion.ProjectLighthouse.Types.Entities.Interaction;
using LBPUnion.ProjectLighthouse.Types.Entities.Level;
using LBPUnion.ProjectLighthouse.Types.Entities.Profile;
using LBPUnion.ProjectLighthouse.Types.Entities.Token;
using LBPUnion.ProjectLighthouse.Types.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Servers.GameServer.Controllers.Matching;

[ApiController]
[Authorize]
[Route("LITTLEBIGPLANETPS3_XML/")]
[Produces("text/xml")]
public class EnterLevelController : ControllerBase
{
    private readonly DatabaseContext database;

    private static readonly bool emailEnforcementEnabled = EnforceEmailConfiguration.Instance.EnableEmailEnforcement;

    public EnterLevelController(DatabaseContext database)
    {
        this.database = database;
    }

    [HttpPost("play/{slotType}/{slotId:int}")]
    public async Task<IActionResult> PlayLevel(string slotType, int slotId)
    {
        GameTokenEntity token = this.GetToken();

        UserEntity? user = await this.database.UserFromGameToken(token);

        if (SlotHelper.IsTypeInvalid(slotType)) return this.BadRequest();

        // Return bad request on unverified email if enforcement is enabled
        if (emailEnforcementEnabled  && !user.EmailAddressVerified) return this.BadRequest();

        // don't count plays for developer slots
        if (slotType == "developer") return this.Ok();

        SlotEntity? slot = await this.database.Slots.FirstOrDefaultAsync(s => s.SlotId == slotId);
        if (slot == null) return this.BadRequest();

        IQueryable<VisitedLevelEntity> visited = this.database.VisitedLevels.Where(s => s.SlotId == slotId && s.UserId == token.UserId);
        VisitedLevelEntity? v;
        if (!visited.Any())
        {
            switch (token.GameVersion)
            {
                case GameVersion.LittleBigPlanet2:
                case GameVersion.LittleBigPlanetVita:
                    slot.PlaysLBP2Unique++;
                    break;
                case GameVersion.LittleBigPlanet3:
                    slot.PlaysLBP3Unique++;
                    break;
                case GameVersion.LittleBigPlanet1:
                case GameVersion.LittleBigPlanetPSP:
                case GameVersion.Unknown:
                default: return this.BadRequest();
            }

            v = new VisitedLevelEntity
            {
                SlotId = slotId,
                UserId = token.UserId,
            };
            this.database.VisitedLevels.Add(v);
        }
        else
        {
            v = await visited.FirstOrDefaultAsync();
        }

        if (v == null) return this.NotFound();

        switch (token.GameVersion)
        {
            case GameVersion.LittleBigPlanet2:
            case GameVersion.LittleBigPlanetVita:
                slot.PlaysLBP2++;
                v.PlaysLBP2++;
                break;
            case GameVersion.LittleBigPlanet3:
                slot.PlaysLBP3++;
                v.PlaysLBP3++;
                break;
            case GameVersion.LittleBigPlanet1:
            case GameVersion.LittleBigPlanetPSP:
            case GameVersion.Unknown:
            default:
                return this.BadRequest();
        }

        await this.database.SaveChangesAsync();

        return this.Ok();
    }

    // Only used in LBP1
    [HttpPost("enterLevel/{slotType}/{slotId:int}")]
    public async Task<IActionResult> EnterLevel(string slotType, int slotId)
    {
        GameTokenEntity token = this.GetToken();

        UserEntity? user = await this.database.UserFromGameToken(token);

        if (SlotHelper.IsTypeInvalid(slotType)) return this.BadRequest();

        // Return bad request on unverified email if enforcement is enabled
        if (emailEnforcementEnabled  && !user.EmailAddressVerified) return this.BadRequest();

        if (slotType == "developer") return this.Ok();

        SlotEntity? slot = await this.database.Slots.FirstOrDefaultAsync(s => s.SlotId == slotId);
        if (slot == null) return this.NotFound();

        IQueryable<VisitedLevelEntity> visited = this.database.VisitedLevels.Where(s => s.SlotId == slotId && s.UserId == token.UserId);
        VisitedLevelEntity? v;
        if (!visited.Any())
        {
            slot.PlaysLBP1Unique++;

            v = new VisitedLevelEntity
            {
                SlotId = slotId,
                UserId = token.UserId,
            };
            this.database.VisitedLevels.Add(v);
        }
        else
        {
            v = await visited.FirstOrDefaultAsync();
        }

        if (v == null) return this.NotFound();

        slot.PlaysLBP1++;
        v.PlaysLBP1++;

        await this.database.SaveChangesAsync();

        return this.Ok();
    }
}