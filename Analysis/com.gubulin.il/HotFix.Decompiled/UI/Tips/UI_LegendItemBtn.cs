using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_LegendItemBtn : GButton
{
	public Controller button;

	public GButton Content;

	public const string URL = "ui://47lbpgx97aku58";

	public static string Name = "UI_LegendItemBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx97aku58";
	}

	public static UI_LegendItemBtn CreateInstance()
	{
		return (UI_LegendItemBtn)(object)UIPackage.CreateObject("Tips", "LegendItemBtn");
	}

	public static UI_LegendItemBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx97aku58", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Content = (GButton)((GComponent)this).GetChild("Content");
	}
}
