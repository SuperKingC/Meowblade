using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_com_FilterContent : GComponent
{
	public Controller IsFiltering;

	public Controller IsShowSoldierFilter;

	public Controller IsShowPropFilter;

	public Controller hideQuality;

	public GImage n120;

	public GTextField n123;

	public GTextField n121;

	public GTextField n147;

	public GList QualityFilter;

	public GImage n139;

	public GGroup QualityGroup;

	public GList RaceFilter;

	public GImage n138;

	public GList SoldierFilter;

	public GImage n140;

	public GList PropFilter;

	public GGroup OtherGroup;

	public const string URL = "ui://fwpu3639q8fup";

	public static string Name = "UI_com_FilterContent";

	public static string GetURL()
	{
		return "ui://fwpu3639q8fup";
	}

	public static UI_com_FilterContent CreateInstance()
	{
		return (UI_com_FilterContent)(object)UIPackage.CreateObject("GvGAmplifierStorage", "com_FilterContent");
	}

	public static UI_com_FilterContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FilterContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639q8fup", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFiltering = ((GComponent)this).GetController("IsFiltering");
		IsShowSoldierFilter = ((GComponent)this).GetController("IsShowSoldierFilter");
		IsShowPropFilter = ((GComponent)this).GetController("IsShowPropFilter");
		hideQuality = ((GComponent)this).GetController("hideQuality");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n123 = (GTextField)((GComponent)this).GetChild("n123");
		string id = "ui://fwpu3639q8fup".Replace("ui://", "") + "-" + ((GObject)n123).id;
		((GObject)n123).text = LanguagesManager.GetDesc(id);
		n121 = (GTextField)((GComponent)this).GetChild("n121");
		string id2 = "ui://fwpu3639q8fup".Replace("ui://", "") + "-" + ((GObject)n121).id;
		((GObject)n121).text = LanguagesManager.GetDesc(id2);
		n147 = (GTextField)((GComponent)this).GetChild("n147");
		string id3 = "ui://fwpu3639q8fup".Replace("ui://", "") + "-" + ((GObject)n147).id;
		((GObject)n147).text = LanguagesManager.GetDesc(id3);
		QualityFilter = (GList)((GComponent)this).GetChild("QualityFilter");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		QualityGroup = (GGroup)((GComponent)this).GetChild("QualityGroup");
		RaceFilter = (GList)((GComponent)this).GetChild("RaceFilter");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		SoldierFilter = (GList)((GComponent)this).GetChild("SoldierFilter");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		PropFilter = (GList)((GComponent)this).GetChild("PropFilter");
		OtherGroup = (GGroup)((GComponent)this).GetChild("OtherGroup");
	}
}
