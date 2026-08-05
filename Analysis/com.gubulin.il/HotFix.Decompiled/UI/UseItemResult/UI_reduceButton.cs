using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_reduceButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://800w3r8r9vfjv";

	public static string Name = "UI_reduceButton";

	public static string GetURL()
	{
		return "ui://800w3r8r9vfjv";
	}

	public static UI_reduceButton CreateInstance()
	{
		return (UI_reduceButton)(object)UIPackage.CreateObject("UseItemResult", "reduceButton");
	}

	public static UI_reduceButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_reduceButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8r9vfjv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
