using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_messagerBtn : GButton
{
	public Controller button;

	public GTextField ChatContent;

	public GTextField sender;

	public Transition t0;

	public const string URL = "ui://j611zmymsafiv42j";

	public static string Name = "UI_messagerBtn";

	public static string GetURL()
	{
		return "ui://j611zmymsafiv42j";
	}

	public static UI_messagerBtn CreateInstance()
	{
		return (UI_messagerBtn)(object)UIPackage.CreateObject("MainCity", "messagerBtn");
	}

	public static UI_messagerBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_messagerBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymsafiv42j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ChatContent = (GTextField)((GComponent)this).GetChild("ChatContent");
		string id = "ui://j611zmymsafiv42j".Replace("ui://", "") + "-" + ((GObject)ChatContent).id;
		((GObject)ChatContent).text = LanguagesManager.GetDesc(id);
		sender = (GTextField)((GComponent)this).GetChild("sender");
		string id2 = "ui://j611zmymsafiv42j".Replace("ui://", "") + "-" + ((GObject)sender).id;
		((GObject)sender).text = LanguagesManager.GetDesc(id2);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
