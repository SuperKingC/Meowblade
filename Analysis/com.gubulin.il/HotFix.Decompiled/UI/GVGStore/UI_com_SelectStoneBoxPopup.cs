using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_SelectStoneBoxPopup : GComponent
{
	public GGraph Mask;

	public UI_com_SelectStoneBoxDialog dialog;

	public const string URL = "ui://fvc33k3grlgk31";

	public static string Name = "UI_com_SelectStoneBoxPopup";

	public static string GetURL()
	{
		return "ui://fvc33k3grlgk31";
	}

	public static UI_com_SelectStoneBoxPopup CreateInstance()
	{
		return (UI_com_SelectStoneBoxPopup)(object)UIPackage.CreateObject("GVGStore", "com_SelectStoneBoxPopup");
	}

	public static UI_com_SelectStoneBoxPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectStoneBoxPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3grlgk31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		dialog = (UI_com_SelectStoneBoxDialog)(object)((GComponent)this).GetChild("dialog");
	}
}
