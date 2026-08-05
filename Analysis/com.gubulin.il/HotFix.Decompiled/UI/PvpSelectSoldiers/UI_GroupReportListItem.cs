using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_GroupReportListItem : GButton
{
	public Controller HasMedal;

	public Controller HasHornorTitle;

	public Controller ShowTipBtn;

	public GTextField title;

	public GLoader PlayerItemFrame;

	public UI_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GLoader HonorTitle;

	public GList MedalList;

	public GImage n41;

	public GTextField GroupScore;

	public UI_btn_SimpleTip SimpleTipBtn;

	public GImage n43;

	public GTextField Rate;

	public GImage n45;

	public GTextField RoundScore;

	public UI_btn_BattleReport BattleReportBtn;

	public GGroup n39;

	public const string URL = "ui://82mo10n5hrekjdub";

	public static string Name = "UI_GroupReportListItem";

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdub";
	}

	public static UI_GroupReportListItem CreateInstance()
	{
		return (UI_GroupReportListItem)(object)UIPackage.CreateObject("PvpSelectSoldiers", "GroupReportListItem");
	}

	public static UI_GroupReportListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GroupReportListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdub", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasMedal = ((GComponent)this).GetController("HasMedal");
		HasHornorTitle = ((GComponent)this).GetController("HasHornorTitle");
		ShowTipBtn = ((GComponent)this).GetController("ShowTipBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5hrekjdub".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		HonorTitle = (GLoader)((GComponent)this).GetChild("HonorTitle");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		GroupScore = (GTextField)((GComponent)this).GetChild("GroupScore");
		SimpleTipBtn = (UI_btn_SimpleTip)(object)((GComponent)this).GetChild("SimpleTipBtn");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		Rate = (GTextField)((GComponent)this).GetChild("Rate");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		RoundScore = (GTextField)((GComponent)this).GetChild("RoundScore");
		BattleReportBtn = (UI_btn_BattleReport)(object)((GComponent)this).GetChild("BattleReportBtn");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
	}
}
