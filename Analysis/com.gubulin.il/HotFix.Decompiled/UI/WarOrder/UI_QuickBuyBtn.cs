using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_QuickBuyBtn : GButton
{
	public Controller button;

	public GImage n8;

	public GImage n7;

	public const string URL = "ui://ax280w58okbc21";

	public static string Name = "UI_QuickBuyBtn";

	public static string GetURL()
	{
		return "ui://ax280w58okbc21";
	}

	public static UI_QuickBuyBtn CreateInstance()
	{
		return (UI_QuickBuyBtn)(object)UIPackage.CreateObject("WarOrder", "QuickBuyBtn");
	}

	public static UI_QuickBuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickBuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
