using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_BuyAdvancedBtn : GButton
{
	public Controller button;

	public GImage back;

	public GImage n6;

	public GLoader costIcon;

	public GTextField Cost;

	public GGroup n9;

	public const string URL = "ui://jl0c82y5ibyrx";

	public static string Name = "UI_BuyAdvancedBtn";

	public static string GetURL()
	{
		return "ui://jl0c82y5ibyrx";
	}

	public static UI_BuyAdvancedBtn CreateInstance()
	{
		return (UI_BuyAdvancedBtn)(object)UIPackage.CreateObject("WeekActivity", "BuyAdvancedBtn");
	}

	public static UI_BuyAdvancedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuyAdvancedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5ibyrx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		costIcon = (GLoader)((GComponent)this).GetChild("costIcon");
		Cost = (GTextField)((GComponent)this).GetChild("Cost");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
	}
}
