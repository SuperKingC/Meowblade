using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_SecretTreasury : GComponent
{
	public Controller UseNewStyle;

	public UI_com_AchimentListWithMask AchievementList;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GGroup n23;

	public GLoader activityBg;

	public GGroup n26;

	public GTextField ActivityTime;

	public UI_TopUpBtn topupBtn;

	public GRichTextField showRuleBtn;

	public const string URL = "ui://29q48tv6nkejf4f";

	public static string Name = "UI_com_SecretTreasury";

	public static string GetURL()
	{
		return "ui://29q48tv6nkejf4f";
	}

	public static UI_com_SecretTreasury CreateInstance()
	{
		return (UI_com_SecretTreasury)(object)UIPackage.CreateObject("GameActivity", "com_SecretTreasury");
	}

	public static UI_com_SecretTreasury CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SecretTreasury).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6nkejf4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UseNewStyle = ((GComponent)this).GetController("UseNewStyle");
		AchievementList = (UI_com_AchimentListWithMask)(object)((GComponent)this).GetChild("AchievementList");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
		activityBg = (GLoader)((GComponent)this).GetChild("activityBg");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
		topupBtn = (UI_TopUpBtn)(object)((GComponent)this).GetChild("topupBtn");
		showRuleBtn = (GRichTextField)((GComponent)this).GetChild("showRuleBtn");
		string id = "ui://29q48tv6nkejf4f".Replace("ui://", "") + "-" + ((GObject)showRuleBtn).id;
		((GObject)showRuleBtn).text = LanguagesManager.GetDesc(id);
	}
}
