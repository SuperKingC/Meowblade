using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_SelectForgeUniversalLegendItem : GComponent
{
	public Controller SelectState;

	public Controller Level;

	public Controller ShowName;

	public Controller ShowCount;

	public GLoader FrameIcon;

	public GImage n9;

	public GImage n10;

	public GLoader Icon;

	public GTextField ItemName;

	public GRichTextField Count;

	public GImage n2;

	public const string URL = "ui://h09dvkcgll2q5ltfd";

	public static string Name = "UI_com_SelectForgeUniversalLegendItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgll2q5ltfd";
	}

	public static UI_com_SelectForgeUniversalLegendItem CreateInstance()
	{
		return (UI_com_SelectForgeUniversalLegendItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_SelectForgeUniversalLegendItem");
	}

	public static UI_com_SelectForgeUniversalLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectForgeUniversalLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgll2q5ltfd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelectState = ((GComponent)this).GetController("SelectState");
		Level = ((GComponent)this).GetController("Level");
		ShowName = ((GComponent)this).GetController("ShowName");
		ShowCount = ((GComponent)this).GetController("ShowCount");
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		Count = (GRichTextField)((GComponent)this).GetChild("Count");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
