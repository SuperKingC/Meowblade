using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_FloorInfo : GButton
{
	public Controller button;

	public Controller TypeController;

	public GTextField Title;

	public GTextField Tip;

	public GList display;

	public const string URL = "ui://2eraz3j9y9rzk";

	public static string Name = "UI_FloorInfo";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzk";
	}

	public static UI_FloorInfo CreateInstance()
	{
		return (UI_FloorInfo)(object)UIPackage.CreateObject("LegendItemDungeon", "FloorInfo");
	}

	public static UI_FloorInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FloorInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://2eraz3j9y9rzk".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://2eraz3j9y9rzk".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
		display = (GList)((GComponent)this).GetChild("display");
	}
}
