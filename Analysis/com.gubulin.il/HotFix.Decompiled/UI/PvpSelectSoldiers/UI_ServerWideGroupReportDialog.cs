using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideGroupReportDialog : GComponent
{
	public GImage Background;

	public GImage n4;

	public UI_BattleGroupTitle BattleGroupTitle;

	public GTextField title;

	public GList List;

	public GImage n49;

	public GTextField RankTitle;

	public GTextField PlayerTitle;

	public GTextField GroupScoreTitle;

	public GTextField RateTitle;

	public GTextField RoundScoreTitle;

	public const string URL = "ui://82mo10n5hrekjdua";

	public static string Name = "UI_ServerWideGroupReportDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5hrekjdua";
	}

	public static UI_ServerWideGroupReportDialog CreateInstance()
	{
		return (UI_ServerWideGroupReportDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideGroupReportDialog");
	}

	public static UI_ServerWideGroupReportDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideGroupReportDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hrekjdua", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		BattleGroupTitle = (UI_BattleGroupTitle)(object)((GComponent)this).GetChild("BattleGroupTitle");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		List = (GList)((GComponent)this).GetChild("List");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		RankTitle = (GTextField)((GComponent)this).GetChild("RankTitle");
		string id2 = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)RankTitle).id;
		((GObject)RankTitle).text = LanguagesManager.GetDesc(id2);
		PlayerTitle = (GTextField)((GComponent)this).GetChild("PlayerTitle");
		string id3 = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)PlayerTitle).id;
		((GObject)PlayerTitle).text = LanguagesManager.GetDesc(id3);
		GroupScoreTitle = (GTextField)((GComponent)this).GetChild("GroupScoreTitle");
		string id4 = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)GroupScoreTitle).id;
		((GObject)GroupScoreTitle).text = LanguagesManager.GetDesc(id4);
		RateTitle = (GTextField)((GComponent)this).GetChild("RateTitle");
		string id5 = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)RateTitle).id;
		((GObject)RateTitle).text = LanguagesManager.GetDesc(id5);
		RoundScoreTitle = (GTextField)((GComponent)this).GetChild("RoundScoreTitle");
		string id6 = "ui://82mo10n5hrekjdua".Replace("ui://", "") + "-" + ((GObject)RoundScoreTitle).id;
		((GObject)RoundScoreTitle).text = LanguagesManager.GetDesc(id6);
	}
}
