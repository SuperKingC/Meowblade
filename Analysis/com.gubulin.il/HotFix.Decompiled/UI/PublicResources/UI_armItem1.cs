using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_armItem1 : GButton
{
	public Controller button;

	public Controller RedPointController;

	public Controller Status;

	public Controller Level;

	public Controller LegendItemNum;

	public GImage removeBack;

	public GLoader iconFrame;

	public GImage iconFrameBack;

	public GLoader icon;

	public GLoader lvFrame;

	public GRichTextField lv;

	public GImage assemblyNote;

	public GImage removeNote;

	public UI_SoliderSoulStoneLevel SoulStoneLevel;

	public GList classListCopy;

	public GList classList;

	public GRichTextField title;

	public GRichTextField title_Max;

	public GTextField removeText;

	public UI_racePicture racePicture;

	public GImage redPoint;

	public GImage occupation;

	public UI_SoldierPotentialIcon19 PotentialIcon;

	public GImage newIcon;

	public GImage modifierBack;

	public GTextField modifierText;

	public GGroup modifierGroup;

	public GList unlockSoldiersStonesList;

	public GImage SelectNote;

	public GImage NumBack;

	public GImage numNote2;

	public GRichTextField num2;

	public GGroup NumSelected;

	public GImage numNote;

	public GRichTextField num;

	public GGroup NumSelected1;

	public GImage legendItemsBack;

	public GImage n55;

	public GImage n56;

	public UI_LegendItem legendItem0;

	public UI_LegendItem legendItem1;

	public GGroup LegendItems;

	public GImage max;

	public const string URL = "ui://kt6rg65ovv0ue7";

	public static string Name = "UI_armItem1";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0ue7";
	}

	public static UI_armItem1 CreateInstance()
	{
		return (UI_armItem1)(object)UIPackage.CreateObject("PublicResources", "armItem1");
	}

	public static UI_armItem1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_armItem1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0ue7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected O, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Expected O, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedPointController = ((GComponent)this).GetController("RedPointController");
		Status = ((GComponent)this).GetController("Status");
		Level = ((GComponent)this).GetController("Level");
		LegendItemNum = ((GComponent)this).GetController("LegendItemNum");
		removeBack = (GImage)((GComponent)this).GetChild("removeBack");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		iconFrameBack = (GImage)((GComponent)this).GetChild("iconFrameBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		lv = (GRichTextField)((GComponent)this).GetChild("lv");
		string id = "ui://kt6rg65ovv0ue7".Replace("ui://", "") + "-" + ((GObject)lv).id;
		((GObject)lv).text = LanguagesManager.GetDesc(id);
		assemblyNote = (GImage)((GComponent)this).GetChild("assemblyNote");
		removeNote = (GImage)((GComponent)this).GetChild("removeNote");
		SoulStoneLevel = (UI_SoliderSoulStoneLevel)(object)((GComponent)this).GetChild("SoulStoneLevel");
		classListCopy = (GList)((GComponent)this).GetChild("classListCopy");
		classList = (GList)((GComponent)this).GetChild("classList");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://kt6rg65ovv0ue7".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		title_Max = (GRichTextField)((GComponent)this).GetChild("title_Max");
		string id3 = "ui://kt6rg65ovv0ue7".Replace("ui://", "") + "-" + ((GObject)title_Max).id;
		((GObject)title_Max).text = LanguagesManager.GetDesc(id3);
		removeText = (GTextField)((GComponent)this).GetChild("removeText");
		string id4 = "ui://kt6rg65ovv0ue7".Replace("ui://", "") + "-" + ((GObject)removeText).id;
		((GObject)removeText).text = LanguagesManager.GetDesc(id4);
		racePicture = (UI_racePicture)(object)((GComponent)this).GetChild("racePicture");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
		occupation = (GImage)((GComponent)this).GetChild("occupation");
		PotentialIcon = (UI_SoldierPotentialIcon19)(object)((GComponent)this).GetChild("PotentialIcon");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		modifierBack = (GImage)((GComponent)this).GetChild("modifierBack");
		modifierText = (GTextField)((GComponent)this).GetChild("modifierText");
		string id5 = "ui://kt6rg65ovv0ue7".Replace("ui://", "") + "-" + ((GObject)modifierText).id;
		((GObject)modifierText).text = LanguagesManager.GetDesc(id5);
		modifierGroup = (GGroup)((GComponent)this).GetChild("modifierGroup");
		unlockSoldiersStonesList = (GList)((GComponent)this).GetChild("unlockSoldiersStonesList");
		SelectNote = (GImage)((GComponent)this).GetChild("SelectNote");
		NumBack = (GImage)((GComponent)this).GetChild("NumBack");
		numNote2 = (GImage)((GComponent)this).GetChild("numNote2");
		num2 = (GRichTextField)((GComponent)this).GetChild("num2");
		NumSelected = (GGroup)((GComponent)this).GetChild("NumSelected");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		num = (GRichTextField)((GComponent)this).GetChild("num");
		NumSelected1 = (GGroup)((GComponent)this).GetChild("NumSelected1");
		legendItemsBack = (GImage)((GComponent)this).GetChild("legendItemsBack");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		legendItem0 = (UI_LegendItem)(object)((GComponent)this).GetChild("legendItem0");
		legendItem1 = (UI_LegendItem)(object)((GComponent)this).GetChild("legendItem1");
		LegendItems = (GGroup)((GComponent)this).GetChild("LegendItems");
		max = (GImage)((GComponent)this).GetChild("max");
	}
}
