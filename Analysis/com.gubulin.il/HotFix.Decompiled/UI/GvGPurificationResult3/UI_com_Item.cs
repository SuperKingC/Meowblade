using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurificationResult3;

public class UI_com_Item : GComponent
{
	public GLoader ItemIcon;

	public GTextField ItemNumber;

	public const string URL = "ui://l9ol6w5fsmdj2";

	public static string Name = "UI_com_Item";

	public static string GetURL()
	{
		return "ui://l9ol6w5fsmdj2";
	}

	public static UI_com_Item CreateInstance()
	{
		return (UI_com_Item)(object)UIPackage.CreateObject("GvGPurificationResult3", "com_Item");
	}

	public static UI_com_Item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		ItemNumber = (GTextField)((GComponent)this).GetChild("ItemNumber");
	}
}
