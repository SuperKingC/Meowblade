using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LevelOption : GComponent
{
	public Controller stateController;

	public Controller typeController;

	public GImage n4;

	public GTextField levelNameForDifficulty;

	public GList stars;

	public GGroup n8;

	public GTextField levelName;

	public GImage n10;

	public const string URL = "ui://8x5gc8j2ihxkv4v0";

	public static string Name = "UI_com_LevelOption";

	public static string GetURL()
	{
		return "ui://8x5gc8j2ihxkv4v0";
	}

	public static UI_com_LevelOption CreateInstance()
	{
		return (UI_com_LevelOption)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LevelOption");
	}

	public static UI_com_LevelOption CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelOption).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2ihxkv4v0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		stateController = ((GComponent)this).GetController("stateController");
		typeController = ((GComponent)this).GetController("typeController");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		levelNameForDifficulty = (GTextField)((GComponent)this).GetChild("levelNameForDifficulty");
		stars = (GList)((GComponent)this).GetChild("stars");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		levelName = (GTextField)((GComponent)this).GetChild("levelName");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
