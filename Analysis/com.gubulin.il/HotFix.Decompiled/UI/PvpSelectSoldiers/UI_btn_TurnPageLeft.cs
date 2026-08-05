using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_TurnPageLeft : GButton
{
	public Controller button;

	public Controller Enabled;

	public GImage title;

	public const string URL = "ui://82mo10n5exsyjdqo";

	public static string Name = "UI_btn_TurnPageLeft";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqo";
	}

	public static UI_btn_TurnPageLeft CreateInstance()
	{
		return (UI_btn_TurnPageLeft)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_TurnPageLeft");
	}

	public static UI_btn_TurnPageLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TurnPageLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Enabled = ((GComponent)this).GetController("Enabled");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
