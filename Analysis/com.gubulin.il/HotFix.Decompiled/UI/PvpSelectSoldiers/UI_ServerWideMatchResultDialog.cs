using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideMatchResultDialog : GComponent
{
	public Controller ListCount;

	public GImage Background;

	public UI_eff_RuneCircle eff_RuneCircle;

	public GImage n50;

	public GImage n51;

	public GImage n52;

	public GTextField Tips;

	public GList BetSettingList1;

	public GList BetSettingList2;

	public GList BetSettingList3;

	public GList BetSettingList4;

	public GGroup BetSettingListGroup;

	public GTextField BetCountTitle;

	public GTextField BingoCountTitle;

	public GGroup BetCountTitleGroup;

	public GTextField BetCountText;

	public GTextField BingoCountText;

	public GGroup BetCountTextGroup;

	public GGroup BetCountGroup;

	public GImage n66;

	public GTextField BingoRateTitle;

	public GTextField BingoRateText;

	public GGroup BingoRateGroup;

	public GGroup n76;

	public UI_BetRewardCountLabel BetRewardCountLabel;

	public GMovieClip n74;

	public GButton ConfirmBtn;

	public GImage n47;

	public GTextField title;

	public Transition Appear1;

	public Transition Appear2;

	public const string URL = "ui://82mo10n5svvbjdu2";

	public static string Name = "UI_ServerWideMatchResultDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5svvbjdu2";
	}

	public static UI_ServerWideMatchResultDialog CreateInstance()
	{
		return (UI_ServerWideMatchResultDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideMatchResultDialog");
	}

	public static UI_ServerWideMatchResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideMatchResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5svvbjdu2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ListCount = ((GComponent)this).GetController("ListCount");
		Background = (GImage)((GComponent)this).GetChild("Background");
		eff_RuneCircle = (UI_eff_RuneCircle)(object)((GComponent)this).GetChild("eff_RuneCircle");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id = "ui://82mo10n5svvbjdu2".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id);
		BetSettingList1 = (GList)((GComponent)this).GetChild("BetSettingList1");
		BetSettingList2 = (GList)((GComponent)this).GetChild("BetSettingList2");
		BetSettingList3 = (GList)((GComponent)this).GetChild("BetSettingList3");
		BetSettingList4 = (GList)((GComponent)this).GetChild("BetSettingList4");
		BetSettingListGroup = (GGroup)((GComponent)this).GetChild("BetSettingListGroup");
		BetCountTitle = (GTextField)((GComponent)this).GetChild("BetCountTitle");
		string id2 = "ui://82mo10n5svvbjdu2".Replace("ui://", "") + "-" + ((GObject)BetCountTitle).id;
		((GObject)BetCountTitle).text = LanguagesManager.GetDesc(id2);
		BingoCountTitle = (GTextField)((GComponent)this).GetChild("BingoCountTitle");
		string id3 = "ui://82mo10n5svvbjdu2".Replace("ui://", "") + "-" + ((GObject)BingoCountTitle).id;
		((GObject)BingoCountTitle).text = LanguagesManager.GetDesc(id3);
		BetCountTitleGroup = (GGroup)((GComponent)this).GetChild("BetCountTitleGroup");
		BetCountText = (GTextField)((GComponent)this).GetChild("BetCountText");
		BingoCountText = (GTextField)((GComponent)this).GetChild("BingoCountText");
		BetCountTextGroup = (GGroup)((GComponent)this).GetChild("BetCountTextGroup");
		BetCountGroup = (GGroup)((GComponent)this).GetChild("BetCountGroup");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		BingoRateTitle = (GTextField)((GComponent)this).GetChild("BingoRateTitle");
		string id4 = "ui://82mo10n5svvbjdu2".Replace("ui://", "") + "-" + ((GObject)BingoRateTitle).id;
		((GObject)BingoRateTitle).text = LanguagesManager.GetDesc(id4);
		BingoRateText = (GTextField)((GComponent)this).GetChild("BingoRateText");
		BingoRateGroup = (GGroup)((GComponent)this).GetChild("BingoRateGroup");
		n76 = (GGroup)((GComponent)this).GetChild("n76");
		BetRewardCountLabel = (UI_BetRewardCountLabel)(object)((GComponent)this).GetChild("BetRewardCountLabel");
		n74 = (GMovieClip)((GComponent)this).GetChild("n74");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		title = (GTextField)((GComponent)this).GetChild("title");
		Appear1 = ((GComponent)this).GetTransition("Appear1");
		Appear2 = ((GComponent)this).GetTransition("Appear2");
	}
}
