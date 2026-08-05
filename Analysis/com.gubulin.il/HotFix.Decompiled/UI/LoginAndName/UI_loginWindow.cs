using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_loginWindow : GButton
{
	public Controller button;

	public GImage back;

	public GImage n32;

	public GImage inputUsernameBack;

	public GImage inputPasswordBack;

	public GTextInput inputUsername;

	public GTextInput inputPassword;

	public UI_Account enterGame;

	public UI_exitBtn exit;

	public UI_GainBtn GainBtn;

	public GImage n28;

	public GTextField n29;

	public GImage n30;

	public GImage n31;

	public Transition t0;

	public const string URL = "ui://yb3s7uv7ryu83";

	public static string Name = "UI_loginWindow";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ryu83";
	}

	public static UI_loginWindow CreateInstance()
	{
		return (UI_loginWindow)(object)UIPackage.CreateObject("LoginAndName", "loginWindow");
	}

	public static UI_loginWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_loginWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ryu83", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		inputUsernameBack = (GImage)((GComponent)this).GetChild("inputUsernameBack");
		inputPasswordBack = (GImage)((GComponent)this).GetChild("inputPasswordBack");
		inputUsername = (GTextInput)((GComponent)this).GetChild("inputUsername");
		string id = "ui://yb3s7uv7ryu83".Replace("ui://", "") + "-" + ((GObject)inputUsername).id + "-prompt";
		inputUsername.promptText = LanguagesManager.GetDesc(id);
		inputPassword = (GTextInput)((GComponent)this).GetChild("inputPassword");
		string id2 = "ui://yb3s7uv7ryu83".Replace("ui://", "") + "-" + ((GObject)inputPassword).id + "-prompt";
		inputPassword.promptText = LanguagesManager.GetDesc(id2);
		enterGame = (UI_Account)(object)((GComponent)this).GetChild("enterGame");
		exit = (UI_exitBtn)(object)((GComponent)this).GetChild("exit");
		GainBtn = (UI_GainBtn)(object)((GComponent)this).GetChild("GainBtn");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id3 = "ui://yb3s7uv7ryu83".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id3);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
