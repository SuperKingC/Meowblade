using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_Page02 : GButton
{
	public Controller button;

	public GImage n13;

	public GImage RedDot;

	public const string URL = "ui://249h3k3dqf7c1d";

	public static string Name = "UI_btn_Page02";

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1d";
	}

	public static UI_btn_Page02 CreateInstance()
	{
		return (UI_btn_Page02)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_Page02");
	}

	public static UI_btn_Page02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Page02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n13 = (GImage)((GComponent)this).GetChild("n13");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}
