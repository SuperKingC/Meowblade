using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_UserAvatar : GComponent
{
	public Controller Type;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public UI_AvatarLoader Avatar;

	public const string URL = "ui://k2sprg26in7b2b";

	public static string Name = "UI_UserAvatar";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2b";
	}

	public static UI_UserAvatar CreateInstance()
	{
		return (UI_UserAvatar)(object)UIPackage.CreateObject("IslandComeAgain", "UserAvatar");
	}

	public static UI_UserAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Avatar = (UI_AvatarLoader)(object)((GComponent)this).GetChild("Avatar");
	}
}
