using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_AchievementWrapper : GComponent
{
	public UI_com_Achievement Achievement;

	public Transition RemoveTrans;

	public Transition Appear;

	public Transition Disappear;

	public const string URL = "ui://rx5ntv98win2a";

	public static string Name = "UI_com_AchievementWrapper";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2a";
	}

	public static UI_com_AchievementWrapper CreateInstance()
	{
		return (UI_com_AchievementWrapper)(object)UIPackage.CreateObject("ReturningRewards", "com_AchievementWrapper");
	}

	public static UI_com_AchievementWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AchievementWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Achievement = (UI_com_Achievement)(object)((GComponent)this).GetChild("Achievement");
		RemoveTrans = ((GComponent)this).GetTransition("RemoveTrans");
		Appear = ((GComponent)this).GetTransition("Appear");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}
