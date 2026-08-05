using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_LegendItemReplace : GButton
{
	public Controller button;

	public Controller TypeController;

	public Controller ClassController;

	public GLoader FrameIcon;

	public GLoader Icon;

	public GLoader LvFrame;

	public GRichTextField Level;

	public GButton SoldierIcon;

	public GLoader ClassIcon;

	public const string URL = "ui://b9wlonaqh4zmhf";

	public static string Name = "UI_LegendItemReplace";

	public static string GetURL()
	{
		return "ui://b9wlonaqh4zmhf";
	}

	public static UI_LegendItemReplace CreateInstance()
	{
		return (UI_LegendItemReplace)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemReplace");
	}

	public static UI_LegendItemReplace CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemReplace).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqh4zmhf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		ClassController = ((GComponent)this).GetController("ClassController");
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		LvFrame = (GLoader)((GComponent)this).GetChild("LvFrame");
		Level = (GRichTextField)((GComponent)this).GetChild("Level");
		string id = "ui://b9wlonaqh4zmhf".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id);
		SoldierIcon = (GButton)((GComponent)this).GetChild("SoldierIcon");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
	}
}
