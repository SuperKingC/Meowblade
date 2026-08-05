using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_FormationBtn : GButton
{
	public Controller button;

	public GImage frameLight;

	public GLoader formationIcon;

	public GTextField name;

	public GTextField LevelTitle;

	public GTextField Level;

	public GGroup selectPhalanxGropu;

	public const string URL = "ui://k2sprg26in7b1o";

	public static string Name = "UI_FormationBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1o";
	}

	public static UI_FormationBtn CreateInstance()
	{
		return (UI_FormationBtn)(object)UIPackage.CreateObject("IslandComeAgain", "FormationBtn");
	}

	public static UI_FormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frameLight = (GImage)((GComponent)this).GetChild("frameLight");
		formationIcon = (GLoader)((GComponent)this).GetChild("formationIcon");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://k2sprg26in7b1o".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		LevelTitle = (GTextField)((GComponent)this).GetChild("LevelTitle");
		string id2 = "ui://k2sprg26in7b1o".Replace("ui://", "") + "-" + ((GObject)LevelTitle).id;
		((GObject)LevelTitle).text = LanguagesManager.GetDesc(id2);
		Level = (GTextField)((GComponent)this).GetChild("Level");
		string id3 = "ui://k2sprg26in7b1o".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id3);
		selectPhalanxGropu = (GGroup)((GComponent)this).GetChild("selectPhalanxGropu");
	}
}
