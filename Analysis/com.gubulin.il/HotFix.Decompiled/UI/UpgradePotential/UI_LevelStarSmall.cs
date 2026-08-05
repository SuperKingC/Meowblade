using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_LevelStarSmall : GComponent
{
	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://l5ik1uclic7jt88";

	public static string Name = "UI_LevelStarSmall";

	public static string GetURL()
	{
		return "ui://l5ik1uclic7jt88";
	}

	public static UI_LevelStarSmall CreateInstance()
	{
		return (UI_LevelStarSmall)(object)UIPackage.CreateObject("UpgradePotential", "LevelStarSmall");
	}

	public static UI_LevelStarSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelStarSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclic7jt88", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
