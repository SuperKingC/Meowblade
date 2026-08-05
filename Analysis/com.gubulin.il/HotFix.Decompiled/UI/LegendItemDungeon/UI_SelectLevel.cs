using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_SelectLevel : GButton
{
	public Controller button;

	public const string URL = "ui://2eraz3j9y9rzo";

	public static string Name = "UI_SelectLevel";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzo";
	}

	public static UI_SelectLevel CreateInstance()
	{
		return (UI_SelectLevel)(object)UIPackage.CreateObject("LegendItemDungeon", "SelectLevel");
	}

	public static UI_SelectLevel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectLevel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
