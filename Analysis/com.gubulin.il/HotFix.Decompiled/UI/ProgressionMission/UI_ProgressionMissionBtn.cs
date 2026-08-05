using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionMissionBtn : GButton
{
	public Controller ReceiveStatus;

	public GLoader clickBtn;

	public GImage n23;

	public GTextField title;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GLoader progressBarBg;

	public GImage progressBar;

	public GMovieClip n31;

	public GImage n32;

	public GImage n30;

	public GImage n34;

	public GImage n33;

	public Transition disappear;

	public const string URL = "ui://mapat4i5nksh9f";

	public static string Name = "UI_ProgressionMissionBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5nksh9f";
	}

	public static UI_ProgressionMissionBtn CreateInstance()
	{
		return (UI_ProgressionMissionBtn)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionMissionBtn");
	}

	public static UI_ProgressionMissionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5nksh9f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		clickBtn = (GLoader)((GComponent)this).GetChild("clickBtn");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://mapat4i5nksh9f".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		progressBarBg = (GLoader)((GComponent)this).GetChild("progressBarBg");
		progressBar = (GImage)((GComponent)this).GetChild("progressBar");
		n31 = (GMovieClip)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
