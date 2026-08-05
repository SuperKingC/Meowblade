using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_FilterContent : GComponent
{
	public Controller IsShowSoldierFilter;

	public GTextField n122;

	public GImage n139;

	public GImage n138;

	public GImage n140;

	public GList QualityFilter;

	public GList RaceFilter;

	public GList SoldierFilter;

	public GList PropFilter;

	public UI_com_ContentBottom ContentBottom;

	public const string URL = "ui://tt2iq07odwxt9";

	public static string Name = "UI_com_FilterContent";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt9";
	}

	public static UI_com_FilterContent CreateInstance()
	{
		return (UI_com_FilterContent)(object)UIPackage.CreateObject("GvGExchange3", "com_FilterContent");
	}

	public static UI_com_FilterContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FilterContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowSoldierFilter = ((GComponent)this).GetController("IsShowSoldierFilter");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id = "ui://tt2iq07odwxt9".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id);
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		QualityFilter = (GList)((GComponent)this).GetChild("QualityFilter");
		RaceFilter = (GList)((GComponent)this).GetChild("RaceFilter");
		SoldierFilter = (GList)((GComponent)this).GetChild("SoldierFilter");
		PropFilter = (GList)((GComponent)this).GetChild("PropFilter");
		ContentBottom = (UI_com_ContentBottom)(object)((GComponent)this).GetChild("ContentBottom");
	}
}
