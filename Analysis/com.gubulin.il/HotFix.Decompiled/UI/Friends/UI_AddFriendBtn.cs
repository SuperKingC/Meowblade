using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_AddFriendBtn : GButton
{
	public Controller button;

	public GImage n7;

	public GImage title;

	public const string URL = "ui://3rz8gv6cqtr6v";

	public static string Name = "UI_AddFriendBtn";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr6v";
	}

	public static UI_AddFriendBtn CreateInstance()
	{
		return (UI_AddFriendBtn)(object)UIPackage.CreateObject("Friends", "AddFriendBtn");
	}

	public static UI_AddFriendBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddFriendBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
