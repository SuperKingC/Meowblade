using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_PlayerLoseInFinalResult : GButton
{
	public GImage n4;

	public GTextField title;

	public const string URL = "ui://82mo10n5hmsjjdtg";

	public static string Name = "UI_btn_PlayerLoseInFinalResult";

	public static string GetURL()
	{
		return "ui://82mo10n5hmsjjdtg";
	}

	public static UI_btn_PlayerLoseInFinalResult CreateInstance()
	{
		return (UI_btn_PlayerLoseInFinalResult)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_PlayerLoseInFinalResult");
	}

	public static UI_btn_PlayerLoseInFinalResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PlayerLoseInFinalResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hmsjjdtg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5hmsjjdtg".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
