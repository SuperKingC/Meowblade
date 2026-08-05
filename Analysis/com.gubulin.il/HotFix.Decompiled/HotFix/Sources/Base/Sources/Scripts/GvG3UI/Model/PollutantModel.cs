using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class PollutantModel
{
	private string PurificationId { get; }

	private float PurificationRate { get; }

	public string CostItemId { get; }

	private int CostNumber { get; }

	public RItem PollutantItem { get; }

	public int PermitPurifyNumber { get; private set; }

	public int PermitCostNumber { get; private set; }

	public bool CanAllPurify { get; private set; }

	public PollutantModel(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		PollutantItemEffect pollutantItemEffect = JsonHelper.ToObject<PollutantItemEffect>(gDEItemData.Effect);
		KeyValuePair<string, int> keyValuePair = pollutantItemEffect.Get.ToList()[0];
		PurificationId = keyValuePair.Key;
		PurificationRate = 1f / (float)keyValuePair.Value;
		KeyValuePair<string, int> keyValuePair2 = pollutantItemEffect.Cost.ToList()[0];
		CostItemId = keyValuePair2.Key;
		CostNumber = keyValuePair2.Value;
		PollutantItem = new RItem
		{
			ItemId = itemId
		};
	}

	public void UpdatePurifyNumber()
	{
		PollutantItem.cnt = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(PollutantItem.ItemId, includingGSStock: true);
		int num = GameManagers.Instance.StockController.GetLimit(PurificationId) - Singleton<GvGStoreHouseManager>.Instance.GetItemCount(PurificationId, includingGSStock: true);
		PermitPurifyNumber = Mathf.Min(PollutantItem.cnt, (int)((float)Mathf.Max(0, num) * PurificationRate));
		PermitCostNumber = CostNumber * PermitPurifyNumber;
		CanAllPurify = PermitPurifyNumber >= PollutantItem.cnt;
	}
}
