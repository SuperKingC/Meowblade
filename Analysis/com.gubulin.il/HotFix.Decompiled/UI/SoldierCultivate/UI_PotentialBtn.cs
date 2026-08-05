using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_PotentialBtn : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://7dantnbi108mt7d";

	public static string Name = "UI_PotentialBtn";

	public static string GetURL()
	{
		return "ui://7dantnbi108mt7d";
	}

	public static UI_PotentialBtn CreateInstance()
	{
		return (UI_PotentialBtn)(object)UIPackage.CreateObject("SoldierCultivate", "PotentialBtn");
	}

	public static UI_PotentialBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PotentialBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbi108mt7d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbi108mt7d".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
