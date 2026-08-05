using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Operation_Goto_Large : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GTextField title0;

	public GTextField title1;

	public const string URL = "ui://4eq8fgd2pjrq3h";

	public static string Name = "UI_btn_Operation_Goto_Large";

	public static string GetURL()
	{
		return "ui://4eq8fgd2pjrq3h";
	}

	public static UI_btn_Operation_Goto_Large CreateInstance()
	{
		return (UI_btn_Operation_Goto_Large)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Operation_Goto_Large");
	}

	public static UI_btn_Operation_Goto_Large CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Operation_Goto_Large).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pjrq3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://4eq8fgd2pjrq3h".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id2 = "ui://4eq8fgd2pjrq3h".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id2);
	}
}
