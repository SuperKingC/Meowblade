using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_panelTitle : GComponent
{
	public GImage n0;

	public GTextField buildingName;

	public const string URL = "ui://jl0c82y5fmsk9";

	public static string Name = "UI_com_panelTitle";

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk9";
	}

	public static UI_com_panelTitle CreateInstance()
	{
		return (UI_com_panelTitle)(object)UIPackage.CreateObject("WeekActivity", "com_panelTitle");
	}

	public static UI_com_panelTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_panelTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		buildingName = (GTextField)((GComponent)this).GetChild("buildingName");
		string id = "ui://jl0c82y5fmsk9".Replace("ui://", "") + "-" + ((GObject)buildingName).id;
		((GObject)buildingName).text = LanguagesManager.GetDesc(id);
	}
}
