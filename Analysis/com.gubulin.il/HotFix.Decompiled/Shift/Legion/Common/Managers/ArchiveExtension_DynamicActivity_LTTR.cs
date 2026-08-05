using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_DynamicActivity_LTTR
{
	public enum BonusState
	{
		Undergoing,
		Pending,
		Claimed
	}

	public class Model
	{
		public Dictionary<string, LTTRInfo> Infos = new Dictionary<string, LTTRInfo>();
	}

	public class LTTRInfo
	{
		public class ClaimedInfo
		{
			public int ClaimedLevel { get; set; }

			public bool IsClaimed { get; set; }

			public int ClaimedTimeStamp { get; set; }
		}

		public string ActivityId { get; set; }

		public Dictionary<string, ClaimedInfo> ClaimedInfos { get; set; } = new Dictionary<string, ClaimedInfo>();

		public List<int> OrderList { get; set; } = new List<int>();

		public float TotalRecharge { get; set; } = 0f;
	}

	private const string Key = "DynamicActivity_LTTR";

	public static Model GetLTTRProgress(this UserArchiveManager manager)
	{
		return manager.GetModel();
	}

	public static void SetLTTRProgress(this UserArchiveManager manager, Model _model)
	{
		manager.SetModel(_model);
	}

	private static Model GetModel(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("DynamicActivity_LTTR");
		if (model == null)
		{
			model = new Model();
			if (model.Infos == null)
			{
				model.Infos = new Dictionary<string, LTTRInfo>();
			}
			manager.SetConfigValue("DynamicActivity_LTTR", model);
		}
		return model;
	}

	private static void SetModel(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue("DynamicActivity_LTTR", _model);
	}

	public static float GetCurrentTotalRecharge(string activityId)
	{
		Model lTTRProgress = GameManagers.Instance.UserArchiveManager.GetLTTRProgress();
		if (!lTTRProgress.Infos.ContainsKey(activityId))
		{
			return 0f;
		}
		return lTTRProgress.Infos[activityId].TotalRecharge;
	}

	public static BonusState GetOneBonusState(string activityId, int bonusLevel)
	{
		Model lTTRProgress = GameManagers.Instance.UserArchiveManager.GetLTTRProgress();
		if (!lTTRProgress.Infos.ContainsKey(activityId))
		{
			return BonusState.Undergoing;
		}
		LTTRInfo lTTRInfo = lTTRProgress.Infos[activityId];
		if (!lTTRInfo.ClaimedInfos.ContainsKey(bonusLevel.ToString()))
		{
			if (lTTRInfo.TotalRecharge >= (float)bonusLevel)
			{
				return BonusState.Pending;
			}
			return BonusState.Undergoing;
		}
		LTTRInfo.ClaimedInfo claimedInfo = lTTRInfo.ClaimedInfos[bonusLevel.ToString()];
		if (claimedInfo.IsClaimed)
		{
			return BonusState.Claimed;
		}
		if (lTTRInfo.TotalRecharge >= (float)bonusLevel)
		{
			return BonusState.Pending;
		}
		return BonusState.Undergoing;
	}

	public static void ClaimedBonus(string activityId, LimitedTimeTotalRechargeInfo rmb_Level, Action action)
	{
		ILRequestHelper<ClaimDynamicActivityLTTRResponse>.Request((EventContext)null, (Func<Task<ClaimDynamicActivityLTTRResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimDynamicActivityLTTR(activityId, rmb_Level.RMB)), (Action<ClaimDynamicActivityLTTRResponse>)delegate(ClaimDynamicActivityLTTRResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Model model = JsonHelper.ToObject<Model>(response.LTTR_Progress);
				GameManagers.Instance.UserArchiveManager.SetLTTRProgress(model);
				int num = 0;
				foreach (KeyValuePair<string, int> reward in rmb_Level.Rewards)
				{
					Bonus bonus = Bonus.Get(reward.Key, reward.Value);
					bonus.Claim(GameManagers.Instance);
				}
				action?.Invoke();
			}
		});
	}
}
