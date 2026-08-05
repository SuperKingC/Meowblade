using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Client.Sources.Extensions;

public static class ChapterActivityPayloadExtensions
{
	public static bool Play(this ChapterActivityPayload payload, GameManagers managers, int levelIndex = 0)
	{
		if (payload.Chapter == null)
		{
			return false;
		}
		List<Level> list = payload.Levels(managers);
		if (list.Count < 1)
		{
			return false;
		}
		if (levelIndex < 0 || levelIndex >= list.Count)
		{
			return false;
		}
		KeyValuePair<string, LevelStatus> keyValuePair = payload.LevelProgress(managers)[levelIndex];
		if (payload.CooldownPeriod > 0)
		{
			Dictionary<string, DateTimeOffset> levelCooldownRecord = payload.GetLevelCooldownRecord(payload.Activity.ActivityProgress(managers));
			if (levelCooldownRecord != null && levelCooldownRecord.Count > levelIndex && levelCooldownRecord.Values.ToArray()[levelIndex].CompareTo(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())) > 0)
			{
				return false;
			}
		}
		else if (payload.Chapter.Type == ChapterType.RepeatableInstanceOffensive && keyValuePair.Value == LevelStatus.Completed)
		{
			return false;
		}
		if (!payload.Activity.CanPlay(managers, payload.ChapterId))
		{
			return false;
		}
		bool isPortal = payload.IsPortal;
		Activity value = null;
		if (isPortal && !ActivityManager.Activities.TryGetValue(payload.PortalRoute, out value))
		{
			return false;
		}
		managers.ActivityManager.ActivityDifficultyLevels.GetValue().TryGetValue(payload.Activity.Type.ToString(), out var value2);
		if (isPortal && value != null && value2 >= value.DifficultyLevel)
		{
			return false;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (payload.Activity.UiParams != null)
		{
			foreach (KeyValuePair<string, object> uiParam in payload.Activity.UiParams)
			{
				dictionary.Add(uiParam.Key, uiParam.Value);
			}
		}
		Level level = list[levelIndex];
		Dictionary<string, int> value3 = null;
		if (!string.IsNullOrEmpty(payload.Activity.TicketItem) && payload.Tickets > 0)
		{
			value3 = new Dictionary<string, int> { 
			{
				payload.Activity.TicketItem,
				payload.Tickets
			} };
		}
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", level.LevelId },
			{ "LevelInst", level },
			{ "BattleCostKey", value3 },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"OpenUiOnReturn",
				payload.Activity.UiName
			},
			{ "UiParamsOnReturn", dictionary },
			{ "WorldMapBtnVisible", false }
		}));
		return true;
	}

	public static bool PortalTo(this ChapterActivityPayload payload, GameManagers managers, Activity from)
	{
		if (!payload.Activity.CanPlay(managers, payload.ChapterId))
		{
			return false;
		}
		if (!payload.IsPortal || !ActivityManager.Activities.TryGetValue(payload.PortalRoute, out var value))
		{
			return false;
		}
		managers.ActivityManager.ActivityDifficultyLevels.GetValue().TryGetValue(payload.Activity.Type.ToString(), out var value2);
		if (value2 < value.DifficultyLevel)
		{
			return false;
		}
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{
				"Type",
				Convert.ToInt32(value.UiParams["Type"])
			},
			{ "Activity", value }
		};
		Contexts.sharedInstance.Service<IUiService>().OpenPanel("UI_InstanceZonesPanel", parameters);
		return true;
	}

	public static bool ShowPortal(this ChapterActivityPayload payload, GameManagers managers)
	{
		if (!payload.IsPortal || !ActivityManager.Activities.TryGetValue(payload.PortalRoute, out var value))
		{
			return false;
		}
		managers.ActivityManager.ActivityMaxDifficultyLevels.GetValue().TryGetValue(payload.Activity.Type.ToString(), out var value2);
		if (value.DifficultyLevel <= value2)
		{
			return true;
		}
		if (payload.AllEnableFiltersPassed(managers))
		{
			return true;
		}
		return false;
	}

	public static bool CanPortal(this ChapterActivityPayload payload, GameManagers managers)
	{
		if (!payload.IsPortal || !ActivityManager.Activities.TryGetValue(payload.PortalRoute, out var value))
		{
			return false;
		}
		managers.ActivityManager.ActivityDifficultyLevels.GetValue().TryGetValue(payload.Activity.Type.ToString(), out var value2);
		return value.DifficultyLevel <= value2;
	}
}
