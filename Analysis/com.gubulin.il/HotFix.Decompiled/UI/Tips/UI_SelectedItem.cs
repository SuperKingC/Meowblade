using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SelectedItem : GComponent
{
	public GLoader SelectedIcon;

	public GTextField SelectedName;

	public const string URL = "ui://47lbpgx9qtr65k";

	public static string Name = "UI_SelectedItem";

	public static string GetURL()
	{
		return "ui://47lbpgx9qtr65k";
	}

	public static UI_SelectedItem CreateInstance()
	{
		return (UI_SelectedItem)(object)UIPackage.CreateObject("Tips", "SelectedItem");
	}

	public static UI_SelectedItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectedItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9qtr65k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelectedIcon = (GLoader)((GComponent)this).GetChild("SelectedIcon");
		SelectedName = (GTextField)((GComponent)this).GetChild("SelectedName");
	}
}
