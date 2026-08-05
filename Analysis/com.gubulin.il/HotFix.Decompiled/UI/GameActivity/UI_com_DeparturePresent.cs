using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_DeparturePresent : GComponent
{
	public GGraph mask;

	public GList Gifts;

	public const string URL = "ui://29q48tv6jorqax";

	public static string Name = "UI_com_DeparturePresent";

	public static string GetURL()
	{
		return "ui://29q48tv6jorqax";
	}

	public static UI_com_DeparturePresent CreateInstance()
	{
		return (UI_com_DeparturePresent)(object)UIPackage.CreateObject("GameActivity", "com_DeparturePresent");
	}

	public static UI_com_DeparturePresent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DeparturePresent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jorqax", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Gifts = (GList)((GComponent)this).GetChild("Gifts");
	}
}
