using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using GameMaths;
using HotFix;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Managers;

public static class LanguagesManager
{
	private static Dictionary<string, string> _legendItemTextTemplates;

	private static Dictionary<string, List<string>> _legendItemRandomValueText;

	private static Dictionary<string, string> _JsonErrorMessages;

	private static Dictionary<string, string> _languagesTemplates;

	private static Dictionary<string, string> _legendItemEntryIdText;

	private static Dictionary<string, string> _legendItemEntryPrecision = new Dictionary<string, string>();

	private static Dictionary<string, List<ItemEntryScoreConfig>> _itemEntryScoreConfigDict;

	public const string ChangePropetryToBeConfirmed = "ChangePropetryToBeConfirmed";

	public const string ChangePropetry = "ChangePropetry";

	private const string MaxValueColor = "#D52B09";

	private const int MaxValueFontSize = 36;

	public const string LegendItemSubEntryUnlockTip = "LegendItemSubEntryUnlockTip";

	public const string CustomerServiceQq = "CustomerService_QQ";

	private static string _comma;

	public static string Comma
	{
		get
		{
			if (_comma == null)
			{
				if (HotUpdateProcess.LanguageKey == "eng")
				{
					_comma = ", ";
				}
				else
				{
					_comma = "，";
				}
			}
			return _comma;
		}
	}

	public static string Colon
	{
		get
		{
			if (HotUpdateProcess.LanguageKey == "eng")
			{
				return ":";
			}
			return "：";
		}
	}

	public static bool HasTemplate(string key)
	{
		return _legendItemTextTemplates.ContainsKey(key);
	}

	public static string GetLockedSubEntryText()
	{
		return "[color=#AC9D78]" + GetDesc("CsharpCodeZhTcText56") + "[/color]";
	}

	public static string GetCustomerServiceQq()
	{
		string result = "";
		if (_languagesTemplates.TryGetValue("CustomerService_QQ", out var value))
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				value += "CustomerService_QQ";
			}
			return value;
		}
		return result;
	}

	public static string GetActionResultMessage(ActionResultCode id)
	{
		if (_languagesTemplates.TryGetValue($"ActionResultCode_{(int)id}", out var value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		if (_languagesTemplates.TryGetValue("ActionResultCode_Default", out var value2))
		{
			string format = value2;
			int num = (int)id;
			return string.Format(format, num.ToString());
		}
		return $"ActionResultCode:{id}";
	}

	public static string GetJsonErrorMessage(int id)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (_JsonErrorMessages == null)
		{
			TextAsset val = Addressables.LoadAssetAsync<TextAsset>((object)"ErrorCode.json").WaitForCompletion();
			_JsonErrorMessages = JsonHelper.ToObject<Dictionary<string, string>>(val.text);
			Addressables.Release<TextAsset>(val);
		}
		if (_JsonErrorMessages.TryGetValue($"ErrorCode_{id}", out var value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		return $"ErrorCode:{id}";
	}

	public static string GetErrorMessage(int id)
	{
		if (_languagesTemplates.TryGetValue($"ErrorCode_{id}", out var value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		if (_languagesTemplates.TryGetValue("ErrorCode_Default", out var value2))
		{
			return string.Format(value2, id.ToString());
		}
		return $"ErrorCode:{id}";
	}

	public static string GetDesc(string id, bool returnKey = true)
	{
		if (_languagesTemplates.TryGetValue(id, out var value))
		{
			if (value == "&nbsp;")
			{
				return string.Empty;
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				value += (returnKey ? id : string.Empty);
			}
			return value;
		}
		return returnKey ? id : string.Empty;
	}

	public static string GetDesc(string id, string defaultValue)
	{
		string desc = GetDesc(id, returnKey: false);
		if (string.IsNullOrWhiteSpace(desc))
		{
			return defaultValue;
		}
		return desc;
	}

	public static string GetErrorDesc(string codeId, object[] _data)
	{
		if (_languagesTemplates.TryGetValue(codeId, out var value))
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				value += codeId;
			}
			return string.Format(value, _data);
		}
		return codeId;
	}

	public static string GetCertificationDesc(int _code, int _count, string qqId = "961307252")
	{
		string text = $"ErrorCode_{_code}";
		if (_languagesTemplates.TryGetValue(text, out var value))
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return value + text;
			}
			if (_code == 1005005)
			{
				return string.Format(value, _count);
			}
			return string.Format(value, qqId, _count);
		}
		return text;
	}

	public static string GetAuthenticateMessage(string origin)
	{
		string key = "AuthenticateError_" + origin;
		if (_languagesTemplates.TryGetValue(key, out var value))
		{
			return value;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return "Authenticate Failed";
		}
		return origin;
	}

	public static string GetSetDesc(string id)
	{
		string text = "";
		string key = "Set_" + id + "_Name";
		string key2 = "Set_" + id + "_Desc";
		string key3 = "Set_" + id + "_Fx1";
		string key4 = "Set_" + id + "_Fx2";
		if (_languagesTemplates.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value))
		{
			text = text + value + Environment.NewLine;
		}
		if (_languagesTemplates.TryGetValue(key2, out var value2) && !string.IsNullOrWhiteSpace(value2))
		{
			text = text + value2 + Environment.NewLine;
		}
		if (_languagesTemplates.TryGetValue(key3, out var value3) && !string.IsNullOrWhiteSpace(value3))
		{
			text = text + value3 + Environment.NewLine;
		}
		if (_languagesTemplates.TryGetValue(key4, out var value4) && !string.IsNullOrWhiteSpace(value4))
		{
			text += value4;
		}
		return text;
	}

	public static void LoadLanguagesTemplates()
	{
		_languagesTemplates = new Dictionary<string, string>();
		List<GDELanguagesData> list = GDMgr.GetAllItems<GDELanguagesData>().ToList();
		for (int i = 0; i < list.Count; i++)
		{
			_languagesTemplates.Add(list[i].Key, list[i].Template);
		}
	}

	public static void LoadLegendItemTextTemplates()
	{
		_legendItemTextTemplates = new Dictionary<string, string>();
		_legendItemRandomValueText = new Dictionary<string, List<string>>();
		_legendItemEntryIdText = new Dictionary<string, string>();
		_itemEntryScoreConfigDict = new Dictionary<string, List<ItemEntryScoreConfig>>();
		List<GDELegendItemPropertyData> list = GDMgr.GetAllItems<GDELegendItemPropertyData>().ToList();
		string[] separator = new string[1] { "],[" };
		for (int i = 0; i < list.Count; i++)
		{
			GDELegendItemPropertyData gDELegendItemPropertyData = list[i];
			string value = (_languagesTemplates.ContainsKey(gDELegendItemPropertyData.DescTemplateId) ? _languagesTemplates[gDELegendItemPropertyData.DescTemplateId] : "");
			string key = gDELegendItemPropertyData.Key;
			_legendItemTextTemplates.Add(key, value);
			_legendItemEntryIdText.Add(key, gDELegendItemPropertyData.DescTemplateId);
			List<Dictionary<string, string>> list2 = JsonHelper.ToObject<List<Dictionary<string, string>>>(gDELegendItemPropertyData.Payload);
			if (list2.First()["Type"] != "随机")
			{
				continue;
			}
			_itemEntryScoreConfigDict.Add(key, new List<ItemEntryScoreConfig>());
			for (int j = 0; j < list2.Count && j <= 1; j++)
			{
				Dictionary<string, string> dictionary = list2[j];
				string[] source = dictionary["Value"].TrimStart('[').TrimEnd(']').Split(separator, StringSplitOptions.None);
				string[] array = source.First().Split(',');
				string text = array[0];
				bool flag = text.EndsWith("%");
				float value2 = 0f;
				if (flag)
				{
					if (!NumericParser.TryFloat(text.TrimEnd('%'), out value2))
					{
						ILRuntimeDebug.LogError("float parse failed 1! lBorder=" + text);
					}
					value2 /= 100f;
				}
				else if (!NumericParser.TryFloat(text, out value2))
				{
					ILRuntimeDebug.LogError("float parse failed 2! lBorder=" + text);
				}
				float num = value2;
				float num2 = Mathf.Abs(num);
				string[] array2 = source.Last().Split(',');
				string text2 = array2[1];
				bool flag2 = text2.EndsWith("%");
				float value3 = 0f;
				if (flag2)
				{
					if (!NumericParser.TryFloat(text2.TrimEnd('%'), out value3))
					{
						ILRuntimeDebug.LogError("float parse failed 3! rBorder=" + text2);
					}
					value3 /= 100f;
				}
				else if (!NumericParser.TryFloat(text2, out value3))
				{
					ILRuntimeDebug.LogError("float parse failed 4! rBorder=" + text2);
				}
				float num3 = value3;
				float num4 = Mathf.Abs(num3);
				float deltaScore;
				if (dictionary.TryGetValue("DeltaScore", out var value4) && !string.IsNullOrEmpty(value4) && value4 != "0")
				{
					if (!NumericParser.TryFloat(value4, out var value5))
					{
						ILRuntimeDebug.LogError("float parse failed 5! deltaScoreConf=" + value4);
					}
					deltaScore = value5 * 10000f;
				}
				else
				{
					float num5 = num3 - num;
					if (Mathf.Abs(num5) < float.Epsilon)
					{
						deltaScore = 100000000f;
					}
					else
					{
						int num6 = int.Parse(dictionary["BaseScore"]);
						int num7 = int.Parse(dictionary["MaxScore"]);
						deltaScore = (float)(num7 - num6) / num5;
					}
				}
				string text3 = dictionary["Key"];
				if (flag || flag2)
				{
					text3 += "_PCT";
				}
				bool flag3 = Modifier.NeedPercentConvertProcess(text3);
				if (flag3 || flag)
				{
					num2 *= 100f;
				}
				if (flag3 || flag2)
				{
					num4 *= 100f;
				}
				if (!_legendItemEntryPrecision.ContainsKey(key))
				{
					_legendItemEntryPrecision.Add(key, array[2]);
				}
				List<string> list3 = new List<string>();
				string text4 = array[2].TrimEnd('%');
				if (text4.Contains(".") && text4.Split('.')[1].Length >= 2)
				{
					string text5 = $"F{text4.Split('.')[1].Length}";
					list3 = new List<string>
					{
						(num2.ToString(text5) ?? "").TrimEnd('.'),
						(num4.ToString(text5) ?? "").TrimEnd('.')
					};
				}
				else
				{
					list3 = new List<string>
					{
						$"{num2:F1}".TrimEnd('0').TrimEnd('.'),
						$"{num4:F1}".TrimEnd('0').TrimEnd('.')
					};
				}
				for (int k = 0; k < list3.Count; k++)
				{
					if (!list3[k].Contains(".") && (array[2].Contains(".") || array2[2].Contains(".")))
					{
						list3[k] += ".0";
					}
				}
				if (j == 1)
				{
					_legendItemRandomValueText.Add($"{key}_{j}", list3);
				}
				else
				{
					_legendItemRandomValueText.Add(key, list3);
				}
				_itemEntryScoreConfigDict[key].Add(new ItemEntryScoreConfig
				{
					EntryId = key,
					EntryKey = text3,
					MinVal = num,
					MaxVal = num3,
					DeltaScore = deltaScore
				});
			}
		}
	}

	public static string GetEntryValuePrecision(string entryId, bool isFxEntry = false)
	{
		if (!_legendItemEntryPrecision.ContainsKey(entryId))
		{
			return "F1";
		}
		if (!isFxEntry)
		{
			return "F1";
		}
		string text = _legendItemEntryPrecision[entryId];
		if (text.Contains("%"))
		{
			text = text.TrimEnd('%');
		}
		if (text.Contains('.'))
		{
			int length = text.Split('.')[1].Length;
			if (length == 0)
			{
				return "";
			}
			return $"F{length}";
		}
		return "";
	}

	public static List<string> GetPropetryRandomValueText(string randomKey)
	{
		List<string> value;
		return _legendItemRandomValueText.TryGetValue(randomKey, out value) ? value : new List<string>();
	}

	public static string GetLegendItemEntryIdText(string propetryId)
	{
		string value;
		return _legendItemEntryIdText.TryGetValue(propetryId, out value) ? value : propetryId;
	}

	public static string GetLegendItemTextTemplates(string propetryId)
	{
		string value;
		return _legendItemTextTemplates.TryGetValue(propetryId, out value) ? value : string.Empty;
	}

	public static string GetLegendItemPropetryDesc(string propetryId, List<ItemEntryData> itemEntryData, bool isFxEntry = false)
	{
		List<object> list = new List<object>();
		int num = 0;
		string text = "";
		bool flag = true;
		foreach (ItemEntryData itemEntryDatum in itemEntryData)
		{
			string key = propetryId;
			if (num != 0)
			{
				key = $"{propetryId}_{1}";
			}
			list.Add(SetMaxValueTextStyle(itemEntryDatum.GetValueString(propetryId, isFxEntry), propetryId, itemEntryDatum, out var maxLogoText));
			if (string.IsNullOrWhiteSpace(maxLogoText))
			{
				flag = false;
			}
			else
			{
				text = maxLogoText;
			}
			if (_legendItemRandomValueText.ContainsKey(key))
			{
				List<string> list2 = _legendItemRandomValueText[propetryId];
				if (!isFxEntry)
				{
					for (int i = 0; i < list2.Count; i++)
					{
						list2[i] = NumericParser.Float(list2[i]).ToString("F1");
					}
				}
				list.AddRange(_legendItemRandomValueText[key]);
			}
			num++;
		}
		string format = (_legendItemTextTemplates.ContainsKey(propetryId) ? _legendItemTextTemplates[propetryId] : "");
		return (!string.IsNullOrWhiteSpace(text) && flag) ? (text + string.Format(format, list.ToArray())) : string.Format(format, list.ToArray());
	}

	public static int GetChangeEntryValueTipType(string propetryId, List<ItemEntryData> itemEntryDataList)
	{
		if (!_itemEntryScoreConfigDict.TryGetValue(propetryId, out var value))
		{
			return 0;
		}
		bool flag = true;
		bool flag2 = false;
		for (int i = 0; i < itemEntryDataList.Count; i++)
		{
			ItemEntryData itemEntryData = itemEntryDataList[i];
			string text = itemEntryData.Key;
			if (itemEntryData.IsPercent)
			{
				text += "_PCT";
			}
			ItemEntryScoreConfig itemEntryScoreConfig = null;
			foreach (ItemEntryScoreConfig item in value)
			{
				if (item.EntryKey == text)
				{
					itemEntryScoreConfig = item;
				}
			}
			if (itemEntryScoreConfig == null)
			{
				flag = false;
				continue;
			}
			float num = itemEntryScoreConfig.MaxVal - itemEntryScoreConfig.MinVal;
			if (Math.Abs(num) < float.Epsilon)
			{
				flag2 = true;
				continue;
			}
			float num2 = ((!(itemEntryScoreConfig.DeltaScore >= 0f)) ? ((itemEntryScoreConfig.MaxVal - itemEntryData.GetValue()) / num) : ((itemEntryData.GetValue() - itemEntryScoreConfig.MinVal) / num));
			if (num2 < 1f)
			{
				flag = false;
			}
			if (num2 >= 0.8f)
			{
				flag2 = true;
			}
		}
		if (flag)
		{
			return 2;
		}
		if (flag2)
		{
			return 1;
		}
		return 0;
	}

	public static bool IsEntryValueBiggerBetter(string propertyId, ItemEntryData itemEntryData)
	{
		if (!_itemEntryScoreConfigDict.TryGetValue(propertyId, out var value))
		{
			return true;
		}
		string text = itemEntryData.Key;
		if (itemEntryData.IsPercent)
		{
			text += "_PCT";
		}
		ItemEntryScoreConfig itemEntryScoreConfig = null;
		foreach (ItemEntryScoreConfig item in value)
		{
			if (item.EntryKey == text)
			{
				itemEntryScoreConfig = item;
			}
		}
		if (itemEntryScoreConfig == null)
		{
			return true;
		}
		return itemEntryScoreConfig.DeltaScore >= 0f;
	}

	public static Dictionary<string, string> GetReforgeTitle(string propetryId, List<ItemEntryData> itemEntryData, out string maxLogoText)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = "";
		foreach (ItemEntryData itemEntryDatum in itemEntryData)
		{
			string text2 = "Reforge" + itemEntryDatum.Key;
			string maxLogoText2;
			string text3 = SetMaxValueTextStyle(itemEntryDatum.GetValueString(propetryId), propetryId, itemEntryDatum, out maxLogoText2);
			if (!string.IsNullOrWhiteSpace(maxLogoText2))
			{
				text = maxLogoText2;
			}
			string key = ((itemEntryDatum.IsPercent || Modifier.NeedPercentConvertProcess(itemEntryDatum.Key)) ? ("+" + text3 + "%") : ("+" + text3));
			dictionary.Add(key, text2);
			if (_languagesTemplates.ContainsKey(text2))
			{
				dictionary[key] = _languagesTemplates[text2];
			}
		}
		maxLogoText = text;
		return dictionary;
	}

	public static string GetChangePropetry(string propetryId, List<ItemEntryData> itemEntryData, string textTitle, List<ItemEntryData> lastItemEntryData = null, bool isFxEntry = false)
	{
		Dictionary<string, string> languagesTemplates = _languagesTemplates;
		string key = textTitle + _legendItemEntryIdText[propetryId];
		string format = (_languagesTemplates.ContainsKey(key) ? _languagesTemplates[key] : "");
		List<object> list = new List<object>();
		string text = "";
		bool flag = true;
		for (int i = 0; i < itemEntryData.Count; i++)
		{
			if (i <= 1)
			{
				string propetryId2 = propetryId;
				if (i == 1)
				{
					propetryId2 = $"{propetryId}_{i}";
				}
				string maxLogoText = GetMaxLogoText(propetryId2, itemEntryData[i]);
				if (string.IsNullOrWhiteSpace(maxLogoText))
				{
					flag = false;
				}
				else
				{
					text = maxLogoText;
				}
				list.AddRange(GetChangePropetry(propetryId2, itemEntryData[i], textTitle, lastItemEntryData?[i], isFxEntry));
			}
		}
		return (!string.IsNullOrWhiteSpace(text) && flag) ? (text + string.Format(format, list.ToArray())) : string.Format(format, list.ToArray());
	}

	private static List<object> GetChangePropetry(string propetryId, ItemEntryData itemEntryData, string textTitle, ItemEntryData lastItemEntryData = null, bool isFxEntry = false)
	{
		List<object> list = new List<object>();
		if (lastItemEntryData != null)
		{
			list.Add(lastItemEntryData.GetValueString(propetryId, isFxEntry));
		}
		list.Add(SetMaxValueTextStyle(itemEntryData.GetValueString(propetryId, isFxEntry), propetryId, itemEntryData, out var _));
		if (_legendItemRandomValueText.ContainsKey(propetryId))
		{
			List<string> list2 = _legendItemRandomValueText[propetryId];
			if (!isFxEntry)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					list2[i] = NumericParser.Float(list2[i]).ToString("F1");
				}
			}
			list.AddRange(_legendItemRandomValueText[propetryId]);
		}
		return list;
	}

	private static string SetMaxValueTextStyle(string value, string propetryId, ItemEntryData itemEntryData, out string maxLogoText)
	{
		int changeEntryValueTipType = GetChangeEntryValueTipType(propetryId, new List<ItemEntryData> { itemEntryData });
		if (changeEntryValueTipType != 2)
		{
			maxLogoText = "";
			return value;
		}
		maxLogoText = "<img src='ui://PublicResources/MaxText' width='33' height='33'/>";
		return string.Format("[color={0}][size={1}]{2}[/size][/color]", "#D52B09", 36, value);
	}

	private static string GetMaxLogoText(string propetryId, ItemEntryData itemEntryData)
	{
		int changeEntryValueTipType = GetChangeEntryValueTipType(propetryId, new List<ItemEntryData> { itemEntryData });
		if (changeEntryValueTipType != 2)
		{
			return "";
		}
		return "<img src='ui://PublicResources/MaxText' width='33' height='33'/>";
	}

	public static string TryParseMultiLanguageTip(string tip)
	{
		if (!tip.StartsWith("{"))
		{
			return tip;
		}
		Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(tip);
		if (dictionary.TryGetValue(HotUpdateProcess.LanguageKey, out var value))
		{
			return value;
		}
		return dictionary["eng"];
	}

	public static string ParseItemDictionary(Dictionary<string, int> items)
	{
		string text = string.Empty;
		string desc = GetDesc("AutoShipOrderMail_ItemFormat");
		int num = 0;
		foreach (KeyValuePair<string, int> item in items)
		{
			text += string.Format(desc, Item.Name(null, item.Key), item.Value);
			num++;
			if (num != items.Count)
			{
				text += Comma;
			}
		}
		return text;
	}
}
