using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DestroyDotBtn : GButton
{
	public Controller button;

	public Controller PageController;

	public Controller Status;

	public GImage grayLine0;

	public GImage grayLine1;

	public GImage grayLine2;

	public GImage lightLine0;

	public GImage lightLine1;

	public GImage lightLine2;

	public GImage halfLightLine0;

	public GImage halfLightLine1;

	public GImage halfLightLine2;

	public GImage frame0;

	public GImage frame1;

	public GImage frame2;

	public GTextField title;

	public GTextField index;

	public GGraph backSpine;

	public GLoader frame;

	public GLoader icon;

	public GLoader iconGray;

	public GTextField level;

	public GTextField levelLimit;

	public GTextField lockTip;

	public GImage n48;

	public GGraph levelSfxBack;

	public GGraph textSpine;

	public Transition lightUp;

	public Transition lineDisapear;

	public Transition ZeroToTwo;

	public Transition TwoToOne;

	public Transition ZeroToZero;

	public Transition TechUpgrade;

	public const string URL = "ui://7ca77a3fty9r6";

	public static string Name = "UI_DestroyDotBtn";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://7ca77a3fty9r6".Replace("ui://", ""), ((GObject)lockTip).id, PageController.selectedIndex);
		((GObject)lockTip).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://7ca77a3fty9r6";
	}

	public static UI_DestroyDotBtn CreateInstance()
	{
		return (UI_DestroyDotBtn)(object)UIPackage.CreateObject("Technology", "DestroyDotBtn");
	}

	public static UI_DestroyDotBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DestroyDotBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9r6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
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
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		Status = ((GComponent)this).GetController("Status");
		grayLine0 = (GImage)((GComponent)this).GetChild("grayLine0");
		grayLine1 = (GImage)((GComponent)this).GetChild("grayLine1");
		grayLine2 = (GImage)((GComponent)this).GetChild("grayLine2");
		lightLine0 = (GImage)((GComponent)this).GetChild("lightLine0");
		lightLine1 = (GImage)((GComponent)this).GetChild("lightLine1");
		lightLine2 = (GImage)((GComponent)this).GetChild("lightLine2");
		halfLightLine0 = (GImage)((GComponent)this).GetChild("halfLightLine0");
		halfLightLine1 = (GImage)((GComponent)this).GetChild("halfLightLine1");
		halfLightLine2 = (GImage)((GComponent)this).GetChild("halfLightLine2");
		frame0 = (GImage)((GComponent)this).GetChild("frame0");
		frame1 = (GImage)((GComponent)this).GetChild("frame1");
		frame2 = (GImage)((GComponent)this).GetChild("frame2");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7ca77a3fty9r6".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		index = (GTextField)((GComponent)this).GetChild("index");
		string id2 = "ui://7ca77a3fty9r6".Replace("ui://", "") + "-" + ((GObject)index).id;
		((GObject)index).text = LanguagesManager.GetDesc(id2);
		backSpine = (GGraph)((GComponent)this).GetChild("backSpine");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		iconGray = (GLoader)((GComponent)this).GetChild("iconGray");
		level = (GTextField)((GComponent)this).GetChild("level");
		levelLimit = (GTextField)((GComponent)this).GetChild("levelLimit");
		string id3 = "ui://7ca77a3fty9r6".Replace("ui://", "") + "-" + ((GObject)levelLimit).id;
		((GObject)levelLimit).text = LanguagesManager.GetDesc(id3);
		lockTip = (GTextField)((GComponent)this).GetChild("lockTip");
		string id4 = "ui://7ca77a3fty9r6".Replace("ui://", "") + "-" + ((GObject)lockTip).id;
		((GObject)lockTip).text = LanguagesManager.GetDesc(id4);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		levelSfxBack = (GGraph)((GComponent)this).GetChild("levelSfxBack");
		textSpine = (GGraph)((GComponent)this).GetChild("textSpine");
		lightUp = ((GComponent)this).GetTransition("lightUp");
		lineDisapear = ((GComponent)this).GetTransition("lineDisapear");
		ZeroToTwo = ((GComponent)this).GetTransition("ZeroToTwo");
		TwoToOne = ((GComponent)this).GetTransition("TwoToOne");
		ZeroToZero = ((GComponent)this).GetTransition("ZeroToZero");
		TechUpgrade = ((GComponent)this).GetTransition("TechUpgrade");
	}
}
