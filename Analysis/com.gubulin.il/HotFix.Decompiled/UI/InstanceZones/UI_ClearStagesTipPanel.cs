using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ClearStagesTipPanel : GComponent
{
	public GGraph mask;

	public UI_ClearStagesTipDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://f4wr270rqfz85b";

	public static string Name = "UI_ClearStagesTipPanel";

	public static string GetURL()
	{
		return "ui://f4wr270rqfz85b";
	}

	public static UI_ClearStagesTipPanel CreateInstance()
	{
		return (UI_ClearStagesTipPanel)(object)UIPackage.CreateObject("InstanceZones", "ClearStagesTipPanel");
	}

	public static UI_ClearStagesTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearStagesTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rqfz85b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ClearStagesTipDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
