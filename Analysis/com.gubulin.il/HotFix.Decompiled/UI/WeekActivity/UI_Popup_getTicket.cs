using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;

namespace UI.WeekActivity;

public class UI_Popup_getTicket : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_getTicket content;

	public Transition ShowSelf;

	public const string URL = "ui://jl0c82y5txpa3e";

	public static string Name = "UI_Popup_getTicket";

	public static string GetURL()
	{
		return "ui://jl0c82y5txpa3e";
	}

	public static UI_Popup_getTicket CreateInstance()
	{
		return (UI_Popup_getTicket)(object)UIPackage.CreateObject("WeekActivity", "Popup_getTicket");
	}

	public static UI_Popup_getTicket CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Popup_getTicket).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5txpa3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		content = (UI_com_getTicket)(object)((GComponent)this).GetChild("content");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)mask).onClick.Set(new EventCallback0(End));
		((GObject)content.goBtn1).onClick.Set(new EventCallback0(OnClickGoWeekCard));
		((GObject)content.goBtn2).onClick.Set(new EventCallback0(OnClickGoGiftPack));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
		((GObject)content.goBtn1).onClick.Clear();
		((GObject)content.goBtn2).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		GetWeeklyActivityResponse spinWeekActivity = ActivityManager.SpinWeekActivity;
		content.showDailyBonus.SetSelectedIndex(1);
		if (HotUpdateProcess.Instance.IsRegionOutCN && spinWeekActivity.ActivityType == GetWeeklyActivityResponse.SpinWeekType.BigWheel)
		{
			content.showDailyBonus.SetSelectedIndex(0);
		}
		string multiLanguagesUrl = URLHelper.GetMultiLanguagesUrl(UiHelper.GetItemIconPath(spinWeekActivity.ActivityConfig.LotteryItemId));
		string multiLanguagesUrl2 = URLHelper.GetMultiLanguagesUrl(UiHelper.GetItemIconPath(spinWeekActivity.ActivityConfig.ExchangeItemId));
		((GObject)content.tipText).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(LanguagesManager.GetDesc("WeekActivityStorePanelTip"), multiLanguagesUrl, multiLanguagesUrl2);
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

	private static void OnClickGoWeekCard()
	{
		UnityUiService.Instance.OpenPanel(UI_popup_weekSpinCard.Name, new Dictionary<string, object>());
	}

	private static void OnClickGoGiftPack()
	{
		UnityUiService.Instance.OpenPanel(UI_popup_weekGiftPackPanel.Name, new Dictionary<string, object>());
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
