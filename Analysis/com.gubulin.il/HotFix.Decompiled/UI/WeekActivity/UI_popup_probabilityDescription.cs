using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;

namespace UI.WeekActivity;

public class UI_popup_probabilityDescription : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_probabilityDescriptionDialog Content;

	public Transition t0;

	public const string URL = "ui://jl0c82y5oqg02f";

	public static string Name = "UI_popup_probabilityDescription";

	public static string GetURL()
	{
		return "ui://jl0c82y5oqg02f";
	}

	public static UI_popup_probabilityDescription CreateInstance()
	{
		return (UI_popup_probabilityDescription)(object)UIPackage.CreateObject("WeekActivity", "popup_probabilityDescription");
	}

	public static UI_popup_probabilityDescription CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_probabilityDescription).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5oqg02f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Content = (UI_com_probabilityDescriptionDialog)(object)((GComponent)this).GetChild("Content");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		GetWeeklyActivityResponse.SpinWeekType activityType = ActivityManager.SpinWeekActivity.ActivityType;
		Content.Type.SetSelectedIndex((int)activityType);
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

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
