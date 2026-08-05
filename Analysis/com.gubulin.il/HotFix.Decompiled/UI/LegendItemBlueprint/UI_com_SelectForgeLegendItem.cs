using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_SelectForgeLegendItem : GComponent
{
	public Controller SelectState;

	public Controller LockState;

	public UI_com_LegendItem LegendItem;

	public GImage n2;

	public GImage Lock;

	public const string URL = "ui://h09dvkcgi56w4a";

	public static string Name = "UI_com_SelectForgeLegendItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgi56w4a";
	}

	public static UI_com_SelectForgeLegendItem CreateInstance()
	{
		return (UI_com_SelectForgeLegendItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_SelectForgeLegendItem");
	}

	public static UI_com_SelectForgeLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectForgeLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgi56w4a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelectState = ((GComponent)this).GetController("SelectState");
		LockState = ((GComponent)this).GetController("LockState");
		LegendItem = (UI_com_LegendItem)(object)((GComponent)this).GetChild("LegendItem");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Lock = (GImage)((GComponent)this).GetChild("Lock");
	}
}
