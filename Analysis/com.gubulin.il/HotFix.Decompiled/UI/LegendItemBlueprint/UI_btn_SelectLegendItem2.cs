using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_SelectLegendItem2 : GButton
{
	public Controller button;

	public GButton n0;

	public const string URL = "ui://h09dvkcgtvyq5ltfc";

	public static string Name = "UI_btn_SelectLegendItem2";

	public static string GetURL()
	{
		return "ui://h09dvkcgtvyq5ltfc";
	}

	public static UI_btn_SelectLegendItem2 CreateInstance()
	{
		return (UI_btn_SelectLegendItem2)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_SelectLegendItem2");
	}

	public static UI_btn_SelectLegendItem2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectLegendItem2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgtvyq5ltfc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GButton)((GComponent)this).GetChild("n0");
	}
}
