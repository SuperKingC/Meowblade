using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_Continue : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://249h3k3ddsas2z";

	public static string Name = "UI_btn_Continue";

	public static string GetURL()
	{
		return "ui://249h3k3ddsas2z";
	}

	public static UI_btn_Continue CreateInstance()
	{
		return (UI_btn_Continue)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_Continue");
	}

	public static UI_btn_Continue CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Continue).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3ddsas2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
