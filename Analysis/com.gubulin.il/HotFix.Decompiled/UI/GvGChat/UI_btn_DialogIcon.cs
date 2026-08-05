using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_btn_DialogIcon : GComponent
{
	public GImage n0;

	public const string URL = "ui://e3rxkbapy77p1y";

	public static string Name = "UI_btn_DialogIcon";

	public static string GetURL()
	{
		return "ui://e3rxkbapy77p1y";
	}

	public static UI_btn_DialogIcon CreateInstance()
	{
		return (UI_btn_DialogIcon)(object)UIPackage.CreateObject("GvGChat", "btn_DialogIcon");
	}

	public static UI_btn_DialogIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DialogIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapy77p1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
