using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampIcon : GComponent
{
	public Controller CampId;

	public Controller IsFirst;

	public GLoader Icon;

	public GImage n1;

	public const string URL = "ui://hozu168rk7me4s";

	public static string Name = "UI_com_CampIcon";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4s";
	}

	public static UI_com_CampIcon CreateInstance()
	{
		return (UI_com_CampIcon)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampIcon");
	}

	public static UI_com_CampIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		IsFirst = ((GComponent)this).GetController("IsFirst");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
