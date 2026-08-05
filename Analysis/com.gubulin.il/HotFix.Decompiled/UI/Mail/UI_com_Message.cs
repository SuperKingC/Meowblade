using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_Message : GComponent
{
	public Controller type;

	public Controller isCopy;

	public GGraph bg;

	public UI_ChatSelf ChatSelf;

	public GTextField NameSelf;

	public GTextField timeSelf;

	public GGroup selfGroup;

	public UI_ChatPlayer ChatPlayer;

	public GTextField NameFriends;

	public GTextField timeFriends;

	public GGroup friendGroup;

	public GImage n118;

	public GTextField n121;

	public GImage n120;

	public GGroup partLineGroup;

	public UI_Copy Copy;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://edr57v33tjql3m";

	public static string Name = "UI_com_Message";

	public static string GetURL()
	{
		return "ui://edr57v33tjql3m";
	}

	public static UI_com_Message CreateInstance()
	{
		return (UI_com_Message)(object)UIPackage.CreateObject("Mail", "com_Message");
	}

	public static UI_com_Message CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Message).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33tjql3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		type = ((GComponent)this).GetController("type");
		isCopy = ((GComponent)this).GetController("isCopy");
		bg = (GGraph)((GComponent)this).GetChild("bg");
		ChatSelf = (UI_ChatSelf)(object)((GComponent)this).GetChild("ChatSelf");
		NameSelf = (GTextField)((GComponent)this).GetChild("NameSelf");
		timeSelf = (GTextField)((GComponent)this).GetChild("timeSelf");
		selfGroup = (GGroup)((GComponent)this).GetChild("selfGroup");
		ChatPlayer = (UI_ChatPlayer)(object)((GComponent)this).GetChild("ChatPlayer");
		NameFriends = (GTextField)((GComponent)this).GetChild("NameFriends");
		timeFriends = (GTextField)((GComponent)this).GetChild("timeFriends");
		friendGroup = (GGroup)((GComponent)this).GetChild("friendGroup");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n121 = (GTextField)((GComponent)this).GetChild("n121");
		string id = "ui://edr57v33tjql3m".Replace("ui://", "") + "-" + ((GObject)n121).id;
		((GObject)n121).text = LanguagesManager.GetDesc(id);
		n120 = (GImage)((GComponent)this).GetChild("n120");
		partLineGroup = (GGroup)((GComponent)this).GetChild("partLineGroup");
		Copy = (UI_Copy)(object)((GComponent)this).GetChild("Copy");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
