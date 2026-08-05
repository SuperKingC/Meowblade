using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_ShipAmpSummary : GComponent
{
	public Controller AmpScoreState;

	public Controller AmpCountState;

	public Controller ShipPowerState;

	public GImage n169;

	public UI_btn_SelectedShip SelectedShip;

	public GImage n187;

	public GImage n170;

	public GTextField n171;

	public GTextField n172;

	public GTextField n173;

	public GTextField n175;

	public GTextField ShipPower;

	public GTextField AmpScore;

	public GTextField AmpCount;

	public GTextField AmpCountLimit;

	public UI_com_PropState ShipPowerStateIcon;

	public UI_com_PropState AmpScoreStateIcon;

	public UI_com_PropState AmpCountStateIcon;

	public GList TotalPropList;

	public const string URL = "ui://pwlamcyxoyh61s";

	public static string Name = "UI_com_ShipAmpSummary";

	public static string GetURL()
	{
		return "ui://pwlamcyxoyh61s";
	}

	public static UI_com_ShipAmpSummary CreateInstance()
	{
		return (UI_com_ShipAmpSummary)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_ShipAmpSummary");
	}

	public static UI_com_ShipAmpSummary CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipAmpSummary).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxoyh61s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AmpScoreState = ((GComponent)this).GetController("AmpScoreState");
		AmpCountState = ((GComponent)this).GetController("AmpCountState");
		ShipPowerState = ((GComponent)this).GetController("ShipPowerState");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		SelectedShip = (UI_btn_SelectedShip)(object)((GComponent)this).GetChild("SelectedShip");
		n187 = (GImage)((GComponent)this).GetChild("n187");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n171 = (GTextField)((GComponent)this).GetChild("n171");
		string id = "ui://pwlamcyxoyh61s".Replace("ui://", "") + "-" + ((GObject)n171).id;
		((GObject)n171).text = LanguagesManager.GetDesc(id);
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id2 = "ui://pwlamcyxoyh61s".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id2);
		n173 = (GTextField)((GComponent)this).GetChild("n173");
		string id3 = "ui://pwlamcyxoyh61s".Replace("ui://", "") + "-" + ((GObject)n173).id;
		((GObject)n173).text = LanguagesManager.GetDesc(id3);
		n175 = (GTextField)((GComponent)this).GetChild("n175");
		string id4 = "ui://pwlamcyxoyh61s".Replace("ui://", "") + "-" + ((GObject)n175).id;
		((GObject)n175).text = LanguagesManager.GetDesc(id4);
		ShipPower = (GTextField)((GComponent)this).GetChild("ShipPower");
		AmpScore = (GTextField)((GComponent)this).GetChild("AmpScore");
		AmpCount = (GTextField)((GComponent)this).GetChild("AmpCount");
		AmpCountLimit = (GTextField)((GComponent)this).GetChild("AmpCountLimit");
		ShipPowerStateIcon = (UI_com_PropState)(object)((GComponent)this).GetChild("ShipPowerStateIcon");
		AmpScoreStateIcon = (UI_com_PropState)(object)((GComponent)this).GetChild("AmpScoreStateIcon");
		AmpCountStateIcon = (UI_com_PropState)(object)((GComponent)this).GetChild("AmpCountStateIcon");
		TotalPropList = (GList)((GComponent)this).GetChild("TotalPropList");
	}
}
