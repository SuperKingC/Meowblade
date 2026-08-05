using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_reduceButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://47lbpgx9otto3f";

	public static string Name = "UI_reduceButton";

	public static string GetURL()
	{
		return "ui://47lbpgx9otto3f";
	}

	public static UI_reduceButton CreateInstance()
	{
		return (UI_reduceButton)(object)UIPackage.CreateObject("Tips", "reduceButton");
	}

	public static UI_reduceButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_reduceButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9otto3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
