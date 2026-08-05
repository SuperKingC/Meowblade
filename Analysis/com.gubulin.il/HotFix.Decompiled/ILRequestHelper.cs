using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public static class ILRequestHelper
{
	public class WaitingAnimParam
	{
		public float Delay;

		public IUiService Service;

		public object Task;
	}

	public static Func<IUiService> GetUiService;

	public static Action<WaitingAnimParam> ShowWaitingAnimationWithDelay;

	public static void ShowMessage(string message)
	{
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { message }, 1, arg3: false);
	}

	public static void ShowErrorCode(int ErrorCode)
	{
		if (ErrorCode != 0)
		{
			string errorMessage = LanguagesManager.GetErrorMessage(ErrorCode);
			SentrySdk.AddBreadcrumb("[ShowErrorCode] " + errorMessage);
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errorMessage }, 1, arg3: false);
		}
	}

	public static void ShowErrorCodeAndData(int ErrorCode, object[] _data)
	{
		string errorDesc = LanguagesManager.GetErrorDesc("ErrorCode_" + ErrorCode, _data);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errorDesc }, 1, arg3: false);
	}
}
public static class ILRequestHelper<T>
{
	public static void Request(EventContext eventContext, Func<Task<T>> requestCallback, Action<T> completedCallback)
	{
		Request(eventContext?.data as CustomTaskCompletionSource<bool>, requestCallback, completedCallback);
	}

	public static void Request(CustomTaskCompletionSource<bool> taskCompletionSource, Func<Task<T>> requestCallback, Action<T> completedCallback, float showWaitingAfterTime = 1f)
	{
		IUiService uiService = ILRequestHelper.GetUiService?.Invoke();
		int changeId = 0;
		if (uiService != null)
		{
			changeId = uiService.SetUiNotTouchable(null);
		}
		if (taskCompletionSource != null)
		{
			taskCompletionSource.IsAsync = true;
		}
		Task<T> task = requestCallback();
		if (showWaitingAfterTime >= 0f && uiService != null)
		{
			ILRequestHelper.ShowWaitingAnimationWithDelay(new ILRequestHelper.WaitingAnimParam
			{
				Delay = showWaitingAfterTime,
				Service = uiService,
				Task = task
			});
		}
		task.GetAwaiter().OnCompleted(delegate
		{
			if (uiService != null)
			{
				uiService.ShowWaitingAnimation(show: false);
				uiService.SetUiTouchable(changeId);
			}
			taskCompletionSource?.TrySetResult(result: true);
			T result = task.Result;
			completedCallback(result);
		});
	}

	public static async Task RequestAsync(CustomTaskCompletionSource<bool> taskCompletionSource, Func<Task<T>> requestCallback, Action<T> completedCallback, float showWaitingAfterTime = 1f)
	{
		IUiService uiService = ILRequestHelper.GetUiService?.Invoke();
		int changeId = 0;
		if (uiService != null)
		{
			changeId = uiService.SetUiNotTouchable(null);
		}
		if (taskCompletionSource != null)
		{
			taskCompletionSource.IsAsync = true;
		}
		Task<T> task = requestCallback();
		if (showWaitingAfterTime >= 0f && uiService != null)
		{
			ILRequestHelper.ShowWaitingAnimationWithDelay(new ILRequestHelper.WaitingAnimParam
			{
				Delay = showWaitingAfterTime,
				Service = uiService,
				Task = task
			});
		}
		T response = await task;
		if (uiService != null)
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		taskCompletionSource?.TrySetResult(result: true);
		completedCallback(response);
	}
}
