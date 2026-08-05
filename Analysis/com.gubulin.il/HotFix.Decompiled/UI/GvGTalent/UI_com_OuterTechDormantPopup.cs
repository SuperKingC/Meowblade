using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_OuterTechDormantPopup : GComponent
{
	public GGraph Mask;

	public UI_com_OuterTechDormantDialog Dialog;

	public Transition showTip;

	public const string URL = "ui://4r1llhd8pdsr65";

	public static string Name = "UI_com_OuterTechDormantPopup";

	public static string GetURL()
	{
		return "ui://4r1llhd8pdsr65";
	}

	public static UI_com_OuterTechDormantPopup CreateInstance()
	{
		return (UI_com_OuterTechDormantPopup)(object)UIPackage.CreateObject("GvGTalent", "com_OuterTechDormantPopup");
	}

	public static UI_com_OuterTechDormantPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechDormantPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8pdsr65", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_OuterTechDormantDialog)(object)((GComponent)this).GetChild("Dialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}
}
