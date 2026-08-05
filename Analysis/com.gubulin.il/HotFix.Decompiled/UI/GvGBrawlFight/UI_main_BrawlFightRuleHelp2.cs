using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlFightRuleHelp2 : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BrawlFightRuleHelp2 PreviewUi;

	public Transition t0;

	public const string URL = "ui://hozu168r7sjy8v";

	public static string Name = "UI_main_BrawlFightRuleHelp2";

	public static string GetURL()
	{
		return "ui://hozu168r7sjy8v";
	}

	public static UI_main_BrawlFightRuleHelp2 CreateInstance()
	{
		return (UI_main_BrawlFightRuleHelp2)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlFightRuleHelp2");
	}

	public static UI_main_BrawlFightRuleHelp2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlFightRuleHelp2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r7sjy8v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PreviewUi = (UI_com_BrawlFightRuleHelp2)(object)((GComponent)this).GetChild("PreviewUi");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PreviewUi.Close).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PreviewUi.Close).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
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
