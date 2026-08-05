using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_LevelStar : GComponent
{
	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://kt6rg65ovv0uea";

	public static string Name = "UI_LevelStar";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uea";
	}

	public static UI_LevelStar CreateInstance()
	{
		return (UI_LevelStar)(object)UIPackage.CreateObject("PublicResources", "LevelStar");
	}

	public static UI_LevelStar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelStar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uea", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
