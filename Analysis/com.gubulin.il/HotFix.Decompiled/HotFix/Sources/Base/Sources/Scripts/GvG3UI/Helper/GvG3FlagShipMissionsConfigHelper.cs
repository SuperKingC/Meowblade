using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class GvG3FlagShipMissionsConfigHelper
{
	private const string GvGMode3CampMainMissionBonusByRankKey = "GvGMode3CampMainMissionBonusByRank";

	private static Dictionary<string, Dictionary<string, Dictionary<string, int>>> _mainMissionBonusByRank;

	private static Dictionary<string, List<RankBonusData>> _izRankBonusConfigs;

	private static List<GvGMode3CampMissionConfigModel> _missionConfig;

	private static Dictionary<string, GvGMode3CampMissionConfigModel> _missionConfig_Dict;

	private static List<GvGMode3CampProgressConfigModel> _progressConfig;

	private static List<GvGMode3CampProgressConfigModel> _progressConfig_All;

	private static List<GvGMode3EventMissionConfigModel> _eventMissions;

	private static Dictionary<string, GvGMode3ShopEventFormulaConfigModel> _eventShopFormulas;

	public static Dictionary<string, Dictionary<string, Dictionary<string, int>>> MainMissionBonusByRank
	{
		get
		{
			if (_mainMissionBonusByRank == null)
			{
				LoadMissionBonusByRank();
			}
			return _mainMissionBonusByRank;
			static void LoadMissionBonusByRank()
			{
				_mainMissionBonusByRank = "GvGMode3CampMainMissionBonusByRank".ToConfiguration<Dictionary<string, Dictionary<string, Dictionary<string, int>>>>();
			}
		}
	}

	public static Dictionary<string, List<RankBonusData>> IzRankBonusConfigs
	{
		get
		{
			if (_izRankBonusConfigs == null)
			{
				LoadIzRankBonusConfigs();
			}
			return _izRankBonusConfigs;
			static void LoadIzRankBonusConfigs()
			{
				_izRankBonusConfigs = ("RankBonusConfig_" + Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId).ToConfiguration<Dictionary<string, List<RankBonusData>>>();
			}
		}
	}

	public static List<GvGMode3CampMissionConfigModel> MissionConfig => _missionConfig;

	public static Dictionary<string, GvGMode3CampMissionConfigModel> MissionConfig_Dict => _missionConfig_Dict;

	public static List<GvGMode3CampProgressConfigModel> CampMainProgressConfig => _progressConfig.Where((GvGMode3CampProgressConfigModel config) => config.MissionTag() != eCampMainMissionTag.EternalNight).ToList();

	private static List<GvGMode3EventMissionConfigModel> EventMissions
	{
		get
		{
			if (_eventMissions == null)
			{
				LoadMissionConfig();
			}
			return _eventMissions;
			static void LoadMissionConfig()
			{
				IEnumerable<GDEGvGMode3CampMissionData> allItems = GDMgr.GetAllItems<GDEGvGMode3CampMissionData>();
				_eventMissions = new List<GvGMode3EventMissionConfigModel>();
				string arg = string.Empty;
				try
				{
					foreach (GDEGvGMode3CampMissionData item2 in allItems)
					{
						if (!string.IsNullOrEmpty(item2.Type))
						{
							eGvGMode3CampMissionType eGvGMode3CampMissionType = (eGvGMode3CampMissionType)Enum.Parse(typeof(eGvGMode3CampMissionType), item2.Type);
							if (eGvGMode3CampMissionType == eGvGMode3CampMissionType.RE)
							{
								arg = item2.Key;
								eGvGMode3CampMissionSubType eGvGMode3CampMissionSubType = (eGvGMode3CampMissionSubType)Enum.Parse(typeof(eGvGMode3CampMissionSubType), item2.SubType);
								GvGMode3EventMissionConfigModel item = new GvGMode3EventMissionConfigModel
								{
									Key = item2.Key,
									IconIdx = item2.EventIconIdx,
									Icon = item2.Icon,
									UiIcon = item2.UiIcon,
									Cost = ((eGvGMode3CampMissionSubType == eGvGMode3CampMissionSubType.RE_NPCDialog) ? JsonHelper.ToObject<SubTypeModel_RandomEventNPCDialog>(item2.SubTypeData).Cost : null),
									ShowBonus = (string.IsNullOrEmpty(item2.ShowBonus) ? null : JsonHelper.ToObject<Dictionary<string, int>>(item2.ShowBonus)),
									MissionBonus = (string.IsNullOrEmpty(item2.MissionBonus) ? null : JsonHelper.ToObject<MissionBonus>(item2.MissionBonus)),
									SubType = eGvGMode3CampMissionSubType,
									NPCTemplate = (eGvGMode3CampMissionSubType.HasRandomEventReward() ? JsonHelper.ToObject<SubTypeModel_RandomEventBattle>(item2.SubTypeData).NPCTemplate : null),
									BrawlSubTypeData = ((eGvGMode3CampMissionSubType == eGvGMode3CampMissionSubType.RE_FactionWar || eGvGMode3CampMissionSubType == eGvGMode3CampMissionSubType.RE_FFA || eGvGMode3CampMissionSubType == eGvGMode3CampMissionSubType.RE_Ally) ? JsonHelper.ToObject<SubTypeModel_BE>(item2.SubTypeData) : null)
								};
								_eventMissions.Add(item);
							}
						}
					}
				}
				catch (Exception arg2)
				{
					ILRuntimeDebug.LogError($"EventMissions PreLoad Key={arg},ex={arg2}");
					throw;
				}
			}
		}
	}

	public static IEnumerator InitCoroutine()
	{
		if (_missionConfig != null)
		{
			yield break;
		}
		IEnumerable<GDEGvGMode3CampMissionData> missionDatas = GDMgr.GetAllItems<GDEGvGMode3CampMissionData>();
		_missionConfig = new List<GvGMode3CampMissionConfigModel>();
		_missionConfig_Dict = new Dictionary<string, GvGMode3CampMissionConfigModel>();
		_progressConfig = new List<GvGMode3CampProgressConfigModel>();
		_progressConfig_All = new List<GvGMode3CampProgressConfigModel>();
		string campTag = $"Camp{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId}";
		_ = string.Empty;
		int mainMissionGroupId = Singleton<WorldStateManager>.Instance.Data.MainMissionGroupId;
		foreach (GDEGvGMode3CampMissionData m in missionDatas)
		{
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
			if (string.IsNullOrEmpty(m.Type))
			{
				continue;
			}
			eGvGMode3CampMissionType eType = (eGvGMode3CampMissionType)Enum.Parse(typeof(eGvGMode3CampMissionType), m.Type);
			if (eType != eGvGMode3CampMissionType.CampMain && eType != eGvGMode3CampMissionType.CampSide)
			{
				continue;
			}
			_ = m.Key;
			GvGMode3CampMissionConfigModel model = new GvGMode3CampMissionConfigModel
			{
				Key = m.Key,
				GroupId = m.GroupId,
				Type = eType,
				Icon = m.Icon,
				Desc = m.Desc,
				Progress = m.Progress,
				Step = m.Step,
				Tags = m.Tags,
				Timer = m.Timer,
				SucessCheckValue = (string.IsNullOrEmpty(m.SucessCheckValue) ? null : JsonHelper.ToObject<EntityCheck>(m.SucessCheckValue)),
				TriggerOnAccept = (string.IsNullOrEmpty(m.TriggerOnAccept) ? null : JsonHelper.ToObject<Dictionary<string, object>>(m.TriggerOnAccept)),
				TriggerOnFinish = (string.IsNullOrEmpty(m.TriggerOnFinish) ? null : JsonHelper.ToObject<Dictionary<string, object>>(m.TriggerOnFinish)),
				MissionBonus = (string.IsNullOrEmpty(m.MissionBonus) ? null : JsonHelper.ToObject<MissionBonus>(m.MissionBonus)),
				ShowBonus = (string.IsNullOrEmpty(m.ShowBonus) ? null : JsonHelper.ToObject<Dictionary<string, int>>(m.ShowBonus)),
				CollectShadowEnergy = ((eType == eGvGMode3CampMissionType.CampSide && !string.IsNullOrEmpty(m.SubTypeData)) ? JsonHelper.ToObject<SubTypeModelCollectShadowEnergy>(m.SubTypeData).Energy : 0)
			};
			if (eType != eGvGMode3CampMissionType.CampMain || m.Tags.Contains(campTag))
			{
				_missionConfig.Add(model);
				_missionConfig_Dict.Add(model.Key, model);
			}
			if (eType != eGvGMode3CampMissionType.CampMain || model.GroupId != mainMissionGroupId)
			{
				continue;
			}
			int checkValue = (int)((model.SucessCheckValue != null) ? model.SucessCheckValue.GetEntityCheckConditionContent[0] : 0);
			bool isMoonStep = model.Step == 4;
			bool isWaitEternalNight = model.Tags.Contains("WaitEternalNight");
			if (isWaitEternalNight)
			{
				GvGMode3CampProgressConfigModel _config = new GvGMode3CampProgressConfigModel
				{
					Progress = 5,
					StepCnt = 1,
					GroupId = m.GroupId,
					Tags = m.Tags,
					EternalNightStartTimestamp = (isWaitEternalNight ? checkValue : 0),
					CampControlMoonIsland = (isMoonStep ? checkValue : 0)
				};
				if (m.Tags.Contains(campTag))
				{
					_progressConfig.Add(_config);
				}
				_progressConfig_All.Add(_config);
			}
			else if (_progressConfig.Any((GvGMode3CampProgressConfigModel config) => config.Progress == m.Progress) && m.Tags.Contains(campTag))
			{
				GvGMode3CampProgressConfigModel progressModel = _progressConfig.Find((GvGMode3CampProgressConfigModel config) => config.Progress == m.Progress);
				progressModel.StepCnt++;
				if (isMoonStep)
				{
					progressModel.CampControlMoonIsland = checkValue;
				}
			}
			else if (!model.Tags.Contains("EternalNight"))
			{
				GvGMode3CampProgressConfigModel _config2 = new GvGMode3CampProgressConfigModel
				{
					Progress = m.Progress,
					StepCnt = 1,
					GroupId = m.GroupId,
					Tags = m.Tags,
					EternalNightStartTimestamp = 0,
					CampControlMoonIsland = (isMoonStep ? checkValue : 0)
				};
				if (m.Tags.Contains(campTag))
				{
					_progressConfig.Add(_config2);
				}
				_progressConfig_All.Add(_config2);
			}
		}
	}

	public static GvGMode3EventMissionConfigModel EventMissionConfig(string missionConfigId)
	{
		return EventMissions.Find((GvGMode3EventMissionConfigModel m) => m.Key == missionConfigId);
	}

	public static GvGMode3ShopEventFormulaConfigModel EventShopFormulas(string formulaId)
	{
		if (_eventShopFormulas == null)
		{
			_eventShopFormulas = new Dictionary<string, GvGMode3ShopEventFormulaConfigModel>();
		}
		_eventShopFormulas.TryGetValue(formulaId, out var value);
		if (value == null)
		{
			GDEFormulaData gDEFormulaData = GDMgr.Get<GDEFormulaData>(formulaId);
			value = new GvGMode3ShopEventFormulaConfigModel
			{
				RawData = gDEFormulaData,
				FormulaId = gDEFormulaData.Key,
				Rarity = gDEFormulaData.Rarity,
				Input = JsonHelper.ToObject<Dictionary<string, int>>(gDEFormulaData.Input),
				Output = JsonHelper.ToObject<Dictionary<string, int>>(gDEFormulaData.Output)
			};
			_eventShopFormulas.Add(formulaId, value);
		}
		return value;
	}
}
