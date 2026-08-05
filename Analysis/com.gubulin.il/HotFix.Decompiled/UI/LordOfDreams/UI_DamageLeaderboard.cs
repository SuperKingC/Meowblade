using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_DamageLeaderboard : GComponent
{
	public Controller PageController;

	public GImage n23;

	public GImage n24;

	public GLoader n3;

	public GImage n20;

	public GTextField n22;

	public GImage n13;

	public GGraph n4;

	public UI_TotalDmgBtn TotalDmgBtn;

	public UI_TodayTopDmgBtn TodayTopDmgBtn;

	public GTextField n21;

	public GTextField n8;

	public GTextField n9;

	public GGraph n10;

	public GList List;

	public GList DamageRewardList;

	public UI_DamageLeaderboardSlot Mine;

	public GImage MineNew;

	public GImage n15;

	public UI_BigBossTopDmgBtn n17;

	public UI_RankingBonusBtn n16;

	public GImage n25;

	public GImage n26;

	public GTextField n27;

	public const string URL = "ui://0i520nzmhyas2l";

	public static string Name = "UI_DamageLeaderboard";

	public static string GetURL()
	{
		return "ui://0i520nzmhyas2l";
	}

	public static UI_DamageLeaderboard CreateInstance()
	{
		return (UI_DamageLeaderboard)(object)UIPackage.CreateObject("LordOfDreams", "DamageLeaderboard");
	}

	public static UI_DamageLeaderboard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageLeaderboard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmhyas2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://0i520nzmhyas2l".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		TotalDmgBtn = (UI_TotalDmgBtn)(object)((GComponent)this).GetChild("TotalDmgBtn");
		TodayTopDmgBtn = (UI_TodayTopDmgBtn)(object)((GComponent)this).GetChild("TodayTopDmgBtn");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://0i520nzmhyas2l".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id3 = "ui://0i520nzmhyas2l".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id3);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://0i520nzmhyas2l".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
		n10 = (GGraph)((GComponent)this).GetChild("n10");
		List = (GList)((GComponent)this).GetChild("List");
		DamageRewardList = (GList)((GComponent)this).GetChild("DamageRewardList");
		Mine = (UI_DamageLeaderboardSlot)(object)((GComponent)this).GetChild("Mine");
		MineNew = (GImage)((GComponent)this).GetChild("MineNew");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n17 = (UI_BigBossTopDmgBtn)(object)((GComponent)this).GetChild("n17");
		n16 = (UI_RankingBonusBtn)(object)((GComponent)this).GetChild("n16");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id5 = "ui://0i520nzmhyas2l".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id5);
	}
}
