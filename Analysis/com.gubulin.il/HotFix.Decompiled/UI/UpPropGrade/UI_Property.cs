using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_Property : GComponent
{
	public GTextField title;

	public GImage arrow;

	public GTextField Current_t;

	public GTextField Next_t;

	public const string URL = "ui://blindbbgmol0p";

	public static string Name = "UI_Property";

	public static string GetURL()
	{
		return "ui://blindbbgmol0p";
	}

	public static UI_Property CreateInstance()
	{
		return (UI_Property)(object)UIPackage.CreateObject("UpPropGrade", "Property");
	}

	public static UI_Property CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Property).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		title = (GTextField)((GComponent)this).GetChild("title");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		Current_t = (GTextField)((GComponent)this).GetChild("Current_t");
		Next_t = (GTextField)((GComponent)this).GetChild("Next_t");
	}
}
