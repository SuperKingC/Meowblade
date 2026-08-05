using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_Choice : GButton
{
	public Controller button;

	public GButton backgroundBtn;

	public GButton n22;

	public GGroup commonGroup;

	public GButton n40;

	public GButton n39;

	public GGroup sliverGroup;

	public GButton n19;

	public GButton n20;

	public GGroup rareGroup;

	public GGraph fxBack;

	public GLoader icon;

	public GRichTextField title;

	public GRichTextField introduction;

	public GTextField stockNum;

	public GLoader numNote;

	public GTextField num;

	public GGroup content;

	public GGraph soldier;

	public GTextField soldierName;

	public GGroup soldierGroup;

	public GComponent curLevel;

	public const string URL = "ui://hda5vzklkxzh1a";

	public static string Name = "UI_Choice";

	public static string GetURL()
	{
		return "ui://hda5vzklkxzh1a";
	}

	public static UI_Choice CreateInstance()
	{
		return (UI_Choice)(object)UIPackage.CreateObject("GameEndPanels", "Choice");
	}

	public static UI_Choice CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Choice).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklkxzh1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		backgroundBtn = (GButton)((GComponent)this).GetChild("backgroundBtn");
		n22 = (GButton)((GComponent)this).GetChild("n22");
		commonGroup = (GGroup)((GComponent)this).GetChild("commonGroup");
		n40 = (GButton)((GComponent)this).GetChild("n40");
		n39 = (GButton)((GComponent)this).GetChild("n39");
		sliverGroup = (GGroup)((GComponent)this).GetChild("sliverGroup");
		n19 = (GButton)((GComponent)this).GetChild("n19");
		n20 = (GButton)((GComponent)this).GetChild("n20");
		rareGroup = (GGroup)((GComponent)this).GetChild("rareGroup");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://hda5vzklkxzh1a".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://hda5vzklkxzh1a".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		stockNum = (GTextField)((GComponent)this).GetChild("stockNum");
		numNote = (GLoader)((GComponent)this).GetChild("numNote");
		num = (GTextField)((GComponent)this).GetChild("num");
		content = (GGroup)((GComponent)this).GetChild("content");
		soldier = (GGraph)((GComponent)this).GetChild("soldier");
		soldierName = (GTextField)((GComponent)this).GetChild("soldierName");
		string id3 = "ui://hda5vzklkxzh1a".Replace("ui://", "") + "-" + ((GObject)soldierName).id;
		((GObject)soldierName).text = LanguagesManager.GetDesc(id3);
		soldierGroup = (GGroup)((GComponent)this).GetChild("soldierGroup");
		curLevel = (GComponent)((GComponent)this).GetChild("curLevel");
	}
}
