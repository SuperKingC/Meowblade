using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_increaseButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://7dantnbibunlt8t";

	public static string Name = "UI_increaseButton";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8t";
	}

	public static UI_increaseButton CreateInstance()
	{
		return (UI_increaseButton)(object)UIPackage.CreateObject("SoldierCultivate", "increaseButton");
	}

	public static UI_increaseButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_increaseButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
