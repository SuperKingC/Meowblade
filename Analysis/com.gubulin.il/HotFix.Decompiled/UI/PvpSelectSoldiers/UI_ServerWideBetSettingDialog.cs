using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBetSettingDialog : GComponent
{
	public Controller IsFinalMatch;

	public Controller ListCount;

	public Controller OpenTipDialog;

	public GImage Background;

	public GButton ExitButton;

	public GImage n4;

	public GImage n16;

	public UI_BattleGroupTitle BattleGroupTitle;

	public GTextField TipTitle;

	public GImage n9;

	public GImage n11;

	public GTextField CountText;

	public GGroup TipTitleGroup;

	public GList PlayerBetList1;

	public GList PlayerBetList2;

	public GImage n33;

	public GTextField BetBingoTitle;

	public GTextField BetFailedTitle;

	public GGroup BetResultTipTitleGroup;

	public GLoader BetBingoItemIcon1;

	public GTextField BetBingoCount1;

	public GLoader BetBingoItemIcon2;

	public GTextField BetBingoCount2;

	public GLoader BetFailedItemIcon1;

	public GTextField BetFailedCount1;

	public GLoader BetFailedItemIcon2;

	public GTextField BetFailedCount2;

	public GGroup BetResultContentGroup;

	public GGroup BetResultTipGroup;

	public GButton ConfirmBtn;

	public GTextField n35;

	public GLoader BetItemIcon;

	public GTextField BetItemTotallyCount;

	public GGroup BetItemCountGroup;

	public GLoader clickMask;

	public UI_BetSelectTipDialog BetSelectTipDialog;

	public Transition CountAlert;

	public const string URL = "ui://82mo10n5rnlpjdtq";

	public static string Name = "UI_ServerWideBetSettingDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtq";
	}

	public static UI_ServerWideBetSettingDialog CreateInstance()
	{
		return (UI_ServerWideBetSettingDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBetSettingDialog");
	}

	public static UI_ServerWideBetSettingDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBetSettingDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFinalMatch = ((GComponent)this).GetController("IsFinalMatch");
		ListCount = ((GComponent)this).GetController("ListCount");
		OpenTipDialog = ((GComponent)this).GetController("OpenTipDialog");
		Background = (GImage)((GComponent)this).GetChild("Background");
		ExitButton = (GButton)((GComponent)this).GetChild("ExitButton");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		BattleGroupTitle = (UI_BattleGroupTitle)(object)((GComponent)this).GetChild("BattleGroupTitle");
		TipTitle = (GTextField)((GComponent)this).GetChild("TipTitle");
		string id = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)TipTitle).id;
		((GObject)TipTitle).text = LanguagesManager.GetDesc(id);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		CountText = (GTextField)((GComponent)this).GetChild("CountText");
		TipTitleGroup = (GGroup)((GComponent)this).GetChild("TipTitleGroup");
		PlayerBetList1 = (GList)((GComponent)this).GetChild("PlayerBetList1");
		PlayerBetList2 = (GList)((GComponent)this).GetChild("PlayerBetList2");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		BetBingoTitle = (GTextField)((GComponent)this).GetChild("BetBingoTitle");
		string id2 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetBingoTitle).id;
		((GObject)BetBingoTitle).text = LanguagesManager.GetDesc(id2);
		BetFailedTitle = (GTextField)((GComponent)this).GetChild("BetFailedTitle");
		string id3 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetFailedTitle).id;
		((GObject)BetFailedTitle).text = LanguagesManager.GetDesc(id3);
		BetResultTipTitleGroup = (GGroup)((GComponent)this).GetChild("BetResultTipTitleGroup");
		BetBingoItemIcon1 = (GLoader)((GComponent)this).GetChild("BetBingoItemIcon1");
		BetBingoCount1 = (GTextField)((GComponent)this).GetChild("BetBingoCount1");
		string id4 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetBingoCount1).id;
		((GObject)BetBingoCount1).text = LanguagesManager.GetDesc(id4);
		BetBingoItemIcon2 = (GLoader)((GComponent)this).GetChild("BetBingoItemIcon2");
		BetBingoCount2 = (GTextField)((GComponent)this).GetChild("BetBingoCount2");
		string id5 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetBingoCount2).id;
		((GObject)BetBingoCount2).text = LanguagesManager.GetDesc(id5);
		BetFailedItemIcon1 = (GLoader)((GComponent)this).GetChild("BetFailedItemIcon1");
		BetFailedCount1 = (GTextField)((GComponent)this).GetChild("BetFailedCount1");
		string id6 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetFailedCount1).id;
		((GObject)BetFailedCount1).text = LanguagesManager.GetDesc(id6);
		BetFailedItemIcon2 = (GLoader)((GComponent)this).GetChild("BetFailedItemIcon2");
		BetFailedCount2 = (GTextField)((GComponent)this).GetChild("BetFailedCount2");
		string id7 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)BetFailedCount2).id;
		((GObject)BetFailedCount2).text = LanguagesManager.GetDesc(id7);
		BetResultContentGroup = (GGroup)((GComponent)this).GetChild("BetResultContentGroup");
		BetResultTipGroup = (GGroup)((GComponent)this).GetChild("BetResultTipGroup");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id8 = "ui://82mo10n5rnlpjdtq".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id8);
		BetItemIcon = (GLoader)((GComponent)this).GetChild("BetItemIcon");
		BetItemTotallyCount = (GTextField)((GComponent)this).GetChild("BetItemTotallyCount");
		BetItemCountGroup = (GGroup)((GComponent)this).GetChild("BetItemCountGroup");
		clickMask = (GLoader)((GComponent)this).GetChild("clickMask");
		BetSelectTipDialog = (UI_BetSelectTipDialog)(object)((GComponent)this).GetChild("BetSelectTipDialog");
		CountAlert = ((GComponent)this).GetTransition("CountAlert");
	}
}
