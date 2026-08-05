using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3LandOfEternalNight;

public class UI_btn_Location : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title;

	public const string URL = "ui://amuqyzl8uehe12";

	public static string Name = "UI_btn_Location";

	public static string GetURL()
	{
		return "ui://amuqyzl8uehe12";
	}

	public static UI_btn_Location CreateInstance()
	{
		return (UI_btn_Location)(object)UIPackage.CreateObject("GvG3LandOfEternalNight", "btn_Location");
	}

	public static UI_btn_Location CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Location).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://amuqyzl8uehe12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://amuqyzl8uehe12".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
