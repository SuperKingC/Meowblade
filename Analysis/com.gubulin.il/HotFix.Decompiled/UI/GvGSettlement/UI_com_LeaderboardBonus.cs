using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_LeaderboardBonus : GComponent
{
	public Controller RankingTopThree;

	public Controller RankingType;

	public Controller TitleType;

	public Controller IsEmpty;

	public Controller EmptyState;

	public GImage n139;

	public GImage n154;

	public GImage n157;

	public GImage n156;

	public GLoader RankingTypeIcon;

	public GTextField RankingData;

	public GLoader n150;

	public GTextField Ranking;

	public GGroup n152;

	public GTextField EmptyTip;

	public GTextField n161;

	public GList BonusList;

	public GImage n141;

	public GImage n158;

	public GTextField TypeName0;

	public GTextField TypeName1;

	public const string URL = "ui://91jxdrkanc8fv";

	public static string Name = "UI_com_LeaderboardBonus";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8fv";
	}

	public static UI_com_LeaderboardBonus CreateInstance()
	{
		return (UI_com_LeaderboardBonus)(object)UIPackage.CreateObject("GvGSettlement", "com_LeaderboardBonus");
	}

	public static UI_com_LeaderboardBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LeaderboardBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8fv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		RankingType = ((GComponent)this).GetController("RankingType");
		TitleType = ((GComponent)this).GetController("TitleType");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		EmptyState = ((GComponent)this).GetController("EmptyState");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		RankingTypeIcon = (GLoader)((GComponent)this).GetChild("RankingTypeIcon");
		RankingData = (GTextField)((GComponent)this).GetChild("RankingData");
		n150 = (GLoader)((GComponent)this).GetChild("n150");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n152 = (GGroup)((GComponent)this).GetChild("n152");
		EmptyTip = (GTextField)((GComponent)this).GetChild("EmptyTip");
		string id = "ui://91jxdrkanc8fv".Replace("ui://", "") + "-" + ((GObject)EmptyTip).id;
		((GObject)EmptyTip).text = LanguagesManager.GetDesc(id);
		n161 = (GTextField)((GComponent)this).GetChild("n161");
		string id2 = "ui://91jxdrkanc8fv".Replace("ui://", "") + "-" + ((GObject)n161).id;
		((GObject)n161).text = LanguagesManager.GetDesc(id2);
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		TypeName0 = (GTextField)((GComponent)this).GetChild("TypeName0");
		TypeName1 = (GTextField)((GComponent)this).GetChild("TypeName1");
	}
}
