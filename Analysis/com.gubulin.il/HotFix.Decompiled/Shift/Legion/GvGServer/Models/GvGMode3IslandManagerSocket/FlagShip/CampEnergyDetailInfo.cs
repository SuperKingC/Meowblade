using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class CampEnergyDetailInfo
{
	[ProtoMember(1)]
	public int IslandType { get; set; }

	[ProtoMember(2)]
	public int EnergyEfficiencyPerSecond { get; set; }

	[ProtoMember(3)]
	public int IslandCount { get; set; }

	[ProtoIgnore]
	public int EnergyEfficiencyPerDay => Mathf.CeilToInt((float)(EnergyEfficiencyPerSecond * 86400) / 5f);

	[ProtoIgnore]
	public eIslandType IslandTypeValue => (eIslandType)IslandType;
}
