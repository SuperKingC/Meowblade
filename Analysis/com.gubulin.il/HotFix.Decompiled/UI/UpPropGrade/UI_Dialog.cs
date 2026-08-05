using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_Dialog : GComponent
{
	public GImage back;

	public GGraph n20;

	public GGraph n21;

	public UI_DialogRightContent RightContent;

	public UI_DialogLeftContent LeftContent;

	public UI_ProductUpGradeButton ProductUpGradeBtn;

	public GTextField upgradeTitle;

	public GButton exitBtn;

	public UI_DialogMiddleContent MiddleContent;

	public const string URL = "ui://blindbbgmol0m";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://blindbbgmol0m";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("UpPropGrade", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n20 = (GGraph)((GComponent)this).GetChild("n20");
		n21 = (GGraph)((GComponent)this).GetChild("n21");
		RightContent = (UI_DialogRightContent)(object)((GComponent)this).GetChild("RightContent");
		LeftContent = (UI_DialogLeftContent)(object)((GComponent)this).GetChild("LeftContent");
		ProductUpGradeBtn = (UI_ProductUpGradeButton)(object)((GComponent)this).GetChild("ProductUpGradeBtn");
		upgradeTitle = (GTextField)((GComponent)this).GetChild("upgradeTitle");
		string id = "ui://blindbbgmol0m".Replace("ui://", "") + "-" + ((GObject)upgradeTitle).id;
		((GObject)upgradeTitle).text = LanguagesManager.GetDesc(id);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		MiddleContent = (UI_DialogMiddleContent)(object)((GComponent)this).GetChild("MiddleContent");
	}
}
