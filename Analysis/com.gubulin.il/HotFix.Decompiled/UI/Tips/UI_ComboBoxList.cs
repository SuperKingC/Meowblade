using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ComboBoxList : GComponent
{
	public const string URL = "ui://47lbpgx9yzxz3r";

	public static string Name = "UI_ComboBoxList";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3r";
	}

	public static UI_ComboBoxList CreateInstance()
	{
		return (UI_ComboBoxList)(object)UIPackage.CreateObject("Tips", "ComboBoxList");
	}

	public static UI_ComboBoxList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBoxList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
