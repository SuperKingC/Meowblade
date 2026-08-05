using System.Collections;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.UI.LoadWebImage;

public class LoadWebImageTask
{
	private string _taskName;

	public Coroutine Work;

	public IEnumerator MyTask;

	public float DelayTime;

	public string TaskName
	{
		get
		{
			return _taskName;
		}
		set
		{
			_taskName = value;
		}
	}

	public LoadWebImageTask(Coroutine work, string taskName = "defaultTaskName")
	{
		Work = work;
		_taskName = taskName;
	}

	public LoadWebImageTask(IEnumerator work, string taskName = "defaultTaskName", float delayTime = 0f)
	{
		MyTask = work;
		_taskName = taskName;
		DelayTime = delayTime;
	}
}
