using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_PostMyOEMMission : GComponent
{
	public Controller Selected;

	public Controller UseExtra;

	public GImage Background;

	public GImage n17;

	public GImage n20;

	public GImage n19;

	public GImage n18;

	public UI_btn_PostMission_Small Post;

	public GTextField n2;

	public UI_btn_SelectedAmplifier SelectedAmplifier;

	public GTextField n8;

	public GTextField n9;

	public GList ConsumedItems;

	public GTextField n3;

	public GTextField MissionDuration;

	public GTextField n5;

	public GGroup n16;

	public GImage n21;

	public GTextField n22;

	public GTextField n23;

	public GButton Help;

	public GImage n24;

	public GImage n26;

	public GLoader Icon;

	public GTextField Consumed;

	public GImage n31;

	public UI_btn_Add Add;

	public GGroup n27;

	public GTextField n28;

	public const string URL = "ui://tt2iq07onhzv17";

	public static string Name = "UI_com_PostMyOEMMission";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv17";
	}

	public static UI_com_PostMyOEMMission CreateInstance()
	{
		return (UI_com_PostMyOEMMission)(object)UIPackage.CreateObject("GvGExchange3", "com_PostMyOEMMission");
	}

	public static UI_com_PostMyOEMMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostMyOEMMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected O, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		UseExtra = ((GComponent)this).GetController("UseExtra");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Post = (UI_btn_PostMission_Small)(object)((GComponent)this).GetChild("Post");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		SelectedAmplifier = (UI_btn_SelectedAmplifier)(object)((GComponent)this).GetChild("SelectedAmplifier");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		ConsumedItems = (GList)((GComponent)this).GetChild("ConsumedItems");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id4 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id4);
		MissionDuration = (GTextField)((GComponent)this).GetChild("MissionDuration");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id5 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id5);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id6 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id6);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id7 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id7);
		Help = (GButton)((GComponent)this).GetChild("Help");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Consumed = (GTextField)((GComponent)this).GetChild("Consumed");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		Add = (UI_btn_Add)(object)((GComponent)this).GetChild("Add");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id8 = "ui://tt2iq07onhzv17".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id8);
	}
}
