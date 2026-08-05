using System;
using System.Collections.Generic;
using Shift.Legion;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public abstract class BaseNestingGift : INestingGift
{
	private const string I40105 = "I40105";

	public string ItemId { get; }

	public int Count { get; }

	public string IconUrl { get; }

	public string Name { get; }

	protected BaseNestingGift(NestingGiftConfig config)
	{
		ItemId = config.ItemId;
		Count = config.Count;
		IconUrl = config.IconUrl;
		Name = ConstStr.GetItemNameXCountString(Item.Name(GameManagers.Instance, "I40105"), Count);
	}

	protected static bool HasStock(string itemId)
	{
		return GameManagers.Instance.StockController.GetStock(itemId) > 0;
	}

	protected static bool CheckItemUsable(string itemId)
	{
		string text = "";
		string text2 = "";
		List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
		if (list != null)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "UseMinChapter")
				{
					text = item.GetPayload<string>();
				}
				if (item.ModifierId == "UseMinLevel")
				{
					text2 = item.GetPayload<string>();
				}
			}
		}
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2) && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(text).Contains(text2))
		{
			return false;
		}
		return true;
	}

	public abstract int GetUiState();

	public abstract void OnClick(Action onSuccess = null);
}
