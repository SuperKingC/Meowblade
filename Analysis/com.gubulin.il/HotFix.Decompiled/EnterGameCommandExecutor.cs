using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.GvGLoading;
using UI.GvGWorldMap3;
using UnityEngine;

public class EnterGameCommandExecutor
{
	private readonly Contexts _contexts;

	private readonly EnterGameStoryExecute _storyExecute;

	private GvGExpeditionHallModel _gvgData;

	public EnterGameCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
		_storyExecute = new EnterGameStoryExecute(contexts);
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		_contexts.gameState.isGameEntered = true;
		GameManagers.Instance.Messenger.Broadcast("GAME_ENTER");
		GameManagers.Instance.PullData();
		string opStory = NewGuideModeManager.OpStory;
		Action<string> loadStoriesAction = null;
		if (GameManagers.Instance.StoryManager.PlayingStories.Contains(opStory) || GameManagers.Instance.StoryManager.ActivatedStories.Contains(opStory))
		{
			_storyExecute.LoadStories("BattleField");
			GameManagers.Instance.Messenger.Broadcast("LOAD_STORIES");
		}
		else
		{
			loadStoriesAction = _storyExecute.LoadStories;
		}
		string currentChapterId = GameManagers.Instance.UserArchiveManager.GetCurrentChapterId();
		if (!string.IsNullOrEmpty(currentChapterId) && ChapterManager.Chapters.TryGetValue(currentChapterId, out var value) && (value.ChapterId == "C1000" || value.ChapterId == "C10000" || value.ChapterId == "C10001" || value.ChapterId == "C1000" || value.ChapterId == "C10002"))
		{
			CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{
					"LevelId",
					GameManagers.Instance.UserArchiveManager.GetCurrentLevelId()
				},
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", false },
				{ "TaskCompletionSource", null },
				{
					"LoadedCallback",
					(Action<string>)delegate(string scene)
					{
						loadStoriesAction?.Invoke(scene);
						GameManagers.Instance.Messenger.Broadcast("LOAD_STORIES");
						GameController.Contexts.Service<INetworkService>().EnterGame();
					}
				}
			}));
		}
		else
		{
			int? num = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord?.CurIZId;
			int num2 = GameLocalDataManager.GetInt($"QUICK_START_{num}");
			if (num2 == 1)
			{
				ILRequestHelper<GvGMode3RoomOperationDiabledResponse>.Request((EventContext)null, (Func<Task<GvGMode3RoomOperationDiabledResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3RoomOperationDisabled()), (Action<GvGMode3RoomOperationDiabledResponse>)delegate(GvGMode3RoomOperationDiabledResponse response)
				{
					if (!response.Result)
					{
						LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage).ToConfirmPopup(ToMainCity, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
					}
					else
					{
						_gvgData = new GvGExpeditionHallModel();
						_gvgData.GetData(delegate
						{
							if (!_gvgData.IsInit)
							{
								"GVG3_NO_INIT".ToLanguage().ToConfirmPopup(ToMainCity, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
							}
							else if (!_gvgData.IsSigned)
							{
								"GVG3_NO_SIGN".ToLanguage().ToConfirmPopup(ToMainCity, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
							}
							else if (!_gvgData.IsRoomStarted)
							{
								"GVG3_NO_ROOM_START".ToLanguage().ToConfirmPopup(ToMainCity, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
							}
							else
							{
								ToGvG3WorldMap();
							}
						});
					}
				});
			}
			else
			{
				ToMainCity();
			}
		}
		GameManagers.Instance.ActivityManager.CheckActivities(null, new List<ActivityType> { ActivityType.TimeLimitInstance });
		Action EnterMainCity()
		{
			return delegate
			{
				string scene = ((Dungeon.GetFreeManPower(GameManagers.Instance) < 0) ? "MainCity.Left" : "MainCity.Right");
				CommandFactory.CreateOpenSceneCommand(scene, new SceneArguments(new Dictionary<string, object>
				{
					{ "ForceCloseOtherUi", false },
					{ "TaskCompletionSource", null },
					{ "LoadingShowAllSoldier", true },
					{
						"LoadingAnimationDirection",
						LoadingAnimationDirection.Right
					},
					{
						"LoadedCallback",
						(Action<string>)delegate(string obj)
						{
							loadStoriesAction?.Invoke(obj);
							GameManagers.Instance.Messenger.Broadcast("LOAD_STORIES");
						}
					}
				}));
			};
		}
		void ToGvG3WorldMap()
		{
			Singleton<GvGMode3RoomManager>.Instance.OnQuickStartReturnMainCity = EnterMainCity();
			UI_main_GvGLoading2Panel.Open(UI_main_GvGLoading2Panel.eLoadingType.Enter, delegate
			{
				GameLocalDataManager.ClearSpeedPlanLastClaim();
				GameLocalDataManager.ClearSpeedPlanLastPurchase();
				Singleton<GvGMode3RoomManager>.Instance.StopwatchLogInterval("开了GvGLoading");
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGWorldMap3.Name, null);
			});
		}
		void ToMainCity()
		{
			List<GvGMode3ShipModel> list = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord?.Ships;
			if (list != null && list.Count > 0)
			{
				UI_main_GvGLoading2Panel.PreLoadAnim((eRace)list[0].PermanentData.ShipRace);
			}
			EnterMainCity()();
		}
	}

	private IEnumerator WaitToOpenScene(string scene, string levelid)
	{
		if (GameController.Contexts.gameState.hasLoadingPanelStatus && GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
		{
			yield return (object)new WaitForSeconds(0.1f);
			FGUIManager.Instance.OpenIEnumerator(WaitToOpenScene(scene, levelid));
			yield break;
		}
		CommandFactory.CreateOpenSceneCommand(scene, new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", levelid },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", false },
			{ "TaskCompletionSource", null },
			{
				"LoadedCallback",
				(Action<string>)delegate
				{
				}
			}
		}));
	}
}
