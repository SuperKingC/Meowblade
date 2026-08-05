using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_FrigidMountainsStronghold : GButton
{
	public Controller button;

	public UI_segment line;

	public UI_LevelIcon icon;

	public GGraph aim;

	public const string URL = "ui://c9n2h0ksm7wz9b";

	public static string Name = "UI_FrigidMountainsStronghold";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9b";
	}

	public static UI_FrigidMountainsStronghold CreateInstance()
	{
		return (UI_FrigidMountainsStronghold)(object)UIPackage.CreateObject("WorldMap", "FrigidMountainsStronghold");
	}

	public static UI_FrigidMountainsStronghold CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FrigidMountainsStronghold).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		line = (UI_segment)(object)((GComponent)this).GetChild("line");
		icon = (UI_LevelIcon)(object)((GComponent)this).GetChild("icon");
		aim = (GGraph)((GComponent)this).GetChild("aim");
	}
}
