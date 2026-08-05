using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_BlueprintDialog : GComponent
{
	public GImage back;

	public UI_DialogLeftContent LeftContent;

	public UI_DialogRightContent RightContent;

	public UI_BlueprintUpGradeButton BlueprintUpGradeBtn;

	public GTextField title;

	public const string URL = "ui://blindbbgio2ys";

	public static string Name = "UI_BlueprintDialog";

	public static string GetURL()
	{
		return "ui://blindbbgio2ys";
	}

	public static UI_BlueprintDialog CreateInstance()
	{
		return (UI_BlueprintDialog)(object)UIPackage.CreateObject("UpPropGrade", "BlueprintDialog");
	}

	public static UI_BlueprintDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlueprintDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgio2ys", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		LeftContent = (UI_DialogLeftContent)(object)((GComponent)this).GetChild("LeftContent");
		RightContent = (UI_DialogRightContent)(object)((GComponent)this).GetChild("RightContent");
		BlueprintUpGradeBtn = (UI_BlueprintUpGradeButton)(object)((GComponent)this).GetChild("BlueprintUpGradeBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://blindbbgio2ys".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
