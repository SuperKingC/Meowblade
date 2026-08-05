using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ClickAssistantBtn : GButton
{
	public Controller button;

	public Controller Status;

	public UI_btn_01 ConfirmBtn;

	public const string URL = "ui://82mo10n5nvzsdns";

	public static string Name = "UI_ClickAssistantBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5nvzsdns";
	}

	public static UI_ClickAssistantBtn CreateInstance()
	{
		return (UI_ClickAssistantBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ClickAssistantBtn");
	}

	public static UI_ClickAssistantBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClickAssistantBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5nvzsdns", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		ConfirmBtn = (UI_btn_01)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
