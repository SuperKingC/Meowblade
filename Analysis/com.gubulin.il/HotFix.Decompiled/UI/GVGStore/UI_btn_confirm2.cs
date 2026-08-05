using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_confirm2 : GButton
{
	public Controller button;

	public GImage n10;

	public GTextField title;

	public const string URL = "ui://fvc33k3gjsiic";

	public static string Name = "UI_btn_confirm2";

	public static string GetURL()
	{
		return "ui://fvc33k3gjsiic";
	}

	public static UI_btn_confirm2 CreateInstance()
	{
		return (UI_btn_confirm2)(object)UIPackage.CreateObject("GVGStore", "btn_confirm2");
	}

	public static UI_btn_confirm2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_confirm2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsiic", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n10 = (GImage)((GComponent)this).GetChild("n10");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://fvc33k3gjsiic".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
