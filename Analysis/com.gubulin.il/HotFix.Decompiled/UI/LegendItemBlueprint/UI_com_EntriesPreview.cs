using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_EntriesPreview : GComponent
{
	public Controller Type;

	public Controller HasSet;

	public GTextField title0;

	public GImage n2;

	public GTextField title1;

	public GTextField n3;

	public GTextField MainEntry;

	public GTextField n4;

	public GList Entries;

	public GRichTextField CurrentSubEntry;

	public GImage line;

	public GImage MainEntryUp;

	public GTextField title2;

	public GTextField n11;

	public GTextField title3;

	public GTextField n13;

	public GGroup n14;

	public GTextField title4;

	public GRichTextField MainFx;

	public GTextField title5;

	public GRichTextField MainSet;

	public GGroup n20;

	public const string URL = "ui://h09dvkcglxbt40";

	public static string Name = "UI_com_EntriesPreview";

	public static string GetURL()
	{
		return "ui://h09dvkcglxbt40";
	}

	public static UI_com_EntriesPreview CreateInstance()
	{
		return (UI_com_EntriesPreview)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_EntriesPreview");
	}

	public static UI_com_EntriesPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EntriesPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcglxbt40", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Expected O, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		HasSet = ((GComponent)this).GetController("HasSet");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id2 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		MainEntry = (GTextField)((GComponent)this).GetChild("MainEntry");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id4 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id4);
		Entries = (GList)((GComponent)this).GetChild("Entries");
		CurrentSubEntry = (GRichTextField)((GComponent)this).GetChild("CurrentSubEntry");
		line = (GImage)((GComponent)this).GetChild("line");
		MainEntryUp = (GImage)((GComponent)this).GetChild("MainEntryUp");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id5 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id5);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id6 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id6);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id7 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id7);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id8 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id8);
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		title4 = (GTextField)((GComponent)this).GetChild("title4");
		string id9 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title4).id;
		((GObject)title4).text = LanguagesManager.GetDesc(id9);
		MainFx = (GRichTextField)((GComponent)this).GetChild("MainFx");
		title5 = (GTextField)((GComponent)this).GetChild("title5");
		string id10 = "ui://h09dvkcglxbt40".Replace("ui://", "") + "-" + ((GObject)title5).id;
		((GObject)title5).text = LanguagesManager.GetDesc(id10);
		MainSet = (GRichTextField)((GComponent)this).GetChild("MainSet");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
	}
}
