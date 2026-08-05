using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_FirstThreeUserInfo : GButton
{
	public Controller button;

	public Controller Type;

	public UI_RankingListAvatar Icon;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GTextField UserName;

	public GList medalList;

	public const string URL = "ui://82mo10n5frebav";

	public static string Name = "UI_FirstThreeUserInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5frebav";
	}

	public static UI_FirstThreeUserInfo CreateInstance()
	{
		return (UI_FirstThreeUserInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "FirstThreeUserInfo");
	}

	public static UI_FirstThreeUserInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FirstThreeUserInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5frebav", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Icon = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		string id = "ui://82mo10n5frebav".Replace("ui://", "") + "-" + ((GObject)UserName).id;
		((GObject)UserName).text = LanguagesManager.GetDesc(id);
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}
