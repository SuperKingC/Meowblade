using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_RandomLegendItem : GComponent
{
	public GLoader FrameIcon;

	public GLoader Icon;

	public GLoader ClassIcon;

	public const string URL = "ui://se4hok019gdek";

	public static string Name = "UI_com_RandomLegendItem";

	public static string GetURL()
	{
		return "ui://se4hok019gdek";
	}

	public static UI_com_RandomLegendItem CreateInstance()
	{
		return (UI_com_RandomLegendItem)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_RandomLegendItem");
	}

	public static UI_com_RandomLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RandomLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok019gdek", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
	}
}
