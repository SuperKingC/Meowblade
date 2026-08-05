using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_yes : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField title;

	public const string URL = "ui://lzvt5p2vi09ea";

	public static string Name = "UI_yes";

	public static string GetURL()
	{
		return "ui://lzvt5p2vi09ea";
	}

	public static UI_yes CreateInstance()
	{
		return (UI_yes)(object)UIPackage.CreateObject("LegendItemInfo", "yes");
	}

	public static UI_yes CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_yes).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vi09ea", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://lzvt5p2vi09ea".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
