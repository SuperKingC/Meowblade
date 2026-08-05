using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_LevelStarSmall : GComponent
{
	public GImage n3;

	public GLoader loader;

	public const string URL = "ui://72fujxhkpipja";

	public static string Name = "UI_LevelStarSmall";

	public static string GetURL()
	{
		return "ui://72fujxhkpipja";
	}

	public static UI_LevelStarSmall CreateInstance()
	{
		return (UI_LevelStarSmall)(object)UIPackage.CreateObject("RecruitingCamp", "LevelStarSmall");
	}

	public static UI_LevelStarSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelStarSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkpipja", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		loader = (GLoader)((GComponent)this).GetChild("loader");
	}
}
