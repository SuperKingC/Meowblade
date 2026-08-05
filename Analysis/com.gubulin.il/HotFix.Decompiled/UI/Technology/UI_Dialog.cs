using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_Dialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GTextField tip;

	public GButton exitBtn;

	public GLoader DemandIcon;

	public GImage chipNote;

	public GComponent CurrentDemand_t;

	public UI_RefreshCardConfirmBtn RefreshCardBtn;

	public UI_DialogMiddleContent DialogMiddleContent;

	public const string URL = "ui://7ca77a3fnwky3k";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://7ca77a3fnwky3k";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("Technology", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fnwky3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7ca77a3fnwky3k".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://7ca77a3fnwky3k".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		DemandIcon = (GLoader)((GComponent)this).GetChild("DemandIcon");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		CurrentDemand_t = (GComponent)((GComponent)this).GetChild("CurrentDemand_t");
		RefreshCardBtn = (UI_RefreshCardConfirmBtn)(object)((GComponent)this).GetChild("RefreshCardBtn");
		DialogMiddleContent = (UI_DialogMiddleContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
	}
}
