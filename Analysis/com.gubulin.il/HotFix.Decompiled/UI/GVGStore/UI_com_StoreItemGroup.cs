using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_StoreItemGroup : GComponent
{
	public UI_com_StoreItem StoreItem0;

	public UI_com_StoreItem StoreItem1;

	public UI_com_StoreItem StoreItem2;

	public Transition t0;

	public const string URL = "ui://fvc33k3ggyk31r";

	public static string Name = "UI_com_StoreItemGroup";

	public static string GetURL()
	{
		return "ui://fvc33k3ggyk31r";
	}

	public static UI_com_StoreItemGroup CreateInstance()
	{
		return (UI_com_StoreItemGroup)(object)UIPackage.CreateObject("GVGStore", "com_StoreItemGroup");
	}

	public static UI_com_StoreItemGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreItemGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ggyk31r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		StoreItem0 = (UI_com_StoreItem)(object)((GComponent)this).GetChild("StoreItem0");
		StoreItem1 = (UI_com_StoreItem)(object)((GComponent)this).GetChild("StoreItem1");
		StoreItem2 = (UI_com_StoreItem)(object)((GComponent)this).GetChild("StoreItem2");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
