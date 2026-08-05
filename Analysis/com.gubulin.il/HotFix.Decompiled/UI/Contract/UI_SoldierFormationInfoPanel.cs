using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_SoldierFormationInfoPanel : GComponent
{
	public GGraph mask;

	public UI_SoldierFormationInfo Dialog;

	public const string URL = "ui://avplaivd924qt3x";

	public static string Name = "UI_SoldierFormationInfoPanel";

	public static string GetURL()
	{
		return "ui://avplaivd924qt3x";
	}

	public static UI_SoldierFormationInfoPanel CreateInstance()
	{
		return (UI_SoldierFormationInfoPanel)(object)UIPackage.CreateObject("Contract", "SoldierFormationInfoPanel");
	}

	public static UI_SoldierFormationInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierFormationInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivd924qt3x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_SoldierFormationInfo)(object)((GComponent)this).GetChild("Dialog");
	}
}
