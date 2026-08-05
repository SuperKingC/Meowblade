using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_Abatis : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://kqd1t06on4411p";

	public static string Name = "UI_Abatis";

	public static string GetURL()
	{
		return "ui://kqd1t06on4411p";
	}

	public static UI_Abatis CreateInstance()
	{
		return (UI_Abatis)(object)UIPackage.CreateObject("QuickBattle", "Abatis");
	}

	public static UI_Abatis CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Abatis).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06on4411p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
