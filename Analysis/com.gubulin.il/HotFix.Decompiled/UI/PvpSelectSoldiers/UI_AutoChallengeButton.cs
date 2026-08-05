using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_AutoChallengeButton : GButton
{
	public Controller button;

	public GImage bg;

	public GTextField title;

	public const string URL = "ui://82mo10n5vxevdks";

	public static string Name = "UI_AutoChallengeButton";

	public static string GetURL()
	{
		return "ui://82mo10n5vxevdks";
	}

	public static UI_AutoChallengeButton CreateInstance()
	{
		return (UI_AutoChallengeButton)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AutoChallengeButton");
	}

	public static UI_AutoChallengeButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AutoChallengeButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5vxevdks", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		bg = (GImage)((GComponent)this).GetChild("bg");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5vxevdks".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
