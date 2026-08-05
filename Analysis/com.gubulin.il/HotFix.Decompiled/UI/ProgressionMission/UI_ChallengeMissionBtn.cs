using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ChallengeMissionBtn : GComponent
{
	public Controller ReceiveStatus;

	public GLoader clickBtn;

	public GImage n29;

	public GImage n30;

	public GGroup n31;

	public GImage n23;

	public GTextField title;

	public GTextField num;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GImage arrow;

	public GImage n34;

	public GImage n28;

	public GImage n32;

	public Transition disappear;

	public Transition t1;

	public const string URL = "ui://mapat4i5pjcu8g";

	public static string Name = "UI_ChallengeMissionBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5pjcu8g";
	}

	public static UI_ChallengeMissionBtn CreateInstance()
	{
		return (UI_ChallengeMissionBtn)(object)UIPackage.CreateObject("ProgressionMission", "ChallengeMissionBtn");
	}

	public static UI_ChallengeMissionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChallengeMissionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5pjcu8g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		clickBtn = (GLoader)((GComponent)this).GetChild("clickBtn");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		title = (GTextField)((GComponent)this).GetChild("title");
		num = (GTextField)((GComponent)this).GetChild("num");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		disappear = ((GComponent)this).GetTransition("disappear");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
