using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_Material0 : GComponent
{
	public GLoader Icon;

	public const string URL = "ui://fvc33k3g7nboh";

	public static string Name = "UI_com_Material0";

	public static string GetURL()
	{
		return "ui://fvc33k3g7nboh";
	}

	public static UI_com_Material0 CreateInstance()
	{
		return (UI_com_Material0)(object)UIPackage.CreateObject("GVGStore", "com_Material0");
	}

	public static UI_com_Material0 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Material0).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nboh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
