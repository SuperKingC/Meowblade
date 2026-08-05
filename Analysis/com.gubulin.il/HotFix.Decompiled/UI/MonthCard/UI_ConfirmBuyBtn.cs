using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_ConfirmBuyBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n6;

	public const string URL = "ui://4ctl553savmfb";

	public static string Name = "UI_ConfirmBuyBtn";

	public static string GetURL()
	{
		return "ui://4ctl553savmfb";
	}

	public static UI_ConfirmBuyBtn CreateInstance()
	{
		return (UI_ConfirmBuyBtn)(object)UIPackage.CreateObject("MonthCard", "ConfirmBuyBtn");
	}

	public static UI_ConfirmBuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmBuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmfb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
