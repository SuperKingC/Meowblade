using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DestroyMasterBtn : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Type;

	public GImage grayLine0;

	public GImage grayLine1;

	public GImage grayLine2;

	public GImage lightLine0;

	public GImage lightLine1;

	public GImage lightLine2;

	public GImage halfLightLine0;

	public GImage halfLightLine1;

	public GImage halfLightLine2;

	public GImage n21;

	public GImage n20;

	public GTextField title;

	public GTextField index;

	public GGraph backSpine;

	public GLoader frame;

	public GGraph textSpine;

	public GLoader icon;

	public GLoader iconGray;

	public GTextField lockedText;

	public GTextField levelNew;

	public GTextField levelLimit;

	public GImage n35;

	public GGraph levelSfxBack;

	public Transition lightUp;

	public Transition lineDisapear;

	public Transition MasterUpgrade;

	public const string URL = "ui://7ca77a3fty9r8";

	public static string Name = "UI_DestroyMasterBtn";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9r8";
	}

	public static UI_DestroyMasterBtn CreateInstance()
	{
		return (UI_DestroyMasterBtn)(object)UIPackage.CreateObject("Technology", "DestroyMasterBtn");
	}

	public static UI_DestroyMasterBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DestroyMasterBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9r8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
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
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		grayLine0 = (GImage)((GComponent)this).GetChild("grayLine0");
		grayLine1 = (GImage)((GComponent)this).GetChild("grayLine1");
		grayLine2 = (GImage)((GComponent)this).GetChild("grayLine2");
		lightLine0 = (GImage)((GComponent)this).GetChild("lightLine0");
		lightLine1 = (GImage)((GComponent)this).GetChild("lightLine1");
		lightLine2 = (GImage)((GComponent)this).GetChild("lightLine2");
		halfLightLine0 = (GImage)((GComponent)this).GetChild("halfLightLine0");
		halfLightLine1 = (GImage)((GComponent)this).GetChild("halfLightLine1");
		halfLightLine2 = (GImage)((GComponent)this).GetChild("halfLightLine2");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7ca77a3fty9r8".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		index = (GTextField)((GComponent)this).GetChild("index");
		string id2 = "ui://7ca77a3fty9r8".Replace("ui://", "") + "-" + ((GObject)index).id;
		((GObject)index).text = LanguagesManager.GetDesc(id2);
		backSpine = (GGraph)((GComponent)this).GetChild("backSpine");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		textSpine = (GGraph)((GComponent)this).GetChild("textSpine");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		iconGray = (GLoader)((GComponent)this).GetChild("iconGray");
		lockedText = (GTextField)((GComponent)this).GetChild("lockedText");
		string id3 = "ui://7ca77a3fty9r8".Replace("ui://", "") + "-" + ((GObject)lockedText).id;
		((GObject)lockedText).text = LanguagesManager.GetDesc(id3);
		levelNew = (GTextField)((GComponent)this).GetChild("levelNew");
		levelLimit = (GTextField)((GComponent)this).GetChild("levelLimit");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		levelSfxBack = (GGraph)((GComponent)this).GetChild("levelSfxBack");
		lightUp = ((GComponent)this).GetTransition("lightUp");
		lineDisapear = ((GComponent)this).GetTransition("lineDisapear");
		MasterUpgrade = ((GComponent)this).GetTransition("MasterUpgrade");
	}
}
