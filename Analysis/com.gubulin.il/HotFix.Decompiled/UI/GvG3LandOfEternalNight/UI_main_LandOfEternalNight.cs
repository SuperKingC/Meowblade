using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGLoading;

namespace UI.GvG3LandOfEternalNight;

public class UI_main_LandOfEternalNight : GComponent, IUiController
{
	public Controller Type;

	public Controller StoryType;

	public GGraph Mask;

	public GGraph ClickGraph;

	public GImage n7;

	public UI_com_Stage1 Stage1;

	public UI_com_Stage2 Stage2;

	public GImage n15;

	public GImage n16;

	public GImage n18;

	public GGroup n20;

	public UI_com_BrawlStage1 BrawlStage1;

	public UI_com_BrawlStage2 BrawlStage2;

	public GImage n23;

	public GImage n24;

	public GGroup n22;

	public UI_btn_Location FlagShipPositioning;

	public UI_btn_Location EternalNightPositioning;

	public Transition Progress1;

	public Transition Progress2;

	public const string URL = "ui://amuqyzl8c4i70";

	public static string Name = "UI_main_LandOfEternalNight";

	private Action _invokePlayTransition;

	public static string GetURL()
	{
		return "ui://amuqyzl8c4i70";
	}

	public static UI_main_LandOfEternalNight CreateInstance()
	{
		return (UI_main_LandOfEternalNight)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "main_LandOfEternalNight");
	}

	public static UI_main_LandOfEternalNight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LandOfEternalNight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8c4i70", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		StoryType = ((GComponent)this).GetController("StoryType");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		ClickGraph = (GGraph)((GComponent)this).GetChild("ClickGraph");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Stage1 = (UI_com_Stage1)(object)((GComponent)this).GetChild("Stage1");
		Stage2 = (UI_com_Stage2)(object)((GComponent)this).GetChild("Stage2");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		BrawlStage1 = (UI_com_BrawlStage1)(object)((GComponent)this).GetChild("BrawlStage1");
		BrawlStage2 = (UI_com_BrawlStage2)(object)((GComponent)this).GetChild("BrawlStage2");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n22 = (GGroup)((GComponent)this).GetChild("n22");
		FlagShipPositioning = (UI_btn_Location)(object)((GComponent)this).GetChild("FlagShipPositioning");
		EternalNightPositioning = (UI_btn_Location)(object)((GComponent)this).GetChild("EternalNightPositioning");
		Progress1 = ((GComponent)this).GetTransition("Progress1");
		Progress2 = ((GComponent)this).GetTransition("Progress2");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		object value;
		List<eEternalNightTransition> list = (parameters.TryGetValue("TransitionType", out value) ? (value as List<eEternalNightTransition>) : new List<eEternalNightTransition>());
		if (list != null)
		{
			List<int> list2 = new List<int>();
			foreach (eEternalNightTransition item in list)
			{
				list2.Add((int)item);
			}
			list2.Sort();
			list2.Reverse();
			TryPlayTransition(list2[0]);
		}
		else
		{
			((GObject)ClickGraph).visible = true;
		}
		int selectedIndex = (WorldMapConfigHelper.Configs.IsBrawlEvent() ? 1 : 0);
		StoryType.SetSelectedIndex(selectedIndex);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		((GObject)FlagShipPositioning).data = eEternalNightTransition.Open;
		((GObject)EternalNightPositioning).data = eEternalNightTransition.Boss;
		((GObject)FlagShipPositioning).onClick.Set(new EventCallback1(Locate));
		((GObject)EternalNightPositioning).onClick.Set(new EventCallback1(Locate));
		((GObject)ClickGraph).onClick.Set(new EventCallback0(CloseUi));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnLoadingPanelClose);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)FlagShipPositioning).onClick.Clear();
		((GObject)EternalNightPositioning).onClick.Clear();
		((GObject)ClickGraph).onClick.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnLoadingPanelClose);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void CloseUi()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void TryPlayTransition(int pageIndex)
	{
		if (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_GvGLoading2Panel.Name))
		{
			_invokePlayTransition = delegate
			{
				PlayTransition(pageIndex);
			};
		}
		else
		{
			PlayTransition(pageIndex);
		}
	}

	private void PlayTransition(int pageIndex)
	{
		Type.selectedIndex = pageIndex;
	}

	private void OnLoadingPanelClose(string uiName)
	{
		if (!(uiName != UI_main_GvGLoading2Panel.Name))
		{
			_invokePlayTransition?.Invoke();
		}
	}

	private void Locate(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		eEternalNightTransition eEternalNightTransition = (eEternalNightTransition)((GObject)context.sender).data;
		int islandId = 0;
		switch (eEternalNightTransition)
		{
		case eEternalNightTransition.Open:
			islandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
			break;
		case eEternalNightTransition.Boss:
		{
			if (WorldMapConfigHelper.Configs.IsBrawlEvent())
			{
				islandId = 1450;
				break;
			}
			Dictionary<string, List<int>> dictionary = "GvGMode3FinalProgressIsland".ToConfiguration<Dictionary<string, List<int>>>();
			islandId = dictionary[Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId][0];
			break;
		}
		}
		GvGWorldMapController.Instance.FocusIslandById(islandId);
		End();
	}
}
