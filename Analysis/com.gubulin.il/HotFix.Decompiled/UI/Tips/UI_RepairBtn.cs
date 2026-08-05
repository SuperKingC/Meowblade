using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_RepairBtn : GButton
{
	public Controller button;

	public GImage background;

	public GTextField title;

	public const string URL = "ui://47lbpgx9bo6wd";

	public static string Name = "UI_RepairBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9bo6wd";
	}

	public static UI_RepairBtn CreateInstance()
	{
		return (UI_RepairBtn)(object)UIPackage.CreateObject("Tips", "RepairBtn");
	}

	public static UI_RepairBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RepairBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9bo6wd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9bo6wd".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
