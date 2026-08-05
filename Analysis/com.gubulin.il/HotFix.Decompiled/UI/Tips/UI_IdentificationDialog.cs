using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_IdentificationDialog : GComponent
{
	public GGraph interceptBack;

	public GImage windowBack;

	public UI_Content Content;

	public UI_consumption consumption;

	public GTextField title2nd;

	public GImage compoundNumBack;

	public GTextField compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public UI_MaxValueBtn MaxValueBtn;

	public GGroup n16;

	public UI_RepairBtn checkBtn;

	public const string URL = "ui://47lbpgx9g6f957";

	public static string Name = "UI_IdentificationDialog";

	public void SetButtonTitle()
	{
		((GObject)checkBtn.title).text = LanguagesManager.GetDesc("Tips-IdentificationDialog-checkBtn-title");
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9g6f957";
	}

	public static UI_IdentificationDialog CreateInstance()
	{
		return (UI_IdentificationDialog)(object)UIPackage.CreateObject("Tips", "IdentificationDialog");
	}

	public static UI_IdentificationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IdentificationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9g6f957", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		Content = (UI_Content)(object)((GComponent)this).GetChild("Content");
		consumption = (UI_consumption)(object)((GComponent)this).GetChild("consumption");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id = "ui://47lbpgx9g6f957".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id);
		compoundNumBack = (GImage)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		checkBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("checkBtn");
	}
}
