using System.Collections.Generic;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SignInBonusData
{
	public GDESignInSerialData Data;

	public string SignInSerialId;

	public string Title;

	public int Target;

	public List<Bonus> BonusList;

	public string UIType;

	public int Spacing;

	public Dictionary<string, string> DisplayBonus;

	private string _uiTitleOutCn;

	public string UiTitle
	{
		get
		{
			bool isRegionOutCN = HotUpdateProcess.Instance.IsRegionOutCN;
			if (_uiTitleOutCn == null && isRegionOutCN)
			{
				string text = $"NewYearSignIn_Day{Target}_Title";
				_uiTitleOutCn = text.ToLanguage();
				if (_uiTitleOutCn == text)
				{
					_uiTitleOutCn = Title;
				}
			}
			return isRegionOutCN ? _uiTitleOutCn : Title;
		}
	}

	public SignInBonusData(GDESignInSerialData signInSerialData)
	{
		Data = signInSerialData;
		SignInSerialId = signInSerialData.SerialId;
		Title = signInSerialData.Title;
		Target = signInSerialData.Target;
		BonusList = new List<Bonus>();
		if (!string.IsNullOrEmpty(Data.Bonus))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(Data.Bonus))
			{
				BonusList.Add(Bonus.Get(item.Key, item.Value));
			}
		}
		DisplayBonus = new Dictionary<string, string>();
		if (string.IsNullOrEmpty(Data.DisplayBonus))
		{
			return;
		}
		foreach (KeyValuePair<string, string> item2 in JsonHelper.ToObject<Dictionary<string, string>>(Data.DisplayBonus))
		{
			DisplayBonus.Add(item2.Key, item2.Value);
		}
	}
}
