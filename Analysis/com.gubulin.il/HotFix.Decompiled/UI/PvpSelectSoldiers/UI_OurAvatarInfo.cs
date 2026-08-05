using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_OurAvatarInfo : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n4;

	public UI_UserHp Hp;

	public GGroup n11;

	public UI_RankingListAvatar Avatar;

	public GImage n5;

	public GTextField UserName;

	public GGroup n10;

	public GGraph BreakSpineBack;

	public GList OurMedalList;

	public Transition FadeAway;

	public const string URL = "ui://82mo10n5c3gbdcv";

	public static string Name = "UI_OurAvatarInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcv";
	}

	public static UI_OurAvatarInfo CreateInstance()
	{
		return (UI_OurAvatarInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "OurAvatarInfo");
	}

	public static UI_OurAvatarInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurAvatarInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Hp = (UI_UserHp)(object)((GComponent)this).GetChild("Hp");
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		string id = "ui://82mo10n5c3gbdcv".Replace("ui://", "") + "-" + ((GObject)UserName).id;
		((GObject)UserName).text = LanguagesManager.GetDesc(id);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		BreakSpineBack = (GGraph)((GComponent)this).GetChild("BreakSpineBack");
		OurMedalList = (GList)((GComponent)this).GetChild("OurMedalList");
		FadeAway = ((GComponent)this).GetTransition("FadeAway");
	}
}
