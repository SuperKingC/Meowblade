using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_UserBattleInfo : GComponent
{
	public GGraph back;

	public GImage n11;

	public UI_OurHPbar UserHp;

	public GImage n12;

	public UI_UserHPbar LegionHp;

	public GImage n10;

	public GTextField ArmyGroupName;

	public UI_RankingListAvatar Avatar;

	public GGraph SfxBack;

	public GList OurMedalList;

	public const string URL = "ui://82mo10n5c3gbdco";

	public static string Name = "UI_UserBattleInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdco";
	}

	public static UI_UserBattleInfo CreateInstance()
	{
		return (UI_UserBattleInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "UserBattleInfo");
	}

	public static UI_UserBattleInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserBattleInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdco", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		UserHp = (UI_OurHPbar)(object)((GComponent)this).GetChild("UserHp");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		LegionHp = (UI_UserHPbar)(object)((GComponent)this).GetChild("LegionHp");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		string id = "ui://82mo10n5c3gbdco".Replace("ui://", "") + "-" + ((GObject)ArmyGroupName).id;
		((GObject)ArmyGroupName).text = LanguagesManager.GetDesc(id);
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		OurMedalList = (GList)((GComponent)this).GetChild("OurMedalList");
	}
}
