using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushGiftBag;

public class UI_ConfirmBuyBtn : GButton
{
	public Controller button;

	public GImage n8;

	public GImage n7;

	public const string URL = "ui://ume49e0adecwe";

	public static string Name = "UI_ConfirmBuyBtn";

	public static string GetURL()
	{
		return "ui://ume49e0adecwe";
	}

	public static UI_ConfirmBuyBtn CreateInstance()
	{
		return (UI_ConfirmBuyBtn)(object)UIPackage.CreateObject("PushGiftBag", "ConfirmBuyBtn");
	}

	public static UI_ConfirmBuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmBuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
