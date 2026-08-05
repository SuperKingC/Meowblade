using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Content : GComponent
{
	public UI_com_PreviewContent PreviewContent;

	public UI_com_CostContent CostContent;

	public UI_com_ContentBottom ContentBottom;

	public const string URL = "ui://h09dvkcgjpqa16";

	public static string Name = "UI_com_Content";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqa16";
	}

	public static UI_com_Content CreateInstance()
	{
		return (UI_com_Content)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Content");
	}

	public static UI_com_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqa16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		PreviewContent = (UI_com_PreviewContent)(object)((GComponent)this).GetChild("PreviewContent");
		CostContent = (UI_com_CostContent)(object)((GComponent)this).GetChild("CostContent");
		ContentBottom = (UI_com_ContentBottom)(object)((GComponent)this).GetChild("ContentBottom");
	}
}
