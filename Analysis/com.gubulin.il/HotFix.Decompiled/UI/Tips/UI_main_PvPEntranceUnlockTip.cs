using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.Tips;

public class UI_main_PvPEntranceUnlockTip : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_PvPEntranceDialog Tip;

	public Transition popup;

	public const string URL = "ui://47lbpgx9pbvcj5ltfr";

	public static string Name = "UI_main_PvPEntranceUnlockTip";

	public static string GetURL()
	{
		return "ui://47lbpgx9pbvcj5ltfr";
	}

	public static UI_main_PvPEntranceUnlockTip CreateInstance()
	{
		return (UI_main_PvPEntranceUnlockTip)(object)UIPackage.CreateObject("Tips", "main_PvPEntranceUnlockTip");
	}

	public static UI_main_PvPEntranceUnlockTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PvPEntranceUnlockTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9pbvcj5ltfr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Tip = (UI_com_PvPEntranceDialog)(object)((GComponent)this).GetChild("Tip");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public static void OpenPvPEntranceUnlockTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, null);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Tip.Close).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Tip.Close).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
	}

	public void OnShow()
	{
		popup.Play();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
