using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_TakeItemContent : GComponent
{
	public Controller type;

	public GLoader icon;

	public GLoader icon2;

	public GTextField num;

	public GTextField title;

	public GButton ExclamationMarkBtn;

	public const string URL = "ui://47lbpgx9otto3b";

	public static string Name = "UI_TakeItemContent";

	public static string GetURL()
	{
		return "ui://47lbpgx9otto3b";
	}

	public static UI_TakeItemContent CreateInstance()
	{
		return (UI_TakeItemContent)(object)UIPackage.CreateObject("Tips", "TakeItemContent");
	}

	public static UI_TakeItemContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItemContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9otto3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		type = ((GComponent)this).GetController("type");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		icon2 = (GLoader)((GComponent)this).GetChild("icon2");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://47lbpgx9otto3b".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://47lbpgx9otto3b".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
	}
}
