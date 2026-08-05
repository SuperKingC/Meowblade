using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using GameDataEditor;
using HotFix;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Helpers;

public static class SchemaIndexHelper
{
	private static Dictionary<string, string> _idToSchemaDictionary;

	public static Dictionary<string, string> IdToSchemaDictionary
	{
		get
		{
			if (_idToSchemaDictionary == null)
			{
				string json = GDMgr.LoadGameDataFileAllText(null, "SchemaIndexHelper");
				_idToSchemaDictionary = JsonHelper.ToObject<Dictionary<string, string>>(json);
				GDMgr.ReleaseGameDataFileAllText("SchemaIndexHelper");
			}
			return _idToSchemaDictionary;
		}
	}

	public static string GetSchemaById(string itemId)
	{
		if (!IdToSchemaDictionary.ContainsKey(itemId))
		{
			return "Item";
		}
		return IdToSchemaDictionary[itemId].ToString();
	}

	public static string GetNameById(GameManagers managers, string itemId)
	{
		string text;
		switch (GetSchemaById(itemId))
		{
		case "Soldier":
			text = managers.SoldierManager.Get(itemId).Name;
			break;
		case "Product":
		{
			GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(itemId);
			text = ((gDEProductData == null) ? itemId : Item.Name(managers, gDEProductData.ItemId));
			break;
		}
		case "Building":
			text = managers.BuildingManager.GetBuildingByType(itemId)?.Name ?? itemId;
			break;
		case "Technology":
			text = GDMgr.Get<GDETechnologyData>(itemId)?.Name ?? itemId;
			break;
		default:
			text = Item.Name(managers, itemId);
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			text = itemId;
		}
		return text;
	}

	public static string GetNameByIdWithLineBreak(GameManagers managers, string itemId)
	{
		string nameById = GetNameById(managers, itemId);
		return AddLineBreak(nameById);
	}

	public static string GetNameWithLineBreak(this StoreItem item)
	{
		return AddLineBreak(item.Name);
	}

	public static string RemoveLineBreak(this string name)
	{
		return name.Replace("\n", "");
	}

	public static string AddLineBreak(string name)
	{
		if (HotUpdateProcess.LanguageKey != "eng")
		{
			return name;
		}
		if (name.Contains("\n"))
		{
			return name;
		}
		Match match = Regex.Match(name, "\\(.*\\)");
		if (!match.Success)
		{
			return name;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(name.Substring(0, match.Index - 1));
		stringBuilder.Append("\n");
		stringBuilder.Append(name.Substring(match.Index));
		return stringBuilder.ToString();
	}
}
