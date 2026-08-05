using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_RedRockPlateau_1Btn : GButton
{
	public Controller button;

	public UI_segment line;

	public GImage icon;

	public const string URL = "ui://c9n2h0ksnxwgke";

	public static string Name = "UI_RedRockPlateau_1Btn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksnxwgke";
	}

	public static UI_RedRockPlateau_1Btn CreateInstance()
	{
		return (UI_RedRockPlateau_1Btn)(object)UIPackage.CreateObject("WorldMap", "RedRockPlateau_1Btn");
	}

	public static UI_RedRockPlateau_1Btn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RedRockPlateau_1Btn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksnxwgke", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		line = (UI_segment)(object)((GComponent)this).GetChild("line");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
