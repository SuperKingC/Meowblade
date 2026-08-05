using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_ClosePreviewReward : GButton
{
	public GImage back;

	public GLoader n3;

	public const string URL = "ui://249h3k3dndj6s4c";

	public static string Name = "UI_btn_ClosePreviewReward";

	public static string GetURL()
	{
		return "ui://249h3k3dndj6s4c";
	}

	public static UI_btn_ClosePreviewReward CreateInstance()
	{
		return (UI_btn_ClosePreviewReward)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_ClosePreviewReward");
	}

	public static UI_btn_ClosePreviewReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ClosePreviewReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dndj6s4c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
	}
}
