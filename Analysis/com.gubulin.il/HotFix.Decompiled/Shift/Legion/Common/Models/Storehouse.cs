using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class Storehouse : Building
{
	public object Controller;

	public Dictionary<string, float> MainstreamStocks = new Dictionary<string, float>();

	public StockStatus StockStatus = StockStatus.Level0;

	private int timerid = -1;

	private int last_refresh_tm = 0;

	public Storehouse(GameManagers managers)
		: base(managers, "11")
	{
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		NewCheckStockStatus();
	}

	public override bool HasAnyInform()
	{
		if (base.HasAnyInform())
		{
			return true;
		}
		if (MainstreamStocks.Count > 0)
		{
			string key = MainstreamStocks.First().Key;
			if (Managers.StockController.GetStock(key) >= Managers.StockController.GetLimit(key))
			{
				return true;
			}
		}
		return false;
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		if (!Contexts.sharedInstance.Service<BaseSceneService>().GetEnableMainCityProduce())
		{
			return;
		}
		if (timerid <= 0)
		{
			timerid = ScriptApi.CreateTimer(0.5f, NewCheckStockStatus);
			return;
		}
		TimerEntity entityWithId = Contexts.sharedInstance.timer.GetEntityWithId(timerid);
		if (entityWithId != null)
		{
			entityWithId.ReplaceRepeat(1);
			entityWithId.ReplaceDuration(0.5f);
			entityWithId.ReplaceElapsedTime(0f);
			entityWithId.ReplaceCallbackAction(NewCheckStockStatus);
		}
		else
		{
			timerid = ScriptApi.CreateTimer(0.5f, NewCheckStockStatus);
		}
	}

	private void NewCheckStockStatus()
	{
		int num = (int)GameController.Instance.GetServerTime();
		if (num - last_refresh_tm < 5 || !GameController.Contexts.gameState.isMainCityInitialized)
		{
			return;
		}
		last_refresh_tm = (int)GameController.Instance.GetServerTime();
		List<float> stockPercentByCategory = Managers.StockController.GetStockPercentByCategory(1, 10);
		List<float> stockPercentByCategory2 = Managers.StockController.GetStockPercentByCategory(11, 10);
		List<float> stockPercentByCategory3 = Managers.StockController.GetStockPercentByCategory(12, 10);
		List<float> stockPercentByCategory4 = Managers.StockController.GetStockPercentByCategory(13, 10);
		List<float> list = new List<float>();
		list.AddRange(stockPercentByCategory);
		list.AddRange(stockPercentByCategory2);
		list.AddRange(stockPercentByCategory3);
		list.AddRange(stockPercentByCategory4);
		list.Sort();
		list.Reverse();
		float num2 = 0f;
		float num3 = Math.Min(list.Count, 10);
		for (int i = 0; (float)i < num3; i++)
		{
			num2 += list[i];
		}
		if (num3 == 0f)
		{
			Managers.Messenger.Broadcast("STOCK_STATUS_CHANGED", 0);
			return;
		}
		float num4 = num2 / num3;
		StockStatus stockStatus = StockStatus;
		if (num4 < 0.05f)
		{
			StockStatus = StockStatus.Level0;
		}
		else if (num4 < 0.15f)
		{
			StockStatus = StockStatus.Level1;
		}
		else if (num4 < 0.3f)
		{
			StockStatus = StockStatus.Level2;
		}
		else if (num4 < 0.6f)
		{
			StockStatus = StockStatus.Level3;
		}
		else
		{
			StockStatus = StockStatus.Level4;
		}
		if (StockStatus != stockStatus)
		{
			Managers.Messenger.Broadcast("STOCK_STATUS_CHANGED", (int)StockStatus);
		}
	}

	private void CheckStockStatus()
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		foreach (GDEStorehouseData value in StockController.StorehouseDataDictionary.Values)
		{
			if (value.Category == 1 || value.Category == 11 || value.Category == 12 || value.Category == 13)
			{
				int stock = Managers.StockController.GetStock(value.ItemId);
				if (stock > 0 && !dictionary.ContainsKey(value.ItemId))
				{
					dictionary.Add(value.ItemId, (float)stock / (float)Managers.StockController.GetLimit(value.ItemId));
				}
			}
		}
		MainstreamStocks.Clear();
		foreach (KeyValuePair<string, float> item in dictionary.OrderByDescending((KeyValuePair<string, float> kv) => kv.Value).Take(10))
		{
			MainstreamStocks.Add(item.Key, item.Value);
		}
		StockStatus stockStatus = StockStatus;
		float num = MainstreamStocks.Average((KeyValuePair<string, float> kv) => kv.Value);
		if (num < 0.05f)
		{
			StockStatus = StockStatus.Level0;
		}
		else if (num < 0.15f)
		{
			StockStatus = StockStatus.Level1;
		}
		else if (num < 0.3f)
		{
			StockStatus = StockStatus.Level2;
		}
		else if (num < 0.6f)
		{
			StockStatus = StockStatus.Level3;
		}
		else
		{
			StockStatus = StockStatus.Level4;
		}
		if (StockStatus != stockStatus)
		{
			Managers.Messenger.Broadcast("STOCK_STATUS_CHANGED", (int)StockStatus);
		}
	}
}
