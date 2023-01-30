#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using LBPUnion.ProjectLighthouse.Entities.Level;
using LBPUnion.ProjectLighthouse.Extensions;
using LBPUnion.ProjectLighthouse.Users;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Levels.Categories;

public class MostPlayedCategory : Category
{
    public override string Name { get; set; } = "Most Played";
    public override string Description { get; set; } = "The most played content";
    public override string IconHash { get; set; } = "g820608";
    public override string Endpoint { get; set; } = "mostUniquePlays";
    public override Slot? GetPreviewSlot(Database database) => database.Slots.Where(s => s.Type == SlotType.User).AsEnumerable().MaxBy(s => s.PlaysUnique);
    public override IEnumerable<Slot> GetSlots
        (Database database, int pageStart, int pageSize)
        => database.Slots.ByGameVersion(GameVersion.LittleBigPlanet3, false, true)
        .AsEnumerable()
            .OrderByDescending(s => s.PlaysUnique)
            .ThenBy(_ => EF.Functions.Random())
            .Skip(Math.Max(0, pageStart - 1))
            .Take(Math.Min(pageSize, 20));
    public override int GetTotalSlots(Database database) => database.Slots.Count(s => s.Type == SlotType.User);
}