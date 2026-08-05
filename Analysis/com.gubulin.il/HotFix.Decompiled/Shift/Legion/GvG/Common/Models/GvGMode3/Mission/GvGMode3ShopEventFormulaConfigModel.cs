using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class GvGMode3ShopEventFormulaConfigModel
{
	public GDEFormulaData RawData;

	public string FormulaId;

	public int Rarity;

	public Dictionary<string, int> Input;

	public Dictionary<string, int> Output;

	private string _storeItemId;

	private int _storeItemCnt;

	private string _storeItemName;

	public int StoreItemCnt => _storeItemCnt;

	public FormulaType Type => (FormulaType)RawData.Type;

	public string StoreItemId
	{
		get
		{
			if (!string.IsNullOrEmpty(_storeItemId))
			{
				return _storeItemId;
			}
			using (Dictionary<string, int>.Enumerator enumerator = Output.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, int> current = enumerator.Current;
					_storeItemId = current.Key;
					_storeItemCnt = current.Value;
				}
			}
			return _storeItemId;
		}
	}

	public bool IsAmplifier => StoreItemId.Contains("GvGAmp");

	public string StoreItemName
	{
		get
		{
			if (!string.IsNullOrEmpty(_storeItemName))
			{
				return _storeItemName;
			}
			if (IsAmplifier)
			{
				AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(StoreItemId);
				_storeItemName = amplifierModel.Name;
			}
			else
			{
				string oldItemId = StoreItemId;
				FGUIManager.Instance.ItemIdReplace(ref oldItemId);
				_storeItemName = Item.Name(GameManagers.Instance, oldItemId);
			}
			return _storeItemName;
		}
	}

	public int GetCostOfInput(string inputItem)
	{
		if (Type != FormulaType.NpcShopItem)
		{
			return Input[inputItem];
		}
		TechData techData = "I67206".GetTechData();
		float effectValue = techData.EffectValue;
		int num = Input[inputItem];
		return Mathf.Max(1, Mathf.FloorToInt((float)num * (1f - effectValue / 100f)));
	}
}
