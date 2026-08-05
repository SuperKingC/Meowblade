using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWidePointsDetailslog : GComponent
{
	public GImage n0;

	public GTextField title;

	public GTextField content;

	public GImage n9;

	public GTextField n2;

	public GTextField n1;

	public GTextField n3;

	public GTextField n4;

	public GGroup n17;

	public GList scoreList;

	public GGraph n12;

	public GTextField totalScoreTitle;

	public GTextField PointsNumber;

	public GGroup TotalPoints;

	public GGroup PointsList;

	public const string URL = "ui://82mo10n5jzv6jdvb";

	public static string Name = "UI_ServerWidePointsDetailslog";

	public static string GetURL()
	{
		return "ui://82mo10n5jzv6jdvb";
	}

	public static UI_ServerWidePointsDetailslog CreateInstance()
	{
		return (UI_ServerWidePointsDetailslog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWidePointsDetailslog");
	}

	public static UI_ServerWidePointsDetailslog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWidePointsDetailslog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jzv6jdvb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id2 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id2);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id3 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id3);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id4 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id4);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id5 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id5);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id6 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id6);
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		scoreList = (GList)((GComponent)this).GetChild("scoreList");
		n12 = (GGraph)((GComponent)this).GetChild("n12");
		totalScoreTitle = (GTextField)((GComponent)this).GetChild("totalScoreTitle");
		string id7 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)totalScoreTitle).id;
		((GObject)totalScoreTitle).text = LanguagesManager.GetDesc(id7);
		PointsNumber = (GTextField)((GComponent)this).GetChild("PointsNumber");
		string id8 = "ui://82mo10n5jzv6jdvb".Replace("ui://", "") + "-" + ((GObject)PointsNumber).id;
		((GObject)PointsNumber).text = LanguagesManager.GetDesc(id8);
		TotalPoints = (GGroup)((GComponent)this).GetChild("TotalPoints");
		PointsList = (GGroup)((GComponent)this).GetChild("PointsList");
	}
}
