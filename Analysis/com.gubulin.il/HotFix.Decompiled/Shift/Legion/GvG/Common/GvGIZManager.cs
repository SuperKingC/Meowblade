using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Common.Models.InstanceZoneModels;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.GvG.Common;

public class GvGIZManager
{
	public class UserCampMissionData
	{
		public string MissionConfigId;

		public string BonusId;

		public int BonusNum;

		public string BonusName;

		public int TargetScore;

		public int Index;

		public eCampMissionState State;
	}

	public class CampMissionData
	{
		public string MissionConfigId;

		public string Icon;

		public List<CampMissionBonus> Bonuses;

		public string Title;

		public string Desc;

		public string BossIcon;

		public eCampMissionState State;
	}

	public class CampMissionBonus
	{
		public string ItemId;

		public int Num;
	}

	private class UserTriggerClass
	{
		public int WBScore;
	}

	public class WaitContent
	{
		public int AfterIZBegin { get; set; } = -1;

		public int AfterPickMission { get; set; } = -1;

		public int CalcBossRebornTime(int beginTimestamp, int pickedTime)
		{
			if (AfterIZBegin > 0)
			{
				return beginTimestamp + AfterIZBegin;
			}
			if (AfterPickMission > 0)
			{
				return pickedTime + AfterPickMission;
			}
			return 0;
		}
	}

	private static GvGIZManager _Instance;

	public Action OnDataLoaded;

	public List<InstanceZone_Protocol> IZInfos;

	private Dictionary<string, string> CustomizeTables;

	public Dictionary<string, FinalBossDamageRewardTable> DamageRewardTables;

	private int _BossRebornTime;

	private int _BossCampPickedTime;

	private Dictionary<string, Dictionary<string, List<UserCampMissionData>>> _UserCampMission;

	private Dictionary<string, Dictionary<string, List<CampMissionData>>> _CampMission;

	private Dictionary<string, CampMissionData> LoadedCampMission;

	private Dictionary<string, WaitContent> SpecialCampMission;

	private Coroutine UpdateDataCoroutine;

	private bool NeedCustomizeTables;

	public static GvGIZManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new GvGIZManager();
			}
			return _Instance;
		}
	}

	private GvGIZManager()
	{
		NeedCustomizeTables = true;
	}

	public void LoadDataOnce()
	{
		if (IZInfos != null)
		{
			OnDataLoaded?.Invoke();
		}
		else
		{
			UpdateData();
		}
	}

	public void LoadDataPerSecond()
	{
		if (UpdateDataCoroutine == null)
		{
			UpdateDataCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateDataPerSecond());
		}
	}

	public void StopLoadDataPerSecond()
	{
		if (UpdateDataCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(UpdateDataCoroutine);
			UpdateDataCoroutine = null;
		}
	}

	private IEnumerator UpdateDataPerSecond()
	{
		while (true)
		{
			UpdateData();
			yield return (object)new WaitForSeconds(60f);
		}
	}

	public void UpdateData()
	{
		ILRequestHelper<GvGGetIZInfosResponse>.Request((EventContext)null, (Func<Task<GvGGetIZInfosResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGGetIZInfos(NeedCustomizeTables)), (Action<GvGGetIZInfosResponse>)delegate(GvGGetIZInfosResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowMessage("GvGGetIZInfos 请求失败！");
			}
			else if (response.IZInfos == null)
			{
				ILRuntimeDebug.LogError("GvGGetWorldBossInfo: List<InstanceZone_Protocol> IZInfos 为 null");
			}
			else if (response.IZInfos.Count == 0)
			{
				ILRuntimeDebug.LogError("GvGGetWorldBossInfo: List<InstanceZone_Protocol> IZInfos.Count 为0");
			}
			else
			{
				IZInfos = response.IZInfos;
				_CampMission = new Dictionary<string, Dictionary<string, List<CampMissionData>>>();
				_UserCampMission = new Dictionary<string, Dictionary<string, List<UserCampMissionData>>>();
				LoadedCampMission = new Dictionary<string, CampMissionData>();
				SpecialCampMission = new Dictionary<string, WaitContent>();
				if (NeedCustomizeTables)
				{
					NeedCustomizeTables = false;
					CustomizeTables = JsonHelper.ToObject<Dictionary<string, string>>(response.CustomizeTables);
					DamageRewardTables = new Dictionary<string, FinalBossDamageRewardTable>();
				}
				OnDataLoaded?.Invoke();
			}
		});
	}

	public List<UserCampMissionData> GetUserCampMissions(string _IZId, string _campID)
	{
		if (!_UserCampMission.TryGetValue(_IZId, out var value))
		{
			if (!IZInfos.Exists((InstanceZone_Protocol info) => info.IZId == _IZId))
			{
				ILRuntimeDebug.LogError("GetUserCampMissions: IZInfos 中不存在 IZId " + _IZId + " 的相关数据");
				return null;
			}
			value = new Dictionary<string, List<UserCampMissionData>>();
			_UserCampMission.Add(_IZId, value);
		}
		if (!value.TryGetValue(_campID, out var value2))
		{
			InstanceZone_Protocol instanceZoneInfo = GetInstanceZoneInfo(_IZId);
			if (instanceZoneInfo.CampUserMissionConfigs == null || !instanceZoneInfo.CampUserMissionConfigs.TryGetValue(_campID, out var value3))
			{
				ILRuntimeDebug.LogError("GetUserCampMissions: IZInfos 中不存在 IZId " + _IZId + " campID " + _campID + " 的相关数据");
				return null;
			}
			value2 = new List<UserCampMissionData>();
			value.Add(_campID, value2);
			int num = 0;
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			string text = $"{dailyRefreshTime.Year}_{dailyRefreshTime.Month}_{dailyRefreshTime.Day}";
			ArchiveExtension_WorldBossRecord.Model worldBossRecordModel = GameManagers.Instance.UserArchiveManager.GetWorldBossRecordModel();
			if (worldBossRecordModel.Records.TryGetValue(_IZId, out var value4))
			{
				num = value4.TotalScore;
			}
			for (int num2 = 0; num2 < value3.Count; num2++)
			{
				CampMissionConfig campMissionConfig = value3[num2];
				GDEGvGCampMissionData gDEGvGCampMissionData = GDMgr.Get<GDEGvGCampMissionData>(campMissionConfig.Id);
				if (gDEGvGCampMissionData == null)
				{
					ILRuntimeDebug.LogError("GetUserCampMissions: GDEGvGCampMissionData 中不存在 Id " + campMissionConfig.Id + " 的相关数据");
					continue;
				}
				Dictionary<string, int>.Enumerator enumerator = JsonHelper.ToObject<Dictionary<string, int>>(gDEGvGCampMissionData.DisplayBonus).GetEnumerator();
				enumerator.MoveNext();
				KeyValuePair<string, int> current = enumerator.Current;
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(current.Key);
				int wBScore = JsonHelper.ToObject<UserTriggerClass>(gDEGvGCampMissionData.TriggerCondition).WBScore;
				eCampMissionState eCampMissionState = GameManagers.Instance.UserArchiveManager.GetGvGUserCampMissionState(_IZId, campMissionConfig.Id);
				if (num >= wBScore && eCampMissionState != eCampMissionState.Claimed)
				{
					eCampMissionState = eCampMissionState.Completed;
				}
				value2.Add(new UserCampMissionData
				{
					Index = num2,
					MissionConfigId = campMissionConfig.Id,
					BonusId = current.Key,
					BonusNum = current.Value,
					BonusName = gDEItemData?.Name,
					TargetScore = wBScore,
					State = eCampMissionState
				});
			}
		}
		return value2;
	}

	public List<CampMissionData> GetCampMissions(string _IZId, string _campID)
	{
		if (!_CampMission.TryGetValue(_IZId, out var value))
		{
			if (!IZInfos.Exists((InstanceZone_Protocol info) => info.IZId == _IZId))
			{
				ILRuntimeDebug.LogError("GetCampMissions: IZInfos 中不存在 IZId " + _IZId + " 的相关数据");
				return null;
			}
			value = new Dictionary<string, List<CampMissionData>>();
			_CampMission.Add(_IZId, value);
		}
		InstanceZone_Protocol instanceZoneInfo = GetInstanceZoneInfo(_IZId);
		if (!value.TryGetValue(_campID, out var value2))
		{
			value2 = new List<CampMissionData>();
			value.Add(_campID, value2);
			IEnumerable<GDEGvGCampMissionData> allItems = GDMgr.GetAllItems<GDEGvGCampMissionData>();
			foreach (GDEGvGCampMissionData item in allItems)
			{
				List<CampMissionBonus> list = new List<CampMissionBonus>();
				Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(item.DisplayBonus);
				if (dictionary == null)
				{
					WaitContent value3 = JsonHelper.ToObject<WaitContent>(item.TriggerCondition);
					SpecialCampMission.Add(item.Key, value3);
				}
				else
				{
					if (!item.Tags.Contains("UIShow"))
					{
						continue;
					}
					string title = item.Name;
					string desc = item.Desc;
					foreach (KeyValuePair<string, int> item2 in dictionary)
					{
						list.Add(new CampMissionBonus
						{
							ItemId = item2.Key,
							Num = item2.Value
						});
					}
					if (item.Tags.Contains("Special1") && instanceZoneInfo.IZProgress < 2)
					{
						title = "？？？？？？？？？";
						desc = "？？？？？？？？？";
						list.Clear();
					}
					CampMissionData campMissionData = new CampMissionData
					{
						MissionConfigId = item.Key,
						Icon = "ui://PublicResources/" + item.Icon,
						Bonuses = list,
						Title = title,
						Desc = desc,
						State = eCampMissionState.Pending
					};
					value2.Add(campMissionData);
					LoadedCampMission.Add(campMissionData.MissionConfigId, campMissionData);
				}
			}
		}
		if (instanceZoneInfo.CampMissions != null && instanceZoneInfo.CampMissions.TryGetValue(_campID, out var value4))
		{
			foreach (CampMission item3 in value4)
			{
				if (LoadedCampMission.TryGetValue(item3.MissionConfigId, out var value5))
				{
					value5.State = (eCampMissionState)item3.State;
				}
				if (SpecialCampMission.TryGetValue(item3.MissionConfigId, out var value6) && item3.State == 2)
				{
					_BossRebornTime = value6.CalcBossRebornTime(instanceZoneInfo.BeginTimestamp, item3.PickedTimestamp);
					_BossCampPickedTime = item3.PickedTimestamp;
				}
			}
		}
		else
		{
			ILRuntimeDebug.LogError("GetCampMissions: IZInfos 中不存在 IZId " + _IZId + " campID " + _campID + " 的相关数据");
		}
		return value2;
	}

	public int GetBossRebornTime(string _IZId, string _campID)
	{
		List<CampMissionData> campMissions = GetCampMissions(_IZId, _campID);
		return _BossRebornTime;
	}

	public int GetBossDeadTime(string _IZId, string _campID)
	{
		List<CampMissionData> campMissions = GetCampMissions(_IZId, _campID);
		return _BossCampPickedTime;
	}

	public InstanceZone_Protocol GetInstanceZoneInfo(string _IZId)
	{
		return IZInfos.Find((InstanceZone_Protocol info) => info.IZId == _IZId);
	}

	public FinalBossDamageRewardTable GetDamageRewardTable(string _IZId)
	{
		if (DamageRewardTables.TryGetValue(_IZId, out var value))
		{
			return value;
		}
		if (CustomizeTables.TryGetValue(_IZId, out var value2))
		{
			Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(value2);
			if (dictionary.TryGetValue("最终BOSS的总伤害奖励表", out var value3))
			{
				FinalBossDamageRewardTable finalBossDamageRewardTable = JsonHelper.ToObject<FinalBossDamageRewardTable>(value3);
				DamageRewardTables.Add(_IZId, finalBossDamageRewardTable);
				return finalBossDamageRewardTable;
			}
		}
		return null;
	}
}
