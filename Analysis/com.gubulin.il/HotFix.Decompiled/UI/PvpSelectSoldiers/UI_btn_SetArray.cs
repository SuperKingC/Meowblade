using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_SetArray : GButton
{
	public Controller IsArraySetFinished;

	public Controller MatchStage;

	public GButton SetArrayBtn;

	public GImage n82;

	public const string URL = "ui://82mo10n5uwtxjdrr";

	public static string Name = "UI_btn_SetArray";

	public static string GetURL()
	{
		return "ui://82mo10n5uwtxjdrr";
	}

	public static UI_btn_SetArray CreateInstance()
	{
		return (UI_btn_SetArray)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_SetArray");
	}

	public static UI_btn_SetArray CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SetArray).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uwtxjdrr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsArraySetFinished = ((GComponent)this).GetController("IsArraySetFinished");
		MatchStage = ((GComponent)this).GetController("MatchStage");
		SetArrayBtn = (GButton)((GComponent)this).GetChild("SetArrayBtn");
		n82 = (GImage)((GComponent)this).GetChild("n82");
	}
}
