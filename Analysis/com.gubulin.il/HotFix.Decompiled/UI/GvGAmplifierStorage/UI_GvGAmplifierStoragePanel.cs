using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Services;
using UI.GvGAmpIntroduction;

namespace UI.GvGAmplifierStorage;

public class UI_GvGAmplifierStoragePanel : GComponent, IUiController
{
	public GLoader background;

	public GButton BackBtn;

	public GButton HelpBtn;

	public UI_com_Title Title;

	public GImage n117;

	public GImage n118;

	public UI_com_AmplifierFilterDialog FilterDialog;

	public GList AmplifierList;

	public const string URL = "ui://fwpu3639b4va0";

	public static string Name = "UI_GvGAmplifierStoragePanel";

	private GvGAmplifierStorageModel Data;

	private List<AmplifierModel> FilteredAmps;

	public static string GetURL()
	{
		return "ui://fwpu3639b4va0";
	}

	public static UI_GvGAmplifierStoragePanel CreateInstance()
	{
		return (UI_GvGAmplifierStoragePanel)(object)UIPackage.CreateObject("GvGAmplifierStorage", "GvGAmplifierStoragePanel");
	}

	public static UI_GvGAmplifierStoragePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAmplifierStoragePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639b4va0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		FilterDialog = (UI_com_AmplifierFilterDialog)(object)((GComponent)this).GetChild("FilterDialog");
		AmplifierList = (GList)((GComponent)this).GetChild("AmplifierList");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		FilterDialog.Init();
		Data = new GvGAmplifierStorageModel();
		Data.GetData(delegate
		{
			FilteredAmps = Data.StorageAmpsConfig_List;
			Update();
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnHelpClick));
		FilterDialog.RegisterUiEventListeners();
		UI_com_AmplifierFilterDialog filterDialog = FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Combine(filterDialog.OnFilterChange, new Action(OnChangeFilter));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		FilterDialog.UnregisterUiEventListeners();
		UI_com_AmplifierFilterDialog filterDialog = FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Remove(filterDialog.OnFilterChange, new Action(OnChangeFilter));
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("增幅器仓库", "远征相关", "增幅器");
	}

	private void OnChangeFilter()
	{
		if (Data.StorageAmpsConfig_List != null)
		{
			FilteredAmps = AmpConfigHelper.FilterAmplifiers(Data.StorageAmpsConfig_List, FilterDialog.SelectedQuality, FilterDialog.SelectedRace, FilterDialog.SelectedSoldierId, FilterDialog.SelectedModifier);
			Update();
		}
	}

	private void OnClickItem(int idx)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "AmpIdx", idx } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_mian_GvGAmpIntroductionPopup.Name, parameters);
	}

	private void Update()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		AmplifierList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmplifierSlot(i, (UI_AmplifierSlot)(object)o);
		};
		AmplifierList.numItems = FilteredAmps.Count;
	}

	private void RenderAmplifierSlot(int i, UI_AmplifierSlot slot)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		AmplifierModel amp = FilteredAmps[i];
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.AmplifierIcon, amp);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.AffectedRange, amp);
		((GObject)slot.Count).text = Data.AmplifierStorage[amp.Idx].ToString();
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(amp.Idx);
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
