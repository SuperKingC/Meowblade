using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_IslandFinishDialog : GComponent
{
	public Controller Type;

	public Controller CampId;

	public GImage back;

	public GGraph n28;

	public GTextField tip;

	public GLoader npc;

	public GLoader n27;

	public GTextField n29;

	public GTextField CountDown;

	public GButton ConfirmBtn;

	public UI_BigBtn BackToMainCamp;

	public UI_BigBtn ContinueWatching;

	public GLoader n37;

	public GTextField WinInfo;

	public GImage n40;

	public GTextField Score;

	public GGroup n41;

	public GGroup n39;

	public const string URL = "ui://hd2s9kukrs2j4x";

	public static string Name = "UI_IslandFinishDialog";

	public static string GetURL()
	{
		return "ui://hd2s9kukrs2j4x";
	}

	public static UI_IslandFinishDialog CreateInstance()
	{
		return (UI_IslandFinishDialog)(object)UIPackage.CreateObject("GvGWorldMap2", "IslandFinishDialog");
	}

	public static UI_IslandFinishDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandFinishDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukrs2j4x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		CampId = ((GComponent)this).GetController("CampId");
		back = (GImage)((GComponent)this).GetChild("back");
		n28 = (GGraph)((GComponent)this).GetChild("n28");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://hd2s9kukrs2j4x".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		npc = (GLoader)((GComponent)this).GetChild("npc");
		n27 = (GLoader)((GComponent)this).GetChild("n27");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://hd2s9kukrs2j4x".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		string id3 = "ui://hd2s9kukrs2j4x".Replace("ui://", "") + "-" + ((GObject)CountDown).id;
		((GObject)CountDown).text = LanguagesManager.GetDesc(id3);
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		BackToMainCamp = (UI_BigBtn)(object)((GComponent)this).GetChild("BackToMainCamp");
		ContinueWatching = (UI_BigBtn)(object)((GComponent)this).GetChild("ContinueWatching");
		n37 = (GLoader)((GComponent)this).GetChild("n37");
		WinInfo = (GTextField)((GComponent)this).GetChild("WinInfo");
		string id4 = "ui://hd2s9kukrs2j4x".Replace("ui://", "") + "-" + ((GObject)WinInfo).id;
		((GObject)WinInfo).text = LanguagesManager.GetDesc(id4);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		string id5 = "ui://hd2s9kukrs2j4x".Replace("ui://", "") + "-" + ((GObject)Score).id;
		((GObject)Score).text = LanguagesManager.GetDesc(id5);
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
	}
}
