using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_LoginGroup : GComponent
{
	public Controller PageController;

	public GImage windowBack;

	public UI_WeChatBtn2 accountBtn;

	public UI_WeChatBtn1 wechatBtn;

	public UI_GoogleBtn googleBtn;

	public UI_IosBtn iosBtn;

	public UI_TapTapBtn taptapBtn;

	public GTextField n35;

	public GTextField n37;

	public UI_AgreementBtn AgreementBtn;

	public UI_PrivacyBtn PrivacyBtn;

	public GGroup n39;

	public UI_AgreementBtn AgreementBtn2;

	public UI_PrivacyBtn PrivacyBtn2;

	public GTextField n48;

	public GLoader agreeCheckBox;

	public GTextField n56;

	public GImage agreeMark;

	public GGroup PolicyContainer;

	public GImage n57;

	public GTextField n58;

	public GImage n59;

	public GImage n60;

	public const string URL = "ui://yb3s7uv7q12t1w";

	public static string Name = "UI_LoginGroup";

	public static string GetURL()
	{
		return "ui://yb3s7uv7q12t1w";
	}

	public static UI_LoginGroup CreateInstance()
	{
		return (UI_LoginGroup)(object)UIPackage.CreateObject("LoginAndName", "LoginGroup");
	}

	public static UI_LoginGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoginGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7q12t1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		accountBtn = (UI_WeChatBtn2)(object)((GComponent)this).GetChild("accountBtn");
		wechatBtn = (UI_WeChatBtn1)(object)((GComponent)this).GetChild("wechatBtn");
		googleBtn = (UI_GoogleBtn)(object)((GComponent)this).GetChild("googleBtn");
		iosBtn = (UI_IosBtn)(object)((GComponent)this).GetChild("iosBtn");
		taptapBtn = (UI_TapTapBtn)(object)((GComponent)this).GetChild("taptapBtn");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://yb3s7uv7q12t1w".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id2 = "ui://yb3s7uv7q12t1w".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id2);
		AgreementBtn = (UI_AgreementBtn)(object)((GComponent)this).GetChild("AgreementBtn");
		PrivacyBtn = (UI_PrivacyBtn)(object)((GComponent)this).GetChild("PrivacyBtn");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		AgreementBtn2 = (UI_AgreementBtn)(object)((GComponent)this).GetChild("AgreementBtn2");
		PrivacyBtn2 = (UI_PrivacyBtn)(object)((GComponent)this).GetChild("PrivacyBtn2");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id3 = "ui://yb3s7uv7q12t1w".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id3);
		agreeCheckBox = (GLoader)((GComponent)this).GetChild("agreeCheckBox");
		n56 = (GTextField)((GComponent)this).GetChild("n56");
		string id4 = "ui://yb3s7uv7q12t1w".Replace("ui://", "") + "-" + ((GObject)n56).id;
		((GObject)n56).text = LanguagesManager.GetDesc(id4);
		agreeMark = (GImage)((GComponent)this).GetChild("agreeMark");
		PolicyContainer = (GGroup)((GComponent)this).GetChild("PolicyContainer");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id5 = "ui://yb3s7uv7q12t1w".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id5);
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
	}
}
