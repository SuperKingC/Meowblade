using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SkillBtnInside : GButton
{
	public Controller button;

	public GLoader IconLoader;

	public GImage frame;

	public const string URL = "ui://47lbpgx9ef7ej5ltgp";

	public static string Name = "UI_SkillBtnInside";

	public static string GetURL()
	{
		return "ui://47lbpgx9ef7ej5ltgp";
	}

	public static UI_SkillBtnInside CreateInstance()
	{
		return (UI_SkillBtnInside)(object)UIPackage.CreateObject("Tips", "SkillBtnInside");
	}

	public static UI_SkillBtnInside CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillBtnInside).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ef7ej5ltgp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		frame = (GImage)((GComponent)this).GetChild("frame");
	}
}
