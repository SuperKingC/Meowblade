using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_RefillFoodBtn : GButton
{
	public Controller State;

	public GImage RefillFoodBtn;

	public GImage n92;

	public GImage n93;

	public const string URL = "ui://u6x0b1gndxsb25";

	public static string Name = "UI_btn_RefillFoodBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gndxsb25";
	}

	public static UI_btn_RefillFoodBtn CreateInstance()
	{
		return (UI_btn_RefillFoodBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_RefillFoodBtn");
	}

	public static UI_btn_RefillFoodBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RefillFoodBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gndxsb25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		RefillFoodBtn = (GImage)((GComponent)this).GetChild("RefillFoodBtn");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n93 = (GImage)((GComponent)this).GetChild("n93");
	}
}
