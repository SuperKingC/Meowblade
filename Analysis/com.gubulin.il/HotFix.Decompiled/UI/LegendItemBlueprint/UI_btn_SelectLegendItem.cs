using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_SelectLegendItem : GButton
{
	public Controller button;

	public GImage n2;

	public GButton n0;

	public GImage n3;

	public const string URL = "ui://h09dvkcgb8pv5ltdy";

	public static string Name = "UI_btn_SelectLegendItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5ltdy";
	}

	public static UI_btn_SelectLegendItem CreateInstance()
	{
		return (UI_btn_SelectLegendItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_SelectLegendItem");
	}

	public static UI_btn_SelectLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5ltdy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GButton)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
