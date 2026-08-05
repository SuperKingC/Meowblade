using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BackBtn : GButton
{
	public Controller button;

	public GImage icon;

	public GImage arrow;

	public const string URL = "ui://82mo10n5ch138l";

	public static string Name = "UI_BackBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5ch138l";
	}

	public static UI_BackBtn CreateInstance()
	{
		return (UI_BackBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BackBtn");
	}

	public static UI_BackBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BackBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ch138l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GImage)((GComponent)this).GetChild("icon");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
	}
}
