using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameMaths;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Technology;

namespace Shift.Legion.Common.Models;

public class TimeoutActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "Timeout";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		if (!string.IsNullOrEmpty(actionPayload))
		{
			taskCompletionSource.IsAsync = true;
			if (actionPayload.Contains(":"))
			{
				Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(actionPayload);
				object value3;
				if (dictionary.TryGetValue("Until", out var value))
				{
					dictionary.Remove("Until");
					string triggerId = managers.TriggerManager.CreateTrigger(value?.ToString() + ":" + JsonHelper.ToJson(dictionary));
					managers.TriggerManager.SetCallback(triggerId, delegate
					{
						taskCompletionSource.TrySetResult(result: true);
					});
					managers.TriggerManager.SetupTrigger(triggerId);
					if (value.ToString() == "OnBuildingConstructingComplete")
					{
						string json = JsonHelper.ToJson(dictionary);
						Dictionary<string, string> dictionary2 = JsonHelper.ToObject<Dictionary<string, string>>(json);
						if (dictionary2.TryGetValue("BuildingType", out var value2) && (GameManagers.Instance.UserArchiveManager.GetBuildingLevel(value2) > 0 || GameManagers.Instance.UserArchiveManager.GetBuildingStatus(value2) == BuildingStatus.Ready || GameManagers.Instance.UserArchiveManager.GetBuildingStatus(value2) == BuildingStatus.Running))
						{
							taskCompletionSource.TrySetResult(result: true);
						}
					}
				}
				else if (dictionary.TryGetValue("Tag", out value3))
				{
					WaitingTag(value3, taskCompletionSource);
				}
				else
				{
					taskCompletionSource.TrySetResult(result: true);
				}
			}
			else
			{
				if (!NumericParser.TryFloat(actionPayload, out var value4))
				{
					taskCompletionSource.TrySetResult(result: true);
				}
				Task.Delay(Mathf.CeilToInt(value4 * 1000f)).GetAwaiter().OnCompleted(delegate
				{
					taskCompletionSource.TrySetResult(result: true);
				});
			}
		}
		return null;
	}

	private async void WaitingTag(object tag, CustomTaskCompletionSource<bool> taskCompletionSource)
	{
		int time = 0;
		bool found = false;
		string tagName = tag.ToString();
		for (int waitTimes = CalcWaitingTimes(tagName); time <= waitTimes; time++)
		{
			if (UiTagManager.Instance.FindObjectByTag(tagName) != null)
			{
				found = true;
				break;
			}
			await Task.Delay(100);
		}
		if (!found)
		{
			OnFoundFail(tagName);
		}
		taskCompletionSource.SetResult(result: true);
	}

	private static int CalcWaitingTimes(string tagName)
	{
		if (tagName == "MaterialIntroductionPanel.ProduceBtn")
		{
			return 20;
		}
		return 200;
	}

	private static void OnFoundFail(string tagName)
	{
		if (tagName == "MaterialIntroductionPanel.ProduceBtn")
		{
			string triggerId = GameManagers.Instance.TriggerManager.CreateTrigger("OnMainCityComUnlocked:" + JsonHelper.ToJson(new Dictionary<string, object> { { "Component", "MainCity.TechnologyBtn" } }));
			GameManagers.Instance.TriggerManager.SetCallback(triggerId, delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Technology.Name, new Dictionary<string, object> { { "TechId", "H001" } });
			});
			GameManagers.Instance.TriggerManager.SetupTrigger(triggerId);
		}
	}
}
