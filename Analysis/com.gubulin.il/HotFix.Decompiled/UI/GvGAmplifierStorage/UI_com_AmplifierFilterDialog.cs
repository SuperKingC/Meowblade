using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

namespace UI.GvGAmplifierStorage;

public class UI_com_AmplifierFilterDialog : GComponent
{
	public GImage n116;

	public UI_com_FilterContent FilterContent;

	public UI_com_Scroll ScrollTip;

	public const string URL = "ui://fwpu3639q8fuq";

	public static string Name = "UI_com_AmplifierFilterDialog";

	public Action OnFilterChange;

	private int LastQualityIndex;

	private int LastRaceIndex;

	private int LastSoldierIdIndex;

	private int LastModifierIndex;

	private List<string> ModifiersList;

	private List<eRace> RaceList;

	private Dictionary<eRace, List<string>> RaceSoldiers;

	private List<string> CurRaceSoldiers;

	private bool _IsShowPropFilter = false;

	public int SelectedQuality { get; private set; }

	public eRace SelectedRace { get; private set; }

	public string SelectedSoldierId { get; private set; }

	public string SelectedModifier { get; private set; }

	private GList QualityFilter => FilterContent.QualityFilter;

	private GList RaceFilter => FilterContent.RaceFilter;

	private GList SoldierFilter => FilterContent.SoldierFilter;

	private GList PropFilter => FilterContent.PropFilter;

	private bool IsAnySelected => SelectedQuality != 0 || SelectedRace != eRace.全种族 || SelectedSoldierId != null || SelectedModifier != null;

	public bool IsShowPropFilter
	{
		get
		{
			return _IsShowPropFilter;
		}
		set
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			_IsShowPropFilter = value;
			if (_IsShowPropFilter)
			{
				FilterContent.IsShowPropFilter.selectedIndex = 1;
				PropFilter.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
				{
					ModifierRenderer(i, (UI_PropSelectionBtn)(object)o);
				};
				PropFilter.numItems = ModifiersList.Count;
				PropFilter.ResizeToFit(PropFilter.numItems);
			}
			else
			{
				PropFilter.selectedIndex = -1;
				SelectedModifier = null;
				LastModifierIndex = -1;
				FilterContent.IsShowPropFilter.selectedIndex = 0;
				PropFilter.numItems = 0;
				((GObject)PropFilter).height = 0f;
			}
		}
	}

	public static string GetURL()
	{
		return "ui://fwpu3639q8fuq";
	}

	public static UI_com_AmplifierFilterDialog CreateInstance()
	{
		return (UI_com_AmplifierFilterDialog)(object)UIPackage.CreateObject("GvGAmplifierStorage", "com_AmplifierFilterDialog");
	}

	public static UI_com_AmplifierFilterDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierFilterDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639q8fuq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n116 = (GImage)((GComponent)this).GetChild("n116");
		FilterContent = (UI_com_FilterContent)(object)((GComponent)this).GetChild("FilterContent");
		ScrollTip = (UI_com_Scroll)(object)((GComponent)this).GetChild("ScrollTip");
	}

	public void Init(bool hideQuality = false)
	{
		SelectedQuality = 0;
		SelectedRace = eRace.全种族;
		SelectedSoldierId = null;
		SelectedModifier = null;
		LastQualityIndex = -1;
		LastRaceIndex = -1;
		LastSoldierIdIndex = -1;
		LastModifierIndex = -1;
		ModifiersList = AmpConfigHelper.Configs.Modifiers_List;
		RaceList = new List<eRace>();
		RaceSoldiers = new Dictionary<eRace, List<string>>();
		for (int i = 0; i < RaceFilter.numItems; i++)
		{
			UI_RaceSelectionBtn uI_RaceSelectionBtn = (UI_RaceSelectionBtn)(object)((GComponent)RaceFilter).GetChildAt(i);
			eRace selectedIndex = (eRace)uI_RaceSelectionBtn.Type.selectedIndex;
			List<string> raceList = FGUIManager.Instance.GetRaceList(selectedIndex.ToString());
			RaceSoldiers.Add(selectedIndex, raceList);
			RaceList.Add(selectedIndex);
		}
		FilterContent.hideQuality.SetSelectedIndex(hideQuality ? 1 : 0);
		OnHideSoldierFilter();
		IsShowPropFilter = true;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		QualityFilter.onClickItem.Add(new EventCallback1(OnSelectQuality));
		RaceFilter.onClickItem.Add(new EventCallback1(OnSelectRace));
		SoldierFilter.onClickItem.Add(new EventCallback1(OnSelectSoldier));
		PropFilter.onClickItem.Add(new EventCallback1(OnSelectProp));
	}

	public void UnregisterUiEventListeners()
	{
		QualityFilter.onClickItem.Clear();
		RaceFilter.onClickItem.Clear();
		SoldierFilter.onClickItem.Clear();
		PropFilter.onClickItem.Clear();
	}

	public void ShowPropFilter()
	{
	}

	private void OnSelectQuality(EventContext context)
	{
		if (QualityFilter.selectedIndex == LastQualityIndex)
		{
			QualityFilter.selectedIndex = -1;
		}
		LastQualityIndex = QualityFilter.selectedIndex;
		if (QualityFilter.selectedIndex == -1)
		{
			SelectedQuality = 0;
		}
		else
		{
			UI_QualitySelectionBtn uI_QualitySelectionBtn = (UI_QualitySelectionBtn)(object)((GComponent)QualityFilter).GetChildAt(QualityFilter.selectedIndex);
			SelectedQuality = uI_QualitySelectionBtn.Quality.selectedIndex;
		}
		OnChangeAnySelection();
	}

	private void OnSelectRace(EventContext context)
	{
		if (RaceFilter.selectedIndex == LastRaceIndex)
		{
			RaceFilter.selectedIndex = -1;
		}
		LastRaceIndex = RaceFilter.selectedIndex;
		SoldierFilter.selectedIndex = -1;
		LastSoldierIdIndex = -1;
		SelectedSoldierId = null;
		if (RaceFilter.selectedIndex == -1)
		{
			SelectedRace = eRace.全种族;
			CurRaceSoldiers = null;
			OnHideSoldierFilter();
		}
		else
		{
			SelectedRace = RaceList[RaceFilter.selectedIndex];
			CurRaceSoldiers = RaceSoldiers[SelectedRace];
			OnShowSoldierFilter();
		}
		OnChangeAnySelection();
	}

	private void OnSelectSoldier(EventContext context)
	{
		if (SoldierFilter.selectedIndex == LastSoldierIdIndex)
		{
			SoldierFilter.selectedIndex = -1;
		}
		LastSoldierIdIndex = SoldierFilter.selectedIndex;
		if (SoldierFilter.selectedIndex == -1)
		{
			SelectedSoldierId = null;
		}
		else
		{
			if (CurRaceSoldiers == null)
			{
				ILRuntimeDebug.LogError("[UI_AmplifierFilterDialog] 不应该进到这里");
				return;
			}
			SelectedSoldierId = CurRaceSoldiers[SoldierFilter.selectedIndex];
		}
		OnChangeAnySelection();
	}

	private void OnSelectProp(EventContext context)
	{
		if (PropFilter.selectedIndex == LastModifierIndex)
		{
			PropFilter.selectedIndex = -1;
		}
		LastModifierIndex = PropFilter.selectedIndex;
		if (PropFilter.selectedIndex == -1)
		{
			SelectedModifier = null;
		}
		else
		{
			SelectedModifier = ModifiersList[PropFilter.selectedIndex];
		}
		OnChangeAnySelection();
	}

	private void OnShowSoldierFilter()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		FilterContent.IsShowSoldierFilter.selectedIndex = 1;
		SoldierFilter.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			SoldierRenderer(i, (UI_SoldierSelectionBtn)(object)o);
		};
		SoldierFilter.numItems = CurRaceSoldiers.Count;
		SoldierFilter.ResizeToFit(CurRaceSoldiers.Count);
	}

	private void OnHideSoldierFilter()
	{
		FilterContent.IsShowSoldierFilter.selectedIndex = 0;
		SoldierFilter.numItems = 0;
		((GObject)SoldierFilter).height = 0f;
	}

	private void OnChangeAnySelection()
	{
		FilterContent.IsFiltering.selectedIndex = (IsAnySelected ? 1 : 0);
		OnFilterChange?.Invoke();
	}

	private void SoldierRenderer(int index, UI_SoldierSelectionBtn item)
	{
		string soldierId = CurRaceSoldiers[index];
		RenderHelper_SimpleSquareSoldier.RenderSoldier(item.AffectedSoldier, soldierId);
	}

	private void ModifierRenderer(int index, UI_PropSelectionBtn item)
	{
		string langKey = "GvGAmpProp_" + ModifiersList[index];
		((GObject)item.PropName).text = langKey.ToLanguage();
	}
}
