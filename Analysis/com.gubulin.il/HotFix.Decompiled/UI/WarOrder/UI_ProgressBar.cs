using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_ProgressBar : GProgressBar
{
	public GImage back;

	public GImage Bar;

	public const string URL = "ui://ax280w58p8iip";

	public static string Name = "UI_ProgressBar";

	public static string GetURL()
	{
		return "ui://ax280w58p8iip";
	}

	public static UI_ProgressBar CreateInstance()
	{
		return (UI_ProgressBar)(object)UIPackage.CreateObject("WarOrder", "ProgressBar");
	}

	public static UI_ProgressBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58p8iip", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Bar = (GImage)((GComponent)this).GetChild("Bar");
	}
}
