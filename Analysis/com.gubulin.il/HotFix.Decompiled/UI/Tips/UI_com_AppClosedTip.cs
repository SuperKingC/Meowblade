using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_AppClosedTip : GComponent
{
	public Controller Type;

	public GImage back;

	public GTextField tip;

	public GTextField n29;

	public GTextField n30;

	public GTextField n31;

	public GTextField n33;

	public UI_popup_AppClosedTipDialog n32;

	public const string URL = "ui://47lbpgx9gybij5ltg9";

	public static string Name = "UI_com_AppClosedTip";

	public static string GetURL()
	{
		return "ui://47lbpgx9gybij5ltg9";
	}

	public static UI_com_AppClosedTip CreateInstance()
	{
		return (UI_com_AppClosedTip)(object)UIPackage.CreateObject("Tips", "com_AppClosedTip");
	}

	public static UI_com_AppClosedTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AppClosedTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gybij5ltg9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://47lbpgx9gybij5ltg9".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://47lbpgx9gybij5ltg9".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id3 = "ui://47lbpgx9gybij5ltg9".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id3);
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id4 = "ui://47lbpgx9gybij5ltg9".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id4);
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id5 = "ui://47lbpgx9gybij5ltg9".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id5);
		n32 = (UI_popup_AppClosedTipDialog)(object)((GComponent)this).GetChild("n32");
	}
}
