using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_LegendItem : GButton
{
	public Controller button;

	public Controller Type;

	public Controller ClassController;

	public GGraph SfxBack;

	public GLoader FrameIcon;

	public GLoader Icon;

	public GLoader ClassIcon;

	public GList ClassList;

	public GTextField name;

	public const string URL = "ui://xogvri2hs2vzn";

	public static string Name = "UI_LegendItem";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzn";
	}

	public static UI_LegendItem CreateInstance()
	{
		return (UI_LegendItem)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItem");
	}

	public static UI_LegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		ClassController = ((GComponent)this).GetController("ClassController");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
		ClassList = (GList)((GComponent)this).GetChild("ClassList");
		name = (GTextField)((GComponent)this).GetChild("name");
	}
}
