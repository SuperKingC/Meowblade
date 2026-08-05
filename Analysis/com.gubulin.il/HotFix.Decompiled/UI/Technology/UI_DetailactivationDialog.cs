using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailactivationDialog : GComponent
{
	public GImage background;

	public GGraph n48;

	public GButton exit;

	public GLoader IconFrame;

	public GLoader IconLoader;

	public GTextField Name_t;

	public GTextField owner;

	public GTextField Describe_t;

	public GTextField gradeTitle;

	public GTextField ConsumptionTitle;

	public UI_RepairBtn RepairBtn;

	public GButton ConsumptionItem;

	public const string URL = "ui://7ca77a3fv93k35";

	public static string Name = "UI_DetailactivationDialog";

	public void SetButtonTitle()
	{
		((GObject)RepairBtn.title).text = LanguagesManager.GetDesc("Technology-DetailactivationDialog-RepairBtn-title");
	}

	public static string GetURL()
	{
		return "ui://7ca77a3fv93k35";
	}

	public static UI_DetailactivationDialog CreateInstance()
	{
		return (UI_DetailactivationDialog)(object)UIPackage.CreateObject("Technology", "DetailactivationDialog");
	}

	public static UI_DetailactivationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailactivationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fv93k35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GImage)((GComponent)this).GetChild("background");
		n48 = (GGraph)((GComponent)this).GetChild("n48");
		exit = (GButton)((GComponent)this).GetChild("exit");
		IconFrame = (GLoader)((GComponent)this).GetChild("IconFrame");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id = "ui://7ca77a3fv93k35".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id);
		owner = (GTextField)((GComponent)this).GetChild("owner");
		string id2 = "ui://7ca77a3fv93k35".Replace("ui://", "") + "-" + ((GObject)owner).id;
		((GObject)owner).text = LanguagesManager.GetDesc(id2);
		Describe_t = (GTextField)((GComponent)this).GetChild("Describe_t");
		string id3 = "ui://7ca77a3fv93k35".Replace("ui://", "") + "-" + ((GObject)Describe_t).id;
		((GObject)Describe_t).text = LanguagesManager.GetDesc(id3);
		gradeTitle = (GTextField)((GComponent)this).GetChild("gradeTitle");
		string id4 = "ui://7ca77a3fv93k35".Replace("ui://", "") + "-" + ((GObject)gradeTitle).id;
		((GObject)gradeTitle).text = LanguagesManager.GetDesc(id4);
		ConsumptionTitle = (GTextField)((GComponent)this).GetChild("ConsumptionTitle");
		string id5 = "ui://7ca77a3fv93k35".Replace("ui://", "") + "-" + ((GObject)ConsumptionTitle).id;
		((GObject)ConsumptionTitle).text = LanguagesManager.GetDesc(id5);
		RepairBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("RepairBtn");
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
	}
}
