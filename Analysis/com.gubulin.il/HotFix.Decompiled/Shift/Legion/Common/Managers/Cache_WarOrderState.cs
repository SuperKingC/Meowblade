using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public class Cache_WarOrderState : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANGE = typeof(Cache_WarOrderState).Name + "REDDOT";

	public static string ON_CERT_CHANGE = typeof(Cache_WarOrderState).Name + "CERT";

	private List<Activity> AvailableActivities;

	private Activity NormalActivity;

	private List<int> NormalBonusLevels;

	private List<int> AdvancedBonusLevels;

	private bool _IsShowRedDot;

	private bool _IsMainEntryAvailable;

	private List<string> ScoreItemIds;

	private List<string> CertItemIds;

	private List<Activity> BattlePassActivity;

	public bool IsShowRedDot
	{
		get
		{
			return _IsShowRedDot;
		}
		set
		{
			if (value != _IsShowRedDot)
			{
				_IsShowRedDot = value;
				SharedMessenger.Broadcast(ON_REDDOT_CHANGE, this);
			}
		}
	}

	public bool IsAvailable => GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1003").Contains("P320");

	public bool IsMainEntryAvailable
	{
		get
		{
			return _IsMainEntryAvailable;
		}
		set
		{
			if (value != _IsMainEntryAvailable)
			{
				_IsMainEntryAvailable = value;
				SharedMessenger.Broadcast(ON_CERT_CHANGE, this);
			}
		}
	}

	public int RemainingTime
	{
		get
		{
			if (NormalActivity == null)
			{
				return 0;
			}
			DateTimeOffset now = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
			return Convert.ToInt32(NormalActivity.CurRemainingTime(now).TotalSeconds);
		}
	}

	public override IEnumerator Init()
	{
		yield return base.Init();
		base.DelayUpdateFromNow = 3f;
		TimeInterval = 2f;
		_IsShowRedDot = false;
		_IsMainEntryAvailable = false;
		NormalActivity = null;
		ScoreItemIds = new List<string>();
		CertItemIds = new List<string>();
		AvailableActivities = new List<Activity>();
		NormalBonusLevels = new List<int>();
		AdvancedBonusLevels = new List<int>();
		yield return null;
		BattlePassActivity = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.BattlePass, null, isSort: false);
		yield return (object)new WaitForSeconds(0.2f);
		foreach (Activity activity in BattlePassActivity)
		{
			if (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
			{
				continue;
			}
			Dictionary<string, ActivityContentPayload>.Enumerator enumerator2 = activity.ContentPayload(GameManagers.Instance).GetEnumerator();
			enumerator2.MoveNext();
			BattlePassActivityPayload payload = (BattlePassActivityPayload)enumerator2.Current.Value;
			AvailableActivities.Add(activity);
			if (!string.IsNullOrEmpty(payload.ScoreItem) && ScoreItemIds.IndexOf(payload.ScoreItem) < 0)
			{
				ScoreItemIds.Add(payload.ScoreItem);
			}
			if (!string.IsNullOrEmpty(payload.PaidCert) && CertItemIds.IndexOf(payload.PaidCert) < 0)
			{
				CertItemIds.Add(payload.PaidCert);
			}
			if (string.IsNullOrEmpty(payload.PaidCert) && NormalBonusLevels.Count == 0)
			{
				NormalActivity = activity;
				NormalBonusLevels.AddRange(payload.BonusConfig.Keys);
			}
			else if (!string.IsNullOrEmpty(payload.PaidCert) && AdvancedBonusLevels.Count == 0)
			{
				foreach (KeyValuePair<int, Dictionary<string, int>> bonus in payload.BonusConfig)
				{
					int i = 0;
					while (i < bonus.Value.Count)
					{
						AdvancedBonusLevels.Add(bonus.Key);
						int num = i + 1;
						i = num;
					}
				}
			}
			yield return (object)new WaitForSeconds(0.2f);
		}
		NormalBonusLevels.Sort();
		yield return (object)new WaitForSeconds(0.2f);
		AdvancedBonusLevels.Sort();
	}

	public override void DeferredUpdate()
	{
		if (ScoreItemIds.Count == 0 || CertItemIds.Count == 0)
		{
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock(ScoreItemIds.First());
		int stock2 = GameManagers.Instance.StockController.GetStock(CertItemIds.First());
		bool flag = stock2 > 0;
		int num = 0;
		foreach (Activity availableActivity in AvailableActivities)
		{
			num += availableActivity.ClaimProgress(GameManagers.Instance).Count;
		}
		int num2 = 0;
		foreach (int normalBonusLevel in NormalBonusLevels)
		{
			if (normalBonusLevel <= stock)
			{
				num2++;
				continue;
			}
			break;
		}
		if (flag)
		{
			foreach (int advancedBonusLevel in AdvancedBonusLevels)
			{
				if (advancedBonusLevel <= stock)
				{
					num2++;
					continue;
				}
				break;
			}
		}
		IsMainEntryAvailable = IsAvailable && stock2 == 0;
		IsShowRedDot = num < num2;
		IsUpdateEnabled = false;
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelBonusClaimed);
	}

	private void OnLevelBonusClaimed(Level level)
	{
		if (AvailableActivities.Count == 0)
		{
			foreach (Activity item in BattlePassActivity)
			{
				if (item.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
				{
					AvailableActivities.Add(item);
				}
			}
		}
		foreach (Activity item2 in BattlePassActivity)
		{
			if (item2.LevelCase == null || !item2.LevelCase.Contains(level.LevelId))
			{
				continue;
			}
			Dictionary<string, ActivityContentPayload> dictionary = item2.ContentPayload(GameManagers.Instance);
			foreach (ActivityContentPayload value in dictionary.Values)
			{
				BattlePassActivityPayload battlePassActivityPayload = value as BattlePassActivityPayload;
				if (!string.IsNullOrEmpty(battlePassActivityPayload.ScoreItem) && ScoreItemIds.IndexOf(battlePassActivityPayload.ScoreItem) < 0)
				{
					ScoreItemIds.Add(battlePassActivityPayload.ScoreItem);
				}
				if (!string.IsNullOrEmpty(battlePassActivityPayload.PaidCert) && CertItemIds.IndexOf(battlePassActivityPayload.PaidCert) < 0)
				{
					CertItemIds.Add(battlePassActivityPayload.PaidCert);
				}
				if (string.IsNullOrEmpty(battlePassActivityPayload.PaidCert) && NormalBonusLevels.Count == 0)
				{
					NormalActivity = item2;
					NormalBonusLevels.AddRange(battlePassActivityPayload.BonusConfig.Keys);
				}
				else
				{
					if (string.IsNullOrEmpty(battlePassActivityPayload.PaidCert) || AdvancedBonusLevels.Count != 0)
					{
						continue;
					}
					foreach (KeyValuePair<int, Dictionary<string, int>> item3 in battlePassActivityPayload.BonusConfig)
					{
						for (int i = 0; i < item3.Value.Count; i++)
						{
							AdvancedBonusLevels.Add(item3.Key);
						}
					}
				}
			}
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (ScoreItemIds.IndexOf(itemId) >= 0 || CertItemIds.IndexOf(itemId) >= 0)
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}
}
