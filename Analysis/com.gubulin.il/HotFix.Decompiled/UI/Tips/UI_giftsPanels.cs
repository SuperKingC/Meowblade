using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_giftsPanels : GComponent
{
	public GList materialList;

	public const string URL = "ui://47lbpgx9otto3h";

	public static string Name = "UI_giftsPanels";

	public static string GetURL()
	{
		return "ui://47lbpgx9otto3h";
	}

	public static UI_giftsPanels CreateInstance()
	{
		return (UI_giftsPanels)(object)UIPackage.CreateObject("Tips", "giftsPanels");
	}

	public static UI_giftsPanels CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_giftsPanels).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9otto3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		materialList = (GList)((GComponent)this).GetChild("materialList");
	}
}
