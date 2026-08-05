using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipLaunch;

public class UI_com_IslandList : GComponent
{
	public GGraph n0;

	public UI_btn_SelectLaunchIsland Confirm;

	public GList IslandList;

	public const string URL = "ui://tc205cu3fgyl3";

	public static string Name = "UI_com_IslandList";

	public static string GetURL()
	{
		return "ui://tc205cu3fgyl3";
	}

	public static UI_com_IslandList CreateInstance()
	{
		return (UI_com_IslandList)(object)UIPackage.CreateObject("GvGShipLaunch", "com_IslandList");
	}

	public static UI_com_IslandList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		Confirm = (UI_btn_SelectLaunchIsland)(object)((GComponent)this).GetChild("Confirm");
		IslandList = (GList)((GComponent)this).GetChild("IslandList");
	}
}
