using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossIcon : GButton
{
	public Controller button;

	public GImage n3;

	public UI_GvGBossAvatar BossAvatar;

	public const string URL = "ui://twlbabiccvfml6";

	public static string Name = "UI_GvGBossIcon";

	public static string GetURL()
	{
		return "ui://twlbabiccvfml6";
	}

	public static UI_GvGBossIcon CreateInstance()
	{
		return (UI_GvGBossIcon)(object)UIPackage.CreateObject("Battle", "GvGBossIcon");
	}

	public static UI_GvGBossIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiccvfml6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		BossAvatar = (UI_GvGBossAvatar)(object)((GComponent)this).GetChild("BossAvatar");
	}
}
