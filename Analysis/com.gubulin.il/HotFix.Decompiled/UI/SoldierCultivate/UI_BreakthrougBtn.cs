using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_BreakthrougBtn : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://7dantnbionm2g";

	public static string Name = "UI_BreakthrougBtn";

	public static string GetURL()
	{
		return "ui://7dantnbionm2g";
	}

	public static UI_BreakthrougBtn CreateInstance()
	{
		return (UI_BreakthrougBtn)(object)UIPackage.CreateObject("SoldierCultivate", "BreakthrougBtn");
	}

	public static UI_BreakthrougBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BreakthrougBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://7dantnbionm2g".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
