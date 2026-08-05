using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Refine : GComponent
{
	public GImage n89;

	public GList PropetryContent;

	public const string URL = "ui://b9wlonaqtpmtd";

	public static string Name = "UI_Refine";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmtd";
	}

	public static UI_Refine CreateInstance()
	{
		return (UI_Refine)(object)UIPackage.CreateObject("LegendItemCultivation", "Refine");
	}

	public static UI_Refine CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Refine).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmtd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n89 = (GImage)((GComponent)this).GetChild("n89");
		PropetryContent = (GList)((GComponent)this).GetChild("PropetryContent");
	}
}
