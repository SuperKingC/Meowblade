using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Formula
{
	public GDEFormulaData Data;

	public readonly string FormulaId;

	public readonly eFormulaType Type;

	public readonly string Input;

	public readonly string Output;

	public readonly int Rarity;

	public Formula(GDEFormulaData data)
	{
		Data = data;
		FormulaId = data.Key;
		Type = (eFormulaType)data.Type;
		Input = data.Input;
		Output = data.Output;
		Rarity = data.Rarity;
	}

	public bool CanUse()
	{
		if (Type == eFormulaType.FreeExchange)
		{
			return false;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Input);
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (item.Value > GameManagers.Instance.StockController.GetStock(item.Key))
			{
				return false;
			}
		}
		return true;
	}

	public bool CanUse(int inputIndex)
	{
		if (Type != eFormulaType.FreeExchange)
		{
			return false;
		}
		List<Dictionary<string, int>> list = JsonHelper.ToObject<List<Dictionary<string, int>>>(Input);
		foreach (KeyValuePair<string, int> item in list[inputIndex])
		{
			if (GameManagers.Instance.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		return true;
	}

	public List<string> GetInputList()
	{
		if (Type == eFormulaType.FreeExchange)
		{
			return null;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Input);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			for (int i = 0; i < item.Value; i++)
			{
				list.Add(item.Key);
			}
		}
		return list;
	}

	public List<string> GetInputList(int inputIndex)
	{
		if (Type != eFormulaType.FreeExchange)
		{
			return null;
		}
		List<Dictionary<string, int>> list = JsonHelper.ToObject<List<Dictionary<string, int>>>(Input);
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, int> item in list[inputIndex])
		{
			for (int i = 0; i < item.Value; i++)
			{
				list2.Add(item.Key);
			}
		}
		return list2;
	}

	public List<string> GetOutputList()
	{
		if (Type != eFormulaType.LimitedExchange && Type != eFormulaType.RarityStoneLimitedExchange)
		{
			return null;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Output);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			for (int i = 0; i < item.Value; i++)
			{
				list.Add(item.Key);
			}
		}
		return list;
	}

	public List<string> GetOutputList(int outputIndex)
	{
		if (Type != eFormulaType.FreeExchange)
		{
			return null;
		}
		List<Dictionary<string, int>> list = JsonHelper.ToObject<List<Dictionary<string, int>>>(Output);
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, int> item in list[outputIndex])
		{
			for (int i = 0; i < item.Value; i++)
			{
				list2.Add(item.Key);
			}
		}
		return list2;
	}

	public bool ClaimFormulaBonus(GameManagers managers, Dictionary<string, float> claimed = null, bool broadcastInform = true, int inputIndex = 0, int outputIndex = 0)
	{
		if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(Output))
		{
			return false;
		}
		if (Type == eFormulaType.FreeExchange)
		{
			return ClaimFreeExchangeFormulaBonus(managers, inputIndex, outputIndex);
		}
		if (Type == eFormulaType.LimitedExchange || Type == eFormulaType.RarityStoneLimitedExchange)
		{
			return ClaimLimitedExchangeFormulaBonus(managers);
		}
		if (Type == eFormulaType.GvGStoreItem)
		{
			return ClaimLimitedStoreItemFormulaBonus(managers);
		}
		if (Type == eFormulaType.GvGStoreLegendItem)
		{
			return ClaimLimitedStoreItemFormulaBonus(managers);
		}
		if (Type == eFormulaType.GvGStoreBlueprint)
		{
			return ClaimLimitedStoreItemFormulaBonus(managers);
		}
		return ClaimLimitedExchangeFormulaBonus(managers);
	}

	private bool ClaimLimitedStoreItemFormulaBonus(GameManagers managers, Dictionary<string, float> claimed = null, bool broadcastInform = true)
	{
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Input);
		Dictionary<string, int> dictionary2 = JsonHelper.ToObject<Dictionary<string, int>>(Output);
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		if (Type != eFormulaType.GvGStoreBlueprint)
		{
			foreach (KeyValuePair<string, int> item2 in dictionary2)
			{
				Bonus.Get(item2.Key, item2.Value).Claim(managers, claimed, $"{113}:{FormulaId}", forceClaim: true, broadcastInform);
			}
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item3 in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item3.Key,
				Offset = -item3.Value,
				Context = 113,
				ContextValue = (FormulaId ?? ""),
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		return true;
	}

	private bool ClaimLimitedExchangeFormulaBonus(GameManagers managers, Dictionary<string, float> claimed = null, bool broadcastInform = true)
	{
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Input);
		Dictionary<string, int> dictionary2 = JsonHelper.ToObject<Dictionary<string, int>>(Output);
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		foreach (KeyValuePair<string, int> item2 in dictionary2)
		{
			Bonus.Get(item2.Key, item2.Value).Claim(managers, claimed, $"{113}:{FormulaId}", forceClaim: true, broadcastInform);
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item3 in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item3.Key,
				Offset = -item3.Value,
				Context = 113,
				ContextValue = (FormulaId ?? ""),
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		return true;
	}

	private bool ClaimFreeExchangeFormulaBonus(GameManagers managers, int inputIndex, int outputIndex, Dictionary<string, float> claimed = null, bool broadcastInform = true)
	{
		if (inputIndex < 0 || outputIndex < 0)
		{
			return false;
		}
		List<Dictionary<string, int>> list = JsonHelper.ToObject<List<Dictionary<string, int>>>(Input);
		List<Dictionary<string, int>> list2 = JsonHelper.ToObject<List<Dictionary<string, int>>>(Output);
		if (inputIndex >= list?.Count || outputIndex >= list2?.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, int> item in list[inputIndex])
		{
			if (managers.StockController.GetStock(item.Key) < item.Value)
			{
				return false;
			}
		}
		foreach (KeyValuePair<string, int> item2 in list2[outputIndex])
		{
			Bonus.Get(item2.Key, item2.Value).Claim(managers, claimed, $"{113}:{FormulaId}", forceClaim: true, broadcastInform);
		}
		StockChangeRecord[] stockChangeRecords = list[inputIndex].ToStockChangeRecords(StockInContext.FormulaBonus, FormulaId ?? "", -1);
		GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
		return true;
	}
}
