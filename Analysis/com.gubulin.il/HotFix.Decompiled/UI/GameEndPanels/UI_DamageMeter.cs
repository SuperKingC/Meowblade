using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;

namespace UI.GameEndPanels;

public class UI_DamageMeter : GComponent, IUiController, IAnyReplayStateListener
{
	public Controller Status;

	public Controller TypeController;

	public UI_OurDamageMeterCom OurDamageMeterCom;

	public UI_EnemyDamageMeterCom EnemyDamageMeterCom;

	public UI_EnemyDamageMeterComB EnemyDamageMeterVideoCom;

	public UI_OurDamageMeterComB OurDamageMeterVideoCom;

	public GTextField tip1;

	public GGroup ContentGroup;

	public GGraph Back0;

	public UI_show MeterSwitch;

	public GImage n14;

	public GGroup n15;

	public UI_CloseVideo CloseVideo;

	public UI_PlayBattleVideo PlayBattleVideo;

	public GButton lookBack;

	public GGraph Mask;

	public UI_ReplayDialog ReplayDialog;

	public GTextField replayId;

	public Transition ReplayDialogPopup;

	public Transition SlideOut;

	public const string URL = "ui://hda5vzklrjqw34";

	public static string Name = "UI_DamageMeter";

	private GameStateEntity _gameStateEntity;

	private List<string> _textureList = new List<string>();

	private Dictionary<string, Tuple<int, int, float>> OurSoldiersData = new Dictionary<string, Tuple<int, int, float>>();

	private Dictionary<string, Tuple<int, int, float>> EnemySoldiersData = new Dictionary<string, Tuple<int, int, float>>();

	private float OurTotalDamage;

	private float EnemyTotalDamge;

	private List<float> OurDamagePercent;

	private List<float> EnemyDamagePercent;

	private string MvpId;

	private List<string> textureList = new List<string>();

	private int result;

	private Dictionary<Team, BattleResultStats> battleResultStatses = new Dictionary<Team, BattleResultStats>();

	private const int playBackType = 1;

	private const int battleType = 0;

	private const int gvgDetailType = 2;

	private GList OurSoldierDamageDataList;

	private GList EnemySoldierDamageDataList;

	private bool canReplayVideo;

	private bool isInstancezoneReplay;

	private bool isRankBattle;

	private bool isGvGReplay;

	private bool isIslandComeAgainReplay;

	private string battleId;

	private bool _isGvGMode3Replay;

	private Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _redDetails;

	private Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail> _blueDetails;

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw34";
	}

	public static UI_DamageMeter CreateInstance()
	{
		return (UI_DamageMeter)(object)UIPackage.CreateObject("GameEndPanels", "DamageMeter");
	}

	public static UI_DamageMeter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageMeter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		TypeController = ((GComponent)this).GetController("TypeController");
		OurDamageMeterCom = (UI_OurDamageMeterCom)(object)((GComponent)this).GetChild("OurDamageMeterCom");
		EnemyDamageMeterCom = (UI_EnemyDamageMeterCom)(object)((GComponent)this).GetChild("EnemyDamageMeterCom");
		EnemyDamageMeterVideoCom = (UI_EnemyDamageMeterComB)(object)((GComponent)this).GetChild("EnemyDamageMeterVideoCom");
		OurDamageMeterVideoCom = (UI_OurDamageMeterComB)(object)((GComponent)this).GetChild("OurDamageMeterVideoCom");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id = "ui://hda5vzklrjqw34".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
		ContentGroup = (GGroup)((GComponent)this).GetChild("ContentGroup");
		Back0 = (GGraph)((GComponent)this).GetChild("Back0");
		MeterSwitch = (UI_show)(object)((GComponent)this).GetChild("MeterSwitch");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		CloseVideo = (UI_CloseVideo)(object)((GComponent)this).GetChild("CloseVideo");
		PlayBattleVideo = (UI_PlayBattleVideo)(object)((GComponent)this).GetChild("PlayBattleVideo");
		lookBack = (GButton)((GComponent)this).GetChild("lookBack");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		ReplayDialog = (UI_ReplayDialog)(object)((GComponent)this).GetChild("ReplayDialog");
		replayId = (GTextField)((GComponent)this).GetChild("replayId");
		ReplayDialogPopup = ((GComponent)this).GetTransition("ReplayDialogPopup");
		SlideOut = ((GComponent)this).GetTransition("SlideOut");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("BattleStats", out var value) && value != null)
		{
			battleResultStatses = (Dictionary<Team, BattleResultStats>)value;
			if (parameters.TryGetValue("ShowLookBack", out var value2))
			{
				bool visible = (bool)value2;
				((GObject)lookBack).visible = visible;
			}
			if (parameters.TryGetValue("ReturnMainCity", out var value3))
			{
				isInstancezoneReplay = (bool)value3;
			}
			if (parameters.TryGetValue("isRankBattle", out var value4))
			{
				isRankBattle = (bool)value4;
			}
			if (parameters.TryGetValue("IsGvGReplay", out var value5))
			{
				isGvGReplay = (bool)value5;
			}
			if (parameters.TryGetValue("IsIslandComeAgain", out var value6))
			{
				isIslandComeAgainReplay = (bool)value6;
			}
			if (parameters.TryGetValue("BattleId", out var value7))
			{
				battleId = value7.ToString();
			}
			else if (GameController.Contexts.gameState.hasReplayBattleId)
			{
				battleId = GameController.Contexts.gameState.replayBattleId.value;
			}
			_redDetails = (parameters.TryGetValue("RedDetails", out var value8) ? ((Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail>)value8) : null);
			_blueDetails = (parameters.TryGetValue("BlueDetails", out var value9) ? ((Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail>)value9) : null);
			if (parameters.TryGetValue("IslandComeAgainRedDetails", out var value10))
			{
				_redDetails = new Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail>();
				foreach (Shift.Legion.ClientApi.Models.SoldierDetail item in (List<Shift.Legion.ClientApi.Models.SoldierDetail>)value10)
				{
					_redDetails.Add(item.SoldierId, new Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail
					{
						SoldierId = item.SoldierId,
						PortalId = item.PortalId,
						PotentialLevel = item.PotentialLevel,
						Level = item.Level,
						CombatPower = item.CombatPower.ToString()
					});
				}
			}
			if (parameters.TryGetValue("IslandComeAgainBlueDetails", out var value11))
			{
				_blueDetails = new Dictionary<string, Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail>();
				foreach (Shift.Legion.ClientApi.Models.SoldierDetail item2 in (List<Shift.Legion.ClientApi.Models.SoldierDetail>)value11)
				{
					_blueDetails.Add(item2.SoldierId, new Shift.Legion.GvG.Common.Models.GvGMode3.SoldierDetail
					{
						SoldierId = item2.SoldierId,
						PortalId = item2.PortalId,
						PotentialLevel = item2.PotentialLevel,
						Level = item2.Level,
						CombatPower = item2.CombatPower.ToString()
					});
				}
			}
			_isGvGMode3Replay = parameters.TryGetValue("GvGMode3Replay", out var value12) && (bool)value12;
			((GObject)this).sortingOrder = ((!parameters.TryGetValue("SortingOrder", out var value13)) ? 1 : ((int)value13));
			result = ((!parameters.TryGetValue("BattleResult", out var value14)) ? 1 : ((int)value14));
			TypeController.selectedIndex = (parameters.TryGetValue("Type", out var value15) ? ((int)value15) : 0);
			if (TypeController.selectedIndex == 0)
			{
				FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			}
			else if (TypeController.selectedIndex == 1 || TypeController.selectedIndex == 2)
			{
				FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
				float num = (float)Screen.width / (float)Screen.height;
				float num2 = 1.7777778f;
				float num3 = num / num2;
			}
			((GObject)replayId).visible = !string.IsNullOrEmpty(battleId);
			((GObject)replayId).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("DamageMeterBattleReplayId".ToLanguage(), battleId);
			MeterSwitchInit();
			FGUIManager.Instance.DamageMeter = this;
			if (battleResultStatses.Count >= 0)
			{
				ProcessDamageData();
				RenderBothHealthBar();
				RenderOurDamageDataList();
				RenderEnemyDamageDataList();
			}
		}
		else
		{
			ILRuntimeDebug.LogError("没有获取到统计数据");
			End();
		}
	}

	public void OnShow()
	{
		if (isGvGReplay)
		{
			GvGConfigHelper.SetDoNotCloseUisVisible(visible: false);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyReplayStateListener(this);
		((GButton)MeterSwitch).onChanged.Add(new EventCallback0(MeterSwitchEvent));
		((GObject)CloseVideo).onClick.Add(new EventCallback0(StopVideo));
		((GObject)PlayBattleVideo).onClick.Add(new EventCallback0(PlayVideoSwitchEvent));
		((GObject)lookBack).onClick.Add(new EventCallback0(BattleLookBack));
		((GObject)ReplayDialog.ReplayBtn).onClick.Add(new EventCallback0(ReplayBtnClick));
		((GObject)ReplayDialog.ExitBtn).onClick.Add(new EventCallback0(StopVideo));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyReplayStateListener(this);
		((GButton)MeterSwitch).onChanged.Remove(new EventCallback0(MeterSwitchEvent));
		((GObject)CloseVideo).onClick.Remove(new EventCallback0(StopVideo));
		((GObject)PlayBattleVideo).onClick.Remove(new EventCallback0(PlayVideoSwitchEvent));
		((GObject)lookBack).onClick.Remove(new EventCallback0(BattleLookBack));
		((GObject)ReplayDialog.ReplayBtn).onClick.Remove(new EventCallback0(ReplayBtnClick));
		((GObject)ReplayDialog.ExitBtn).onClick.Remove(new EventCallback0(StopVideo));
	}

	private void BattleLookBack()
	{
		if (isRankBattle)
		{
			RankDataHelper.BattleLookBack();
			return;
		}
		FGUIManager.Instance.GameEndPanelVictoryPanel?.QuickLevelClaimBonusForPlayVideo();
		QuickPlayReplayService.Instance.BattleLookBack();
	}

	public void End()
	{
		((GObject)this).alpha = 0f;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
		FGUIManager.Instance.DamageMeter = null;
	}

	private void MeterSwitchInit()
	{
		if (TypeController.selectedIndex == 1)
		{
			((GButton)MeterSwitch).selected = false;
			Status.selectedIndex = 0;
		}
		else if (GameLocalDataManager.HasKey("DamageMeterSwitch"))
		{
			if (GameLocalDataManager.GetBool("DamageMeterSwitch"))
			{
				((GButton)MeterSwitch).selected = true;
				Status.selectedIndex = 1;
			}
			else
			{
				((GButton)MeterSwitch).selected = false;
				Status.selectedIndex = 0;
			}
		}
		else
		{
			((GButton)MeterSwitch).selected = true;
			Status.selectedIndex = 1;
			GameLocalDataManager.SetBool("DamageMeterSwitch", value: true);
		}
	}

	private void MeterSwitchEvent()
	{
		if (((GButton)MeterSwitch).selected)
		{
			GameLocalDataManager.SetBool("DamageMeterSwitch", value: true);
		}
		else
		{
			GameLocalDataManager.SetBool("DamageMeterSwitch", value: false);
		}
	}

	private void SetPlayVideoSwitchState(int state)
	{
		switch (state)
		{
		case 1:
			((GButton)PlayBattleVideo).selected = false;
			break;
		case 2:
			((GButton)PlayBattleVideo).selected = true;
			break;
		case 3:
			((GButton)PlayBattleVideo).selected = true;
			Status.selectedIndex = 1;
			((GButton)MeterSwitch).selected = true;
			((GObject)Mask).visible = true;
			ReplayDialogPopup.Play();
			canReplayVideo = true;
			break;
		default:
			((GButton)PlayBattleVideo).selected = false;
			break;
		}
	}

	private void ReplayBtnClick()
	{
		if (canReplayVideo)
		{
			RePlayVideo();
		}
	}

	private void PlayVideoSwitchEvent()
	{
		if (canReplayVideo)
		{
			RePlayVideo();
		}
		else if (((GButton)PlayBattleVideo).selected)
		{
			PauseVideo();
		}
		else
		{
			PlayVideo();
		}
	}

	private void RePlayVideo()
	{
		object lastReplay = GameLocalDataManager.GetLastReplay();
		if (lastReplay != null)
		{
			GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", (PlayBattleReplayData)lastReplay, null);
		}
	}

	private void StopVideo()
	{
		GameController.Contexts.Service<IUiService>().CloseAll();
		if (isInstancezoneReplay)
		{
			GameController.Contexts.Service<ReplayPlayerService>().Stop();
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"OpenUiOnReturn",
					QuickPlayReplayService.returnUiName
				},
				{
					"UiParamsOnReturn",
					QuickPlayReplayService.returnUiParams
				}
			}));
		}
		else if (isRankBattle)
		{
			GameController.Contexts.Service<ReplayPlayerService>().Stop();
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"LoadedCallback",
					(Action<string>)delegate
					{
						RankDataHelper.OpenPvpPanelOnReturnMainCity();
					}
				}
			}));
		}
		else if (isGvGReplay)
		{
			GameController.Contexts.Service<ReplayPlayerService>().Stop();
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"LoadedCallback",
					(Action<string>)delegate
					{
						GvGConfigHelper.SetDoNotCloseUisVisible(visible: true);
					}
				}
			}));
		}
		else if (isIslandComeAgainReplay)
		{
			GameController.Contexts.Service<ReplayPlayerService>().Stop();
			string scene = (Singleton<GvGInstanceZone>.Instance.IsInZone ? "SceneGVG2" : "MainCity.Right");
			CommandFactory.CreateOpenSceneCommand(scene, new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"LoadedCallback",
					(Action<string>)delegate
					{
						Singleton<GvGInstanceZone>.Instance.OnReplayEnd();
					}
				}
			}));
		}
		else if (_isGvGMode3Replay)
		{
			StopVideoGvGMode3();
		}
		else
		{
			CommandFactory.CreateExitReplayCommand();
		}
		GameLocalDataManager.ClearLastReplayUserInfo();
	}

	private void StopVideoGvGMode3()
	{
		End();
		GameController.Contexts.Service<ReplayPlayerService>().Stop();
		GameController.Contexts.Service<IUiService>().StartRecoverBackup();
		CommandFactory.CreateOpenSceneCommand("SceneGVG2", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{
				"LoadedCallback",
				(Action<string>)delegate
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayRecover());
				}
			}
		}));
		static IEnumerator DelayRecover()
		{
			yield return null;
			SentrySdk.AddBreadcrumb("[UI_DamageMeter] StopVideoGvGMode3 TryDelayDisconnectRoom");
			GameController.Contexts.Service<IUiService>().RecoverLastBackup(Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed ? 1 : 0);
			Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
		}
	}

	private void PauseVideo()
	{
		CommandFactory.CreatePauseReplayCommand();
	}

	private void PlayVideo()
	{
		CommandFactory.CreatePlayReplayCommand();
	}

	private void ProcessDamageData()
	{
		if (battleResultStatses.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<Team, BattleResultStats> battleResultStatse in battleResultStatses)
		{
			if (battleResultStatse.Key == Team.Red)
			{
				ProcessDamageData(OurSoldiersData, battleResultStatse.Value);
			}
			else if (battleResultStatse.Key == Team.Blue)
			{
				ProcessDamageData(EnemySoldiersData, battleResultStatse.Value);
			}
		}
		if (result != -1)
		{
			float num = 0f;
			foreach (string key in OurSoldiersData.Keys)
			{
				if (OurSoldiersData[key].Item3 > num)
				{
					num = OurSoldiersData[key].Item3;
					MvpId = key;
				}
			}
		}
		else
		{
			float num2 = 0f;
			foreach (string key2 in EnemySoldiersData.Keys)
			{
				if (EnemySoldiersData[key2].Item3 > num2)
				{
					num2 = EnemySoldiersData[key2].Item3;
					MvpId = key2;
				}
			}
		}
		List<float> percentList = new List<float>();
		foreach (KeyValuePair<string, Tuple<int, int, float>> ourSoldiersDatum in OurSoldiersData)
		{
			OurTotalDamage += ourSoldiersDatum.Value.Item3;
			percentList.Add(ourSoldiersDatum.Value.Item3);
		}
		OurDamagePercent = UiHelper.CalculatePercent(OurTotalDamage, ref percentList);
		List<float> percentList2 = new List<float>();
		foreach (KeyValuePair<string, Tuple<int, int, float>> enemySoldiersDatum in EnemySoldiersData)
		{
			EnemyTotalDamge += enemySoldiersDatum.Value.Item3;
			percentList2.Add(enemySoldiersDatum.Value.Item3);
		}
		EnemyDamagePercent = UiHelper.CalculatePercent(EnemyTotalDamge, ref percentList2);
	}

	private void ProcessDamageData(Dictionary<string, Tuple<int, int, float>> stats, BattleResultStats resultStats)
	{
		for (int i = 0; i < resultStats.Units.GetLength(0); i++)
		{
			for (int j = 0; j < resultStats.Units.GetLength(1); j++)
			{
				string text = resultStats.Units[i, j];
				if (text != null && !stats.ContainsKey(text))
				{
					float value = 0f;
					resultStats.UnitsDamage?.TryGetValue(text, out value);
					int value2 = 0;
					resultStats.UnitsDead?.TryGetValue(text, out value2);
					int item = resultStats.UnitsTotal[i, j];
					stats.Add(text, new Tuple<int, int, float>(value2, item, value));
				}
			}
		}
	}

	private int GetCasualtiesStatusIndex(float ratio)
	{
		int num = 0;
		if (ratio <= 0.2f)
		{
			return 0;
		}
		if (ratio <= 0.5f)
		{
			return 3;
		}
		if (ratio <= 0.8f)
		{
			return 1;
		}
		return 2;
	}

	private void RenderBothHealthBar()
	{
		if (TypeController.selectedIndex == 1 || TypeController.selectedIndex == 2)
		{
			OurSoldierDamageDataList = OurDamageMeterVideoCom.SoldierDamageDataList;
			EnemySoldierDamageDataList = EnemyDamageMeterVideoCom.SoldierDamageDataList;
			return;
		}
		((GProgressBar)OurDamageMeterCom.HealthBar).value = (FGUIManager.Instance.BothHealthBarValues.TryGetValue("RedHealthBarValue", out var value) ? value : 100.0);
		((GProgressBar)EnemyDamageMeterCom.HealthBar).value = (FGUIManager.Instance.BothHealthBarValues.TryGetValue("BlueHealthBarValue", out var value2) ? value2 : 0.0);
		OurSoldierDamageDataList = OurDamageMeterCom.SoldierDamageDataList;
		EnemySoldierDamageDataList = EnemyDamageMeterCom.SoldierDamageDataList;
	}

	private void RenderOurDamageDataList()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (_redDetails != null)
		{
			OurSoldierDamageDataList.itemRenderer = new ListItemRenderer(RenderRedSoldierDetail);
		}
		else
		{
			OurSoldierDamageDataList.itemRenderer = new ListItemRenderer(RenderOurDamageDataItem);
		}
		OurSoldierDamageDataList.numItems = OurSoldiersData.Count;
		for (int i = 0; i < OurSoldierDamageDataList.numItems; i++)
		{
			if (((GComponent)((GComponent)OurSoldierDamageDataList).GetChildAt(i).asButton).GetChild("Icon").asCom.GetChild("OurBossIcon").visible)
			{
				((GComponent)OurSoldierDamageDataList).SetChildIndex(((GComponent)OurSoldierDamageDataList).GetChildAt(i), 0);
				break;
			}
		}
	}

	private void RenderRedSoldierDetail(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		KeyValuePair<string, Tuple<int, int, float>> keyValuePair = OurSoldiersData.ToList()[index];
		if (_redDetails.TryGetValue(keyValuePair.Key, out var value))
		{
			GComponent asCom = ((GComponent)asButton).GetChild("Icon").asCom;
			GComponent asCom2 = asCom.GetChild("Iconloader").asCom;
			asCom2.GetController("Type").selectedIndex = 1;
			asCom2.GetChild("Iconloader").asLoader.url = value.Icon;
			Controller controller = ((GComponent)asButton).GetController("MvpStatus");
			Controller controller2 = asCom.GetController("MvpStatus");
			if (result == 1)
			{
				controller.selectedIndex = ((keyValuePair.Key == MvpId) ? 1 : 0);
			}
			else
			{
				controller.selectedIndex = 0;
			}
			controller2.selectedIndex = controller.selectedIndex;
			((GComponent)asButton).GetChild("DamageBar").asProgress.value = OurDamagePercent[index];
			((GComponent)asButton).GetChild("percent").text = $"{Convert.ToInt32(OurDamagePercent[index])}%";
			float ratio = (float)keyValuePair.Value.Item1 / (float)keyValuePair.Value.Item2;
			((GComponent)asButton).GetController("Status").selectedIndex = GetCasualtiesStatusIndex(ratio);
			((GComponent)asButton).GetChild("num").text = $"{keyValuePair.Value.Item1}";
			GObject child = asCom.GetChild("OurBossIcon");
			child.visible = value.IsBoss;
		}
	}

	private void RenderOurDamageDataItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		KeyValuePair<string, Tuple<int, int, float>> keyValuePair = OurSoldiersData.ToList()[index];
		Soldier soldier = new Soldier(keyValuePair.Key);
		((GComponent)asButton).GetChild("Icon").asCom.GetChild("Iconloader").asCom.GetController("Type").selectedIndex = 1;
		((GComponent)asButton).GetChild("Icon").asCom.GetChild("Iconloader").asCom.GetChild("Iconloader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(keyValuePair.Key);
		if (result == 1)
		{
			if (keyValuePair.Key == MvpId)
			{
				((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 1;
			}
			else
			{
				((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 0;
			}
		}
		else
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild("DamageBar").asProgress.value = OurDamagePercent[index];
		((GComponent)asButton).GetChild("percent").text = $"{Convert.ToInt32(OurDamagePercent[index])}%";
		float ratio = (float)keyValuePair.Value.Item1 / (float)keyValuePair.Value.Item2;
		((GComponent)asButton).GetController("Status").selectedIndex = GetCasualtiesStatusIndex(ratio);
		((GComponent)asButton).GetChild("num").text = $"{keyValuePair.Value.Item1}";
		if (soldier.Tags.Contains("IS_BOSS") || soldier.Tags.Contains("BOSS"))
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetChild("OurBossIcon").visible = true;
		}
		else
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetChild("OurBossIcon").visible = false;
		}
	}

	private void RenderEnemyDamageDataList()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (_blueDetails == null)
		{
			EnemySoldierDamageDataList.itemRenderer = new ListItemRenderer(RenderEnemyDamageDataItem);
		}
		else
		{
			EnemySoldierDamageDataList.itemRenderer = new ListItemRenderer(RenderBlueSoldierDetail);
		}
		EnemySoldierDamageDataList.numItems = EnemySoldiersData.Count;
		for (int i = 0; i < EnemySoldierDamageDataList.numItems; i++)
		{
			if (((GComponent)((GComponent)EnemySoldierDamageDataList).GetChildAt(i).asButton).GetChild("Icon").asCom.GetChild("EnemyBossIcon").visible)
			{
				((GComponent)EnemySoldierDamageDataList).SetChildIndex(((GComponent)EnemySoldierDamageDataList).GetChildAt(i), 0);
				break;
			}
		}
	}

	private void RenderEnemyDamageDataItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		KeyValuePair<string, Tuple<int, int, float>> keyValuePair = EnemySoldiersData.ToList()[index];
		Soldier soldier = new Soldier(keyValuePair.Key);
		int num = int.Parse(soldier.GetSkin().Substring(4));
		string text = "";
		text = ((!isRankBattle && !isIslandComeAgainReplay && !_isGvGMode3Replay) ? (new Soldier(soldier.Data.ParentSoldierId).ItemId + $"_{num}") : (soldier.ItemId + $"_{num}"));
		((GComponent)asButton).GetChild("Icon").asCom.GetChild("Iconloader").asCom.GetController("Type").selectedIndex = 0;
		((GComponent)asButton).GetChild("Icon").asCom.GetChild("Iconloader").asCom.GetChild("Iconloader").asLoader.url = "ui://PublicResources/" + text;
		if (result == -1)
		{
			if (keyValuePair.Key == MvpId)
			{
				((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 1;
			}
			else
			{
				((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 0;
			}
		}
		else
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetController("MvpStatus").selectedIndex = 0;
		}
		((GComponent)asButton).GetChild("DamageBar").asProgress.value = EnemyDamagePercent[index];
		((GComponent)asButton).GetChild("percent").text = $"{Convert.ToInt32(EnemyDamagePercent[index])}%";
		float ratio = (float)keyValuePair.Value.Item1 / (float)keyValuePair.Value.Item2;
		((GComponent)asButton).GetController("Status").selectedIndex = GetCasualtiesStatusIndex(ratio);
		((GComponent)asButton).GetChild("num").text = $"{keyValuePair.Value.Item1}";
		if (soldier.Tags.Contains("IS_BOSS") || soldier.Tags.Contains("BOSS"))
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetChild("EnemyBossIcon").visible = true;
		}
		else
		{
			((GComponent)asButton).GetChild("Icon").asCom.GetChild("EnemyBossIcon").visible = false;
		}
	}

	private void RenderBlueSoldierDetail(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		KeyValuePair<string, Tuple<int, int, float>> keyValuePair = EnemySoldiersData.ToList()[index];
		if (_blueDetails.TryGetValue(keyValuePair.Key, out var value))
		{
			GComponent asCom = ((GComponent)asButton).GetChild("Icon").asCom;
			GComponent asCom2 = asCom.GetChild("Iconloader").asCom;
			asCom2.GetController("Type").selectedIndex = 0;
			asCom2.GetChild("Iconloader").asLoader.url = value.Icon;
			Controller controller = ((GComponent)asButton).GetController("MvpStatus");
			Controller controller2 = asCom.GetController("MvpStatus");
			if (result == -1)
			{
				controller.selectedIndex = ((keyValuePair.Key == MvpId) ? 1 : 0);
			}
			else
			{
				controller.selectedIndex = 0;
			}
			controller2.selectedIndex = controller.selectedIndex;
			((GComponent)asButton).GetChild("DamageBar").asProgress.value = EnemyDamagePercent[index];
			((GComponent)asButton).GetChild("percent").text = $"{Convert.ToInt32(EnemyDamagePercent[index])}%";
			float ratio = (float)keyValuePair.Value.Item1 / (float)keyValuePair.Value.Item2;
			((GComponent)asButton).GetController("Status").selectedIndex = GetCasualtiesStatusIndex(ratio);
			((GComponent)asButton).GetChild("num").text = $"{keyValuePair.Value.Item1}";
			GObject child = asCom.GetChild("EnemyBossIcon");
			child.visible = value.IsBoss;
		}
	}

	public void OnAnyReplayState(GameStateEntity entity, int value)
	{
		SetPlayVideoSwitchState(value);
	}
}
