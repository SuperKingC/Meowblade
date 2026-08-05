using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentEveryDayLogPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_TopTournamentEveryDayLogDialog EveryDayLogDialog;

	public const string URL = "ui://82mo10n5aveldgq";

	public static string Name = "UI_TopTournamentEveryDayLogPanel";

	public static UI_TopTournamentEveryDayLogPanel TopTournamentEveryDayLogPanel;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private Dictionary<int, string> DayIndexData = new Dictionary<int, string>();

	private int currentDayIndex;

	private Dictionary<string, List<Dictionary<string, object>>> TodayBattleLogData = new Dictionary<string, List<Dictionary<string, object>>>();

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgq";
	}

	public static UI_TopTournamentEveryDayLogPanel CreateInstance()
	{
		return (UI_TopTournamentEveryDayLogPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentEveryDayLogPanel");
	}

	public static UI_TopTournamentEveryDayLogPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentEveryDayLogPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		EveryDayLogDialog = (UI_TopTournamentEveryDayLogDialog)(object)((GComponent)this).GetChild("EveryDayLogDialog");
	}

	public void BeforeDestroy()
	{
		TopTournamentEveryDayLogPanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_TopTournamentLogComponent.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		TopTournamentEveryDayLogPanel = this;
		currentDayIndex = EveryDayLogDialog.DayIndexList.Init();
		BattleLogInit(currentDayIndex);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public async void BattleLogInit(int dayIndex)
	{
		currentDayIndex = dayIndex;
		EveryDayLogDialog.BattleLogList.numItems = 0;
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		await GetPvPTopTournamentRecordData(dayIndex);
		uiService.ShowWaitingAnimation(show: false);
		uiService.SetUiTouchable(changeId);
	}

	private async Task GetPvPTopTournamentRecordData(int dayIndex)
	{
		if (dayIndex <= 0)
		{
			RenderLastTurnBattleLog();
			return;
		}
		GetPvPTopTournamentRecordResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRecord(dayIndex);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)EveryDayLogDialog.tip).visible = true;
			return;
		}
		TodayBattleLogData = response.BattleLogData;
		if (TodayBattleLogData == null || TodayBattleLogData.Count <= 0)
		{
			((GObject)EveryDayLogDialog.tip).visible = true;
			return;
		}
		((GObject)EveryDayLogDialog.tip).visible = false;
		RenderAllBattleLog();
	}

	private async void RenderLastTurnBattleLog()
	{
		List<RankDataHelper.tRankStartGame> turns;
		int turnState = RankDataHelper.GetCurrentSeasonIs(isBattleEnd: false, out turns);
		if (turns.Count <= 0 && turnState != 0)
		{
			((GObject)EveryDayLogDialog.tip).visible = true;
			return;
		}
		GetPvPRankLastTurnLastDayResultResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLastDayResult();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)EveryDayLogDialog.tip).visible = true;
			return;
		}
		TodayBattleLogData = response.BattleLogData;
		if (TodayBattleLogData == null || TodayBattleLogData.Count <= 0)
		{
			((GObject)EveryDayLogDialog.tip).visible = true;
			return;
		}
		((GObject)EveryDayLogDialog.tip).visible = false;
		RenderAllBattleLog();
	}

	private void RenderAllBattleLog()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		EveryDayLogDialog.BattleLogList.itemRenderer = new ListItemRenderer(RenderTopTournamentLogComponent);
		EveryDayLogDialog.BattleLogList.numItems = TodayBattleLogData.Count;
	}

	private void RenderTopTournamentLogComponent(int index, GObject obj)
	{
		if (obj is UI_TopTournamentLogComponent uI_TopTournamentLogComponent)
		{
			KeyValuePair<string, List<Dictionary<string, object>>> keyValuePair = TodayBattleLogData.ToList()[index];
			uI_TopTournamentLogComponent.RenderBattleRecord(index + 1, NumericParser.Float(keyValuePair.Key), keyValuePair.Value, currentDayIndex);
		}
	}
}
