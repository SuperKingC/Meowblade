using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SettingBtn : GButton
{
	public Controller button;

	public UI_RetreatBtn ConfirmBtn;

	public GGraph n6;

	public GTextInput level;

	public const string URL = "ui://82mo10n5gox2m";

	public static string Name = "UI_SettingBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5gox2m";
	}

	public static UI_SettingBtn CreateInstance()
	{
		return (UI_SettingBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SettingBtn");
	}

	public static UI_SettingBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SettingBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gox2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ConfirmBtn = (UI_RetreatBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		level = (GTextInput)((GComponent)this).GetChild("level");
	}
}
