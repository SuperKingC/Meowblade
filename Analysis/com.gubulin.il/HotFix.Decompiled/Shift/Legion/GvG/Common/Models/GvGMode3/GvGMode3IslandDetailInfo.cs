using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.Helpers;
using UI.GvGWorldMap3;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3IslandDetailInfo
{
	[ProtoMember(1)]
	public string IslandName;

	[ProtoMember(2)]
	public List<int> IslandActions;

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Collecting.CollectingStockModel")]
	public List<CollectingStockModel> CollectingGroup = new List<CollectingStockModel>();

	[ProtoMember(4)]
	public string UnitInfos;

	[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.IslandBuff")]
	public List<IslandBuff> Buff = new List<IslandBuff>();

	[ProtoMember(6)]
	public float ObedienceValue;

	[ProtoMember(9)]
	public int ExternalSocketPort;

	[ProtoMember(10)]
	public int Pid;

	[ProtoMember(11)]
	public string JsonHoldingScore;

	[ProtoMember(12)]
	public int FlagShipCampId;

	[ProtoMember(13, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission.MissionStateRecordWithProgress")]
	public List<MissionStateRecordWithProgress> IslandEventsProgress;

	[ProtoMember(14)]
	public string REUnitInfos;

	[ProtoMember(15, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandDetailInfo_PlayerInfos")]
	public List<GvGMode3IslandDetailInfo_PlayerInfos> PlayerInfos;

	[ProtoMember(16)]
	public int BossHp;

	[ProtoMember(17)]
	public string ServerMapId;

	[ProtoMember(18, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandBossInfo")]
	public IslandBossInfo BossInfo;

	[ProtoMember(19, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> CurrentCollectingItemStock;

	private Dictionary<string, List<UnitInfo_Protocol>> _unitInfos;

	private List<string> _reUnitInfoKeys;

	private Dictionary<int, List<int>> _campUserIds;

	public bool UnitInfosIsEmpty => string.IsNullOrEmpty(UnitInfos) && string.IsNullOrEmpty(REUnitInfos);

	public int Obedience(int islandId)
	{
		return (ObedienceValue < 0f) ? 100 : Convert.ToInt32(ObedienceValue / (float)WorldMapConfigHelper.GetGvGMode3DefenderZoneConfigs(islandId).NPCRebellionMax * 100f);
	}

	public Dictionary<string, List<UnitInfo_Protocol>> GetUnitInfos()
	{
		if (_unitInfos == null)
		{
			if (!string.IsNullOrEmpty(REUnitInfos))
			{
				_unitInfos = UnitInfoHelper.ToValue(REUnitInfos);
				_reUnitInfoKeys = new List<string>(_unitInfos.Keys);
			}
			if (!string.IsNullOrEmpty(UnitInfos))
			{
				foreach (KeyValuePair<string, List<UnitInfo_Protocol>> item in UnitInfoHelper.ToValue(UnitInfos))
				{
					_unitInfos?.Add(item.Key, item.Value);
				}
			}
		}
		return _unitInfos;
	}

	public List<UI_main_IslandDefenders.UnitInfo> GetUiUnitInfos()
	{
		List<UI_main_IslandDefenders.UnitInfo> list = new List<UI_main_IslandDefenders.UnitInfo>();
		foreach (KeyValuePair<string, List<UnitInfo_Protocol>> unitInfo in GetUnitInfos())
		{
			list.Add(new UI_main_IslandDefenders.UnitInfo
			{
				UnitInfos = unitInfo.Value,
				UnitKey = unitInfo.Key
			});
		}
		return list;
	}

	public bool IsReNpc(string unitKey)
	{
		return _reUnitInfoKeys != null && _reUnitInfoKeys.Contains(unitKey);
	}

	public int DefenderNum()
	{
		Dictionary<string, List<UnitInfo_Protocol>> unitInfos = GetUnitInfos();
		if (unitInfos == null)
		{
			return 0;
		}
		int num = 0;
		foreach (KeyValuePair<string, List<UnitInfo_Protocol>> item in unitInfos)
		{
			if (item.Value == null)
			{
				continue;
			}
			for (int i = 0; i < item.Value.Count; i++)
			{
				if (item.Value[i] != null)
				{
					num += item.Value[i].Total;
				}
			}
		}
		return num;
	}

	public Dictionary<int, int> HoldingScore()
	{
		return (!string.IsNullOrEmpty(JsonHoldingScore)) ? JsonHelper.ToObject<Dictionary<int, int>>(JsonHoldingScore) : new Dictionary<int, int>();
	}

	public List<GvGMode3IslandOutputModel> GetBriefCollectingStock(int num = 3)
	{
		List<GvGMode3IslandOutputModel> list = new List<GvGMode3IslandOutputModel>();
		if (CollectingGroup == null || CollectingGroup.Count <= 0)
		{
			return list;
		}
		for (int i = 0; i < CollectingGroup.Count; i++)
		{
			if (i < num)
			{
				list.Add(new GvGMode3IslandOutputModel(CollectingGroup[i]));
			}
		}
		return list;
	}

	public List<GvGMode3IslandOutputModel> GetAllCollectingStock()
	{
		List<GvGMode3IslandOutputModel> list = new List<GvGMode3IslandOutputModel>();
		if (CollectingGroup == null || CollectingGroup.Count <= 0)
		{
			return list;
		}
		for (int i = 0; i < CollectingGroup.Count; i++)
		{
			list.Add(new GvGMode3IslandOutputModel(CollectingGroup[i]));
		}
		return list;
	}
}
