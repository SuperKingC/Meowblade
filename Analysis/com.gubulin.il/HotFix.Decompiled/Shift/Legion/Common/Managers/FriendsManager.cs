using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class FriendsManager : Manager
{
	private const string InvitingSlotsConfigKey = "InvitingSlotsConfig";

	private const string InvitedBonusRecordsKey = "InvitedBonusRecords";

	private const string FriendsLimitKey = "FriendsLimit";

	private static Dictionary<int, InvitingConfigData> _invitingConfigDatas;

	private Config<List<int>> _invitedBonusRecords;

	private Config<Dictionary<int, Tuple<int, string, int>>> _invitingSlotsConfig;

	public static Func<Task<GetInvitedWorkersResponse>> SendGetInvitedWorkersRequest;

	public static Func<bool, Task<GetFriendsResponse>> SendGetFriendsRequest;

	public static Dictionary<int, InvitingConfigData> InvitingConfigDatas
	{
		get
		{
			if (_invitingConfigDatas == null)
			{
				_invitingConfigDatas = new Dictionary<int, InvitingConfigData>();
				foreach (GDEInvitingConfigData allItem in GDMgr.GetAllItems<GDEInvitingConfigData>())
				{
					_invitingConfigDatas.Add(allItem.UserLevel, new InvitingConfigData(allItem));
				}
			}
			return _invitingConfigDatas;
		}
	}

	public int InvitingSlots => Managers.UserArchiveManager.GetInvitingSlots();

	public int FriendsLimit
	{
		get
		{
			UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
			if (!userArchiveManager.Contains("FriendsLimit"))
			{
				userArchiveManager.SetFriendsLimit(30);
			}
			return userArchiveManager.GetFriendsLimit();
		}
	}

	public Config<List<int>> InvitedBonusRecords
	{
		get
		{
			if (_invitedBonusRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("InvitedBonusRecords"))
				{
					_invitedBonusRecords = userArchiveManager.GetConfig<List<int>>("InvitedBonusRecords");
				}
				else
				{
					userArchiveManager.SetConfigValue("InvitedBonusRecords", new List<int>());
					_invitedBonusRecords = userArchiveManager.GetConfig<List<int>>("InvitedBonusRecords");
				}
			}
			return _invitedBonusRecords;
		}
	}

	public Config<Dictionary<int, Tuple<int, string, int>>> InvitingSlotsConfig
	{
		get
		{
			if (_invitingSlotsConfig == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("InvitingSlotsConfig"))
				{
					_invitingSlotsConfig = userArchiveManager.GetConfig<Dictionary<int, Tuple<int, string, int>>>("InvitingSlotsConfig");
				}
				else
				{
					userArchiveManager.SetConfigValue("InvitingSlotsConfig", new Dictionary<int, Tuple<int, string, int>>());
					_invitingSlotsConfig = userArchiveManager.GetConfig<Dictionary<int, Tuple<int, string, int>>>("InvitingSlotsConfig");
				}
			}
			return _invitingSlotsConfig;
		}
	}

	public Dictionary<int, Shift.Legion.Common.Models.InvitedWorker> NewExpiredInvitedWorkers { get; set; } = new Dictionary<int, Shift.Legion.Common.Models.InvitedWorker>();

	public Dictionary<int, Shift.Legion.Common.Models.InvitedWorker> InvitedWorkers { get; set; } = new Dictionary<int, Shift.Legion.Common.Models.InvitedWorker>();

	public List<UserInfo> FriendsList { get; set; } = new List<UserInfo>();

	public bool HasNewInvitedWorkers => InvitedWorkers.Values.Any((Shift.Legion.Common.Models.InvitedWorker worker) => worker.Status == InvitedWorkerActivateStatus.New || worker.Status == InvitedWorkerActivateStatus.UnChecked);

	public void AssignInvitedWorker(int slotIndex, int workerId, string buildingType = null, int workbenchIndex = -1)
	{
		if (slotIndex >= InvitingSlots)
		{
			return;
		}
		Dictionary<int, Tuple<int, string, int>> value = InvitingSlotsConfig.GetValue();
		for (int i = 0; i < InvitingSlots; i++)
		{
			if (!value.ContainsKey(i))
			{
				value.Add(i, new Tuple<int, string, int>(0, null, -1));
			}
			if (i == slotIndex)
			{
				value[i] = new Tuple<int, string, int>(workerId, buildingType, workbenchIndex);
			}
			else if (value[i].Item1 == workerId)
			{
				value.Add(i, new Tuple<int, string, int>(0, null, -1));
			}
		}
		InvitingSlotsConfig.Save();
		if (InvitedWorkers.TryGetValue(workerId, out var value2))
		{
			value2.AllocateInfo = new KeyValuePair<string, int>(buildingType, workbenchIndex);
		}
	}

	public FriendsManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		return InitLoadData();
	}

	private async Task InitLoadData()
	{
		await GetInvitedWorkers();
		await GetFriends();
	}

	public static bool ShouldShowCopyInvitingCodeWindow()
	{
		return HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.ChannelCode == "bilibili" || HotUpdateProcess.ChannelCode == "xipu";
	}

	public async Task<Dictionary<int, Shift.Legion.Common.Models.InvitedWorker>> GetInvitedWorkers()
	{
		CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
		taskCompletionSource.IsAsync = true;
		ILRequestHelper<GetInvitedWorkersResponse>.Request(null, () => SendGetInvitedWorkersRequest(), delegate(GetInvitedWorkersResponse response)
		{
			if (response == null)
			{
				taskCompletionSource.TrySetResult(result: false);
			}
			else if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				taskCompletionSource.TrySetResult(result: false);
			}
			else
			{
				if (response.Workers != null)
				{
					InvitedWorkers.Clear();
					foreach (KeyValuePair<int, Shift.Legion.ClientApi.Protocol.Friends.InvitedWorker> worker in response.Workers)
					{
						int key = worker.Key;
						Shift.Legion.ClientApi.Protocol.Friends.InvitedWorker value = worker.Value;
						InvitedWorkers.Add(key, new Shift.Legion.Common.Models.InvitedWorker
						{
							UserId = value.UserId,
							InvitedUserId = value.UserId,
							Avatar = value.Avatar,
							Nickname = value.Nickname,
							Level = Convert.ToInt32(value.Level),
							InviteAt = value.InvitedAt,
							ExpireAt = value.ExpiredAt,
							Status = (InvitedWorkerActivateStatus)value.Status
						});
					}
				}
				if (response.NewExpiredWorkers != null)
				{
					foreach (KeyValuePair<int, Shift.Legion.ClientApi.Protocol.Friends.InvitedWorker> newExpiredWorker in response.NewExpiredWorkers)
					{
						int key2 = newExpiredWorker.Key;
						if (!NewExpiredInvitedWorkers.ContainsKey(key2))
						{
							Shift.Legion.ClientApi.Protocol.Friends.InvitedWorker value2 = newExpiredWorker.Value;
							NewExpiredInvitedWorkers.Add(key2, new Shift.Legion.Common.Models.InvitedWorker
							{
								UserId = value2.UserId,
								InvitedUserId = value2.UserId,
								Avatar = value2.Avatar,
								Nickname = value2.Nickname,
								Level = Convert.ToInt32(value2.Level),
								InviteAt = value2.InvitedAt,
								ExpireAt = value2.ExpiredAt,
								Status = (InvitedWorkerActivateStatus)value2.Status
							});
						}
					}
				}
				if (response.InvitingSlotsConfig != null)
				{
					InvitingSlotsConfig.SetValue(response.InvitingSlotsConfig);
				}
				if (response.BuildingProdConfigs != null)
				{
					foreach (KeyValuePair<string, Dictionary<int, Shift.Legion.ClientApi.Protocol.Building.ProductionConfig>> buildingProdConfig in response.BuildingProdConfigs)
					{
						string key3 = buildingProdConfig.Key;
						if (Managers.BuildingManager.GetBuildingByType(key3) is WorkShop workShop)
						{
							Dictionary<string, Shift.Legion.Common.Models.ProductionConfig> dictionary = new Dictionary<string, Shift.Legion.Common.Models.ProductionConfig>();
							foreach (KeyValuePair<int, Shift.Legion.ClientApi.Protocol.Building.ProductionConfig> item in buildingProdConfig.Value)
							{
								string key4 = item.Key.ToString();
								Shift.Legion.ClientApi.Protocol.Building.ProductionConfig value3 = item.Value;
								dictionary.Add(key4, new Shift.Legion.Common.Models.ProductionConfig
								{
									ProductList = (value3.ProductList ?? new List<string>()),
									Workers = value3.Workers
								});
							}
							workShop.ProductionConfigs = dictionary;
						}
					}
				}
				taskCompletionSource.TrySetResult(result: true);
			}
		}, 1f);
		await taskCompletionSource.Task;
		return InvitedWorkers;
	}

	public void DeleteFriends(int _userId)
	{
		for (int num = FriendsList.Count - 1; num >= 0; num--)
		{
			if (FriendsList[num].UserId == _userId)
			{
				FriendsList.RemoveAt(num);
				break;
			}
		}
	}

	public async Task<List<UserInfo>> GetFriends(bool getNew = false)
	{
		CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
		taskCompletionSource.IsAsync = true;
		ILRequestHelper<GetFriendsResponse>.Request(null, () => SendGetFriendsRequest(getNew), delegate(GetFriendsResponse response)
		{
			if (response == null)
			{
				taskCompletionSource.TrySetResult(result: false);
			}
			else if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				taskCompletionSource.TrySetResult(result: false);
			}
			else
			{
				if (response.Friends != null)
				{
					FriendsList.Clear();
					FriendsList.AddRange(response.Friends);
				}
				taskCompletionSource.TrySetResult(result: true);
			}
		}, 1f);
		await taskCompletionSource.Task;
		return FriendsList;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
	}

	private void OnUserLevelUp(int level)
	{
	}

	public int GetWorkerLifeTimeByLevel(int level)
	{
		int result = 0;
		foreach (KeyValuePair<int, InvitingConfigData> invitingConfigData in InvitingConfigDatas)
		{
			int key = invitingConfigData.Key;
			if (key > level)
			{
				break;
			}
			InvitingConfigData value = invitingConfigData.Value;
			if (value.WorkerLifeTime != 0)
			{
				result = value.WorkerLifeTime;
			}
		}
		return result;
	}

	public float GetWorkerProduceEfficiencyModifier(int level)
	{
		float result = 0f;
		foreach (KeyValuePair<int, InvitingConfigData> invitingConfigData in InvitingConfigDatas)
		{
			int key = invitingConfigData.Key;
			if (key > level)
			{
				break;
			}
			InvitingConfigData value = invitingConfigData.Value;
			if (Math.Abs(value.WorkerProduceEfficiencyModifier) > float.Epsilon)
			{
				result = value.WorkerProduceEfficiencyModifier;
			}
		}
		return result;
	}

	public Dictionary<string, int> GetInvitingBonusByLevel(int level)
	{
		Dictionary<string, int> result = null;
		if (InvitingConfigDatas.TryGetValue(level, out var value))
		{
			result = value.InvitingBonus;
		}
		return result;
	}

	public Dictionary<string, int> GetInvitedBonusByLevel(int level)
	{
		Dictionary<string, int> result = null;
		if (InvitingConfigDatas.TryGetValue(level, out var value))
		{
			result = value.InvitedBonus;
		}
		return result;
	}
}
