using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_armItem : GButton
{
	public Controller button;

	public Controller Level;

	public GImage iconBack;

	public GLoader iconFrame;

	public GImage n28;

	public GLoader icon;

	public GList classListCopy;

	public GList classList;

	public GRichTextField title;

	public GRichTextField title_Max;

	public GComponent SoulStoneLevel;

	public GLoader ShoulderStrap;

	public GComponent PotentialIcon;

	public Transition t0;

	public const string URL = "ui://7dantnbifb7x5e";

	public static string Name = "UI_armItem";

	public static string GetURL()
	{
		return "ui://7dantnbifb7x5e";
	}

	public static UI_armItem CreateInstance()
	{
		return (UI_armItem)(object)UIPackage.CreateObject("SoldierCultivate", "armItem");
	}

	public static UI_armItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_armItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbifb7x5e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Level = ((GComponent)this).GetController("Level");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		classListCopy = (GList)((GComponent)this).GetChild("classListCopy");
		classList = (GList)((GComponent)this).GetChild("classList");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbifb7x5e".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		title_Max = (GRichTextField)((GComponent)this).GetChild("title_Max");
		string id2 = "ui://7dantnbifb7x5e".Replace("ui://", "") + "-" + ((GObject)title_Max).id;
		((GObject)title_Max).text = LanguagesManager.GetDesc(id2);
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		ShoulderStrap = (GLoader)((GComponent)this).GetChild("ShoulderStrap");
		PotentialIcon = (GComponent)((GComponent)this).GetChild("PotentialIcon");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
