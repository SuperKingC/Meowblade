using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_EnemyBattleInfo : GComponent
{
	public GGraph back;

	public GImage n13;

	public GImage n14;

	public UI_EnemyHPbar UserHp;

	public UI_EnemyHP LegionHp;

	public GImage n16;

	public GTextField ArmyGroupName;

	public UI_RankingListAvatar Avatar;

	public GGraph SfxBack;

	public GList EnemyMedalList;

	public const string URL = "ui://82mo10n5c3gbdcr";

	public static string Name = "UI_EnemyBattleInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcr";
	}

	public static UI_EnemyBattleInfo CreateInstance()
	{
		return (UI_EnemyBattleInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EnemyBattleInfo");
	}

	public static UI_EnemyBattleInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyBattleInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
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
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		UserHp = (UI_EnemyHPbar)(object)((GComponent)this).GetChild("UserHp");
		LegionHp = (UI_EnemyHP)(object)((GComponent)this).GetChild("LegionHp");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		string id = "ui://82mo10n5c3gbdcr".Replace("ui://", "") + "-" + ((GObject)ArmyGroupName).id;
		((GObject)ArmyGroupName).text = LanguagesManager.GetDesc(id);
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		EnemyMedalList = (GList)((GComponent)this).GetChild("EnemyMedalList");
	}
}
