using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class GvGMode3ShipTemporaryData
{
	public bool IsDBModel = false;

	[ProtoMember(1)]
	public int CampId { get; set; }

	[ProtoMember(2)]
	public int ShipRace { get; set; }

	[ProtoMember(3)]
	public int ShipSkinId { get; set; }

	[ProtoMember(4)]
	public int FoodOnboardCount { get; set; }

	[ProtoMember(5)]
	public int TargetIslandId { get; set; }

	[ProtoMember(6)]
	public eShipState ShipState { get; set; }

	[ProtoMember(7)]
	public string FormationId { get; set; } = "FA01";

	[ProtoMember(8)]
	public List<GvGMode3UnitInfo> Group { get; set; } = new List<GvGMode3UnitInfo>(5);

	[ProtoMember(9)]
	public List<GvGMode3UnitInfo> BackupGroup { get; set; } = new List<GvGMode3UnitInfo>(3);

	[ProtoMember(10)]
	public Dictionary<int, int> Amplifiers { get; set; } = new Dictionary<int, int>();

	[ProtoMember(11)]
	public int WorkersOnboardCount { get; set; }

	[ProtoMember(99)]
	public int EntityId { get; set; }

	[ProtoMember(12)]
	public int ShipPower { get; set; }

	[ProtoMember(13)]
	public int ShipSpeed { get; set; }

	[ProtoMember(61)]
	public bool CanDestroy { get; set; } = false;

	[ProtoMember(102)]
	public int SoulGuideCDTimestamp { get; set; }

	public bool ShouldSerializeEntityId()
	{
		return !IsDBModel;
	}

	public bool ShouldSerializeShipPower()
	{
		return !IsDBModel;
	}

	public bool ShouldSerializeShipSpeed()
	{
		return !IsDBModel;
	}

	public bool ShouldSerializeSoulGuideCDTimestamp()
	{
		return !IsDBModel;
	}
}
