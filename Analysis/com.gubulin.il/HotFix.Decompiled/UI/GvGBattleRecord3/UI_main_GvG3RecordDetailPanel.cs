using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.Battle;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;
using UI.Battle;
using UI.GameEndPanels;
using UI.LegendItemInfo;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGBattleRecord3;

public class UI_main_GvG3RecordDetailPanel : GComponent, IUiController
{
	public GGraph blackMask;

	public GLoader background;

	public GImage n63;

	public GImage n46;

	public UI_com_OurInfomationBar OurInfomationBar;

	public UI_com_EnemyInfomationBar EnemyInfomationBar;

	public UI_com_StandardFormationSketchMap MyStandardFormationSketchMap;

	public UI_com_EnemyStandardFormationSketchMap EnemyStandardFormationSketchMap;

	public GGraph n56;

	public GImage flashImage;

	public GTextField OurCombat;

	public GTextField n11;

	public GGroup PowerMine;

	public GGraph n57;

	public GImage flashImage2;

	public GTextField EnemyCombat;

	public GTextField n21;

	public GGroup PowerEnemy;

	public GButton backBtn;

	public UI_btn_Play PlayRecord;

	public UI_btn_CheckAbility CheckLeftAblities;

	public UI_btn_CheckAbility CheckRightAblities;

	public Transition MainUiFade;

	public const string URL = "ui://b3fc6085stwvh";

	public static string Name = "UI_main_GvG3RecordDetailPanel";

	private int _retryTimes = 0;

	private int _totalDownloadCnt = 0;

	private readonly WaitForSeconds _waitTime = new WaitForSeconds(0.2f);

	private bool _downloading;

	private GvG3RecordDetailUiModel _uiModel;

	private Dictionary<Team, BattleResultStats> _resultStats;

	private bool _reservePackageResOnClose;

	private bool _hasBoss;

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<GButton> ourFormations = new List<GButton>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<GButton> enemyFormations = new List<GButton>();

	private static List<Vector2> enemyVector2s = new List<Vector2>();

	private GvGMode3CalcBattleParams BattleParams => _uiModel.BattleParams;

	private string LevelId => _uiModel.RecordLevelId;

	private GetGvGBattleResultResponse BattleResult => _uiModel.BattleResult;

	private Dictionary<Team, BattleResultStats> ResultStats => _resultStats ?? (_resultStats = BattleFieldService.GetGvGBattleResultStats(_uiModel.BattleResult));

	private BattleRecordDetailModel RedDetail => _uiModel.RedDetailData;

	private BattleRecordDetailModel BlueDetail => _uiModel.BlueDetailData;

	private BattleLogShipInfo RedInfo => _uiModel.RedInfo;

	private Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> RedDetails => Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.RedDetails;

	private Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> BlueDetails => Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.BlueDetails;

	private BattleLogShipInfo BlueInfo => _uiModel.BlueInfo;

	public static string GetURL()
	{
		return "ui://b3fc6085stwvh";
	}

	public static UI_main_GvG3RecordDetailPanel CreateInstance()
	{
		return (UI_main_GvG3RecordDetailPanel)(object)UIPackage.CreateObject("GvGBattleRecord3", "main_GvG3RecordDetailPanel");
	}

	public static UI_main_GvG3RecordDetailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3RecordDetailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		OurInfomationBar = (UI_com_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_com_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		MyStandardFormationSketchMap = (UI_com_StandardFormationSketchMap)(object)((GComponent)this).GetChild("MyStandardFormationSketchMap");
		EnemyStandardFormationSketchMap = (UI_com_EnemyStandardFormationSketchMap)(object)((GComponent)this).GetChild("EnemyStandardFormationSketchMap");
		n56 = (GGraph)((GComponent)this).GetChild("n56");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://b3fc6085stwvh".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		n57 = (GGraph)((GComponent)this).GetChild("n57");
		flashImage2 = (GImage)((GComponent)this).GetChild("flashImage2");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://b3fc6085stwvh".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		PlayRecord = (UI_btn_Play)(object)((GComponent)this).GetChild("PlayRecord");
		CheckLeftAblities = (UI_btn_CheckAbility)(object)((GComponent)this).GetChild("CheckLeftAblities");
		CheckRightAblities = (UI_btn_CheckAbility)(object)((GComponent)this).GetChild("CheckRightAblities");
		MainUiFade = ((GComponent)this).GetTransition("MainUiFade");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_reservePackageResOnClose = parameters.TryGetValue("ReservePackageResOnClose", out var value) && (bool)value;
		_uiModel = (parameters.TryGetValue("RecordDetail", out var value2) ? ((GvG3RecordDetailUiModel)value2) : null);
		_hasBoss = parameters.TryGetValue("HasBoss", out var value3) && (bool)value3;
		RenderMainUi();
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
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)PlayRecord).onClick.Add(new EventCallback0(OnPlayBtnClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)PlayRecord).onClick.Remove(new EventCallback0(OnPlayBtnClick));
	}

	private void End()
	{
		FGUIManager.Instance.DamageMeter?.End();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, _reservePackageResOnClose);
	}

	private void RenderMainUi()
	{
		if (_uiModel == null)
		{
			ILRuntimeDebug.LogError("[GvG3战报]: GvG3RecordDetailUiModel is null");
			return;
		}
		GvGMode3BattleRecordsManager instance = Singleton<GvGMode3BattleRecordsManager>.Instance;
		Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> detailsDic = GetDetailsDic(_uiModel.RedDetailData.Soldiers);
		Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> detailsDic2 = GetDetailsDic(_uiModel.BlueDetailData.Soldiers);
		instance.UpdateRecordLevelInfo(null, null, null, null, null, null, null, detailsDic, detailsDic2);
		RenderUserInfo();
		RenderLegions();
		RenderAbilities();
		OpenDamageMeter();
	}

	private void RenderUserInfo()
	{
		RenderUserInfo((GComponent)(object)OurInfomationBar.ProfileDisplay, RedInfo);
		RenderUserInfo((GComponent)(object)EnemyInfomationBar.ProfileDisplay, BlueInfo);
	}

	private void RenderUserInfo(GComponent displayComponent, BattleLogShipInfo user)
	{
		GObject child = displayComponent.GetChild("Avatar");
		UI_com_ShipAvatar avatar = child as UI_com_ShipAvatar;
		if (avatar != null)
		{
			if (user.IsNpc)
			{
				DisplayNpcInfo();
			}
			else
			{
				DisplayPlayerInfo();
			}
		}
		void DisplayNpcInfo()
		{
			GObject child2 = displayComponent.GetChild("PlayerName");
			avatar.CampId.selectedIndex = user.CampId;
			avatar.HeadPortrait.Type.selectedIndex = 1;
			child2.text = user.NpcName();
			avatar.HeadPortrait.icon.url = user.NpcIcon();
		}
		void DisplayPlayerInfo()
		{
			GObject child2 = displayComponent.GetChild("ShipName");
			GTextField val = (GTextField)(object)((child2 is GTextField) ? child2 : null);
			if (val != null)
			{
				((GObject)val).text = user.MyShipName;
				avatar.HeadPortrait.Type.selectedIndex = 0;
				displayComponent.RenderPlayerProfileGvG3<GComponent>(new PlayerProfileParams<GComponent>
				{
					CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
					UserId = user.UserId,
					CampId = user.CampId
				}, user.UserId);
			}
		}
	}

	private void RenderLegions()
	{
		((GObject)OurCombat).text = RedDetail.GetTotalCombatPower(long.Parse(BattleParams.RedDiffCombatPower), BattleParams.RedTeam).ToString();
		SetOurPos(RedDetail.FormationId, RedDetail.Soldiers);
		((GObject)EnemyCombat).text = BlueDetail.GetTotalCombatPower(long.Parse(BattleParams.BlueDiffCombatPower), BattleParams.BlueTeam).ToString();
		SetEnemyPos(BlueDetail.FormationId, BlueDetail.Soldiers);
	}

	private IEnumerator InitDownload()
	{
		_downloading = true;
		GameController.Contexts.Service<INetworkService>().InformWatchingReplay(BattleParams.BattleId);
		GameManagers.Instance.Messenger.Broadcast("WATCHING_REPLAY");
		List<string> fileNames = new List<string> { "ret.bin" };
		for (int idx = 0; idx < BattleResult.ReplaySegments; idx++)
		{
			fileNames.Add(idx.ToString());
		}
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo
		{
			UserId = BlueInfo.UserId,
			IsUser = !BlueInfo.IsNpc,
			NpcUrl = BlueInfo.NpcIcon(),
			UserName = BlueInfo.NpcName()
		};
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			UserId = RedInfo.UserId,
			IsUser = !RedInfo.IsNpc,
			NpcUrl = RedInfo.NpcIcon(),
			UserName = RedInfo.NpcName()
		};
		_totalDownloadCnt = fileNames.Count;
		yield return DownloadZipReplay(fileNames);
	}

	public IEnumerator DownloadZipReplay(List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(BattleParams.BattleId, delegate(bool isSuccess)
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
	}

	public IEnumerator DownloadNormalReplay(List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		if (wait_tm > 0f)
		{
			yield return _waitTime;
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
		ReplayDownloadManager.DownloadReplay(BattleParams.BattleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (_retryTimes > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					_retryTimes++;
					FGUIManager.Instance.OpenIEnumerator(DownloadNormalReplay(queue, downloading, 0.2f));
				}
			}
			else
			{
				_retryTimes = 0;
				float num = 1f * (float)(_totalDownloadCnt - queue.Count) / (float)_totalDownloadCnt;
				float barValue = num * 35f + 65f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue);
				if (queue.Count == 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					_downloading = false;
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
		if (!((GObject)this).isDisposed)
		{
			PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
			{
				BattleId = BattleParams.BattleId,
				TargetFrame = BattleResult.ReplayFrames - 1,
				LevelId = LevelId,
				LocalSource = true,
				ReplayMode = 3,
				MaskDuration = 0
			};
			QuickPlayReplayService.info.BattleId = string.Empty;
			Singleton<GvGMode3BattleRecordsManager>.Instance.UpdateRecordLevelInfo(BattleParams.BattleId, LevelId, BattleResult.Result ? 1 : (-1), ResultStats, _hasBoss ? 1 : 0, BattleParams.BlueItemAbilities, BlueDetail.GetBossLevel());
			GameLocalDataManager.SetLastReplay(playBattleReplayData);
			GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(null, toBackupStack: true, closeHidden: true);
			SentrySdk.AddBreadcrumb("[UI_main_GvG3RecordDetailPanel] PlayReplay TryConnectToRoom");
			Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom();
			Singleton<CameraService>.Instance.SwitchToScene("BattleField");
			GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
		}
	}

	private void OpenDamageMeter()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder + 1
			},
			{ "Type", 2 },
			{
				"BattleResult",
				BattleResult.Result ? 1 : (-1)
			},
			{ "BattleStats", ResultStats },
			{ "GvGMode3Replay", true },
			{ "RedDetails", RedDetails },
			{ "BlueDetails", BlueDetails }
		});
	}

	private void OnPlayBtnClick()
	{
		if (RedDetail != null && BlueDetail != null && !_downloading)
		{
			FGUIManager.Instance.OpenIEnumerator(InitDownload());
		}
	}

	private void RenderAbilities()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		List<ItemAbility> redAbilities = BattleParams.GetRedAbilities();
		if (redAbilities.Count > 0)
		{
			CheckLeftAblities.Abilities.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				//IL_0145: Unknown result type (might be due to invalid IL or missing references)
				//IL_014f: Expected O, but got Unknown
				if (item is UI_com_Ability uI_com_Ability)
				{
					ItemAbility itemAbility = (ItemAbility)(((GObject)uI_com_Ability).data = redAbilities[index]);
					((GObject)uI_com_Ability.Title).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(itemAbility.AbilityData.Key);
					GLoader icon = uI_com_Ability.icon;
					string url = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
					icon.url = url;
					int specialTagValue = Singleton<AbilityDataManager>.Instance.GetSpecialTagValue(itemAbility.AbilityData.Key, "BuffType");
					int techLevel = GetTechLevel(itemAbility);
					if (techLevel > 0)
					{
						((GObject)uI_com_Ability.Lv).text = ((techLevel > 1) ? $"Lv{techLevel}" : string.Empty);
					}
					else
					{
						((GObject)uI_com_Ability.Lv).text = ((specialTagValue != 0) ? $"Lv{itemAbility.AbilityLevel}" : ((itemAbility.AbilityLevel > 1) ? $"Lv{itemAbility.AbilityLevel}" : string.Empty));
					}
					uI_com_Ability.BufforDebuff.SetSelectedIndex(specialTagValue);
					((GObject)uI_com_Ability).onClick.Set(new EventCallback1(OnAbilityItemClick));
				}
			};
			CheckLeftAblities.Abilities.numItems = redAbilities.Count;
			CheckLeftAblities.Abilities.ResizeToFit(CheckLeftAblities.Abilities.numItems);
			CheckLeftAblities.Type.selectedIndex = 1;
		}
		else
		{
			CheckLeftAblities.Abilities.ResizeToFit(1);
			CheckLeftAblities.Type.selectedIndex = 0;
		}
		List<ItemAbility> blueAbilities = BattleParams.GetBlueAbilities();
		if (blueAbilities.Count > 0)
		{
			CheckRightAblities.Abilities.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				//IL_0145: Unknown result type (might be due to invalid IL or missing references)
				//IL_014f: Expected O, but got Unknown
				if (item is UI_com_Ability uI_com_Ability)
				{
					ItemAbility itemAbility = (ItemAbility)(((GObject)uI_com_Ability).data = blueAbilities[index]);
					((GObject)uI_com_Ability.Title).text = Singleton<AbilityDataManager>.Instance.GetSpecialTagName(itemAbility.AbilityData.Key);
					GLoader icon = uI_com_Ability.icon;
					string url = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
					icon.url = url;
					int specialTagValue = Singleton<AbilityDataManager>.Instance.GetSpecialTagValue(itemAbility.AbilityData.Key, "BuffType");
					int techLevel = GetTechLevel(itemAbility);
					if (techLevel > 0)
					{
						((GObject)uI_com_Ability.Lv).text = ((techLevel > 1) ? $"Lv{techLevel}" : string.Empty);
					}
					else
					{
						((GObject)uI_com_Ability.Lv).text = ((specialTagValue != 0) ? $"Lv{itemAbility.AbilityLevel}" : ((itemAbility.AbilityLevel > 1) ? $"Lv{itemAbility.AbilityLevel}" : string.Empty));
					}
					uI_com_Ability.BufforDebuff.SetSelectedIndex(specialTagValue);
					((GObject)uI_com_Ability).onClick.Set(new EventCallback1(OnAbilityItemClick));
				}
			};
			CheckRightAblities.Abilities.numItems = blueAbilities.Count;
			CheckRightAblities.Abilities.ResizeToFit(CheckRightAblities.Abilities.numItems);
			CheckRightAblities.Type.selectedIndex = 1;
		}
		else
		{
			CheckRightAblities.Abilities.ResizeToFit(1);
			CheckRightAblities.Type.selectedIndex = 0;
		}
	}

	private void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = val.LocalToRoot(Vector2.zero, GRoot.inst);
			int techLevel = GetTechLevel(itemAbility);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
			{
				{ "Pos", val2 },
				{ "Data", itemAbility.AbilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", itemAbility.Icon },
				{ "Level", itemAbility.AbilityLevel },
				{ "TechLevel", techLevel }
			});
		}
	}

	private int GetTechLevel(ItemAbility ability)
	{
		int result = -1;
		if (ability.AbilityId.StartsWith("GVGcard"))
		{
			string key = ability.AbilityId.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries).Last();
			SoldierOuterTechEffectConfig config = JsonHelper.ToObject<SoldierOuterTechEffectConfig>(GDMgr.Get<GDEItemData>(key).Effect);
			result = OuterTechHelper.CalculateCountFromAbilityLevel(config, ability.AbilityLevel);
		}
		return result;
	}

	private Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> GetDetailsDic(List<Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> soldierDetails)
	{
		Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> dictionary = new Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail>();
		foreach (Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail soldierDetail in soldierDetails)
		{
			dictionary.Add(soldierDetail.SoldierId, soldierDetail);
		}
		return dictionary;
	}

	private void FormationsInit()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		if (ourFormations.Count >= 9)
		{
			return;
		}
		ourFormations.Clear();
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			GButton _redBtn = ((GComponent)MyStandardFormationSketchMap).GetChild($"OurFormation{i}").asButton;
			ourVector2s.Add(((GObject)_redBtn).xy);
			ourFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	public void SetOurFormations(List<Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _curSoldiers)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail soldierDetail = _curSoldiers[i];
				string soldierId = soldierDetail.SoldierId;
				BattleParams.RedTeam.TryGetValue(soldierId, out var value);
				if (!string.IsNullOrWhiteSpace(soldierId) && soldierId != "Unlock" && soldierId != "Lock" && value > 0)
				{
					((GComponent)ourFormations[i]).GetController("Type").selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], ((GComponent)ourFormations[i]).GetChild("Icon").asButton, 0);
					((GComponent)ourFormations[i]).GetChild("Icon").alpha = 1f;
					((GComponent)ourFormations[i]).GetChild("n7").visible = true;
					((GComponent)ourFormations[i]).GetChild("num").visible = true;
					int num2 = soldierDetail.Num;
					bool flag = value < num2;
					((GComponent)ourFormations[i]).GetChild("num").asTextField.color = (flag ? Color.red : Color.white);
					((GComponent)ourFormations[i]).GetChild("num").asTextField.strokeColor = (flag ? Color.white : Color.gray);
					((GComponent)ourFormations[i]).GetChild("num").text = $"{value}/{num2}";
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

	public void SetOurPos(string fid, List<Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _curSoldiers)
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
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
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
					((GObject)ourFormations[j]).xy = dictionary[key];
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
			((GObject)ourFormations[k]).xy = list[k - 5];
		}
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
	}

	private void EnemyFormationsInit()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		if (enemyFormations.Count >= 9)
		{
			return;
		}
		enemyFormations.Clear();
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			GButton _redBtn = ((GComponent)EnemyStandardFormationSketchMap).GetChild($"OurFormation{i}").asButton;
			enemyVector2s.Add(((GObject)_redBtn).xy);
			enemyFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	public void SetEnemyFormations(List<Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _curSoldiers)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail soldierDetail = _curSoldiers[i];
				string soldierId = soldierDetail.SoldierId;
				BattleParams.BlueTeam.TryGetValue(soldierId, out var value);
				if (!string.IsNullOrWhiteSpace(soldierId) && soldierId != "Unlock" && soldierId != "Lock" && value > 0)
				{
					((GComponent)enemyFormations[i]).GetController("Type").selectedIndex = 0;
					num++;
					RenderSoldierItem(_curSoldiers[i], ((GComponent)enemyFormations[i]).GetChild("Icon").asButton, 0);
					((GComponent)enemyFormations[i]).GetChild("Icon").alpha = 1f;
					((GComponent)enemyFormations[i]).GetChild("n7").visible = true;
					((GComponent)enemyFormations[i]).GetChild("num").visible = true;
					int num2 = soldierDetail.Num;
					bool flag = value < num2;
					((GComponent)enemyFormations[i]).GetChild("num").asTextField.color = (flag ? Color.red : Color.white);
					((GComponent)enemyFormations[i]).GetChild("num").asTextField.strokeColor = (flag ? Color.white : Color.gray);
					((GComponent)enemyFormations[i]).GetChild("num").text = $"{value}/{num2}";
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

	public void SetEnemyPos(string fid, List<Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _curSoldiers)
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
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
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
					((GObject)enemyFormations[j]).xy = dictionary[key];
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
			((GObject)enemyFormations[k]).xy = list[k - 5];
		}
		SetEnemyFormations(_curSoldiers);
		ShowEnemyIcons();
	}

	private void RenderSoldierItem(Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail soldier, GButton btn, int selectedIndex)
	{
		((GObject)btn).touchable = true;
		((GComponent)btn).GetChild("SoulStoneLevel").alpha = 1f;
		((GComponent)btn).GetController("Type").selectedIndex = selectedIndex;
		Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(soldier.SoldierId);
		((GComponent)btn).GetChild("BossTag").visible = soldier2.Data.Tags.Contains("WORLD_BOSS");
		int potentialLevel = soldier.PotentialLevel;
		SoldierExtensions.GvG3SoldierIconReader gvG3SoldierIconReader = soldier2.GetGvG3SoldierIconReader(potentialLevel);
		((GComponent)btn).GetChild("icon").asLoader.url = gvG3SoldierIconReader.GetIconUrl();
		((GComponent)btn).GetChild("iconFrame").asLoader.url = gvG3SoldierIconReader.GetFrameIconUrl();
		bool flag = soldier.Level > 0;
		((GComponent)btn).GetChild("lv").text = (flag ? soldier.Level.ToString() : string.Empty);
		((GComponent)btn).GetChild("lvFrame").asLoader.url = (flag ? UiHelper.GetLevelFrameBorderSoldier(gvG3SoldierIconReader.CorrectedPotentialLevel) : string.Empty);
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)btn).GetChild("iconFrame").asLoader, gvG3SoldierIconReader.CorrectedPotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)btn).GetChild("SoulStoneLevel").asCom, gvG3SoldierIconReader.CorrectedPotentialLevel, new List<int>());
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

	private void RenderLegendItems(Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail soldier, GButton button)
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
