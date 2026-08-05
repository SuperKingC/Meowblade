using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_com_UserAvatarBig : GComponent
{
	public Controller CampId;

	public GLoader Icon;

	public UI_com_AvatarLoader HeadPortrait;

	public const string URL = "ui://g5hi1peosxgwr";

	public static string Name = "UI_com_UserAvatarBig";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgwr";
	}

	public static UI_com_UserAvatarBig CreateInstance()
	{
		return (UI_com_UserAvatarBig)(object)UIPackage.CreateObject("GvG3Medal", "com_UserAvatarBig");
	}

	public static UI_com_UserAvatarBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UserAvatarBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_com_AvatarLoader)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
