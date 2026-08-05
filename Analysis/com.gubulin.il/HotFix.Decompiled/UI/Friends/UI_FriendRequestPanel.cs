using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_FriendRequestPanel : GComponent
{
	public GGraph Mask;

	public UI_FriendRequestDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://3rz8gv6cqtr610";

	public static string Name = "UI_FriendRequestPanel";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr610";
	}

	public static UI_FriendRequestPanel CreateInstance()
	{
		return (UI_FriendRequestPanel)(object)UIPackage.CreateObject("Friends", "FriendRequestPanel");
	}

	public static UI_FriendRequestPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendRequestPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr610", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_FriendRequestDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
