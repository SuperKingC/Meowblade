using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_Leaderboard : GComponent
{
	public Controller Type;

	public Controller c1;

	public Controller c2;

	public Controller HasExtraRanking;

	public GImage n83;

	public GImage n84;

	public GImage n85;

	public GImage n87;

	public GImage n88;

	public GImage n89;

	public GImage n90;

	public GList List;

	public GTextField n81;

	public GTextField n82;

	public UI_btn_arrow n86;

	public GTextField n91;

	public GTextField n95;

	public GTextField n92;

	public UI_btn_RankingListSwitch Switch;

	public UI_btn_Help Help;

	public const string URL = "ui://ebc4ciwrl44l1q";

	public static string Name = "UI_com_Leaderboard";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1q";
	}

	public static UI_com_Leaderboard CreateInstance()
	{
		return (UI_com_Leaderboard)(object)UIPackage.CreateObject("GvGOnIsland3", "com_Leaderboard");
	}

	public static UI_com_Leaderboard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Leaderboard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		c1 = ((GComponent)this).GetController("c1");
		c2 = ((GComponent)this).GetController("c2");
		HasExtraRanking = ((GComponent)this).GetController("HasExtraRanking");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		List = (GList)((GComponent)this).GetChild("List");
		n81 = (GTextField)((GComponent)this).GetChild("n81");
		string id = "ui://ebc4ciwrl44l1q".Replace("ui://", "") + "-" + ((GObject)n81).id;
		((GObject)n81).text = LanguagesManager.GetDesc(id);
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id2 = "ui://ebc4ciwrl44l1q".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id2);
		n86 = (UI_btn_arrow)(object)((GComponent)this).GetChild("n86");
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id3 = "ui://ebc4ciwrl44l1q".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id3);
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id4 = "ui://ebc4ciwrl44l1q".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id4);
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id5 = "ui://ebc4ciwrl44l1q".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id5);
		Switch = (UI_btn_RankingListSwitch)(object)((GComponent)this).GetChild("Switch");
		Help = (UI_btn_Help)(object)((GComponent)this).GetChild("Help");
	}
}
