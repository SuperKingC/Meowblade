using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_RarityTab : GButton
{
	public Controller Rarity;

	public Controller button;

	public UI_dec_QualityTabFrame QualityTabFrame;

	public GImage n105;

	public GImage n103;

	public GImage n104;

	public UI_QualityIcon QualityIcon;

	public GTextField n98;

	public GTextField n99;

	public GTextField n100;

	public GTextField n101;

	public GTextField n102;

	public GImage RedDot;

	public const string URL = "ui://tt2iq07oj1h83g";

	public static string Name = "UI_btn_RarityTab";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h83g";
	}

	public static UI_btn_RarityTab CreateInstance()
	{
		return (UI_btn_RarityTab)(object)UIPackage.CreateObject("GvGExchange3", "btn_RarityTab");
	}

	public static UI_btn_RarityTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RarityTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h83g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		button = ((GComponent)this).GetController("button");
		QualityTabFrame = (UI_dec_QualityTabFrame)(object)((GComponent)this).GetChild("QualityTabFrame");
		n105 = (GImage)((GComponent)this).GetChild("n105");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		n104 = (GImage)((GComponent)this).GetChild("n104");
		QualityIcon = (UI_QualityIcon)(object)((GComponent)this).GetChild("QualityIcon");
		n98 = (GTextField)((GComponent)this).GetChild("n98");
		string id = "ui://tt2iq07oj1h83g".Replace("ui://", "") + "-" + ((GObject)n98).id;
		((GObject)n98).text = LanguagesManager.GetDesc(id);
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id2 = "ui://tt2iq07oj1h83g".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id2);
		n100 = (GTextField)((GComponent)this).GetChild("n100");
		string id3 = "ui://tt2iq07oj1h83g".Replace("ui://", "") + "-" + ((GObject)n100).id;
		((GObject)n100).text = LanguagesManager.GetDesc(id3);
		n101 = (GTextField)((GComponent)this).GetChild("n101");
		string id4 = "ui://tt2iq07oj1h83g".Replace("ui://", "") + "-" + ((GObject)n101).id;
		((GObject)n101).text = LanguagesManager.GetDesc(id4);
		n102 = (GTextField)((GComponent)this).GetChild("n102");
		string id5 = "ui://tt2iq07oj1h83g".Replace("ui://", "") + "-" + ((GObject)n102).id;
		((GObject)n102).text = LanguagesManager.GetDesc(id5);
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}
