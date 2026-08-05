using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_no : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField title;

	public const string URL = "ui://h09dvkcgnpfy5ltet";

	public static string Name = "UI_btn_no";

	public static string GetURL()
	{
		return "ui://h09dvkcgnpfy5ltet";
	}

	public static UI_btn_no CreateInstance()
	{
		return (UI_btn_no)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_no");
	}

	public static UI_btn_no CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_no).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgnpfy5ltet", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://h09dvkcgnpfy5ltet".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
