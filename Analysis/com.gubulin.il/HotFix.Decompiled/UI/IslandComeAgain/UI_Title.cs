using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_Title : GComponent
{
	public GImage n0;

	public GLoader name;

	public GTextField buildingName;

	public const string URL = "ui://k2sprg26q73t9t";

	public static string Name = "UI_Title";

	public static string GetURL()
	{
		return "ui://k2sprg26q73t9t";
	}

	public static UI_Title CreateInstance()
	{
		return (UI_Title)(object)UIPackage.CreateObject("IslandComeAgain", "Title");
	}

	public static UI_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26q73t9t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		name = (GLoader)((GComponent)this).GetChild("name");
		buildingName = (GTextField)((GComponent)this).GetChild("buildingName");
	}
}
