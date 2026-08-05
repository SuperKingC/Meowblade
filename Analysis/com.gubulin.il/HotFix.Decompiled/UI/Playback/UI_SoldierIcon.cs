using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_SoldierIcon : GButton
{
	public Controller button;

	public UI_armItem1 icon;

	public const string URL = "ui://9u6qpm6pt6gca";

	public static string Name = "UI_SoldierIcon";

	public static string GetURL()
	{
		return "ui://9u6qpm6pt6gca";
	}

	public static UI_SoldierIcon CreateInstance()
	{
		return (UI_SoldierIcon)(object)UIPackage.CreateObject("Playback", "SoldierIcon");
	}

	public static UI_SoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pt6gca", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (UI_armItem1)(object)((GComponent)this).GetChild("icon");
	}
}
