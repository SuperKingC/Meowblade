using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_TakeContent_Large : GComponent
{
	public GImage back;

	public GGraph n84;

	public GTextField t1;

	public GList materialList;

	public GTextField Title;

	public UI_YesBtn_Large ConfirmBtn;

	public GLoader SelectedIcon;

	public GTextField SelectedName;

	public GTextField Desc;

	public GButton Close;

	public UI_btn_01 helpBtn;

	public const string URL = "ui://47lbpgx9vur65g";

	public static string Name = "UI_TakeContent_Large";

	public static string GetURL()
	{
		return "ui://47lbpgx9vur65g";
	}

	public static UI_TakeContent_Large CreateInstance()
	{
		return (UI_TakeContent_Large)(object)UIPackage.CreateObject("Tips", "TakeContent_Large");
	}

	public static UI_TakeContent_Large CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeContent_Large).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9vur65g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n84 = (GGraph)((GComponent)this).GetChild("n84");
		t1 = (GTextField)((GComponent)this).GetChild("t1");
		string id = "ui://47lbpgx9vur65g".Replace("ui://", "") + "-" + ((GObject)t1).id;
		((GObject)t1).text = LanguagesManager.GetDesc(id);
		materialList = (GList)((GComponent)this).GetChild("materialList");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id2 = "ui://47lbpgx9vur65g".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id2);
		ConfirmBtn = (UI_YesBtn_Large)(object)((GComponent)this).GetChild("ConfirmBtn");
		SelectedIcon = (GLoader)((GComponent)this).GetChild("SelectedIcon");
		SelectedName = (GTextField)((GComponent)this).GetChild("SelectedName");
		string id3 = "ui://47lbpgx9vur65g".Replace("ui://", "") + "-" + ((GObject)SelectedName).id;
		((GObject)SelectedName).text = LanguagesManager.GetDesc(id3);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Close = (GButton)((GComponent)this).GetChild("Close");
		helpBtn = (UI_btn_01)(object)((GComponent)this).GetChild("helpBtn");
	}
}
