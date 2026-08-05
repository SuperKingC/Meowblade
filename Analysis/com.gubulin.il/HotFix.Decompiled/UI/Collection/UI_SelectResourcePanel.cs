using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_SelectResourcePanel : GComponent
{
	public GGraph mask;

	public GImage back;

	public GImage n30;

	public GGraph line;

	public GButton exitButton;

	public UI_yes confirmButton;

	public UI_no concelButton;

	public GLoader title;

	public GList materialSelectList;

	public UI_show SelectAllBtn;

	public GGroup selectWindow;

	public GImage corner;

	public GImage tipBack;

	public GTextField npcWords;

	public GGraph n18;

	public GLoader npc;

	public GTextField npcName;

	public GGroup npcGroup;

	public GGroup guideTip;

	public Transition showUp;

	public const string URL = "ui://ehe4tm5znwjt4b";

	public static string Name = "UI_SelectResourcePanel";

	public static string GetURL()
	{
		return "ui://ehe4tm5znwjt4b";
	}

	public static UI_SelectResourcePanel CreateInstance()
	{
		return (UI_SelectResourcePanel)(object)UIPackage.CreateObject("Collection", "SelectResourcePanel");
	}

	public static UI_SelectResourcePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectResourcePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5znwjt4b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		line = (GGraph)((GComponent)this).GetChild("line");
		exitButton = (GButton)((GComponent)this).GetChild("exitButton");
		confirmButton = (UI_yes)(object)((GComponent)this).GetChild("confirmButton");
		concelButton = (UI_no)(object)((GComponent)this).GetChild("concelButton");
		title = (GLoader)((GComponent)this).GetChild("title");
		materialSelectList = (GList)((GComponent)this).GetChild("materialSelectList");
		SelectAllBtn = (UI_show)(object)((GComponent)this).GetChild("SelectAllBtn");
		selectWindow = (GGroup)((GComponent)this).GetChild("selectWindow");
		corner = (GImage)((GComponent)this).GetChild("corner");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		npcWords = (GTextField)((GComponent)this).GetChild("npcWords");
		string id = "ui://ehe4tm5znwjt4b".Replace("ui://", "") + "-" + ((GObject)npcWords).id;
		((GObject)npcWords).text = LanguagesManager.GetDesc(id);
		n18 = (GGraph)((GComponent)this).GetChild("n18");
		npc = (GLoader)((GComponent)this).GetChild("npc");
		npcName = (GTextField)((GComponent)this).GetChild("npcName");
		string id2 = "ui://ehe4tm5znwjt4b".Replace("ui://", "") + "-" + ((GObject)npcName).id;
		((GObject)npcName).text = LanguagesManager.GetDesc(id2);
		npcGroup = (GGroup)((GComponent)this).GetChild("npcGroup");
		guideTip = (GGroup)((GComponent)this).GetChild("guideTip");
		showUp = ((GComponent)this).GetTransition("showUp");
	}
}
