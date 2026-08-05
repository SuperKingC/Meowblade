using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ProgressSettlementBonus : GComponent
{
	public Controller Camp;

	public GImage n0;

	public GImage n36;

	public GImage n30;

	public GImage n13;

	public GImage n14;

	public GImage n12;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GImage n15;

	public GLoader n1;

	public GTextField Title;

	public GImage n31;

	public GTextField n3;

	public GImage n25;

	public GImage n26;

	public GTextField n27;

	public GImage n21;

	public GImage n22;

	public GTextField n23;

	public GList CampBonuses;

	public GList FlagShipBonuses;

	public GTextField n8;

	public UI_btn_CheckFlagShipMissions CheckMissions;

	public UI_btn_Close Close;

	public GImage n29;

	public GImage n32;

	public UI_com_ProgressTitle ProgressTitle;

	public GTextField n37;

	public const string URL = "ui://4eq8fgd2ko68df";

	public static string Name = "UI_com_ProgressSettlementBonus";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ko68df";
	}

	public static UI_com_ProgressSettlementBonus CreateInstance()
	{
		return (UI_com_ProgressSettlementBonus)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ProgressSettlementBonus");
	}

	public static UI_com_ProgressSettlementBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProgressSettlementBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ko68df", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2ko68df".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id2 = "ui://4eq8fgd2ko68df".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id2);
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id3 = "ui://4eq8fgd2ko68df".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id3);
		CampBonuses = (GList)((GComponent)this).GetChild("CampBonuses");
		FlagShipBonuses = (GList)((GComponent)this).GetChild("FlagShipBonuses");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://4eq8fgd2ko68df".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		CheckMissions = (UI_btn_CheckFlagShipMissions)(object)((GComponent)this).GetChild("CheckMissions");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		ProgressTitle = (UI_com_ProgressTitle)(object)((GComponent)this).GetChild("ProgressTitle");
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id5 = "ui://4eq8fgd2ko68df".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id5);
	}
}
