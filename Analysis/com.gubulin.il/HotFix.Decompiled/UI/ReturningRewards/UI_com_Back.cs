using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Back : GComponent
{
	public GList Prizes;

	public const string URL = "ui://rx5ntv98win2y";

	public static string Name = "UI_com_Back";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2y";
	}

	public static UI_com_Back CreateInstance()
	{
		return (UI_com_Back)(object)UIPackage.CreateObject("ReturningRewards", "com_Back");
	}

	public static UI_com_Back CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Back).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Prizes = (GList)((GComponent)this).GetChild("Prizes");
	}
}
