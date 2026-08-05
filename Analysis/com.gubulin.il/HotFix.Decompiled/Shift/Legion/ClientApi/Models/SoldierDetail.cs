using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class SoldierDetail
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(2)]
	public int PortalId;

	[ProtoMember(3)]
	public int Num;

	[ProtoMember(4)]
	public int Level;

	[ProtoMember(5)]
	public int PotentialLevel;

	[ProtoMember(6)]
	public int EvoLevel;

	[ProtoMember(7)]
	public int CombatPower;

	[ProtoMember(20)]
	public int Atk;

	[ProtoMember(21)]
	public int Def;

	[ProtoMember(22)]
	public int Hp;

	[ProtoMember(23)]
	public string str_Hp;

	[ProtoMember(24)]
	public string str_CombatPower;

	[ProtoMember(90, TypeName = "Shift.Legion.ClientApi.Models.LegendItemBrief")]
	public List<LegendItemBrief> LegendItems;

	[ProtoMember(91, TypeName = "Shift.Legion.ClientApi.Models.ItemLevel")]
	public List<ItemLevel> Weapons;
}
