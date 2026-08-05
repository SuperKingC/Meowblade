using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_LegionCultivateFundPanel : GComponent
{
	public Controller PageController;

	public Controller region;

	public GImage n63;

	public GImage n70;

	public GImage n55;

	public GImage n53;

	public UI_Invest InvestBtn;

	public GList Bonus;

	public GImage n52;

	public GImage n64;

	public GImage n65;

	public GImage n69;

	public GRichTextField priceIcon;

	public GRichTextField investText;

	public GRichTextField price;

	public GGroup priceZhGroup;

	public GRichTextField investTextSea;

	public GRichTextField priceSea;

	public GGroup priceSeaGroup;

	public const string URL = "ui://29q48tv6962vad";

	public static string Name = "UI_LegionCultivateFundPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6962vad";
	}

	public static UI_LegionCultivateFundPanel CreateInstance()
	{
		return (UI_LegionCultivateFundPanel)(object)UIPackage.CreateObject("GameActivity", "LegionCultivateFundPanel");
	}

	public static UI_LegionCultivateFundPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegionCultivateFundPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6962vad", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		region = ((GComponent)this).GetController("region");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		InvestBtn = (UI_Invest)(object)((GComponent)this).GetChild("InvestBtn");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		priceIcon = (GRichTextField)((GComponent)this).GetChild("priceIcon");
		investText = (GRichTextField)((GComponent)this).GetChild("investText");
		string id = "ui://29q48tv6962vad".Replace("ui://", "") + "-" + ((GObject)investText).id;
		((GObject)investText).text = LanguagesManager.GetDesc(id);
		price = (GRichTextField)((GComponent)this).GetChild("price");
		priceZhGroup = (GGroup)((GComponent)this).GetChild("priceZhGroup");
		investTextSea = (GRichTextField)((GComponent)this).GetChild("investTextSea");
		string id2 = "ui://29q48tv6962vad".Replace("ui://", "") + "-" + ((GObject)investTextSea).id;
		((GObject)investTextSea).text = LanguagesManager.GetDesc(id2);
		priceSea = (GRichTextField)((GComponent)this).GetChild("priceSea");
		priceSeaGroup = (GGroup)((GComponent)this).GetChild("priceSeaGroup");
	}
}
