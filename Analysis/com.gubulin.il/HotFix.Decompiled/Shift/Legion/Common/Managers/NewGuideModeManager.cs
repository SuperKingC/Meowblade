using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public class NewGuideModeManager : Manager
{
	public static Dictionary<string, string> GuideModeMissionPrefix = new Dictionary<string, string>
	{
		{ "NewForeign2", "NewSea_GuideMission" },
		{ "NewForeign", "OutSea_GuideMission" },
		{ "NewForeign3", "NewBieStory_GuideMission" },
		{ "New3", "NewBieStory_GuideMission" },
		{ "NewGuideMode", "Story_GuideMission" }
	};

	private const string OldGuideOpStroy = "Story0011";

	private const string SUFFIX = "_FrontEndOnly";

	public NewGuideMissionInstance MonoInstance;

	public static string OpStory
	{
		get
		{
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode2())
			{
				return "NewStory_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2())
			{
				return "NewSea_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3())
			{
				return "NewBieStory_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode3())
			{
				return "NewBieStory_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode())
			{
				return "OutSea_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
			{
				return "Story_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode4())
			{
				return "Story_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4())
			{
				return "Story_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode5())
			{
				return "Story_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5())
			{
				return "NewSea_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode6())
			{
				return "Story_GuideMission00c";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
			{
				return "Story_GuideMission00c1";
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
			{
				return "NewSea_GuideMission00c";
			}
			return "Story0011";
		}
	}

	public NewGuideModeManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, int>("NEW_GUIDE_MISSION_PLAY_STORY", PlayStory);
		Managers.Messenger.AddListener<string>("NEW_GUIDE_MISSION_SKIP_STORY", SkipStory);
		Managers.Messenger.AddListener("LOAD_STORIES", OnLoadStories);
		Managers.Messenger.AddListener<string>("STORY_END", OnStoryEnd);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, int>("NEW_GUIDE_MISSION_PLAY_STORY", PlayStory);
		Managers.Messenger.RemoveListener<string>("NEW_GUIDE_MISSION_SKIP_STORY", SkipStory);
		Managers.Messenger.RemoveListener("LOAD_STORIES", OnLoadStories);
		Managers.Messenger.AddListener<string>("STORY_END", OnStoryEnd);
	}

	public override Task Init()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		GameObject val = new GameObject("NewGuideMissionManager");
		Object.DontDestroyOnLoad((Object)(object)val);
		val.AddComponent<NewGuideMissionInstance>();
		MonoInstance = val.GetComponent<NewGuideMissionInstance>();
		return null;
	}

	private void OnLoadStories()
	{
		MonoInstance.OnLoadStories();
	}

	private void PlayStory(string missionId, int status)
	{
		MonoInstance.PlayStory(missionId, status);
	}

	private void SkipStory(string storyId)
	{
		MonoInstance.SkipStory(storyId);
	}

	private void OnStoryEnd(string storyId)
	{
		MonoInstance.OnStoryEnd(storyId);
	}
}
