using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintAttributeListSub : GComponent
{
	public UI_com_OptionalBlueprintAttSelList generalList;

	public const string URL = "ui://h09dvkcguad65lte2";

	public static string Name = "UI_com_OptionalBlueprintAttributeListSub";

	public static string GetURL()
	{
		return "ui://h09dvkcguad65lte2";
	}

	public static UI_com_OptionalBlueprintAttributeListSub CreateInstance()
	{
		return (UI_com_OptionalBlueprintAttributeListSub)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintAttributeListSub");
	}

	public static UI_com_OptionalBlueprintAttributeListSub CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintAttributeListSub).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcguad65lte2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		generalList = (UI_com_OptionalBlueprintAttSelList)(object)((GComponent)this).GetChild("generalList");
	}
}
