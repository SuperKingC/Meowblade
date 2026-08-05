using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_QueueListItem : GComponent
{
	public Controller PageController;

	public Controller Level;

	public Controller NumStatus;

	public Controller Type;

	public Controller LegendItemNum;

	public GImage n53;

	public GLoader FrameLoader;

	public UI_SoldierIconLoader IconLoader;

	public GGraph n52;

	public GLoader lvFrame;

	public GComponent SoulStoneLevel;

	public GRichTextField Level_t;

	public GImage numNote;

	public GRichTextField Amount_t;

	public GRichTextField BestAmount;

	public GGroup InfoGroup;

	public GTextField Name_t;

	public GTextField Name_Max;

	public GGroup NameGroup;

	public GImage legendItemsBack;

	public GImage n46;

	public GImage n47;

	public GButton legendItem0;

	public GButton legendItem1;

	public GGroup LegendItems;

	public GButton racePicture;

	public Transition t0;

	public const string URL = "ui://k2sprg26p1ft3";

	public static string Name = "UI_QueueListItem";

	public static string GetURL()
	{
		return "ui://k2sprg26p1ft3";
	}

	public static UI_QueueListItem CreateInstance()
	{
		return (UI_QueueListItem)(object)UIPackage.CreateObject("IslandComeAgain", "QueueListItem");
	}

	public static UI_QueueListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QueueListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26p1ft3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
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
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Level = ((GComponent)this).GetController("Level");
		NumStatus = ((GComponent)this).GetController("NumStatus");
		Type = ((GComponent)this).GetController("Type");
		LegendItemNum = ((GComponent)this).GetController("LegendItemNum");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (UI_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Level_t = (GRichTextField)((GComponent)this).GetChild("Level_t");
		string id = "ui://k2sprg26p1ft3".Replace("ui://", "") + "-" + ((GObject)Level_t).id;
		((GObject)Level_t).text = LanguagesManager.GetDesc(id);
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
		BestAmount = (GRichTextField)((GComponent)this).GetChild("BestAmount");
		InfoGroup = (GGroup)((GComponent)this).GetChild("InfoGroup");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id2 = "ui://k2sprg26p1ft3".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id2);
		Name_Max = (GTextField)((GComponent)this).GetChild("Name_Max");
		string id3 = "ui://k2sprg26p1ft3".Replace("ui://", "") + "-" + ((GObject)Name_Max).id;
		((GObject)Name_Max).text = LanguagesManager.GetDesc(id3);
		NameGroup = (GGroup)((GComponent)this).GetChild("NameGroup");
		legendItemsBack = (GImage)((GComponent)this).GetChild("legendItemsBack");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		legendItem0 = (GButton)((GComponent)this).GetChild("legendItem0");
		legendItem1 = (GButton)((GComponent)this).GetChild("legendItem1");
		LegendItems = (GGroup)((GComponent)this).GetChild("LegendItems");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
