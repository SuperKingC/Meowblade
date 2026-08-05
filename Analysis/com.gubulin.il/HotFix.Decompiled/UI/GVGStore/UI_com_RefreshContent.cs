using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_RefreshContent : GComponent
{
	public GButton ConsumptionItem;

	public const string URL = "ui://fvc33k3gv6i7z";

	public static string Name = "UI_com_RefreshContent";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7z";
	}

	public static UI_com_RefreshContent CreateInstance()
	{
		return (UI_com_RefreshContent)(object)UIPackage.CreateObject("GVGStore", "com_RefreshContent");
	}

	public static UI_com_RefreshContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RefreshContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
