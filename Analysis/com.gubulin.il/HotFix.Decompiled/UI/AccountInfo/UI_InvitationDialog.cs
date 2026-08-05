using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_InvitationDialog : GComponent
{
	public GImage back;

	public GGraph inputUsernameBack;

	public GTextInput inputUsername;

	public UI_confirmBtn confirmBtn;

	public GTextField tip;

	public const string URL = "ui://b9yxt7u0t1jrm";

	public static string Name = "UI_InvitationDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrm";
	}

	public static UI_InvitationDialog CreateInstance()
	{
		return (UI_InvitationDialog)(object)UIPackage.CreateObject("AccountInfo", "InvitationDialog");
	}

	public static UI_InvitationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		inputUsernameBack = (GGraph)((GComponent)this).GetChild("inputUsernameBack");
		inputUsername = (GTextInput)((GComponent)this).GetChild("inputUsername");
		string id = "ui://b9yxt7u0t1jrm".Replace("ui://", "") + "-" + ((GObject)inputUsername).id + "-prompt";
		inputUsername.promptText = LanguagesManager.GetDesc(id);
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://b9yxt7u0t1jrm".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
	}
}
