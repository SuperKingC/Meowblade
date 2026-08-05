using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_rewardBtnWeekTree : GButton
{
	public Controller button;

	public Controller Quality;

	public GImage n5;

	public GLoader itemIcon;

	public GMovieClip n6;

	public GTextField Num;

	public Transition t0;

	public const string URL = "ui://29q48tv6kf8gf6z";

	public static string Name = "UI_rewardBtnWeekTree";

	public static string GetURL()
	{
		return "ui://29q48tv6kf8gf6z";
	}

	public static UI_rewardBtnWeekTree CreateInstance()
	{
		return (UI_rewardBtnWeekTree)(object)UIPackage.CreateObject("GameActivity", "rewardBtnWeekTree");
	}

	public static UI_rewardBtnWeekTree CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rewardBtnWeekTree).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6kf8gf6z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Quality = ((GComponent)this).GetController("Quality");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		n6 = (GMovieClip)((GComponent)this).GetChild("n6");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
