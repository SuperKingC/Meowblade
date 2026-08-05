using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public class NewGuideMissionInstance : MonoBehaviour
{
	public class Model
	{
		public string MissionClientId;

		public int Status;

		public List<string> StoryIds;

		public int CurPlayIdx = 0;
	}

	private List<Model> _Sequence;

	private bool _IsPlaying;

	private Coroutine OnPlaying = null;

	private bool _IsLoadStories = false;

	public void OnLoadStories()
	{
		_IsLoadStories = true;
	}

	public bool HasStoryPlaying()
	{
		if (OnPlaying != null)
		{
			return true;
		}
		return false;
	}

	public void SkipStory(string storyId)
	{
		GameManagers.Instance.StoryManager.DeactivateStory(storyId);
		GameManagers.Instance.UserArchiveManager.RemovePlayingStory(storyId);
		if (_Sequence.Count == 0)
		{
			return;
		}
		Model model = _Sequence.FirstOrDefault((Model _model) => _model.StoryIds.Contains(storyId));
		if (model != null)
		{
			if (_Sequence[0] == model)
			{
				_IsPlaying = false;
			}
			_Sequence.Remove(model);
			if (_Sequence.Count == 0)
			{
				_IsPlaying = false;
			}
			OnPlaying = null;
		}
	}

	public void PlayStory(string mid, int status)
	{
		if (!MissionManager.Configs_GDEMissionFrontEndOnlyData.TryGetValue(mid, out var value))
		{
			ILRuntimeDebug.LogError(mid + " 无此GDEMissionFrontEndOnlyData配置");
			return;
		}
		if (!GameManagers.Instance.MissionManager.PickedMissions.TryGetValue(mid, out var value2))
		{
			ILRuntimeDebug.LogError(mid + " PickedMissions中无此任务");
			return;
		}
		value2.CheckProgress(GameManagers.Instance);
		MissionStatus status2 = value2.MissionState(GameManagers.Instance).Status;
		if (status != 4)
		{
			switch (status2)
			{
			case MissionStatus.Completed:
				status = 2;
				break;
			case MissionStatus.Undergoing:
				status = 1;
				break;
			case MissionStatus.Claimed:
				status = 3;
				break;
			}
		}
		List<string> list = null;
		switch (status)
		{
		case 1:
			list = JsonHelper.ToObject<List<string>>(value.OnUndergoing);
			break;
		case 2:
			list = JsonHelper.ToObject<List<string>>(value.OnCompleted);
			break;
		case 3:
			list = JsonHelper.ToObject<List<string>>(value.OnClaimed);
			break;
		case 4:
			list = JsonHelper.ToObject<List<string>>(value.OnGoTo);
			break;
		}
		if (list != null && list.Count != 0)
		{
			SkipStory(list[0]);
			_Sequence.Add(new Model
			{
				MissionClientId = mid,
				StoryIds = list,
				Status = status,
				CurPlayIdx = 0
			});
		}
	}

	public void AddUiStory(List<string> storyIds)
	{
		if (storyIds != null && storyIds.Count > 0)
		{
			SkipStory(storyIds[0]);
			_Sequence.Add(new Model
			{
				MissionClientId = "",
				StoryIds = storyIds,
				Status = 1,
				CurPlayIdx = 0
			});
		}
	}

	private void Awake()
	{
		_IsLoadStories = false;
		_Sequence = new List<Model>();
		_IsPlaying = false;
	}

	private void Update()
	{
		if (_IsLoadStories && GameController.Contexts.gameState.isGameEntered && (!GameController.Contexts.gameState.hasLoadingPanelStatus || GameController.Contexts.gameState.loadingPanelStatus.value == LoadingPanelStatus.Closed) && !_IsPlaying && _Sequence.Count != 0 && OnPlaying == null)
		{
			OnPlaying = ((MonoBehaviour)this).StartCoroutine(OnPlay(_Sequence[0]));
		}
	}

	private IEnumerator OnPlay(Model _model)
	{
		yield return null;
		string storyId = _model.StoryIds[_model.CurPlayIdx];
		_IsPlaying = true;
		string temp_storyId = "FAKESTROYID_" + storyId;
		string startKey = "FAKESCONFIG_0_" + storyId;
		string activateKey = "FAKESCONFIG_1_" + storyId;
		string endKey = "FAKESCONFIG_2_" + storyId;
		if (!GDMgr.Has<GDEStoryData>(startKey))
		{
			GDEStoryData start = new GDEStoryData
			{
				Key = startKey,
				StoryId = temp_storyId,
				StartTrigger = "ActivateStory",
				Action = "StoryBegin",
				NextTrigger = ""
			};
			GDMgr.TryAdd(start.Key, start);
			GDEStoryData activate = new GDEStoryData
			{
				Key = activateKey,
				StoryId = temp_storyId,
				StartTrigger = "",
				Action = "ActivateStory",
				Payload = JsonHelper.ToJson(new Dictionary<string, string> { { "Story", storyId } }),
				NextTrigger = "Continue"
			};
			GDMgr.TryAdd(activate.Key, activate);
			GDEStoryData end = new GDEStoryData
			{
				Key = endKey,
				StoryId = temp_storyId,
				StartTrigger = "",
				Action = "StoryEnd",
				NextTrigger = ""
			};
			GDMgr.TryAdd(end.Key, end);
			StoryManager.StoryLines.Add(temp_storyId, new List<string> { start.Key, activate.Key, end.Key });
		}
		StoryManager.PlayStoryWithOutServer(GameManagers.Instance, temp_storyId);
	}

	public void OnStoryEnd(string storyId)
	{
		if (_Sequence.Count <= 0)
		{
			return;
		}
		Model model = _Sequence[0];
		string value = model.StoryIds[model.CurPlayIdx];
		if (storyId.Equals(value))
		{
			model.CurPlayIdx++;
			if (_Sequence[0].CurPlayIdx >= _Sequence[0].StoryIds.Count)
			{
				_Sequence.RemoveAt(0);
			}
			OnPlaying = null;
			_IsPlaying = false;
		}
	}
}
