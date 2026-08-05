using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGAmplifierForgeModel
{
	private List<string> ForceUnlockedFormulas;

	public Dictionary<int, float> AmpForgeHighQualityRate;

	public Dictionary<string, FormulaCountModel> FormulaCount_Dict = new Dictionary<string, FormulaCountModel>();

	public List<AmplifierFormulaModel> Formula_List = new List<AmplifierFormulaModel>();

	private readonly HashSet<string> _newUnlockAmpFormulas = new HashSet<string>();

	private readonly string _checkFormulasKey = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_" + $"{GameController.Contexts.gameState.user.value.UserId}_CheckAmpFormulas";

	private List<string> _checkedFormulas;

	public HashSet<string> NewUnlockAmpFormulas => _newUnlockAmpFormulas;

	public bool HasNewAmpFormulas => _newUnlockAmpFormulas.Any();

	public void GetData(Action onFinished = null, bool isInit = false)
	{
		if (isInit)
		{
			LoadCheckFormulas();
		}
		if (AmpForgeHighQualityRate == null)
		{
			AmpForgeHighQualityRate = new Dictionary<int, float>();
			foreach (KeyValuePair<string, float> item in ObserverConfigHelper.DefaultsConfig.AmpForgeHighQualityRate)
			{
				AmpForgeHighQualityRate.Add(int.Parse(item.Key), item.Value);
			}
		}
		Singleton<GvGAmplifierManager>.Instance.GetAmplifierStorage(delegate(GvGAmplifierManager.AmplifierStorageData data)
		{
			ForceUnlockedFormulas = data.UnlockedFormulas;
			foreach (string forceUnlockedFormula in ForceUnlockedFormulas)
			{
				UnlockFormula(forceUnlockedFormula, null, 0);
			}
			if (isInit)
			{
				UpdateUnlockedFormulas();
			}
			UpdateNewUnlockFormulas(FormulaCount_Dict.Keys.ToList());
			onFinished?.Invoke();
		});
	}

	public void UpdateUnlockedFormulas(List<string> unlockList)
	{
		ForceUnlockedFormulas = unlockList;
		foreach (string forceUnlockedFormula in ForceUnlockedFormulas)
		{
			UnlockFormula(forceUnlockedFormula, null, 0);
		}
		UpdateNewUnlockFormulas(FormulaCount_Dict.Keys.ToList());
	}

	public void UpdateUnlockedFormulas(Dictionary<string, int> curStock, bool notice)
	{
		bool flag = false;
		foreach (KeyValuePair<string, int> item in curStock)
		{
			string key = item.Key;
			string text = key;
			ItemType itemType = (ItemType)Item.ItemType(key);
			bool flag2 = false;
			if (itemType == ItemType.GvGServer_AmplifierFormula_SelfOnly)
			{
				text = AmplifierFormula_SelfOnlyHash(key);
				flag2 = true;
			}
			else if (itemType != ItemType.GvGServer_AmplifierFormula)
			{
				continue;
			}
			string text2 = "GvGAmplifierForgeItem_" + text;
			if (FormulaCount_Dict.ContainsKey(text2))
			{
				FormulaCountModel formulaCountModel = FormulaCount_Dict[text2];
				if (flag2)
				{
					formulaCountModel.ScrollCount41 = item.Value;
				}
				else
				{
					formulaCountModel.ScrollCount40 = item.Value;
				}
			}
			else
			{
				UnlockFormula(text2, key, item.Value);
				flag = true;
			}
		}
		UpdateNewUnlockFormulas(FormulaCount_Dict.Keys.ToList());
		if (flag && notice)
		{
			Singleton<GvGAmplifierManager>.Instance.OnUpdateTotalAmpFormulaRedDot?.Invoke(HasNewAmpFormulas);
		}
	}

	public void UpdateUnlockedFormulas()
	{
		UpdateUnlockedFormulas(Singleton<GvGStoreHouseManager>.Instance.Items, notice: false);
	}

	private static string AmplifierFormula_SelfOnlyHash(string selfFormula)
	{
		return selfFormula.Replace("I9", "I");
	}

	public void UnlockFormula(string formulaId, string itemId, int count)
	{
		if (!FormulaCount_Dict.ContainsKey(formulaId))
		{
			FormulaCountModel formulaCountModel = new FormulaCountModel();
			if (string.IsNullOrEmpty(itemId))
			{
				formulaCountModel.ScrollCount40 = 0;
				formulaCountModel.ScrollCount41 = 0;
			}
			else if (Item.ItemType(itemId) == 41)
			{
				formulaCountModel.ScrollCount41 = count;
			}
			else
			{
				formulaCountModel.ScrollCount40 = count;
			}
			FormulaCount_Dict.Add(formulaId, formulaCountModel);
			if (!AmpConfigHelper.CheckIsDefaultShowFormula(formulaId))
			{
				Formula_List.Add(AmpConfigHelper.TryGetAmplifierFormula(formulaId));
			}
		}
	}

	public void ForgeAmplifier(string formulaId, int forgeCount, Action<GvGAmplifierManager.ForgeData> onFinished = null)
	{
		Singleton<GvGAmplifierManager>.Instance.ForgeAmplifier(formulaId, forgeCount, delegate(GvGAmplifierManager.ForgeData data)
		{
			onFinished?.Invoke(data);
		});
	}

	public HashSet<int> HasNewUnlockFormulaRarity()
	{
		List<string> list = _newUnlockAmpFormulas.ToList();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (string item in list)
		{
			AmplifierFormulaModel amplifierFormulaModel = AmpConfigHelper.TryGetAmplifierFormula(item);
			hashSet.Add(amplifierFormulaModel.Data.Rarity);
		}
		return hashSet;
	}

	public HashSet<int> HasNewUnlockFormulaType(int rarity)
	{
		List<string> list = _newUnlockAmpFormulas.ToList();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (string item in list)
		{
			AmplifierFormulaModel amplifierFormulaModel = AmpConfigHelper.TryGetAmplifierFormula(item);
			if (amplifierFormulaModel.Rarity == rarity)
			{
				int type = (int)amplifierFormulaModel.OutputAmplifier.Type;
				hashSet.Add(type);
			}
		}
		return hashSet;
	}

	public bool IsNewAmplifierFormula(string formulaId)
	{
		return _newUnlockAmpFormulas.Contains(formulaId);
	}

	public void CheckAmplifierFormula(string formulaId, Action onFinished = null)
	{
		if (!_checkedFormulas.Contains(formulaId))
		{
			_newUnlockAmpFormulas.Remove(formulaId);
			_checkedFormulas.Add(formulaId);
			SaveCheckFormulas();
			onFinished?.Invoke();
			Singleton<GvGAmplifierManager>.Instance.OnUpdateTotalAmpFormulaRedDot?.Invoke(HasNewAmpFormulas);
		}
	}

	private void LoadCheckFormulas()
	{
		if (_checkedFormulas == null)
		{
			string text = PlayerPrefs.GetString(_checkFormulasKey);
			_checkedFormulas = (string.IsNullOrEmpty(text) ? new List<string>() : JsonHelper.ToObject<List<string>>(text));
		}
	}

	private void SaveCheckFormulas()
	{
		PlayerPrefs.SetString(_checkFormulasKey, JsonHelper.ToJson(_checkedFormulas));
	}

	private void UpdateNewUnlockFormulas(List<string> curUnlockList)
	{
		if (curUnlockList == null)
		{
			return;
		}
		foreach (string curUnlock in curUnlockList)
		{
			if (!_checkedFormulas.Contains(curUnlock))
			{
				_newUnlockAmpFormulas.Add(curUnlock);
			}
		}
	}
}
