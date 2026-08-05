using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_DailyMissionTip : GComponent, IUiController
{
	public GGraph mask;

	public UI_DailyMissionTipDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://k2sprg26ke8pah";

	public static string Name = "UI_DailyMissionTip";

	public static string GetURL()
	{
		return "ui://k2sprg26ke8pah";
	}

	public static UI_DailyMissionTip CreateInstance()
	{
		return (UI_DailyMissionTip)(object)UIPackage.CreateObject("IslandComeAgain", "DailyMissionTip");
	}

	public static UI_DailyMissionTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailyMissionTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26ke8pah", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_DailyMissionTipDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
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

	public void RefreshPanel()
	{
		ShowDialog.Play();
		Dialog.RefreshPanel();
	}
}
