using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_ChooseLotteryPage : GComponent
{
	public Controller ChooseController;

	public GImage n68;

	public GLoader LotteryImageLoader;

	public UI_generialJackpotBtn GeneralJackpotBtn;

	public UI_SpecialJackpotBtn SpecialJackpotBtnA;

	public UI_SpecialJackpotBtnB SpecialJackpotBtnB;

	public UI_ExitBtn ExitBtn;

	public UI_EnterJackpotBtn EnterjackpotBtn;

	public UI_LotteryTimesProcessBar LotteryTimesProcessBar;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public UI_LotteryRulesBtn LotteryRuleBtn;

	public const string URL = "ui://gxhnhhxkhblgq";

	public static string Name = "UI_ChooseLotteryPage";

	public static string GetURL()
	{
		return "ui://gxhnhhxkhblgq";
	}

	public static UI_ChooseLotteryPage CreateInstance()
	{
		return (UI_ChooseLotteryPage)(object)UIPackage.CreateObject("Lottery", "ChooseLotteryPage");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ChooseController = ((GComponent)this).GetController("ChooseController");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		LotteryImageLoader = (GLoader)((GComponent)this).GetChild("LotteryImageLoader");
		GeneralJackpotBtn = (UI_generialJackpotBtn)(object)((GComponent)this).GetChild("GeneralJackpotBtn");
		SpecialJackpotBtnA = (UI_SpecialJackpotBtn)(object)((GComponent)this).GetChild("SpecialJackpotBtnA");
		SpecialJackpotBtnB = (UI_SpecialJackpotBtnB)(object)((GComponent)this).GetChild("SpecialJackpotBtnB");
		ExitBtn = (UI_ExitBtn)(object)((GComponent)this).GetChild("ExitBtn");
		EnterjackpotBtn = (UI_EnterJackpotBtn)(object)((GComponent)this).GetChild("EnterjackpotBtn");
		LotteryTimesProcessBar = (UI_LotteryTimesProcessBar)(object)((GComponent)this).GetChild("LotteryTimesProcessBar");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		LotteryRuleBtn = (UI_LotteryRulesBtn)(object)((GComponent)this).GetChild("LotteryRuleBtn");
	}
}
