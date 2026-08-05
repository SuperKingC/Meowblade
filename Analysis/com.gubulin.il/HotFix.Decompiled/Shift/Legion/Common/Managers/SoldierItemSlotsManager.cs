using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class SoldierItemSlotsManager : Manager
{
	private const string NormalSoldierKey = "Normal";

	private static Dictionary<string, AttrCheckConf[]> _unlockConditions;

	private static Dictionary<string, Dictionary<int, List<ResourceRequirement>>> _unlockRequirements;

	private SoldiersItemSlots _soldiersItemSlots;

	public static Dictionary<string, AttrCheckConf[]> UnlockConditions
	{
		get
		{
			if (_unlockConditions == null)
			{
				_unlockConditions = new Dictionary<string, AttrCheckConf[]>();
				IEnumerable<GDESoldierItemSlotConfigData> allItems = GDMgr.GetAllItems<GDESoldierItemSlotConfigData>();
				foreach (GDESoldierItemSlotConfigData item in allItems)
				{
					if (!string.IsNullOrEmpty(item.UnlockConditions))
					{
						string key = (string.IsNullOrEmpty(item.SoldierId) ? "Normal" : item.SoldierId);
						if (!_unlockConditions.TryGetValue(key, out var value))
						{
							value = new AttrCheckConf[3];
							_unlockConditions[key] = value;
						}
						AttrCheckConf attrCheckConf = JsonHelper.ToObject<AttrCheckConf>(item.UnlockConditions);
						value[item.SlotId] = attrCheckConf;
					}
				}
			}
			return _unlockConditions;
		}
	}

	public static Dictionary<string, Dictionary<int, List<ResourceRequirement>>> UnlockRequirements
	{
		get
		{
			if (_unlockRequirements == null)
			{
				_unlockRequirements = new Dictionary<string, Dictionary<int, List<ResourceRequirement>>>();
				IEnumerable<GDESoldierItemSlotConfigData> allItems = GDMgr.GetAllItems<GDESoldierItemSlotConfigData>();
				foreach (GDESoldierItemSlotConfigData item in allItems)
				{
					if (string.IsNullOrEmpty(item.UnlockRequirements))
					{
						continue;
					}
					string key = (string.IsNullOrEmpty(item.SoldierId) ? "Normal" : item.SoldierId);
					Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(item.UnlockRequirements);
					if (!_unlockRequirements.TryGetValue(key, out var value))
					{
						value = new Dictionary<int, List<ResourceRequirement>>();
						_unlockRequirements[key] = value;
					}
					List<ResourceRequirement> list = new List<ResourceRequirement>();
					foreach (KeyValuePair<string, int> item2 in dictionary)
					{
						list.Add(new ResourceRequirement
						{
							ItemId = item2.Key,
							Qty = item2.Value
						});
					}
					value[item.SlotId] = list;
				}
			}
			return _unlockRequirements;
		}
	}

	public SoldierItemSlotsManager(GameManagers managers)
		: base(managers)
	{
	}

	public void SetSoldiersItemSlots(SoldiersItemSlots soldiersItemSlots)
	{
		_soldiersItemSlots = soldiersItemSlots;
	}

	public bool IsSlotUnlocked(string soldierId, int slotId)
	{
		_soldiersItemSlots.Value.TryGetValue(soldierId, out var value);
		if (value == null)
		{
			value = new int[3];
			_soldiersItemSlots.Value[soldierId] = value;
		}
		return value[slotId] == 1;
	}

	public void SetSlotUnlocked(string soldierId, int slotId)
	{
		_soldiersItemSlots.Value.TryGetValue(soldierId, out var value);
		if (value == null)
		{
			value = new int[3];
			_soldiersItemSlots.Value[soldierId] = value;
		}
		value[slotId] = 1;
	}

	public bool IsSlotUnlockable(string soldierId, int slotId)
	{
		Soldier data = Managers.SoldierManager.Get(soldierId);
		if (!UnlockConditions.TryGetValue(soldierId, out var value))
		{
			value = UnlockConditions["Normal"];
		}
		return AttributeChecker.Check(value[slotId], data);
	}

	public bool IsSlotUnlockRequirementsEnough(string soldierId, int slotId)
	{
		if (!UnlockRequirements.TryGetValue(soldierId, out var value))
		{
			value = UnlockRequirements["Normal"];
		}
		List<ResourceRequirement> list = value[slotId];
		foreach (ResourceRequirement item in list)
		{
			int stock = Managers.StockController.GetStock(item.ItemId);
			if (stock < item.Qty)
			{
				return false;
			}
		}
		return true;
	}
}
