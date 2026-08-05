using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Legion.Common.Managers;

public class CustomScriptManager : Manager
{
	private List<TaskCompletionSource<bool>> _pendingTaskDictionary;

	private List<TaskCompletionSource<bool>> PendingTaskDictionary
	{
		get
		{
			if (_pendingTaskDictionary == null)
			{
				_pendingTaskDictionary = new List<TaskCompletionSource<bool>>();
			}
			return _pendingTaskDictionary;
		}
		set
		{
			_pendingTaskDictionary = value;
		}
	}

	public CustomScriptManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<TaskCompletionSource<bool>, bool>("CUSTOM_ACTION_FINISH", OnActionFinish);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<TaskCompletionSource<bool>, bool>("CUSTOM_ACTION_FINISH", OnActionFinish);
	}

	private void OnActionFinish(TaskCompletionSource<bool> taskCompletionSource, bool shouldContinue)
	{
		if (PendingTaskDictionary.Remove(taskCompletionSource))
		{
			taskCompletionSource.TrySetResult(shouldContinue);
		}
	}

	public void AddPendingAction(TaskCompletionSource<bool> taskCompletionSource)
	{
		if (!PendingTaskDictionary.Contains(taskCompletionSource))
		{
			PendingTaskDictionary.Add(taskCompletionSource);
		}
	}
}
