using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_RankingListAvatar : GButton
{
	public Controller button;

	public Controller Type;

	public GImage AvatarShadow;

	public GImage back0;

	public GImage back1;

	public UI_AvatarLoader AvatarLoader;

	public const string URL = "ui://5xc1njmujjrn25";

	public static string Name = "UI_RankingListAvatar";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn25";
	}

	public static UI_RankingListAvatar CreateInstance()
	{
		return (UI_RankingListAvatar)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "RankingListAvatar");
	}

	public static UI_RankingListAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankingListAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		AvatarShadow = (GImage)((GComponent)this).GetChild("AvatarShadow");
		back0 = (GImage)((GComponent)this).GetChild("back0");
		back1 = (GImage)((GComponent)this).GetChild("back1");
		AvatarLoader = (UI_AvatarLoader)(object)((GComponent)this).GetChild("AvatarLoader");
	}
}
