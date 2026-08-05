using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_AddButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://ax280w58okbc1y";

	public static string Name = "UI_AddButton";

	public static string GetURL()
	{
		return "ui://ax280w58okbc1y";
	}

	public static UI_AddButton CreateInstance()
	{
		return (UI_AddButton)(object)UIPackage.CreateObject("WarOrder", "AddButton");
	}

	public static UI_AddButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
