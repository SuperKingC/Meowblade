using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_DialogMiddleContent : GComponent
{
	public GButton ConsumptionItem;

	public const string URL = "ui://47lbpgx9i0qy53";

	public static string Name = "UI_DialogMiddleContent";

	public static string GetURL()
	{
		return "ui://47lbpgx9i0qy53";
	}

	public static UI_DialogMiddleContent CreateInstance()
	{
		return (UI_DialogMiddleContent)(object)UIPackage.CreateObject("Tips", "DialogMiddleContent");
	}

	public static UI_DialogMiddleContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogMiddleContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9i0qy53", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
	}
}
