using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_PanelTitle : GComponent
{
	public GImage n0;

	public GLoader name;

	public GLoader icon;

	public GTextField buildingName;

	public const string URL = "ui://kt6rg65oghb6v4r5";

	public static string Name = "UI_PanelTitle";

	public static string GetURL()
	{
		return "ui://kt6rg65oghb6v4r5";
	}

	public static UI_PanelTitle CreateInstance()
	{
		return (UI_PanelTitle)(object)UIPackage.CreateObject("PublicResources", "PanelTitle");
	}

	public static UI_PanelTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PanelTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oghb6v4r5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		name = (GLoader)((GComponent)this).GetChild("name");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		buildingName = (GTextField)((GComponent)this).GetChild("buildingName");
	}
}
