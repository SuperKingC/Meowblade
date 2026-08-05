using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using UI.GvGAmplifierForge;

namespace UI.GvGExchange3;

public class UI_com_PostFormulaOemFilter : GComponent
{
	public Controller IsListEmpty;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GImage n8;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GTextField n3;

	public GLoader n7;

	public GTextField n9;

	public GList Formulas;

	public GList RarityMenu;

	public GList TypeMenu;

	public const string URL = "ui://tt2iq07oj1h833";

	public static string Name = "UI_com_PostFormulaOemFilter";

	public Action<int> OnSelectAmplifier = delegate
	{
	};

	public Action<bool> ChangeConfirmBtnEnabled = delegate
	{
	};

	private GvGAmplifierForgeModel _amplifierData;

	private int _selectedRarity;

	private eAmplifierType _selectedType;

	private int _selectedAmpIndex;

	private readonly List<AmplifierFormulaModel> _filteredAmps = new List<AmplifierFormulaModel>();

	private AmplifierFormulaModel _selectedAmpFormula;

	private eAmplifierType ReadSelectedType => (eAmplifierType)((UI_btn_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(TypeMenu.selectedIndex)).Type.selectedIndex;

	private int ReadSelectedRarity => ((UI_RarityTab)(object)((GComponent)RarityMenu).GetChildAt(RarityMenu.selectedIndex)).Rarity.selectedIndex;

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h833";
	}

	public static UI_com_PostFormulaOemFilter CreateInstance()
	{
		return (UI_com_PostFormulaOemFilter)(object)UIPackage.CreateObject("GvGExchange3", "com_PostFormulaOemFilter");
	}

	public static UI_com_PostFormulaOemFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostFormulaOemFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h833", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsListEmpty = ((GComponent)this).GetController("IsListEmpty");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://tt2iq07oj1h833".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://tt2iq07oj1h833".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		Formulas = (GList)((GComponent)this).GetChild("Formulas");
		RarityMenu = (GList)((GComponent)this).GetChild("RarityMenu");
		TypeMenu = (GList)((GComponent)this).GetChild("TypeMenu");
	}

	public void Init()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		_amplifierData = Singleton<GvGAmplifierManager>.Instance.GvGAmplifierData;
		_selectedAmpIndex = -1;
		TypeMenu.selectedIndex = 0;
		RarityMenu.selectedIndex = 0;
		_selectedType = ReadSelectedType;
		_selectedRarity = ReadSelectedRarity;
		Formulas.SetVirtual();
		Formulas.itemRenderer = new ListItemRenderer(RenderRecipeItem);
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			_amplifierData.GetData(OnChangeFilter);
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		RarityMenu.onClickItem.Add(new EventCallback1(OnSelectRarity));
		TypeMenu.onClickItem.Add(new EventCallback1(OnSelectType));
		Formulas.onClickItem.Add(new EventCallback0(OnSelectAmpFormula));
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Combine(instance.OnChange, new Action(OnChangeFilter));
	}

	public void UnregisterUiEventListeners()
	{
		RarityMenu.onClickItem.Clear();
		TypeMenu.onClickItem.Clear();
		Formulas.onClickItem.Clear();
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Remove(instance.OnChange, new Action(OnChangeFilter));
	}

	public void OnDestroy()
	{
		_filteredAmps.Clear();
		OnSelectAmplifier = null;
		ChangeConfirmBtnEnabled = null;
		_amplifierData = null;
		_selectedAmpFormula = null;
	}

	private void OnSelectType(EventContext context)
	{
		eAmplifierType readSelectedType = ReadSelectedType;
		if (readSelectedType != _selectedType)
		{
			_selectedType = readSelectedType;
			_selectedAmpIndex = -1;
			OnChangeFilter();
		}
	}

	private void OnSelectRarity(EventContext context)
	{
		int readSelectedRarity = ReadSelectedRarity;
		if (readSelectedRarity != _selectedRarity)
		{
			_selectedRarity = readSelectedRarity;
			_selectedAmpIndex = -1;
			OnChangeFilter();
		}
	}

	private void OnChangeFilter()
	{
		if (Singleton<GvGStoreHouseManager>.Instance.Items != null)
		{
			ChangeConfirmBtnEnabled?.Invoke(obj: false);
			_amplifierData.UpdateUnlockedFormulas();
			DoFilter();
			Formulas.numItems = _filteredAmps.Count;
			if (_selectedAmpIndex >= _filteredAmps.Count)
			{
				_selectedAmpIndex = -1;
			}
			IsListEmpty.selectedIndex = ((Formulas.numItems == 0) ? 1 : 0);
			Formulas.selectedIndex = _selectedAmpIndex;
			OnSelectAmpFormula();
		}
	}

	private void DoFilter()
	{
		List<AmplifierFormulaModel> list = AmpConfigHelper.FilterFormulaByRarity(_amplifierData.Formula_List, _selectedRarity);
		list = AmpConfigHelper.FilterFormulaByOutputType(list, _selectedType);
		List<AmplifierFormulaModel> list2 = new List<AmplifierFormulaModel>();
		foreach (AmplifierFormulaModel item in list)
		{
			_amplifierData.FormulaCount_Dict.TryGetValue(item.Key, out var value);
			if (value != null && value.ScrollCount40 > 0)
			{
				list2.Add(item);
			}
		}
		_filteredAmps.Clear();
		_filteredAmps.AddRange(list2);
	}

	private void OnSelectAmpFormula()
	{
		_selectedAmpIndex = Formulas.selectedIndex;
		_selectedAmpFormula = ((_selectedAmpIndex == -1) ? null : _filteredAmps[Formulas.selectedIndex]);
		if (_selectedAmpFormula != null)
		{
			OnSelectAmplifier?.Invoke(_selectedAmpFormula.OutputAmplifier.Idx);
			ChangeConfirmBtnEnabled?.Invoke(obj: true);
		}
	}

	private void RenderRecipeItem(int i, GObject obj)
	{
		if (obj is UI_btn_Formula uI_btn_Formula)
		{
			((GObject)uI_btn_Formula).touchable = true;
			AmplifierFormulaModel amplifierFormulaModel = _filteredAmps[i];
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(amplifierFormulaModel.OutputAmpId);
			bool flag = string.IsNullOrEmpty(amplifierModel.AffectedSoldier);
			_amplifierData.FormulaCount_Dict.TryGetValue(amplifierFormulaModel.Key, out var value);
			int num = value?.ScrollCount40 ?? 0;
			((GObject)uI_btn_Formula.ForgeScrollCount).text = $"{num}";
			uI_btn_Formula.IsShowRace.selectedIndex = (flag ? 1 : 0);
			if (flag)
			{
				RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace(uI_btn_Formula.RaceType, amplifierModel);
			}
			else
			{
				RenderHelper_SimpleSolierIcon.RenderAmplifierAffectedSoldier(uI_btn_Formula.AffectedSoldier, amplifierModel);
			}
			uI_btn_Formula.Rarity.selectedIndex = amplifierFormulaModel.Rarity;
			((GObject)uI_btn_Formula.AmpName).text = amplifierModel.Name;
		}
	}
}
