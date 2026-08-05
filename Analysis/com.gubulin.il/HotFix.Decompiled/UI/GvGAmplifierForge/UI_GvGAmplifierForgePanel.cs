using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGAmpIntroduction;
using UI.GvGAmplifierStorage;
using UnityEngine;

namespace UI.GvGAmplifierForge;

public class UI_GvGAmplifierForgePanel : GComponent, IUiController
{
	private class AmplifierFormulaGetMore : AmplifierFormulaModel
	{
		private Window _window;

		private UI_com_AmplifierFormulaSource _contentPane;

		private readonly Vector2 _position;

		public AmplifierFormulaGetMore(Vector2 showPos)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			_position = showPos;
		}

		public void Destroy()
		{
			_contentPane = null;
			Window window = _window;
			if (window != null)
			{
				((GObject)window).Dispose();
			}
		}

		public void OpenGetMoreFormulas()
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			if (_window == null)
			{
				GComponent asCom = UIPackage.CreateObject("GvGAmplifierForge", "com_AmplifierFormulaSource").asCom;
				_window = new Window
				{
					contentPane = asCom,
					sortingOrder = 3000
				};
			}
			if (_contentPane == null)
			{
				_contentPane = _window.contentPane as UI_com_AmplifierFormulaSource;
				if (_contentPane == null)
				{
					ILRuntimeDebug.LogError("AmplifierFormulaGetMore : _contentPane is not com_AmplifierFormulaSource");
					return;
				}
				_contentPane.Render();
			}
			GRoot.inst.ShowPopup((GObject)(object)_window);
			((GObject)_contentPane).SetXY(_position.x, _position.y);
		}
	}

	public Controller ForgeState;

	public Controller AmpTag;

	public Controller IsShowForgeResult;

	public Controller Quatity;

	public Controller SelectionState;

	public Controller IsListEmpty;

	public Controller c1;

	public Controller hasOuterTech;

	public Controller showSkyForegeOpDialog;

	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GButton HelpBtn;

	public GImage n101;

	public GLoader n162;

	public GImage n166;

	public GImage n165;

	public GImage n163;

	public GImage n164;

	public GImage n156;

	public GImage n160;

	public GImage n157;

	public GImage n155;

	public GImage n115;

	public GImage n177;

	public GImage n179;

	public GLoader n178;

	public GTextField n124;

	public GTextField n136;

	public GButton AmpConsumeDiscountRateBtn;

	public GTextField n137;

	public GImage n142;

	public GTextField n170;

	public GList RarityMenu;

	public GList RecipeList;

	public GList TypeMenu;

	public GButton HighQualityRateHelpBtn;

	public UI_com_AmplifierModel AmplifierIcon;

	public GTextField AmpName;

	public GTextField AmplifierOwnCount;

	public GTextField UnlockText;

	public GTextField n159;

	public GTextField Property;

	public GButton ExtraHighQualityRateBtn;

	public GTextField HighQualityRate;

	public UI_QualityIcon CurQuality;

	public UI_QualityIcon NextQuality;

	public UI_btn_ForgeBtn ForgeBtn;

	public UI_btn_GetMoreAmplifierFormula AddBtn;

	public UI_btn_ReduceBtn ReduceBtn;

	public GTextField CountToForge;

	public UI_btn_MaxBtn MaxBtn;

	public GList ConsumeList;

	public UI_btn_AmplifierStorageEntryBtn AmplifierStorageEntryBtn;

	public GComponent AffectedRange;

	public UI_com_AnimationTaser n168;

	public UI_com_AnimationTaser n169;

	public GGraph ui_amplifier_forge_gun;

	public GGraph ui_amplifier_forge_gun2;

	public GGraph ui_amplifier_forge_icon;

	public UI_btn_03 skyForgeBtn;

	public GGraph ForgeResultDialogMask;

	public UI_com_ForgeResultDialog ForgeResultDialog;

	public GGraph Mask2;

	public UI_com_02 SkyForgeOpDialog;

	public Transition ForgeAmp;

	public const string URL = "ui://fpjheycbb4va0";

	public static string Name = "UI_GvGAmplifierForgePanel";

	private GvGAmplifierForgeModel _amplifierData;

	private int SelectedRarity;

	private eAmplifierType SelectedType;

	private List<AmplifierFormulaModel> FilteredRecipe;

	private List<KeyValuePair<string, int>> ConsumeListData;

	private int MaxCanForgeTimes;

	private int SelectedForgeTimes;

	private AmplifierFormulaModel CurRecipe;

	private int CurRecipeListIndex;

	private List<GameObject> vfxList;

	private float AmpConsumeDiscountRate;

	private float ExtraAmpForgeHighQualityRate;

	private int NormalForgedCount;

	private const int MaxForgeTimes = 100;

	private CoroutineQueue CoroutineQueue;

	private AmplifierFormulaGetMore _getMoreAmplifierFormula;

	public static string GetURL()
	{
		return "ui://fpjheycbb4va0";
	}

	public static UI_GvGAmplifierForgePanel CreateInstance()
	{
		return (UI_GvGAmplifierForgePanel)(object)UIPackage.CreateObject("GvGAmplifierForge", "GvGAmplifierForgePanel");
	}

	public static UI_GvGAmplifierForgePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAmplifierForgePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbb4va0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected O, but got Unknown
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected O, but got Unknown
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Expected O, but got Unknown
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Expected O, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ForgeState = ((GComponent)this).GetController("ForgeState");
		AmpTag = ((GComponent)this).GetController("AmpTag");
		IsShowForgeResult = ((GComponent)this).GetController("IsShowForgeResult");
		Quatity = ((GComponent)this).GetController("Quatity");
		SelectionState = ((GComponent)this).GetController("SelectionState");
		IsListEmpty = ((GComponent)this).GetController("IsListEmpty");
		c1 = ((GComponent)this).GetController("c1");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		showSkyForegeOpDialog = ((GComponent)this).GetController("showSkyForegeOpDialog");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n162 = (GLoader)((GComponent)this).GetChild("n162");
		n166 = (GImage)((GComponent)this).GetChild("n166");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n177 = (GImage)((GComponent)this).GetChild("n177");
		n179 = (GImage)((GComponent)this).GetChild("n179");
		n178 = (GLoader)((GComponent)this).GetChild("n178");
		n124 = (GTextField)((GComponent)this).GetChild("n124");
		string id = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)n124).id;
		((GObject)n124).text = LanguagesManager.GetDesc(id);
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id2 = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id2);
		AmpConsumeDiscountRateBtn = (GButton)((GComponent)this).GetChild("AmpConsumeDiscountRateBtn");
		n137 = (GTextField)((GComponent)this).GetChild("n137");
		string id3 = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)n137).id;
		((GObject)n137).text = LanguagesManager.GetDesc(id3);
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n170 = (GTextField)((GComponent)this).GetChild("n170");
		string id4 = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)n170).id;
		((GObject)n170).text = LanguagesManager.GetDesc(id4);
		RarityMenu = (GList)((GComponent)this).GetChild("RarityMenu");
		RecipeList = (GList)((GComponent)this).GetChild("RecipeList");
		TypeMenu = (GList)((GComponent)this).GetChild("TypeMenu");
		HighQualityRateHelpBtn = (GButton)((GComponent)this).GetChild("HighQualityRateHelpBtn");
		AmplifierIcon = (UI_com_AmplifierModel)(object)((GComponent)this).GetChild("AmplifierIcon");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		AmplifierOwnCount = (GTextField)((GComponent)this).GetChild("AmplifierOwnCount");
		UnlockText = (GTextField)((GComponent)this).GetChild("UnlockText");
		string id5 = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)UnlockText).id;
		((GObject)UnlockText).text = LanguagesManager.GetDesc(id5);
		n159 = (GTextField)((GComponent)this).GetChild("n159");
		string id6 = "ui://fpjheycbb4va0".Replace("ui://", "") + "-" + ((GObject)n159).id;
		((GObject)n159).text = LanguagesManager.GetDesc(id6);
		Property = (GTextField)((GComponent)this).GetChild("Property");
		ExtraHighQualityRateBtn = (GButton)((GComponent)this).GetChild("ExtraHighQualityRateBtn");
		HighQualityRate = (GTextField)((GComponent)this).GetChild("HighQualityRate");
		CurQuality = (UI_QualityIcon)(object)((GComponent)this).GetChild("CurQuality");
		NextQuality = (UI_QualityIcon)(object)((GComponent)this).GetChild("NextQuality");
		ForgeBtn = (UI_btn_ForgeBtn)(object)((GComponent)this).GetChild("ForgeBtn");
		AddBtn = (UI_btn_GetMoreAmplifierFormula)(object)((GComponent)this).GetChild("AddBtn");
		ReduceBtn = (UI_btn_ReduceBtn)(object)((GComponent)this).GetChild("ReduceBtn");
		CountToForge = (GTextField)((GComponent)this).GetChild("CountToForge");
		MaxBtn = (UI_btn_MaxBtn)(object)((GComponent)this).GetChild("MaxBtn");
		ConsumeList = (GList)((GComponent)this).GetChild("ConsumeList");
		AmplifierStorageEntryBtn = (UI_btn_AmplifierStorageEntryBtn)(object)((GComponent)this).GetChild("AmplifierStorageEntryBtn");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		n168 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n168");
		n169 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n169");
		ui_amplifier_forge_gun = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun");
		ui_amplifier_forge_gun2 = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun2");
		ui_amplifier_forge_icon = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_icon");
		skyForgeBtn = (UI_btn_03)(object)((GComponent)this).GetChild("skyForgeBtn");
		ForgeResultDialogMask = (GGraph)((GComponent)this).GetChild("ForgeResultDialogMask");
		ForgeResultDialog = (UI_com_ForgeResultDialog)(object)((GComponent)this).GetChild("ForgeResultDialog");
		Mask2 = (GGraph)((GComponent)this).GetChild("Mask2");
		SkyForgeOpDialog = (UI_com_02)(object)((GComponent)this).GetChild("SkyForgeOpDialog");
		ForgeAmp = ((GComponent)this).GetTransition("ForgeAmp");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		CoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		TypeMenu.selectedIndex = 0;
		RarityMenu.selectedIndex = 0;
		CurRecipeListIndex = -1;
		SelectedRarity = ((UI_RarityTab)(object)((GComponent)RarityMenu).GetChildAt(RarityMenu.selectedIndex)).Rarity.selectedIndex;
		SelectedType = (eAmplifierType)((UI_btn_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(TypeMenu.selectedIndex)).Type.selectedIndex;
		_amplifierData = Singleton<GvGAmplifierManager>.Instance.GvGAmplifierData;
		RecipeList.SetVirtual();
		RecipeList.itemProvider = new ListItemProvider(GetListItemResource);
		RecipeList.itemRenderer = new ListItemRenderer(RenderRecipeItem);
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			_amplifierData.GetData(Update);
		});
		((GObject)AmpConsumeDiscountRateBtn).visible = false;
		((GObject)ExtraHighQualityRateBtn).visible = false;
		Singleton<GvGAmplifierManager>.Instance.SyncAmplifierTalentData(delegate
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			AmpConsumeDiscountRate = Singleton<GvGAmplifierManager>.Instance.TalentData.AmpConsumeDiscountRate;
			ExtraAmpForgeHighQualityRate = Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmpForgeHighQualityRate;
			((GObject)AmpConsumeDiscountRateBtn).visible = AmpConsumeDiscountRate > 0f;
			((GObject)ExtraHighQualityRateBtn).visible = ExtraAmpForgeHighQualityRate > 0f;
			AmpConsumeDiscountRateBtn.SetPopupTips(Singleton<GvGAmplifierManager>.Instance.TalentData.AmpConsumeDiscountRate_Tip);
			ExtraHighQualityRateBtn.SetPopupTips(Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmpForgeHighQualityRate_Tip);
			RenderCurRecipe();
		});
		showSkyForegeOpDialog.SetSelectedIndex(0);
		bool flag = "I67509".IsActive();
		hasOuterTech.SetSelectedIndex(flag ? 1 : 0);
		SkyForgeOpDialog.Init(delegate
		{
			showSkyForegeOpDialog.SetSelectedIndex(0);
		});
		InitVfx();
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnHelpClick));
		((GObject)AmplifierStorageEntryBtn).onClick.Add(new EventCallback1(OpenStoratePanel));
		RarityMenu.onClickItem.Add(new EventCallback1(OnSelectRarity));
		TypeMenu.onClickItem.Add(new EventCallback1(OnSelectType));
		RecipeList.onClickItem.Add(new EventCallback0(OnSelectRecipe));
		((GObject)AddBtn).onClick.Add(new EventCallback1(OnClickAddBtn));
		((GObject)ReduceBtn).onClick.Add(new EventCallback1(OnClickReduceBtn));
		((GObject)MaxBtn).onClick.Add(new EventCallback1(OnClickMaxBtn));
		((GObject)ForgeBtn).onClick.Add(new EventCallback1(OnClickForgeBtn));
		((GObject)ForgeResultDialog.ConfirmBrn).onClick.Set(new EventCallback0(OnHideForgeResultDialog));
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Combine(instance.OnChange, new Action(OnChangeStoreHouse));
		((GObject)skyForgeBtn).onClick.Set(new EventCallback1(OnClickSkyForgeBtn));
		((GObject)Mask2).onClick.Set(new EventCallback1(OnClickSkyForgeMask));
		SkyForgeOpDialog.RegisterUiListener();
		SharedMessenger.AddListener<ItemChangePack>("ON_GVGSTOREHOUSE_STOCK_CHANGE_WITH_REASON", OnItemChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		((GObject)AmplifierStorageEntryBtn).onClick.Clear();
		RarityMenu.onClickItem.Clear();
		TypeMenu.onClickItem.Clear();
		RecipeList.onClickItem.Clear();
		((GObject)AddBtn).onClick.Clear();
		((GObject)ReduceBtn).onClick.Clear();
		((GObject)MaxBtn).onClick.Clear();
		((GObject)ForgeBtn).onClick.Clear();
		((GObject)ForgeResultDialog.ConfirmBrn).onClick.Clear();
		S2C_OuterTechAmpTransfrom.OnPushEvent = (Action<S2C_OuterTechAmpTransfrom.Request>)Delegate.Remove(S2C_OuterTechAmpTransfrom.OnPushEvent, new Action<S2C_OuterTechAmpTransfrom.Request>(OnPushItemChange));
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Remove(instance.OnChange, new Action(OnChangeStoreHouse));
		((GObject)skyForgeBtn).onClick.Clear();
		((GObject)Mask2).onClick.Clear();
		SkyForgeOpDialog.UnRegisterUiListener();
		SharedMessenger.RemoveListener<ItemChangePack>("ON_GVGSTOREHOUSE_STOCK_CHANGE_WITH_REASON", OnItemChange);
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("增幅器锻造", "远征相关", "增幅器");
	}

	private void OnSelectType(EventContext context)
	{
		eAmplifierType selectedIndex = (eAmplifierType)((UI_btn_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(TypeMenu.selectedIndex)).Type.selectedIndex;
		if (selectedIndex != SelectedType)
		{
			SelectedType = selectedIndex;
			CurRecipeListIndex = -1;
			OnChangeFilter();
		}
	}

	private void OnSelectRarity(EventContext context)
	{
		int selectedIndex = ((UI_RarityTab)(object)((GComponent)RarityMenu).GetChildAt(RarityMenu.selectedIndex)).Rarity.selectedIndex;
		if (selectedIndex != SelectedRarity)
		{
			SelectedRarity = selectedIndex;
			CurRecipeListIndex = -1;
			OnChangeFilter();
		}
	}

	private void OpenStoratePanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierStoragePanel.Name, null);
	}

	private void OnChangeFilter()
	{
		Update();
	}

	private void OnChangeStoreHouse()
	{
		Update();
	}

	private void OnPushItemChange(S2C_OuterTechAmpTransfrom.Request req)
	{
		Update();
	}

	private void OnItemChange(ItemChangePack pack)
	{
		if (pack.Reason == StockInContext.GvGMode3_OuterTech_AmpTransform && pack.Offset > 0)
		{
			ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, pack.ItemId)}+{pack.Offset}");
		}
	}

	private void OnSelectRecipe()
	{
		if (RecipeList.selectedIndex != -1)
		{
			AmplifierFormulaModel amplifierFormulaModel = FilteredRecipe[RecipeList.selectedIndex];
			if (amplifierFormulaModel == null)
			{
				return;
			}
			if (amplifierFormulaModel is AmplifierFormulaGetMore amplifierFormulaGetMore)
			{
				amplifierFormulaGetMore.OpenGetMoreFormulas();
				return;
			}
			_amplifierData.CheckAmplifierFormula(amplifierFormulaModel.Key, delegate
			{
				UpdateRedDot();
			});
		}
		if (RecipeList.selectedIndex == -1 || CurRecipe != FilteredRecipe[RecipeList.selectedIndex])
		{
			SelectedForgeTimes = 1;
		}
		CurRecipeListIndex = RecipeList.selectedIndex;
		CurRecipe = ((CurRecipeListIndex == -1) ? null : FilteredRecipe[RecipeList.selectedIndex]);
		RenderCurRecipe();
	}

	private void OnClickAddBtn(EventContext context)
	{
		if (SelectedForgeTimes < MaxCanForgeTimes)
		{
			SelectedForgeTimes++;
			UpdateCountToForgeText();
		}
	}

	private void OnClickReduceBtn(EventContext context)
	{
		if (SelectedForgeTimes != 1)
		{
			SelectedForgeTimes--;
			UpdateCountToForgeText();
		}
	}

	private void OnClickSkyForgeBtn(EventContext context)
	{
		context.StopPropagation();
		showSkyForegeOpDialog.SetSelectedIndex(1);
		SkyForgeOpDialog.RefreshWithLevel(CurRecipe.Rarity);
	}

	private void OnClickSkyForgeMask(EventContext context)
	{
		context.StopPropagation();
		showSkyForegeOpDialog.SetSelectedIndex(0);
	}

	private void OnClickMaxBtn(EventContext context)
	{
		if (MaxCanForgeTimes != 0)
		{
			SelectedForgeTimes = MaxCanForgeTimes;
			UpdateCountToForgeText();
		}
	}

	private void OnClickForgeBtn(EventContext context)
	{
		_amplifierData.ForgeAmplifier(CurRecipe.Key, SelectedForgeTimes, delegate(GvGAmplifierManager.ForgeData forgedData)
		{
			if (forgedData != null)
			{
				ShowForgeResultDialog(forgedData.ForgedAmplifiers, forgedData.CriticalAmps, forgedData.ExtraAmps, forgedData.ExtraItems);
				Update();
			}
			else
			{
				ILRuntimeDebug.LogError("[UI_GvGAmplifierForgePanel] 锻造失败");
			}
		});
	}

	private void OnClickItem(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private void OnHideForgeResultDialog()
	{
		CoroutineQueue.Clear();
		IsShowForgeResult.selectedIndex = 0;
		ForgeAmp.Stop();
		ForgeResultDialog.t0.Stop();
		UI_com_ForgeResultContent content = ForgeResultDialog.Content;
		((GComponent)content).scrollPane.posY = 0f;
		((GComponent)content.AmplifierList).RemoveChildren();
		content.AmplifierList.numItems = 0;
		((GComponent)content.AmplifierList_big).RemoveChildren();
		content.AmplifierList_big.numItems = 0;
		((GComponent)content.Extras.ExtraList).RemoveChildren();
		content.Extras.ExtraList.numItems = 0;
	}

	private void OnShowAmpIntro(int idx)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "AmpIdx", idx } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_mian_GvGAmpIntroductionPopup.Name, parameters);
	}

	private void ShowForgeResultDialog(Dictionary<int, int> forgedAmps, List<int> criticalAmps, List<ForgedExtraAmplifier> extraAmps, List<ForgedExtraItem> extraItems)
	{
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		IsShowForgeResult.selectedIndex = 1;
		HashSet<int> criticalSet = new HashSet<int>(criticalAmps);
		List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
		List<KeyValuePair<int, int>> list2 = new List<KeyValuePair<int, int>>();
		foreach (ForgedExtraAmplifier extraAmp in extraAmps)
		{
			forgedAmps[extraAmp.Idx] -= extraAmp.Count;
		}
		List<object> extraList = new List<object>();
		extraList.AddRange(extraAmps);
		extraList.AddRange(extraItems);
		foreach (KeyValuePair<int, int> forgedAmp in forgedAmps)
		{
			if (forgedAmp.Value != 0)
			{
				if (criticalSet.Contains(forgedAmp.Key))
				{
					list.Add(forgedAmp);
				}
				else
				{
					list2.Add(forgedAmp);
				}
			}
		}
		List<KeyValuePair<int, int>> forgedList = new List<KeyValuePair<int, int>>();
		forgedList.AddRange(list);
		forgedList.AddRange(list2);
		NormalForgedCount = forgedList.Count;
		UI_com_ForgeResultContent content = ForgeResultDialog.Content;
		((GComponent)content).scrollPane.posY = 0f;
		CoroutineQueue.AddCoroutine(WaitForForgingAnimation());
		if (extraList.Count == 0 && forgedList.Count <= 2)
		{
			ForgeResultDialog.Count.selectedIndex = 0;
			content.AmplifierList.align = (AlignType)1;
			content.AmplifierList_big.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				RenderAmplifierSlotBig(i, (UI_AmplifierSlotBig)(object)o, forgedList, criticalSet);
			};
			content.AmplifierList_big.numItems = forgedList.Count;
			content.AmplifierList_big.ResizeToFit(forgedList.Count);
		}
		else
		{
			content.AmplifierList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				RenderAmplifierSlot(i, (UI_AmplifierSlot)(object)o, forgedList, criticalSet);
			};
			content.AmplifierList.numItems = forgedList.Count;
			content.AmplifierList.ResizeToFit(forgedList.Count);
			if (extraList.Count == 0 && 3 <= forgedList.Count && forgedList.Count <= 5)
			{
				ForgeResultDialog.Count.selectedIndex = 1;
				content.AmplifierList.align = (AlignType)1;
			}
			else
			{
				ForgeResultDialog.Count.selectedIndex = 2;
				((GObject)ForgeResultDialog.ScrollTip).visible = true;
				content.AmplifierList.align = (AlignType)0;
				content.Extras.ExtraList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
				{
					RenderExtraSlot(i, (UI_btn_ExtraSlot)(object)o, extraList);
				};
				content.Extras.ExtraList.numItems = extraList.Count;
				content.Extras.ExtraList.ResizeToFit(extraList.Count);
				if (extraList.Count == 0)
				{
					((GObject)content.Extras.ExtraList).height = 0f;
				}
			}
		}
		UpdateResultTip(extraList);
	}

	private void UpdateResultTip(List<object> extraList)
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		if (extraList.Count == 0)
		{
			((GObject)ForgeResultDialog.Content.Extras.Tips).visible = false;
			return;
		}
		string text = "ForgeAmpResultTip".ToLanguage();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (object extra in extraList)
		{
			GvGTalentUiModel gvGTalentUiModel = null;
			if (extra is ForgedExtraAmplifier)
			{
				gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel((extra as ForgedExtraAmplifier).src);
			}
			else if (extra is ForgedExtraItem)
			{
				gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel((extra as ForgedExtraItem).src);
			}
			if (gvGTalentUiModel != null)
			{
				hashSet.Add(gvGTalentUiModel.Name);
			}
		}
		foreach (string item in hashSet)
		{
			text = text + "\n" + item;
		}
		((GObject)ForgeResultDialog.Content.Extras.Tips).visible = true;
		ForgeResultDialog.Content.Extras.Tips.SetPopupTips(text);
	}

	private void RenderAmplifierSlot(int i, UI_AmplifierSlot slot, List<KeyValuePair<int, int>> forgedAmps, HashSet<int> criticalSet)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		int idx = forgedAmps[i].Key;
		int value = forgedAmps[i].Value;
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.AmplifierIcon, amplifierModel);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.AffectedRange, amplifierModel);
		slot.IsCriticalStrike.selectedIndex = (criticalSet.Contains(idx) ? 1 : 0);
		((GObject)slot.Count).text = $"x{value}";
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnShowAmpIntro(idx);
		});
		slot.Quatity.selectedIndex = amplifierModel.Quality;
		DelayRenderSlot((GComponent)(object)slot, i);
	}

	private void RenderAmplifierSlotBig(int i, UI_AmplifierSlotBig slot, List<KeyValuePair<int, int>> forgedAmps, HashSet<int> criticalSet)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		int idx = forgedAmps[i].Key;
		int value = forgedAmps[i].Value;
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.AmplifierIcon, amplifierModel);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.AffectedRange, amplifierModel);
		slot.IsCriticalStrike.selectedIndex = (criticalSet.Contains(idx) ? 1 : 0);
		((GObject)slot.Count).text = $"x{value}";
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnShowAmpIntro(idx);
		});
		slot.Quatity.selectedIndex = amplifierModel.Quality;
		DelayRenderSlot((GComponent)(object)slot, i);
	}

	private void RenderExtraSlot(int i, UI_btn_ExtraSlot slot, List<object> extraList)
	{
		object obj = extraList[i];
		if (obj is ForgedExtraAmplifier)
		{
			RenderExtraAmp(i, slot, obj as ForgedExtraAmplifier);
		}
		else if (obj is ForgedExtraItem)
		{
			ForgedExtraItem forgedExtraItem = obj as ForgedExtraItem;
			if (StorehouseHelper.IsGvGAmplifierFormulaItem(forgedExtraItem.ItemId))
			{
				RenderExtraFormula(i, slot, forgedExtraItem);
			}
			else
			{
				RenderExtraItem(i, slot, forgedExtraItem);
			}
		}
	}

	private void RenderExtraAmp(int i, UI_btn_ExtraSlot slot, ForgedExtraAmplifier data)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		slot.ItemType.selectedIndex = 0;
		int idx = data.Idx;
		int count = data.Count;
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(idx);
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.Amplifier.AmplifierIcon, amplifierModel);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.Amplifier.AffectedRange, amplifierModel);
		slot.Amplifier.IsCriticalStrike.selectedIndex = (data.IsCritical ? 1 : 0);
		((GObject)slot.Amplifier.Count).text = $"x{count}";
		slot.Amplifier.Quatity.selectedIndex = amplifierModel.Quality;
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnShowAmpIntro(idx);
		});
		slot.TalentSrc.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(data.src);
		DelayRenderSlot((GComponent)(object)slot, i + NormalForgedCount);
	}

	private void RenderExtraFormula(int i, UI_btn_ExtraSlot slot, ForgedExtraItem data)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		slot.ItemType.selectedIndex = 1;
		string itemId = data.ItemId;
		int num = Item.Level(GameManagers.Instance, itemId);
		FGUIManager.Instance.SetItemIconAndFrame(slot.Formula.ItemIcon, itemId, null, UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num));
		((GObject)slot.Formula.Count).text = "x" + data.Count.ShortNumberFormat();
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(itemId);
		});
		slot.TalentSrc.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(data.src);
		DelayRenderSlot((GComponent)(object)slot, i + NormalForgedCount);
	}

	private void RenderExtraItem(int i, UI_btn_ExtraSlot slot, ForgedExtraItem data)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		slot.ItemType.selectedIndex = 2;
		string itemId = data.ItemId;
		int num = Item.Level(GameManagers.Instance, itemId);
		FGUIManager.Instance.SetItemIconAndFrame(slot.Item.ItemIcon, itemId, null, UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num));
		((GObject)slot.Item.Count).text = "x" + data.Count.ShortNumberFormat();
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(itemId);
		});
		slot.TalentSrc.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(data.src);
		DelayRenderSlot((GComponent)(object)slot, i + NormalForgedCount);
	}

	private void DelayRenderSlot(GComponent slot, int i)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		((GObject)slot).alpha = 0f;
		if (((GObject)slot).data != null)
		{
			((GTweener)((GObject)slot).data).Kill(false);
		}
		if (i < 25)
		{
			CoroutineQueue.AddCoroutine(DelayRenderSlotCoroutine(0.1f, slot, i));
		}
		else
		{
			CoroutineQueue.AddCoroutine(DelayRenderSlotCoroutine(0f, slot, i));
		}
	}

	private IEnumerator WaitForForgingAnimation()
	{
		yield return (object)new WaitForSeconds(3.8f);
	}

	private IEnumerator DelayRenderSlotCoroutine(float delayInterval, GComponent slot, int i)
	{
		if (delayInterval > 0f)
		{
			yield return (object)new WaitForSeconds(delayInterval);
			((GObject)slot).data = ((GObject)slot).TweenFade(1f, 0.1f);
		}
		else
		{
			yield return null;
			((GObject)slot).alpha = 1f;
		}
	}

	private void Update()
	{
		if (Singleton<GvGStoreHouseManager>.Instance.Items != null)
		{
			_amplifierData.UpdateUnlockedFormulas();
			RarityMenuRedDotInit();
			DoFilter();
			RecipeList.numItems = FilteredRecipe.Count;
			if (CurRecipeListIndex >= FilteredRecipe.Count)
			{
				CurRecipeListIndex = -1;
			}
			IsListEmpty.selectedIndex = ((RecipeList.numItems == 0) ? 1 : 0);
			RecipeList.selectedIndex = CurRecipeListIndex;
			OnSelectRecipe();
		}
	}

	private void RenderCurRecipe()
	{
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		AmplifierFormulaModel curRecipe = CurRecipe;
		if (curRecipe == null || FilteredRecipe.Count == 0)
		{
			SelectionState.selectedIndex = 0;
			AmpTag.selectedIndex = 1;
			ForgeState.selectedIndex = 0;
			return;
		}
		if (!_amplifierData.FormulaCount_Dict.ContainsKey(curRecipe.Key))
		{
			SelectionState.selectedIndex = 1;
			((GObject)UnlockText).text = curRecipe.UnlockText;
		}
		else
		{
			SelectionState.selectedIndex = 2;
			((GObject)UnlockText).text = "";
		}
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(curRecipe.OutputAmpId);
		((GObject)AmpName).text = amplifierModel.Name;
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(AffectedRange, amplifierModel);
		if (amplifierModel.Tag == eAmplifierTag.Normal)
		{
			AmpTag.selectedIndex = 0;
			KeyValuePair<string, float> keyValuePair = amplifierModel.Desc[0];
			((GObject)Property).text = string.Format(keyValuePair.Key.ToLanguage(), keyValuePair.Value) ?? "";
			((GObject)AmplifierOwnCount).text = $"{Singleton<GvGAmplifierManager>.Instance.GetAmplifierOwnedCount(amplifierModel.Idx)}";
		}
		else if (amplifierModel.Tag == eAmplifierTag.RandomTemplatePool)
		{
			AmpTag.selectedIndex = 1;
			if (string.IsNullOrEmpty(amplifierModel.TemplateDesc))
			{
				throw new Exception($"随机增幅器模板 Idx={amplifierModel.Idx}的TemplateDesc不能为空");
			}
			((GObject)Property).text = amplifierModel.TemplateDesc.ToLanguage();
		}
		Quatity.selectedIndex = amplifierModel.Quality;
		CurQuality.Quatity.selectedIndex = amplifierModel.Quality;
		NextQuality.Quatity.selectedIndex = amplifierModel.Quality + 1;
		((GObject)HighQualityRate).text = $"{_amplifierData.AmpForgeHighQualityRate[amplifierModel.Quality] + ExtraAmpForgeHighQualityRate}%";
		ConsumeListData = new List<KeyValuePair<string, int>>(curRecipe.Input_Dict);
		ConsumeList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderConsumeItem(i, (UI_ConsumeItem)(object)o);
		};
		ConsumeList.numItems = curRecipe.Input_Dict.Count;
		CalcMaxForgeTime();
		UpdateCountToForgeText();
	}

	private void RenderConsumeItem(int i, UI_ConsumeItem item)
	{
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		string itemId = ConsumeListData[i].Key;
		int num = (int)Math.Floor((float)ConsumeListData[i].Value * (1f - AmpConsumeDiscountRate / 100f));
		int num2 = Item.Level(GameManagers.Instance, itemId);
		FGUIManager.Instance.SetItemIconAndFrame(item.ItemIcon, itemId, null, "", frameVisible: false);
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId, includingGSStock: true);
		if (AmpConsumeDiscountRate > 0f)
		{
			((GObject)item.Num).text = itemCount.ShortNumberFormat() + "/[color=#ffff00]" + num.ShortNumberFormat() + "[/color]";
		}
		else
		{
			((GObject)item.Num).text = itemCount.ShortNumberFormat() + "/" + num.ShortNumberFormat();
		}
		item.IsEnough.selectedIndex = ((itemCount >= num) ? 1 : 0);
		((GObject)item).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(itemId);
		});
	}

	private string GetListItemResource(int index)
	{
		AmplifierFormulaModel amplifierFormulaModel = FilteredRecipe[index];
		if (amplifierFormulaModel == null)
		{
			return "ui://fpjheycbej1av4fz";
		}
		if (index == FilteredRecipe.Count - 1)
		{
			return "ui://fpjheycbej1av4g0";
		}
		return "ui://fpjheycbxe3q8";
	}

	private void RenderRecipeItem(int i, GObject obj)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		if (FilteredRecipe[i] == null)
		{
			return;
		}
		if (i == FilteredRecipe.Count - 1)
		{
			obj.onClick.Set(new EventCallback0(OpenGetMoreFormulas));
		}
		else if (obj is UI_RecipeSlot uI_RecipeSlot)
		{
			((GObject)uI_RecipeSlot).touchable = true;
			AmplifierFormulaModel amplifierFormulaModel = FilteredRecipe[i];
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(amplifierFormulaModel.OutputAmpId);
			bool flag = string.IsNullOrEmpty(amplifierModel.AffectedSoldier);
			bool flag2 = AmpConfigHelper.CheckIsDefaultShowFormula(amplifierFormulaModel.Key);
			if (_amplifierData.FormulaCount_Dict.TryGetValue(amplifierFormulaModel.Key, out var value))
			{
				uI_RecipeSlot.State.selectedIndex = ((value.Total != 0 || flag2) ? 1 : 2);
			}
			else
			{
				uI_RecipeSlot.State.selectedIndex = 0;
				((GObject)uI_RecipeSlot.Unlocking).text = amplifierFormulaModel.UnlockText;
			}
			int num = value?.Total ?? 0;
			if (flag2)
			{
				uI_RecipeSlot.ForgeCountState.SetSelectedIndex(1);
				((GObject)uI_RecipeSlot.InfiniteText).text = "∞";
			}
			else
			{
				uI_RecipeSlot.ForgeCountState.SetSelectedIndex((num <= 0) ? 2 : 0);
				((GObject)uI_RecipeSlot.ForgeScrollCount).text = $"{num}";
				((GObject)uI_RecipeSlot.Empty).text = "0";
			}
			uI_RecipeSlot.IsShowRace.selectedIndex = (flag ? 1 : 0);
			if (flag)
			{
				RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace(uI_RecipeSlot.RaceType, amplifierModel);
			}
			else
			{
				RenderHelper_SimpleSolierIcon.RenderAmplifierAffectedSoldier(uI_RecipeSlot.AffectedSoldier, amplifierModel);
			}
			uI_RecipeSlot.Rarity.selectedIndex = amplifierFormulaModel.Rarity;
			((GObject)uI_RecipeSlot.AmpName).text = amplifierModel.Name;
			int num2 = Mathf.Min(100, AmpConfigHelper.CheckIsDefaultShowFormula(amplifierFormulaModel.Key) ? GetResourceCanForgeTimes(amplifierFormulaModel) : Mathf.Min(GetResourceCanForgeTimes(amplifierFormulaModel), num));
			((GObject)uI_RecipeSlot.MaxResourceForgeCount).text = $"{num2}";
			((GObject)uI_RecipeSlot.RedDot).visible = _amplifierData.IsNewAmplifierFormula(amplifierFormulaModel.Key);
		}
		void OpenGetMoreFormulas()
		{
			_getMoreAmplifierFormula?.OpenGetMoreFormulas();
		}
	}

	private void UpdateCountToForgeText()
	{
		ForgeState.selectedIndex = ((SelectedForgeTimes <= MaxCanForgeTimes) ? 1 : 0);
		((GObject)CountToForge).text = $"{SelectedForgeTimes}/{MaxCanForgeTimes}";
	}

	private void NoticeForgedAmplifiers(Dictionary<int, int> forgedAmplifiers)
	{
		foreach (KeyValuePair<int, int> forgedAmplifier in forgedAmplifiers)
		{
			string name = AmpConfigHelper.Configs.TryGetNormalAmplifier(forgedAmplifier.Key).Name;
			List<string> arg = new List<string> { $"{name}+{forgedAmplifier.Value}" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void UpdateRedDot()
	{
		RarityMenuRedDotInit();
		ShowTypeRedDot();
		if (RecipeList.selectedIndex == -1 || RecipeList.selectedIndex >= RecipeList.numItems)
		{
			return;
		}
		int num = RecipeList.ItemIndexToChildIndex(RecipeList.selectedIndex);
		if (num < ((GComponent)RecipeList).numChildren)
		{
			GObject childAt = ((GComponent)RecipeList).GetChildAt(num);
			if (childAt != null)
			{
				((GObject)((UI_RecipeSlot)(object)childAt).RedDot).visible = false;
			}
		}
	}

	private void RarityMenuRedDotInit()
	{
		HashSet<int> hashSet = _amplifierData.HasNewUnlockFormulaRarity();
		for (int i = 0; i < ((GComponent)RarityMenu).numChildren; i++)
		{
			UI_RarityTab uI_RarityTab = (UI_RarityTab)(object)((GComponent)RarityMenu).GetChildAt(i);
			((GObject)uI_RarityTab.RedDot).visible = hashSet.Contains(uI_RarityTab.Rarity.selectedIndex);
		}
	}

	private void ShowTypeRedDot()
	{
		HashSet<int> hashSet = _amplifierData.HasNewUnlockFormulaType(SelectedRarity);
		for (int i = 0; i < ((GComponent)TypeMenu).numChildren; i++)
		{
			UI_btn_TypeTab uI_btn_TypeTab = (UI_btn_TypeTab)(object)((GComponent)TypeMenu).GetChildAt(i);
			((GObject)uI_btn_TypeTab.RedDot).visible = hashSet.Contains(uI_btn_TypeTab.Type.selectedIndex);
		}
	}

	private void InitVfx()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		vfxList = new List<GameObject>();
		vfxList.Add(FGUIManager.Instance.AddTextSpecialEffects(ui_amplifier_forge_gun, "ui_amplifier_forge_gun", new Vector3(100f, 100f, 100f)));
		GameObject val = FGUIManager.Instance.AddTextSpecialEffects(ui_amplifier_forge_gun2, "ui_amplifier_forge_gun", new Vector3(100f, 100f, 100f));
		if ((Object)(object)val != (Object)null)
		{
			val.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}
		vfxList.Add(val);
		vfxList.Add(FGUIManager.Instance.AddTextSpecialEffects(ui_amplifier_forge_icon, "ui_amplifier_forge_icon", new Vector3(100f, 100f, 100f)));
		vfxList.Add(FGUIManager.Instance.AddTextSpecialEffects(ForgeResultDialog.ui_amplifier_forge_result_title, "ui_amplifier_forge_result_title", new Vector3(100f, 100f, 100f)));
		ForgeAmp.SetHook("ui_amplifier_forge_result_title", (TransitionHook)delegate
		{
			((GObject)ForgeResultDialog).visible = true;
		});
	}

	private void CalcMaxForgeTime()
	{
		int num = 0;
		if (_amplifierData.FormulaCount_Dict.TryGetValue(CurRecipe.Key, out var value))
		{
			num = value.Total;
		}
		MaxCanForgeTimes = Mathf.Min(100, AmpConfigHelper.CheckIsDefaultShowFormula(CurRecipe.Key) ? GetResourceCanForgeTimes(CurRecipe) : Mathf.Min(GetResourceCanForgeTimes(CurRecipe), num));
	}

	private int GetResourceCanForgeTimes(AmplifierFormulaModel formula)
	{
		int num = int.MaxValue;
		foreach (KeyValuePair<string, int> item in formula.Input_Dict)
		{
			string key = item.Key;
			int value = item.Value;
			if (!Singleton<GvGStoreHouseManager>.Instance.IsFormulaScrollItem(key))
			{
				int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(key, includingGSStock: true);
				float num2 = ((AmpConsumeDiscountRate > 0f) ? ((float)value * (1f - AmpConsumeDiscountRate / 100f)) : ((float)value));
				int num3 = (int)Mathf.Floor((float)itemCount / num2);
				num = Mathf.Min(num, num3);
			}
		}
		return num;
	}

	private void DoFilter()
	{
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		List<AmplifierFormulaModel> list = AmpConfigHelper.FilterFormulaByRarity(AmpConfigHelper.Configs.AlwaysShowFormulas_List, SelectedRarity);
		list = AmpConfigHelper.FilterFormulaByOutputType(list, SelectedType);
		List<AmplifierFormulaModel> list2 = AmpConfigHelper.FilterFormulaByRarity(_amplifierData.Formula_List, SelectedRarity);
		list2 = AmpConfigHelper.FilterFormulaByOutputType(list2, SelectedType);
		List<AmplifierFormulaModel> list3 = new List<AmplifierFormulaModel>();
		List<AmplifierFormulaModel> list4 = new List<AmplifierFormulaModel>();
		foreach (AmplifierFormulaModel item in list2)
		{
			_amplifierData.FormulaCount_Dict.TryGetValue(item.Key, out var value);
			if (value != null)
			{
				if (value.Total == 0)
				{
					list4.Add(item);
				}
				else
				{
					list3.Add(item);
				}
			}
		}
		FilteredRecipe = new List<AmplifierFormulaModel>();
		FilteredRecipe.AddRange(list);
		if (list.Any())
		{
			FilteredRecipe.Add(null);
		}
		FilteredRecipe.AddRange(list3);
		FilteredRecipe.AddRange(list4);
		if (_getMoreAmplifierFormula == null)
		{
			_getMoreAmplifierFormula = new AmplifierFormulaGetMore(new Vector2(((GObject)GRoot.inst).width / 2f, ((GObject)GRoot.inst).height / 2f));
		}
		FilteredRecipe.Add(_getMoreAmplifierFormula);
		ShowTypeRedDot();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		_getMoreAmplifierFormula?.Destroy();
		foreach (GameObject vfx in vfxList)
		{
			if ((Object)(object)vfx != (Object)null)
			{
				Object.Destroy((Object)(object)vfx);
			}
		}
	}

	public void End()
	{
		CoroutineQueue.Clear();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
