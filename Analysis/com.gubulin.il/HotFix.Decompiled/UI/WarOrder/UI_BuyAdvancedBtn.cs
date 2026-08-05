using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_BuyAdvancedBtn : GButton
{
	public Controller button;

	public GImage back;

	public GImage n5;

	public const string URL = "ui://ax280w58i8lw19";

	public static string Name = "UI_BuyAdvancedBtn";

	public static string GetURL()
	{
		return "ui://ax280w58i8lw19";
	}

	public static UI_BuyAdvancedBtn CreateInstance()
	{
		return (UI_BuyAdvancedBtn)(object)UIPackage.CreateObject("WarOrder", "BuyAdvancedBtn");
	}

	public static UI_BuyAdvancedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuyAdvancedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58i8lw19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
