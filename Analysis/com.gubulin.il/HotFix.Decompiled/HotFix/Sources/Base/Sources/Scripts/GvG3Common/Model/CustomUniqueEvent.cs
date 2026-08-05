using System;
using System.Collections.Generic;
using System.Linq;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class CustomUniqueEvent
{
	private HashSet<Action> eventHandlers = new HashSet<Action>();

	private List<Action> eventHandlersList = null;

	public bool IsEmpty => eventHandlers.Count == 0;

	public void AddListener(Action handler)
	{
		if (handler == null)
		{
			throw new Exception("[CustomEvent] the parameter 'handler' cannot be null");
		}
		eventHandlers.Add(handler);
		eventHandlersList = null;
	}

	public void RemoveListener(Action handler)
	{
		eventHandlers.Remove(handler);
		eventHandlersList = null;
	}

	public void Invoke()
	{
		if (eventHandlersList == null)
		{
			eventHandlersList = eventHandlers.ToList();
		}
		foreach (Action eventHandlers in eventHandlersList)
		{
			eventHandlers();
		}
	}

	public void Clear()
	{
		eventHandlers.Clear();
		eventHandlersList = null;
	}
}
public class CustomUniqueEvent<T>
{
	private HashSet<Action<T>> eventHandlers = new HashSet<Action<T>>();

	private List<Action<T>> eventHandlersList = null;

	public bool IsEmpty => eventHandlers.Count == 0;

	public void AddListener(Action<T> handler)
	{
		if (handler == null)
		{
			throw new Exception("[CustomEvent] the parameter 'handler' cannot be null");
		}
		eventHandlers.Add(handler);
		eventHandlersList = null;
	}

	public void RemoveListener(Action<T> handler)
	{
		eventHandlers.Remove(handler);
		eventHandlersList = null;
	}

	public void Invoke(T p1)
	{
		if (IsEmpty)
		{
			return;
		}
		if (eventHandlersList == null)
		{
			eventHandlersList = eventHandlers.ToList();
		}
		foreach (Action<T> eventHandlers in eventHandlersList)
		{
			eventHandlers(p1);
		}
	}

	public void Clear()
	{
		eventHandlers.Clear();
		eventHandlersList = null;
	}
}
