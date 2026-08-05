using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_GetSelfRankBtn : GButton
{
	public Controller button;

	public UI_RetreatBtn ConfirmBtn;

	public const string URL = "ui://82mo10n5iirg6h";

	public static string Name = "UI_GetSelfRankBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5iirg6h";
	}

	public static UI_GetSelfRankBtn CreateInstance()
	{
		return (UI_GetSelfRankBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "GetSelfRankBtn");
	}

	public static UI_GetSelfRankBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GetSelfRankBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5iirg6h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ConfirmBtn = (UI_RetreatBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
