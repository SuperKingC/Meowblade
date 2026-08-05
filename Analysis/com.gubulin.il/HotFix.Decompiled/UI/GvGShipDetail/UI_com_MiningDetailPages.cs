using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_MiningDetailPages : GComponent
{
	public Controller State;

	public UI_com_MiningCave MiningCave;

	public GGraph SpineLoader_NoMining;

	public GImage n113;

	public GRichTextField miningDesc;

	public GTextField n115;

	public GTextField n116;

	public GImage n120;

	public GButton CollectBuff;

	public GTextField n122;

	public GTextField MiningEfficiency;

	public GGroup MiningGroup1;

	public GGroup n126;

	public UI_btn_ConfirmToMineBtn ConfirmToMineBtn;

	public UI_btn_ChangeOptionBtn ChangeOptionBtn;

	public GList MineralList;

	public GList MiningMineralList;

	public UI_btn_AllSelect OneClickCheckBox;

	public GButton n117;

	public GImage n128;

	public GTextField n127;

	public GGroup n129;

	public GTextField n130;

	public const string URL = "ui://u6x0b1gnlyij2q";

	public static string Name = "UI_com_MiningDetailPages";

	public static string GetURL()
	{
		return "ui://u6x0b1gnlyij2q";
	}

	public static UI_com_MiningDetailPages CreateInstance()
	{
		return (UI_com_MiningDetailPages)(object)UIPackage.CreateObject("GvGShipDetail", "com_MiningDetailPages");
	}

	public static UI_com_MiningDetailPages CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MiningDetailPages).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnlyij2q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		MiningCave = (UI_com_MiningCave)(object)((GComponent)this).GetChild("MiningCave");
		SpineLoader_NoMining = (GGraph)((GComponent)this).GetChild("SpineLoader_NoMining");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		miningDesc = (GRichTextField)((GComponent)this).GetChild("miningDesc");
		string id = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)miningDesc).id;
		((GObject)miningDesc).text = LanguagesManager.GetDesc(id);
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id2 = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id2);
		n116 = (GTextField)((GComponent)this).GetChild("n116");
		string id3 = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)n116).id;
		((GObject)n116).text = LanguagesManager.GetDesc(id3);
		n120 = (GImage)((GComponent)this).GetChild("n120");
		CollectBuff = (GButton)((GComponent)this).GetChild("CollectBuff");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id4 = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id4);
		MiningEfficiency = (GTextField)((GComponent)this).GetChild("MiningEfficiency");
		MiningGroup1 = (GGroup)((GComponent)this).GetChild("MiningGroup1");
		n126 = (GGroup)((GComponent)this).GetChild("n126");
		ConfirmToMineBtn = (UI_btn_ConfirmToMineBtn)(object)((GComponent)this).GetChild("ConfirmToMineBtn");
		ChangeOptionBtn = (UI_btn_ChangeOptionBtn)(object)((GComponent)this).GetChild("ChangeOptionBtn");
		MineralList = (GList)((GComponent)this).GetChild("MineralList");
		MiningMineralList = (GList)((GComponent)this).GetChild("MiningMineralList");
		OneClickCheckBox = (UI_btn_AllSelect)(object)((GComponent)this).GetChild("OneClickCheckBox");
		n117 = (GButton)((GComponent)this).GetChild("n117");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n127 = (GTextField)((GComponent)this).GetChild("n127");
		string id5 = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)n127).id;
		((GObject)n127).text = LanguagesManager.GetDesc(id5);
		n129 = (GGroup)((GComponent)this).GetChild("n129");
		n130 = (GTextField)((GComponent)this).GetChild("n130");
		string id6 = "ui://u6x0b1gnlyij2q".Replace("ui://", "") + "-" + ((GObject)n130).id;
		((GObject)n130).text = LanguagesManager.GetDesc(id6);
	}
}
