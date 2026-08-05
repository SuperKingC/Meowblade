using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

public class TakeItemsCommandExecutor
{
	public TakeItemsCommandExecutor(Contexts contexts)
	{
	}

	public void Prepare()
	{
	}

	public void Execute(TakeItemsCommand cmd)
	{
		if (cmd.items == null || cmd.items.Count == 0)
		{
			return;
		}
		foreach (Bonus item in cmd.items)
		{
			if (item.ItemId.IndexOf("Unlock.") >= 0)
			{
				string itemId = item.ItemId.Replace("Unlock.", "");
				Bonus bonus = Bonus.Get(itemId, new List<int> { 1, item.Qty }, 2);
				bonus.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
			}
			else if (item.ItemId.IndexOf("PotentialLevel.") >= 0)
			{
				string key = item.ItemId.Replace("PotentialLevel.", "");
				Bonus bonus2 = Bonus.Get("PotentialLevel", new Dictionary<string, float> { { key, item.Qty } });
				bonus2.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
			}
			else
			{
				item.Claim(GameManagers.Instance);
			}
		}
	}
}
