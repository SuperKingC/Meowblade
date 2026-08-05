using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_SoldierInfoPanelClickBtn : GButton
{
	public Controller button;

	public const string URL = "ui://72fujxhkoomc28";

	public static string Name = "UI_SoldierInfoPanelClickBtn";

	public static string GetURL()
	{
		return "ui://72fujxhkoomc28";
	}

	public static UI_SoldierInfoPanelClickBtn CreateInstance()
	{
		return (UI_SoldierInfoPanelClickBtn)(object)UIPackage.CreateObject("RecruitingCamp", "SoldierInfoPanelClickBtn");
	}

	public static UI_SoldierInfoPanelClickBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierInfoPanelClickBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkoomc28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
