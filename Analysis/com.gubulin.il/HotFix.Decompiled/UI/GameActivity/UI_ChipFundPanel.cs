using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_ChipFundPanel : GComponent
{
	public Controller PageController;

	public Controller region;

	public GImage n48;

	public GImage n49;

	public GImage n51;

	public GImage n50;

	public GGraph n52;

	public UI_Invest InvestBtn;

	public GList Bonus;

	public GImage n53;

	public GRichTextField priceIcon;

	public GRichTextField investText;

	public GRichTextField price;

	public GGroup priceZhGroup;

	public GRichTextField investTextSea;

	public GRichTextField priceSea;

	public GGroup priceSeaGroup;

	public const string URL = "ui://29q48tv6n4413c";

	public static string Name = "UI_ChipFundPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6n4413c";
	}

	public static UI_ChipFundPanel CreateInstance()
	{
		return (UI_ChipFundPanel)(object)UIPackage.CreateObject("GameActivity", "ChipFundPanel");
	}

	public static UI_ChipFundPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChipFundPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n4413c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
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
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		InvestBtn = (UI_Invest)(object)((GComponent)this).GetChild("InvestBtn");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		priceIcon = (GRichTextField)((GComponent)this).GetChild("priceIcon");
		investText = (GRichTextField)((GComponent)this).GetChild("investText");
		string id = "ui://29q48tv6n4413c".Replace("ui://", "") + "-" + ((GObject)investText).id;
		((GObject)investText).text = LanguagesManager.GetDesc(id);
		price = (GRichTextField)((GComponent)this).GetChild("price");
		priceZhGroup = (GGroup)((GComponent)this).GetChild("priceZhGroup");
		investTextSea = (GRichTextField)((GComponent)this).GetChild("investTextSea");
		string id2 = "ui://29q48tv6n4413c".Replace("ui://", "") + "-" + ((GObject)investTextSea).id;
		((GObject)investTextSea).text = LanguagesManager.GetDesc(id2);
		priceSea = (GRichTextField)((GComponent)this).GetChild("priceSea");
		priceSeaGroup = (GGroup)((GComponent)this).GetChild("priceSeaGroup");
	}
}
