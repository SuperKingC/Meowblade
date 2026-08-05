using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ContinueButton : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n6;

	public const string URL = "ui://82mo10n5onsrdbu";

	public static string Name = "UI_ContinueButton";

	public static string GetURL()
	{
		return "ui://82mo10n5onsrdbu";
	}

	public static UI_ContinueButton CreateInstance()
	{
		return (UI_ContinueButton)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ContinueButton");
	}

	public static UI_ContinueButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ContinueButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5onsrdbu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
