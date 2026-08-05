using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_TipBubble : GComponent
{
	public Controller ShipState;

	public Controller SkyPortalState;

	public Controller NewWorkshopState;

	public Controller EnterIZBefore;

	public Controller TechState;

	public Controller SpeedPlanEnabled;

	public Controller SpeedPlanClaimed;

	public GImage n148;

	public GTextField n12;

	public GImage n170;

	public GTextField ShipText;

	public GTextField ShipStateText;

	public UI_com_GoToBuild GoToBuildShipBtn;

	public GImage n171;

	public GTextField n17;

	public GTextField SkyPortalStateText;

	public UI_com_GoToBuild GoToBuildSkyPortalBtn;

	public GImage n172;

	public GTextField n19;

	public GTextField NewWorkshopStateText;

	public UI_com_GoToBuild GoToBuildNewWorkshopBtn;

	public GGroup n175;

	public GImage n176;

	public GTextField n20;

	public GTextField TechStateText;

	public UI_com_GoToArrange GoToOuterTechLottery;

	public GGroup n181;

	public GImage n182;

	public GTextField n183;

	public UI_com_GoToGet GoToSpeedPlanClaim;

	public GTextField SpeedPlanClaimCnt;

	public GGroup n187;

	public GGroup n186;

	public GImage n173;

	public const string URL = "ui://k19peou7sz5k1w";

	public static string Name = "UI_com_TipBubble";

	public static string GetURL()
	{
		return "ui://k19peou7sz5k1w";
	}

	public static UI_com_TipBubble CreateInstance()
	{
		return (UI_com_TipBubble)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_TipBubble");
	}

	public static UI_com_TipBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TipBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7sz5k1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipState = ((GComponent)this).GetController("ShipState");
		SkyPortalState = ((GComponent)this).GetController("SkyPortalState");
		NewWorkshopState = ((GComponent)this).GetController("NewWorkshopState");
		EnterIZBefore = ((GComponent)this).GetController("EnterIZBefore");
		TechState = ((GComponent)this).GetController("TechState");
		SpeedPlanEnabled = ((GComponent)this).GetController("SpeedPlanEnabled");
		SpeedPlanClaimed = ((GComponent)this).GetController("SpeedPlanClaimed");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://k19peou7sz5k1w".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		n170 = (GImage)((GComponent)this).GetChild("n170");
		ShipText = (GTextField)((GComponent)this).GetChild("ShipText");
		ShipStateText = (GTextField)((GComponent)this).GetChild("ShipStateText");
		GoToBuildShipBtn = (UI_com_GoToBuild)(object)((GComponent)this).GetChild("GoToBuildShipBtn");
		n171 = (GImage)((GComponent)this).GetChild("n171");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id2 = "ui://k19peou7sz5k1w".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id2);
		SkyPortalStateText = (GTextField)((GComponent)this).GetChild("SkyPortalStateText");
		GoToBuildSkyPortalBtn = (UI_com_GoToBuild)(object)((GComponent)this).GetChild("GoToBuildSkyPortalBtn");
		n172 = (GImage)((GComponent)this).GetChild("n172");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id3 = "ui://k19peou7sz5k1w".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id3);
		NewWorkshopStateText = (GTextField)((GComponent)this).GetChild("NewWorkshopStateText");
		GoToBuildNewWorkshopBtn = (UI_com_GoToBuild)(object)((GComponent)this).GetChild("GoToBuildNewWorkshopBtn");
		n175 = (GGroup)((GComponent)this).GetChild("n175");
		n176 = (GImage)((GComponent)this).GetChild("n176");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id4 = "ui://k19peou7sz5k1w".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id4);
		TechStateText = (GTextField)((GComponent)this).GetChild("TechStateText");
		GoToOuterTechLottery = (UI_com_GoToArrange)(object)((GComponent)this).GetChild("GoToOuterTechLottery");
		n181 = (GGroup)((GComponent)this).GetChild("n181");
		n182 = (GImage)((GComponent)this).GetChild("n182");
		n183 = (GTextField)((GComponent)this).GetChild("n183");
		string id5 = "ui://k19peou7sz5k1w".Replace("ui://", "") + "-" + ((GObject)n183).id;
		((GObject)n183).text = LanguagesManager.GetDesc(id5);
		GoToSpeedPlanClaim = (UI_com_GoToGet)(object)((GComponent)this).GetChild("GoToSpeedPlanClaim");
		SpeedPlanClaimCnt = (GTextField)((GComponent)this).GetChild("SpeedPlanClaimCnt");
		n187 = (GGroup)((GComponent)this).GetChild("n187");
		n186 = (GGroup)((GComponent)this).GetChild("n186");
		n173 = (GImage)((GComponent)this).GetChild("n173");
	}
}
