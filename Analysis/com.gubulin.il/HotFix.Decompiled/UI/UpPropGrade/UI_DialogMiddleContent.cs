using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_DialogMiddleContent : GComponent
{
	public GTextField ConsumptionTitle;

	public GButton ConsumptionItem;

	public const string URL = "ui://blindbbgvecsq";

	public static string Name = "UI_DialogMiddleContent";

	public static string GetURL()
	{
		return "ui://blindbbgvecsq";
	}

	public static UI_DialogMiddleContent CreateInstance()
	{
		return (UI_DialogMiddleContent)(object)UIPackage.CreateObject("UpPropGrade", "DialogMiddleContent");
	}

	public static UI_DialogMiddleContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogMiddleContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgvecsq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ConsumptionTitle = (GTextField)((GComponent)this).GetChild("ConsumptionTitle");
		string id = "ui://blindbbgvecsq".Replace("ui://", "") + "-" + ((GObject)ConsumptionTitle).id;
		((GObject)ConsumptionTitle).text = LanguagesManager.GetDesc(id);
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
	}
}
