using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_rewardBtnWeekSpin : GButton
{
	public Controller button;

	public Controller Type;

	public Controller State;

	public GLoader iconBack;

	public GLoader icon;

	public GTextField num;

	public GMovieClip n7;

	public GMovieClip n8;

	public const string URL = "ui://29q48tv6q9xef5e";

	public static string Name = "UI_rewardBtnWeekSpin";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef5e";
	}

	public static UI_rewardBtnWeekSpin CreateInstance()
	{
		return (UI_rewardBtnWeekSpin)(object)UIPackage.CreateObject("GameActivity", "rewardBtnWeekSpin");
	}

	public static UI_rewardBtnWeekSpin CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rewardBtnWeekSpin).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef5e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		iconBack = (GLoader)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
	}
}
