using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_btn_BonusItemWrapper : GButton
{
	public Controller button;

	public UI_com_BonusItem BonusItem;

	public const string URL = "ui://800w3r8rez1c6";

	public static string Name = "UI_btn_BonusItemWrapper";

	public static string GetURL()
	{
		return "ui://800w3r8rez1c6";
	}

	public static UI_btn_BonusItemWrapper CreateInstance()
	{
		return (UI_btn_BonusItemWrapper)(object)UIPackage.CreateObject("UseItemResult", "btn_BonusItemWrapper");
	}

	public static UI_btn_BonusItemWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BonusItemWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		BonusItem = (UI_com_BonusItem)(object)((GComponent)this).GetChild("BonusItem");
	}
}
