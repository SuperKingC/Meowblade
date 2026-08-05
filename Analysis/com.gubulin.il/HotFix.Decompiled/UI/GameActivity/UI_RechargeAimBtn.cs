using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_RechargeAimBtn : GButton
{
	public Controller button;

	public Controller ReceiveStatus;

	public Controller rewardStyle;

	public GImage n24;

	public GTextField title;

	public GTextField num;

	public UI_receiveBtn receiveBtn;

	public GList rewardList;

	public GGraph mask;

	public Transition disappear;

	public const string URL = "ui://29q48tv6gawy1g";

	public static string Name = "UI_RechargeAimBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1g";
	}

	public static UI_RechargeAimBtn CreateInstance()
	{
		return (UI_RechargeAimBtn)(object)UIPackage.CreateObject("GameActivity", "RechargeAimBtn");
	}

	public static UI_RechargeAimBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeAimBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		rewardStyle = ((GComponent)this).GetController("rewardStyle");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6gawy1g".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		rewardList = (GList)((GComponent)this).GetChild("rewardList");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
