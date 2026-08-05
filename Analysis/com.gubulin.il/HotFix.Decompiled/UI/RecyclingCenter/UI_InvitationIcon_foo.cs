using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_InvitationIcon_foo : GButton
{
	public Controller button;

	public GImage back;

	public UI_HeadPortrait_foo HeadPortrait;

	public const string URL = "ui://72poq8plt5u81s";

	public static string Name = "UI_InvitationIcon_foo";

	public static string GetURL()
	{
		return "ui://72poq8plt5u81s";
	}

	public static UI_InvitationIcon_foo CreateInstance()
	{
		return (UI_InvitationIcon_foo)(object)UIPackage.CreateObject("RecyclingCenter", "InvitationIcon_foo");
	}

	public static UI_InvitationIcon_foo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitationIcon_foo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plt5u81s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		HeadPortrait = (UI_HeadPortrait_foo)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
