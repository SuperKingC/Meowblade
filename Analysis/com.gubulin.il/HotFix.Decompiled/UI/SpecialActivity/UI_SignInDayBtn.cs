using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInDayBtn : GButton
{
	public Controller button;

	public Controller receiveController;

	public GImage back;

	public GTextField day;

	public UI_rewardBtn155 rewardBtn;

	public UI_SignInBtn SignInBtn;

	public GImage n7;

	public GImage n8;

	public UI_SignInReward SignInReward;

	public UI_SignInRewards SignInRewards;

	public const string URL = "ui://kozswd8hndjah";

	public static string Name = "UI_SignInDayBtn";

	public static string GetURL()
	{
		return "ui://kozswd8hndjah";
	}

	public static UI_SignInDayBtn CreateInstance()
	{
		return (UI_SignInDayBtn)(object)UIPackage.CreateObject("SpecialActivity", "SignInDayBtn");
	}

	public static UI_SignInDayBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInDayBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjah", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		receiveController = ((GComponent)this).GetController("receiveController");
		back = (GImage)((GComponent)this).GetChild("back");
		day = (GTextField)((GComponent)this).GetChild("day");
		string id = "ui://kozswd8hndjah".Replace("ui://", "") + "-" + ((GObject)day).id;
		((GObject)day).text = LanguagesManager.GetDesc(id);
		rewardBtn = (UI_rewardBtn155)(object)((GComponent)this).GetChild("rewardBtn");
		SignInBtn = (UI_SignInBtn)(object)((GComponent)this).GetChild("SignInBtn");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		SignInReward = (UI_SignInReward)(object)((GComponent)this).GetChild("SignInReward");
		SignInRewards = (UI_SignInRewards)(object)((GComponent)this).GetChild("SignInRewards");
	}
}
