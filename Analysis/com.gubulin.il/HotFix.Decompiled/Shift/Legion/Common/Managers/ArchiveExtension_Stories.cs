using System.Collections.Generic;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Stories
{
	private const string UndergoingStoryKey = "UNDERGOING_STORY";

	private const string PlayingStoryKey = "PLAYING_STORY";

	private const string PlayingStoryLineKey = "PLAYING_STORY_LINE";

	private const string PlayZBossExtraSceneKey = "PlayZBossExtraSceneKey";

	public static List<string> GetUndergoingStories(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("UNDERGOING_STORY");
	}

	public static void RemoveFromUndergoingStories(this UserArchiveManager manager, string storyId)
	{
		manager.RemoveFromList("UNDERGOING_STORY", storyId);
	}

	public static void AddUndergoingStory(this UserArchiveManager manager, string storyId)
	{
		manager.AddToList("UNDERGOING_STORY", storyId);
	}

	public static List<string> GetPlayingStories(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<string>>("PLAYING_STORY");
	}

	public static void RemovePlayingStory(this UserArchiveManager manager, string storyId)
	{
		manager.RemoveFromList("PLAYING_STORY", storyId);
		manager.RemoveFromDictConfig<string>("PLAYING_STORY_LINE", storyId);
	}

	public static void AddPlayingStory(this UserArchiveManager manager, string storyId)
	{
		List<string> playingStories = manager.GetPlayingStories();
		if (!playingStories.Contains(storyId))
		{
			manager.AddToList("PLAYING_STORY", storyId);
		}
	}

	public static Dictionary<string, string> GetPlayingStoriesLine(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<Dictionary<string, string>>("PLAYING_STORY_LINE");
	}

	public static void SetPlayingStoryLine(this UserArchiveManager manager, string storyId, string lineKey)
	{
		manager.SetValueOfDictConfig("PLAYING_STORY_LINE", storyId, lineKey, acceptInsert: true);
	}

	public static void SetPlayZBossExtraSceneRecord(this UserArchiveManager manager)
	{
		manager.SetConfigValue("PlayZBossExtraSceneKey", value: true);
	}

	public static bool GetPlayZBossExtraSceneRecord(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<bool>("PlayZBossExtraSceneKey");
	}
}
