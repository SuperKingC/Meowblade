using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_Lottery : GComponent
{
	public Controller PageController;

	public UI_ChooseLotteryPage ChooseLotteryPage;

	public UI_LotteryResultPage LotteryResultPage;

	public UI_ReadyLotteryPage ReadyLotteryPage;

	public const string URL = "ui://gxhnhhxkrtxa0";

	public static string Name = "UI_Lottery";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxa0";
	}

	public static UI_Lottery CreateInstance()
	{
		return (UI_Lottery)(object)UIPackage.CreateObject("Lottery", "Lottery");
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		ChooseLotteryPage = (UI_ChooseLotteryPage)(object)((GComponent)this).GetChild("ChooseLotteryPage");
		LotteryResultPage = (UI_LotteryResultPage)(object)((GComponent)this).GetChild("LotteryResultPage");
		ReadyLotteryPage = (UI_ReadyLotteryPage)(object)((GComponent)this).GetChild("ReadyLotteryPage");
	}
}
