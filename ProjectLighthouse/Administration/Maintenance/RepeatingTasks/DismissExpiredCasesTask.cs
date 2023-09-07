﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBPUnion.ProjectLighthouse.Database;
using LBPUnion.ProjectLighthouse.Logging;
using LBPUnion.ProjectLighthouse.Types.Entities.Moderation;
using LBPUnion.ProjectLighthouse.Types.Logging;
using LBPUnion.ProjectLighthouse.Types.Maintenance;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Administration.Maintenance.RepeatingTasks;

public class DismissExpiredCasesTask : IRepeatingTask
{
    public string Name => "Dismiss Expired Cases";
    public TimeSpan RepeatInterval => TimeSpan.FromMinutes(1);
    public DateTime LastRan { get; set; }

    public async Task Run(DatabaseContext database)
    {
        List<ModerationCaseEntity> cases =
            await database.Cases.Where(c => c.ExpiresAt != null && c.ExpiresAt < DateTime.Now).ToListAsync();

        if (cases.Count == 0)
        {
            Logger.Info("There are no expired cases to dismiss", LogArea.Maintenance);
            return;
        }

        foreach (ModerationCaseEntity @case in cases)
        {
            @case.DismissedAt = DateTime.Now;
            Logger.Info($"Dismissed expired case {@case.CaseId}", LogArea.Maintenance);
        }

        await database.SaveChangesAsync();
    }
}