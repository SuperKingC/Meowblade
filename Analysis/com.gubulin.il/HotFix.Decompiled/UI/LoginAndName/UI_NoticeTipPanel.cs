using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_NoticeTipPanel : GComponent
{
	public GGraph mask;

	public GImage back;

	public UI_noticeTip noticeTip;

	public GTextField title;

	public UI_exitBtn exit;

	public const string URL = "ui://yb3s7uv7bw1c29";

	public static string Name = "UI_NoticeTipPanel";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c29";
	}

	public static UI_NoticeTipPanel CreateInstance()
	{
		return (UI_NoticeTipPanel)(object)UIPackage.CreateObject("LoginAndName", "NoticeTipPanel");
	}

	public static UI_NoticeTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NoticeTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		noticeTip = (UI_noticeTip)(object)((GComponent)this).GetChild("noticeTip");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://yb3s7uv7bw1c29".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		exit = (UI_exitBtn)(object)((GComponent)this).GetChild("exit");
	}
}
