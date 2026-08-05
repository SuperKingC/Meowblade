using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class Cache_BlackMarketTreasureRedDot : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANGE = typeof(Cache_BlackMarketTreasureRedDot).Name;

	private bool _IsUpdating = false;

	private bool _IsShowRedDot = false;

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

	public override IEnumerator Init()
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 1f;
		yield return null;
	}

	public override void DeferredUpdate()
	{
		if (_IsUpdating)
		{
			return;
		}
		_IsUpdating = true;
		bool hasRedDot = false;
		Task<TreasureHouseRechargeInfo> blackMarketTreasureData = FGUIManager.Instance.GetBlackMarketTreasureData();
		blackMarketTreasureData.GetAwaiter().OnCompleted(delegate
		{
			_IsUpdating = false;
			TreasureHouseRechargeInfo blackMarketTreasureData2 = FGUIManager.Instance.BlackMarketTreasureData;
			Activity value;
			if (blackMarketTreasureData2 == null)
			{
				IsUpdateEnabled = false;
			}
			else if (!ActivityManager.Activities.TryGetValue(FGUIManager.BlackMarketTreasureActivityId, out value))
			{
				IsUpdateEnabled = false;
			}
			else
			{
				if (blackMarketTreasureData2.EndTime.CompareTo(DateTimeHelper.ServerNow) == 1)
				{
					int num = 0;
					foreach (ActivityContentPayload value2 in value.ContentPayload(GameManagers.Instance).Values)
					{
						using Dictionary<float, Dictionary<string, float>>.Enumerator enumerator2 = ((TreasureHouseActivityPayload)value2).BonusConfig.GetEnumerator();
						while (enumerator2.MoveNext() && !(enumerator2.Current.Key > blackMarketTreasureData2.TotalRecharge))
						{
							num++;
						}
					}
					hasRedDot = num > blackMarketTreasureData2.HasClaimed.Count;
				}
				IsShowRedDot = hasRedDot;
				IsUpdateEnabled = false;
			}
		});
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<float>("ON_RECHARGE", OnRecharge);
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
		SharedMessenger.AddListener<int>("BLACKMARKET_TREASURE_BONUS_CLAIMED", OnBlackMarketTreasureClaimed);
	}

	private void OnRecharge(float totalRecord)
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 0.5f;
	}

	private void OnLevelComplete(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (FGUIManager.Instance.BlackMarketTreasureData == null && winner == Team.Red)
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}

	private void OnBlackMarketTreasureClaimed(int score)
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 0.01f;
	}
}
