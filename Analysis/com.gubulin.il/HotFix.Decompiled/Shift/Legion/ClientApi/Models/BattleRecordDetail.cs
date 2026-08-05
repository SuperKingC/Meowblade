using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class BattleRecordDetail
{
	[ProtoMember(1)]
	public string FormationId;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.SoldierDetail")]
	public List<SoldierDetail> Soldiers;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.TechLevel")]
	public List<TechLevel> Techs;

	[ProtoMember(5)]
	public List<int> PvP_ReplaySegments;

	[ProtoMember(6)]
	public List<int> PvP_ReplayFrames;

	[ProtoMember(7)]
	public string PvP_Details;

	[ProtoMember(8)]
	public string CombatPower;

	[ProtoMember(9)]
	public string CustomizeData;

	private Dictionary<string, List<ItemAbility>> customizeDataDic;

	public Dictionary<string, List<ItemAbility>> CustomizeDataDic
	{
		get
		{
			if (string.IsNullOrEmpty(CustomizeData))
			{
				return new Dictionary<string, List<ItemAbility>>();
			}
			Dictionary<string, List<ItemAbility>> dictionary = customizeDataDic ?? (customizeDataDic = JsonHelper.ToObject<Dictionary<string, List<ItemAbility>>>(CustomizeData));
			if (dictionary == null)
			{
				return new Dictionary<string, List<ItemAbility>>();
			}
			return dictionary;
		}
	}
}
