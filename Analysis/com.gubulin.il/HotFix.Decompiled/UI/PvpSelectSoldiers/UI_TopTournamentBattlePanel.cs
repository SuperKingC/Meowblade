using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentBattlePanel : GComponent, IUiController
{
	public Controller Type;

	public GLoader background;

	public GImage n37;

	public GImage n57;

	public GImage n58;

	public GGraph n50;

	public GGroup backRight;

	public GButton BackBtn;

	public UI_Title PanelTitle;

	public UI_TopTournamentRankList TopTournamentRankList;

	public UI_btn_SeasonEntranceFunction TopTournamentIllustration;

	public UI_btn_SeasonEntranceFunction TopTournamentRewardPreview;

	public UI_btn_SeasonEntranceFunction TopTournamentNameList;

	public UI_btn_SeasonEntranceFunction SeasonMission;

	public UI_btn_SeasonEntranceFunction TopTournamentArray;

	public UI_TopTournamentCurDayLog TopTournamentCurDayLog;

	public const string URL = "ui://82mo10n5t7wpdfn";

	public static string Name = "UI_TopTournamentBattlePanel";

	public static UI_TopTournamentBattlePanel TopTournamentBattlePanel;

	private string PanelName => LanguagesManager.GetDesc("CsharpCodeZhTcText509");

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpdfn";
	}

	public static UI_TopTournamentBattlePanel CreateInstance()
	{
		return (UI_TopTournamentBattlePanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentBattlePanel");
	}

	public static UI_TopTournamentBattlePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentBattlePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpdfn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n50 = (GGraph)((GComponent)this).GetChild("n50");
		backRight = (GGroup)((GComponent)this).GetChild("backRight");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		PanelTitle = (UI_Title)(object)((GComponent)this).GetChild("PanelTitle");
		TopTournamentRankList = (UI_TopTournamentRankList)(object)((GComponent)this).GetChild("TopTournamentRankList");
		TopTournamentIllustration = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentIllustration");
		TopTournamentRewardPreview = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentRewardPreview");
		TopTournamentNameList = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentNameList");
		SeasonMission = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("SeasonMission");
		TopTournamentArray = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("TopTournamentArray");
		TopTournamentCurDayLog = (UI_TopTournamentCurDayLog)(object)((GComponent)this).GetChild("TopTournamentCurDayLog");
	}

	public void BeforeDestroy()
	{
		TopTournamentBattlePanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_TopTournamentRankList.Name);
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_TopTournamentCurDayLog.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		TopTournamentBattlePanel = this;
		PanelTitle.SetBuildingName(PanelName);
		int changeId = -1;
		if (parameters != null)
		{
			changeId = (parameters.TryGetValue("ChangeId", out var value) ? ((int)value) : (-1));
		}
		InitPanel(changeId);
		CheckSeasonMission();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)TopTournamentIllustration).onClick.Add(new EventCallback1(IllustrationClick));
		((GObject)TopTournamentRewardPreview).onClick.Add(new EventCallback1(RewardPreviewClick));
		((GObject)TopTournamentNameList).onClick.Add(new EventCallback1(NameListClick));
		((GObject)TopTournamentArray).onClick.Add(new EventCallback1(BattleArrayClick));
		((GObject)SeasonMission).onClick.Add(new EventCallback0(OnClickSeasonMissions));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)TopTournamentIllustration).onClick.Remove(new EventCallback1(IllustrationClick));
		((GObject)TopTournamentRewardPreview).onClick.Remove(new EventCallback1(RewardPreviewClick));
		((GObject)TopTournamentNameList).onClick.Remove(new EventCallback1(NameListClick));
		((GObject)TopTournamentArray).onClick.Remove(new EventCallback1(BattleArrayClick));
		((GObject)SeasonMission).onClick.Clear();
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void InitPanel(int changeId)
	{
		if (RankDataHelper.PeakBattleUnlocked())
		{
			Type.selectedIndex = 1;
		}
		else
		{
			Type.selectedIndex = 0;
		}
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		await TopTournamentRankList.Init();
		await TopTournamentCurDayLog.Init();
		if (changeId <= -1)
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.ClearUiTouchable();
		}
		else
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		if (!RankDataHelper.IsServerWideBattle)
		{
			((GObject)SeasonMission).visible = false;
			if (Type.selectedIndex == 1)
			{
				((GObject)TopTournamentArray).x = ((GObject)SeasonMission).x;
			}
		}
	}

	private void IllustrationClick(EventContext context)
	{
		UiHelper.OpenHelpPage("游戏帮助界面", "玩法", "天梯巅峰赛");
	}

	private void RewardPreviewClick(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Rank_RewardPanel.Name, null);
	}

	private void NameListClick(EventContext context)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)TopTournamentNameList).touchable = false;
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int num = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		((GComponent)(object)TopTournamentNameList).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)TopTournamentNameList).touchable = true;
		});
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TopTournamentNameList.Name, new Dictionary<string, object> { { "ChangeId", num } });
	}

	private void BattleArrayClick(EventContext context)
	{
		ILRequestHelper<GetPvPTopTournamentFormationResponse>.Request((EventContext)null, (Func<Task<GetPvPTopTournamentFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentFormation()), (Action<GetPvPTopTournamentFormationResponse>)delegate(GetPvPTopTournamentFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PeakBattleSelectArrayPanel.Name, new Dictionary<string, object> { { "FormationResponse", response } });
			}
		});
	}

	private void OnClickSeasonMissions()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PVPSeasonMissionPanel.Name, null);
	}

	private void CheckSeasonMission()
	{
		((GObject)SeasonMission.note).visible = RankDataHelper.SeasonMissionHasFreeBonusToClaim();
	}

	private void OnAnyUIClosed(string panelName)
	{
		if (panelName == UI_PVPSeasonMissionPanel.Name)
		{
			CheckSeasonMission();
		}
	}
}
