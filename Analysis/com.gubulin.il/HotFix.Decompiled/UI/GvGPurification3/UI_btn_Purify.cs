using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_btn_Purify : GButton
{
	public Controller button;

	public GImage n0;

	public GLoader icon;

	public const string URL = "ui://v7vqvgvmsmdjlc";

	public static string Name = "UI_btn_Purify";

	public static string GetURL()
	{
		return "ui://v7vqvgvmsmdjlc";
	}

	public static UI_btn_Purify CreateInstance()
	{
		return (UI_btn_Purify)(object)UIPackage.CreateObject("GvGPurification3", "btn_Purify");
	}

	public static UI_btn_Purify CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Purify).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjlc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
