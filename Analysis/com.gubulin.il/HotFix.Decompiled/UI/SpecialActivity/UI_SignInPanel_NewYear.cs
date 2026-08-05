using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInPanel_NewYear : GComponent
{
	public Controller RetroactiveSignInAvailable;

	public GGraph backB;

	public UI_NYBack Back;

	public UI_RetroactiveSignInInfoLandscape RetroactiveSignInInfo;

	public GGroup n19;

	public GTextField ActivityTime;

	public UI_RechargeAchievementList AchievementList;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public const string URL = "ui://kozswd8hjmcp1i";

	public static string Name = "UI_SignInPanel_NewYear";

	public static string GetURL()
	{
		return "ui://kozswd8hjmcp1i";
	}

	public static UI_SignInPanel_NewYear CreateInstance()
	{
		return (UI_SignInPanel_NewYear)(object)UIPackage.CreateObject("SpecialActivity", "SignInPanel_NewYear");
	}

	public static UI_SignInPanel_NewYear CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInPanel_NewYear).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hjmcp1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RetroactiveSignInAvailable = ((GComponent)this).GetController("RetroactiveSignInAvailable");
		backB = (GGraph)((GComponent)this).GetChild("backB");
		Back = (UI_NYBack)(object)((GComponent)this).GetChild("Back");
		RetroactiveSignInInfo = (UI_RetroactiveSignInInfoLandscape)(object)((GComponent)this).GetChild("RetroactiveSignInInfo");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
		AchievementList = (UI_RechargeAchievementList)(object)((GComponent)this).GetChild("AchievementList");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
	}
}
