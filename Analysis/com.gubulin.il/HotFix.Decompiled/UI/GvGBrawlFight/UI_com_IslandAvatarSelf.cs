using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandAvatarSelf : GComponent
{
	public Controller Strategy;

	public GImage n53;

	public UI_com_Avatar avatar;

	public GLoader Icon;

	public GImage n54;

	public GLoader n55;

	public const string URL = "ui://hozu168ryltp77";

	public static string Name = "UI_com_IslandAvatarSelf";

	public static string GetURL()
	{
		return "ui://hozu168ryltp77";
	}

	public static UI_com_IslandAvatarSelf CreateInstance()
	{
		return (UI_com_IslandAvatarSelf)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandAvatarSelf");
	}

	public static UI_com_IslandAvatarSelf CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandAvatarSelf).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168ryltp77", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Strategy = ((GComponent)this).GetController("Strategy");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		avatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("avatar");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GLoader)((GComponent)this).GetChild("n55");
	}
}
