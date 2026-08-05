using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_UnlockSkillBtn : GButton
{
	public Controller button;

	public UI_SkillBtnInside IconBtn;

	public UI_UnlockSkillLightBtn highLight;

	public const string URL = "ui://7dantnbilkklt7s";

	public static string Name = "UI_UnlockSkillBtn";

	public static string GetURL()
	{
		return "ui://7dantnbilkklt7s";
	}

	public static UI_UnlockSkillBtn CreateInstance()
	{
		return (UI_UnlockSkillBtn)(object)UIPackage.CreateObject("SoldierCultivate", "UnlockSkillBtn");
	}

	public static UI_UnlockSkillBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockSkillBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbilkklt7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IconBtn = (UI_SkillBtnInside)(object)((GComponent)this).GetChild("IconBtn");
		highLight = (UI_UnlockSkillLightBtn)(object)((GComponent)this).GetChild("highLight");
	}
}
