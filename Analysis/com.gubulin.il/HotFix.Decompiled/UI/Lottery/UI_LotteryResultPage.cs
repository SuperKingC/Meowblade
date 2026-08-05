using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_LotteryResultPage : GComponent
{
	public GImage n19;

	public GLoader CardLoader2;

	public GLoader CardLoader3;

	public GLoader CardLoader4;

	public GLoader CardLoader5;

	public GLoader CardLoader6;

	public GLoader CardLoader7;

	public GLoader CardLoader8;

	public GLoader CardLoader9;

	public GLoader CardLoader10;

	public GLoader CardLoader1;

	public GTextField Tip;

	public GTextField Descrip;

	public UI_GetAllBtn GetAllBtn;

	public UI_ShareBtn ShareBtn;

	public UI_NotAllBtn ChangeLottery;

	public UI_ExitBtn ExitBtn;

	public UI_DetailedListBtn DetailedListBtn;

	public UI_ConfirmWindow ConfirmWindow;

	public const string URL = "ui://gxhnhhxkrtxaa";

	public static string Name = "UI_LotteryResultPage";

	public static string GetURL()
	{
		return "ui://gxhnhhxkrtxaa";
	}

	public static UI_LotteryResultPage CreateInstance()
	{
		return (UI_LotteryResultPage)(object)UIPackage.CreateObject("Lottery", "LotteryResultPage");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		CardLoader2 = (GLoader)((GComponent)this).GetChild("CardLoader2");
		CardLoader3 = (GLoader)((GComponent)this).GetChild("CardLoader3");
		CardLoader4 = (GLoader)((GComponent)this).GetChild("CardLoader4");
		CardLoader5 = (GLoader)((GComponent)this).GetChild("CardLoader5");
		CardLoader6 = (GLoader)((GComponent)this).GetChild("CardLoader6");
		CardLoader7 = (GLoader)((GComponent)this).GetChild("CardLoader7");
		CardLoader8 = (GLoader)((GComponent)this).GetChild("CardLoader8");
		CardLoader9 = (GLoader)((GComponent)this).GetChild("CardLoader9");
		CardLoader10 = (GLoader)((GComponent)this).GetChild("CardLoader10");
		CardLoader1 = (GLoader)((GComponent)this).GetChild("CardLoader1");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		Descrip = (GTextField)((GComponent)this).GetChild("Descrip");
		GetAllBtn = (UI_GetAllBtn)(object)((GComponent)this).GetChild("GetAllBtn");
		ShareBtn = (UI_ShareBtn)(object)((GComponent)this).GetChild("ShareBtn");
		ChangeLottery = (UI_NotAllBtn)(object)((GComponent)this).GetChild("ChangeLottery");
		ExitBtn = (UI_ExitBtn)(object)((GComponent)this).GetChild("ExitBtn");
		DetailedListBtn = (UI_DetailedListBtn)(object)((GComponent)this).GetChild("DetailedListBtn");
		ConfirmWindow = (UI_ConfirmWindow)(object)((GComponent)this).GetChild("ConfirmWindow");
	}
}
