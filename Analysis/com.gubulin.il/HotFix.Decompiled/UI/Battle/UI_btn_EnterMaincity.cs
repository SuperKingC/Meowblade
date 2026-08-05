using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_btn_EnterMaincity : GButton
{
	public Controller button;

	public const string URL = "ui://twlbabicc6kyp5";

	public static string Name = "UI_btn_EnterMaincity";

	public static string GetURL()
	{
		return "ui://twlbabicc6kyp5";
	}

	public static UI_btn_EnterMaincity CreateInstance()
	{
		return (UI_btn_EnterMaincity)(object)UIPackage.CreateObject("Battle", "btn_EnterMaincity");
	}

	public static UI_btn_EnterMaincity CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_EnterMaincity).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicc6kyp5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
