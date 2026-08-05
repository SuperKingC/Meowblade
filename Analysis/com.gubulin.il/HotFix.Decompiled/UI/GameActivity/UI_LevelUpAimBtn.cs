using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_LevelUpAimBtn : GButton
{
	public Controller button;

	public Controller ReceiveStatus;

	public GImage n29;

	public GTextField title;

	public GTextField num;

	public GGraph n30;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public UI_ReceiveFundBonus ReceiveBtn;

	public GTextField rewardNum;

	public GGraph mask;

	public Transition disappear;

	public const string URL = "ui://29q48tv6n4413z";

	public static string Name = "UI_LevelUpAimBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6n4413z";
	}

	public static UI_LevelUpAimBtn CreateInstance()
	{
		return (UI_LevelUpAimBtn)(object)UIPackage.CreateObject("GameActivity", "LevelUpAimBtn");
	}

	public static UI_LevelUpAimBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelUpAimBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n4413z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6n4413z".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		n30 = (GGraph)((GComponent)this).GetChild("n30");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		ReceiveBtn = (UI_ReceiveFundBonus)(object)((GComponent)this).GetChild("ReceiveBtn");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
