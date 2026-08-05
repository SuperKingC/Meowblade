using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleLogInfoResources : GComponent
{
	public Controller Type;

	public Controller Status;

	public Controller AttackAndDefense;

	public Controller Attaches;

	public Controller isShowMedalLeft;

	public Controller isShowMedalRight;

	public GImage n22;

	public GTextField Day;

	public GImage n23;

	public GImage n24;

	public GGraph n52;

	public GGroup n25;

	public GImage n26;

	public GImage n27;

	public UI_RankingListAvatar MyAvatar;

	public GTextField EnemyName;

	public GTextField MyName;

	public UI_RankListLevelDiy MyRank;

	public UI_PlayBtn PlayBtn;

	public UI_RankingListAvatar EnemyAvatar;

	public UI_RankListLevelDiy EnemyRank;

	public GImage n30;

	public GImage n32;

	public GImage n35;

	public GGroup n38;

	public GImage n31;

	public GImage n33;

	public GImage n34;

	public GGroup n39;

	public GList LeftMedalList;

	public GList RightMedalList;

	public GGroup n37;

	public GGraph back;

	public UI_OurHPbar RedUserHp;

	public GGroup RedUserHpBar;

	public GGraph back_2;

	public UI_EnemyHPbar BlueUserHp;

	public GGroup BlueUserHpBar;

	public UI_ShowLevelChange LevelChangeContent;

	public const string URL = "ui://82mo10n5dv2sday";

	public static string Name = "UI_PvpBattleLogInfoResources";

	public static string GetURL()
	{
		return "ui://82mo10n5dv2sday";
	}

	public static UI_PvpBattleLogInfoResources CreateInstance()
	{
		return (UI_PvpBattleLogInfoResources)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleLogInfoResources");
	}

	public static UI_PvpBattleLogInfoResources CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleLogInfoResources).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5dv2sday", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Status = ((GComponent)this).GetController("Status");
		AttackAndDefense = ((GComponent)this).GetController("AttackAndDefense");
		Attaches = ((GComponent)this).GetController("Attaches");
		isShowMedalLeft = ((GComponent)this).GetController("isShowMedalLeft");
		isShowMedalRight = ((GComponent)this).GetController("isShowMedalRight");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		Day = (GTextField)((GComponent)this).GetChild("Day");
		string id = "ui://82mo10n5dv2sday".Replace("ui://", "") + "-" + ((GObject)Day).id;
		((GObject)Day).text = LanguagesManager.GetDesc(id);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		MyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("MyAvatar");
		EnemyName = (GTextField)((GComponent)this).GetChild("EnemyName");
		MyName = (GTextField)((GComponent)this).GetChild("MyName");
		MyRank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("MyRank");
		PlayBtn = (UI_PlayBtn)(object)((GComponent)this).GetChild("PlayBtn");
		EnemyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("EnemyAvatar");
		EnemyRank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("EnemyRank");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		LeftMedalList = (GList)((GComponent)this).GetChild("LeftMedalList");
		RightMedalList = (GList)((GComponent)this).GetChild("RightMedalList");
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		back = (GGraph)((GComponent)this).GetChild("back");
		RedUserHp = (UI_OurHPbar)(object)((GComponent)this).GetChild("RedUserHp");
		RedUserHpBar = (GGroup)((GComponent)this).GetChild("RedUserHpBar");
		back_2 = (GGraph)((GComponent)this).GetChild("back");
		BlueUserHp = (UI_EnemyHPbar)(object)((GComponent)this).GetChild("BlueUserHp");
		BlueUserHpBar = (GGroup)((GComponent)this).GetChild("BlueUserHpBar");
		LevelChangeContent = (UI_ShowLevelChange)(object)((GComponent)this).GetChild("LevelChangeContent");
	}
}
