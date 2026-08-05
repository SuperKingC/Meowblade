using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampMvpAvatar : GComponent
{
	public GComponent Avatar;

	public GImage n1;

	public const string URL = "ui://hozu168rhd0n9j";

	public static string Name = "UI_com_CampMvpAvatar";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9j";
	}

	public static UI_com_CampMvpAvatar CreateInstance()
	{
		return (UI_com_CampMvpAvatar)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampMvpAvatar");
	}

	public static UI_com_CampMvpAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampMvpAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
