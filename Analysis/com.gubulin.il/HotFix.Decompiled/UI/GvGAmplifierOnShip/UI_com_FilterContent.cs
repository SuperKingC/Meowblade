using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_FilterContent : GComponent
{
	public Controller IsFiltering;

	public Controller IsShowSoldierFilter;

	public Controller IsShowPropFilter;

	public GImage n120;

	public GTextField n123;

	public GTextField n121;

	public GTextField n147;

	public GList QualityFilter;

	public GImage n139;

	public GList RaceFilter;

	public GImage n138;

	public GList SoldierFilter;

	public GImage n140;

	public GList PropFilter;

	public const string URL = "ui://pwlamcyxgp16i";

	public static string Name = "UI_com_FilterContent";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16i";
	}

	public static UI_com_FilterContent CreateInstance()
	{
		return (UI_com_FilterContent)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_FilterContent");
	}

	public static UI_com_FilterContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FilterContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFiltering = ((GComponent)this).GetController("IsFiltering");
		IsShowSoldierFilter = ((GComponent)this).GetController("IsShowSoldierFilter");
		IsShowPropFilter = ((GComponent)this).GetController("IsShowPropFilter");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n123 = (GTextField)((GComponent)this).GetChild("n123");
		string id = "ui://pwlamcyxgp16i".Replace("ui://", "") + "-" + ((GObject)n123).id;
		((GObject)n123).text = LanguagesManager.GetDesc(id);
		n121 = (GTextField)((GComponent)this).GetChild("n121");
		string id2 = "ui://pwlamcyxgp16i".Replace("ui://", "") + "-" + ((GObject)n121).id;
		((GObject)n121).text = LanguagesManager.GetDesc(id2);
		n147 = (GTextField)((GComponent)this).GetChild("n147");
		string id3 = "ui://pwlamcyxgp16i".Replace("ui://", "") + "-" + ((GObject)n147).id;
		((GObject)n147).text = LanguagesManager.GetDesc(id3);
		QualityFilter = (GList)((GComponent)this).GetChild("QualityFilter");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		RaceFilter = (GList)((GComponent)this).GetChild("RaceFilter");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		SoldierFilter = (GList)((GComponent)this).GetChild("SoldierFilter");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		PropFilter = (GList)((GComponent)this).GetChild("PropFilter");
	}
}
