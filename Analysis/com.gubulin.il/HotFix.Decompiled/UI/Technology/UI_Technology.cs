using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GiftBag;
using UI.PublicResources;
using UnityEngine;

namespace UI.Technology;

public class UI_Technology : GComponent, IUiController
{
	public Controller PageControll;

	public Controller Status;

	public GLoader background;

	public UI_Title Title;

	public GButton ExitBtn;

	public GComponent addCouponBtn;

	public GButton ExclamationTipBtn;

	public GComponent addCoupon2ndBtn;

	public GImage DestroyBtnDark;

	public GImage DominateBtnDark;

	public GImage EnslaveBtnDark;

	public UI_RefreshCardBtn RefreshCardBtn;

	public GImage BackA;

	public GGroup backGroup;

	public UI_DestroyPage DestroyPage;

	public UI_DominatePage DominatePage;

	public UI_EnslavePage EnslavePage;

	public GImage DestroyBtnLight;

	public UI_DestroyBtn DestroyBtn;

	public GImage DominateBtnLight;

	public UI_DominateBtn DominateBtn;

	public GImage EnslaveBtnLight;

	public UI_EnslaveBtn EnslaveBtn;

	public GGraph ScreenFlash;

	public GGraph clickMask;

	public Transition tab0Exit;

	public Transition UpgradeDominate;

	public Transition UpgradeDestroy;

	public Transition UpgradeEnslave;

	public const string URL = "ui://7ca77a3fty9ro";

	public static string Name = "UI_Technology";

	private List<string> allKey;

	private int currentPage;

	private GButton[] destroyDotBtns;

	private UI_DetailInfoPage DetailInfoPage;

	private UI_DetailactivationPage DetailactivationPage;

	private GButton activatingButton;

	public UI_ProductionNumFloating NumFloating1st;

	public UI_RefreshCardPopup RefreshCardPopup;

	public UI_ProductionNumFloating NumFloating2nd;

	private readonly string[] desc = new string[3]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText570") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText571"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText572") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText573"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText574") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText575")
	};

	private GButton[] dominateDotBtns;

	private GButton[] enslaveDotBtns;

	private string technologyId;

	private GButton technologyDot;

	private bool canLight;

	private List<string> textureList = new List<string>();

	public string FocusTechId;

	public static string GetURL()
	{
		return "ui://7ca77a3fty9ro";
	}

	public static UI_Technology CreateInstance()
	{
		return (UI_Technology)(object)UIPackage.CreateObject("Technology", "Technology");
	}

	public static UI_Technology CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Technology).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9ro", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageControll = ((GComponent)this).GetController("PageControll");
		Status = ((GComponent)this).GetController("Status");
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		ExclamationTipBtn = (GButton)((GComponent)this).GetChild("ExclamationTipBtn");
		addCoupon2ndBtn = (GComponent)((GComponent)this).GetChild("addCoupon2ndBtn");
		DestroyBtnDark = (GImage)((GComponent)this).GetChild("DestroyBtnDark");
		DominateBtnDark = (GImage)((GComponent)this).GetChild("DominateBtnDark");
		EnslaveBtnDark = (GImage)((GComponent)this).GetChild("EnslaveBtnDark");
		RefreshCardBtn = (UI_RefreshCardBtn)(object)((GComponent)this).GetChild("RefreshCardBtn");
		BackA = (GImage)((GComponent)this).GetChild("BackA");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		DestroyPage = (UI_DestroyPage)(object)((GComponent)this).GetChild("DestroyPage");
		DominatePage = (UI_DominatePage)(object)((GComponent)this).GetChild("DominatePage");
		EnslavePage = (UI_EnslavePage)(object)((GComponent)this).GetChild("EnslavePage");
		DestroyBtnLight = (GImage)((GComponent)this).GetChild("DestroyBtnLight");
		DestroyBtn = (UI_DestroyBtn)(object)((GComponent)this).GetChild("DestroyBtn");
		DominateBtnLight = (GImage)((GComponent)this).GetChild("DominateBtnLight");
		DominateBtn = (UI_DominateBtn)(object)((GComponent)this).GetChild("DominateBtn");
		EnslaveBtnLight = (GImage)((GComponent)this).GetChild("EnslaveBtnLight");
		EnslaveBtn = (UI_EnslaveBtn)(object)((GComponent)this).GetChild("EnslaveBtn");
		ScreenFlash = (GGraph)((GComponent)this).GetChild("ScreenFlash");
		clickMask = (GGraph)((GComponent)this).GetChild("clickMask");
		tab0Exit = ((GComponent)this).GetTransition("tab0Exit");
		UpgradeDominate = ((GComponent)this).GetTransition("UpgradeDominate");
		UpgradeDestroy = ((GComponent)this).GetTransition("UpgradeDestroy");
		UpgradeEnslave = ((GComponent)this).GetTransition("UpgradeEnslave");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Technology.DoomTab", DestroyBtn);
		instance.Unregister("Technology.SlaveryTab", EnslaveBtn);
		instance.Unregister("Technology.DominionTab", DominateBtn);
		instance.Unregister("Technology.DoomArtifact", DestroyPage.DestroyMasterBtn);
		instance.Unregister("Technology.SlaveryArtifact", EnslavePage.EnslaveMaster);
		instance.Unregister("Technology.DominionArtifact", DominatePage.DominateMasterBtn);
		instance.Unregister("Technology.Node");
		instance.Unregister("Technology.UpgradeBtn");
		instance.Unregister("Technology.ActivateBtn");
		if (string.IsNullOrWhiteSpace(FocusTechId))
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	public void OnShow()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (!string.IsNullOrEmpty(FocusTechId) && FGUIManager.Instance.TechIdisNotMainKey(FocusTechId))
		{
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				PlayTransition();
			});
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Technology.DoomTab", DestroyBtn);
		instance.Register("Technology.SlaveryTab", EnslaveBtn);
		instance.Register("Technology.DominionTab", DominateBtn);
		instance.Register("Technology.DoomArtifact", DestroyPage.DestroyMasterBtn);
		instance.Register("Technology.SlaveryArtifact", EnslavePage.EnslaveMaster);
		instance.Register("Technology.DominionArtifact", DominatePage.DominateMasterBtn);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		canLight = true;
		FGUIManager.Instance.TechnologyPanel = this;
		SetBuildingName();
		UpdateCouponNum();
		((GObject)ExclamationTipBtn).visible = GameManagers.Instance.NewMsgIncomingManager.HasNewTechPoint();
		if (parameters != null)
		{
			object value2;
			if (parameters.TryGetValue("Tab", out var value))
			{
				PageControll.selectedIndex = (currentPage = (int)value);
			}
			else if (parameters.TryGetValue("TechId", out value2))
			{
				FocusTechId = value2.ToString();
				if (TechnologyManager.IsDoomTechnology(FocusTechId))
				{
					PageControll.selectedIndex = (currentPage = 0);
				}
				else if (TechnologyManager.IsDominionTechnology(FocusTechId))
				{
					PageControll.selectedIndex = (currentPage = 1);
				}
				else if (TechnologyManager.IsSlaveryTechnology(FocusTechId))
				{
					PageControll.selectedIndex = (currentPage = 2);
				}
			}
			else
			{
				PageControll.selectedIndex = (currentPage = 0);
			}
		}
		SetTechIcon();
		List<int> list = new List<int> { 0, 1, 2 };
		list.Remove(currentPage);
		foreach (int item in list)
		{
			RefreshTechnologyData(item);
		}
		RefreshTechnologyData(currentPage);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Expected O, but got Unknown
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Expected O, but got Unknown
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Expected O, but got Unknown
		//IL_0cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccf: Expected O, but got Unknown
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Expected O, but got Unknown
		SharedMessenger.AddListener<string, int>("TECH_UPGRADED", OnTechUpgrade);
		FGUIManager.Instance.SkipShowTechUpgradeTip = true;
		((GObject)DestroyBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)DominateBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)EnslaveBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)ExitBtn).onClick.Add(new EventCallback0(ExitPanel));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddStarClick));
		((GObject)addCoupon2ndBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddDiamondClick));
		((GObject)ExclamationTipBtn).onClick.Add(new EventCallback0(UpdateTechPointNote));
		((GObject)RefreshCardBtn).onClick.Add(new EventCallback0(ShowRefreshCardPopup));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		destroyDotBtns = (GButton[])(object)new GButton[13]
		{
			DestroyPage.DestroyMasterBtn, DestroyPage.DestroyDotBtn1, DestroyPage.DestroyDotBtn2, DestroyPage.DestroyDotBtn3, DestroyPage.DestroyDotBtn4, DestroyPage.DestroyDotBtn5, DestroyPage.DestroyDotBtn6, DestroyPage.DestroyDotBtn7, DestroyPage.DestroyDotBtn8, DestroyPage.DestroyDotBtn9,
			DestroyPage.DestroyDotBtn10, DestroyPage.DestroyDotBtn11, DestroyPage.DestroyDotBtn12
		};
		dominateDotBtns = (GButton[])(object)new GButton[13]
		{
			DominatePage.DominateMasterBtn, DominatePage.DominateDotBtn1, DominatePage.DominateDotBtn2, DominatePage.DominateDotBtn3, DominatePage.DominateDotBtn4, DominatePage.DominateDotBtn5, DominatePage.DominateDotBtn6, DominatePage.DominateDotBtn7, DominatePage.DominateDotBtn8, DominatePage.DominateDotBtn9,
			DominatePage.DominateDotBtn10, DominatePage.DominateDotBtn11, DominatePage.DominateDotBtn12
		};
		enslaveDotBtns = (GButton[])(object)new GButton[13]
		{
			EnslavePage.EnslaveMaster, EnslavePage.EnslaveDotBtn1, EnslavePage.EnslaveDotBtn2, EnslavePage.EnslaveDotBtn3, EnslavePage.EnslaveDotBtn4, EnslavePage.EnslaveDotBtn5, EnslavePage.EnslaveDotBtn6, EnslavePage.EnslaveDotBtn7, EnslavePage.EnslaveDotBtn8, EnslavePage.EnslaveDotBtn9,
			EnslavePage.EnslaveDotBtn10, EnslavePage.EnslaveDotBtn11, EnslavePage.EnslaveDotBtn12
		};
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[3]);
		if (techLevel > 0)
		{
			((GObject)EnslavePage.tip).visible = false;
		}
		else
		{
			((GObject)EnslavePage.tip).visible = true;
		}
		int techLevel2 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[5]);
		if (techLevel2 > 0)
		{
			((GObject)DominatePage.tip).visible = false;
		}
		else
		{
			((GObject)DominatePage.tip).visible = true;
		}
		int techLevel3 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[5]);
		if (techLevel3 > 0)
		{
			((GObject)DestroyPage.tip).visible = false;
		}
		else
		{
			((GObject)DestroyPage.tip).visible = true;
		}
		for (int i = 0; i < destroyDotBtns.Length; i++)
		{
			destroyDotBtns[i].title = TechnologyManager.DoomTechnologies[i];
			dominateDotBtns[i].title = TechnologyManager.DominionTechnologies[i];
			enslaveDotBtns[i].title = TechnologyManager.SlaveryTechnologies[i];
			string text = i.ToString();
			if (i == 0)
			{
				text = LanguagesManager.GetDesc("CsharpCodeZhTcText569");
			}
			((GObject)((GComponent)destroyDotBtns[i]).GetChild("index").asTextField).text = text;
			((GObject)((GComponent)dominateDotBtns[i]).GetChild("index").asTextField).text = text;
			((GObject)((GComponent)enslaveDotBtns[i]).GetChild("index").asTextField).text = text;
			if (i == 0)
			{
				string techId = TechnologyManager.DoomTechnologies[i];
				int maxLevel = TechnologyData.GetMaxLevel();
				UI_DestroyMasterBtn uI_DestroyMasterBtn = (UI_DestroyMasterBtn)(object)destroyDotBtns[i];
				int techLevel4 = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId);
				if (techLevel4 == 0)
				{
					uI_DestroyMasterBtn.Type.selectedIndex = 0;
					DestroyPage.PageController.selectedIndex = 0;
				}
				else
				{
					uI_DestroyMasterBtn.Type.selectedIndex = 1;
					((GObject)uI_DestroyMasterBtn.levelNew).text = techLevel4.ToString();
					((GObject)uI_DestroyMasterBtn.levelLimit).text = $"/{maxLevel}";
					DestroyPage.PageController.selectedIndex = 1;
					FGUIManager.Instance.AddTextSpecialEffects(uI_DestroyMasterBtn.backSpine, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
				}
				((GObject)destroyDotBtns[i]).data = techLevel4;
				SetTechNodeLine(destroyDotBtns[i], 0, techLevel4);
				UI_DestroyMasterBtn uI_DestroyMasterBtn2 = (UI_DestroyMasterBtn)(object)dominateDotBtns[i];
				int techLevel5 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[i]);
				if (techLevel5 == 0)
				{
					uI_DestroyMasterBtn2.Type.selectedIndex = 0;
					DominatePage.PageController.selectedIndex = 0;
				}
				else
				{
					((GObject)uI_DestroyMasterBtn2.levelNew).text = techLevel5.ToString();
					((GObject)uI_DestroyMasterBtn2.levelLimit).text = $"/{maxLevel}";
					uI_DestroyMasterBtn2.Type.selectedIndex = 1;
					DominatePage.PageController.selectedIndex = 1;
					FGUIManager.Instance.AddTextSpecialEffects(uI_DestroyMasterBtn2.backSpine, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
				}
				((GObject)dominateDotBtns[i]).data = techLevel5;
				SetTechNodeLine(dominateDotBtns[i], 0, techLevel5);
				UI_DestroyMasterBtn uI_DestroyMasterBtn3 = (UI_DestroyMasterBtn)(object)enslaveDotBtns[i];
				int techLevel6 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[i]);
				if (techLevel6 == 0)
				{
					uI_DestroyMasterBtn3.Type.selectedIndex = 0;
					EnslavePage.PageController.selectedIndex = 0;
				}
				else
				{
					((GObject)uI_DestroyMasterBtn3.levelNew).text = techLevel6.ToString();
					((GObject)uI_DestroyMasterBtn3.levelLimit).text = $"/{maxLevel}";
					uI_DestroyMasterBtn3.Type.selectedIndex = 1;
					EnslavePage.PageController.selectedIndex = 1;
					FGUIManager.Instance.AddTextSpecialEffects(uI_DestroyMasterBtn3.backSpine, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
				}
				((GObject)enslaveDotBtns[i]).data = techLevel6;
				SetTechNodeLine(enslaveDotBtns[i], 0, techLevel6);
				((GObject)destroyDotBtns[i]).onClick.Add(new EventCallback1(DevilIntroduction));
				((GObject)dominateDotBtns[i]).onClick.Add(new EventCallback1(DevilIntroduction));
				((GObject)enslaveDotBtns[i]).onClick.Add(new EventCallback1(DevilIntroduction));
				((GObject)destroyDotBtns[i]).touchable = true;
				((GObject)dominateDotBtns[i]).touchable = true;
				((GObject)enslaveDotBtns[i]).touchable = true;
			}
			else
			{
				string techId2 = TechnologyManager.DoomTechnologies[i];
				int maxLevel2 = TechnologyData.GetMaxLevel();
				int techLevel7 = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId2);
				((GObject)((GComponent)destroyDotBtns[i]).GetChild("level").asTextField).text = $"{techLevel7}";
				((GObject)((GComponent)destroyDotBtns[i]).GetChild("levelLimit").asTextField).text = $"/{maxLevel2}";
				Controller controller = ((GComponent)destroyDotBtns[i]).GetController("PageController");
				if (techLevel7 > 0)
				{
					controller.selectedIndex = 2;
				}
				else
				{
					controller.selectedIndex = (JudgeTechFrontTechsLevel(destroyDotBtns[i].title) ? 1 : 0);
				}
				((UI_DestroyDotBtn)(object)destroyDotBtns[i]).SetControllerPageText();
				SetTechNodeLine(destroyDotBtns[i], (i != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[0]));
				string techId3 = TechnologyManager.DominionTechnologies[i];
				int techLevel8 = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId3);
				int maxLevel3 = TechnologyData.GetMaxLevel();
				((GObject)((GComponent)dominateDotBtns[i]).GetChild("level").asTextField).text = $"{techLevel8}";
				((GObject)((GComponent)dominateDotBtns[i]).GetChild("levelLimit").asTextField).text = $"/{maxLevel3}";
				Controller controller2 = ((GComponent)dominateDotBtns[i]).GetController("PageController");
				if (techLevel8 > 0)
				{
					controller2.selectedIndex = 2;
				}
				else
				{
					controller2.selectedIndex = (JudgeTechFrontTechsLevel(dominateDotBtns[i].title) ? 1 : 0);
				}
				((UI_DestroyDotBtn)(object)dominateDotBtns[i]).SetControllerPageText();
				SetTechNodeLine(dominateDotBtns[i], (i != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[0]));
				string techId4 = TechnologyManager.SlaveryTechnologies[i];
				int techLevel9 = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId4);
				int maxLevel4 = TechnologyData.GetMaxLevel();
				((GObject)((GComponent)enslaveDotBtns[i]).GetChild("level").asTextField).text = $"{techLevel9}";
				((GObject)((GComponent)enslaveDotBtns[i]).GetChild("levelLimit").asTextField).text = $"/{maxLevel4}";
				Controller controller3 = ((GComponent)enslaveDotBtns[i]).GetController("PageController");
				if (techLevel9 > 0)
				{
					controller3.selectedIndex = 2;
				}
				else
				{
					controller3.selectedIndex = (JudgeTechFrontTechsLevel(enslaveDotBtns[i].title) ? 1 : 0);
				}
				((UI_DestroyDotBtn)(object)enslaveDotBtns[i]).SetControllerPageText();
				SetTechNodeLine(enslaveDotBtns[i], (i != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[0]));
				((GObject)destroyDotBtns[i]).onClick.Add(new EventCallback1(TechnologyDotClickEvent));
				((GObject)dominateDotBtns[i]).onClick.Add(new EventCallback1(TechnologyDotClickEvent));
				((GObject)enslaveDotBtns[i]).onClick.Add(new EventCallback1(TechnologyDotClickEvent));
			}
		}
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		SharedMessenger.RemoveListener<string, int>("TECH_UPGRADED", OnTechUpgrade);
		FGUIManager.Instance.SkipShowTechUpgradeTip = false;
		((GObject)DestroyBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)DominateBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)EnslaveBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)ExitBtn).onClick.Remove(new EventCallback0(ExitPanel));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddStarClick));
		((GObject)addCoupon2ndBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddStarClick));
		((GObject)ExclamationTipBtn).onClick.Remove(new EventCallback0(UpdateTechPointNote));
		((GObject)RefreshCardBtn).onClick.Remove(new EventCallback0(ShowRefreshCardPopup));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		for (int i = 0; i < destroyDotBtns.Length; i++)
		{
			if (i == 0)
			{
				((GObject)destroyDotBtns[i]).onClick.Remove(new EventCallback1(DevilIntroduction));
				((GObject)dominateDotBtns[i]).onClick.Remove(new EventCallback1(DevilIntroduction));
				((GObject)enslaveDotBtns[i]).onClick.Remove(new EventCallback1(DevilIntroduction));
			}
			((GObject)destroyDotBtns[i]).onClick.Remove(new EventCallback1(TechnologyDotClickEvent));
			((GObject)dominateDotBtns[i]).onClick.Remove(new EventCallback1(TechnologyDotClickEvent));
			((GObject)enslaveDotBtns[i]).onClick.Remove(new EventCallback1(TechnologyDotClickEvent));
		}
	}

	private void UpdateTechPointNote()
	{
		GameManagers.Instance.NewMsgIncomingManager.CheckNewTechPoint();
		((GObject)ExclamationTipBtn).visible = false;
	}

	private void OnTechUpgrade(string techId, int level)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		if (FGUIManager.Instance.TechIdisNotMainKey(techId))
		{
			return;
		}
		float duration = 2.5f;
		((GObject)clickMask).visible = true;
		if (techId == TechnologyManager.DominionArtifactKey)
		{
			DominatePage.MasterUpgrade.SetHook("ChangeControllerType", (TransitionHook)delegate
			{
				DominatePage.PageController.SetSelectedIndex((level > 0) ? 1 : 0);
				DominatePage.DominateMasterBtn.Type.SetSelectedIndex((level > 0) ? 1 : 0);
			});
			DominatePage.DominateMasterBtn.MasterUpgrade.SetHook("ChangeNumber", (TransitionHook)delegate
			{
				((GObject)DominatePage.DominateMasterBtn.levelNew).text = level.ToString();
			});
			((GObject)DominatePage.DominateMasterBtn.levelNew).text = (level - 1).ToString();
			PlayCompleteCallback val = default(PlayCompleteCallback);
			((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
			{
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Expected O, but got Unknown
				//IL_0080: Expected O, but got Unknown
				FGUIManager.Instance.AddTextSpecialEffects(DominatePage.FxWrapper, "UI_TechUpgrade_Crown", new Vector3(100f, 100f, 100f));
				((GObject)DominatePage.FxWrapper).visible = true;
				Transition upgradeDominate = UpgradeDominate;
				PlayCompleteCallback obj = val;
				if (obj == null)
				{
					PlayCompleteCallback val2 = delegate
					{
						OnAnimationEnd();
						((GObject)DominatePage.FxWrapper).visible = false;
					};
					PlayCompleteCallback val3 = val2;
					val = val2;
					obj = val3;
				}
				upgradeDominate.Play(obj);
			});
		}
		else if (techId == TechnologyManager.DoomArtifactKey)
		{
			DestroyPage.MasterUpgrade.SetHook("ChangeControllerType", (TransitionHook)delegate
			{
				DestroyPage.PageController.SetSelectedIndex((level > 0) ? 1 : 0);
				DestroyPage.DestroyMasterBtn.Type.SetSelectedIndex((level > 0) ? 1 : 0);
			});
			DestroyPage.DestroyMasterBtn.MasterUpgrade.SetHook("ChangeNumber", (TransitionHook)delegate
			{
				((GObject)DestroyPage.DestroyMasterBtn.levelNew).text = level.ToString();
			});
			((GObject)DestroyPage.DestroyMasterBtn.levelNew).text = (level - 1).ToString();
			PlayCompleteCallback val = default(PlayCompleteCallback);
			((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
			{
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Expected O, but got Unknown
				//IL_0080: Expected O, but got Unknown
				FGUIManager.Instance.AddTextSpecialEffects(DestroyPage.FxWrapper, "UI_TechUpgrade_Sword", new Vector3(100f, 100f, 100f));
				((GObject)DestroyPage.FxWrapper).visible = true;
				Transition upgradeDestroy = UpgradeDestroy;
				PlayCompleteCallback obj = val;
				if (obj == null)
				{
					PlayCompleteCallback val2 = delegate
					{
						OnAnimationEnd();
						((GObject)DestroyPage.FxWrapper).visible = false;
					};
					PlayCompleteCallback val3 = val2;
					val = val2;
					obj = val3;
				}
				upgradeDestroy.Play(obj);
			});
		}
		else
		{
			if (!(techId == TechnologyManager.SlaveryArtifactKey))
			{
				return;
			}
			EnslavePage.MasterUpgrade.SetHook("ChangeControllerType", (TransitionHook)delegate
			{
				EnslavePage.PageController.SetSelectedIndex((level > 0) ? 1 : 0);
				EnslavePage.EnslaveMaster.Type.SetSelectedIndex((level > 0) ? 1 : 0);
			});
			EnslavePage.EnslaveMaster.MasterUpgrade.SetHook("ChangeNumber", (TransitionHook)delegate
			{
				((GObject)EnslavePage.EnslaveMaster.levelNew).text = level.ToString();
			});
			((GObject)EnslavePage.EnslaveMaster.levelNew).text = (level - 1).ToString();
			PlayCompleteCallback val = default(PlayCompleteCallback);
			((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
			{
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Expected O, but got Unknown
				//IL_0080: Expected O, but got Unknown
				FGUIManager.Instance.AddTextSpecialEffects(EnslavePage.FxWrapper, "UI_TechUpgrade_Eye", new Vector3(100f, 100f, 100f));
				((GObject)DominatePage.FxWrapper).visible = true;
				Transition upgradeEnslave = UpgradeEnslave;
				PlayCompleteCallback obj = val;
				if (obj == null)
				{
					PlayCompleteCallback val2 = delegate
					{
						OnAnimationEnd();
						((GObject)DominatePage.FxWrapper).visible = false;
					};
					PlayCompleteCallback val3 = val2;
					val = val2;
					obj = val3;
				}
				upgradeEnslave.Play(obj);
			});
		}
		void OnAnimationEnd()
		{
			((GObject)clickMask).visible = false;
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "MainTechId", techId },
				{ "Level", level }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LordUpgradeTipPanel.Name, parameters);
		}
	}

	private void SetTechIcon()
	{
		for (int i = 0; i < destroyDotBtns.Length; i++)
		{
			GButton val = destroyDotBtns[i];
			GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(val.title);
			if (i == 0)
			{
				((GComponent)val).GetChild("icon").asLoader.url = "ui://Technology/tech_sword_1";
				((GComponent)val).GetChild("iconGray").asLoader.url = "ui://Technology/tech_sword_2";
			}
			else
			{
				((GComponent)val).GetChild("icon").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData.Icon;
				((GComponent)val).GetChild("iconGray").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData.Icon + "_grey";
			}
		}
		for (int j = 0; j < dominateDotBtns.Length; j++)
		{
			GButton val2 = dominateDotBtns[j];
			GDETechnologyData gDETechnologyData2 = GDMgr.Get<GDETechnologyData>(val2.title);
			if (j == 0)
			{
				((GComponent)val2).GetChild("icon").asLoader.url = "ui://Technology/tech_crown_1";
				((GComponent)val2).GetChild("iconGray").asLoader.url = "ui://Technology/tech_crown_2";
			}
			else
			{
				((GComponent)val2).GetChild("icon").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData2.Icon;
				((GComponent)val2).GetChild("iconGray").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData2.Icon + "_grey";
			}
		}
		for (int k = 0; k < enslaveDotBtns.Length; k++)
		{
			GButton val3 = enslaveDotBtns[k];
			GDETechnologyData gDETechnologyData3 = GDMgr.Get<GDETechnologyData>(val3.title);
			if (k == 0)
			{
				((GComponent)val3).GetChild("icon").asLoader.url = "ui://Technology/tech_eye_1";
				((GComponent)val3).GetChild("iconGray").asLoader.url = "ui://Technology/tech_eye_2";
			}
			else
			{
				((GComponent)val3).GetChild("icon").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData3.Icon;
				((GComponent)val3).GetChild("iconGray").asLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData3.Icon + "_grey";
			}
		}
	}

	private void RefreshTechnologyData(int currentIndex, bool isActivating = false)
	{
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		//IL_0ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd9: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		int maxLevel = TechnologyData.GetMaxLevel();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		switch (currentIndex)
		{
		case 0:
		{
			PlayHideLine(destroyDotBtns);
			int techLevel3 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[5]);
			if (techLevel3 > 0)
			{
				((GObject)DestroyPage.tip).visible = false;
			}
			else
			{
				((GObject)DestroyPage.tip).visible = true;
			}
			for (int num = 0; num < destroyDotBtns.Length; num++)
			{
				GButton techBtn2 = destroyDotBtns[num];
				string text2 = TechnologyManager.DoomTechnologies[num];
				dictionary.Add(text2, techBtn2);
				int techLevel4 = GameManagers.Instance.UserArchiveManager.GetTechLevel(text2);
				if (num == 0)
				{
					UI_DestroyMasterBtn uI_DestroyMasterBtn2 = (UI_DestroyMasterBtn)(object)techBtn2;
					if (techLevel4 == 0)
					{
						uI_DestroyMasterBtn2.Type.selectedIndex = 0;
						DestroyPage.PageController.selectedIndex = 0;
						((GObject)uI_DestroyMasterBtn2.backSpine).displayObject.Dispose();
					}
					else
					{
						((GObject)uI_DestroyMasterBtn2.levelLimit).text = $"/{maxLevel}";
						if (!isActivating)
						{
							((GObject)uI_DestroyMasterBtn2.levelNew).text = techLevel4.ToString();
							uI_DestroyMasterBtn2.Type.selectedIndex = 1;
							DestroyPage.PageController.selectedIndex = 1;
							FGUIManager.Instance.AddTextSpecialEffects(uI_DestroyMasterBtn2.backSpine, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
						}
					}
					SetTechNodeLine(techBtn2, 0, techLevel4);
					((GComponent)techBtn2).GetTransition("lightUp").Play();
					((GObject)techBtn2).data = techLevel4;
					continue;
				}
				int selectedIndex2 = ((GComponent)techBtn2).GetController("PageController").selectedIndex;
				int pageControllerSelectIndexChangeValue2 = selectedIndex2;
				if (techLevel4 > 0)
				{
					pageControllerSelectIndexChangeValue2 = 2;
				}
				else
				{
					pageControllerSelectIndexChangeValue2 = (JudgeTechFrontTechsLevel(techBtn2.title) ? 1 : 0);
				}
				((GObject)((GComponent)techBtn2).GetChild("level").asTextField).text = $"{techLevel4}";
				if (techLevel4 <= 0)
				{
					((GObject)((GComponent)techBtn2).GetChild("backSpine").asGraph).displayObject.Dispose();
				}
				else if (!string.IsNullOrWhiteSpace(FocusTechId) && text2 == FocusTechId && canLight && FGUIManager.Instance.TechIdisNotMainKey(FocusTechId))
				{
					((GObject)techBtn2).touchable = false;
					((GComponent)techBtn2).GetTransition("lightUp").Play(1, 0f, 0f, 0.04f, (PlayCompleteCallback)null);
					pageControllerSelectIndexChangeValue2 = 0;
				}
				else
				{
					((GObject)techBtn2).touchable = true;
					if (!isActivating)
					{
						FGUIManager.Instance.AddTextSpecialEffects(((GComponent)techBtn2).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(90f, 90f, 90f));
					}
				}
				((GObject)((UI_DestroyDotBtn)(object)techBtn2).textSpine).displayObject.Dispose();
				((GComponent)(object)this).SetTimeout(0.1f).OnComplete((GTweenCallback)delegate
				{
					((GComponent)techBtn2).GetController("PageController").selectedIndex = pageControllerSelectIndexChangeValue2;
					((UI_DestroyDotBtn)(object)techBtn2).SetControllerPageText();
				});
				SetTechNodeLine(techBtn2, (num != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[0]));
			}
			break;
		}
		case 1:
		{
			PlayHideLine(dominateDotBtns);
			int techLevel5 = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[5]);
			if (techLevel5 > 0)
			{
				((GObject)DominatePage.tip).visible = false;
			}
			else
			{
				((GObject)DominatePage.tip).visible = true;
			}
			for (int num2 = 0; num2 < dominateDotBtns.Length; num2++)
			{
				GButton techBtn3 = dominateDotBtns[num2];
				string text3 = TechnologyManager.DominionTechnologies[num2];
				dictionary.Add(text3, techBtn3);
				int techLevel6 = GameManagers.Instance.UserArchiveManager.GetTechLevel(text3);
				if (num2 == 0)
				{
					UI_DestroyMasterBtn uI_DestroyMasterBtn3 = (UI_DestroyMasterBtn)(object)techBtn3;
					if (techLevel6 == 0)
					{
						uI_DestroyMasterBtn3.Type.selectedIndex = 0;
						DominatePage.PageController.selectedIndex = 0;
						((GObject)uI_DestroyMasterBtn3.backSpine).displayObject.Dispose();
					}
					else
					{
						((GObject)uI_DestroyMasterBtn3.levelLimit).text = $"/{maxLevel}";
						if (!isActivating)
						{
							((GObject)uI_DestroyMasterBtn3.levelNew).text = techLevel6.ToString();
							uI_DestroyMasterBtn3.Type.selectedIndex = 1;
							DominatePage.PageController.selectedIndex = 1;
							FGUIManager.Instance.AddTextSpecialEffects(((GComponent)techBtn3).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
						}
					}
					((GComponent)techBtn3).GetTransition("lightUp").Play();
					SetTechNodeLine(techBtn3, 0, techLevel6);
					((GObject)techBtn3).data = techLevel6;
					continue;
				}
				int selectedIndex3 = ((GComponent)techBtn3).GetController("PageController").selectedIndex;
				int pageControllerSelectIndexChangeValue3 = selectedIndex3;
				if (techLevel6 > 0)
				{
					pageControllerSelectIndexChangeValue3 = 2;
				}
				else
				{
					pageControllerSelectIndexChangeValue3 = (JudgeTechFrontTechsLevel(techBtn3.title) ? 1 : 0);
				}
				((GObject)((GComponent)techBtn3).GetChild("level").asTextField).text = $"{techLevel6}";
				if (techLevel6 <= 0)
				{
					((GObject)((GComponent)techBtn3).GetChild("backSpine").asGraph).displayObject.Dispose();
				}
				else if (!string.IsNullOrWhiteSpace(FocusTechId) && text3 == FocusTechId && canLight && FGUIManager.Instance.TechIdisNotMainKey(FocusTechId))
				{
					((GObject)techBtn3).touchable = false;
					((GComponent)techBtn3).GetTransition("lightUp").Play(1, 0f, 0f, 0.04f, (PlayCompleteCallback)null);
					pageControllerSelectIndexChangeValue3 = 0;
				}
				else
				{
					((GObject)techBtn3).touchable = true;
					if (!isActivating)
					{
						FGUIManager.Instance.AddTextSpecialEffects(((GComponent)techBtn3).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(90f, 90f, 90f));
					}
				}
				((GObject)((UI_DestroyDotBtn)(object)techBtn3).textSpine).displayObject.Dispose();
				((GComponent)(object)this).SetTimeout(0.1f).OnComplete((GTweenCallback)delegate
				{
					((GComponent)techBtn3).GetController("PageController").selectedIndex = pageControllerSelectIndexChangeValue3;
					((UI_DestroyDotBtn)(object)techBtn3).SetControllerPageText();
				});
				SetTechNodeLine(techBtn3, (num2 != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[0]));
			}
			break;
		}
		case 2:
		{
			PlayHideLine(enslaveDotBtns);
			int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[3]);
			if (techLevel > 0)
			{
				((GObject)EnslavePage.tip).visible = false;
			}
			else
			{
				((GObject)EnslavePage.tip).visible = true;
			}
			for (int i = 0; i < enslaveDotBtns.Length; i++)
			{
				GButton techBtn = enslaveDotBtns[i];
				string text = TechnologyManager.SlaveryTechnologies[i];
				dictionary.Add(text, techBtn);
				int techLevel2 = GameManagers.Instance.UserArchiveManager.GetTechLevel(text);
				if (i == 0)
				{
					UI_DestroyMasterBtn uI_DestroyMasterBtn = (UI_DestroyMasterBtn)(object)techBtn;
					if (techLevel2 == 0)
					{
						uI_DestroyMasterBtn.Type.selectedIndex = 0;
						EnslavePage.PageController.selectedIndex = 0;
						((GObject)uI_DestroyMasterBtn.backSpine).displayObject.Dispose();
					}
					else
					{
						((GObject)uI_DestroyMasterBtn.levelLimit).text = $"/{maxLevel}";
						if (!isActivating)
						{
							((GObject)uI_DestroyMasterBtn.levelNew).text = techLevel2.ToString();
							uI_DestroyMasterBtn.Type.selectedIndex = 1;
							EnslavePage.PageController.selectedIndex = 1;
							FGUIManager.Instance.AddTextSpecialEffects(((GComponent)techBtn).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
						}
					}
					((GComponent)techBtn).GetTransition("lightUp").Play();
					SetTechNodeLine(techBtn, 0, techLevel2);
					((GObject)techBtn).data = techLevel2;
					continue;
				}
				int selectedIndex = ((GComponent)techBtn).GetController("PageController").selectedIndex;
				int pageControllerSelectIndexChangeValue = selectedIndex;
				if (techLevel2 > 0)
				{
					pageControllerSelectIndexChangeValue = 2;
				}
				else
				{
					pageControllerSelectIndexChangeValue = (JudgeTechFrontTechsLevel(techBtn.title) ? 1 : 0);
				}
				((GObject)((GComponent)techBtn).GetChild("level").asTextField).text = $"{techLevel2}";
				if (techLevel2 <= 0)
				{
					((GObject)((GComponent)techBtn).GetChild("backSpine").asGraph).displayObject.Dispose();
				}
				else if (!string.IsNullOrWhiteSpace(FocusTechId) && text == FocusTechId && canLight && FGUIManager.Instance.TechIdisNotMainKey(FocusTechId))
				{
					((GObject)techBtn).touchable = false;
					((GComponent)techBtn).GetTransition("lightUp").Play(1, 0f, 0f, 0.04f, (PlayCompleteCallback)null);
					pageControllerSelectIndexChangeValue = 0;
				}
				else
				{
					((GObject)techBtn).touchable = true;
					if (!isActivating)
					{
						FGUIManager.Instance.AddTextSpecialEffects(((GComponent)techBtn).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(90f, 90f, 90f));
					}
				}
				((GObject)((UI_DestroyDotBtn)(object)techBtn).textSpine).displayObject.Dispose();
				((GComponent)(object)this).SetTimeout(0.1f).OnComplete((GTweenCallback)delegate
				{
					((GComponent)techBtn).GetController("PageController").selectedIndex = pageControllerSelectIndexChangeValue;
					((UI_DestroyDotBtn)(object)techBtn).SetControllerPageText();
				});
				SetTechNodeLine(techBtn, (i != 1) ? 1 : (-1), GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[0]));
			}
			break;
		}
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Technology.Node");
		instance.Register("Technology.Node", dictionary);
	}

	private float PlayHideLine(GButton[] techGButtons)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(techGButtons[0].title);
		float result = 0f;
		if (((GObject)techGButtons[0]).data != null && techLevel > (int)((GObject)techGButtons[0]).data && (int)((GObject)techGButtons[0]).data == 0)
		{
			for (int i = 0; i < techGButtons.Length; i++)
			{
				int num = i;
				if (techGButtons[num].title == FocusTechId)
				{
					SetTechNodeLine(techGButtons[num], 1, 0);
					SetTechNodeLine(techGButtons[0], 0, 0);
				}
			}
			for (int j = 0; j < techGButtons.Length; j++)
			{
				int index = j;
				((GComponent)(object)this).SetTimeout(5.75f).OnComplete((GTweenCallback)delegate
				{
					((GComponent)techGButtons[index]).GetTransition("lineDisapear").Play();
				});
			}
			result = 2.75f;
		}
		return result;
	}

	public void ChangePage(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		currentPage = int.Parse(((GObject)(GButton)context.sender).data.ToString());
		PageControll.selectedIndex = currentPage;
		FocusTechId = string.Empty;
		RefreshTechnologyData(currentPage);
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", currentPage } });
	}

	public void TechnologyDotClickEvent(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		technologyDot = (GButton)context.sender;
		string techId = technologyDot.title;
		technologyId = techId;
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		UiTagManager uiTagManager = UiTagManager.Instance;
		if (GameManagers.Instance.UserArchiveManager.GetTechLevel(techId) < 1)
		{
			DetailactivationPage = UI_DetailactivationPage.CreateInstance();
			((GObject)DetailactivationPage).sortingOrder = 1;
			DetailactivationPage.tip.RepairBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
			((GObject)DetailactivationPage.tip.RepairBtn).onClick.Add((EventCallback0)delegate
			{
				ActivationClickEvent(techId);
			});
			DetailactivationPage.tip.SetButtonTitle();
			((GObject)DetailactivationPage.tip.Name_t).text = gDETechnologyData.Name;
			if (TechnologyData.CanUpgrade(GameManagers.Instance, technologyId))
			{
				((GObject)DetailactivationPage.tip.RepairBtn).enabled = true;
			}
			else
			{
				((GObject)DetailactivationPage.tip.RepairBtn).enabled = false;
			}
			DetailactivationPage.tip.IconLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData.Icon;
			((GObject)DetailactivationPage.tip.Describe_t).text = "";
			((GObject)DetailactivationPage.tip.exit).onClick.Set((EventCallback0)delegate
			{
				((GObject)DetailactivationPage).Dispose();
			});
			RefreshActivatePopupInfo(technologyId, technologyDot);
			((GComponent)GRoot.inst).AddChild((GObject)(object)DetailactivationPage);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)DetailactivationPage);
			FGUIManager.SetToFullScreen((GObject)(object)DetailactivationPage);
			DetailactivationPage.showPopup.Play((PlayCompleteCallback)delegate
			{
				uiTagManager.Unregister("Technology.ActivateBtn");
				uiTagManager.Register("Technology.ActivateBtn", DetailactivationPage.tip.RepairBtn);
			});
		}
		else
		{
			DetailInfoPage = UI_DetailInfoPage.CreateInstance();
			((GObject)DetailInfoPage).sortingOrder = 1;
			DetailInfoPage.tip.RepairBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
			((GObject)DetailInfoPage.tip.RepairBtn).onClick.Add((EventCallback0)delegate
			{
				OnClickUpgradeTech(techId);
			});
			((GObject)DetailInfoPage.tip.Name_t).text = gDETechnologyData.Name;
			if (TechnologyData.CanUpgrade(GameManagers.Instance, technologyId))
			{
				((GObject)DetailInfoPage.tip.RepairBtn).enabled = true;
			}
			else
			{
				((GObject)DetailInfoPage.tip.RepairBtn).enabled = false;
			}
			DetailInfoPage.tip.IconLoader.url = "ui://Technology/TechUiIcon_" + gDETechnologyData.Icon;
			((GObject)DetailInfoPage.tip.Describe_t).text = "";
			((GObject)DetailInfoPage.tip.exit).onClick.Set((EventCallback0)delegate
			{
				((GObject)DetailInfoPage).Dispose();
			});
			RefreshPopupInfo(DetailInfoPage, technologyId, technologyDot);
			((GComponent)GRoot.inst).AddChild((GObject)(object)DetailInfoPage);
			((GObject)DetailInfoPage).SetXY(0f, 0f);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)DetailInfoPage);
			FGUIManager.SetToFullScreen((GObject)(object)DetailInfoPage);
			DetailInfoPage.showPopup.Play((PlayCompleteCallback)delegate
			{
				uiTagManager.Unregister("Technology.UpgradeBtn");
				uiTagManager.Register("Technology.UpgradeBtn", DetailInfoPage.tip.RepairBtn);
			});
		}
	}

	private void TechnologyDotLevelUpdate(string techId)
	{
		technologyId = techId;
		CloseDetailInfoPage();
	}

	private void CloseDetailInfoPage()
	{
		if (DetailInfoPage != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)DetailInfoPage, true);
		}
	}

	private void SetBuildingName(bool isInit = true)
	{
		if (isInit)
		{
			((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText450");
		}
		if (GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[0]) > 0 || GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[0]) > 0 || GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[0]) > 0)
		{
			Status.selectedIndex = 1;
		}
		else
		{
			Status.selectedIndex = 0;
		}
	}

	public void RefreshActivatePopupInfo(string techId, GButton technologyDot)
	{
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		if (DetailactivationPage == null)
		{
			return;
		}
		string key = currentPage switch
		{
			0 => TechnologyManager.DoomArtifactKey, 
			1 => TechnologyManager.DominionArtifactKey, 
			_ => TechnologyManager.SlaveryArtifactKey, 
		};
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		((GObject)DetailactivationPage.tip.Name_t).text = gDETechnologyData.Name;
		string text = "TechUiIcon_" + gDETechnologyData.Icon;
		DetailactivationPage.tip.IconLoader.url = "ui://Technology/" + text;
		GDETechnologyData gDETechnologyData2 = GDMgr.Get<GDETechnologyData>(key);
		((GObject)DetailactivationPage.tip.owner).text = gDETechnologyData2.Name;
		((GObject)DetailactivationPage.tip.gradeTitle).alpha = ((gDETechnologyData.FrontTechs.Count > 0) ? 1 : 0);
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId);
		List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects(techId, techLevel);
		if (techEffects == null)
		{
			GTextField describe_t = DetailactivationPage.tip.Describe_t;
			((GObject)describe_t).text = ((GObject)describe_t).text + " [color=#9bc52a]" + gDETechnologyData.GainDescrible + "[/color]";
		}
		else
		{
			GTextField describe_t2 = DetailactivationPage.tip.Describe_t;
			((GObject)describe_t2).text = ((GObject)describe_t2).text + " [color=#9bc52a]";
			for (int i = 0; i < techEffects.Count; i++)
			{
				Modifier modifier = techEffects[i];
				GDETechnologyEffectData gDETechnologyEffectData = TechnologyManager.TechnologyEffectDataDictionary[techId][techLevel][i];
				if (string.IsNullOrEmpty(gDETechnologyEffectData.Desc))
				{
					GTextField describe_t3 = DetailactivationPage.tip.Describe_t;
					((GObject)describe_t3).text = ((GObject)describe_t3).text + modifier.Desc + " ";
				}
				else
				{
					GTextField describe_t4 = DetailactivationPage.tip.Describe_t;
					((GObject)describe_t4).text = ((GObject)describe_t4).text + gDETechnologyEffectData.Desc + " ";
				}
				if (!string.IsNullOrEmpty(gDETechnologyEffectData.NextDesc))
				{
				}
			}
			GTextField describe_t5 = DetailactivationPage.tip.Describe_t;
			((GObject)describe_t5).text = ((GObject)describe_t5).text + "[/color]";
		}
		Dictionary<string, int> upgradeRequirements = TechnologyData.GetUpgradeRequirements(techId, techLevel + 1);
		if (upgradeRequirements != null)
		{
			string regId = "";
			foreach (KeyValuePair<string, int> item in upgradeRequirements)
			{
				regId = item.Key;
				((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
				if (item.Value > GameManagers.Instance.StockController.GetStock(item.Key))
				{
					((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("reqDesc").asCom.GetChild("curPrice").text = "[color=#DC143C]" + GameManagers.Instance.StockController.GetStock(item.Key).ShortNumberFormat() + "[/color][color=#F6E2B2]/" + item.Value.ShortNumberFormat() + "[/color]";
				}
				else
				{
					((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("reqDesc").asCom.GetChild("curPrice").text = "[color=#F6E2B2]" + GameManagers.Instance.StockController.GetStock(item.Key).ShortNumberFormat() + "[/color][color=#F6E2B2]/" + item.Value.ShortNumberFormat() + "[/color]";
				}
			}
			if (!string.IsNullOrWhiteSpace(regId))
			{
				string itemId = regId;
				int num = Item.Level(GameManagers.Instance, itemId);
				((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
				((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{((num < 1) ? 1 : num)}";
				((GComponent)DetailactivationPage.tip.ConsumptionItem).GetChild("icon").onClick.Set((EventCallback0)delegate
				{
					ItemTip(regId);
				});
			}
			else
			{
				((GObject)DetailactivationPage.tip.ConsumptionTitle).visible = false;
				((GObject)DetailactivationPage.tip.ConsumptionItem).visible = false;
			}
		}
		else
		{
			((GObject)DetailactivationPage.tip.ConsumptionTitle).visible = false;
			((GObject)DetailactivationPage.tip.ConsumptionItem).visible = false;
		}
		if (TechnologyData.FrontTechsSatisfied(techId))
		{
			((GObject)DetailactivationPage.tip.gradeTitle).alpha = 0f;
		}
		else
		{
			((GObject)DetailactivationPage.tip.gradeTitle).alpha = 1f;
		}
		if (TechnologyData.CanUpgrade(GameManagers.Instance, techId))
		{
			((GObject)DetailactivationPage.tip.RepairBtn).enabled = true;
		}
		else
		{
			((GObject)DetailactivationPage.tip.RepairBtn).enabled = false;
		}
	}

	public void RefreshPopupInfo(UI_DetailInfoPage fG_DetailInfoPage, string techId, GButton technologyDot)
	{
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Expected O, but got Unknown
		string key;
		string techId2;
		if (currentPage == 0)
		{
			key = TechnologyManager.DoomArtifactKey;
			techId2 = TechnologyManager.DoomTechnologies[0];
		}
		else if (currentPage == 1)
		{
			key = TechnologyManager.DominionArtifactKey;
			techId2 = TechnologyManager.DominionTechnologies[0];
		}
		else
		{
			key = TechnologyManager.SlaveryArtifactKey;
			techId2 = TechnologyManager.SlaveryTechnologies[0];
		}
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(techId);
		((GObject)fG_DetailInfoPage.tip.Name_t).text = gDETechnologyData.Name;
		string text = "TechUiIcon_" + gDETechnologyData.Icon;
		fG_DetailInfoPage.tip.IconLoader.url = "ui://Technology/" + text;
		GDETechnologyData gDETechnologyData2 = GDMgr.Get<GDETechnologyData>(key);
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId);
		int maxLevel = TechnologyData.GetMaxLevel();
		((GObject)fG_DetailInfoPage.tip.Level_t).text = $"{techLevel}/{maxLevel}";
		((GObject)fG_DetailInfoPage.tip.owner).text = gDETechnologyData2.Name;
		fG_DetailInfoPage.tip.consumptionList.numItems = 0;
		fG_DetailInfoPage.tip.consumptionList.AddItemFromPool();
		List<Modifier> effects = TechnologyData.GetEffects(GameManagers.Instance, techId, techLevel);
		int techLevel2 = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId2);
		((GObject)fG_DetailInfoPage.tip.gradeTitle).visible = true;
		((GObject)fG_DetailInfoPage.tip.Level_t).visible = true;
		((GObject)fG_DetailInfoPage.tip.consumptionList).visible = true;
		((GObject)fG_DetailInfoPage.tip.RepairBtn).visible = true;
		if (!TechnologyData.IsMaxLevel(technologyId))
		{
			bool flag = TechnologyData.FrontTechsSatisfied(technologyId);
			((GObject)DetailInfoPage.tip.n49).visible = !flag;
			if (TechnologyData.IsFirstTechNode(technologyId))
			{
				int weaponLevel = TechnologyData.GetWeaponLevel((TechnologyType)gDETechnologyData.Type);
				string format = LanguagesManager.GetDesc("CsharpCodeZhTcText961");
				((GObject)DetailInfoPage.tip.n49).text = string.Format(format, weaponLevel + 1);
			}
		}
		else
		{
			((GObject)DetailInfoPage.tip.n49).visible = false;
		}
		string text2 = "";
		string text3 = "";
		if (effects == null)
		{
			text3 = text3 + " [color=#9bc52a]" + gDETechnologyData.GainDescrible + "[/color]";
		}
		else
		{
			text3 += " [color=#9bc52a]";
			for (int i = 0; i < effects.Count; i++)
			{
				Modifier modifier = effects[i];
				GDETechnologyEffectData gDETechnologyEffectData = TechnologyManager.TechnologyEffectDataDictionary[techId][techLevel][i];
				text3 = ((!string.IsNullOrEmpty(gDETechnologyEffectData.Desc)) ? (text3 + gDETechnologyEffectData.Desc + " ") : (text3 + modifier.Desc + " "));
				if (!string.IsNullOrEmpty(gDETechnologyEffectData.NextDesc))
				{
					text2 = text2 + gDETechnologyEffectData.NextDesc + " ";
				}
			}
			text3 += "[/color]";
		}
		if (techLevel2 >= 1 && !string.IsNullOrEmpty(text2))
		{
			text3 = text3 + Environment.NewLine + "[color=#9bc52a](" + LanguagesManager.GetDesc("CsharpCodeZhTcText576") + "：" + text2 + ")[/color]";
		}
		((GObject)fG_DetailInfoPage.tip.Describe_t).text = text3;
		((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).text = "";
		if (TechnologyData.IsMaxLevel(techId))
		{
			((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).visible = false;
			((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).asButton.title = "";
			((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).visible = false;
			((GObject)fG_DetailInfoPage.tip.tip).visible = true;
			((GObject)fG_DetailInfoPage.tip.RepairBtn).touchable = false;
			((GObject)fG_DetailInfoPage.tip.RepairBtn).grayed = true;
		}
		else
		{
			((GObject)fG_DetailInfoPage.tip.tip).visible = false;
			((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).visible = true;
			Dictionary<string, int> upgradeRequirements = TechnologyData.GetUpgradeRequirements(techId, techLevel + 1);
			if (upgradeRequirements != null)
			{
				string regId = "";
				foreach (KeyValuePair<string, int> item in upgradeRequirements)
				{
					regId = item.Key;
					GButton asButton = ((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).asButton;
					((GComponent)asButton).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
					if (item.Value > GameManagers.Instance.StockController.GetStock(item.Key))
					{
						((GComponent)asButton).GetChild("reqDesc").asCom.GetChild("curPrice").text = "[color=#DC143C]" + GameManagers.Instance.StockController.GetStock(item.Key).ShortNumberFormat() + "[/color][color=#F6E2B2]/" + item.Value.ShortNumberFormat() + "[/color]";
					}
					else
					{
						((GComponent)asButton).GetChild("reqDesc").asCom.GetChild("curPrice").text = "[color=#F6E2B2]" + GameManagers.Instance.StockController.GetStock(item.Key).ShortNumberFormat() + "[/color][color=#F6E2B2]/" + item.Value.ShortNumberFormat() + "[/color]";
					}
				}
				if (!string.IsNullOrWhiteSpace(regId))
				{
					((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText577") + "：";
					((GObject)((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).asButton).onClick.Set((EventCallback0)delegate
					{
						ItemTip(regId, CloseDetailInfoPage);
					});
					string iconPath = UiHelper.GetIconPath(regId);
					((GComponent)((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
					string itemId = regId;
					int num = Item.Level(GameManagers.Instance, itemId);
					((GComponent)((GComponent)fG_DetailInfoPage.tip.consumptionList).GetChildAt(0).asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{((num < 1) ? 1 : num)}";
				}
				else
				{
					((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).visible = false;
					((GObject)fG_DetailInfoPage.tip.consumptionList).visible = false;
				}
			}
			else
			{
				((GObject)fG_DetailInfoPage.tip.ConsumptionTitle).visible = false;
				((GObject)fG_DetailInfoPage.tip.consumptionList).visible = false;
			}
		}
		if (TechnologyData.CanUpgrade(GameManagers.Instance, techId))
		{
			((GObject)fG_DetailInfoPage.tip.RepairBtn).enabled = true;
		}
		else
		{
			((GObject)fG_DetailInfoPage.tip.RepairBtn).enabled = false;
		}
	}

	public void ActivationClickEvent(string techId)
	{
		if (GameManagers.Instance.TechnologyManager.TechCanUpgrade(techId))
		{
			ILRequestHelper<UpgradeTechnologyResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().UpgradeTechnology(-1L, techId), delegate(UpgradeTechnologyResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					OnTechActivationComplete(techId);
				}
			}, 1f);
		}
		((GObject)DetailactivationPage).Dispose();
	}

	private void OnTechActivationComplete(string techId)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		GameManagers.Instance.TechnologyManager.Upgrade(techId);
		FocusTechId = techId;
		PlayTransition(2);
		float num = 0f;
		switch (currentPage)
		{
		case 0:
			num = PlayHideLine(destroyDotBtns);
			break;
		case 1:
			num = PlayHideLine(dominateDotBtns);
			break;
		case 2:
			num = PlayHideLine(enslaveDotBtns);
			break;
		}
		if (num != 0f)
		{
			((GComponent)(object)this).SetTimeout(2f).OnComplete(new GTweenCallback(PlayMainTechActivatingSfx));
		}
		((GComponent)(object)this).SetTimeout(3f + num).OnComplete((GTweenCallback)delegate
		{
			RefreshTechnologyData(currentPage, isActivating: true);
			SetBuildingName(isInit: false);
		});
	}

	public void OnClickUpgradeTech(string techId)
	{
		if (!GameManagers.Instance.TechnologyManager.TechCanUpgrade(techId))
		{
			return;
		}
		ILRequestHelper<UpgradeTechnologyResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().UpgradeTechnology(-1L, techId), delegate(UpgradeTechnologyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.TechnologyManager.Upgrade(techId);
				TechnologyDotLevelUpdate(techId);
				RefreshTechnologyData(currentPage, isActivating: true);
				PlayTechUpgradeAnim(techId);
			}
		}, 1f);
	}

	private void PlayTechUpgradeAnim(string techId)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		GButton[] array = ((currentPage == 0) ? destroyDotBtns : ((currentPage != 1) ? enslaveDotBtns : dominateDotBtns));
		GButton[] array2 = array;
		foreach (GButton val in array2)
		{
			if (!(val.title == techId))
			{
				continue;
			}
			UI_DestroyDotBtn dotBtn = val as UI_DestroyDotBtn;
			if (dotBtn == null)
			{
				continue;
			}
			int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId);
			((GObject)dotBtn.level).text = (techLevel - 1).ToString();
			dotBtn.TechUpgrade.SetHook("ChangeNumber", (TransitionHook)delegate
			{
				((GObject)dotBtn.level).text = techLevel.ToString();
			});
			FGUIManager.Instance.AddTextSpecialEffects(dotBtn.textSpine, "ui_tech_upgrade", new Vector3(100f, 100f, 100f));
			EffectHelper.CoroutineDelay(1.2f, delegate
			{
				if (!((GObject)this).isDisposed)
				{
					((GObject)dotBtn.textSpine).displayObject.Dispose();
				}
			});
			dotBtn.TechUpgrade.Play();
			break;
		}
	}

	public void ExitPanel()
	{
		FocusTechId = "";
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		FGUIManager.Instance.TechnologyPanel = null;
	}

	private void ItemTip(string itemId, Action onJump = null)
	{
		FGUIManager.Instance.ItemTip(itemId, 2, noCheckBtn: false, reserveRes: false, null, isPack: false, null, 0, onJump);
	}

	private void AddDiamondClick()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void AddStarClick()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void DevilIntroduction(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		technologyDot = (GButton)context.sender;
		technologyId = technologyDot.title;
		string text = technologyId;
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(text);
		UI_DetailLordInfoPage DetailLordInfoPage = UI_DetailLordInfoPage.CreateInstance();
		GRoot.inst.ShowPopup((GObject)(object)DetailLordInfoPage);
		((GObject)DetailLordInfoPage).SetXY(0f, 0f);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)DetailLordInfoPage);
		FGUIManager.SetToFullScreen((GObject)(object)DetailLordInfoPage);
		((GObject)DetailLordInfoPage.tip.exit).onClick.Add((EventCallback0)delegate
		{
			((GObject)DetailLordInfoPage).Dispose();
		});
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(text);
		List<Modifier> effects = TechnologyData.GetEffects(GameManagers.Instance, text, techLevel);
		DetailLordInfoPage.tip.gradeTitle.UBBEnabled = true;
		string text2 = "#9bc52a";
		if (techLevel < 1)
		{
			((GObject)DetailLordInfoPage.tip.Level).visible = false;
			((GObject)DetailLordInfoPage.tip.gradeTitle).text = "[color=#B22222]" + LanguagesManager.GetDesc("CsharpCodeZhTcText578") + "[/color]";
			text2 = "#A9A9A9";
		}
		else
		{
			((GObject)DetailLordInfoPage.tip.Level).visible = true;
			((GObject)DetailLordInfoPage.tip.gradeTitle).text = "[color=#D5BA7A]" + LanguagesManager.GetDesc("CsharpCodeZhTcText194") + "：[/color]";
			((GObject)DetailLordInfoPage.tip.Level).text = techLevel.ToString();
		}
		GetPieceNum(currentPage, out var a, out var b);
		((GObject)DetailLordInfoPage.tip.Title).text = gDETechnologyData.Name;
		bool flag = TechnologyData.IsMaxLevel(text);
		if (flag)
		{
			((GObject)DetailLordInfoPage.tip.pieceNum).text = $"{b}/{b}";
		}
		else
		{
			((GObject)DetailLordInfoPage.tip.pieceNum).text = $"{a}/{b}";
		}
		string format = LanguagesManager.GetDesc("CsharpCodeZhTcText964");
		int maxLevel = TechnologyData.GetMaxLevel();
		((GObject)DetailLordInfoPage.tip.n31).text = string.Format(format, techLevel + 1);
		((GObject)DetailLordInfoPage.tip.n31).visible = techLevel >= 1 && techLevel < maxLevel;
		((GObject)DetailLordInfoPage.tip.n33).visible = flag;
		if (HotUpdateProcess.LanguageKey == "eng")
		{
			((GObject)DetailLordInfoPage.tip.n30).width = Mathf.Max(((GObject)DetailLordInfoPage.tip.n30).width, 900f);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(desc[currentPage] + Environment.NewLine + Environment.NewLine);
		stringBuilder.Append("[color=" + text2 + "]");
		if (effects != null)
		{
			foreach (Modifier item in effects)
			{
				stringBuilder.Append(item.Desc + " ");
			}
		}
		else
		{
			stringBuilder.Append(gDETechnologyData.GainDescrible ?? "");
		}
		stringBuilder.Append("[/color]");
		GDETechnologyEffectData effect = TechnologyData.GetEffect(text, techLevel);
		if (effect != null && !string.IsNullOrWhiteSpace(effect.NextDesc))
		{
			string format2 = LanguagesManager.GetDesc("CsharpTechNextEffectDes");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append(string.Format(format2, effect.NextDesc));
		}
		((GObject)DetailLordInfoPage.tip.describe).text = stringBuilder.ToString();
		DetailLordInfoPage.tip.Type.selectedIndex = currentPage;
		DetailLordInfoPage.showPopup.Play();
	}

	private void GetPieceNum(int curTab, out int a, out int b)
	{
		List<string> list = new List<string>();
		string techId = TechnologyManager.DoomArtifactKey;
		switch (curTab)
		{
		case 0:
			list = TechnologyManager.DoomTechnologies;
			break;
		case 1:
			list = TechnologyManager.DominionTechnologies;
			techId = TechnologyManager.DominionArtifactKey;
			break;
		case 2:
			list = TechnologyManager.SlaveryTechnologies;
			techId = TechnologyManager.SlaveryArtifactKey;
			break;
		}
		int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(techId);
		if (techLevel == TechnologyManager.MaxTechnologyLevel)
		{
			a = list.Count - 1;
			b = list.Count - 1;
			return;
		}
		int num = 0;
		for (int i = 1; i < list.Count; i++)
		{
			if (GameManagers.Instance.UserArchiveManager.GetTechLevel(list[i]) > techLevel)
			{
				num++;
			}
		}
		a = num;
		b = list.Count - 1;
	}

	private void SetTechNodeLine(GButton button, int type, int mainLevel)
	{
		int selectedIndex = ((GComponent)button).GetController("Status").selectedIndex;
		int num = selectedIndex;
		for (int i = 0; i < 3; i++)
		{
			((GComponent)button).GetChild($"lightLine{i}").visible = false;
			((GComponent)button).GetChild($"grayLine{i}").visible = false;
		}
		if (type == -1)
		{
			((GComponent)button).GetController("Status").selectedIndex = 0;
			return;
		}
		string title = button.title;
		GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(title);
		if (mainLevel > 0)
		{
			for (int j = 0; j < 3 && j != gDETechnologyData.FrontTechs.Count; j++)
			{
				string text = $"halfLightLine{j}";
				((GComponent)button).GetChild(text).visible = true;
				GButton prior = FindActivatingButton(gDETechnologyData.FrontTechs[j]);
				SetStrongholdLine(prior, button, text);
			}
			return;
		}
		num = 1;
		switch (type)
		{
		case 1:
		{
			if (gDETechnologyData.FrontTechs.Count == 0)
			{
				((GComponent)button).GetController("Status").selectedIndex = 0;
				return;
			}
			for (int l = 0; l < 3 && l != gDETechnologyData.FrontTechs.Count; l++)
			{
				string text3 = "";
				if (GameManagers.Instance.UserArchiveManager.GetTechLevel(gDETechnologyData.FrontTechs[l]) > 0 && GameManagers.Instance.UserArchiveManager.GetTechLevel(button.title) > 0)
				{
					((GComponent)button).GetChild($"lightLine{l}").visible = true;
					text3 = $"lightLine{l}";
				}
				else
				{
					((GComponent)button).GetChild($"grayLine{l}").visible = true;
					text3 = $"grayLine{l}";
				}
				GButton prior3 = FindActivatingButton(gDETechnologyData.FrontTechs[l]);
				SetStrongholdLine(prior3, button, text3);
			}
			break;
		}
		case 0:
		{
			if (gDETechnologyData.FrontTechs.Count == 0)
			{
				((GComponent)button).GetController("Status").selectedIndex = 0;
				return;
			}
			for (int k = 0; k < 3 && k != gDETechnologyData.FrontTechs.Count; k++)
			{
				string text2 = "";
				if (GameManagers.Instance.UserArchiveManager.GetTechLevel(gDETechnologyData.FrontTechs[k]) > 0)
				{
					((GComponent)button).GetChild($"lightLine{k}").visible = true;
					text2 = $"lightLine{k}";
				}
				else
				{
					((GComponent)button).GetChild($"grayLine{k}").visible = true;
					text2 = $"grayLine{k}";
				}
				GButton prior2 = FindActivatingButton(gDETechnologyData.FrontTechs[k]);
				SetStrongholdLine(prior2, button, text2);
			}
			break;
		}
		}
		if (type == 0 && gDETechnologyData.FrontTechs.Contains(FocusTechId))
		{
			for (int m = 0; m < 3; m++)
			{
				((GComponent)button).GetChild($"lightLine{m}").alpha = 0f;
				((GComponent)button).GetChild($"lightLine{m}").TweenFade(1f, 1.5f);
			}
		}
		else if (button.title == FocusTechId)
		{
			for (int n = 0; n < 3; n++)
			{
				((GComponent)button).GetChild($"lightLine{n}").alpha = 0f;
				((GComponent)button).GetChild($"lightLine{n}").TweenFade(1f, 1.5f);
			}
		}
		((GComponent)button).GetController("Status").selectedIndex = num;
	}

	private bool JudgeTechFrontTechsLevel(string techId)
	{
		return TechnologyData.FrontTechsSatisfied(techId);
	}

	private void SetStrongholdLine(GButton prior, GButton latter, string lineName)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		((GObject)prior).SetPivot(0.5f, 0.5f, true);
		((GObject)latter).SetPivot(0.5f, 0.5f, true);
		Vector2 val = ((GObject)prior).xy - ((GObject)latter).xy;
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(0f, 1f);
		((GComponent)latter).GetChild(lineName).height = ((Vector2)(ref val)).magnitude;
		float rotation = Vector2.SignedAngle(val2, val);
		((GComponent)latter).GetChild(lineName).rotation = rotation;
	}

	private GButton FindActivatingButton(string _techId)
	{
		int num = -1;
		GButton[] array = null;
		if (TechnologyManager.DoomTechnologies.Contains(_techId))
		{
			num = TechnologyManager.DoomTechnologies.IndexOf(_techId);
			array = destroyDotBtns;
			return array[num];
		}
		if (TechnologyManager.DominionTechnologies.Contains(_techId))
		{
			num = TechnologyManager.DominionTechnologies.IndexOf(_techId);
			array = dominateDotBtns;
			return array[num];
		}
		if (TechnologyManager.SlaveryTechnologies.Contains(_techId))
		{
			num = TechnologyManager.SlaveryTechnologies.IndexOf(_techId);
			array = enslaveDotBtns;
			return array[num];
		}
		return null;
	}

	private void PlayTransition(int fakeSelectIndex = 0)
	{
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		int index = -1;
		int num = 0;
		GButton[] button;
		switch (currentPage)
		{
		default:
			return;
		case 0:
			index = TechnologyManager.DoomTechnologies.IndexOf(FocusTechId);
			num = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DoomTechnologies[0]);
			button = destroyDotBtns;
			break;
		case 1:
			index = TechnologyManager.DominionTechnologies.IndexOf(FocusTechId);
			num = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.DominionTechnologies[0]);
			button = dominateDotBtns;
			break;
		case 2:
			index = TechnologyManager.SlaveryTechnologies.IndexOf(FocusTechId);
			num = GameManagers.Instance.UserArchiveManager.GetTechLevel(TechnologyManager.SlaveryTechnologies[0]);
			button = enslaveDotBtns;
			break;
		}
		if (index != -1 && button != null)
		{
			int selectedIndex = ((GComponent)button[index]).GetController("PageController").selectedIndex;
			int num2 = selectedIndex;
			int techLevel = GameManagers.Instance.UserArchiveManager.GetTechLevel(FocusTechId);
			num2 = ((fakeSelectIndex != 0) ? 2 : ((num > 0) ? 1 : 2));
			((GComponent)button[index]).GetController("PageController").selectedIndex = num2;
			if (selectedIndex != num2 && selectedIndex == 0 && num2 == 2)
			{
				((GComponent)button[index]).GetTransition("ZeroToTwo").Play();
			}
			((GComponent)button[index]).GetChild("frame").grayed = false;
			((GComponent)button[index]).GetChild("icon").grayed = false;
			((GComponent)button[index]).GetTransition("lightUp").Play((PlayCompleteCallback)delegate
			{
				((GObject)((GComponent)button[index]).GetChild("level").asTextField).text = $"{techLevel}";
			});
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button[index]).GetChild("textSpine").asGraph, "ui_tech_unlock", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject activatingFx)
			{
				UiAudioManager.Instance.LoadSoundsForSfx(activatingFx, "MiniTechActivate");
			});
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button[index]).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(90f, 90f, 90f));
			((GComponent)(object)this).SetTimeout(3f).OnComplete((GTweenCallback)delegate
			{
				((GObject)((GComponent)button[index]).GetChild("textSpine").asGraph).displayObject.Dispose();
				canLight = false;
				((GObject)button[index]).touchable = true;
			});
		}
	}

	private void PlayMainTechActivatingSfx()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		int num = -1;
		GButton[] button;
		switch (currentPage)
		{
		default:
			return;
		case 0:
			num = TechnologyManager.DoomTechnologies.IndexOf(FocusTechId);
			button = destroyDotBtns;
			break;
		case 1:
			num = TechnologyManager.DominionTechnologies.IndexOf(FocusTechId);
			button = dominateDotBtns;
			break;
		case 2:
			num = TechnologyManager.SlaveryTechnologies.IndexOf(FocusTechId);
			button = enslaveDotBtns;
			break;
		}
		FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button[0]).GetChild("textSpine").asGraph, "activating_fx", new Vector3(170f, 170f, 170f), "Default", 0.5f, delegate(GameObject activatingFx)
		{
			UiAudioManager.Instance.LoadSoundsForSfx(activatingFx, "BoxFlashing");
		});
		((GComponent)(object)this).SetTimeout(3f).OnComplete((GTweenCallback)delegate
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			((GObject)((GComponent)button[0]).GetChild("textSpine").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button[0]).GetChild("backSpine").asGraph, "ui_active_glow_orange", new Vector3(110f, 110f, 110f));
			canLight = false;
			((GObject)button[0]).touchable = true;
		});
	}

	private void UpdateCouponNum()
	{
		string itemId = ((GObject)addCouponBtn).data.ToString();
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		addCouponBtn.GetChild("num").text = stock.ShortNumberFormat();
		addCouponBtn.GetChild("num").data = stock;
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		string itemId2 = ((GObject)addCoupon2ndBtn).data.ToString();
		int stock2 = GameManagers.Instance.StockController.GetStock(itemId2);
		addCoupon2ndBtn.GetChild("num").text = stock2.ShortNumberFormat();
		addCoupon2ndBtn.GetChild("num").data = stock2;
		addCoupon2ndBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId2);
	}

	private void ShowRefreshCardPopup()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		RefreshCardPopup = UI_RefreshCardPopup.CreateInstance();
		((GComponent)this).AddChild((GObject)(object)RefreshCardPopup);
		((GObject)RefreshCardPopup).sortingOrder = 1;
		((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = GameManagers.Instance.TechnologyManager.CanReset();
		((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).onClick.Set(new EventCallback1(ResetTechs));
		((GObject)RefreshCardPopup.ConfirmDialog.exitBtn).onClick.Set(new EventCallback0(CloseRefreshCardPopup));
		FGUIManager.SetToFullScreen((GObject)(object)RefreshCardPopup);
		Dictionary<string, int> resetCost = GameManagers.Instance.TechnologyManager.GetResetCost();
		if (resetCost.Count > 0)
		{
			KeyValuePair<string, int> keyValuePair = resetCost.First();
			string itemId = keyValuePair.Key;
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)RefreshCardPopup.ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("icon").asLoader, itemId, textureList);
			GComponent asCom = ((GComponent)RefreshCardPopup.ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("reqDesc").asCom;
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			string text = ((stock < keyValuePair.Value) ? "#DC143C" : "#F6E2B2");
			string text2 = "#F6E2B2";
			GComponent asCom2 = asCom.GetChild("originPrice").asCom;
			((GObject)asCom2).SetSize(0f, 0f);
			((GObject)asCom2).visible = false;
			if (stock < keyValuePair.Value)
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = false;
			}
			else
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = true;
			}
			int number = stock;
			GTextField asTextField = asCom.GetChild("curPrice").asTextField;
			((GObject)asTextField).text = $"[color={text}]{number.ShortNumberFormat()}[/color][color={text2}]/{keyValuePair.Value}[/color]";
			((GObject)RefreshCardPopup.ConfirmDialog.DialogMiddleContent).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		RefreshCardPopup.showTip.Play();
	}

	private void ResetTechs(EventContext eventContext)
	{
		ILRequestHelper<ResetTechnologyResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ResetTechnology(-1L), delegate(ResetTechnologyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.TechnologyManager.ResetAllTechnologies();
				CloseRefreshCardPopup();
				PlayResetTechSfx();
			}
		});
	}

	private void PlayResetTechSfx()
	{
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		GButton[] button;
		switch (currentPage)
		{
		default:
			return;
		case 0:
			button = destroyDotBtns;
			break;
		case 1:
			button = dominateDotBtns;
			break;
		case 2:
			button = enslaveDotBtns;
			break;
		}
		if (DestroyPage.PageController.selectedIndex == 1)
		{
			DestroyPage.PageController.selectedIndex = 0;
			for (int i = 0; i < destroyDotBtns.Length; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					((GComponent)destroyDotBtns[i]).GetChild($"grayLine{j}").visible = true;
					((GComponent)destroyDotBtns[i]).GetChild($"grayLine{j}").alpha = 1f;
				}
			}
		}
		if (DominatePage.PageController.selectedIndex == 1)
		{
			DominatePage.PageController.selectedIndex = 0;
			for (int k = 0; k < dominateDotBtns.Length; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					((GComponent)dominateDotBtns[k]).GetChild($"grayLine{l}").visible = true;
					((GComponent)dominateDotBtns[k]).GetChild($"grayLine{l}").alpha = 1f;
				}
			}
		}
		if (EnslavePage.PageController.selectedIndex == 1)
		{
			EnslavePage.PageController.selectedIndex = 0;
			for (int m = 0; m < enslaveDotBtns.Length; m++)
			{
				for (int n = 0; n < 3; n++)
				{
					((GComponent)enslaveDotBtns[m]).GetChild($"grayLine{n}").visible = true;
					((GComponent)enslaveDotBtns[m]).GetChild($"grayLine{n}").alpha = 1f;
				}
			}
		}
		for (int num = 0; num < button.Length; num++)
		{
			for (int num2 = 0; num2 < 3; num2++)
			{
				((GComponent)button[num]).GetChild($"lightLine{num2}").TweenFade(0f, 0.5f);
			}
			int index = num;
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				if (index == 0)
				{
					((GObject)((GComponent)button[index]).GetChild("backSpine").asGraph).displayObject.Dispose();
				}
				else
				{
					((GObject)((GComponent)button[index]).GetChild("textSpine").asGraph).displayObject.Dispose();
				}
			});
		}
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			PageControll.selectedIndex = currentPage;
			RefreshTechnologyData(currentPage);
		});
	}

	private void CloseRefreshCardPopup()
	{
		if (RefreshCardPopup != null)
		{
			((GComponent)this).RemoveChild((GObject)(object)RefreshCardPopup, true);
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		if (itemId == ((GObject)addCouponBtn).data.ToString())
		{
			((GObject)addCouponBtn.GetChild("num").asTextField).text = stock.ShortNumberFormat() ?? "";
			int num = ((addCouponBtn.GetChild("num").data != null) ? ((int)addCouponBtn.GetChild("num").data) : stock);
			if (num != stock && stock > num)
			{
				int num2 = stock - num;
				if (NumFloating1st == null)
				{
					NumFloating1st = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloating1st).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating1st, addCouponBtn, stock - num);
				}
				else
				{
					((GObject)NumFloating1st.Title).text = $"+{(int)((GObject)NumFloating1st.Title).data + num2}";
					((GObject)NumFloating1st.Title).data = (int)((GObject)NumFloating1st.Title).data + num2;
				}
			}
			addCouponBtn.GetChild("num").data = stock;
			addCouponBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addCouponBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		if (!(itemId == ((GObject)addCoupon2ndBtn).data.ToString()))
		{
			return;
		}
		((GObject)addCoupon2ndBtn.GetChild("num").asTextField).text = stock.ShortNumberFormat() ?? "";
		int num3 = ((addCoupon2ndBtn.GetChild("num").data != null) ? ((int)addCoupon2ndBtn.GetChild("num").data) : stock);
		if (num3 != stock && stock > num3)
		{
			int num4 = stock - num3;
			if (NumFloating2nd == null)
			{
				NumFloating2nd = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating2nd).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating2nd, addCoupon2ndBtn, stock - num3);
			}
			else
			{
				((GObject)NumFloating2nd.Title).text = $"+{(int)((GObject)NumFloating2nd.Title).data + num4}";
				((GObject)NumFloating2nd.Title).data = (int)((GObject)NumFloating2nd.Title).data + num4;
			}
		}
		addCoupon2ndBtn.GetChild("num").data = stock;
		addCoupon2ndBtn.GetChild("textSFXBack").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addCoupon2ndBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		});
	}
}
