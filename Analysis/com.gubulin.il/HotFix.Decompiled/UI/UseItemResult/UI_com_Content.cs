using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_com_Content : GComponent
{
	public GList ItemList;

	public const string URL = "ui://800w3r8rez1c5";

	public static string Name = "UI_com_Content";

	public static string GetURL()
	{
		return "ui://800w3r8rez1c5";
	}

	public static UI_com_Content CreateInstance()
	{
		return (UI_com_Content)(object)UIPackage.CreateObject("UseItemResult", "com_Content");
	}

	public static UI_com_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
	}
}
