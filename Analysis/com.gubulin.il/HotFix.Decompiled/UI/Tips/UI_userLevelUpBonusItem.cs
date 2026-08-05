using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_userLevelUpBonusItem : GButton
{
	public GImage n7;

	public GImage n6;

	public UI_userLevelUpBonusItemContent Content;

	public Transition ShowContent;

	public const string URL = "ui://47lbpgx9f3r62s";

	public static string Name = "UI_userLevelUpBonusItem";

	public static string GetURL()
	{
		return "ui://47lbpgx9f3r62s";
	}

	public static UI_userLevelUpBonusItem CreateInstance()
	{
		return (UI_userLevelUpBonusItem)(object)UIPackage.CreateObject("Tips", "userLevelUpBonusItem");
	}

	public static UI_userLevelUpBonusItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_userLevelUpBonusItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9f3r62s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Content = (UI_userLevelUpBonusItemContent)(object)((GComponent)this).GetChild("Content");
		ShowContent = ((GComponent)this).GetTransition("ShowContent");
	}
}
