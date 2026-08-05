using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_UserInfo : GComponent
{
	public UI_UserAvatar UserAvatar;

	public GTextField UserName;

	public GTextField StateInfo;

	public GTextField kills;

	public const string URL = "ui://k2sprg26in7b28";

	public static string Name = "UI_UserInfo";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b28";
	}

	public static UI_UserInfo CreateInstance()
	{
		return (UI_UserInfo)(object)UIPackage.CreateObject("IslandComeAgain", "UserInfo");
	}

	public static UI_UserInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UserAvatar = (UI_UserAvatar)(object)((GComponent)this).GetChild("UserAvatar");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		StateInfo = (GTextField)((GComponent)this).GetChild("StateInfo");
		kills = (GTextField)((GComponent)this).GetChild("kills");
	}
}
