using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_Dialog : GComponent
{
	public GImage back;

	public GTextField tip;

	public GButton exitBtn;

	public GButton RefreshCardBtn;

	public UI_DialogMiddleContent DialogMiddleContent;

	public const string URL = "ui://47lbpgx9i0qy51";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9i0qy51";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("Tips", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9i0qy51", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://47lbpgx9i0qy51".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		RefreshCardBtn = (GButton)((GComponent)this).GetChild("RefreshCardBtn");
		DialogMiddleContent = (UI_DialogMiddleContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
	}
}
