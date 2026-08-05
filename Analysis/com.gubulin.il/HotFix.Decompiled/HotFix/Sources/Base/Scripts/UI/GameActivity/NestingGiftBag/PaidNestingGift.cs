using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public class PaidNestingGift : BaseNestingGift
{
	public StoreItem StoreItem { get; }

	public PaidNestingGift(NestingGiftConfig config)
		: base(config)
	{
		StoreItem = LoadStoreItem(base.ItemId);
	}

	private static StoreItem LoadStoreItem(string itemId)
	{
		List<Modifier> list = Item.Effect(GameManagers.Instance, itemId) ?? new List<Modifier>();
		string text = null;
		foreach (Modifier item in list)
		{
			if (item.ModifierId == "StoreItem")
			{
				text = item.PayloadDictionary["Payload"].ToString();
				break;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new Exception("[UI_WarehousePanel] 展示Item内部礼包 itemId=" + itemId + " StoreItemId 为空");
		}
		return StoreItem.Get(GameManagers.Instance, text);
	}

	public override int GetUiState()
	{
		return (int)GetCurrentState();
	}

	public override void OnClick(Action onSuccess = null)
	{
		GiftState currentState = GetCurrentState();
		if (currentState != GiftState.Claimed && currentState != GiftState.NotGet)
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(StoreItem.ReferenceId, out var value);
			PurchaseManager.Instance.InvokePurchase(StoreItem, value, 1, onSuccess, doubleCheck: true);
		}
	}

	private GiftState GetCurrentState()
	{
		if (!BaseNestingGift.HasStock(base.ItemId))
		{
			return GiftState.NotGet;
		}
		int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(StoreItem.StoreItemId);
		return (StoreItem.PurchaseLimit - purchaseCntAtLimitPeriod > 0) ? GiftState.Claimable : GiftState.Claimed;
	}
}
