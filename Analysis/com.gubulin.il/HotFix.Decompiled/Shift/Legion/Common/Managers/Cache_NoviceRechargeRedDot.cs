using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class Cache_NoviceRechargeRedDot : CacheBaseBehavior
{
	public const string ON_REDDOT_CHANGE = "Cache_NoviceRechargeRedDot";

	public const string ON_RED_DOT_SET = "Cache_NoviceRechargeRedDotSET";

	private bool _isUpdating = false;

	private bool _isShowRedDot = false;

	public bool IsShowRedDot
	{
		get
		{
			return _isShowRedDot;
		}
		set
		{
			if (value != _isShowRedDot)
			{
				_isShowRedDot = value;
				SharedMessenger.Broadcast("Cache_NoviceRechargeRedDot", this);
			}
			SharedMessenger.Broadcast("Cache_NoviceRechargeRedDotSET", this);
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
		if (_isUpdating)
		{
			return;
		}
		_isUpdating = true;
		bool hasRedDot = false;
		Task<NoviceRechargeData> noviceRechargeData = FGUIManager.Instance.GetNoviceRechargeData();
		noviceRechargeData.GetAwaiter().OnCompleted(delegate
		{
			NoviceRechargeData noviceRechargeData2 = FGUIManager.Instance.NoviceRechargeData;
			if (AchievementManager.Achievements.TryGetValue("ACHIEVEMENT035", out var value) && value.Status(GameManagers.Instance) == AchievementStatus.PendingToClaim)
			{
				hasRedDot = true;
			}
			if (!hasRedDot)
			{
				hasRedDot = noviceRechargeData2.Progress.Values.Any((ContinuousRechargeBonus bonus) => bonus.BonusStatus == BonusStatus.CanClaimBonus);
			}
			IsShowRedDot = hasRedDot;
			IsUpdateEnabled = false;
			_isUpdating = false;
		});
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<float>("ON_RECHARGE", OnRecharge);
		SharedMessenger.AddListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
		SharedMessenger.AddListener("RECHARGE_COMBO_BONUS_CLAIMED", OnRechargeBonusClaimed);
	}

	private void OnRecharge(float totalRecord)
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 0.5f;
	}

	private void OnMissionClaimed(Mission mission)
	{
		if (mission.Data.CompleteTrigger == "OnAchievement" && AchievementManager.Achievements.TryGetValue(mission.Data.TriggerPayload, out var value) && (value.Type == AchievementType.TotalRecharge || value.Type == AchievementType.IntlTotalRecharge))
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}

	private void OnRechargeBonusClaimed()
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 0.5f;
	}
}
