using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_SpecialItem : GButton
{
	public Controller 是否特有宝物蓝图;

	public GImage n141;

	public GLoader back;

	public GLoader icon;

	public GTextField ItemName;

	public const string URL = "ui://k19peou7qix93h";

	public static string Name = "UI_SpecialItem";

	public static string GetURL()
	{
		return "ui://k19peou7qix93h";
	}

	public static UI_SpecialItem CreateInstance()
	{
		return (UI_SpecialItem)(object)UIPackage.CreateObject("GvGExpeditionHall", "SpecialItem");
	}

	public static UI_SpecialItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpecialItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		是否特有宝物蓝图 = ((GComponent)this).GetController("是否特有宝物蓝图");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
	}
}
