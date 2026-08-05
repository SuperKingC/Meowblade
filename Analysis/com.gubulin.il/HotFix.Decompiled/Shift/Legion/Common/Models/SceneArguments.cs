using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.Common.Enums;

namespace Shift.Legion.Common.Models;

public class SceneArguments
{
	public const string AssetKey = "Asset";

	public const string ForceCloseOtherUiKey = "ForceCloseOtherUi";

	public const string TaskCompletionSourceKey = "TaskCompletionSource";

	public const string LoadingShowAllSoldierKey = "LoadingShowAllSoldier";

	public const string LoadingAnimationDirectionKey = "LoadingAnimationDirection";

	public const string OpenUiOnReturnKey = "OpenUiOnReturn";

	public const string UiParamsOnReturnKey = "UiParamsOnReturn";

	public const string OpenUiOnEnterKey = "OpenUiOnEnter";

	public const string UiParamsOnEnterKey = "UiParamsOnEnter";

	public const string WorldMapBtnVisibleKey = "WorldMapBtnVisible";

	public const string SHOW_LEVEL_STRATEGY_REMINDER = "SHOW_LEVEL_STRATEGY_REMINDER";

	public const string ContextTagsKey = "ContextTags";

	public const string LoadedCallbackKey = "LoadedCallback";

	public const string TimeLineMainCityKey = "TimeLineMainCity";

	public Dictionary<string, object> Data;

	public string Asset
	{
		get
		{
			if (Data.TryGetValue("Asset", out var value))
			{
				return (string)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("Asset"))
			{
				Data["Asset"] = value;
			}
			else
			{
				Data.Add("Asset", value);
			}
		}
	}

	public bool ForceCloseOtherUi
	{
		get
		{
			if (Data.TryGetValue("ForceCloseOtherUi", out var value))
			{
				return (bool)value;
			}
			return false;
		}
		set
		{
			bool flag = value;
			if (Data.ContainsKey("ForceCloseOtherUi"))
			{
				Data["ForceCloseOtherUi"] = flag;
			}
			else
			{
				Data.Add("ForceCloseOtherUi", flag);
			}
		}
	}

	public string TimeLineMainCity
	{
		get
		{
			if (Data.TryGetValue("TimeLineMainCity", out var value))
			{
				return (string)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("TimeLineMainCity"))
			{
				Data["TimeLineMainCity"] = value;
			}
			else
			{
				Data.Add("TimeLineMainCity", value);
			}
		}
	}

	public bool LoadingShowAllSoldier
	{
		get
		{
			if (Data.TryGetValue("LoadingShowAllSoldier", out var value))
			{
				return (bool)value;
			}
			return false;
		}
		set
		{
			bool flag = value;
			if (Data.ContainsKey("LoadingShowAllSoldier"))
			{
				Data["LoadingShowAllSoldier"] = flag;
			}
			else
			{
				Data.Add("LoadingShowAllSoldier", flag);
			}
		}
	}

	public LoadingAnimationDirection LoadingAnimationDirection
	{
		get
		{
			if (Data.TryGetValue("LoadingAnimationDirection", out var value))
			{
				return (LoadingAnimationDirection)value;
			}
			return LoadingAnimationDirection.Right;
		}
		set
		{
			LoadingAnimationDirection loadingAnimationDirection = value;
			if (Data.ContainsKey("LoadingAnimationDirection"))
			{
				Data["LoadingAnimationDirection"] = loadingAnimationDirection;
			}
			else
			{
				Data.Add("LoadingAnimationDirection", loadingAnimationDirection);
			}
		}
	}

	public TaskCompletionSource<bool> TaskCompletionSource
	{
		get
		{
			if (Data.TryGetValue("TaskCompletionSource", out var value))
			{
				return (TaskCompletionSource<bool>)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("TaskCompletionSource"))
			{
				Data["TaskCompletionSource"] = value;
			}
			else
			{
				Data.Add("TaskCompletionSource", value);
			}
		}
	}

	public bool ShowLevelStrategyReminder
	{
		get
		{
			object value;
			return Data.TryGetValue("SHOW_LEVEL_STRATEGY_REMINDER", out value) && (bool)value;
		}
		set
		{
			Data["SHOW_LEVEL_STRATEGY_REMINDER"] = value;
		}
	}

	public string OpenUiOnReturn
	{
		get
		{
			if (Data.TryGetValue("OpenUiOnReturn", out var value))
			{
				return (string)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("OpenUiOnReturn"))
			{
				Data["OpenUiOnReturn"] = value;
			}
			else
			{
				Data.Add("OpenUiOnReturn", value);
			}
		}
	}

	public Dictionary<string, object> UiParamsOnReturn
	{
		get
		{
			if (Data.TryGetValue("UiParamsOnReturn", out var value))
			{
				return (Dictionary<string, object>)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("UiParamsOnReturn"))
			{
				Data["UiParamsOnReturn"] = value;
			}
			else
			{
				Data.Add("UiParamsOnReturn", value);
			}
		}
	}

	public string OpenUiOnEnter
	{
		get
		{
			if (Data.TryGetValue("OpenUiOnEnter", out var value))
			{
				return (string)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("OpenUiOnEnter"))
			{
				Data["OpenUiOnEnter"] = value;
			}
			else
			{
				Data.Add("OpenUiOnEnter", value);
			}
		}
	}

	public Dictionary<string, object> UiParamsOnEnter
	{
		get
		{
			if (Data.TryGetValue("UiParamsOnEnter", out var value))
			{
				return (Dictionary<string, object>)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("UiParamsOnEnter"))
			{
				Data["UiParamsOnEnter"] = value;
			}
			else
			{
				Data.Add("UiParamsOnEnter", value);
			}
		}
	}

	public bool WorldMapBtnVisible
	{
		get
		{
			if (Data.TryGetValue("WorldMapBtnVisible", out var value))
			{
				return (bool)value;
			}
			return false;
		}
		set
		{
			bool flag = value;
			if (Data.ContainsKey("WorldMapBtnVisible"))
			{
				Data["WorldMapBtnVisible"] = flag;
			}
			else
			{
				Data.Add("WorldMapBtnVisible", flag);
			}
		}
	}

	public List<string> ContextTags
	{
		get
		{
			if (Data.TryGetValue("ContextTags", out var value))
			{
				return (List<string>)value;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("ContextTags"))
			{
				Data["ContextTags"] = value;
			}
			else
			{
				Data.Add("ContextTags", value);
			}
		}
	}

	public Action<string> LoadedCallback
	{
		get
		{
			if (Data.TryGetValue("LoadedCallback", out var value))
			{
				return value as Action<string>;
			}
			return null;
		}
		set
		{
			if (Data.ContainsKey("LoadedCallback"))
			{
				Data["LoadedCallback"] = value;
			}
			else
			{
				Data.Add("LoadedCallback", value);
			}
		}
	}

	public SceneArguments(Dictionary<string, object> dic)
	{
		if (Data == null)
		{
			Data = new Dictionary<string, object>();
		}
		Data = dic;
	}
}
