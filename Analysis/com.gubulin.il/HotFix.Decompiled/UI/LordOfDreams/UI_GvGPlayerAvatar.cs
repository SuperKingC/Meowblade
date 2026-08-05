using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGPlayerAvatar : GComponent
{
	public Controller IsShowInfo;

	public UI_PlayerInfo PlayerInfo;

	public UI_Avatar Avatar;

	public GMovieClip FightingIcon;

	public GGraph SfxLoader;

	public const string URL = "ui://0i520nzmp5p0o5e";

	public static string Name = "UI_GvGPlayerAvatar";

	public static string GetURL()
	{
		return "ui://0i520nzmp5p0o5e";
	}

	public static UI_GvGPlayerAvatar CreateInstance()
	{
		return (UI_GvGPlayerAvatar)(object)UIPackage.CreateObject("LordOfDreams", "GvGPlayerAvatar");
	}

	public static UI_GvGPlayerAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGPlayerAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmp5p0o5e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowInfo = ((GComponent)this).GetController("IsShowInfo");
		PlayerInfo = (UI_PlayerInfo)(object)((GComponent)this).GetChild("PlayerInfo");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		FightingIcon = (GMovieClip)((GComponent)this).GetChild("FightingIcon");
		SfxLoader = (GGraph)((GComponent)this).GetChild("SfxLoader");
	}
}
