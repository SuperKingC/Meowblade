using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_UserHp : GProgressBar
{
	public GImage bar;

	public GTextField Health;

	public const string URL = "ui://82mo10n5c3gbdcw";

	public static string Name = "UI_UserHp";

	public static string GetURL()
	{
		return "ui://82mo10n5c3gbdcw";
	}

	public static UI_UserHp CreateInstance()
	{
		return (UI_UserHp)(object)UIPackage.CreateObject("PvpSelectSoldiers", "UserHp");
	}

	public static UI_UserHp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserHp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5c3gbdcw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
		Health = (GTextField)((GComponent)this).GetChild("Health");
		string id = "ui://82mo10n5c3gbdcw".Replace("ui://", "") + "-" + ((GObject)Health).id;
		((GObject)Health).text = LanguagesManager.GetDesc(id);
	}
}
