using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_RewardDetail : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://249h3k3dsuqe17";

	public static string Name = "UI_btn_RewardDetail";

	public static string GetURL()
	{
		return "ui://249h3k3dsuqe17";
	}

	public static UI_btn_RewardDetail CreateInstance()
	{
		return (UI_btn_RewardDetail)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_RewardDetail");
	}

	public static UI_btn_RewardDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dsuqe17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
