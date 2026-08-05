using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_CampaignMyData : GButton
{
	public Controller button;

	public Controller Rank;

	public Controller Winner;

	public GImage mask;

	public GImage n25;

	public GImage n24;

	public GImage n21;

	public GImage n23;

	public GLoader n22;

	public UI_com_UserAvatarSmall UserIcon;

	public GTextField ShipNum;

	public GTextField n2;

	public GTextField TotalScore;

	public GTextField Kill;

	public GTextField Loss;

	public GTextField Occupy;

	public GTextField UserName;

	public GList ShipData;

	public GImage n20;

	public GTextField n14;

	public GLoader n16;

	public GTextField Ranking;

	public GImage n18;

	public GGroup RankGroup;

	public GImage n26;

	public Transition t0;

	public const string URL = "ui://b3fc6085stwvc";

	public static string Name = "UI_btn_CampaignMyData";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvc";
	}

	public static UI_btn_CampaignMyData CreateInstance()
	{
		return (UI_btn_CampaignMyData)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_CampaignMyData");
	}

	public static UI_btn_CampaignMyData CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampaignMyData).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Rank = ((GComponent)this).GetController("Rank");
		Winner = ((GComponent)this).GetController("Winner");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GLoader)((GComponent)this).GetChild("n22");
		UserIcon = (UI_com_UserAvatarSmall)(object)((GComponent)this).GetChild("UserIcon");
		ShipNum = (GTextField)((GComponent)this).GetChild("ShipNum");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://b3fc6085stwvc".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		Occupy = (GTextField)((GComponent)this).GetChild("Occupy");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		ShipData = (GList)((GComponent)this).GetChild("ShipData");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id2 = "ui://b3fc6085stwvc".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id2);
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		RankGroup = (GGroup)((GComponent)this).GetChild("RankGroup");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
