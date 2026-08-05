using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_Avatar : GButton
{
	public Controller button;

	public GImage n7;

	public UI_HeadPortrait2 HeadPortrait;

	public const string URL = "ui://82mo10n5exsyjdqr";

	public static string Name = "UI_Avatar";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqr";
	}

	public static UI_Avatar CreateInstance()
	{
		return (UI_Avatar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "Avatar");
	}

	public static UI_Avatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Avatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		HeadPortrait = (UI_HeadPortrait2)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
