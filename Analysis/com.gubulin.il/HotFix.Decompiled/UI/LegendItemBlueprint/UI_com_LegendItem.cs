using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItem : GComponent
{
	public Controller Level;

	public Controller Type;

	public Controller AvailableState;

	public GLoader FrameIcon;

	public GLoader Icon;

	public GLoader LvFrame;

	public GRichTextField LevelValue;

	public GButton SoldierIcon;

	public GLoader ClassIcon;

	public GTextField name;

	public const string URL = "ui://h09dvkcgpqzh2w";

	public static string Name = "UI_com_LegendItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh2w";
	}

	public static UI_com_LegendItem CreateInstance()
	{
		return (UI_com_LegendItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItem");
	}

	public static UI_com_LegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Level = ((GComponent)this).GetController("Level");
		Type = ((GComponent)this).GetController("Type");
		AvailableState = ((GComponent)this).GetController("AvailableState");
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		LvFrame = (GLoader)((GComponent)this).GetChild("LvFrame");
		LevelValue = (GRichTextField)((GComponent)this).GetChild("LevelValue");
		string id = "ui://h09dvkcgpqzh2w".Replace("ui://", "") + "-" + ((GObject)LevelValue).id;
		((GObject)LevelValue).text = LanguagesManager.GetDesc(id);
		SoldierIcon = (GButton)((GComponent)this).GetChild("SoldierIcon");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
		name = (GTextField)((GComponent)this).GetChild("name");
	}
}
