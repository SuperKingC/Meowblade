using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_BigBtn : GButton
{
	public Controller button;

	public GImage icon;

	public GTextField title;

	public const string URL = "ui://hd2s9kukrs2j53";

	public static string Name = "UI_BigBtn";

	public static string GetURL()
	{
		return "ui://hd2s9kukrs2j53";
	}

	public static UI_BigBtn CreateInstance()
	{
		return (UI_BigBtn)(object)UIPackage.CreateObject("GvGWorldMap2", "BigBtn");
	}

	public static UI_BigBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BigBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukrs2j53", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GImage)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://hd2s9kukrs2j53".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
