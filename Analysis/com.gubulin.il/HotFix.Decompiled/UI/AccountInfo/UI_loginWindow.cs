using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_loginWindow : GButton
{
	public Controller button;

	public GImage back;

	public GGraph inputUsernameBack;

	public GGraph inputPasswordBack;

	public GTextInput inputUsername;

	public GTextInput inputPassword;

	public GButton exit;

	public UI_GainBtn GainBtn;

	public UI_confirmBtn confirmBtn;

	public const string URL = "ui://b9yxt7u0f4szq";

	public static string Name = "UI_loginWindow";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szq";
	}

	public static UI_loginWindow CreateInstance()
	{
		return (UI_loginWindow)(object)UIPackage.CreateObject("AccountInfo", "loginWindow");
	}

	public static UI_loginWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_loginWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		inputUsernameBack = (GGraph)((GComponent)this).GetChild("inputUsernameBack");
		inputPasswordBack = (GGraph)((GComponent)this).GetChild("inputPasswordBack");
		inputUsername = (GTextInput)((GComponent)this).GetChild("inputUsername");
		string id = "ui://b9yxt7u0f4szq".Replace("ui://", "") + "-" + ((GObject)inputUsername).id + "-prompt";
		inputUsername.promptText = LanguagesManager.GetDesc(id);
		inputPassword = (GTextInput)((GComponent)this).GetChild("inputPassword");
		string id2 = "ui://b9yxt7u0f4szq".Replace("ui://", "") + "-" + ((GObject)inputPassword).id + "-prompt";
		inputPassword.promptText = LanguagesManager.GetDesc(id2);
		exit = (GButton)((GComponent)this).GetChild("exit");
		GainBtn = (UI_GainBtn)(object)((GComponent)this).GetChild("GainBtn");
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
	}
}
