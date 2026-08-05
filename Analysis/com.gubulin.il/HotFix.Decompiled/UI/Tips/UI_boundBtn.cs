using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_boundBtn : GButton
{
	public Controller button;

	public GImage back;

	public GRichTextField title;

	public const string URL = "ui://47lbpgx9hrru4w";

	public static string Name = "UI_boundBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9hrru4w";
	}

	public static UI_boundBtn CreateInstance()
	{
		return (UI_boundBtn)(object)UIPackage.CreateObject("Tips", "boundBtn");
	}

	public static UI_boundBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_boundBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9hrru4w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9hrru4w".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
