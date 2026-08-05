using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_PreviewProgressReward : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://249h3k3dndj6s4e";

	public static string Name = "UI_btn_PreviewProgressReward";

	public static string GetURL()
	{
		return "ui://249h3k3dndj6s4e";
	}

	public static UI_btn_PreviewProgressReward CreateInstance()
	{
		return (UI_btn_PreviewProgressReward)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_PreviewProgressReward");
	}

	public static UI_btn_PreviewProgressReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PreviewProgressReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dndj6s4e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
