using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class StoryScript
{
	public class BackgroundParam
	{
		public float Opacity;

		public string Image;
	}

	public const string ScriptTypeIndex = "Index";

	public const string ScriptTypeDialog = "Dialog";

	public const string ScriptTypeAnimation = "Animation";

	public const string ScriptTypeBackground = "Background";

	public const string ScriptTypeWaiting = "Waiting";

	public const string ScriptTypeSwitchScene = "SwitchScene";

	public const string ScriptTypeClearDialog = "ClearDialog";

	public const string EffectAlignCenter = "AlignCenter";

	public const string EffectShake = "Shake";

	public const string EffectLordAppear = "LordAppear";

	public List<GDEStoryScriptData> scriptDatas;

	public List<Dictionary<string, object>> formattedScriptList;

	public Dictionary<string, List<string>> roleIndex;

	private static Dictionary<string, StoryScript> _storyScripts;

	private static Dictionary<string, List<GDEStoryScriptData>> _StoryCache;

	public static Dictionary<string, List<GDEStoryScriptData>> StoryCache
	{
		get
		{
			if (_StoryCache == null)
			{
				IEnumerable<GDEStoryScriptData> allItems = GDMgr.GetAllItems<GDEStoryScriptData>();
				_StoryCache = new Dictionary<string, List<GDEStoryScriptData>>();
				foreach (GDEStoryScriptData item in allItems)
				{
					if (!_StoryCache.ContainsKey(item.StoryScriptId))
					{
						_StoryCache.Add(item.StoryScriptId, new List<GDEStoryScriptData>());
					}
					_StoryCache[item.StoryScriptId].Add(item);
				}
			}
			return _StoryCache;
		}
	}

	private StoryScript(string scriptId, List<GDEStoryScriptData> _scriptDatas)
	{
		formattedScriptList = new List<Dictionary<string, object>>();
		scriptDatas = _scriptDatas;
		for (int i = 0; i < scriptDatas.Count; i++)
		{
			Dictionary<string, object> dictionary = null;
			GDEStoryScriptData gDEStoryScriptData = scriptDatas[i];
			switch (gDEStoryScriptData.ScriptType)
			{
			case "Index":
				FormatRoleIndex(gDEStoryScriptData);
				break;
			case "Dialog":
				dictionary = FormatDialogConfig(gDEStoryScriptData);
				break;
			case "Background":
				dictionary = FormatBackgroundConfig(gDEStoryScriptData);
				break;
			case "Waiting":
				dictionary = FormatWaitingConfig(gDEStoryScriptData);
				break;
			case "SwitchScene":
				dictionary = FormatSwitchSceneConfig(gDEStoryScriptData);
				break;
			case "ClearDialog":
				dictionary = FormatClearDialogConfig(gDEStoryScriptData);
				break;
			}
			if (dictionary != null)
			{
				dictionary.Add("Effects", gDEStoryScriptData.Effects);
				formattedScriptList.Add(dictionary);
			}
		}
	}

	public static StoryScript Get(string scriptId)
	{
		if (_storyScripts == null)
		{
			_storyScripts = new Dictionary<string, StoryScript>();
		}
		if (!StoryCache.ContainsKey(scriptId))
		{
			ILRuntimeDebug.LogError("Error! HasNotThisScriptId , StoryScript Get scriptId = {0}", scriptId);
			return null;
		}
		if (!_storyScripts.ContainsKey(scriptId))
		{
			_storyScripts.Add(scriptId, new StoryScript(scriptId, StoryCache[scriptId]));
		}
		return _storyScripts[scriptId];
	}

	private Dictionary<string, List<string>> FormatRoleIndex(GDEStoryScriptData data)
	{
		roleIndex = new Dictionary<string, List<string>>();
		Dictionary<string, Dictionary<string, string>> dictionary = JsonHelper.ToObject<Dictionary<string, Dictionary<string, string>>>(data.Payload);
		foreach (KeyValuePair<string, Dictionary<string, string>> item in dictionary)
		{
			foreach (KeyValuePair<string, string> item2 in item.Value)
			{
				roleIndex.Add(item2.Key, new List<string> { item.Key, item2.Value });
			}
		}
		return roleIndex;
	}

	private Dictionary<string, object> FormatDialogConfig(GDEStoryScriptData data)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "Type", "Dialog" } };
		int num = data.Payload.IndexOf("ui:", StringComparison.OrdinalIgnoreCase);
		int num2 = data.Payload.IndexOf(':');
		if (num + 2 == num2)
		{
			num2 = -1;
		}
		if (num2 < 0)
		{
			dictionary.Add("Content", data.Payload);
			return dictionary;
		}
		string text = data.Payload.Substring(0, num2);
		string value = data.Payload.Substring(num2 + 1);
		dictionary.Add("Name", text);
		dictionary.Add("Content", value);
		if (roleIndex.ContainsKey(text))
		{
			dictionary.Add(roleIndex[text][0], roleIndex[text][1]);
		}
		return dictionary;
	}

	private Dictionary<string, object> FormatBackgroundConfig(GDEStoryScriptData data)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "Type", "Background" } };
		BackgroundParam backgroundParam = JsonHelper.ToObject<BackgroundParam>(data.Payload);
		dictionary.Add("Opacity", backgroundParam.Opacity);
		if (!string.IsNullOrEmpty(backgroundParam.Image))
		{
			dictionary.Add("Image", backgroundParam.Image);
		}
		return dictionary;
	}

	private Dictionary<string, object> FormatWaitingConfig(GDEStoryScriptData data)
	{
		return new Dictionary<string, object>
		{
			{ "Type", "Waiting" },
			{ "Timeout", data.Payload }
		};
	}

	private Dictionary<string, object> FormatSwitchSceneConfig(GDEStoryScriptData data)
	{
		return new Dictionary<string, object>
		{
			{ "Type", "SwitchScene" },
			{ "Scene", data.Payload }
		};
	}

	private Dictionary<string, object> FormatClearDialogConfig(GDEStoryScriptData data)
	{
		return new Dictionary<string, object> { { "Type", "ClearDialog" } };
	}
}
