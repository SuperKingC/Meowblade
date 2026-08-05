using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_RedeemGiftBtn : GButton
{
	public Controller button;

	public Controller RedeemType;

	public GImage bg_free;

	public GImage back_pay;

	public GImage n6;

	public GImage n9;

	public GImage note;

	public const string URL = "ui://29q48tv6vujs7u";

	public static string Name = "UI_RedeemGiftBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6vujs7u";
	}

	public static UI_RedeemGiftBtn CreateInstance()
	{
		return (UI_RedeemGiftBtn)(object)UIPackage.CreateObject("GameActivity", "RedeemGiftBtn");
	}

	public static UI_RedeemGiftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RedeemGiftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6vujs7u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedeemType = ((GComponent)this).GetController("RedeemType");
		bg_free = (GImage)((GComponent)this).GetChild("bg_free");
		back_pay = (GImage)((GComponent)this).GetChild("back_pay");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
