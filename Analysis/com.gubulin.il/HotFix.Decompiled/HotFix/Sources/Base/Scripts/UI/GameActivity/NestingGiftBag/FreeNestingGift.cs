using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public class FreeNestingGift : BaseNestingGift
{
	private readonly string _unlockTip;

	public FreeNestingGift(NestingGiftConfig config, string unlockTip)
		: base(config)
	{
		_unlockTip = unlockTip;
	}

	public override int GetUiState()
	{
		return (int)GetCurrentState();
	}

	public override void OnClick(Action onSuccess = null)
	{
		switch (GetCurrentState())
		{
		case GiftState.Claimed:
			break;
		case GiftState.NotGet:
			_unlockTip.ToTip();
			break;
		default:
			UseItem(base.ItemId, onSuccess);
			break;
		}
	}

	private GiftState GetCurrentState()
	{
		if (!BaseNestingGift.CheckItemUsable(base.ItemId))
		{
			return GiftState.NotGet;
		}
		return BaseNestingGift.HasStock(base.ItemId) ? GiftState.Claimable : GiftState.Claimed;
	}

	private void UseItem(string itemId, Action onSuccess)
	{
		int num = 1;
		GameManagers gameManagers = GameManagers.Instance;
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, itemId, num, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<Bonus> list = new List<Bonus>();
				if (response.Bonuses != null)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
					}
				}
				if (response.StockChangeRecords != null)
				{
					gameManagers.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				foreach (Bonus item in list)
				{
					ILRequestHelper.ShowMessage($"{global::Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, item.ItemId)}+{item.Qty}");
				}
				onSuccess?.Invoke();
			}
		});
	}
}
