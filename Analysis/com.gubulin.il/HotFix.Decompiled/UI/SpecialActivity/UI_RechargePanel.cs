using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RechargePanel : GComponent
{
	public Controller UseNewStyle;

	public GGraph backB;

	public UI_RechargeBack Back;

	public GGroup n19;

	public GTextField ActivityTime;

	public UI_RechargeAchievementList AchievementList;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GGroup n23;

	public UI_com_NewAchievementList AchievementList_NewStyle;

	public const string URL = "ui://kozswd8hqyx61a";

	public static string Name = "UI_RechargePanel";

	public static string GetURL()
	{
		return "ui://kozswd8hqyx61a";
	}

	public static UI_RechargePanel CreateInstance()
	{
		return (UI_RechargePanel)(object)UIPackage.CreateObject("SpecialActivity", "RechargePanel");
	}

	public static UI_RechargePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hqyx61a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UseNewStyle = ((GComponent)this).GetController("UseNewStyle");
		backB = (GGraph)((GComponent)this).GetChild("backB");
		Back = (UI_RechargeBack)(object)((GComponent)this).GetChild("Back");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
		AchievementList = (UI_RechargeAchievementList)(object)((GComponent)this).GetChild("AchievementList");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
		AchievementList_NewStyle = (UI_com_NewAchievementList)(object)((GComponent)this).GetChild("AchievementList_NewStyle");
	}
}
