using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_UserAvatarBig : GComponent
{
	public Controller CampId;

	public Controller IsMe;

	public GLoader Icon;

	public UI_com_AvatarLoader HeadPortrait;

	public UI_com_Component3 n2;

	public const string URL = "ui://b3fc6085stwv23";

	public static string Name = "UI_com_UserAvatarBig";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv23";
	}

	public static UI_com_UserAvatarBig CreateInstance()
	{
		return (UI_com_UserAvatarBig)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_UserAvatarBig");
	}

	public static UI_com_UserAvatarBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UserAvatarBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		IsMe = ((GComponent)this).GetController("IsMe");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_com_AvatarLoader)(object)((GComponent)this).GetChild("HeadPortrait");
		n2 = (UI_com_Component3)(object)((GComponent)this).GetChild("n2");
	}
}
