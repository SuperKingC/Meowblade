using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_main_BossBreakDownTip : GComponent, IUiController
{
	public GGraph back;

	public UI_com_BossBreakDownTip Tip;

	public const string URL = "ui://4eq8fgd2e71eqb6seq";

	public static string Name = "UI_main_BossBreakDownTip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2e71eqb6seq";
	}

	public static UI_main_BossBreakDownTip CreateInstance()
	{
		return (UI_main_BossBreakDownTip)(object)UIPackage.CreateObject("GvGWorldMap3", "main_BossBreakDownTip");
	}

	public static UI_main_BossBreakDownTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BossBreakDownTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2e71eqb6seq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Tip = (UI_com_BossBreakDownTip)(object)((GComponent)this).GetChild("Tip");
	}

	public static void OpenBossBreakDownTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, null);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
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
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
