using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_ChatPlayer : GButton
{
	public Controller button;

	public Controller isCopy;

	public Controller isNew;

	public GImage n4;

	public GTextField MessageFriends;

	public Transition t0;

	public const string URL = "ui://edr57v3311ja64d";

	public static string Name = "UI_ChatPlayer";

	public static string GetURL()
	{
		return "ui://edr57v3311ja64d";
	}

	public static UI_ChatPlayer CreateInstance()
	{
		return (UI_ChatPlayer)(object)UIPackage.CreateObject("Mail", "ChatPlayer");
	}

	public static UI_ChatPlayer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChatPlayer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v3311ja64d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isCopy = ((GComponent)this).GetController("isCopy");
		isNew = ((GComponent)this).GetController("isNew");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		MessageFriends = (GTextField)((GComponent)this).GetChild("MessageFriends");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
