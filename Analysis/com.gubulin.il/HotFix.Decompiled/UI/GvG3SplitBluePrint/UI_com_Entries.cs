using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_Entries : GComponent
{
	public Controller Type;

	public GTextField title0;

	public GImage n2;

	public GTextField title1;

	public GTextField n3;

	public GTextField n4;

	public GList Entries;

	public GImage line;

	public GTextField title2;

	public GTextField n8;

	public GTextField title3;

	public GTextField n10;

	public GGroup n11;

	public const string URL = "ui://7uylntmmkq2dz";

	public static string Name = "UI_com_Entries";

	public static string GetURL()
	{
		return "ui://7uylntmmkq2dz";
	}

	public static UI_com_Entries CreateInstance()
	{
		return (UI_com_Entries)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_Entries");
	}

	public static UI_com_Entries CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entries).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2dz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id2 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id4 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id4);
		Entries = (GList)((GComponent)this).GetChild("Entries");
		line = (GImage)((GComponent)this).GetChild("line");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id5 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id5);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id6 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id6);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id7 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id7);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id8 = "ui://7uylntmmkq2dz".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id8);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
	}
}
