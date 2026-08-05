using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalSelectPropertyBtn : GButton
{
	public Controller State;

	public Controller showSelectIcon;

	public Controller isSelect;

	public GImage selectProperty;

	public GImage n6;

	public GImage n8;

	public GImage n7;

	public GRichTextField content;

	public GImage n14;

	public GImage n18;

	public GGroup Property;

	public GImage selectPropertyOutline;

	public const string URL = "ui://h09dvkcgt49p5ltds";

	public static string Name = "UI_com_OptionalSelectPropertyBtn";

	public static string GetURL()
	{
		return "ui://h09dvkcgt49p5ltds";
	}

	public static UI_com_OptionalSelectPropertyBtn CreateInstance()
	{
		return (UI_com_OptionalSelectPropertyBtn)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalSelectPropertyBtn");
	}

	public static UI_com_OptionalSelectPropertyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalSelectPropertyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgt49p5ltds", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		showSelectIcon = ((GComponent)this).GetController("showSelectIcon");
		isSelect = ((GComponent)this).GetController("isSelect");
		selectProperty = (GImage)((GComponent)this).GetChild("selectProperty");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		content = (GRichTextField)((GComponent)this).GetChild("content");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Property = (GGroup)((GComponent)this).GetChild("Property");
		selectPropertyOutline = (GImage)((GComponent)this).GetChild("selectPropertyOutline");
	}
}
