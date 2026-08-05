using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_FrameTreasure : GComponent
{
	public UI_com_LegendItem Item;

	public GImage n10;

	public Transition t0;

	public const string URL = "ui://h09dvkcgi2xa3i";

	public static string Name = "UI_com_FrameTreasure";

	public static string GetURL()
	{
		return "ui://h09dvkcgi2xa3i";
	}

	public static UI_com_FrameTreasure CreateInstance()
	{
		return (UI_com_FrameTreasure)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_FrameTreasure");
	}

	public static UI_com_FrameTreasure CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FrameTreasure).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgi2xa3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Item = (UI_com_LegendItem)(object)((GComponent)this).GetChild("Item");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
