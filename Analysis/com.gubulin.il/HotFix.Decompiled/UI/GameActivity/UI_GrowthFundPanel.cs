using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_GrowthFundPanel : GComponent
{
	public Controller PageController;

	public Controller region;

	public GImage n93;

	public GGraph n94;

	public UI_GrowthFundInvest Invest;

	public UI_RechargeAchievementList AchievementList;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GGraph n92;

	public GImage n91;

	public GRichTextField priceIcon;

	public GRichTextField investText;

	public GRichTextField price;

	public GGroup groupCn;

	public GRichTextField investTextSea;

	public GRichTextField priceSea;

	public GGroup groupSea;

	public const string URL = "ui://29q48tv6n4413y";

	public static string Name = "UI_GrowthFundPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6n4413y";
	}

	public static UI_GrowthFundPanel CreateInstance()
	{
		return (UI_GrowthFundPanel)(object)UIPackage.CreateObject("GameActivity", "GrowthFundPanel");
	}

	public static UI_GrowthFundPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GrowthFundPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n4413y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		region = ((GComponent)this).GetController("region");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n94 = (GGraph)((GComponent)this).GetChild("n94");
		Invest = (UI_GrowthFundInvest)(object)((GComponent)this).GetChild("Invest");
		AchievementList = (UI_RechargeAchievementList)(object)((GComponent)this).GetChild("AchievementList");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		n92 = (GGraph)((GComponent)this).GetChild("n92");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		priceIcon = (GRichTextField)((GComponent)this).GetChild("priceIcon");
		investText = (GRichTextField)((GComponent)this).GetChild("investText");
		string id = "ui://29q48tv6n4413y".Replace("ui://", "") + "-" + ((GObject)investText).id;
		((GObject)investText).text = LanguagesManager.GetDesc(id);
		price = (GRichTextField)((GComponent)this).GetChild("price");
		groupCn = (GGroup)((GComponent)this).GetChild("groupCn");
		investTextSea = (GRichTextField)((GComponent)this).GetChild("investTextSea");
		string id2 = "ui://29q48tv6n4413y".Replace("ui://", "") + "-" + ((GObject)investTextSea).id;
		((GObject)investTextSea).text = LanguagesManager.GetDesc(id2);
		priceSea = (GRichTextField)((GComponent)this).GetChild("priceSea");
		groupSea = (GGroup)((GComponent)this).GetChild("groupSea");
	}
}
