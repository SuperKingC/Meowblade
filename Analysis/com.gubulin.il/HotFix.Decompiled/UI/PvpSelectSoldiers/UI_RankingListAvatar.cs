using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RankingListAvatar : GButton
{
	public Controller button;

	public Controller Type;

	public GImage AvatarShadow;

	public GImage back0;

	public GImage back1;

	public UI_HeadPortrait HeadPortrait;

	public const string URL = "ui://82mo10n5lt7m9h";

	public static string Name = "UI_RankingListAvatar";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9h";
	}

	public static UI_RankingListAvatar CreateInstance()
	{
		return (UI_RankingListAvatar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RankingListAvatar");
	}

	public static UI_RankingListAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RankingListAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		HeadPortrait = (UI_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}

	public void Update(bool isUser, string npcAvatarUrl = "")
	{
		if (isUser)
		{
			HeadPortrait.Type.selectedIndex = 0;
			return;
		}
		HeadPortrait.icon.url = npcAvatarUrl;
		HeadPortrait.Type.selectedIndex = 1;
	}
}
