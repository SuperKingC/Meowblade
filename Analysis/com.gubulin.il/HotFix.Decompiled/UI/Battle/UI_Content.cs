using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Content : GComponent
{
	public Controller controll;

	public GImage background;

	public GTextField n10;

	public GTextField n11;

	public GTextField n12;

	public GTextField n13;

	public GTextField n14;

	public GTextField n15;

	public GGroup n16;

	public GImage arrowUp;

	public GImage arrowDown;

	public GImage n30;

	public GTextField Name_t;

	public GTextField LevelTitle;

	public GTextField Describe;

	public GLoader Icon;

	public GList phalanxList;

	public GGroup phalanxNoteGroup;

	public GTextField Level;

	public GTextField title;

	public GGroup selectPhalanxGropu;

	public const string URL = "ui://twlbabic8hpg3k";

	public static string Name = "UI_Content";

	public static string GetURL()
	{
		return "ui://twlbabic8hpg3k";
	}

	public static UI_Content CreateInstance()
	{
		return (UI_Content)(object)UIPackage.CreateObject("Battle", "Content");
	}

	public static UI_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabic8hpg3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		controll = ((GComponent)this).GetController("controll");
		background = (GImage)((GComponent)this).GetChild("background");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id3 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id3);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id4 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id4);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id5 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id5);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id6 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id6);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		arrowUp = (GImage)((GComponent)this).GetChild("arrowUp");
		arrowDown = (GImage)((GComponent)this).GetChild("arrowDown");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id7 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id7);
		LevelTitle = (GTextField)((GComponent)this).GetChild("LevelTitle");
		string id8 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)LevelTitle).id;
		((GObject)LevelTitle).text = LanguagesManager.GetDesc(id8);
		Describe = (GTextField)((GComponent)this).GetChild("Describe");
		string id9 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)Describe).id;
		((GObject)Describe).text = LanguagesManager.GetDesc(id9);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		phalanxList = (GList)((GComponent)this).GetChild("phalanxList");
		phalanxNoteGroup = (GGroup)((GComponent)this).GetChild("phalanxNoteGroup");
		Level = (GTextField)((GComponent)this).GetChild("Level");
		string id10 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id10);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id11 = "ui://twlbabic8hpg3k".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id11);
		selectPhalanxGropu = (GGroup)((GComponent)this).GetChild("selectPhalanxGropu");
	}
}
