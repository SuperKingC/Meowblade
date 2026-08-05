using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_TreasureMap : IIslandEvent
{
	[ProtoMember(2)]
	public int ExpireTimestamp;

	[ProtoIgnore]
	public int MUID { get; set; }

	[ProtoIgnore]
	public int IconIdx { get; set; }

	[ProtoIgnore]
	public eIslandEventUiType UiType { get; set; }

	[ProtoIgnore]
	public eIslandEvent EventType { get; set; }

	public string MissionConfigId { get; private set; }

	public bool HasClaimed { get; set; }

	public GvGMode3EventMissionConfigModel EventConfig => GvG3FlagShipMissionsConfigHelper.EventMissionConfig(MissionConfigId);

	public bool StillValid(int timestamp)
	{
		return ExpireTimestamp < 0 || ExpireTimestamp > timestamp;
	}

	public int RemainingTime(int timestamp)
	{
		return Math.Max(0, ExpireTimestamp - timestamp);
	}

	public void UpdateProgress(MissionStateRecordWithProgress progress)
	{
		MissionConfigId = progress.MissionConfigId;
		HasClaimed = progress.HasClaimed;
	}

	public bool HasTimeLimit()
	{
		return ExpireTimestamp > 0;
	}
}
