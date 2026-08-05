using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_stronghold : GButton
{
	public Controller button;

	public UI_segment line;

	public UI_LevelIcon icon;

	public GGraph aim;

	public const string URL = "ui://c9n2h0ksm7wz98";

	public static string Name = "UI_stronghold";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz98";
	}

	public static UI_stronghold CreateInstance()
	{
		return (UI_stronghold)(object)UIPackage.CreateObject("WorldMap", "stronghold");
	}

	public static UI_stronghold CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_stronghold).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz98", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
