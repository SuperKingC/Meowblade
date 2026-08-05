using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlEventSettleInfo : GComponent
{
	public Controller IsFinal;

	public GImage back;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public UI_btn_BattleResultIsland Island;

	public UI_btn_BattleScore UserScore;

	public UI_btn_BattleScore CampScore;

	public UI_btn_BonusWrapper SelfContribution;

	public UI_btn_BonusWrapper SelfBonus;

	public UI_btn_BonusWrapper SelfExtraBonus;

	public UI_btn_BonusWrapper CampBonus;

	public UI_btn_BonusWrapper CampExtraBonus;

	public UI_btn_BonusWrapper FinalBonus;

	public UI_btn_GotoIslandRecord GotoIslandRecord;

	public const string URL = "ui://hozu168rk7me4y";

	public static string Name = "UI_com_BrawlEventSettleInfo";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4y";
	}

	public static UI_com_BrawlEventSettleInfo CreateInstance()
	{
		return (UI_com_BrawlEventSettleInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlEventSettleInfo");
	}

	public static UI_com_BrawlEventSettleInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlEventSettleInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFinal = ((GComponent)this).GetController("IsFinal");
		back = (GImage)((GComponent)this).GetChild("back");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Island = (UI_btn_BattleResultIsland)(object)((GComponent)this).GetChild("Island");
		UserScore = (UI_btn_BattleScore)(object)((GComponent)this).GetChild("UserScore");
		CampScore = (UI_btn_BattleScore)(object)((GComponent)this).GetChild("CampScore");
		SelfContribution = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("SelfContribution");
		SelfBonus = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("SelfBonus");
		SelfExtraBonus = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("SelfExtraBonus");
		CampBonus = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("CampBonus");
		CampExtraBonus = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("CampExtraBonus");
		FinalBonus = (UI_btn_BonusWrapper)(object)((GComponent)this).GetChild("FinalBonus");
		GotoIslandRecord = (UI_btn_GotoIslandRecord)(object)((GComponent)this).GetChild("GotoIslandRecord");
	}
}
