using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class GvG3BattlePassActivityPayload : ActivityContentPayload
{
	public readonly string ScoreItem = string.Empty;

	public readonly string PaidCert = string.Empty;

	public readonly Dictionary<int, Dictionary<string, int>> BonusConfig = new Dictionary<int, Dictionary<string, int>>();

	public readonly Dictionary<int, Dictionary<string, int>> SpecialBonusConfig = new Dictionary<int, Dictionary<string, int>>();

	public readonly List<int> SpecialNodes;

	public readonly List<string> SpecialBonus;

	public readonly BattlePassType BattlePassType;

	public GvG3BattlePassActivityPayload(int contentPayloadIndex, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = contentPayloadIndex;
		Activity = activity;
		if (data.TryGetValue("Bonus", out var value))
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value;
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				Dictionary<string, int> value2 = JsonHelper.ToObject<Dictionary<string, int>>(JsonHelper.ToJson(item.Value));
				BonusConfig.Add(int.Parse(item.Key), value2);
			}
		}
		if (data.TryGetValue("SpecialNodes", out var value3))
		{
			SpecialNodes = JsonHelper.ToObject<List<int>>(JsonHelper.ToJson(value3));
		}
		if (data.TryGetValue("ScoreItem", out var value4))
		{
			ScoreItem = value4.ToString();
			if (string.IsNullOrEmpty(ScoreItem))
			{
				throw new Exception("BattlePass 的 ScoreItem 不能为空");
			}
		}
		if (data.TryGetValue("PaidCert", out var value5))
		{
			PaidCert = value5.ToString();
			if (!string.IsNullOrEmpty(PaidCert))
			{
				if (GDMgr.Get<GDEItemData>(PaidCert) == null)
				{
					throw new Exception("BattlePass 的 PaidCert 不是物品");
				}
				BattlePassType = GetBattlePassActivityPayloadType(PaidCert);
			}
			else
			{
				BattlePassType = BattlePassType.Basic;
			}
		}
		else
		{
			BattlePassType = BattlePassType.Basic;
		}
		if (data.TryGetValue("SpecialBonus", out var value6))
		{
			SpecialBonus = JsonHelper.ToObject<List<string>>(JsonHelper.ToJson(value6));
		}
	}

	private static BattlePassType GetBattlePassActivityPayloadType(string paidCert)
	{
		return (ItemType)Item.ItemType(paidCert) switch
		{
			ItemType.GvGServerBattlePassAdvancedPaidCert => BattlePassType.Advanced, 
			ItemType.GvGServerBattlePassPremiumPaidCert => BattlePassType.Premium, 
			_ => BattlePassType.None, 
		};
	}

	public int ClaimBonus(GameManagers managers, List<int> nodes, ref Dictionary<string, float> claimed)
	{
		if (!string.IsNullOrEmpty(PaidCert))
		{
			int stock = managers.StockController.GetStock(PaidCert);
			if (stock <= 0)
			{
				return 81310001;
			}
		}
		int stock2 = managers.StockController.GetStock(ScoreItem);
		foreach (int node in nodes)
		{
			if (stock2 < node)
			{
				continue;
			}
			if (BonusConfig.TryGetValue(node, out var value))
			{
				foreach (KeyValuePair<string, int> item in value)
				{
					Bonus bonus = Bonus.Get(item.Key, item.Value);
					bonus.Claim(managers, claimed);
				}
			}
			if (!SpecialBonusConfig.TryGetValue(node, out var value2))
			{
				continue;
			}
			foreach (KeyValuePair<string, int> item2 in value2)
			{
				Bonus bonus2 = Bonus.Get(item2.Key, item2.Value);
				bonus2.Claim(managers, claimed);
			}
		}
		return 0;
	}
}
