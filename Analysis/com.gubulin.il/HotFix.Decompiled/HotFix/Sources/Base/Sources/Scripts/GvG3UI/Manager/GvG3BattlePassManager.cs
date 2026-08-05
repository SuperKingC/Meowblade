using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGBattlePass3;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3BattlePassManager : Singleton<GvG3BattlePassManager>
{
	public class LevelConfig
	{
		public int Level;

		public int ContributionScore;

		public Dictionary<string, int> NormalBonuses;

		public Dictionary<string, int> AdvancedBonuses;

		public Dictionary<string, int> PremiumBonuses;

		public bool IsSpecialNode = false;
	}

	public class ConfigData
	{
		public int Version;

		public Activity NormalActivity;

		public GvG3BattlePassActivityPayload NormalPayload;

		public Activity AdvancedActivity;

		public GvG3BattlePassActivityPayload AdvancedPayload;

		public Activity PremiumActivity;

		public GvG3BattlePassActivityPayload PremiumPayload;

		public List<LevelConfig> LevelConfigs;
	}

	private static readonly Dictionary<string, ActivityBundle> _battleActivityBundles = "GvGMode3BattlePassVersion".ToConfiguration<Dictionary<string, ActivityBundle>>();

	private const string _GVG_MODE3_BATTLE_PASS_VERSION = "GvGMode3BattlePassVersion";

	private ConfigData _data = null;

	private Action<ConfigData> _onLoaded = delegate
	{
	};

	private bool _hasClaimable = false;

	private bool _isEventRegistered;

	public Action OnChangeHasClaimable = delegate
	{
	};

	public bool HasClaimable => _hasClaimable;

	public void RegisterSocketEvents()
	{
		if (!_isEventRegistered)
		{
			_isEventRegistered = true;
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnTotalContributionPointsChanged = (Action<int>)Delegate.Combine(instance.OnTotalContributionPointsChanged, new Action<int>(OnTotalContributionPointsChanged));
			WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
			instance2.OnAdvancedPaidCertChanged = (Action<bool>)Delegate.Combine(instance2.OnAdvancedPaidCertChanged, new Action<bool>(OnAdvancedPaidCertChanged));
			WorldStateManager instance3 = Singleton<WorldStateManager>.Instance;
			instance3.OnPremiumPaidCertChanged = (Action<bool>)Delegate.Combine(instance3.OnPremiumPaidCertChanged, new Action<bool>(OnPremiumPaidCertChanged));
		}
	}

	public void UnregisterSocketEvents()
	{
		if (_isEventRegistered)
		{
			_isEventRegistered = false;
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnTotalContributionPointsChanged = (Action<int>)Delegate.Remove(instance.OnTotalContributionPointsChanged, new Action<int>(OnTotalContributionPointsChanged));
			WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
			instance2.OnAdvancedPaidCertChanged = (Action<bool>)Delegate.Remove(instance2.OnAdvancedPaidCertChanged, new Action<bool>(OnAdvancedPaidCertChanged));
			WorldStateManager instance3 = Singleton<WorldStateManager>.Instance;
			instance3.OnPremiumPaidCertChanged = (Action<bool>)Delegate.Remove(instance3.OnPremiumPaidCertChanged, new Action<bool>(OnPremiumPaidCertChanged));
		}
	}

	public void GetConfigData(Action<ConfigData> onLoaded = null, Action clearCurData = null)
	{
		int battlePassDataVersion = Singleton<GvGMode3RoomManager>.Instance.BattlePassDataVersion;
		ConfigData data = _data;
		bool flag = data == null || data.Version != battlePassDataVersion;
		if (_data != null && !flag)
		{
			onLoaded?.Invoke(_data);
			return;
		}
		if (onLoaded != null)
		{
			_onLoaded = (Action<ConfigData>)Delegate.Combine(_onLoaded, onLoaded);
		}
		clearCurData?.Invoke();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(LoadConfigData(battlePassDataVersion));
	}

	public void CheckClaimable()
	{
		GetConfigData(delegate(ConfigData data)
		{
			HashSet<int> hashSet = new HashSet<int>();
			HashSet<int> hashSet2 = new HashSet<int>();
			HashSet<int> hashSet3 = new HashSet<int>();
			bool isIZInSettlement = Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement;
			WorldStateModel data2 = Singleton<WorldStateManager>.Instance.Data;
			SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
			Dictionary<string, List<int>> dictionary = (isIZInSettlement ? playerSettlement.GvGBattlePassRecord : data2.BattlePassClaimedBonus);
			if (!string.IsNullOrEmpty(data.NormalActivity?.ActivityId))
			{
				dictionary.TryGetValue(data.NormalActivity.ActivityId, out var value);
				hashSet = new HashSet<int>(value ?? new List<int>());
			}
			if (!string.IsNullOrEmpty(data.AdvancedActivity?.ActivityId))
			{
				dictionary.TryGetValue(data.AdvancedActivity.ActivityId, out var value2);
				hashSet2 = new HashSet<int>(value2 ?? new List<int>());
			}
			if (!string.IsNullOrEmpty(data.PremiumActivity?.ActivityId))
			{
				dictionary.TryGetValue(data.PremiumActivity.ActivityId, out var value3);
				hashSet3 = new HashSet<int>(value3 ?? new List<int>());
			}
			int num = Mathf.FloorToInt(isIZInSettlement ? playerSettlement.ContributionPoints : ((float)data2.TotalContributionPoints));
			bool flag = (isIZInSettlement ? playerSettlement.HasAdvancedPass : data2.HasBattlePassPaidCert);
			bool flag2 = (isIZInSettlement ? playerSettlement.HasPremiumPass : data2.HasBattlePassPremiumPaidCert);
			bool flag3 = false;
			foreach (LevelConfig levelConfig in data.LevelConfigs)
			{
				if (levelConfig.ContributionScore > num)
				{
					break;
				}
				bool flag4 = levelConfig.NormalBonuses.Count > 0 && !hashSet.Contains(levelConfig.ContributionScore);
				bool flag5 = flag && levelConfig.AdvancedBonuses.Count > 0 && !hashSet2.Contains(levelConfig.ContributionScore);
				bool flag6 = flag2 && levelConfig.PremiumBonuses.Count > 0 && !hashSet3.Contains(levelConfig.ContributionScore);
				if (flag4 || flag5 || flag6)
				{
					flag3 = true;
					break;
				}
			}
			if (flag3 != _hasClaimable)
			{
				_hasClaimable = flag3;
				OnChangeHasClaimable?.Invoke();
			}
		}, UI_main_GvG3BattlePass.ClearConfigData);
	}

	public ActivityBundle GetBundle()
	{
		string text = Singleton<GvGMode3RoomManager>.Instance.BattlePassDataVersion.ToString();
		if (!_battleActivityBundles.TryGetValue(text, out var value))
		{
			throw new Exception("GvG3BattlePassManager.GetBundle BattlePassVersion Config Is Wrong,version=" + text);
		}
		return value;
	}

	private IEnumerator LoadConfigData(int version)
	{
		List<Activity> activities = GetBattlePassActivities(version);
		yield return null;
		ConfigData data = new ConfigData
		{
			Version = version
		};
		foreach (Activity activity in activities)
		{
			Dictionary<string, ActivityContentPayload>.Enumerator enumerator2 = activity.ContentPayload(GameManagers.Instance).GetEnumerator();
			enumerator2.MoveNext();
			GvG3BattlePassActivityPayload payload = (GvG3BattlePassActivityPayload)enumerator2.Current.Value;
			switch (payload.BattlePassType)
			{
			case BattlePassType.Basic:
				data.NormalActivity = activity;
				data.NormalPayload = payload;
				break;
			case BattlePassType.Advanced:
				data.AdvancedActivity = activity;
				data.AdvancedPayload = payload;
				break;
			case BattlePassType.Premium:
				data.PremiumActivity = activity;
				data.PremiumPayload = payload;
				break;
			default:
				throw new ArgumentOutOfRangeException("GvG3BattlePassManager.LoadConfigData payload is wrong,ActivityId=" + activity.ActivityId);
			}
		}
		HashSet<int> pointHash = new HashSet<int>(data.NormalPayload.BonusConfig.Keys);
		HashSet<int> specialPoint = new HashSet<int>(data.NormalPayload.SpecialNodes);
		if (data.AdvancedPayload != null)
		{
			foreach (int point in data.AdvancedPayload.BonusConfig.Keys)
			{
				pointHash.Add(point);
			}
			foreach (int point2 in data.AdvancedPayload.SpecialNodes)
			{
				specialPoint.Add(point2);
			}
		}
		if (data.PremiumPayload != null)
		{
			foreach (int point3 in data.PremiumPayload.BonusConfig.Keys)
			{
				pointHash.Add(point3);
			}
			foreach (int point4 in data.PremiumPayload.SpecialNodes)
			{
				specialPoint.Add(point4);
			}
		}
		List<int> pointList = pointHash.ToList();
		pointList.Sort();
		yield return null;
		int level = 1;
		data.LevelConfigs = new List<LevelConfig>();
		foreach (int point5 in pointList)
		{
			Dictionary<string, int> normalBonuses = new Dictionary<string, int>(1);
			data.NormalPayload?.BonusConfig?.TryGetValue(point5, out normalBonuses);
			Dictionary<string, int> advancedBonuses = new Dictionary<string, int>(1);
			data.AdvancedPayload?.BonusConfig?.TryGetValue(point5, out advancedBonuses);
			Dictionary<string, int> premiumBonuses = new Dictionary<string, int>(1);
			data.PremiumPayload?.BonusConfig?.TryGetValue(point5, out premiumBonuses);
			data.LevelConfigs.Add(new LevelConfig
			{
				Level = level++,
				ContributionScore = point5,
				NormalBonuses = (normalBonuses ?? new Dictionary<string, int>()),
				AdvancedBonuses = (advancedBonuses ?? new Dictionary<string, int>()),
				PremiumBonuses = (premiumBonuses ?? new Dictionary<string, int>()),
				IsSpecialNode = specialPoint.Contains(point5)
			});
		}
		_data = data;
		_onLoaded(data);
		_onLoaded = null;
	}

	private static List<Activity> GetBattlePassActivities(int version)
	{
		if (!_battleActivityBundles.TryGetValue(version.ToString(), out var value))
		{
			throw new Exception($"GvG3BattlePassManager.GetBattlePassActivities BattlePassVersion Config Is Wrong,version={version}");
		}
		List<Activity> activities = new List<Activity>(3);
		AddActivity(value.Basic?.ActivityId);
		AddActivity(value.Advanced?.ActivityId);
		AddActivity(value.Premium?.ActivityId);
		return activities;
		void AddActivity(string activityId)
		{
			if (!string.IsNullOrEmpty(activityId) && ActivityManager.Activities.TryGetValue(activityId, out var value2))
			{
				activities.Add(value2);
			}
		}
	}

	private void OnAdvancedPaidCertChanged(bool paid)
	{
		CheckClaimable();
	}

	private void OnPremiumPaidCertChanged(bool paid)
	{
		CheckClaimable();
	}

	private void OnTotalContributionPointsChanged(int totalContributionPoint)
	{
		CheckClaimable();
	}
}
