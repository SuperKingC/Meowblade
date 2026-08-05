using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItems;

public class UI_btn_LegendItem : GButton
{
	public Controller button;

	public Controller Type;

	public GButton Content;

	public GImage Lock;

	public const string URL = "ui://l6qef30pcae1a";

	public static string Name = "UI_btn_LegendItem";

	public static string GetURL()
	{
		return "ui://l6qef30pcae1a";
	}

	public static UI_btn_LegendItem CreateInstance()
	{
		return (UI_btn_LegendItem)(object)UIPackage.CreateObject("LegendItems", "btn_LegendItem");
	}

	public static UI_btn_LegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pcae1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Content = (GButton)((GComponent)this).GetChild("Content");
		Lock = (GImage)((GComponent)this).GetChild("Lock");
	}
}
