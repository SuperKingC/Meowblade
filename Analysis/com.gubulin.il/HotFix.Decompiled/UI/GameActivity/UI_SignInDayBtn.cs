using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SignInDayBtn : GButton
{
	public Controller button;

	public Controller receiveController;

	public GImage back;

	public GTextField day;

	public UI_rewardBtn155 rewardBtn;

	public GButton SignInBtn;

	public GImage dayTip2;

	public GImage dayTip7;

	public const string URL = "ui://29q48tv6gawyu";

	public static string Name = "UI_SignInDayBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6gawyu";
	}

	public static UI_SignInDayBtn CreateInstance()
	{
		return (UI_SignInDayBtn)(object)UIPackage.CreateObject("GameActivity", "SignInDayBtn");
	}

	public static UI_SignInDayBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInDayBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawyu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		receiveController = ((GComponent)this).GetController("receiveController");
		back = (GImage)((GComponent)this).GetChild("back");
		day = (GTextField)((GComponent)this).GetChild("day");
		string id = "ui://29q48tv6gawyu".Replace("ui://", "") + "-" + ((GObject)day).id;
		((GObject)day).text = LanguagesManager.GetDesc(id);
		rewardBtn = (UI_rewardBtn155)(object)((GComponent)this).GetChild("rewardBtn");
		SignInBtn = (GButton)((GComponent)this).GetChild("SignInBtn");
		dayTip2 = (GImage)((GComponent)this).GetChild("dayTip2");
		dayTip7 = (GImage)((GComponent)this).GetChild("dayTip7");
	}
}
