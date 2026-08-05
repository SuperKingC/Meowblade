using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_Content : GComponent
{
	public UI_com_PreviewContent PreviewContent;

	public UI_com_ContentBottom ContentBottom;

	public const string URL = "ui://7uylntmmkq2dx";

	public static string Name = "UI_com_Content";

	public static string GetURL()
	{
		return "ui://7uylntmmkq2dx";
	}

	public static UI_com_Content CreateInstance()
	{
		return (UI_com_Content)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_Content");
	}

	public static UI_com_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2dx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		PreviewContent = (UI_com_PreviewContent)(object)((GComponent)this).GetChild("PreviewContent");
		ContentBottom = (UI_com_ContentBottom)(object)((GComponent)this).GetChild("ContentBottom");
	}
}
