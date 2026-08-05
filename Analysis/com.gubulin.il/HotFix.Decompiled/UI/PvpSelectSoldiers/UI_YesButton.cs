using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_YesButton : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n5;

	public const string URL = "ui://82mo10n5qxbi7k";

	public static string Name = "UI_YesButton";

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi7k";
	}

	public static UI_YesButton CreateInstance()
	{
		return (UI_YesButton)(object)UIPackage.CreateObject("PvpSelectSoldiers", "YesButton");
	}

	public static UI_YesButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_YesButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi7k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
