using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

public class EnterGameStoryExecute
{
	public class LoadStoryParam
	{
		public string StoryId { get; }

		public string ChapterId { get; }

		public string LevelId { get; }

		public LoadStoryParam(string storyId, string chapterId, string levelId = "")
		{
			StoryId = storyId;
			ChapterId = chapterId;
			LevelId = levelId;
		}
	}

	private readonly Contexts _contexts;

	public EnterGameStoryExecute(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void LoadStories(string initScene)
	{
		StoryManager storyManager = GameManagers.Instance.StoryManager;
		GameManagers.Instance.StoryManager.LoadStories();
		List<string> playingStories = storyManager.PlayingStories;
		if (playingStories.Count < 1)
		{
			LoadLegendItemStory();
			LoadGvG3Stories();
		}
		else
		{
			if (playingStories.Count <= 0)
			{
				return;
			}
			storyManager.CleanResidualStories();
			if (playingStories.Count == 0)
			{
				return;
			}
			string firstStoryId = playingStories[0];
			if (GameManagers.Configs.TryGetValue("SCP", out var value) && value == "0")
			{
				Action action = delegate
				{
					ILRequestHelper<SkipCurrentStoryResponse>.Request(null, () => _contexts.Service<INetworkService>().SkipCurrentStory(-1L, null), delegate(SkipCurrentStoryResponse response)
					{
						if (response != null && !response.Result)
						{
							ILRequestHelper.ShowErrorCode(response.ErrorCode);
						}
						else
						{
							storyManager.Skip();
						}
					}, 1f);
				};
				if (!storyManager.PlayingStoriesLine.ContainsKey(firstStoryId))
				{
					action();
					return;
				}
				string key = storyManager.PlayingStoriesLine[firstStoryId];
				GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(key);
				if (gDEStoryData == null)
				{
					action();
				}
				else if (!string.IsNullOrEmpty(gDEStoryData.ReviewStory))
				{
					if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && !string.IsNullOrEmpty(gDEStoryData.OpenUI))
					{
						if (_contexts.Service<IUiService>().HasShowingUi(gDEStoryData.OpenUI))
						{
							StoryManager.PlayStory(GameManagers.Instance, firstStoryId);
						}
						else
						{
							GameManagers.Instance.StoryManager.ActivateStory(firstStoryId);
						}
					}
					else
					{
						StoryManager.PlayStory(GameManagers.Instance, firstStoryId);
					}
				}
				else
				{
					action();
				}
				return;
			}
			string playingStoryLine = storyManager.GetPlayingStoryLine(firstStoryId);
			if (playingStoryLine == null || !StoryManager.StoryLines.TryGetValue(firstStoryId, out var value2) || value2.Count < 1 || !StoryManager.StoryLineData.TryGetValue(value2[0], out var startLineData))
			{
				return;
			}
			foreach (string item in value2)
			{
				if (item == playingStoryLine || !StoryManager.StoryLineData.TryGetValue(item, out var _data))
				{
					break;
				}
				if (_data.CheckPoint)
				{
					startLineData = _data;
				}
			}
			Action<string> action2 = delegate
			{
				if (!string.IsNullOrEmpty(startLineData.OpenUI))
				{
					List<Dictionary<string, object>> list = JsonHelper.ToObject<List<Dictionary<string, object>>>(startLineData.OpenUI);
					for (int i = 0; i < list.Count; i++)
					{
						Dictionary<string, object> dictionary = list[i];
						if (dictionary.TryGetValue("UI", out var value3))
						{
							dictionary.Remove("UI");
							_contexts.Service<IUiService>().OpenPanel(value3.ToString(), dictionary);
						}
					}
				}
				StoryManager.PlayStory(GameManagers.Instance, firstStoryId);
			};
			if (!string.IsNullOrEmpty(startLineData.OpenScene))
			{
				switch (startLineData.OpenScene)
				{
				case "BattleField":
					CommandFactory.CreateOpenSceneCommand(startLineData.OpenScene, new SceneBattleFieldArguments(new Dictionary<string, object>
					{
						{
							"LevelId",
							GameManagers.Instance.UserArchiveManager.GetCurrentLevelId()
						},
						{ "Asset", "Prefabs/BattleField" },
						{ "ForceCloseOtherUi", false },
						{ "TaskCompletionSource", null },
						{ "LoadedCallback", action2 }
					}));
					break;
				case "MainCity.Left":
				case "MainCity.Right":
					CommandFactory.CreateOpenSceneCommand(startLineData.OpenScene, new SceneArguments(new Dictionary<string, object>
					{
						{ "ForceCloseOtherUi", false },
						{ "TaskCompletionSource", null },
						{ "LoadingShowAllSoldier", true },
						{
							"LoadingAnimationDirection",
							LoadingAnimationDirection.Right
						},
						{ "LoadedCallback", action2 }
					}));
					break;
				}
			}
			else
			{
				action2(startLineData.OpenScene);
			}
		}
	}

	private void LoadLegendItemStory()
	{
		LoadLevelStory(new LoadStoryParam("Story6014", "C1006"));
	}

	private void LoadGvG3Stories()
	{
		if (Define.GvGMode3UnderDevelopment())
		{
			LoadLevelStory(new LoadStoryParam("Story6205", "C1007"));
			LoadLevelStory(new LoadStoryParam("Story11313", "C1011", "P1130"));
		}
	}

	private void LoadLevelStory(LoadStoryParam storyParam)
	{
		Dictionary<string, List<string>> levelProgress = GameManagers.Instance.UserArchiveManager.GetLevelProgress();
		Dictionary<string, string> playingStoriesLine = GameManagers.Instance.UserArchiveManager.GetPlayingStoriesLine();
		if (levelProgress.ContainsKey(storyParam.ChapterId) && CheckLevel() && !playingStoriesLine.ContainsKey(storyParam.StoryId))
		{
			PlayStory(storyParam.StoryId);
		}
		bool CheckLevel()
		{
			return string.IsNullOrEmpty(storyParam.LevelId) || levelProgress[storyParam.ChapterId].Contains(storyParam.LevelId);
		}
	}

	private void PlayStory(string storyId)
	{
		StoryManager.PlayStory(GameManagers.Instance, storyId);
	}
}
