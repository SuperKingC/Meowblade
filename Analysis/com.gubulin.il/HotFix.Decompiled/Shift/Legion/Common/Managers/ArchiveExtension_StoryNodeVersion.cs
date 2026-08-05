using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_StoryNodeVersion
{
	private const string StoryNodeConfigVersionKey = "StoryNodeConfigVersion";

	private static Dictionary<string, int> NodeVersion_Dict;

	private static void EnsureStoryNodeConfigVersion(this UserArchiveManager manager)
	{
		if (!manager.Contains("StoryNodeConfigVersion"))
		{
			manager.SetStoryNodeConfigVersion("");
		}
	}

	public static void SetStoryNodeConfigVersion(this UserArchiveManager manager, string value)
	{
		manager.SetConfigValue("StoryNodeConfigVersion", value);
	}

	public static string GetStoryNodeConfigVersion(this UserArchiveManager manager)
	{
		manager.EnsureStoryNodeConfigVersion();
		return manager.GetConfigValue<string>("StoryNodeConfigVersion");
	}

	public static int GetStoryNodeVersionById(this UserArchiveManager manager, string nodeId)
	{
		if (NodeVersion_Dict == null)
		{
			string storyNodeConfigVersion = manager.GetStoryNodeConfigVersion();
			if (string.IsNullOrEmpty(storyNodeConfigVersion))
			{
				return -1;
			}
			NodeVersion_Dict = storyNodeConfigVersion.ToConfiguration<Dictionary<string, int>>();
		}
		if (NodeVersion_Dict.TryGetValue(nodeId, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("[ArchiveExtension_StoryNodeVersion] GetStoryNodeVersionById 不存在 nodeId=" + nodeId + " 的版本信息");
		return -1;
	}
}
