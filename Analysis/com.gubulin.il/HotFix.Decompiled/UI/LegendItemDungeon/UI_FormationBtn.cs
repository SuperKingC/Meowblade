using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_FormationBtn : GButton
{
	public Controller button;

	public GLoader formationIcon;

	public GTextField name;

	public GTextField LevelTitle;

	public GTextField Level;

	public GGroup selectPhalanxGropu;

	public const string URL = "ui://2eraz3j9et4r3z";

	public static string Name = "UI_FormationBtn";

	public static string GetURL()
	{
		return "ui://2eraz3j9et4r3z";
	}

	public static UI_FormationBtn CreateInstance()
	{
		return (UI_FormationBtn)(object)UIPackage.CreateObject("LegendItemDungeon", "FormationBtn");
	}

	public static UI_FormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9et4r3z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		formationIcon = (GLoader)((GComponent)this).GetChild("formationIcon");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://2eraz3j9et4r3z".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		LevelTitle = (GTextField)((GComponent)this).GetChild("LevelTitle");
		string id2 = "ui://2eraz3j9et4r3z".Replace("ui://", "") + "-" + ((GObject)LevelTitle).id;
		((GObject)LevelTitle).text = LanguagesManager.GetDesc(id2);
		Level = (GTextField)((GComponent)this).GetChild("Level");
		string id3 = "ui://2eraz3j9et4r3z".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id3);
		selectPhalanxGropu = (GGroup)((GComponent)this).GetChild("selectPhalanxGropu");
	}
}
