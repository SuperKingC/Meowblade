using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_ReadyLotteryPage : GComponent
{
	public GImage n11;

	public GGraph n4;

	public GTextField JackpotName;

	public UI_ExitBtn ExitBtn;

	public UI_OpenJackpotBtn StartLottery;

	public UI_OpenLotteryBtn OpenLotteryBtn;

	public GTextField Tip;

	public const string URL = "ui://gxhnhhxkrtxao";

	public static string Name = "UI_ReadyLotteryPage";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxao";
	}

	public static UI_ReadyLotteryPage CreateInstance()
	{
		return (UI_ReadyLotteryPage)(object)UIPackage.CreateObject("Lottery", "ReadyLotteryPage");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		JackpotName = (GTextField)((GComponent)this).GetChild("JackpotName");
		ExitBtn = (UI_ExitBtn)(object)((GComponent)this).GetChild("ExitBtn");
		StartLottery = (UI_OpenJackpotBtn)(object)((GComponent)this).GetChild("StartLottery");
		OpenLotteryBtn = (UI_OpenLotteryBtn)(object)((GComponent)this).GetChild("OpenLotteryBtn");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
	}
}
