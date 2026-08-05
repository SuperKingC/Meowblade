using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ScoreBonusNode : GComponent
{
	public Controller CardState;

	public GImage n22;

	public GImage n38;

	public UI_eff_Lightray n27;

	public GTextField CardRewardName;

	public GImage n23;

	public GTextField n33;

	public GTextField LimitBuyCurrent;

	public GTextField n35;

	public GTextField LimitBuyTotal;

	public GGroup LimitBuyGroup;

	public GTextField CardRewardPrice;

	public GLoader CurrencyIcon;

	public GGroup CardRewardPriceGroup;

	public GButton GetExtraReward;

	public GButton GetFreeReward;

	public GMovieClip BonusHaloFX;

	public GLoader CardRewardIcon;

	public GGraph n57;

	public GImage n55;

	public GImage n56;

	public GImage n17;

	public GLoader CardDemandScoreIcon;

	public GTextField CardDemandScore;

	public GComponent DiscountIcon;

	public GGroup NodeGroup;

	public const string URL = "ui://82mo10n5en8gjdv7";

	public static string Name = "UI_ScoreBonusNode";

	public static string GetURL()
	{
		return "ui://82mo10n5en8gjdv7";
	}

	public static UI_ScoreBonusNode CreateInstance()
	{
		return (UI_ScoreBonusNode)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ScoreBonusNode");
	}

	public static UI_ScoreBonusNode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBonusNode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5en8gjdv7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CardState = ((GComponent)this).GetController("CardState");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n27 = (UI_eff_Lightray)(object)((GComponent)this).GetChild("n27");
		CardRewardName = (GTextField)((GComponent)this).GetChild("CardRewardName");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id = "ui://82mo10n5en8gjdv7".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id);
		LimitBuyCurrent = (GTextField)((GComponent)this).GetChild("LimitBuyCurrent");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		LimitBuyTotal = (GTextField)((GComponent)this).GetChild("LimitBuyTotal");
		LimitBuyGroup = (GGroup)((GComponent)this).GetChild("LimitBuyGroup");
		CardRewardPrice = (GTextField)((GComponent)this).GetChild("CardRewardPrice");
		CurrencyIcon = (GLoader)((GComponent)this).GetChild("CurrencyIcon");
		CardRewardPriceGroup = (GGroup)((GComponent)this).GetChild("CardRewardPriceGroup");
		GetExtraReward = (GButton)((GComponent)this).GetChild("GetExtraReward");
		GetFreeReward = (GButton)((GComponent)this).GetChild("GetFreeReward");
		BonusHaloFX = (GMovieClip)((GComponent)this).GetChild("BonusHaloFX");
		CardRewardIcon = (GLoader)((GComponent)this).GetChild("CardRewardIcon");
		n57 = (GGraph)((GComponent)this).GetChild("n57");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		CardDemandScoreIcon = (GLoader)((GComponent)this).GetChild("CardDemandScoreIcon");
		CardDemandScore = (GTextField)((GComponent)this).GetChild("CardDemandScore");
		DiscountIcon = (GComponent)((GComponent)this).GetChild("DiscountIcon");
		NodeGroup = (GGroup)((GComponent)this).GetChild("NodeGroup");
	}
}
