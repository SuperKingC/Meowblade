using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_LoginGroup_New : GComponent
{
	public GImage windowBack;

	public GTextField n35;

	public GTextField n37;

	public UI_PrivacyBtn PrivacyBtn;

	public UI_AgreementBtn AgreementBtn;

	public GGroup n39;

	public GList LoginBtnList;

	public GImage n49;

	public GTextField n50;

	public GImage n51;

	public GImage n52;

	public const string URL = "ui://yb3s7uv7fa274f";

	public static string Name = "UI_LoginGroup_New";

	public static string GetURL()
	{
		return "ui://yb3s7uv7fa274f";
	}

	public static UI_LoginGroup_New CreateInstance()
	{
		return (UI_LoginGroup_New)(object)UIPackage.CreateObject("LoginAndName", "LoginGroup_New");
	}

	public static UI_LoginGroup_New CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoginGroup_New).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7fa274f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://yb3s7uv7fa274f".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id2 = "ui://yb3s7uv7fa274f".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id2);
		PrivacyBtn = (UI_PrivacyBtn)(object)((GComponent)this).GetChild("PrivacyBtn");
		AgreementBtn = (UI_AgreementBtn)(object)((GComponent)this).GetChild("AgreementBtn");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		LoginBtnList = (GList)((GComponent)this).GetChild("LoginBtnList");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id3 = "ui://yb3s7uv7fa274f".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id3);
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
	}
}
