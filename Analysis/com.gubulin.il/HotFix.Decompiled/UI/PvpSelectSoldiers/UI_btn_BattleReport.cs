using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_BattleReport : GButton
{
	public GImage n0;

	public const string URL = "ui://82mo10n5hrekjduc";

	public static string Name = "UI_btn_BattleReport";

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjduc";
	}

	public static UI_btn_BattleReport CreateInstance()
	{
		return (UI_btn_BattleReport)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_BattleReport");
	}

	public static UI_btn_BattleReport CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleReport).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjduc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
