using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class FormulaExtensions
{
	public struct FormulaItemKv
	{
		public string ItemId { get; private set; }

		public int Count { get; private set; }

		public FormulaItemKv(string itemId, int count)
		{
			ItemId = itemId;
			Count = count;
		}
	}

	public static Formula ToFormula(this string formulaId)
	{
		return GameManagers.Instance.UserArchiveManager.GetStoreItemFormula(formulaId);
	}

	public static FormulaItemKv GetFirstOutputItem(this Formula formula)
	{
		KeyValuePair<string, int> keyValuePair = JsonHelper.ToObject<Dictionary<string, int>>(formula.Output).ToList()[0];
		return new FormulaItemKv(keyValuePair.Key, keyValuePair.Value);
	}

	public static FormulaItemKv GetFirstInputItem(this Formula formula)
	{
		if (formula.Type != eFormulaType.GvGStoreGuaranteed)
		{
			throw new Exception($"GetFirstInputItem fail formula={formula.FormulaId},type={formula.Type}");
		}
		KeyValuePair<string, int> keyValuePair = JsonHelper.ToObject<Dictionary<string, int>>(formula.Input).ToList()[0];
		return new FormulaItemKv(keyValuePair.Key, keyValuePair.Value);
	}
}
