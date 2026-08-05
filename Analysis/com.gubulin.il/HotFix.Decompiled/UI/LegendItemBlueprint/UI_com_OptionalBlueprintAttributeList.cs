using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintAttributeList : GComponent
{
	public UI_com_OptionalBlueprintAttSelList setList;

	public UI_com_OptionalBlueprintAttSelList specialList;

	public UI_com_OptionalBlueprintAttSelList generalList;

	public GGroup mainAtt;

	public const string URL = "ui://h09dvkcgb8pv5lte1";

	public static string Name = "UI_com_OptionalBlueprintAttributeList";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5lte1";
	}

	public static UI_com_OptionalBlueprintAttributeList CreateInstance()
	{
		return (UI_com_OptionalBlueprintAttributeList)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintAttributeList");
	}

	public static UI_com_OptionalBlueprintAttributeList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintAttributeList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5lte1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		setList = (UI_com_OptionalBlueprintAttSelList)(object)((GComponent)this).GetChild("setList");
		specialList = (UI_com_OptionalBlueprintAttSelList)(object)((GComponent)this).GetChild("specialList");
		generalList = (UI_com_OptionalBlueprintAttSelList)(object)((GComponent)this).GetChild("generalList");
		mainAtt = (GGroup)((GComponent)this).GetChild("mainAtt");
	}
}
