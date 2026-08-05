using System;
using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;

public class SyncGsStockManager : Singleton<SyncGsStockManager>
{
	public void RegisterSync()
	{
		S2C_ItemChange.OnPushEvent = (Action<S2C_ItemChange.Request>)Delegate.Combine(S2C_ItemChange.OnPushEvent, new Action<S2C_ItemChange.Request>(OnPushItemChange));
	}

	public void UnregisterSync()
	{
		S2C_ItemChange.OnPushEvent = (Action<S2C_ItemChange.Request>)Delegate.Remove(S2C_ItemChange.OnPushEvent, new Action<S2C_ItemChange.Request>(OnPushItemChange));
	}

	private void OnPushItemChange(S2C_ItemChange.Request req)
	{
		if (req.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(req.ErrorCode);
		}
		else
		{
			if (req.Items == null)
			{
				return;
			}
			foreach (RItem item in req.Items)
			{
				StockInContext stockInContext = (StockInContext)req.StockInContext;
				if (stockInContext == StockInContext.GvGMode3_BattlePass_Bonus)
				{
					int num = item.cnt - GameManagers.Instance.StockController.GetStock(item.ItemId);
					if (num > 0)
					{
						ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, item.ItemId)}+{num}");
					}
				}
				if (!StorehouseHelper.IsGvGItem(item.ItemId))
				{
					GameManagers.Instance.StockController.SetStock(item.ItemId, item.cnt, stockInContext);
					continue;
				}
				int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item.ItemId, includingGSStock: true);
				int num2 = item.cnt - itemCount;
				Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(new Dictionary<string, int> { { item.ItemId, item.cnt } });
				GameManagers.Instance.Messenger.Broadcast("ON_GVGSTOREHOUSE_STOCK_CHANGE", item.ItemId, num2);
				ItemChangePack arg = new ItemChangePack
				{
					ItemId = item.ItemId,
					Offset = num2,
					Reason = stockInContext
				};
				GameManagers.Instance.Messenger.Broadcast("ON_GVGSTOREHOUSE_STOCK_CHANGE_WITH_REASON", arg);
			}
		}
	}
}
