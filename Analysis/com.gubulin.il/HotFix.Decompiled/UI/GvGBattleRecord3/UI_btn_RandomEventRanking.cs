using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_RandomEventRanking : GButton
{
	public Controller Rank;

	public Controller Winner;

	public GLoader n13;

	public GImage n14;

	public UI_com_UserAvatarSmall UserIcon;

	public GTextField RankData;

	public GTextField UserName;

	public GLoader n16;

	public GTextField Ranking;

	public GImage n19;

	public GLoader n20;

	public GImage n21;

	public const string URL = "ui://b3fc6085phuh3s";

	public static string Name = "UI_btn_RandomEventRanking";

	public static string GetURL()
	{
		return "ui://b3fc6085phuh3s";
	}

	public static UI_btn_RandomEventRanking CreateInstance()
	{
		return (UI_btn_RandomEventRanking)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_RandomEventRanking");
	}

	public static UI_btn_RandomEventRanking CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RandomEventRanking).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085phuh3s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rank = ((GComponent)this).GetController("Rank");
		Winner = ((GComponent)this).GetController("Winner");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		UserIcon = (UI_com_UserAvatarSmall)(object)((GComponent)this).GetChild("UserIcon");
		RankData = (GTextField)((GComponent)this).GetChild("RankData");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GLoader)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
	}
}
