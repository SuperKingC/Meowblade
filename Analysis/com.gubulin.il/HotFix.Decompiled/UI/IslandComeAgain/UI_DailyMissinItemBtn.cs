using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_DailyMissinItemBtn : GButton
{
	public Controller button;

	public Controller state;

	public GLoader rewardFrame;

	public GLoader rewardIcon;

	public GMovieClip n9;

	public GTextField rewardCnt;

	public GImage n7;

	public const string URL = "ui://k2sprg26rkqoal";

	public static string Name = "UI_DailyMissinItemBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26rkqoal";
	}

	public static UI_DailyMissinItemBtn CreateInstance()
	{
		return (UI_DailyMissinItemBtn)(object)UIPackage.CreateObject("IslandComeAgain", "DailyMissinItemBtn");
	}

	public static UI_DailyMissinItemBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailyMissinItemBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26rkqoal", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		state = ((GComponent)this).GetController("state");
		rewardFrame = (GLoader)((GComponent)this).GetChild("rewardFrame");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		n9 = (GMovieClip)((GComponent)this).GetChild("n9");
		rewardCnt = (GTextField)((GComponent)this).GetChild("rewardCnt");
		string id = "ui://k2sprg26rkqoal".Replace("ui://", "") + "-" + ((GObject)rewardCnt).id;
		((GObject)rewardCnt).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
