using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_AchimentListWithMask : GComponent
{
	public const string URL = "ui://29q48tv6hrkaf4j";

	public static string Name = "UI_com_AchimentListWithMask";

	public static string GetURL()
	{
		return "ui://29q48tv6hrkaf4j";
	}

	public static UI_com_AchimentListWithMask CreateInstance()
	{
		return (UI_com_AchimentListWithMask)(object)UIPackage.CreateObject("GameActivity", "com_AchimentListWithMask");
	}

	public static UI_com_AchimentListWithMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AchimentListWithMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hrkaf4j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
