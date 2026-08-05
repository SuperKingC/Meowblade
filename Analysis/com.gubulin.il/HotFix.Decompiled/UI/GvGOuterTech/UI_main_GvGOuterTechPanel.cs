using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGOuterTech;

public class UI_main_GvGOuterTechPanel : GComponent, IUiController
{
	public Controller Page;

	public GLoader background;

	public UI_com_TechLotteryPage TechLotteryPage;

	public GLoader background1;

	public UI_com_TechListPage TechListPage;

	public GGraph TouchingMask;

	public Transition ToTechLottery;

	public Transition ToTechList;

	public const string URL = "ui://th385mtty63l0";

	public static string Name = "UI_main_GvGOuterTechPanel";

	public static string GetURL()
	{
		return "ui://th385mtty63l0";
	}

	public static UI_main_GvGOuterTechPanel CreateInstance()
	{
		return (UI_main_GvGOuterTechPanel)(object)UIPackage.CreateObject("GvGOuterTech", "main_GvGOuterTechPanel");
	}

	public static UI_main_GvGOuterTechPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGOuterTechPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63l0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Page = ((GComponent)this).GetController("Page");
		background = (GLoader)((GComponent)this).GetChild("background");
		TechLotteryPage = (UI_com_TechLotteryPage)(object)((GComponent)this).GetChild("TechLotteryPage");
		background1 = (GLoader)((GComponent)this).GetChild("background1");
		TechListPage = (UI_com_TechListPage)(object)((GComponent)this).GetChild("TechListPage");
		TouchingMask = (GGraph)((GComponent)this).GetChild("TouchingMask");
		ToTechLottery = ((GComponent)this).GetTransition("ToTechLottery");
		ToTechList = ((GComponent)this).GetTransition("ToTechList");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ToTechLottery.invalidateBatchingEveryFrame = true;
		ToTechList.invalidateBatchingEveryFrame = true;
		TechListPage.Init();
		TechLotteryPage.Init();
		TechListPage.OnActive();
		if (parameters != null && parameters.TryGetValue("Page", out var value) && (int)value == 1)
		{
			TimerHelper.CallNextFrame(OnGoToTechLotteryPage);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		((GObject)TechListPage.BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)TechListPage.TechLotteryEntry.GotoBtn).onClick.Set(new EventCallback0(OnGoToTechLotteryPage));
		TechListPage.RegisterUiEventListeners();
		((GObject)TechLotteryPage.CloseBtn).onClick.Set(new EventCallback0(OnGoToTechListPage));
		TechLotteryPage.RegisterUiEventListeners();
		ToTechLottery.SetHook("Show", new TransitionHook(OnStartShowTechLotteryPage));
		ToTechLottery.SetHook("End", new TransitionHook(OnFinishChangedToTechLotteryPage));
		ToTechList.SetHook("End", new TransitionHook(OnFinishChangedToTechListPage));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)TechListPage.BackBtn).onClick.Clear();
		((GObject)TechListPage.TechLotteryEntry.GotoBtn).onClick.Clear();
		TechListPage.UnregisterUiEventListeners();
		((GObject)TechLotteryPage.CloseBtn).onClick.Clear();
		TechLotteryPage.UnregisterUiEventListeners();
		ToTechLottery.ClearHooks();
		ToTechList.ClearHooks();
	}

	private void OnGoToTechListPage()
	{
		Page.SetSelectedIndex(0);
		TechLotteryPage.OnInactive();
		TechListPage.OnActive();
	}

	private void OnGoToTechLotteryPage()
	{
		Page.SetSelectedIndex(1);
		TechListPage.OnInactive();
		TechLotteryPage.OnActive();
	}

	private void OnStartShowTechLotteryPage()
	{
		TechLotteryPage.OnShow();
	}

	private void OnFinishChangedToTechLotteryPage()
	{
	}

	private void OnFinishChangedToTechListPage()
	{
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		TechListPage.OnDestroy();
		TechLotteryPage.OnDestroy();
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
