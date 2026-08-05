using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ListGroup : GComponent
{
	public UI_RankTitle RankTitle;

	public UI_PointTitle PointTitle;

	public UI_RankTip RankTip;

	public UI_com_ScoreBonuses ScoreBonuses;

	public GList PointList;

	public const string URL = "ui://82mo10n51053da4";

	public static string Name = "UI_ListGroup";

	public static string GetURL()
	{
		return "ui://82mo10n51053da4";
	}

	public static UI_ListGroup CreateInstance()
	{
		return (UI_ListGroup)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ListGroup");
	}

	public static UI_ListGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ListGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053da4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankTitle = (UI_RankTitle)(object)((GComponent)this).GetChild("RankTitle");
		PointTitle = (UI_PointTitle)(object)((GComponent)this).GetChild("PointTitle");
		RankTip = (UI_RankTip)(object)((GComponent)this).GetChild("RankTip");
		ScoreBonuses = (UI_com_ScoreBonuses)(object)((GComponent)this).GetChild("ScoreBonuses");
		PointList = (GList)((GComponent)this).GetChild("PointList");
	}
}
