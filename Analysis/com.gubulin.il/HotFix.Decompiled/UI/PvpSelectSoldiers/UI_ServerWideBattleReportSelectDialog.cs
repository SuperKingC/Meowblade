using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBattleReportSelectDialog : GComponent
{
	public Controller ListCount;

	public GImage Background;

	public GButton ExitButton;

	public GImage n4;

	public GImage n16;

	public UI_BattleGroupTitle BattleGroupTitle;

	public GList PlayerBetList1;

	public GList PlayerBetList2;

	public GButton ConfirmBtn;

	public UI_BetRewardCountLabel BetRewardCountLabel;

	public Transition CountAlert;

	public const string URL = "ui://82mo10n5rnlpjdtw";

	public static string Name = "UI_ServerWideBattleReportSelectDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtw";
	}

	public static UI_ServerWideBattleReportSelectDialog CreateInstance()
	{
		return (UI_ServerWideBattleReportSelectDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBattleReportSelectDialog");
	}

	public static UI_ServerWideBattleReportSelectDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBattleReportSelectDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		ListCount = ((GComponent)this).GetController("ListCount");
		Background = (GImage)((GComponent)this).GetChild("Background");
		ExitButton = (GButton)((GComponent)this).GetChild("ExitButton");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		BattleGroupTitle = (UI_BattleGroupTitle)(object)((GComponent)this).GetChild("BattleGroupTitle");
		PlayerBetList1 = (GList)((GComponent)this).GetChild("PlayerBetList1");
		PlayerBetList2 = (GList)((GComponent)this).GetChild("PlayerBetList2");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		BetRewardCountLabel = (UI_BetRewardCountLabel)(object)((GComponent)this).GetChild("BetRewardCountLabel");
		CountAlert = ((GComponent)this).GetTransition("CountAlert");
	}
}
