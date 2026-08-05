using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_CumulativeCostPanel : GComponent
{
	public GImage n84;

	public GImage n85;

	public GTextField tip;

	public UI_RechargeAchievementList AchievementList;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GList rewardList;

	public UI_TopUpBtn topUpBtn;

	public const string URL = "ui://29q48tv6gawy1e";

	public static string Name = "UI_CumulativeCostPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1e";
	}

	public static UI_CumulativeCostPanel CreateInstance()
	{
		return (UI_CumulativeCostPanel)(object)UIPackage.CreateObject("GameActivity", "CumulativeCostPanel");
	}

	public static UI_CumulativeCostPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CumulativeCostPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://29q48tv6gawy1e".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		AchievementList = (UI_RechargeAchievementList)(object)((GComponent)this).GetChild("AchievementList");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		topUpBtn = (UI_TopUpBtn)(object)((GComponent)this).GetChild("topUpBtn");
	}
}
