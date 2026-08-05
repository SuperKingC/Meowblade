using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.AbilitySpecialName;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.Common.Managers;

public class AbilityDataManager : Singleton<AbilityDataManager>
{
	private static readonly Dictionary<string, GDEAbilityData> _abilityDataDict = new Dictionary<string, GDEAbilityData>();

	private static readonly Dictionary<string, string> _abilityDescriptionDict = new Dictionary<string, string>();

	private static readonly Dictionary<string, SpecialAbilityName> SpecialNames = new Dictionary<string, SpecialAbilityName>();

	private const string TagPattern = "{\\\\?\\$([a-zA-Z]+):([0-9]+)}";

	public static GDEAbilityData getAbilityData(string id)
	{
		if (!_abilityDataDict.ContainsKey(id))
		{
			_abilityDataDict.Add(id, GDMgr.TryGetWithErrorHandling<GDEAbilityData>(id));
		}
		return _abilityDataDict[id];
	}

	public override void InitInstance()
	{
	}

	public string GetDescription(string abilityId)
	{
		string abilityDescription = getAbilityDescription(abilityId);
		return abilityDescription ?? string.Empty;
	}

	public static string getAbilityDescription(string id)
	{
		if (!_abilityDescriptionDict.ContainsKey(id))
		{
			GDEAbilityData abilityData = getAbilityData(id);
			_abilityDescriptionDict.Add(id, ParseDescription(abilityData.Key, abilityData.Description));
		}
		return _abilityDescriptionDict[id];
	}

	private static string ParseDescription(string abilityId, string description)
	{
		foreach (Match item in Regex.Matches(description, "{\\$([a-zA-Z0-9_\\[\\]]+)(\\.?([a-zA-Z0-9_\\[\\]]+))*?}"))
		{
			string value = item.Value;
			value = value.Replace("{$", "");
			value = value.Replace("}", "");
			string[] array = value.Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			string newValue = item.Value;
			if (array.Length != 0)
			{
				newValue = ParseAbilityParameters(abilityId, array);
			}
			description = description.Replace(item.Value, newValue);
		}
		return description;
	}

	private static string ParseAbilityParameters(string abilityId, string[] parameters, int pIndex = 0)
	{
		if (string.IsNullOrEmpty(abilityId))
		{
			return string.Empty;
		}
		string text = parameters[pIndex];
		int num = 0;
		if (text.Contains("["))
		{
			int num2 = text.IndexOf('[');
			int num3 = text.IndexOf(']');
			text = text.Substring(0, num2);
			num = int.Parse(parameters[pIndex].Substring(num2 + 1, num3 - num2 - 1));
		}
		string text2 = GetAbilityParameterValue(abilityId, text);
		if (text2 == null)
		{
			return string.Empty;
		}
		if (text.Contains("BuffId"))
		{
			text2 = ParseAbilityParameters(text2, parameters, pIndex + 1);
		}
		if (text2 == null)
		{
			return string.Empty;
		}
		if (num > 0)
		{
			num--;
			string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			text2 = ((num >= array.Length) ? "-9999" : array[num]);
		}
		if (num == 1 || num == 3 || num == 4 || num == 5)
		{
			return Mathf.Abs(NumericParser.Float(text2) * 100f).ToString(CultureInfo.InvariantCulture);
		}
		if (text == ParametersKey.P_DamageMultiplier.ToString() || text == ParametersKey.P_ExtraDamageMultiplier.ToString() || text == ParametersKey.P_ShieldValue.ToString() || text == ParametersKey.P_CreateUnitInheritPercentage.ToString())
		{
			return Mathf.Abs(NumericParser.Float(text2) * 100f).ToString(CultureInfo.InvariantCulture);
		}
		if (text == ParametersKey.P_Duration.ToString() || text == ParametersKey.P_TickInterval.ToString() || text == ParametersKey.P_CrowdControlDuration.ToString() || text == ParametersKey.B_Duration.ToString())
		{
			return (NumericParser.Float(text2) / 1000f).ToString(CultureInfo.InvariantCulture);
		}
		return text2;
	}

	private static string GetAbilityParameterValue(string abilityId, string parameterKey)
	{
		string result = null;
		try
		{
			result = GetPropValue(getAbilityData(abilityId), parameterKey).ToString();
		}
		catch (Exception)
		{
		}
		return result;
	}

	private static object GetPropValue(object src, string propName)
	{
		return src.GetType().GetField(propName).GetValue(src);
	}

	public string GetSpecialTagName(string abilityId, string removeText = "压制效果：")
	{
		return GetAbilitySpecialName(abilityId).Name.Replace(removeText, string.Empty);
	}

	public int GetSpecialTagValue(string abilityId, string tag)
	{
		int value;
		return GetAbilitySpecialName(abilityId).Tags.TryGetValue(tag, out value) ? value : 0;
	}

	private static SpecialAbilityName GetAbilitySpecialName(string id)
	{
		if (!SpecialNames.ContainsKey(id))
		{
			GDEAbilityData abilityData = getAbilityData(id);
			SpecialNames.Add(id, RemoveSpecialTags(abilityData.Name));
		}
		return SpecialNames[id];
	}

	private static SpecialAbilityName RemoveSpecialTags(string input)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		StringBuilder stringBuilder = new StringBuilder(input);
		foreach (Match item in Regex.Matches(input, "{\\\\?\\$([a-zA-Z]+):([0-9]+)}"))
		{
			RemoveTag(item, dictionary, stringBuilder);
		}
		return new SpecialAbilityName(stringBuilder.ToString(), dictionary);
	}

	private static void RemoveTag(Match match, Dictionary<string, int> removedTags, StringBuilder builder)
	{
		string value = match.Groups[1].Value;
		int value2 = int.Parse(match.Groups[2].Value);
		removedTags[value] = value2;
		builder.Remove(match.Index, match.Length);
	}
}
