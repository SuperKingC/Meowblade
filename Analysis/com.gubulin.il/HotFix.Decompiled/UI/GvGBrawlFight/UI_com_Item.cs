using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_Item : GComponent
{
	public Controller button;

	public Controller IsExtra;

	public GLoader Icon;

	public GTextField Num;

	public GImage n11;

	public const string URL = "ui://hozu168rniiv6m";

	public static string Name = "UI_com_Item";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6m";
	}

	public static UI_com_Item CreateInstance()
	{
		return (UI_com_Item)(object)UIPackage.CreateObject("GvGBrawlFight", "com_Item");
	}

	public static UI_com_Item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsExtra = ((GComponent)this).GetController("IsExtra");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
