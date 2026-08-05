using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_UseBtn : GButton
{
	public Controller button;

	public GImage n7;

	public GTextField title;

	public const string URL = "ui://2eraz3j9jg6433";

	public static string Name = "UI_UseBtn";

	public static string GetURL()
	{
		return "ui://2eraz3j9jg6433";
	}

	public static UI_UseBtn CreateInstance()
	{
		return (UI_UseBtn)(object)UIPackage.CreateObject("LegendItemDungeon", "UseBtn");
	}

	public static UI_UseBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UseBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9jg6433", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://2eraz3j9jg6433".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
