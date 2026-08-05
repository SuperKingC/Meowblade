using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_com_ScoreBonuses : GComponent
{
	public GList RanKList;

	public const string URL = "ui://82mo10n5pmghdnl";

	public static string Name = "UI_com_ScoreBonuses";

	public static string GetURL()
	{
		return "ui://82mo10n5pmghdnl";
	}

	public static UI_com_ScoreBonuses CreateInstance()
	{
		return (UI_com_ScoreBonuses)(object)UIPackage.CreateObject("PvpSelectSoldiers", "com_ScoreBonuses");
	}

	public static UI_com_ScoreBonuses CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ScoreBonuses).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5pmghdnl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RanKList = (GList)((GComponent)this).GetChild("RanKList");
	}
}
