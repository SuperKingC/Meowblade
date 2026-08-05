using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpTotalRankInfo : GComponent
{
	public Controller SelfType;

	public GImage n29;

	public UI_RankingListAvatar Avatar;

	public GTextField UserName;

	public GImage n17;

	public GTextField CombatPower;

	public GTextField ScoreBonus;

	public UI_RankListLevelDiy Rank;

	public GTextField Layer;

	public GTextField n31;

	public GTextField n32;

	public const string URL = "ui://82mo10n5lt7m9u";

	public static string Name = "UI_PvpTotalRankInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9u";
	}

	public static UI_PvpTotalRankInfo CreateInstance()
	{
		return (UI_PvpTotalRankInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpTotalRankInfo");
	}

	public static UI_PvpTotalRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpTotalRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelfType = ((GComponent)this).GetController("SelfType");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		ScoreBonus = (GTextField)((GComponent)this).GetChild("ScoreBonus");
		Rank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("Rank");
		Layer = (GTextField)((GComponent)this).GetChild("Layer");
		string id = "ui://82mo10n5lt7m9u".Replace("ui://", "") + "-" + ((GObject)Layer).id;
		((GObject)Layer).text = LanguagesManager.GetDesc(id);
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id2 = "ui://82mo10n5lt7m9u".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id2);
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id3 = "ui://82mo10n5lt7m9u".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id3);
	}
}
