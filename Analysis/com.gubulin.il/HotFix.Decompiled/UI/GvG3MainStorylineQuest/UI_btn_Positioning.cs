using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_Positioning : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title;

	public const string URL = "ui://249h3k3dqf7c1j";

	public static string Name = "UI_btn_Positioning";

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1j";
	}

	public static UI_btn_Positioning CreateInstance()
	{
		return (UI_btn_Positioning)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_Positioning");
	}

	public static UI_btn_Positioning CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Positioning).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://249h3k3dqf7c1j".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
