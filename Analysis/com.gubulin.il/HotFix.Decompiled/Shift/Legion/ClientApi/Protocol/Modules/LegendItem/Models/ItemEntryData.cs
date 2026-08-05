using System;
using Assets.Scripts.Managers;
using ProtoBuf;
using Shift.Legion.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

[ProtoContract]
public class ItemEntryData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public int Value;

	[ProtoMember(3)]
	public bool IsPercent;

	public ItemEntryData()
	{
	}

	public ItemEntryData(string key, int value, bool isPercent)
	{
		Key = key;
		Value = value;
		IsPercent = isPercent;
	}

	public float GetValue()
	{
		if (IsPercent)
		{
			return (float)Value / 10000f / 100f;
		}
		return (float)Value / 10000f;
	}

	public string GetValueString(string entryId, bool isFxEntry = false)
	{
		float num = (float)Value / 10000f;
		if (Modifier.NeedPercentConvertProcess(Key))
		{
			num *= 100f;
		}
		string entryValuePrecision = LanguagesManager.GetEntryValuePrecision(entryId, isFxEntry);
		if (string.IsNullOrEmpty(entryValuePrecision))
		{
			return Convert.ToInt32(num).ToString().TrimStart('-');
		}
		string text = num.ToString(entryValuePrecision).TrimStart('-');
		if (text.EndsWith("."))
		{
			text += "0";
		}
		return text;
	}
}
