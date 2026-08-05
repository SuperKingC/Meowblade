using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintPopupInfolist : GComponent
{
	public Controller hasMainItem;

	public Controller isSelected;

	public Controller showSelectIcon;

	public Controller hasEffect;

	public GImage n23;

	public GImage n143;

	public GImage selectMainOutline;

	public GImage n144;

	public GImage n145;

	public GImage n146;

	public GImage n147;

	public GImage n140;

	public GRichTextField n32;

	public GGroup part1;

	public GGraph selectMainItemBtn;

	public GImage n150;

	public GGraph iconBg1;

	public GTextField BlueprintName;

	public GLoader BlueprintIcon;

	public GButton EvoLegendItem;

	public GTextField n93;

	public GTextField Desc;

	public GImage n98;

	public GRichTextField content1;

	public GImage n142;

	public GImage n148;

	public GGroup part2;

	public GList effectList;

	public GGroup part3;

	public Transition t0;

	public const string URL = "ui://h09dvkcgb8pv5ltdt";

	public static string Name = "UI_com_OptionalBlueprintPopupInfolist";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5ltdt";
	}

	public static UI_com_OptionalBlueprintPopupInfolist CreateInstance()
	{
		return (UI_com_OptionalBlueprintPopupInfolist)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintPopupInfolist");
	}

	public static UI_com_OptionalBlueprintPopupInfolist CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintPopupInfolist).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5ltdt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasMainItem = ((GComponent)this).GetController("hasMainItem");
		isSelected = ((GComponent)this).GetController("isSelected");
		showSelectIcon = ((GComponent)this).GetController("showSelectIcon");
		hasEffect = ((GComponent)this).GetController("hasEffect");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		selectMainOutline = (GImage)((GComponent)this).GetChild("selectMainOutline");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n32 = (GRichTextField)((GComponent)this).GetChild("n32");
		part1 = (GGroup)((GComponent)this).GetChild("part1");
		selectMainItemBtn = (GGraph)((GComponent)this).GetChild("selectMainItemBtn");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		iconBg1 = (GGraph)((GComponent)this).GetChild("iconBg1");
		BlueprintName = (GTextField)((GComponent)this).GetChild("BlueprintName");
		BlueprintIcon = (GLoader)((GComponent)this).GetChild("BlueprintIcon");
		EvoLegendItem = (GButton)((GComponent)this).GetChild("EvoLegendItem");
		n93 = (GTextField)((GComponent)this).GetChild("n93");
		string id = "ui://h09dvkcgb8pv5ltdt".Replace("ui://", "") + "-" + ((GObject)n93).id;
		((GObject)n93).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		content1 = (GRichTextField)((GComponent)this).GetChild("content1");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		part2 = (GGroup)((GComponent)this).GetChild("part2");
		effectList = (GList)((GComponent)this).GetChild("effectList");
		part3 = (GGroup)((GComponent)this).GetChild("part3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
