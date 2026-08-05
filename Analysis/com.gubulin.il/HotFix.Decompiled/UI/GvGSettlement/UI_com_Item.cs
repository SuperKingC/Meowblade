using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_Item : GComponent
{
	public GImage n191;

	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://91jxdrkanc8fz";

	public static string Name = "UI_com_Item";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8fz";
	}

	public static UI_com_Item CreateInstance()
	{
		return (UI_com_Item)(object)UIPackage.CreateObject("GvGSettlement", "com_Item");
	}

	public static UI_com_Item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8fz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n191 = (GImage)((GComponent)this).GetChild("n191");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
