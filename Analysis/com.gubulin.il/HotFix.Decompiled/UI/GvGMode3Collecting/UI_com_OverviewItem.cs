using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_com_OverviewItem : GComponent
{
	public Controller LastType;

	public GImage n7;

	public UI_goodItemLarge Icon;

	public GTextField ItemName;

	public GTextField Num;

	public const string URL = "ui://n2y4xuvarxuq9";

	public static string Name = "UI_com_OverviewItem";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuq9";
	}

	public static UI_com_OverviewItem CreateInstance()
	{
		return (UI_com_OverviewItem)(object)UIPackage.CreateObject("GvGMode3Collecting", "com_OverviewItem");
	}

	public static UI_com_OverviewItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OverviewItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LastType = ((GComponent)this).GetController("LastType");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Icon = (UI_goodItemLarge)(object)((GComponent)this).GetChild("Icon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
