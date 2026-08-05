using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SignInPanel : GComponent
{
	public Controller Status;

	public GImage n23;

	public GImage n24;

	public GImage n28;

	public GGraph n27;

	public GGraph n11;

	public GTextField tip1st;

	public GList SignInLabelList;

	public GButton TurnPageLeftBtn;

	public GButton TurnPageRightBtn;

	public UI_rewardBtn155 cumulativeReward;

	public GTextField cumulativeTitle;

	public GTextField cumulativeDays;

	public GGraph cumulativeSfxBack;

	public const string URL = "ui://29q48tv6oa38r";

	public static string Name = "UI_SignInPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6oa38r";
	}

	public static UI_SignInPanel CreateInstance()
	{
		return (UI_SignInPanel)(object)UIPackage.CreateObject("GameActivity", "SignInPanel");
	}

	public static UI_SignInPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6oa38r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n27 = (GGraph)((GComponent)this).GetChild("n27");
		n11 = (GGraph)((GComponent)this).GetChild("n11");
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		string id = "ui://29q48tv6oa38r".Replace("ui://", "") + "-" + ((GObject)tip1st).id;
		((GObject)tip1st).text = LanguagesManager.GetDesc(id);
		SignInLabelList = (GList)((GComponent)this).GetChild("SignInLabelList");
		TurnPageLeftBtn = (GButton)((GComponent)this).GetChild("TurnPageLeftBtn");
		TurnPageRightBtn = (GButton)((GComponent)this).GetChild("TurnPageRightBtn");
		cumulativeReward = (UI_rewardBtn155)(object)((GComponent)this).GetChild("cumulativeReward");
		cumulativeTitle = (GTextField)((GComponent)this).GetChild("cumulativeTitle");
		string id2 = "ui://29q48tv6oa38r".Replace("ui://", "") + "-" + ((GObject)cumulativeTitle).id;
		((GObject)cumulativeTitle).text = LanguagesManager.GetDesc(id2);
		cumulativeDays = (GTextField)((GComponent)this).GetChild("cumulativeDays");
		cumulativeSfxBack = (GGraph)((GComponent)this).GetChild("cumulativeSfxBack");
	}
}
