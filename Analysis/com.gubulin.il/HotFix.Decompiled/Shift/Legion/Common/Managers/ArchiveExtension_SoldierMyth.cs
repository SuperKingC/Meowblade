using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_SoldierMyth
{
	public class Model
	{
		public List<SoldierMyth> SoldierMythData = new List<SoldierMyth>();
	}

	public class SoldierMyth : IId
	{
		public string SoldierId { get; set; }

		public int Level { get; set; } = 0;

		public bool Open { get; set; }

		public string GetId()
		{
			return SoldierId;
		}
	}

	private const string Key = "SoldierMyth";

	private const string CheckLegendItemSlotKey = "LegendItemSlotCheck";

	public static void OpenSoldierMyth(this UserArchiveManager manager, string soldierId)
	{
		Model mythModel = manager.GetMythModel();
		if (!mythModel.SoldierMythData.Any((SoldierMyth s) => s.SoldierId == soldierId))
		{
			manager.AddSoldierMyth(new SoldierMyth
			{
				SoldierId = soldierId,
				Level = 0,
				Open = true
			});
			return;
		}
		for (int num = 0; num < mythModel.SoldierMythData.Count; num++)
		{
			if (soldierId == mythModel.SoldierMythData[num].SoldierId)
			{
				mythModel.SoldierMythData[num].Open = true;
				break;
			}
		}
		manager.SetConfigValue("SoldierMyth", mythModel);
	}

	public static SoldierMyth GetSoldierMyth(this UserArchiveManager manager, string soldierId)
	{
		SoldierMyth soldierMyth = manager.GetMythModel().SoldierMythData.FirstOrDefault((SoldierMyth s) => s.SoldierId == soldierId);
		if (soldierMyth == null)
		{
			soldierMyth = new SoldierMyth
			{
				SoldierId = soldierId,
				Level = 0,
				Open = false
			};
			manager.AddSoldierMyth(soldierMyth);
		}
		return soldierMyth;
	}

	public static bool AddOneSoldierMythLevel(this UserArchiveManager manager, string soldierId, int curLevel)
	{
		Model mythModel = manager.GetMythModel();
		if (!mythModel.SoldierMythData.Any((SoldierMyth s) => s.SoldierId == soldierId))
		{
			return manager.AddSoldierMyth(new SoldierMyth
			{
				SoldierId = soldierId,
				Level = curLevel,
				Open = true
			});
		}
		for (int num = 0; num < mythModel.SoldierMythData.Count; num++)
		{
			if (soldierId == mythModel.SoldierMythData[num].SoldierId)
			{
				mythModel.SoldierMythData[num].Level = curLevel;
				break;
			}
		}
		manager.SetConfigValue("SoldierMyth", mythModel);
		return true;
	}

	public static int GetSStoneCost(this UserArchiveManager manager, string soldierId)
	{
		if (!GDMgr.SoldierMythConfigs.TryGetValue(manager.GetSoldierMyth(soldierId).Level + 1, out var value))
		{
			return 0;
		}
		return value.SStoneCost;
	}

	public static string GetCurrentLevelPercentAttrText(this UserArchiveManager manager, string soldierId, string attrKey, int level = 0)
	{
		if (!GDMgr.SoldierMythConfigs.TryGetValue(manager.GetSoldierMyth(soldierId).Level + level, out var value))
		{
			return string.Empty;
		}
		Dictionary<string, float> percentAttrUi = value.GetPercentAttrUi();
		if (percentAttrUi.Count <= 0)
		{
			return string.Empty;
		}
		if (!percentAttrUi.TryGetValue(attrKey, out var value2))
		{
			return string.Empty;
		}
		return $"{value2}%";
	}

	public static string GetNextLevelPercentAttrIncrementText(this UserArchiveManager manager, string soldierId, string attrKey)
	{
		if (!GDMgr.SoldierMythConfigs.TryGetValue(manager.GetSoldierMyth(soldierId).Level, out var value))
		{
			return string.Empty;
		}
		Dictionary<string, float> percentAttrUi = value.GetPercentAttrUi();
		if (percentAttrUi.Count <= 0)
		{
			return string.Empty;
		}
		if (!percentAttrUi.TryGetValue(attrKey, out var value2))
		{
			return string.Empty;
		}
		if (!GDMgr.SoldierMythConfigs.TryGetValue(manager.GetSoldierMyth(soldierId).Level + 1, out var value3))
		{
			return string.Empty;
		}
		Dictionary<string, float> percentAttrUi2 = value3.GetPercentAttrUi();
		if (percentAttrUi2.Count <= 0)
		{
			return string.Empty;
		}
		if (!percentAttrUi2.TryGetValue(attrKey, out var value4))
		{
			return string.Empty;
		}
		return $"+{value4 - value2:F1}%";
	}

	private static Model GetMythModel(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("SoldierMyth");
		if (model == null)
		{
			model = new Model();
			if (model.SoldierMythData == null)
			{
				model.SoldierMythData = new List<SoldierMyth>();
			}
			manager.SetConfigValue("SoldierMyth", model);
		}
		return model;
	}

	private static void SetModel(this UserArchiveManager manager, Model model)
	{
		manager.SetConfigValue("SoldierMyth", model);
	}

	private static bool AddSoldierMyth(this UserArchiveManager manager, SoldierMyth soldierMyth)
	{
		Model mythModel = manager.GetMythModel();
		bool flag = mythModel.SoldierMythData.AddDistinct(soldierMyth);
		if (flag)
		{
			manager.SetModel(mythModel);
		}
		return flag;
	}

	public static bool GetLegendItemSlotCheckRecord(this UserArchiveManager manager, string soldierId)
	{
		List<string> list = manager.GetConfigValue<List<string>>("LegendItemSlotCheck");
		if (list == null)
		{
			list = new List<string>();
			manager.SetConfigValue("LegendItemSlotCheck", list);
		}
		return list.Contains(soldierId);
	}

	public static void SetLegendItemSlotCheckRecord(this UserArchiveManager manager, string soldierId)
	{
		if (!string.IsNullOrEmpty(soldierId))
		{
			List<string> list = manager.GetConfigValue<List<string>>("LegendItemSlotCheck");
			if (list == null)
			{
				list = new List<string>();
				manager.SetConfigValue("LegendItemSlotCheck", list);
			}
			if (!list.Contains(soldierId))
			{
				list.Add(soldierId);
				manager.SetConfigValue("LegendItemSlotCheck", list);
			}
		}
	}

	public static void UpdateAllLegendSlotCheckRecords(this UserArchiveManager manager)
	{
		if (!Define.SoldierMythUnderDevelopment())
		{
			return;
		}
		List<string> soldiersId = manager.LegendItemSlotIsNotEmpty();
		if (soldiersId.Count <= 0)
		{
			return;
		}
		ILRequestHelper<CheckLegendItemSlotResponse>.Request((EventContext)null, (Func<Task<CheckLegendItemSlotResponse>>)(() => GameController.Contexts.Service<INetworkService>().CheckLegendItemSlot(soldiersId)), (Action<CheckLegendItemSlotResponse>)delegate(CheckLegendItemSlotResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				for (int i = 0; i < soldiersId.Count; i++)
				{
					GameManagers.Instance.UserArchiveManager.SetLegendItemSlotCheckRecord(soldiersId[i]);
				}
			}
		});
	}

	private static List<string> LegendItemSlotIsNotEmpty(this UserArchiveManager manager)
	{
		if (LegendItemsHelper.SoldiersEquippedItems == null || LegendItemsHelper.SoldiersEquippedItems.Count <= 0)
		{
			return new List<string>();
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, long[]> soldiersEquippedItem in LegendItemsHelper.SoldiersEquippedItems)
		{
			if (soldiersEquippedItem.Value != null && soldiersEquippedItem.Value.Length >= 2 && soldiersEquippedItem.Value[1] != 0 && !manager.GetLegendItemSlotCheckRecord(soldiersEquippedItem.Key))
			{
				list.Add(soldiersEquippedItem.Key);
			}
		}
		return list;
	}
}
