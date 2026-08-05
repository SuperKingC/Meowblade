using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_AddFriendPanel : GComponent
{
	public GGraph Mask;

	public UI_AddFriendDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://3rz8gv6cqtr6u";

	public static string Name = "UI_AddFriendPanel";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr6u";
	}

	public static UI_AddFriendPanel CreateInstance()
	{
		return (UI_AddFriendPanel)(object)UIPackage.CreateObject("Friends", "AddFriendPanel");
	}

	public static UI_AddFriendPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddFriendPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_AddFriendDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
