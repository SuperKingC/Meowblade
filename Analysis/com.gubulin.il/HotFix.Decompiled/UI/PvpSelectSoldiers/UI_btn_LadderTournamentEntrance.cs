using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_LadderTournamentEntrance : GComponent
{
	public Controller LadderTournamentState;

	public GImage CardFrame;

	public GLoader CardPicture;

	public GLoader TitleName;

	public GTextField EventDuration;

	public GTextField WeekCount;

	public GImage PlayerRankPanel;

	public GImage DevilRibbon;

	public GTextField PlayerRankText;

	public GTextField PlayerRankLevel;

	public GTextField PlayerRankNumber;

	public GTextField PlayerNoRank;

	public GGroup PlayerRankGroup;

	public GImage n17;

	public GTextField SecondInfoTitle;

	public GTextField SecondInfoContent;

	public GGroup SecondInfoGroup;

	public GImage n21;

	public GTextField StateText;

	public GGroup StateGroup;

	public GButton LadderTournamentButton;

	public GGroup CardGroup;

	public Transition t0;

	public const string URL = "ui://82mo10n5r204dot";

	public static string Name = "UI_btn_LadderTournamentEntrance";

	public static string GetURL()
	{
		return "ui://82mo10n5r204dot";
	}

	public static UI_btn_LadderTournamentEntrance CreateInstance()
	{
		return (UI_btn_LadderTournamentEntrance)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_LadderTournamentEntrance");
	}

	public static UI_btn_LadderTournamentEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LadderTournamentEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5r204dot", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LadderTournamentState = ((GComponent)this).GetController("LadderTournamentState");
		CardFrame = (GImage)((GComponent)this).GetChild("CardFrame");
		CardPicture = (GLoader)((GComponent)this).GetChild("CardPicture");
		TitleName = (GLoader)((GComponent)this).GetChild("TitleName");
		EventDuration = (GTextField)((GComponent)this).GetChild("EventDuration");
		WeekCount = (GTextField)((GComponent)this).GetChild("WeekCount");
		PlayerRankPanel = (GImage)((GComponent)this).GetChild("PlayerRankPanel");
		DevilRibbon = (GImage)((GComponent)this).GetChild("DevilRibbon");
		PlayerRankText = (GTextField)((GComponent)this).GetChild("PlayerRankText");
		string id = "ui://82mo10n5r204dot".Replace("ui://", "") + "-" + ((GObject)PlayerRankText).id;
		((GObject)PlayerRankText).text = LanguagesManager.GetDesc(id);
		PlayerRankLevel = (GTextField)((GComponent)this).GetChild("PlayerRankLevel");
		PlayerRankNumber = (GTextField)((GComponent)this).GetChild("PlayerRankNumber");
		PlayerNoRank = (GTextField)((GComponent)this).GetChild("PlayerNoRank");
		PlayerRankGroup = (GGroup)((GComponent)this).GetChild("PlayerRankGroup");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		SecondInfoTitle = (GTextField)((GComponent)this).GetChild("SecondInfoTitle");
		string id2 = "ui://82mo10n5r204dot".Replace("ui://", "") + "-" + ((GObject)SecondInfoTitle).id;
		((GObject)SecondInfoTitle).text = LanguagesManager.GetDesc(id2);
		SecondInfoContent = (GTextField)((GComponent)this).GetChild("SecondInfoContent");
		SecondInfoGroup = (GGroup)((GComponent)this).GetChild("SecondInfoGroup");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		StateText = (GTextField)((GComponent)this).GetChild("StateText");
		string id3 = "ui://82mo10n5r204dot".Replace("ui://", "") + "-" + ((GObject)StateText).id;
		((GObject)StateText).text = LanguagesManager.GetDesc(id3);
		StateGroup = (GGroup)((GComponent)this).GetChild("StateGroup");
		LadderTournamentButton = (GButton)((GComponent)this).GetChild("LadderTournamentButton");
		CardGroup = (GGroup)((GComponent)this).GetChild("CardGroup");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
