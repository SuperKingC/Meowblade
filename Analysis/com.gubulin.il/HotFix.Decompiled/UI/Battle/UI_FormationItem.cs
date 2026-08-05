using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_FormationItem : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n43;

	public GImage heightLight;

	public GImage n42;

	public GGroup heightLightGroup;

	public GTextField Name_t;

	public GTextField LevelTitle;

	public GTextField Describe;

	public GLoader Icon;

	public GList phalanxList;

	public UI_phalanxNoteItem phalanxNoteItem0;

	public UI_phalanxNoteItem phalanxNoteItem1;

	public UI_phalanxNoteItem phalanxNoteItem2;

	public UI_phalanxNoteItem phalanxNoteItem3;

	public UI_phalanxNoteItem phalanxNoteItem4;

	public GGroup phalanxNoteGroup;

	public GTextField Level;

	public GTextField title;

	public Transition arrowRotate;

	public const string URL = "ui://twlbabicgktvj";

	public static string Name = "UI_FormationItem";

	public static string GetURL()
	{
		return "ui://twlbabicgktvj";
	}

	public static UI_FormationItem CreateInstance()
	{
		return (UI_FormationItem)(object)UIPackage.CreateObject("Battle", "FormationItem");
	}

	public static UI_FormationItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicgktvj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
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
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		heightLight = (GImage)((GComponent)this).GetChild("heightLight");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		heightLightGroup = (GGroup)((GComponent)this).GetChild("heightLightGroup");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id = "ui://twlbabicgktvj".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id);
		LevelTitle = (GTextField)((GComponent)this).GetChild("LevelTitle");
		string id2 = "ui://twlbabicgktvj".Replace("ui://", "") + "-" + ((GObject)LevelTitle).id;
		((GObject)LevelTitle).text = LanguagesManager.GetDesc(id2);
		Describe = (GTextField)((GComponent)this).GetChild("Describe");
		string id3 = "ui://twlbabicgktvj".Replace("ui://", "") + "-" + ((GObject)Describe).id;
		((GObject)Describe).text = LanguagesManager.GetDesc(id3);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		phalanxList = (GList)((GComponent)this).GetChild("phalanxList");
		phalanxNoteItem0 = (UI_phalanxNoteItem)(object)((GComponent)this).GetChild("phalanxNoteItem0");
		phalanxNoteItem1 = (UI_phalanxNoteItem)(object)((GComponent)this).GetChild("phalanxNoteItem1");
		phalanxNoteItem2 = (UI_phalanxNoteItem)(object)((GComponent)this).GetChild("phalanxNoteItem2");
		phalanxNoteItem3 = (UI_phalanxNoteItem)(object)((GComponent)this).GetChild("phalanxNoteItem3");
		phalanxNoteItem4 = (UI_phalanxNoteItem)(object)((GComponent)this).GetChild("phalanxNoteItem4");
		phalanxNoteGroup = (GGroup)((GComponent)this).GetChild("phalanxNoteGroup");
		Level = (GTextField)((GComponent)this).GetChild("Level");
		string id4 = "ui://twlbabicgktvj".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id4);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id5 = "ui://twlbabicgktvj".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id5);
		arrowRotate = ((GComponent)this).GetTransition("arrowRotate");
	}

	public void SetControllerPageText(int pageIndex)
	{
		string id = string.Format("{0}-{1}-{2}", "ui://twlbabicgktvj".Replace("ui://", ""), ((GObject)Describe).id, pageIndex);
		((GObject)Describe).text = LanguagesManager.GetDesc(id, returnKey: false);
	}
}
