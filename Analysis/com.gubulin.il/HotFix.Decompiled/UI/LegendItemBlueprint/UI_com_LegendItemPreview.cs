using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemPreview : GComponent
{
	public UI_com_LegendItemEntryPreview Content;

	public UI_com_ContentBottom ContentBottom;

	public const string URL = "ui://h09dvkcglxbt3y";

	public static string Name = "UI_com_LegendItemPreview";

	public static string GetURL()
	{
		return "ui://h09dvkcglxbt3y";
	}

	public static UI_com_LegendItemPreview CreateInstance()
	{
		return (UI_com_LegendItemPreview)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemPreview");
	}

	public static UI_com_LegendItemPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcglxbt3y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Content = (UI_com_LegendItemEntryPreview)(object)((GComponent)this).GetChild("Content");
		ContentBottom = (UI_com_ContentBottom)(object)((GComponent)this).GetChild("ContentBottom");
	}
}
