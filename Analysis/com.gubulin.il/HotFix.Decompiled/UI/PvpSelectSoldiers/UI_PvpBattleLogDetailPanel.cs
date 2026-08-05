using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Battle;
using UI.EnemyIntroduction;
using UI.LegendItemInfo;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleLogDetailPanel : GComponent, IUiController
{
	public GGraph blackMask;

	public GLoader background;

	public GImage n44;

	public GImage n46;

	public UI_OurInfomationBar OurInfomationBar;

	public UI_EnemyInfomationBar EnemyInfomationBar;

	public UI_StandardFormationSketchMap MyStandardFormationSketchMap;

	public UI_EnemyStandardFormationSketchMap EnemyStandardFormationSketchMap;

	public GGraph n56;

	public GImage flashImage;

	public GTextField OurCombat;

	public GTextField n11;

	public GGroup PowerMine;

	public GList EnemyFormationsList;

	public GGraph n57;

	public GImage flashImage_2;

	public GTextField EnemyCombat;

	public GTextField n21;

	public GGroup PowerEnemy;

	public GButton backBtn;

	public GList OurFormationsList;

	public UI_PlayBtn PlayBattleLog;

	public UI_SeasonBuffLabel SeasonBuffLabel;

	public Transition MainUiFade;

	public const string URL = "ui://82mo10n5zgaedhg";

	public static string Name = "UI_PvpBattleLogDetailPanel";

	private BattleLogSource DataSource;

	private UI_PvpBattleLogPanel.BattleLogUserInfo UserInfo;

	private LevelBattleReplay ReplayData;

	private BattleRecordDetail Detail;

	private RankBattleConfigDetails ConfigDetails;

	private int retry_times = 0;

	private int total_download_cnt = 0;

	private Coroutine DownloadZipReplayCoroutine;

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<UI_SoldierFormation> enemyFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> enemyVector2s = new List<Vector2>();

	public static string GetURL()
	{
		return "ui://82mo10n5zgaedhg";
	}

	public static UI_PvpBattleLogDetailPanel CreateInstance()
	{
		return (UI_PvpBattleLogDetailPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleLogDetailPanel");
	}

	public static UI_PvpBattleLogDetailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleLogDetailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5zgaedhg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		OurInfomationBar = (UI_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		MyStandardFormationSketchMap = (UI_StandardFormationSketchMap)(object)((GComponent)this).GetChild("MyStandardFormationSketchMap");
		EnemyStandardFormationSketchMap = (UI_EnemyStandardFormationSketchMap)(object)((GComponent)this).GetChild("EnemyStandardFormationSketchMap");
		n56 = (GGraph)((GComponent)this).GetChild("n56");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://82mo10n5zgaedhg".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		EnemyFormationsList = (GList)((GComponent)this).GetChild("EnemyFormationsList");
		n57 = (GGraph)((GComponent)this).GetChild("n57");
		flashImage_2 = (GImage)((GComponent)this).GetChild("flashImage");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://82mo10n5zgaedhg".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		OurFormationsList = (GList)((GComponent)this).GetChild("OurFormationsList");
		PlayBattleLog = (UI_PlayBtn)(object)((GComponent)this).GetChild("PlayBattleLog");
		SeasonBuffLabel = (UI_SeasonBuffLabel)(object)((GComponent)this).GetChild("SeasonBuffLabel");
		MainUiFade = ((GComponent)this).GetTransition("MainUiFade");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		DataSource = BattleLogSource.TopTournament;
		if (parameters.TryGetValue("DataSource", out var value))
		{
			DataSource = (BattleLogSource)value;
		}
		if (parameters.TryGetValue("UserInfo", out var value2))
		{
			UserInfo = (UI_PvpBattleLogPanel.BattleLogUserInfo)value2;
		}
		if (parameters.TryGetValue("RankBattleConfigDetails", out var value3))
		{
			ConfigDetails = (RankBattleConfigDetails)value3;
		}
		if (parameters.TryGetValue("BattleReplay", out var value4))
		{
			ReplayData = (LevelBattleReplay)value4;
		}
		if (parameters.TryGetValue("BattleRecordDetail", out var value5))
		{
			Detail = (BattleRecordDetail)value5;
		}
		if (ConfigDetails != null && UserInfo != null && ReplayData != null && Detail != null)
		{
			RenderMainUi();
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(GetDataAndRender());
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)PlayBattleLog).onClick.Add(new EventCallback0(OnClickPlayBtn));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)PlayBattleLog).onClick.Remove(new EventCallback0(OnClickPlayBtn));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderMainUi()
	{
		RenderUserInfo();
		RenderLegionIndex();
		DisplaySeasonBuff();
	}

	private void RenderUserInfo()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, UserInfo.RedUserId, OurInfomationBar.Avatar.HeadPortrait.icon, OurInfomationBar.ArmyGroupLevel));
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, UserInfo.BlueUserId, EnemyInfomationBar.Avatar.HeadPortrait.icon, EnemyInfomationBar.ArmyGroupLevel));
		((GObject)OurInfomationBar.ArmyGroupName).text = "";
		((GObject)EnemyInfomationBar.ArmyGroupName).text = "";
	}

	private void RenderLegionIndex()
	{
		int valueOrDefault = (ConfigDetails.Red?.FormationIds?.Count).GetValueOrDefault();
		int valueOrDefault2 = (ConfigDetails.Red?.TeamCombatPower?.Count).GetValueOrDefault();
		int valueOrDefault3 = (ConfigDetails.Red?.SoldiersDetail?.Count).GetValueOrDefault();
		if (valueOrDefault != valueOrDefault2 || valueOrDefault2 != valueOrDefault3 || valueOrDefault != valueOrDefault3)
		{
			ILRuntimeDebug.LogError($"[RenderLegionIndex] Red 数据不对齐! BattleId={ReplayData?.BattleId} FormationIds={valueOrDefault}, TeamCombatPower={valueOrDefault2}, SoldiersDetail={valueOrDefault3}");
		}
		int valueOrDefault4 = (ConfigDetails.Blue?.FormationIds?.Count).GetValueOrDefault();
		int valueOrDefault5 = (ConfigDetails.Blue?.TeamCombatPower?.Count).GetValueOrDefault();
		int valueOrDefault6 = (ConfigDetails.Blue?.SoldiersDetail?.Count).GetValueOrDefault();
		if (valueOrDefault4 != valueOrDefault5 || valueOrDefault5 != valueOrDefault6 || valueOrDefault4 != valueOrDefault6)
		{
			ILRuntimeDebug.LogError($"[RenderLegionIndex] Blue 数据不对齐! BattleId={ReplayData?.BattleId} FormationIds={valueOrDefault4}, TeamCombatPower={valueOrDefault5}, SoldiersDetail={valueOrDefault6}");
		}
		RenderMyArrayIndex();
		RenderEnemyArrayIndex();
	}

	private void RenderMyArrayIndex()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		int num = Math.Min(Math.Min(ConfigDetails.Red.FormationIds.Count, ConfigDetails.Red.TeamCombatPower.Count), ConfigDetails.Red.SoldiersDetail.Count);
		OurFormationsList.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		OurFormationsList.numItems = num;
		if (num >= 1)
		{
			GButton asButton = ((GComponent)OurFormationsList).GetChildAt(0).asButton;
			((GComponent)asButton).GetController("btnaddd").selectedIndex = 1;
			((GObject)OurCombat).text = ConfigDetails.Red.TeamCombatPower[0].ToString();
			SetOurPos(ConfigDetails.Red.FormationIds[0], ConfigDetails.Red.SoldiersDetail[0]);
		}
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		if (ConfigDetails.Red != null)
		{
			UI_MyArrayIndex uI_MyArrayIndex = obj as UI_MyArrayIndex;
			((GObject)uI_MyArrayIndex.indexText).text = $"{index + 1}";
			((GObject)uI_MyArrayIndex).data = index;
			((GObject)uI_MyArrayIndex).onClick.Set(new EventCallback1(CheckSelfArray));
		}
	}

	private void CheckSelfArray(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		UI_MyArrayIndex uI_MyArrayIndex = ((GObject)context.sender) as UI_MyArrayIndex;
		int num = (int)((GObject)uI_MyArrayIndex).data;
		if (num >= 0 && num < ConfigDetails.Red.TeamCombatPower.Count && num < ConfigDetails.Red.FormationIds.Count && num < ConfigDetails.Red.SoldiersDetail.Count)
		{
			((GObject)OurCombat).text = ConfigDetails.Red.TeamCombatPower[num].ToString();
			SetOurPos(ConfigDetails.Red.FormationIds[num], ConfigDetails.Red.SoldiersDetail[num]);
			for (int i = 0; i < OurFormationsList.numItems; i++)
			{
				((GComponent)((GComponent)OurFormationsList).GetChildAt(i).asButton).GetController("btnaddd").selectedIndex = 0;
			}
			((GComponent)uI_MyArrayIndex).GetController("btnaddd").selectedIndex = 1;
		}
	}

	private void RenderEnemyArrayIndex()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		int num = Math.Min(Math.Min(ConfigDetails.Blue.FormationIds.Count, ConfigDetails.Blue.TeamCombatPower.Count), ConfigDetails.Blue.SoldiersDetail.Count);
		EnemyFormationsList.itemRenderer = new ListItemRenderer(RenderEnemyIndex);
		EnemyFormationsList.numItems = num;
		if (num > 0)
		{
			GButton asButton = ((GComponent)EnemyFormationsList).GetChildAt(0).asButton;
			((GComponent)asButton).GetController("btnadd").selectedIndex = 1;
			((GObject)EnemyCombat).text = ConfigDetails.Blue.TeamCombatPower[0].ToString();
			SetEnemyPos(ConfigDetails.Blue.FormationIds[0], ConfigDetails.Blue.SoldiersDetail[0]);
		}
	}

	private void RenderEnemyIndex(int index, GObject obj)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		if (ConfigDetails.Blue != null)
		{
			UI_ArrayIndex uI_ArrayIndex = obj as UI_ArrayIndex;
			((GObject)uI_ArrayIndex.indexText).text = $"{index + 1}";
			((GObject)uI_ArrayIndex.LockIcon).visible = false;
			((GObject)uI_ArrayIndex).data = index;
			((GObject)uI_ArrayIndex).onClick.Set(new EventCallback1(CheckSomeEnemyArray));
		}
	}

	private void CheckSomeEnemyArray(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		UI_ArrayIndex uI_ArrayIndex = ((GObject)context.sender) as UI_ArrayIndex;
		int num = (int)((GObject)uI_ArrayIndex).data;
		if (num >= 0 && num < ConfigDetails.Blue.TeamCombatPower.Count && num < ConfigDetails.Blue.FormationIds.Count && num < ConfigDetails.Blue.SoldiersDetail.Count)
		{
			((GObject)EnemyCombat).text = ConfigDetails.Blue.TeamCombatPower[num].ToString();
			SetEnemyPos(ConfigDetails.Blue.FormationIds[num], ConfigDetails.Blue.SoldiersDetail[num]);
			for (int i = 0; i < EnemyFormationsList.numItems; i++)
			{
				((GComponent)((GComponent)EnemyFormationsList).GetChildAt(i).asButton).GetController("btnadd").selectedIndex = 0;
			}
			((GComponent)uI_ArrayIndex).GetController("btnadd").selectedIndex = 1;
		}
	}

	private void DisplaySeasonBuff()
	{
		((GObject)SeasonBuffLabel).visible = false;
	}

	private IEnumerator GetDataAndRender()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		if (DataSource == BattleLogSource.LastTurnTopTournament)
		{
			Task<GetPvPRankLastTurnLastDayDetailsResultResponse> _task = GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLastDayDetailsResult(UserInfo.BattleId);
			while (!_task.IsCompleted)
			{
				yield return null;
			}
			GetPvPRankLastTurnLastDayDetailsResultResponse replaydataservice = _task.Result;
			if (!replaydataservice.Result)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(replaydataservice.ErrorCode);
				yield break;
			}
			ReplayData = replaydataservice.Replay;
		}
		else if (DataSource == BattleLogSource.TopTournament)
		{
			Task<GetPvPTopTournamentReplayResponse> _task2 = GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentReplay(UserInfo.BattleId);
			while (!_task2.IsCompleted)
			{
				yield return null;
			}
			GetPvPTopTournamentReplayResponse replaydataservice2 = _task2.Result;
			if (!replaydataservice2.Result)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(replaydataservice2.ErrorCode);
				yield break;
			}
			ReplayData = replaydataservice2.Replay;
		}
		else if (DataSource == BattleLogSource.Common && ReplayData == null)
		{
			Task<GetLevelReplaysResponse> _task3 = GameController.Contexts.Service<INetworkService>().GetLevelReplays("RankBattleFieldLevel", random: false, UserInfo.BattleId);
			while (!_task3.IsCompleted)
			{
				yield return null;
			}
			GetLevelReplaysResponse replaydataservice3 = _task3.Result;
			if (!replaydataservice3.Result)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(replaydataservice3.ErrorCode);
				yield break;
			}
			if (replaydataservice3.Replays == null || replaydataservice3.Replays.Count <= 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				yield break;
			}
			ReplayData = replaydataservice3.Replays[0];
		}
		if (ReplayData == null || ReplayData.Detail == null)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			yield break;
		}
		Detail = ReplayData.Detail;
		ConfigDetails = JsonHelper.ToObject<RankBattleConfigDetails>(Detail.PvP_Details);
		SpecialDataTreatmentForCommonReplay();
		RenderMainUi();
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}

	private void SpecialDataTreatmentForCommonReplay()
	{
		if (DataSource == BattleLogSource.Common && ConfigDetails != null)
		{
			ConfigDetails.Red?.TryCopyLegendItemBrief();
			ConfigDetails.Blue?.TryCopyLegendItemBrief();
		}
	}

	private IEnumerator InitDownload()
	{
		if (DataSource == BattleLogSource.TopTournament || DataSource == BattleLogSource.LastTurnTopTournament)
		{
			GameController.Contexts.Service<INetworkService>().InformWatchingReplay(UserInfo.BattleId);
			GameManagers.Instance.Messenger.Broadcast("WATCHING_REPLAY");
		}
		else if (DataSource == BattleLogSource.Common || DataSource == BattleLogSource.LastTurnLast10)
		{
			GameController.Contexts.Service<INetworkService>().InformWatchingPvPRankReplay(UserInfo.BattleId);
			GameManagers.Instance.Messenger.Broadcast("WATCHING_PVP_RANK_REPLAY");
		}
		List<string> file_names = new List<string> { "ret.bin" };
		for (int idx = 0; idx < Detail.PvP_ReplaySegments.Count; idx++)
		{
			for (int i = idx * 10000; i < Detail.PvP_ReplaySegments[idx]; i++)
			{
				file_names.Add(i.ToString());
			}
		}
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo
		{
			UserId = UserInfo.BlueUserId,
			IsUser = UserInfo.BlueIsUser,
			NpcUrl = UserInfo.BlueNpcUrl
		};
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			UserId = UserInfo.RedUserId,
			IsUser = UserInfo.RedIsUser,
			NpcUrl = UserInfo.RedNpcUrl
		};
		RankDataHelper.info = new RankBattleInfo(ReplayData.BattleId);
		RankDataHelper.info.RealLegionSize = Detail.PvP_ReplaySegments.Count;
		RankDataHelper.info.NeedLegionSize = Detail.PvP_ReplaySegments.Count;
		RankDataHelper.UpdateRankBattleReplayResult(ReplayData.BattleId, ReplayData.Result, new Dictionary<Team, BattleResultStats>());
		total_download_cnt = file_names.Count;
		yield return DownloadZipReplay(ReplayData, file_names);
	}

	public IEnumerator DownloadZipReplay(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(replay.BattleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return DownloadNormalReplay(replay, queue);
		DownloadZipReplayCoroutine = null;
	}

	public IEnumerator DownloadNormalReplay(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		if (queue.Count == 0)
		{
			yield break;
		}
		if (string.IsNullOrEmpty(downloading))
		{
			downloading = queue[0];
			queue.RemoveAt(0);
		}
		ReplayDownloadManager.DownloadReplay(replay.BattleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (retry_times > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					retry_times++;
					FGUIManager.Instance.OpenIEnumerator(DownloadNormalReplay(replay, queue, downloading, 0.2f));
				}
			}
			else
			{
				retry_times = 0;
				float num = 1f * (float)(total_download_cnt - queue.Count) / (float)total_download_cnt;
				float barValue = num * 35f + 65f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue);
				if (queue.Count == 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					PlayReplay();
				}
				else
				{
					FGUIManager.Instance.OpenIEnumerator(DownloadNormalReplay(replay, queue));
				}
			}
		});
	}

	private void PlayReplay()
	{
		PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
		{
			BattleId = ReplayData.BattleId,
			TargetFrame = ReplayData.ReplayFrames - 1,
			LevelId = ReplayData.LevelId,
			LocalSource = true,
			ReplayMode = 3,
			MaskDuration = 0
		};
		QuickPlayReplayService.info.BattleId = string.Empty;
		GameLocalDataManager.SetLastReplayUserInfo(ReplayData.Nickname, ReplayData.Avatar);
		GameLocalDataManager.SetLastReplay(playBattleReplayData);
		GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
	}

	private void OnClickPlayBtn()
	{
		if (ReplayData != null && Detail != null && DownloadZipReplayCoroutine == null)
		{
			DownloadZipReplayCoroutine = FGUIManager.Instance.OpenIEnumerator(InitDownload());
		}
	}

	private void FormationsInit()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		if (ourFormations.Count >= 9)
		{
			return;
		}
		ourFormations.Clear();
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			UI_SoldierFormation _redBtn = (UI_SoldierFormation)(object)((GComponent)MyStandardFormationSketchMap).GetChild($"OurFormation{i}");
			ourVector2s.Add(Vector2.op_Implicit(((GObject)_redBtn).xy));
			ourFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	public void SetOurFormations(List<SoldierDetail> _curSoldiers)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				string soldierId = _curSoldiers[i].SoldierId;
				if (!string.IsNullOrWhiteSpace(soldierId) && soldierId != "Unlock" && soldierId != "Lock")
				{
					ourFormations[i].Type.selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).alpha = 1f;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
				}
				else
				{
					ourFormations[i].Type.selectedIndex = 0;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
					ClearSoldierItem(ourFormations[i].Icon);
				}
			}
			else
			{
				((GObject)ourFormations[i]).data = i;
				ourFormations[i].Type.selectedIndex = 1;
			}
		}
	}

	private void ShowOurIcons()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		float delay = 0.05f;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			UI_SoldierFormation uI_SoldierFormation = ourFormations[i];
			((GObject)uI_SoldierFormation.Icon).alpha = 0f;
		}
		((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			for (int j = 0; j < ourFormations.Count; j++)
			{
				UI_SoldierFormation _btn = ourFormations[j];
				((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
				{
					_btn.ShowInfo.Play();
				});
				delay += 0.05f;
			}
		});
	}

	public void SetOurPos(string fid, List<SoldierDetail> _curSoldiers)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		FormationsInit();
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int i = 0; i < ourFormations.Count; i++)
			{
				ourFormations[i].Type.selectedIndex = 1;
			}
			return;
		}
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				ourVector2s[7]
			},
			{
				"8.3_0",
				ourVector2s[0]
			},
			{
				"8.3_-3.4",
				ourVector2s[5]
			},
			{
				"4.9_3.4",
				ourVector2s[1]
			},
			{
				"4.9_0",
				ourVector2s[3]
			},
			{
				"4.9_-3.4",
				ourVector2s[2]
			},
			{
				"1.5_3.4",
				ourVector2s[8]
			},
			{
				"1.5_0",
				ourVector2s[4]
			},
			{
				"1.5_-3.4",
				ourVector2s[6]
			}
		};
		for (int j = 0; j < 5; j++)
		{
			if (formation.SlotPosition.ContainsKey(j))
			{
				string key = $"{formation.SlotPosition[j].x}_{formation.SlotPosition[j].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)ourFormations[j]).xy = Vector2.op_Implicit(dictionary[key]);
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int k = 5; k < ourFormations.Count; k++)
		{
			((GObject)ourFormations[k]).xy = Vector2.op_Implicit(list[k - 5]);
		}
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
	}

	private void EnemyFormationsInit()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		if (enemyFormations.Count >= 9)
		{
			return;
		}
		enemyFormations.Clear();
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			UI_SoldierFormation _redBtn = (UI_SoldierFormation)(object)((GComponent)EnemyStandardFormationSketchMap).GetChild($"OurFormation{i}");
			enemyVector2s.Add(Vector2.op_Implicit(((GObject)_redBtn).xy));
			enemyFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	public void SetEnemyFormations(List<SoldierDetail> _curSoldiers)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				string soldierId = _curSoldiers[i].SoldierId;
				if (!string.IsNullOrWhiteSpace(soldierId) && soldierId != "Unlock" && soldierId != "Lock")
				{
					enemyFormations[i].Type.selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], enemyFormations[i].Icon);
					((GObject)enemyFormations[i].Icon).alpha = 1f;
					((GObject)enemyFormations[i].n7).visible = false;
					((GObject)enemyFormations[i].num).visible = false;
				}
				else
				{
					enemyFormations[i].Type.selectedIndex = 0;
					((GObject)enemyFormations[i].n7).visible = false;
					((GObject)enemyFormations[i].num).visible = false;
					ClearSoldierItem(enemyFormations[i].Icon);
				}
			}
			else
			{
				((GObject)enemyFormations[i]).data = i;
				enemyFormations[i].Type.selectedIndex = 1;
			}
		}
	}

	private void ShowEnemyIcons()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		float delay = 0.05f;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			UI_SoldierFormation uI_SoldierFormation = enemyFormations[i];
			((GObject)uI_SoldierFormation.Icon).alpha = 0f;
		}
		((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			for (int j = 0; j < enemyFormations.Count; j++)
			{
				UI_SoldierFormation _btn = enemyFormations[j];
				((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
				{
					_btn.ShowInfo.Play();
				});
				delay += 0.05f;
			}
		});
	}

	public void SetEnemyPos(string fid, List<SoldierDetail> _curSoldiers)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		EnemyFormationsInit();
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int i = 0; i < enemyFormations.Count; i++)
			{
				enemyFormations[i].Type.selectedIndex = 1;
			}
			return;
		}
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				enemyVector2s[8]
			},
			{
				"8.3_0",
				enemyVector2s[4]
			},
			{
				"8.3_-3.4",
				enemyVector2s[6]
			},
			{
				"4.9_3.4",
				enemyVector2s[1]
			},
			{
				"4.9_0",
				enemyVector2s[3]
			},
			{
				"4.9_-3.4",
				enemyVector2s[2]
			},
			{
				"1.5_3.4",
				enemyVector2s[7]
			},
			{
				"1.5_0",
				enemyVector2s[0]
			},
			{
				"1.5_-3.4",
				enemyVector2s[5]
			}
		};
		for (int j = 0; j < 5; j++)
		{
			if (formation.SlotPosition.ContainsKey(j))
			{
				string key = $"{formation.SlotPosition[j].x}_{formation.SlotPosition[j].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)enemyFormations[j]).xy = Vector2.op_Implicit(dictionary[key]);
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int k = 5; k < enemyFormations.Count; k++)
		{
			((GObject)enemyFormations[k]).xy = Vector2.op_Implicit(list[k - 5]);
		}
		SetEnemyFormations(_curSoldiers);
		ShowEnemyIcons();
	}

	private void RenderSoldierItem(SoldierDetail soldier, UI_soliderItem btn)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		((GObject)btn).touchable = true;
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		((GObject)btn.lv).text = soldier.Level.ToString();
		int itemLevel = (soldier.PotentialLevel + 2) / 2;
		if (soldier.PotentialLevel == 9)
		{
			itemLevel = 6;
		}
		string iconPath = UiHelper.GetIconPath(soldier.SoldierId, itemLevel);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, new List<int>());
		string text = soldier.SoldierId;
		string text2 = GDMgr.Get<GDESoldierData>(text)?.ParentSoldierId;
		if (!string.IsNullOrEmpty(text2))
		{
			text = text2;
		}
		FakeSoldier fakeSoldierData = new FakeSoldier(text, soldier.Level, soldier.EvoLevel, soldier.PotentialLevel);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", soldier.SoldierId },
				{ "FakeSoldierData", fakeSoldierData },
				{ "Num", soldier.Num },
				{ "CombatPower", soldier.CombatPower },
				{ "ATK", soldier.Atk },
				{ "DEF", soldier.Def },
				{ "HP", soldier.Hp },
				{ "LegendItemBrief", soldier.LegendItems }
			});
		});
		RenderLegendItems(soldier, (GButton)(object)btn);
	}

	private void ClearSoldierItem(UI_soliderItem btn)
	{
		btn.icon.url = "";
		((GObject)btn.lv).text = "";
		btn.iconFrame.url = "";
		btn.lvFrame.url = "";
		((GObject)btn.SoulStoneLevel).alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
	}

	private void RenderLegendItems(SoldierDetail soldier, GButton button)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		((GComponent)button).GetChild("LegendItems").visible = true;
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = false;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < soldier.LegendItems.Count; j++)
		{
			if (num2 >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num2}").asButton;
			((GObject)asButton).visible = true;
			num++;
			UiHelper.RenderLegendItem(asButton, soldier.LegendItems[j], UiHelper.TextColorType.Light, null, 2);
			((GObject)asButton).data = soldier.LegendItems[j];
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendPanel));
			num2++;
		}
		if (num == 0)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
		}
	}

	private void OpenLegendPanel(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		LegendItemBrief itemBrief = (LegendItemBrief)((GObject)context.sender).data;
		UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, null, itemBrief);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
	}
}
