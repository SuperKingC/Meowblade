using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using UI.Battle;
using UI.EnemyIntroduction;
using UI.GameEndPanels;
using UI.LegendItemInfo;
using UnityEngine;

namespace UI.GvGBattleRecords;

public class UI_GvGBattleRecordDetailPanel : GComponent, IUiController
{
	public GGraph blackMask;

	public GLoader background;

	public GImage n63;

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

	public GImage flashImage2;

	public GTextField EnemyCombat;

	public GTextField n21;

	public GGroup PowerEnemy;

	public GButton backBtn;

	public GList OurFormationsList;

	public UI_PlayBtn PlayBattleLog;

	public Transition MainUiFade;

	public const string URL = "ui://dxmilktydzls1z";

	public static string Name = "UI_GvGBattleRecordDetailPanel";

	private GvGBattleRecordUserInfo UserInfo;

	private BattleRecordDetail RedDetail;

	private BattleRecordDetail BlueDetail;

	private string GvGReplayLevelId;

	private GetGvGBattleResultResponse BattleResultData;

	private string WBId;

	private Dictionary<Team, BattleResultStats> ResultStats = new Dictionary<Team, BattleResultStats>();

	private Dictionary<string, int> redSoldiersNumData = new Dictionary<string, int>();

	private Dictionary<string, int> blueSoldiersNumData = new Dictionary<string, int>();

	private int retry_times = 0;

	private int total_download_cnt = 0;

	private Coroutine DownloadZipReplayCoroutine;

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<GButton> ourFormations = new List<GButton>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<GButton> enemyFormations = new List<GButton>();

	private static List<Vector2> enemyVector2s = new List<Vector2>();

	public static string GetURL()
	{
		return "ui://dxmilktydzls1z";
	}

	public static UI_GvGBattleRecordDetailPanel CreateInstance()
	{
		return (UI_GvGBattleRecordDetailPanel)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGBattleRecordDetailPanel");
	}

	public static UI_GvGBattleRecordDetailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordDetailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzls1z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		OurInfomationBar = (UI_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		MyStandardFormationSketchMap = (UI_StandardFormationSketchMap)(object)((GComponent)this).GetChild("MyStandardFormationSketchMap");
		EnemyStandardFormationSketchMap = (UI_EnemyStandardFormationSketchMap)(object)((GComponent)this).GetChild("EnemyStandardFormationSketchMap");
		n56 = (GGraph)((GComponent)this).GetChild("n56");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://dxmilktydzls1z".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		EnemyFormationsList = (GList)((GComponent)this).GetChild("EnemyFormationsList");
		n57 = (GGraph)((GComponent)this).GetChild("n57");
		flashImage2 = (GImage)((GComponent)this).GetChild("flashImage2");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://dxmilktydzls1z".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		OurFormationsList = (GList)((GComponent)this).GetChild("OurFormationsList");
		PlayBattleLog = (UI_PlayBtn)(object)((GComponent)this).GetChild("PlayBattleLog");
		MainUiFade = ((GComponent)this).GetTransition("MainUiFade");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		if (parameters.TryGetValue("UserInfo", out var value))
		{
			UserInfo = (GvGBattleRecordUserInfo)value;
		}
		if (parameters.TryGetValue("BattleRecordRedDetail", out var value2))
		{
			RedDetail = (BattleRecordDetail)value2;
		}
		if (parameters.TryGetValue("BattleRecordBlueDetail", out var value3))
		{
			BlueDetail = (BattleRecordDetail)value3;
		}
		if (parameters.TryGetValue("LevelId", out var value4))
		{
			GvGReplayLevelId = value4.ToString();
		}
		if (parameters.TryGetValue("WBId", out var value5))
		{
			WBId = value5.ToString();
		}
		if (parameters.TryGetValue("BattleRecordResultData", out var value6))
		{
			BattleResultData = (GetGvGBattleResultResponse)value6;
			ResultStats = BattleFieldService.GetGvGBattleResultStats(BattleResultData);
			GetSoldiersNum(redSoldiersNumData, ResultStats[Team.Red]);
			GetSoldiersNum(blueSoldiersNumData, ResultStats[Team.Blue]);
		}
		if (UserInfo != null && RedDetail != null && BlueDetail != null && BattleResultData != null)
		{
			RenderMainUi();
		}
		else
		{
			ILRuntimeDebug.LogError("Open UI_GvGBattleRecordDetailPanel GvGRecordDetailData is null");
		}
		GvGConfigHelper.AddDoNotCloseUis();
	}

	public void OnShow()
	{
		OpenDamageMeter();
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
		GvGConfigHelper.ClearDoNotCloseUis();
		FGUIManager.Instance.DamageMeter?.End();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private List<ItemAbility> GetWorldBossAbilities(out int bossLevel)
	{
		List<ItemAbility> result = new List<ItemAbility>();
		bossLevel = 1;
		if (!BlueDetail.CustomizeDataDic.ContainsKey(Team.Red.ToString()))
		{
			return result;
		}
		result = BlueDetail.CustomizeDataDic[Team.Red.ToString()];
		if (!BlueDetail.CustomizeDataDic.ContainsKey(Team.Blue.ToString()))
		{
			return result;
		}
		foreach (ItemAbility item in BlueDetail.CustomizeDataDic[Team.Blue.ToString()])
		{
			if (item.AbilityId == "WorldBossRevive_001")
			{
				bossLevel = Convert.ToInt32(item.Variables?[0].GetValue()) + 1;
				break;
			}
		}
		return result;
	}

	private void RenderMainUi()
	{
		RenderUserInfo();
		RenderLegionIndex();
	}

	private void RenderUserInfo()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, UserInfo.RedUserId, OurInfomationBar.Avatar.AvatarLoader.icon, OurInfomationBar.ArmyGroupLevel));
		if (UserInfo.BlueUserId != -1)
		{
			EnemyInfomationBar.Avatar.AvatarLoader.Type.selectedIndex = 0;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, UserInfo.BlueUserId, EnemyInfomationBar.Avatar.AvatarLoader.icon, EnemyInfomationBar.ArmyGroupLevel));
		}
		else
		{
			EnemyInfomationBar.Avatar.AvatarLoader.Type.selectedIndex = 1;
			EnemyInfomationBar.Avatar.AvatarLoader.icon.url = UserInfo.BlueUserIconUrl;
			((GObject)EnemyInfomationBar.ArmyGroupLevel).text = UserInfo.BlueUserName;
		}
		((GObject)OurInfomationBar.ArmyGroupName).text = "";
		((GObject)EnemyInfomationBar.ArmyGroupName).text = "";
	}

	private void RenderLegionIndex()
	{
		RenderMyArrayIndex();
		RenderEnemyArrayIndex();
	}

	private void RenderMyArrayIndex()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		OurFormationsList.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		OurFormationsList.numItems = 1;
		if (OurFormationsList.numItems >= 1)
		{
			GButton asButton = ((GComponent)OurFormationsList).GetChildAt(0).asButton;
			((GComponent)asButton).GetController("btnaddd").selectedIndex = 1;
			((GObject)OurCombat).text = RedDetail.CombatPower.ToString();
			SetOurPos(RedDetail.FormationId, RedDetail.Soldiers);
		}
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		UI_MyArrayIndex uI_MyArrayIndex = obj as UI_MyArrayIndex;
		((GObject)uI_MyArrayIndex.indexText).text = $"{index + 1}";
	}

	private void RenderEnemyArrayIndex()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		EnemyFormationsList.itemRenderer = new ListItemRenderer(RenderEnemyIndex);
		EnemyFormationsList.numItems = 1;
		if (EnemyFormationsList.numItems > 0)
		{
			GButton asButton = ((GComponent)EnemyFormationsList).GetChildAt(0).asButton;
			((GComponent)asButton).GetController("btnadd").selectedIndex = 1;
			((GObject)EnemyCombat).text = BlueDetail.CombatPower.ToString();
			SetEnemyPos(BlueDetail.FormationId, BlueDetail.Soldiers);
		}
	}

	private void RenderEnemyIndex(int index, GObject obj)
	{
		UI_ArrayIndex uI_ArrayIndex = obj as UI_ArrayIndex;
		((GObject)uI_ArrayIndex.indexText).text = $"{index + 1}";
		((GObject)uI_ArrayIndex.LockIcon).visible = false;
	}

	private IEnumerator InitDownload()
	{
		GameController.Contexts.Service<INetworkService>().InformWatchingReplay(UserInfo.BattleId);
		GameManagers.Instance.Messenger.Broadcast("WATCHING_REPLAY");
		List<string> file_names = new List<string> { "ret.bin" };
		for (int idx = 0; idx < BattleResultData.ReplaySegments; idx++)
		{
			file_names.Add(idx.ToString());
		}
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo
		{
			UserId = UserInfo.BlueUserId,
			IsUser = (UserInfo.BlueUserId != -1),
			NpcUrl = UserInfo.BlueUserIconUrl,
			UserName = UserInfo.BlueUserName
		};
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			UserId = UserInfo.RedUserId,
			IsUser = true,
			NpcUrl = ""
		};
		total_download_cnt = file_names.Count;
		yield return DownloadZipReplay(file_names);
	}

	public IEnumerator DownloadZipReplay(List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(BattleResultData.BattleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return DownloadNormalReplay(queue);
		DownloadZipReplayCoroutine = null;
	}

	public IEnumerator DownloadNormalReplay(List<string> queue, string downloading = "", float wait_tm = 0f)
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
		ReplayDownloadManager.DownloadReplay(BattleResultData.BattleId, downloading, delegate(bool isSucess)
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
					FGUIManager.Instance.OpenIEnumerator(DownloadNormalReplay(queue, downloading, 0.2f));
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
					FGUIManager.Instance.OpenIEnumerator(DownloadNormalReplay(queue));
				}
			}
		});
	}

	private void PlayReplay()
	{
		PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
		{
			BattleId = BattleResultData.BattleId,
			TargetFrame = BattleResultData.ReplayFrames - 1,
			LevelId = GvGReplayLevelId,
			LocalSource = true,
			ReplayMode = 3,
			MaskDuration = 0
		};
		QuickPlayReplayService.info.BattleId = string.Empty;
		int bossLevel;
		List<ItemAbility> worldBossAbilities = GetWorldBossAbilities(out bossLevel);
		GvGConfigHelper.RecordLevelInfo = new GvGBattleInfo
		{
			BattleId = BattleResultData.BattleId,
			LevelId = GvGReplayLevelId,
			Result = (BattleResultData.Result ? 1 : (-1)),
			BattleResultStats = ResultStats,
			WorldBossDebuffItemAbilities = worldBossAbilities,
			WorldBossLevel = bossLevel
		};
		GvGConfigHelper.CloseLordOfDreamsPanel();
		GameLocalDataManager.SetLastReplay(playBattleReplayData);
		GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
	}

	private void OpenDamageMeter()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder + 1
			},
			{ "Type", 2 },
			{
				"BattleResult",
				BattleResultData.Result ? 1 : (-1)
			},
			{ "BattleStats", ResultStats }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, parameters);
	}

	private void GetSoldiersNum(Dictionary<string, int> stats, BattleResultStats resultStats)
	{
		for (int i = 0; i < resultStats.Units.GetLength(0); i++)
		{
			for (int j = 0; j < resultStats.Units.GetLength(1); j++)
			{
				string text = resultStats.Units[i, j];
				if (text != null && !stats.ContainsKey(text))
				{
					int value = resultStats.UnitsTotal[i, j];
					stats.Add(text, value);
				}
			}
		}
	}

	private void OnClickPlayBtn()
	{
		if (RedDetail != null && BlueDetail != null && DownloadZipReplayCoroutine == null)
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
			GButton _redBtn = ((GComponent)MyStandardFormationSketchMap).GetChild($"OurFormation{i}").asButton;
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
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				string soldierId = _curSoldiers[i].SoldierId;
				if (!string.IsNullOrWhiteSpace(soldierId) && soldierId != "Unlock" && soldierId != "Lock")
				{
					((GComponent)ourFormations[i]).GetController("Type").selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], ((GComponent)ourFormations[i]).GetChild("Icon").asButton, 0);
					((GComponent)ourFormations[i]).GetChild("Icon").alpha = 1f;
					((GComponent)ourFormations[i]).GetChild("n7").visible = true;
					((GComponent)ourFormations[i]).GetChild("num").visible = true;
					int num2 = redSoldiersNumData[soldierId];
					int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, _curSoldiers[i].Level);
					bool flag = num2 < soldierFormationNumber;
					((GComponent)ourFormations[i]).GetChild("num").asTextField.color = (flag ? Color.red : Color.white);
					((GComponent)ourFormations[i]).GetChild("num").asTextField.strokeColor = (flag ? Color.white : Color.gray);
					((GComponent)ourFormations[i]).GetChild("num").text = $"{num2}/{soldierFormationNumber}";
				}
				else
				{
					((GComponent)ourFormations[i]).GetController("Type").selectedIndex = 0;
					((GComponent)ourFormations[i]).GetChild("n7").visible = false;
					((GComponent)ourFormations[i]).GetChild("num").visible = false;
					ClearSoldierItem(((GComponent)ourFormations[i]).GetChild("Icon").asButton);
				}
			}
			else
			{
				((GObject)ourFormations[i]).data = i;
				((GComponent)ourFormations[i]).GetController("Type").selectedIndex = 1;
			}
		}
	}

	private void ShowOurIcons()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		float delay = 0.05f;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			GButton val = ourFormations[i];
			((GComponent)val).GetChild("Icon").alpha = 0f;
		}
		((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			for (int j = 0; j < ourFormations.Count; j++)
			{
				GButton _btn = ourFormations[j];
				((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
				{
					((GComponent)_btn).GetTransition("ShowInfo").Play();
				});
				delay += 0.05f;
			}
		});
	}

	public void SetOurPos(string fid, List<SoldierDetail> _curSoldiers)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		FormationsInit();
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int i = 0; i < ourFormations.Count; i++)
			{
				((GComponent)ourFormations[i]).GetController("Type").selectedIndex = 1;
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
			GButton _redBtn = ((GComponent)EnemyStandardFormationSketchMap).GetChild($"OurFormation{i}").asButton;
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
					((GComponent)enemyFormations[i]).GetController("Type").selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], ((GComponent)enemyFormations[i]).GetChild("Icon").asButton, 1);
					((GComponent)enemyFormations[i]).GetChild("Icon").alpha = 1f;
					((GComponent)enemyFormations[i]).GetChild("n7").visible = true;
					((GComponent)enemyFormations[i]).GetChild("num").visible = true;
					int num2 = blueSoldiersNumData[soldierId];
					((GComponent)enemyFormations[i]).GetChild("num").text = $"{num2}/{num2}";
				}
				else
				{
					((GComponent)enemyFormations[i]).GetController("Type").selectedIndex = 0;
					((GComponent)enemyFormations[i]).GetChild("n7").visible = false;
					((GComponent)enemyFormations[i]).GetChild("num").visible = false;
					ClearSoldierItem(((GComponent)enemyFormations[i]).GetChild("Icon").asButton);
				}
			}
			else
			{
				((GObject)enemyFormations[i]).data = i;
				((GComponent)enemyFormations[i]).GetController("Type").selectedIndex = 1;
			}
		}
	}

	private void ShowEnemyIcons()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		float delay = 0.05f;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			GButton val = enemyFormations[i];
			((GComponent)val).GetChild("Icon").alpha = 0f;
		}
		((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			for (int j = 0; j < enemyFormations.Count; j++)
			{
				GButton _btn = enemyFormations[j];
				((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
				{
					((GComponent)_btn).GetTransition("ShowInfo").Play();
				});
				delay += 0.05f;
			}
		});
	}

	public void SetEnemyPos(string fid, List<SoldierDetail> _curSoldiers)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		EnemyFormationsInit();
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int i = 0; i < enemyFormations.Count; i++)
			{
				((GComponent)enemyFormations[i]).GetController("Type").selectedIndex = 1;
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

	private void RenderSoldierItem(SoldierDetail soldier, GButton btn, int selectedIndex)
	{
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		((GObject)btn).touchable = true;
		((GComponent)btn).GetChild("SoulStoneLevel").alpha = 1f;
		bool isBoss = soldier.SoldierId.Contains("WorldBOSS");
		((GComponent)btn).GetController("Type").selectedIndex = selectedIndex;
		((GComponent)btn).GetChild("BossTag").visible = isBoss;
		int itemLevel = (soldier.PotentialLevel + 2) / 2;
		string finalSoldierId = GvGConfigHelper.GetFinalSoldierID(soldier.SoldierId);
		string text = ((soldier.SoldierId == "WorldBOSS_007") ? "I30029_6" : UiHelper.GetIconPath(finalSoldierId, itemLevel));
		((GComponent)btn).GetChild("icon").asLoader.url = "ui://PublicResources/" + text;
		string text2 = ((finalSoldierId == "S039_wild") ? UiHelper.GetIconFrameBorderSoldier(7) : UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel));
		((GComponent)btn).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text2;
		if (soldier.Level > 0)
		{
			((GComponent)btn).GetChild("lv").text = soldier.Level.ToString();
			((GComponent)btn).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		}
		else
		{
			((GComponent)btn).GetChild("lv").text = "";
			((GComponent)btn).GetChild("lvFrame").asLoader.url = "";
		}
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)btn).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)btn).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, new List<int>());
		FakeSoldier fakeSoldierData = new FakeSoldier(finalSoldierId, soldier.Level, soldier.EvoLevel, soldier.PotentialLevel);
		string soldierCombatPower = ((soldier.CombatPower == -1) ? soldier.str_CombatPower : (soldier.CombatPower * soldier.Num).ToString());
		string soldierHp = ((soldier.Hp == -1) ? soldier.str_Hp : soldier.Hp.ToString());
		FakeSoldier soldierData = new FakeSoldier(soldier.SoldierId, 0, 0, soldier.PotentialLevel);
		string specialityName = "";
		string specialityText = "";
		if (isBoss)
		{
			GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(WBId);
			specialityName = gvGWorldBossInfoByWBId.featureName;
			specialityText = GDMgr.Get<GDELanguagesData>(gvGWorldBossInfoByWBId.featureLangId)?.Template;
		}
		int enemyIntroductionPotentialLevel = ((finalSoldierId == "S039_wild") ? 7 : soldier.PotentialLevel);
		FakeSoldier fakeSoldier = new FakeSoldier(finalSoldierId, 0, 0, soldier.PotentialLevel);
		List<string> abilities = ((fakeSoldierData.AbilityList.Count == 0) ? fakeSoldier.AbilityList : fakeSoldierData.AbilityList);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", finalSoldierId },
				{ "FakeSoldierData", fakeSoldierData },
				{ "Num", soldier.Num },
				{ "CombatPower", soldierCombatPower },
				{ "ATK", soldier.Atk },
				{ "DEF", soldier.Def },
				{ "HP", soldierHp },
				{ "LegendItemBrief", soldier.LegendItems },
				{ "IsBoss", isBoss },
				{ "PotentialLevel", enemyIntroductionPotentialLevel },
				{ "SpecialityName", specialityName },
				{ "SpecialityText", specialityText },
				{ "ChangedAbilities", abilities },
				{ "ChangedSkin", soldierData.Skin }
			});
		});
		RenderLegendItems(soldier, btn);
	}

	private void ClearSoldierItem(GButton btn)
	{
		((GComponent)btn).GetChild("icon").asLoader.url = "";
		((GComponent)btn).GetChild("lv").text = "";
		((GComponent)btn).GetChild("iconFrame").asLoader.url = "";
		((GComponent)btn).GetChild("lvFrame").asLoader.url = "";
		((GComponent)btn).GetChild("SoulStoneLevel").alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
	}

	private void RenderLegendItems(SoldierDetail soldier, GButton button)
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		if (soldier.LegendItems == null)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
			return;
		}
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
