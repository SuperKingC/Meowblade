using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_SoldierSelectionBtn : GButton
{
	public Controller button;

	public GImage n124;

	public GImage n125;

	public GComponent AffectedSoldier;

	public GImage n127;

	public const string URL = "ui://tt2iq07ofnl226";

	public static string Name = "UI_btn_SoldierSelectionBtn";

	public static string GetURL()
	{
		return "ui://tt2iq07ofnl226";
	}

	public static UI_btn_SoldierSelectionBtn CreateInstance()
	{
		return (UI_btn_SoldierSelectionBtn)(object)UIPackage.CreateObject("GvGExchange3", "btn_SoldierSelectionBtn");
	}

	public static UI_btn_SoldierSelectionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SoldierSelectionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07ofnl226", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n124 = (GImage)((GComponent)this).GetChild("n124");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		AffectedSoldier = (GComponent)((GComponent)this).GetChild("AffectedSoldier");
		n127 = (GImage)((GComponent)this).GetChild("n127");
	}
}
