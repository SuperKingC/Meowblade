using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_InvitationCode : GButton
{
	public Controller button;

	public GImage n0;

	public const string URL = "ui://edr57v33gx8u3z";

	public static string Name = "UI_InvitationCode";

	public static string GetURL()
	{
		return "ui://edr57v33gx8u3z";
	}

	public static UI_InvitationCode CreateInstance()
	{
		return (UI_InvitationCode)(object)UIPackage.CreateObject("Mail", "InvitationCode");
	}

	public static UI_InvitationCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33gx8u3z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
