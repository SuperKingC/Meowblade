using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailInfoPageDialog : GComponent
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

	public GTextField Level_t;

	public GTextField ConsumptionTitle;

	public GTextField Requirement_t;

	public UI_RepairBtn RepairBtn;

	public GImage flowerFrame;

	public GImage piece;

	public GList consumptionList;

	public GTextField tip;

	public GTextField n49;

	public const string URL = "ui://7ca77a3fgp9d2m";

	public static string Name = "UI_DetailInfoPageDialog";

	public static string GetURL()
	{
		return "ui://7ca77a3fgp9d2m";
	}

	public static UI_DetailInfoPageDialog CreateInstance()
	{
		return (UI_DetailInfoPageDialog)(object)UIPackage.CreateObject("Technology", "DetailInfoPageDialog");
	}

	public static UI_DetailInfoPageDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailInfoPageDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fgp9d2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GImage)((GComponent)this).GetChild("background");
		n48 = (GGraph)((GComponent)this).GetChild("n48");
		exit = (GButton)((GComponent)this).GetChild("exit");
		IconFrame = (GLoader)((GComponent)this).GetChild("IconFrame");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		owner = (GTextField)((GComponent)this).GetChild("owner");
		string id = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)owner).id;
		((GObject)owner).text = LanguagesManager.GetDesc(id);
		Describe_t = (GTextField)((GComponent)this).GetChild("Describe_t");
		string id2 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)Describe_t).id;
		((GObject)Describe_t).text = LanguagesManager.GetDesc(id2);
		gradeTitle = (GTextField)((GComponent)this).GetChild("gradeTitle");
		string id3 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)gradeTitle).id;
		((GObject)gradeTitle).text = LanguagesManager.GetDesc(id3);
		Level_t = (GTextField)((GComponent)this).GetChild("Level_t");
		string id4 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)Level_t).id;
		((GObject)Level_t).text = LanguagesManager.GetDesc(id4);
		ConsumptionTitle = (GTextField)((GComponent)this).GetChild("ConsumptionTitle");
		string id5 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)ConsumptionTitle).id;
		((GObject)ConsumptionTitle).text = LanguagesManager.GetDesc(id5);
		Requirement_t = (GTextField)((GComponent)this).GetChild("Requirement_t");
		string id6 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)Requirement_t).id;
		((GObject)Requirement_t).text = LanguagesManager.GetDesc(id6);
		RepairBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("RepairBtn");
		flowerFrame = (GImage)((GComponent)this).GetChild("flowerFrame");
		piece = (GImage)((GComponent)this).GetChild("piece");
		consumptionList = (GList)((GComponent)this).GetChild("consumptionList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id7 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id7);
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id8 = "ui://7ca77a3fgp9d2m".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id8);
	}
}
