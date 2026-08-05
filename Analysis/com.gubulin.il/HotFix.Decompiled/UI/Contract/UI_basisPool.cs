using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_basisPool : GComponent
{
	public Controller CardType;

	public Controller StatusController;

	public Controller showGoldTip;

	public GImage n0;

	public GImage n27;

	public GImage n39;

	public GImage n38;

	public GImage n37;

	public GImage n54;

	public GImage n53;

	public GImage n62;

	public GImage n63;

	public GImage n42;

	public UI_QualifiedSoldierIconUp QualifiedSoldierIconUp;

	public UI_QualifiedSoldierIconMiddle QualifiedSoldierIconMiddle;

	public GImage n55;

	public GImage n41;

	public UI_QualifiedSoldierIconDown QualifiedSoldierIconDown;

	public GImage n56;

	public GImage n28;

	public GImage n22;

	public GImage n35;

	public GImage n34;

	public GImage n52;

	public GImage n65;

	public GImage n61;

	public UI_singleBtn singleBtn;

	public UI_runningBtn runningBtn;

	public GLoader singleTicketIcon;

	public GTextField singleCost;

	public GLoader runningTicketIcon;

	public GTextField runningCost;

	public GImage n57;

	public GTextField time;

	public GGroup timeGroup;

	public GImage n40;

	public GTextField drawCount;

	public UI_CheckProbabilityBtn CheckProbabilityBtn;

	public UI_ScoreProgress ScoreProgress;

	public GTextField n58;

	public UI_com_01 goldCardTip;

	public GButton Help;

	public const string URL = "ui://avplaivdic7jt3m";

	public static string Name = "UI_basisPool";

	public static string GetURL()
	{
		return "ui://avplaivdic7jt3m";
	}

	public static UI_basisPool CreateInstance()
	{
		return (UI_basisPool)(object)UIPackage.CreateObject("Contract", "basisPool");
	}

	public static UI_basisPool CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_basisPool).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdic7jt3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CardType = ((GComponent)this).GetController("CardType");
		StatusController = ((GComponent)this).GetController("StatusController");
		showGoldTip = ((GComponent)this).GetController("showGoldTip");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		QualifiedSoldierIconUp = (UI_QualifiedSoldierIconUp)(object)((GComponent)this).GetChild("QualifiedSoldierIconUp");
		QualifiedSoldierIconMiddle = (UI_QualifiedSoldierIconMiddle)(object)((GComponent)this).GetChild("QualifiedSoldierIconMiddle");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		QualifiedSoldierIconDown = (UI_QualifiedSoldierIconDown)(object)((GComponent)this).GetChild("QualifiedSoldierIconDown");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		singleBtn = (UI_singleBtn)(object)((GComponent)this).GetChild("singleBtn");
		runningBtn = (UI_runningBtn)(object)((GComponent)this).GetChild("runningBtn");
		singleTicketIcon = (GLoader)((GComponent)this).GetChild("singleTicketIcon");
		singleCost = (GTextField)((GComponent)this).GetChild("singleCost");
		string id = "ui://avplaivdic7jt3m".Replace("ui://", "") + "-" + ((GObject)singleCost).id;
		((GObject)singleCost).text = LanguagesManager.GetDesc(id);
		runningTicketIcon = (GLoader)((GComponent)this).GetChild("runningTicketIcon");
		runningCost = (GTextField)((GComponent)this).GetChild("runningCost");
		string id2 = "ui://avplaivdic7jt3m".Replace("ui://", "") + "-" + ((GObject)runningCost).id;
		((GObject)runningCost).text = LanguagesManager.GetDesc(id2);
		n57 = (GImage)((GComponent)this).GetChild("n57");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id3 = "ui://avplaivdic7jt3m".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id3);
		timeGroup = (GGroup)((GComponent)this).GetChild("timeGroup");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		drawCount = (GTextField)((GComponent)this).GetChild("drawCount");
		string id4 = "ui://avplaivdic7jt3m".Replace("ui://", "") + "-" + ((GObject)drawCount).id;
		((GObject)drawCount).text = LanguagesManager.GetDesc(id4);
		CheckProbabilityBtn = (UI_CheckProbabilityBtn)(object)((GComponent)this).GetChild("CheckProbabilityBtn");
		ScoreProgress = (UI_ScoreProgress)(object)((GComponent)this).GetChild("ScoreProgress");
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id5 = "ui://avplaivdic7jt3m".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id5);
		goldCardTip = (UI_com_01)(object)((GComponent)this).GetChild("goldCardTip");
		Help = (GButton)((GComponent)this).GetChild("Help");
	}

	public void SetControllerPageText()
	{
		if (CardType.selectedIndex == 0 || CardType.selectedIndex == 5)
		{
			string id = string.Format("{0}-{1}-{2}", "ui://avplaivdic7jt3m".Replace("ui://", ""), ((GObject)n58).id, CardType.selectedIndex);
			((GObject)n58).text = LanguagesManager.GetDesc(id);
		}
	}
}
