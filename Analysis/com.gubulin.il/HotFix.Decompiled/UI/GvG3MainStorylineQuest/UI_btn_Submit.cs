using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_Submit : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField title;

	public const string URL = "ui://249h3k3dzit42t";

	public static string Name = "UI_btn_Submit";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42t";
	}

	public static UI_btn_Submit CreateInstance()
	{
		return (UI_btn_Submit)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_Submit");
	}

	public static UI_btn_Submit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Submit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://249h3k3dzit42t".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
