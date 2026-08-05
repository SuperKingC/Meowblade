using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_CampInfoWindow : GComponent
{
	public Controller InfoPageControll;

	public GGraph mask;

	public GImage tipBack;

	public GGraph n46;

	public GGraph n47;

	public GTextField EnemyCampName;

	public GTextField EnemyCampDescribe;

	public GTextField strongholdIncome;

	public GList CampGainList;

	public GTextField occupiedIncome;

	public GList AwardList;

	public GTextField SpecialReward;

	public GImage iconback;

	public GLoader SpecialRewardFrame;

	public GLoader SpecialRewardIcon;

	public GTextField SpecialRewardName;

	public GTextField SpecialRewardAmount;

	public GGroup enemyInfo;

	public GTextField OurCampName;

	public GTextField OurCampDescribe;

	public GTextField curIncome;

	public GList CurrentTotalGainList;

	public GGroup ourInfo;

	public GButton CloseBtn;

	public GGroup content;

	public Transition showSelf;

	public const string URL = "ui://twlbabicx61yo";

	public static string Name = "UI_CampInfoWindow";

	public static string GetURL()
	{
		return "ui://twlbabicx61yo";
	}

	public static UI_CampInfoWindow CreateInstance()
	{
		return (UI_CampInfoWindow)(object)UIPackage.CreateObject("Battle", "CampInfoWindow");
	}

	public static UI_CampInfoWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampInfoWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicx61yo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		InfoPageControll = ((GComponent)this).GetController("InfoPageControll");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n46 = (GGraph)((GComponent)this).GetChild("n46");
		n47 = (GGraph)((GComponent)this).GetChild("n47");
		EnemyCampName = (GTextField)((GComponent)this).GetChild("EnemyCampName");
		string id = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)EnemyCampName).id;
		((GObject)EnemyCampName).text = LanguagesManager.GetDesc(id);
		EnemyCampDescribe = (GTextField)((GComponent)this).GetChild("EnemyCampDescribe");
		string id2 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)EnemyCampDescribe).id;
		((GObject)EnemyCampDescribe).text = LanguagesManager.GetDesc(id2);
		strongholdIncome = (GTextField)((GComponent)this).GetChild("strongholdIncome");
		string id3 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)strongholdIncome).id;
		((GObject)strongholdIncome).text = LanguagesManager.GetDesc(id3);
		CampGainList = (GList)((GComponent)this).GetChild("CampGainList");
		occupiedIncome = (GTextField)((GComponent)this).GetChild("occupiedIncome");
		string id4 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)occupiedIncome).id;
		((GObject)occupiedIncome).text = LanguagesManager.GetDesc(id4);
		AwardList = (GList)((GComponent)this).GetChild("AwardList");
		SpecialReward = (GTextField)((GComponent)this).GetChild("SpecialReward");
		string id5 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)SpecialReward).id;
		((GObject)SpecialReward).text = LanguagesManager.GetDesc(id5);
		iconback = (GImage)((GComponent)this).GetChild("iconback");
		SpecialRewardFrame = (GLoader)((GComponent)this).GetChild("SpecialRewardFrame");
		SpecialRewardIcon = (GLoader)((GComponent)this).GetChild("SpecialRewardIcon");
		SpecialRewardName = (GTextField)((GComponent)this).GetChild("SpecialRewardName");
		string id6 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)SpecialRewardName).id;
		((GObject)SpecialRewardName).text = LanguagesManager.GetDesc(id6);
		SpecialRewardAmount = (GTextField)((GComponent)this).GetChild("SpecialRewardAmount");
		string id7 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)SpecialRewardAmount).id;
		((GObject)SpecialRewardAmount).text = LanguagesManager.GetDesc(id7);
		enemyInfo = (GGroup)((GComponent)this).GetChild("enemyInfo");
		OurCampName = (GTextField)((GComponent)this).GetChild("OurCampName");
		string id8 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)OurCampName).id;
		((GObject)OurCampName).text = LanguagesManager.GetDesc(id8);
		OurCampDescribe = (GTextField)((GComponent)this).GetChild("OurCampDescribe");
		string id9 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)OurCampDescribe).id;
		((GObject)OurCampDescribe).text = LanguagesManager.GetDesc(id9);
		curIncome = (GTextField)((GComponent)this).GetChild("curIncome");
		string id10 = "ui://twlbabicx61yo".Replace("ui://", "") + "-" + ((GObject)curIncome).id;
		((GObject)curIncome).text = LanguagesManager.GetDesc(id10);
		CurrentTotalGainList = (GList)((GComponent)this).GetChild("CurrentTotalGainList");
		ourInfo = (GGroup)((GComponent)this).GetChild("ourInfo");
		CloseBtn = (GButton)((GComponent)this).GetChild("CloseBtn");
		content = (GGroup)((GComponent)this).GetChild("content");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
