using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_ComfirmBtn : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n8;

	public const string URL = "ui://72fujxhkpipj4";

	public static string Name = "UI_ComfirmBtn";

	public static string GetURL()
	{
		return "ui://72fujxhkpipj4";
	}

	public static UI_ComfirmBtn CreateInstance()
	{
		return (UI_ComfirmBtn)(object)UIPackage.CreateObject("RecruitingCamp", "ComfirmBtn");
	}

	public static UI_ComfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkpipj4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bg = (GImage)((GComponent)this).GetChild("bg");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
