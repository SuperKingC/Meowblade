using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_NeutralDungeonPanel : GComponent
{
	public UI_NeutralDungeonBack Back;

	public GTextField Desc;

	public GTextField OpenTime;

	public UI_EnterNeutralDungeon EnterNeutralDungeon;

	public const string URL = "ui://kozswd8haxd7f2w";

	public static string Name = "UI_NeutralDungeonPanel";

	public static string GetURL()
	{
		return "ui://kozswd8haxd7f2w";
	}

	public static UI_NeutralDungeonPanel CreateInstance()
	{
		return (UI_NeutralDungeonPanel)(object)UIPackage.CreateObject("SpecialActivity", "NeutralDungeonPanel");
	}

	public static UI_NeutralDungeonPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NeutralDungeonPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8haxd7f2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (UI_NeutralDungeonBack)(object)((GComponent)this).GetChild("Back");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		string id = "ui://kozswd8haxd7f2w".Replace("ui://", "") + "-" + ((GObject)Desc).id;
		((GObject)Desc).text = LanguagesManager.GetDesc(id);
		OpenTime = (GTextField)((GComponent)this).GetChild("OpenTime");
		string id2 = "ui://kozswd8haxd7f2w".Replace("ui://", "") + "-" + ((GObject)OpenTime).id;
		((GObject)OpenTime).text = LanguagesManager.GetDesc(id2);
		EnterNeutralDungeon = (UI_EnterNeutralDungeon)(object)((GComponent)this).GetChild("EnterNeutralDungeon");
	}
}
