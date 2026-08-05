using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class GvGMode3IslandEntityInfo
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public int State;

	[ProtoMember(4)]
	public int ProtectedPeriodTimestamp;

	[ProtoMember(5)]
	public int NPCRebornTimestamp;

	[ProtoMember(6)]
	public int NPCRecoveryTimestamp;

	[ProtoMember(7)]
	public int RandomEventStartTimestamp;

	[ProtoMember(8)]
	public int RandomEventEndTimestamp;

	[ProtoMember(9)]
	public List<int> Markers;

	[ProtoMember(10)]
	public List<(int, int)> CampShipCount;

	[ProtoMember(11)]
	public float ObedienceValue;

	[ProtoMember(12, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandEvents")]
	public GvGMode3IslandEvents Events;

	[ProtoMember(14)]
	public int ShieldState;

	[ProtoMember(15)]
	public int AttackerIslandId;

	[ProtoMember(16)]
	public bool HasExtraResource;

	[ProtoMember(99)]
	public int VersionNumber;
}
