using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_CopyInvitingCodePopup : GComponent
{
	public GImage back;

	public GButton exitBtn;

	public GTextField InvitingCode;

	public GButton CopyBtn;

	public GTextField Tip;

	public const string URL = "ui://47lbpgx9mq51tbf";

	public static string Name = "UI_CopyInvitingCodePopup";

	public static string GetURL()
	{
		return "ui://47lbpgx9mq51tbf";
	}

	public static UI_CopyInvitingCodePopup CreateInstance()
	{
		return (UI_CopyInvitingCodePopup)(object)UIPackage.CreateObject("Tips", "CopyInvitingCodePopup");
	}

	public static UI_CopyInvitingCodePopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CopyInvitingCodePopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mq51tbf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		InvitingCode = (GTextField)((GComponent)this).GetChild("InvitingCode");
		string id = "ui://47lbpgx9mq51tbf".Replace("ui://", "") + "-" + ((GObject)InvitingCode).id;
		((GObject)InvitingCode).text = LanguagesManager.GetDesc(id);
		CopyBtn = (GButton)((GComponent)this).GetChild("CopyBtn");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://47lbpgx9mq51tbf".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
	}
}
