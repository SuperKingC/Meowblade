using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_CertificationMainDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GImage n23;

	public GRichTextField content;

	public GGraph inputUsernameBack;

	public GGraph inputPasswordBack;

	public GTextInput inputRealName;

	public GTextInput inputIdCardNumber;

	public GGroup n17;

	public UI_NoticeBtn notice;

	public UI_ConfirmBtn confirm;

	public UI_Experience experience;

	public GTextField n24;

	public GTextField n25;

	public const string URL = "ui://56q48tcqm13te";

	public static string Name = "UI_CertificationMainDialog";

	public static string GetURL()
	{
		return "ui://56q48tcqm13te";
	}

	public static UI_CertificationMainDialog CreateInstance()
	{
		return (UI_CertificationMainDialog)(object)UIPackage.CreateObject("Certification", "CertificationMainDialog");
	}

	public static UI_CertificationMainDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationMainDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13te", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		content = (GRichTextField)((GComponent)this).GetChild("content");
		string id = "ui://56q48tcqm13te".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id);
		inputUsernameBack = (GGraph)((GComponent)this).GetChild("inputUsernameBack");
		inputPasswordBack = (GGraph)((GComponent)this).GetChild("inputPasswordBack");
		inputRealName = (GTextInput)((GComponent)this).GetChild("inputRealName");
		string id2 = "ui://56q48tcqm13te".Replace("ui://", "") + "-" + ((GObject)inputRealName).id + "-prompt";
		inputRealName.promptText = LanguagesManager.GetDesc(id2);
		inputIdCardNumber = (GTextInput)((GComponent)this).GetChild("inputIdCardNumber");
		string id3 = "ui://56q48tcqm13te".Replace("ui://", "") + "-" + ((GObject)inputIdCardNumber).id + "-prompt";
		inputIdCardNumber.promptText = LanguagesManager.GetDesc(id3);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		notice = (UI_NoticeBtn)(object)((GComponent)this).GetChild("notice");
		confirm = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("confirm");
		experience = (UI_Experience)(object)((GComponent)this).GetChild("experience");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id4 = "ui://56q48tcqm13te".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id4);
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id5 = "ui://56q48tcqm13te".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id5);
	}
}
