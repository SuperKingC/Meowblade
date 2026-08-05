using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_confirmBtn : GButton
{
	public Controller button;

	public GImage back;

	public GRichTextField title;

	public const string URL = "ui://b9yxt7u0t1jrn";

	public static string Name = "UI_confirmBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrn";
	}

	public static UI_confirmBtn CreateInstance()
	{
		return (UI_confirmBtn)(object)UIPackage.CreateObject("AccountInfo", "confirmBtn");
	}

	public static UI_confirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_confirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://b9yxt7u0t1jrn".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
