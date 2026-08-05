using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_exitBtn : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://47lbpgx9lm3bj5lteq";

	public static string Name = "UI_exitBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9lm3bj5lteq";
	}

	public static UI_exitBtn CreateInstance()
	{
		return (UI_exitBtn)(object)UIPackage.CreateObject("Tips", "exitBtn");
	}

	public static UI_exitBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_exitBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9lm3bj5lteq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
