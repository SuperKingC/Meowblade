using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_FoodItem : GButton
{
	public Controller button;

	public Controller HasItem;

	public GLoader FoodItemIcon;

	public GImage FoodIcon;

	public GTextField Effect;

	public GGroup n11;

	public GButton hightLight;

	public GTextField Count;

	public const string URL = "ui://u6x0b1gnsvf66q";

	public static string Name = "UI_com_FoodItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsvf66q";
	}

	public static UI_com_FoodItem CreateInstance()
	{
		return (UI_com_FoodItem)(object)UIPackage.CreateObject("GvGShipDetail", "com_FoodItem");
	}

	public static UI_com_FoodItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FoodItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsvf66q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasItem = ((GComponent)this).GetController("HasItem");
		FoodItemIcon = (GLoader)((GComponent)this).GetChild("FoodItemIcon");
		FoodIcon = (GImage)((GComponent)this).GetChild("FoodIcon");
		Effect = (GTextField)((GComponent)this).GetChild("Effect");
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		hightLight = (GButton)((GComponent)this).GetChild("hightLight");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
