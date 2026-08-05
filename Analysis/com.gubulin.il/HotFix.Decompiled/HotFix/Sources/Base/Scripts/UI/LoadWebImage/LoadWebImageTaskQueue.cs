using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.UI.LoadWebImage;

public class LoadWebImageTaskQueue
{
	public Action OnStart = null;

	public Action OnFinish = null;

	private int m_TasksNum = 0;

	private Queue<LoadWebImageTask> m_TaskQueue;

	private Coroutine CurTaskCoroutine;

	public float TaskProcess => 1f - (float)m_TaskQueue.Count * 1f / (float)m_TasksNum;

	public LoadWebImageTaskQueue()
	{
		m_TaskQueue = new Queue<LoadWebImageTask>();
		m_TasksNum = 0;
	}

	public void AddTask(LoadWebImageTask task)
	{
		m_TaskQueue.Enqueue(task);
	}

	public void AddTask(Coroutine work)
	{
		LoadWebImageTask item = new LoadWebImageTask(work);
		m_TaskQueue.Enqueue(item);
	}

	public void AddTask(IEnumerator work, float delayTime = 0f)
	{
		LoadWebImageTask item = new LoadWebImageTask(work, "defaultTaskName", delayTime);
		m_TaskQueue.Enqueue(item);
	}

	public void Start()
	{
		m_TasksNum = m_TaskQueue.Count;
		if (OnStart != null)
		{
			OnStart();
		}
		if (CurTaskCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(CurTaskCoroutine);
			CurTaskCoroutine = null;
		}
		CurTaskCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(NextTask());
	}

	public void Clear()
	{
		if (CurTaskCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(CurTaskCoroutine);
			CurTaskCoroutine = null;
		}
		m_TaskQueue.Clear();
		m_TasksNum = 0;
	}

	private IEnumerator NextTask()
	{
		if (m_TaskQueue.Count > 0)
		{
			LoadWebImageTask task = m_TaskQueue.Dequeue();
			if (task.Work != null)
			{
				yield return task.Work;
			}
			if (task.MyTask != null)
			{
				if (task.DelayTime <= float.Epsilon)
				{
					yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(task.MyTask);
				}
				else
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(task.MyTask);
					yield return (object)new WaitForSeconds(task.DelayTime);
				}
			}
			CurTaskCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(NextTask());
			yield return CurTaskCoroutine;
		}
		else
		{
			if (OnFinish != null)
			{
				OnFinish();
			}
			yield return null;
		}
	}
}
