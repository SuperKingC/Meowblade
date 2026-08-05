using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_activate2 : GButton
{
	public Controller button;

	public GImage background;

	public GRichTextField title;

	public GLoader icon;

	public const string URL = "ui://47lbpgx9ef7ej5ltgq";

	public static string Name = "UI_activate2";

	public static string GetURL()
	{
		return "ui://47lbpgx9ef7ej5ltgq";
	}

	public static UI_activate2 CreateInstance()
	{
		return (UI_activate2)(object)UIPackage.CreateObject("Tips", "activate2");
	}

	public static UI_activate2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_activate2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ef7ej5ltgq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9ef7ej5ltgq".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
