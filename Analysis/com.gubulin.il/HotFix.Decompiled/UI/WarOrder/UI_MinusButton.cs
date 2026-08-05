using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_MinusButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://ax280w58okbc20";

	public static string Name = "UI_MinusButton";

	public static string GetURL()
	{
		return "ui://ax280w58okbc20";
	}

	public static UI_MinusButton CreateInstance()
	{
		return (UI_MinusButton)(object)UIPackage.CreateObject("WarOrder", "MinusButton");
	}

	public static UI_MinusButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MinusButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
