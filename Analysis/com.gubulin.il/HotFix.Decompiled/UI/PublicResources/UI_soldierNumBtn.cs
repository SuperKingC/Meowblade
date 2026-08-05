using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_soldierNumBtn : GButton
{
	public Controller button;

	public Controller Level;

	public GImage background;

	public GLoader iconFrame;

	public UI_LegendSoldierIcon icon;

	public GImage numNote;

	public GRichTextField num;

	public GList classListCopy;

	public GList classList;

	public GRichTextField title;

	public GRichTextField title_Max;

	public const string URL = "ui://kt6rg65os0m4tbx";

	public static string Name = "UI_soldierNumBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65os0m4tbx";
	}

	public static UI_soldierNumBtn CreateInstance()
	{
		return (UI_soldierNumBtn)(object)UIPackage.CreateObject("PublicResources", "soldierNumBtn");
	}

	public static UI_soldierNumBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_soldierNumBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65os0m4tbx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Level = ((GComponent)this).GetController("Level");
		background = (GImage)((GComponent)this).GetChild("background");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (UI_LegendSoldierIcon)(object)((GComponent)this).GetChild("icon");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		num = (GRichTextField)((GComponent)this).GetChild("num");
		string id = "ui://kt6rg65os0m4tbx".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		classListCopy = (GList)((GComponent)this).GetChild("classListCopy");
		classList = (GList)((GComponent)this).GetChild("classList");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://kt6rg65os0m4tbx".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		title_Max = (GRichTextField)((GComponent)this).GetChild("title_Max");
		string id3 = "ui://kt6rg65os0m4tbx".Replace("ui://", "") + "-" + ((GObject)title_Max).id;
		((GObject)title_Max).text = LanguagesManager.GetDesc(id3);
	}
}
