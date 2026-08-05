using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_ConfirmFilter : GButton
{
	public Controller button;

	public GImage n10;

	public GTextField title;

	public const string URL = "ui://tt2iq07oj1h832";

	public static string Name = "UI_btn_ConfirmFilter";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h832";
	}

	public static UI_btn_ConfirmFilter CreateInstance()
	{
		return (UI_btn_ConfirmFilter)(object)UIPackage.CreateObject("GvGExchange3", "btn_ConfirmFilter");
	}

	public static UI_btn_ConfirmFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h832", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://tt2iq07oj1h832".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
