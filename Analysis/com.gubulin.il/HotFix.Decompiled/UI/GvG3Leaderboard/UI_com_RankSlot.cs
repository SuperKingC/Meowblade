using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_RankSlot : GButton
{
	public Controller RankingTopThree;

	public Controller IsMe;

	public Controller RankingType;

	public Controller IsEmpty;

	public Controller button;

	public GLoader n171;

	public GImage n185;

	public GGroup n187;

	public GLoader n172;

	public GTextField Ranking;

	public GComponent ProfileDisplay;

	public GLoader RankingTypeIcon;

	public GTextField RankingData;

	public GTextField n182;

	public GImage n189;

	public GImage n174;

	public GTextField n175;

	public GGroup n183;

	public UI_btn_Info01 DetailInfo;

	public GGroup n186;

	public GImage n190;

	public const string URL = "ui://ylvfgf90uya75j";

	public static string Name = "UI_com_RankSlot";

	public static string GetURL()
	{
		return "ui://ylvfgf90uya75j";
	}

	public static UI_com_RankSlot CreateInstance()
	{
		return (UI_com_RankSlot)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_RankSlot");
	}

	public static UI_com_RankSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RankSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90uya75j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		IsMe = ((GComponent)this).GetController("IsMe");
		RankingType = ((GComponent)this).GetController("RankingType");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		button = ((GComponent)this).GetController("button");
		n171 = (GLoader)((GComponent)this).GetChild("n171");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		n187 = (GGroup)((GComponent)this).GetChild("n187");
		n172 = (GLoader)((GComponent)this).GetChild("n172");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		RankingTypeIcon = (GLoader)((GComponent)this).GetChild("RankingTypeIcon");
		RankingData = (GTextField)((GComponent)this).GetChild("RankingData");
		n182 = (GTextField)((GComponent)this).GetChild("n182");
		string id = "ui://ylvfgf90uya75j".Replace("ui://", "") + "-" + ((GObject)n182).id;
		((GObject)n182).text = LanguagesManager.GetDesc(id);
		n189 = (GImage)((GComponent)this).GetChild("n189");
		n174 = (GImage)((GComponent)this).GetChild("n174");
		n175 = (GTextField)((GComponent)this).GetChild("n175");
		string id2 = "ui://ylvfgf90uya75j".Replace("ui://", "") + "-" + ((GObject)n175).id;
		((GObject)n175).text = LanguagesManager.GetDesc(id2);
		n183 = (GGroup)((GComponent)this).GetChild("n183");
		DetailInfo = (UI_btn_Info01)(object)((GComponent)this).GetChild("DetailInfo");
		n186 = (GGroup)((GComponent)this).GetChild("n186");
		n190 = (GImage)((GComponent)this).GetChild("n190");
	}
}
