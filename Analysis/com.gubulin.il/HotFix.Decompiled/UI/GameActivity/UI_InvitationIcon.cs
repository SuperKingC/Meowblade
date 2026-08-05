using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_InvitationIcon : GButton
{
	public Controller button;

	public GImage back;

	public UI_HeadPortrait HeadPortrait;

	public const string URL = "ui://29q48tv6hkkt25";

	public static string Name = "UI_InvitationIcon";

	public static string GetURL()
	{
		return "ui://29q48tv6hkkt25";
	}

	public static UI_InvitationIcon CreateInstance()
	{
		return (UI_InvitationIcon)(object)UIPackage.CreateObject("GameActivity", "InvitationIcon");
	}

	public static UI_InvitationIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hkkt25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		HeadPortrait = (UI_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
