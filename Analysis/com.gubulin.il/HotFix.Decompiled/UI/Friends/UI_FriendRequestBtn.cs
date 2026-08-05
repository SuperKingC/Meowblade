using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_FriendRequestBtn : GButton
{
	public Controller button;

	public Controller hasMsg;

	public GImage n7;

	public GImage title;

	public GImage n8;

	public const string URL = "ui://3rz8gv6cc3w3h";

	public static string Name = "UI_FriendRequestBtn";

	public static string GetURL()
	{
		return "ui://3rz8gv6cc3w3h";
	}

	public static UI_FriendRequestBtn CreateInstance()
	{
		return (UI_FriendRequestBtn)(object)UIPackage.CreateObject("Friends", "FriendRequestBtn");
	}

	public static UI_FriendRequestBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendRequestBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		hasMsg = ((GComponent)this).GetController("hasMsg");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		title = (GImage)((GComponent)this).GetChild("title");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
