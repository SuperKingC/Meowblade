using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_SelectBlueprintPopup : GComponent
{
	public Controller SelectState;

	public Controller hasEffect;

	public Controller showAdditionEffect;

	public Controller propertyLevel;

	public GImage back;

	public GTextField Title;

	public UI_btn_yes confirmBtn;

	public GImage n117;

	public GTextField n120;

	public GGroup n121;

	public GGroup n132;

	public GImage n129;

	public GImage n130;

	public GImage n131;

	public GList itemList;

	public GImage n87;

	public GGroup part1;

	public GImage n122;

	public GImage n124;

	public UI_btn_reset backBtn1;

	public GGraph iconBg;

	public GTextField BlueprintName;

	public GLoader BlueprintIcon;

	public GButton EvoLegendItem;

	public GTextField n93;

	public GTextField Desc;

	public GImage n98;

	public UI_com_SelectBlueprintPopupContent1 content1;

	public GRichTextField setAliasDecs;

	public GTextField n125;

	public GGroup part2;

	public GImage n115;

	public GGroup n119;

	public GImage n116;

	public GImage n103;

	public GList effectList;

	public GGroup part3;

	public GImage n123;

	public GImage n126;

	public UI_btn_reset backBtn2;

	public GImage n108;

	public UI_content2 content2;

	public GRichTextField n12;

	public GLoader attIcon;

	public GTextField attDesc;

	public GGroup part4;

	public UI_btn_page pageNext;

	public UI_btn_page pageLast;

	public GTextField page;

	public GGroup n137;

	public Transition to01;

	public Transition to2;

	public Transition to0;

	public Transition to21;

	public const string URL = "ui://h09dvkcgqyyy5ltdp";

	public static string Name = "UI_com_SelectBlueprintPopup";

	public static string GetURL()
	{
		return "ui://h09dvkcgqyyy5ltdp";
	}

	public static UI_com_SelectBlueprintPopup CreateInstance()
	{
		return (UI_com_SelectBlueprintPopup)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_SelectBlueprintPopup");
	}

	public static UI_com_SelectBlueprintPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectBlueprintPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqyyy5ltdp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected O, but got Unknown
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Expected O, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelectState = ((GComponent)this).GetController("SelectState");
		hasEffect = ((GComponent)this).GetController("hasEffect");
		showAdditionEffect = ((GComponent)this).GetController("showAdditionEffect");
		propertyLevel = ((GComponent)this).GetController("propertyLevel");
		back = (GImage)((GComponent)this).GetChild("back");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		confirmBtn = (UI_btn_yes)(object)((GComponent)this).GetChild("confirmBtn");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n120 = (GTextField)((GComponent)this).GetChild("n120");
		string id2 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)n120).id;
		((GObject)n120).text = LanguagesManager.GetDesc(id2);
		n121 = (GGroup)((GComponent)this).GetChild("n121");
		n132 = (GGroup)((GComponent)this).GetChild("n132");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		itemList = (GList)((GComponent)this).GetChild("itemList");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		part1 = (GGroup)((GComponent)this).GetChild("part1");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		n124 = (GImage)((GComponent)this).GetChild("n124");
		backBtn1 = (UI_btn_reset)(object)((GComponent)this).GetChild("backBtn1");
		iconBg = (GGraph)((GComponent)this).GetChild("iconBg");
		BlueprintName = (GTextField)((GComponent)this).GetChild("BlueprintName");
		BlueprintIcon = (GLoader)((GComponent)this).GetChild("BlueprintIcon");
		EvoLegendItem = (GButton)((GComponent)this).GetChild("EvoLegendItem");
		n93 = (GTextField)((GComponent)this).GetChild("n93");
		string id3 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)n93).id;
		((GObject)n93).text = LanguagesManager.GetDesc(id3);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		content1 = (UI_com_SelectBlueprintPopupContent1)(object)((GComponent)this).GetChild("content1");
		setAliasDecs = (GRichTextField)((GComponent)this).GetChild("setAliasDecs");
		string id4 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)setAliasDecs).id;
		((GObject)setAliasDecs).text = LanguagesManager.GetDesc(id4);
		n125 = (GTextField)((GComponent)this).GetChild("n125");
		string id5 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)n125).id;
		((GObject)n125).text = LanguagesManager.GetDesc(id5);
		part2 = (GGroup)((GComponent)this).GetChild("part2");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n119 = (GGroup)((GComponent)this).GetChild("n119");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		effectList = (GList)((GComponent)this).GetChild("effectList");
		part3 = (GGroup)((GComponent)this).GetChild("part3");
		n123 = (GImage)((GComponent)this).GetChild("n123");
		n126 = (GImage)((GComponent)this).GetChild("n126");
		backBtn2 = (UI_btn_reset)(object)((GComponent)this).GetChild("backBtn2");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		content2 = (UI_content2)(object)((GComponent)this).GetChild("content2");
		n12 = (GRichTextField)((GComponent)this).GetChild("n12");
		string id6 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id6);
		attIcon = (GLoader)((GComponent)this).GetChild("attIcon");
		attDesc = (GTextField)((GComponent)this).GetChild("attDesc");
		string id7 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)attDesc).id;
		((GObject)attDesc).text = LanguagesManager.GetDesc(id7);
		part4 = (GGroup)((GComponent)this).GetChild("part4");
		pageNext = (UI_btn_page)(object)((GComponent)this).GetChild("pageNext");
		pageLast = (UI_btn_page)(object)((GComponent)this).GetChild("pageLast");
		page = (GTextField)((GComponent)this).GetChild("page");
		string id8 = "ui://h09dvkcgqyyy5ltdp".Replace("ui://", "") + "-" + ((GObject)page).id;
		((GObject)page).text = LanguagesManager.GetDesc(id8);
		n137 = (GGroup)((GComponent)this).GetChild("n137");
		to01 = ((GComponent)this).GetTransition("to01");
		to2 = ((GComponent)this).GetTransition("to2");
		to0 = ((GComponent)this).GetTransition("to0");
		to21 = ((GComponent)this).GetTransition("to21");
	}
}
