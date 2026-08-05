using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_QueueListItem : GComponent
{
	public Controller MaskController;

	public Controller PageController;

	public Controller Level;

	public Controller Status;

	public Controller NumStatus;

	public GImage n32;

	public GImage n33;

	public GLoader FloorLoader;

	public GLoader FrameLoader;

	public GImage FrameBack;

	public UI_SoldierIconLoader IconLoader;

	public GImage Mask;

	public GImage highlight;

	public GImage n43;

	public GTextField tip;

	public GGroup n36;

	public GList LevelStarList;

	public GLoader lvFrame;

	public GComponent SoulStoneLevel;

	public GRichTextField Level_t;

	public GImage n41;

	public GImage numNote;

	public GRichTextField Amount_t;

	public GGroup InfoGroup;

	public GTextField Name_t;

	public GTextField Name_Max;

	public GTextField state;

	public GImage max;

	public Transition t0;

	public const string URL = "ui://72fujxhkpipj9";

	public static string Name = "UI_QueueListItem";

	public static string GetURL()
	{
		return "ui://72fujxhkpipj9";
	}

	public static UI_QueueListItem CreateInstance()
	{
		return (UI_QueueListItem)(object)UIPackage.CreateObject("RecruitingCamp", "QueueListItem");
	}

	public static UI_QueueListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QueueListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkpipj9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
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
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MaskController = ((GComponent)this).GetController("MaskController");
		PageController = ((GComponent)this).GetController("PageController");
		Level = ((GComponent)this).GetController("Level");
		Status = ((GComponent)this).GetController("Status");
		NumStatus = ((GComponent)this).GetController("NumStatus");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		FrameBack = (GImage)((GComponent)this).GetChild("FrameBack");
		IconLoader = (UI_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		highlight = (GImage)((GComponent)this).GetChild("highlight");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://72fujxhkpipj9".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		LevelStarList = (GList)((GComponent)this).GetChild("LevelStarList");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Level_t = (GRichTextField)((GComponent)this).GetChild("Level_t");
		string id2 = "ui://72fujxhkpipj9".Replace("ui://", "") + "-" + ((GObject)Level_t).id;
		((GObject)Level_t).text = LanguagesManager.GetDesc(id2);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
		InfoGroup = (GGroup)((GComponent)this).GetChild("InfoGroup");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id3 = "ui://72fujxhkpipj9".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id3);
		Name_Max = (GTextField)((GComponent)this).GetChild("Name_Max");
		string id4 = "ui://72fujxhkpipj9".Replace("ui://", "") + "-" + ((GObject)Name_Max).id;
		((GObject)Name_Max).text = LanguagesManager.GetDesc(id4);
		state = (GTextField)((GComponent)this).GetChild("state");
		max = (GImage)((GComponent)this).GetChild("max");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
