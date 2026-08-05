using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_FriendRequestDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GTextField title;

	public GList List;

	public GTextField tip2;

	public GTextField tip3;

	public const string URL = "ui://3rz8gv6cqtr6y";

	public static string Name = "UI_FriendRequestDialog";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr6y";
	}

	public static UI_FriendRequestDialog CreateInstance()
	{
		return (UI_FriendRequestDialog)(object)UIPackage.CreateObject("Friends", "FriendRequestDialog");
	}

	public static UI_FriendRequestDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendRequestDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://3rz8gv6cqtr6y".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		List = (GList)((GComponent)this).GetChild("List");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://3rz8gv6cqtr6y".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		string id3 = "ui://3rz8gv6cqtr6y".Replace("ui://", "") + "-" + ((GObject)tip3).id;
		((GObject)tip3).text = LanguagesManager.GetDesc(id3);
	}
}
