using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_com_QueueListItem : GComponent
{
	public Controller PageController;

	public Controller Status;

	public Controller NumStatus;

	public GImage n32;

	public GImage n33;

	public GImage n43;

	public GImage RedDot;

	public GLoader FrameLoader;

	public GImage FrameBack;

	public UI_SoldierIconLoader IconLoader;

	public GImage Mask;

	public GImage highlight;

	public GImage n47;

	public GTextField tip;

	public GGroup n36;

	public GLoader lvFrame;

	public GComponent SoulStoneLevel;

	public GRichTextField Level_t;

	public GImage n41;

	public GImage numNote;

	public GRichTextField Amount_t;

	public GImage max;

	public GButton NotEnough;

	public GGroup InfoGroup;

	public GGroup n45;

	public Transition t0;

	public const string URL = "ui://72fujxhkzmkj33";

	public static string Name = "UI_com_QueueListItem";

	public static string GetURL()
	{
		return "ui://72fujxhkzmkj33";
	}

	public static UI_com_QueueListItem CreateInstance()
	{
		return (UI_com_QueueListItem)(object)UIPackage.CreateObject("RecruitingCamp", "com_QueueListItem");
	}

	public static UI_com_QueueListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_QueueListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkzmkj33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Status = ((GComponent)this).GetController("Status");
		NumStatus = ((GComponent)this).GetController("NumStatus");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		FrameBack = (GImage)((GComponent)this).GetChild("FrameBack");
		IconLoader = (UI_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		highlight = (GImage)((GComponent)this).GetChild("highlight");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://72fujxhkzmkj33".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Level_t = (GRichTextField)((GComponent)this).GetChild("Level_t");
		string id2 = "ui://72fujxhkzmkj33".Replace("ui://", "") + "-" + ((GObject)Level_t).id;
		((GObject)Level_t).text = LanguagesManager.GetDesc(id2);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
		max = (GImage)((GComponent)this).GetChild("max");
		NotEnough = (GButton)((GComponent)this).GetChild("NotEnough");
		InfoGroup = (GGroup)((GComponent)this).GetChild("InfoGroup");
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
