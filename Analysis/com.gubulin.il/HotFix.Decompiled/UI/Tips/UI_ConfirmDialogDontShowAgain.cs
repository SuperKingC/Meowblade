using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ConfirmDialogDontShowAgain : GComponent
{
	public Controller ButtonStyle;

	public GImage back;

	public GTextField tip;

	public UI_DontShowBtn switchBtn;

	public GButton yesBtn;

	public GButton noBtn;

	public const string URL = "ui://47lbpgx9w1r55m";

	public static string Name = "UI_ConfirmDialogDontShowAgain";

	public void SetButtonTitle()
	{
		yesBtn.title = LanguagesManager.GetDesc("Tips-ConfirmDialogDontShowAgain-yesBtn-title");
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9w1r55m";
	}

	public static UI_ConfirmDialogDontShowAgain CreateInstance()
	{
		return (UI_ConfirmDialogDontShowAgain)(object)UIPackage.CreateObject("Tips", "ConfirmDialogDontShowAgain");
	}

	public static UI_ConfirmDialogDontShowAgain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialogDontShowAgain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9w1r55m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ButtonStyle = ((GComponent)this).GetController("ButtonStyle");
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		switchBtn = (UI_DontShowBtn)(object)((GComponent)this).GetChild("switchBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
	}
}
