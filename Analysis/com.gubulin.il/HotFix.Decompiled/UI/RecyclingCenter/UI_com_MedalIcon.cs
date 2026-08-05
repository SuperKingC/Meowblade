using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_com_MedalIcon : GComponent
{
	public GList medalList;

	public const string URL = "ui://72poq8plpeoc32";

	public static string Name = "UI_com_MedalIcon";

	public static string GetURL()
	{
		return "ui://72poq8plpeoc32";
	}

	public static UI_com_MedalIcon CreateInstance()
	{
		return (UI_com_MedalIcon)(object)UIPackage.CreateObject("RecyclingCenter", "com_MedalIcon");
	}

	public static UI_com_MedalIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plpeoc32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}
