using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_ExperiencePage : GComponent
{
	public GGraph mask;

	public UI_ExperienceDialog Dialog;

	public UI_UpSoldierLevel UpSoldierLevelLogo;

	public Transition showSelf;

	public const string URL = "ui://7dantnbinnzi5y";

	public static string Name = "UI_ExperiencePage";

	public static string GetURL()
	{
		return "ui://7dantnbinnzi5y";
	}

	public static UI_ExperiencePage CreateInstance()
	{
		return (UI_ExperiencePage)(object)UIPackage.CreateObject("SoldierCultivate", "ExperiencePage");
	}

	public static UI_ExperiencePage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExperiencePage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbinnzi5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ExperienceDialog)(object)((GComponent)this).GetChild("Dialog");
		UpSoldierLevelLogo = (UI_UpSoldierLevel)(object)((GComponent)this).GetChild("UpSoldierLevelLogo");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
