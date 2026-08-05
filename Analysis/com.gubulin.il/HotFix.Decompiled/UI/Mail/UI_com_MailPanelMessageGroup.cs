using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_MailPanelMessageGroup : GComponent
{
	public Controller MessageEmpty;

	public GImage n110;

	public GImage n109;

	public GTextField n113;

	public GGroup n111;

	public UI_com_MessageDialog MessageContent;

	public GList SessionList;

	public UI_startMessageBtn newChat;

	public GGroup Message;

	public const string URL = "ui://edr57v33pviy45";

	public static string Name = "UI_com_MailPanelMessageGroup";

	public static string GetURL()
	{
		return "ui://edr57v33pviy45";
	}

	public static UI_com_MailPanelMessageGroup CreateInstance()
	{
		return (UI_com_MailPanelMessageGroup)(object)UIPackage.CreateObject("Mail", "com_MailPanelMessageGroup");
	}

	public static UI_com_MailPanelMessageGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MailPanelMessageGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33pviy45", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MessageEmpty = ((GComponent)this).GetController("MessageEmpty");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		n113 = (GTextField)((GComponent)this).GetChild("n113");
		string id = "ui://edr57v33pviy45".Replace("ui://", "") + "-" + ((GObject)n113).id;
		((GObject)n113).text = LanguagesManager.GetDesc(id);
		n111 = (GGroup)((GComponent)this).GetChild("n111");
		MessageContent = (UI_com_MessageDialog)(object)((GComponent)this).GetChild("MessageContent");
		SessionList = (GList)((GComponent)this).GetChild("SessionList");
		newChat = (UI_startMessageBtn)(object)((GComponent)this).GetChild("newChat");
		Message = (GGroup)((GComponent)this).GetChild("Message");
	}
}
