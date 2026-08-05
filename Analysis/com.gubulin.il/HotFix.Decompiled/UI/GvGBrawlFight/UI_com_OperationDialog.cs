using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_OperationDialog : GComponent
{
	public Controller modeType;

	public Controller hasMyShip;

	public Controller campType;

	public Controller State;

	public Controller hasAward;

	public Controller hasCondition;

	public GImage n0;

	public GLoader islandLogo;

	public GGroup n93;

	public GImage n90;

	public GLoader n92;

	public GLoader n91;

	public UI_btn_HelpBtn02 helpBtn;

	public GImage n87;

	public GImage n88;

	public GTextField islandName;

	public GTextField shipCount;

	public GButton enrollBtn;

	public GButton enterBtn;

	public UI_com_01 hasMyShipIcon;

	public UI_dec_03 n94;

	public GLoader campIcon;

	public UI_btn_IslandRecords CheckRecords;

	public UI_com_02 rewardGroup;

	public UI_com_conditionGroup condition;

	public const string URL = "ui://hozu168rnt901d";

	public static string Name = "UI_com_OperationDialog";

	public static string GetURL()
	{
		return "ui://hozu168rnt901d";
	}

	public static UI_com_OperationDialog CreateInstance()
	{
		return (UI_com_OperationDialog)(object)UIPackage.CreateObject("GvGBrawlFight", "com_OperationDialog");
	}

	public static UI_com_OperationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OperationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt901d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		modeType = ((GComponent)this).GetController("modeType");
		hasMyShip = ((GComponent)this).GetController("hasMyShip");
		campType = ((GComponent)this).GetController("campType");
		State = ((GComponent)this).GetController("State");
		hasAward = ((GComponent)this).GetController("hasAward");
		hasCondition = ((GComponent)this).GetController("hasCondition");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		islandLogo = (GLoader)((GComponent)this).GetChild("islandLogo");
		n93 = (GGroup)((GComponent)this).GetChild("n93");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n92 = (GLoader)((GComponent)this).GetChild("n92");
		n91 = (GLoader)((GComponent)this).GetChild("n91");
		helpBtn = (UI_btn_HelpBtn02)(object)((GComponent)this).GetChild("helpBtn");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		islandName = (GTextField)((GComponent)this).GetChild("islandName");
		string id = "ui://hozu168rnt901d".Replace("ui://", "") + "-" + ((GObject)islandName).id;
		((GObject)islandName).text = LanguagesManager.GetDesc(id);
		shipCount = (GTextField)((GComponent)this).GetChild("shipCount");
		string id2 = "ui://hozu168rnt901d".Replace("ui://", "") + "-" + ((GObject)shipCount).id;
		((GObject)shipCount).text = LanguagesManager.GetDesc(id2);
		enrollBtn = (GButton)((GComponent)this).GetChild("enrollBtn");
		enterBtn = (GButton)((GComponent)this).GetChild("enterBtn");
		hasMyShipIcon = (UI_com_01)(object)((GComponent)this).GetChild("hasMyShipIcon");
		n94 = (UI_dec_03)(object)((GComponent)this).GetChild("n94");
		campIcon = (GLoader)((GComponent)this).GetChild("campIcon");
		CheckRecords = (UI_btn_IslandRecords)(object)((GComponent)this).GetChild("CheckRecords");
		rewardGroup = (UI_com_02)(object)((GComponent)this).GetChild("rewardGroup");
		condition = (UI_com_conditionGroup)(object)((GComponent)this).GetChild("condition");
	}
}
