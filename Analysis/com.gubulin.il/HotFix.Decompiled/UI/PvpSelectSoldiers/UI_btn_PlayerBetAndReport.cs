using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_PlayerBetAndReport : GButton
{
	public Controller Usage;

	public Controller HasMedal;

	public Controller HasHornorTitle;

	public Controller ShowMode;

	public Controller HasBet;

	public Controller IsBingo;

	public GLoader PlayerItemFrame;

	public GLoader RankTop3Deco;

	public UI_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GLoader HonorTitle;

	public GList MedalList;

	public GImage BattleReportIcon;

	public UI_BingoIcon BingoIcon;

	public GImage n42;

	public GImage n43;

	public GLoader ItemIcon;

	public GTextField ItemCountText;

	public GImage n46;

	public GGroup BetGroup;

	public GGroup n39;

	public const string URL = "ui://82mo10n5ielxjdsv";

	public static string Name = "UI_btn_PlayerBetAndReport";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdsv";
	}

	public static UI_btn_PlayerBetAndReport CreateInstance()
	{
		return (UI_btn_PlayerBetAndReport)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_PlayerBetAndReport");
	}

	public static UI_btn_PlayerBetAndReport CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PlayerBetAndReport).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdsv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Usage = ((GComponent)this).GetController("Usage");
		HasMedal = ((GComponent)this).GetController("HasMedal");
		HasHornorTitle = ((GComponent)this).GetController("HasHornorTitle");
		ShowMode = ((GComponent)this).GetController("ShowMode");
		HasBet = ((GComponent)this).GetController("HasBet");
		IsBingo = ((GComponent)this).GetController("IsBingo");
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		RankTop3Deco = (GLoader)((GComponent)this).GetChild("RankTop3Deco");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		HonorTitle = (GLoader)((GComponent)this).GetChild("HonorTitle");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		BattleReportIcon = (GImage)((GComponent)this).GetChild("BattleReportIcon");
		BingoIcon = (UI_BingoIcon)(object)((GComponent)this).GetChild("BingoIcon");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		ItemCountText = (GTextField)((GComponent)this).GetChild("ItemCountText");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		BetGroup = (GGroup)((GComponent)this).GetChild("BetGroup");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
	}
}
