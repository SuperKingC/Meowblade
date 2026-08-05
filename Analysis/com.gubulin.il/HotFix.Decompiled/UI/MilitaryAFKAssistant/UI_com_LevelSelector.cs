using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LevelSelector : GComponent
{
	public Controller dropDownController;

	public Controller enabled;

	public GImage n2;

	public UI_com_LevelOptionsList levelOptions;

	public UI_com_LevelSelectorLabel levelSeletorLabel;

	public GImage n5;

	public GImage n6;

	public GTextField n7;

	public GTextField n8;

	public GGroup n9;

	public UI_com_LevelOptionTip levelTips;

	public const string URL = "ui://8x5gc8j2ex2w3";

	public static string Name = "UI_com_LevelSelector";

	public static string GetURL()
	{
		return "ui://8x5gc8j2ex2w3";
	}

	public static UI_com_LevelSelector CreateInstance()
	{
		return (UI_com_LevelSelector)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LevelSelector");
	}

	public static UI_com_LevelSelector CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSelector).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2ex2w3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		dropDownController = ((GComponent)this).GetController("dropDownController");
		enabled = ((GComponent)this).GetController("enabled");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		levelOptions = (UI_com_LevelOptionsList)(object)((GComponent)this).GetChild("levelOptions");
		levelSeletorLabel = (UI_com_LevelSelectorLabel)(object)((GComponent)this).GetChild("levelSeletorLabel");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://8x5gc8j2ex2w3".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://8x5gc8j2ex2w3".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		levelTips = (UI_com_LevelOptionTip)(object)((GComponent)this).GetChild("levelTips");
	}
}
