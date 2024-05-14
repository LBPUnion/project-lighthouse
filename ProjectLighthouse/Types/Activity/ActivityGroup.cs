﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace LBPUnion.ProjectLighthouse.Types.Activity;

public struct ActivityGroup
{
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public int? TargetSlotId { get; set; }
    public int? TargetUserId { get; set; }
    public int? TargetPlaylistId { get; set; }
    public int? TargetNewsId { get; set; }
    public int? TargetTeamPickSlotId { get; set; }

    public int TargetId =>
        this.GroupType switch
        {
            ActivityGroupType.User => this.TargetUserId ?? this.UserId,
            ActivityGroupType.Level => this.TargetSlotId ?? 0,
            ActivityGroupType.TeamPick => this.TargetTeamPickSlotId ?? 0,
            ActivityGroupType.Playlist => this.TargetPlaylistId ?? 0,
            ActivityGroupType.News => this.TargetNewsId ?? 0,
            _ => this.UserId,
        };

    public ActivityGroupType GroupType =>
        (this.TargetPlaylistId ?? 0) != 0
            ? ActivityGroupType.User
            : (this.TargetNewsId ?? 0) != 0
                ? ActivityGroupType.News
                : (this.TargetTeamPickSlotId ?? 0) != 0
                    ? ActivityGroupType.TeamPick
                    : (this.TargetSlotId ?? 0) != 0
                        ? ActivityGroupType.Level
                        : ActivityGroupType.User;

    public override string ToString() =>
        $@"{this.GroupType} Group: Timestamp: {this.Timestamp}, UserId: {this.UserId}, TargetId: {this.TargetId}";
}

public struct OuterActivityGroup
{
    public ActivityGroup Key { get; set; }
    public List<IGrouping<InnerActivityGroup, ActivityDto>> Groups { get; set; }
}

public struct InnerActivityGroup
{
    public ActivityGroupType Type { get; set; }
    public int UserId { get; set; }
    public int TargetId { get; set; }
}

public enum ActivityGroupType
{
    [XmlEnum("user")]
    User,

    [XmlEnum("slot")]
    Level,

    [XmlEnum("playlist")]
    Playlist,

    [XmlEnum("news")]
    News,

    [XmlEnum("slot")]
    TeamPick,
}