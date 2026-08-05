using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandAvatar02 : GComponent, IIslandAvatar
{
	public Controller isHide;

	public Controller Strategy;

	public GImage n53;

	public UI_com_Avatar avatar;

	public GLoader Icon;

	public GImage n54;

	public GLoader n55;

	public const string URL = "ui://hozu168rqbhc7n";

	public static string Name = "UI_com_IslandAvatar02";

	public Controller GetIsHide => isHide;

	public Controller GetStrategy => Strategy;

	public UI_com_Avatar GetAvatar => avatar;

	public GLoader GetIcon => Icon;

	public static string GetURL()
	{
		return "ui://hozu168rqbhc7n";
	}

	public static UI_com_IslandAvatar02 CreateInstance()
	{
		return (UI_com_IslandAvatar02)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandAvatar02");
	}

	public static UI_com_IslandAvatar02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandAvatar02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rqbhc7n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isHide = ((GComponent)this).GetController("isHide");
		Strategy = ((GComponent)this).GetController("Strategy");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		avatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("avatar");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GLoader)((GComponent)this).GetChild("n55");
	}
}
