using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.BattleLog;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGBattleRecord3;

public class UI_main_IslandCampaignPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_CampaignInfoDialog Dialog;

	public Transition t0;

	public const string URL = "ui://b3fc6085stwvg";

	public static string Name = "UI_main_IslandCampaignPanel";

	private const string INSURANCE_CLONE_SHIP = "_Insurance";

	private string _processId;

	private List<IslandLogBrief> _islandLogBriefs = new List<IslandLogBrief>();

	private List<IslandLogBrief> _currentIslandLogBriefs = new List<IslandLogBrief>();

	private int _islandId;

	private bool _reservePackageResOnClose;

	private IslandLogBrief _expandedLog;

	private IslandLog _islandLog;

	private string _eventName;

	private bool _isBossBattle;

	private int _winnerCampId;

	private bool _isRunning;

	private bool OnlyMyCamp => ((GButton)Dialog.CampSelect).selected;

	private int MyUserId => GameController.Contexts.gameState.user.value.UserId;

	private int MyCampId => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;

	private bool HasEvent => !string.IsNullOrEmpty(_eventName);

	public static string GetURL()
	{
		return "ui://b3fc6085stwvg";
	}

	public static UI_main_IslandCampaignPanel CreateInstance()
	{
		return (UI_main_IslandCampaignPanel)(object)UIPackage.CreateObject("GvGBattleRecord3", "main_IslandCampaignPanel");
	}

	public static UI_main_IslandCampaignPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandCampaignPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_CampaignInfoDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_processId = (parameters.TryGetValue("ProcessId", out var value) ? value.ToString() : string.Empty);
		_islandId = (parameters.TryGetValue("IslandId", out var value2) ? ((int)value2) : 0);
		_reservePackageResOnClose = parameters.TryGetValue("ReservePackageResOnClose", out var value3) && (bool)value3;
		_eventName = (parameters.TryGetValue("RandomEventName", out var value4) ? value4.ToString() : string.Empty);
		_isBossBattle = parameters.TryGetValue("IsBossBattle", out var value5) && (bool)value5;
		_winnerCampId = (parameters.TryGetValue("WinnerCampId", out var value6) ? ((int)value6) : 0);
		_isRunning = parameters.TryGetValue("IsRunning", out var value7) && (bool)value7;
		_islandLog = (parameters.TryGetValue("IslandLog", out var value8) ? ((IslandLog)value8) : null);
		Dialog.HasEventRanking.selectedIndex = (HasEvent ? 1 : 0);
		Dialog.BattleState.SetSelectedIndex(_isRunning ? 1 : 0);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetIslandLogBrief(_processId, RenderMainUi);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.CheckDetail).onClick.Add(new EventCallback0(OnCheckDetailClick));
		((GButton)Dialog.CampSelect).onChanged.Add(new EventCallback0(UpdateLogBrief));
		((GObject)Dialog.CheckEventRanking).onClick.Set(new EventCallback1(CheckIslandEventRanking));
		((GObject)Dialog.Help).onClick.Set(new EventCallback0(ShowCampaignContributionAccessTip));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.CheckDetail).onClick.Remove(new EventCallback0(OnCheckDetailClick));
		((GButton)Dialog.CampSelect).onChanged.Remove(new EventCallback0(UpdateLogBrief));
		((GObject)Dialog.CheckEventRanking).onClick.Clear();
		((GObject)Dialog.Help).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, _reservePackageResOnClose);
	}

	private void OnCheckDetailClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3BattleRecordsPanel.Name, new Dictionary<string, object>
		{
			{ "ProcessId", _processId },
			{ "IslandId", _islandId },
			{ "ReservePackageResOnClose", true },
			{ "IslandLog", true },
			{ "GetFormRunningResource", _isRunning },
			{
				"ShowTimeStamp",
				_islandLog == null || !_islandLog.IsBrawlFight()
			}
		});
	}

	private void CheckIslandEventRanking(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3IslandEventRanking.Name, new Dictionary<string, object>
		{
			{ "ProcessId", _processId },
			{ "IslandId", _islandId },
			{ "IsBossBattle", _isBossBattle },
			{ "WinnerCampId", _winnerCampId },
			{ "RandomEvent", _eventName }
		});
	}

	private void ShowCampaignContributionAccessTip()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip<UI_com_CampaignContributionAccess>((GObject)(object)Dialog.Help, eFairyGUITipDir.Down, RenderTip);
		static void RenderTip(UI_com_CampaignContributionAccess tip)
		{
			((GObject)tip.Desc).text = "GvGCampaignContributionAccess".ToLanguage();
		}
	}

	private void RenderMainUi(List<IslandLogBrief> logBriefs)
	{
		if (logBriefs != null)
		{
			_islandLogBriefs = logBriefs.Clone();
			RenderMyRanking();
			UpdateLogBrief();
		}
	}

	private void UpdateLogBrief()
	{
		List<IslandLogBrief> list = new List<IslandLogBrief>();
		list = ((!OnlyMyCamp) ? _islandLogBriefs.Clone() : _islandLogBriefs.Where((IslandLogBrief log) => log.CampId == MyCampId).ToList());
		list.Sort((IslandLogBrief a, IslandLogBrief b) => a.TotalRank - b.TotalRank);
		RenderUserRankingDataList(list);
	}

	private void RenderUserRankingDataList(List<IslandLogBrief> logBriefs)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		_currentIslandLogBriefs = logBriefs;
		Dialog.UserRankingData.SetVirtual();
		Dialog.UserRankingData.itemProvider = new ListItemProvider(GetListItemResource);
		Dialog.UserRankingData.itemRenderer = new ListItemRenderer(RenderUserRankingItem);
		Dialog.UserRankingData.numItems = _currentIslandLogBriefs.Count;
	}

	private string GetListItemResource(int index)
	{
		IslandLogBrief islandLogBrief = _currentIslandLogBriefs[index];
		return islandLogBrief.Expanded ? "ui://GvGBattleRecord3/btn_CampaignUserDataExpanded" : "ui://GvGBattleRecord3/btn_CampaignUserData";
	}

	private void RenderUserRankingItem(int index, GObject obj)
	{
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		IslandLogBrief islandLogBrief = _currentIslandLogBriefs[index];
		if (islandLogBrief.Expanded && obj is UI_btn_CampaignUserDataExpanded uI_btn_CampaignUserDataExpanded)
		{
			((GObject)uI_btn_CampaignUserDataExpanded).onClick.Clear();
			RenderShipScore(uI_btn_CampaignUserDataExpanded.ShipData, islandLogBrief.ShipReports, islandLogBrief.CampId);
			uI_btn_CampaignUserDataExpanded.ShipData.ResizeToFit(uI_btn_CampaignUserDataExpanded.ShipData.numItems);
		}
		else if (obj is UI_btn_CampaignUserData uI_btn_CampaignUserData)
		{
			int rank = islandLogBrief.Rank;
			if (rank <= 3)
			{
				uI_btn_CampaignUserData.Rank.selectedIndex = rank - 1;
			}
			else
			{
				uI_btn_CampaignUserData.Rank.selectedIndex = 3;
			}
			((GObject)uI_btn_CampaignUserData.Ranking).text = rank.ToString();
			((GObject)uI_btn_CampaignUserData.ShipNum).text = islandLogBrief.ShipReports.Count.ToString();
			((GObject)uI_btn_CampaignUserData.Kill).text = islandLogBrief.Kill.ToString();
			((GObject)uI_btn_CampaignUserData.Loss).text = islandLogBrief.Loss.ToString();
			((GObject)uI_btn_CampaignUserData.Occupy).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(islandLogBrief.HoldingProgress.ToString("F"));
			uI_btn_CampaignUserData.Winner.selectedIndex = ((_winnerCampId == islandLogBrief.CampId) ? 1 : 0);
			((GObject)uI_btn_CampaignUserData.TotalScore).text = Mathf.RoundToInt(islandLogBrief.TotalScore).ToString();
			uI_btn_CampaignUserData.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayLeft>
			{
				CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
				UserId = islandLogBrief.UserId,
				CampId = islandLogBrief.CampId,
				OnProfileLoaded = delegate(UI_com_ProfileDisplayLeft displayUi)
				{
					displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
				}
			}, islandLogBrief.UserId);
			((GObject)uI_btn_CampaignUserData).data = index;
			((GObject)uI_btn_CampaignUserData).onClick.Set(new EventCallback1(ExpandUserRankingData));
		}
	}

	private void ExpandUserRankingData(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)context.sender).data;
		if (_expandedLog == null)
		{
			_expandedLog = new IslandLogBrief
			{
				Expanded = true
			};
		}
		IslandLogBrief islandLogBrief = _currentIslandLogBriefs[index];
		if (_currentIslandLogBriefs.Contains(_expandedLog))
		{
			_currentIslandLogBriefs.Remove(_expandedLog);
		}
		if (islandLogBrief.Rank != _expandedLog.Rank)
		{
			_expandedLog.Rank = islandLogBrief.Rank;
			_expandedLog.CampId = islandLogBrief.CampId;
			_expandedLog.ShipReports = islandLogBrief.ShipReports;
			_currentIslandLogBriefs.Insert(_currentIslandLogBriefs.IndexOf(islandLogBrief) + 1, _expandedLog);
		}
		else
		{
			_expandedLog.Rank = 0;
		}
		Dialog.UserRankingData.numItems = _currentIslandLogBriefs.Count;
	}

	private void RenderMyRanking()
	{
		IslandLogBrief islandLogBrief = _islandLogBriefs.FirstOrDefault((IslandLogBrief log) => log.UserId == MyUserId);
		if (islandLogBrief == null)
		{
			Dialog.Type.selectedIndex = 1;
			return;
		}
		Dialog.Type.selectedIndex = 0;
		UI_btn_CampaignMyData btn = Dialog.MyRankingData;
		int rank = islandLogBrief.Rank;
		if (rank <= 3)
		{
			btn.Rank.selectedIndex = rank - 1;
		}
		else
		{
			btn.Rank.selectedIndex = 3;
		}
		((GObject)btn.Ranking).text = rank.ToString();
		((GObject)btn.ShipNum).text = islandLogBrief.ShipReports.Count.ToString();
		((GObject)btn.Kill).text = islandLogBrief.Kill.ToString();
		((GObject)btn.Loss).text = islandLogBrief.Loss.ToString();
		((GObject)btn.Occupy).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(islandLogBrief.HoldingProgress.ToString("F"));
		((GObject)btn.TotalScore).text = Mathf.RoundToInt(islandLogBrief.TotalScore).ToString();
		RenderShipScore(btn.ShipData, islandLogBrief.ShipReports, islandLogBrief.CampId);
		btn.ShipData.ResizeToFit(btn.ShipData.numItems);
		btn.UserIcon.CampId.selectedIndex = islandLogBrief.CampId;
		btn.Winner.selectedIndex = ((_winnerCampId == islandLogBrief.CampId) ? 1 : 0);
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", islandLogBrief.UserId, delegate(UserProfile profile)
		{
			((GObject)btn.UserName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			btn.UserIcon.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
	}

	private void RenderShipScore(GList shipList, List<IslandLogBrief_Ship> shipReports, int campId)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		shipList.itemRenderer = new ListItemRenderer(RenderShipReport);
		shipList.numItems = shipReports.Count;
		void RenderShipReport(int index, GObject obj)
		{
			if (obj is UI_com_CampaignShipData uI_com_CampaignShipData)
			{
				IslandLogBrief_Ship islandLogBrief_Ship = shipReports[index];
				((GObject)uI_com_CampaignShipData.Kill).text = islandLogBrief_Ship.Kill.ToString();
				((GObject)uI_com_CampaignShipData.Loss).text = islandLogBrief_Ship.Loss.ToString();
				uI_com_CampaignShipData.Type.SetSelectedIndex(islandLogBrief_Ship.ShipId.Contains("_Insurance") ? 1 : 0);
				((GObject)uI_com_CampaignShipData.Occupy).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(islandLogBrief_Ship.HoldingProgressUi.ToString("F"));
				((GObject)uI_com_CampaignShipData.TotalScore).text = Mathf.RoundToInt(islandLogBrief_Ship.ShipStatData.TotalContributionPoints).ToString();
				((UI_com_ShipSmallIcon)(object)uI_com_CampaignShipData.ShipIcon).SetShipStyle(islandLogBrief_Ship.ShipRace, campId);
			}
		}
	}
}
