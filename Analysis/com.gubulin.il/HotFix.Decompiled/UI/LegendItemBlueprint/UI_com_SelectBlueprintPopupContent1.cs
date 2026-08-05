using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_SelectBlueprintPopupContent1 : GComponent
{
	public GRichTextField title;

	public const string URL = "ui://h09dvkcgm8v55ltfn";

	public static string Name = "UI_com_SelectBlueprintPopupContent1";

	public static string GetURL()
	{
		return "ui://h09dvkcgm8v55ltfn";
	}

	public static UI_com_SelectBlueprintPopupContent1 CreateInstance()
	{
		return (UI_com_SelectBlueprintPopupContent1)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_SelectBlueprintPopupContent1");
	}

	public static UI_com_SelectBlueprintPopupContent1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectBlueprintPopupContent1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgm8v55ltfn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		title = (GRichTextField)((GComponent)this).GetChild("title");
	}
}
