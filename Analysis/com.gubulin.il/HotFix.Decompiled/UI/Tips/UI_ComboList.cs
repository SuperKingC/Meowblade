using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ComboList : GComponent
{
	public const string URL = "ui://47lbpgx9yzxz3p";

	public static string Name = "UI_ComboList";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3p";
	}

	public static UI_ComboList CreateInstance()
	{
		return (UI_ComboList)(object)UIPackage.CreateObject("Tips", "ComboList");
	}

	public static UI_ComboList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
