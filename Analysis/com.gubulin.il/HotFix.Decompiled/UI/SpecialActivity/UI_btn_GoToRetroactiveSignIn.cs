using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_btn_GoToRetroactiveSignIn : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://kozswd8hy8cyf4g";

	public static string Name = "UI_btn_GoToRetroactiveSignIn";

	public static string GetURL()
	{
		return "ui://kozswd8hy8cyf4g";
	}

	public static UI_btn_GoToRetroactiveSignIn CreateInstance()
	{
		return (UI_btn_GoToRetroactiveSignIn)(object)UIPackage.CreateObject("SpecialActivity", "btn_GoToRetroactiveSignIn");
	}

	public static UI_btn_GoToRetroactiveSignIn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GoToRetroactiveSignIn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hy8cyf4g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hy8cyf4g".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
