using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_MaterialIntroduction : GComponent
{
	public Controller PageController;

	public Controller isBluePrint;

	public GGraph interceptBack;

	public GImage windowBack;

	public GImage windowBack2;

	public UI_RepairBtn checkBtn;

	public UI_Content Content;

	public UI_consumption consumption;

	public GTextField title2nd;

	public GImage compoundNumBack;

	public GTextField compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public UI_MaxValueBtn MaxValueBtn;

	public GGroup n16;

	public GTextField warnning;

	public GTextField Warnning2;

	public GTextField Warnning3;

	public UI_HelpBtn help;

	public const string URL = "ui://47lbpgx9mol01t";

	public static string Name = "UI_MaterialIntroduction";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9mol01t".Replace("ui://", ""), ((GObject)checkBtn).id, PageController.selectedIndex);
		((GObject)checkBtn).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9mol01t";
	}

	public static UI_MaterialIntroduction CreateInstance()
	{
		return (UI_MaterialIntroduction)(object)UIPackage.CreateObject("Tips", "MaterialIntroduction");
	}

	public static UI_MaterialIntroduction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaterialIntroduction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mol01t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		isBluePrint = ((GComponent)this).GetController("isBluePrint");
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		windowBack2 = (GImage)((GComponent)this).GetChild("windowBack2");
		checkBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("checkBtn");
		Content = (UI_Content)(object)((GComponent)this).GetChild("Content");
		consumption = (UI_consumption)(object)((GComponent)this).GetChild("consumption");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id = "ui://47lbpgx9mol01t".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id);
		compoundNumBack = (GImage)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		warnning = (GTextField)((GComponent)this).GetChild("warnning");
		string id2 = "ui://47lbpgx9mol01t".Replace("ui://", "") + "-" + ((GObject)warnning).id;
		((GObject)warnning).text = LanguagesManager.GetDesc(id2);
		Warnning2 = (GTextField)((GComponent)this).GetChild("Warnning2");
		string id3 = "ui://47lbpgx9mol01t".Replace("ui://", "") + "-" + ((GObject)Warnning2).id;
		((GObject)Warnning2).text = LanguagesManager.GetDesc(id3);
		Warnning3 = (GTextField)((GComponent)this).GetChild("Warnning3");
		string id4 = "ui://47lbpgx9mol01t".Replace("ui://", "") + "-" + ((GObject)Warnning3).id;
		((GObject)Warnning3).text = LanguagesManager.GetDesc(id4);
		help = (UI_HelpBtn)(object)((GComponent)this).GetChild("help");
	}
}
