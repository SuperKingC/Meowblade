using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_InvitationCode : GButton
{
	public Controller button;

	public GImage n0;

	public const string URL = "ui://3rz8gv6cn9xk16";

	public static string Name = "UI_InvitationCode";

	public static string GetURL()
	{
		return "ui://3rz8gv6cn9xk16";
	}

	public static UI_InvitationCode CreateInstance()
	{
		return (UI_InvitationCode)(object)UIPackage.CreateObject("Friends", "InvitationCode");
	}

	public static UI_InvitationCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cn9xk16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
