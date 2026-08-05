using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_SideQuestExpanded : GButton
{
	public GImage n14;

	public GList Quests;

	public const string URL = "ui://249h3k3ddb0o2l";

	public static string Name = "UI_btn_SideQuestExpanded";

	public static string GetURL()
	{
		return "ui://249h3k3ddb0o2l";
	}

	public static UI_btn_SideQuestExpanded CreateInstance()
	{
		return (UI_btn_SideQuestExpanded)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_SideQuestExpanded");
	}

	public static UI_btn_SideQuestExpanded CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SideQuestExpanded).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3ddb0o2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Quests = (GList)((GComponent)this).GetChild("Quests");
	}
}
