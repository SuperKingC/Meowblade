using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_FriendsDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GTextField title;

	public GList FriendsList;

	public UI_exit close;

	public GTextField tip2;

	public GTextField tip;

	public UI_InvitationCode InvitationCode;

	public const string URL = "ui://edr57v33c3w31";

	public static string Name = "UI_FriendsDialog";

	public static string GetURL()
	{
		return "ui://edr57v33c3w31";
	}

	public static UI_FriendsDialog CreateInstance()
	{
		return (UI_FriendsDialog)(object)UIPackage.CreateObject("Mail", "FriendsDialog");
	}

	public static UI_FriendsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33c3w31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://edr57v33c3w31".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		FriendsList = (GList)((GComponent)this).GetChild("FriendsList");
		close = (UI_exit)(object)((GComponent)this).GetChild("close");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://edr57v33c3w31".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://edr57v33c3w31".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		InvitationCode = (UI_InvitationCode)(object)((GComponent)this).GetChild("InvitationCode");
	}
}
