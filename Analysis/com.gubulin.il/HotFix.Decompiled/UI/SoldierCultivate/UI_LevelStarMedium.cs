using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_LevelStarMedium : GComponent
{
	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://7dantnbigv525p";

	public static string Name = "UI_LevelStarMedium";

	public static string GetURL()
	{
		return "ui://7dantnbigv525p";
	}

	public static UI_LevelStarMedium CreateInstance()
	{
		return (UI_LevelStarMedium)(object)UIPackage.CreateObject("SoldierCultivate", "LevelStarMedium");
	}

	public static UI_LevelStarMedium CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelStarMedium).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbigv525p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
