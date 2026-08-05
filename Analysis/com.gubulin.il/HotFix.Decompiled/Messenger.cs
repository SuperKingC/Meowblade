using System;
using System.Collections.Generic;
using System.Reflection;

public class Messenger
{
	public class BroadcastException : Exception
	{
		public BroadcastException(string msg)
			: base(msg)
		{
		}
	}

	public class ListenerException : Exception
	{
		public ListenerException(string msg)
			: base(msg)
		{
		}
	}

	public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

	public List<string> permanentMessages = new List<string>();

	public void MarkAsPermanent(string eventType)
	{
		permanentMessages.Add(eventType);
	}

	public void Cleanup()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Delegate> item in eventTable)
		{
			bool flag = false;
			foreach (string permanentMessage in permanentMessages)
			{
				if (item.Key == permanentMessage)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			eventTable.Remove(item2);
		}
	}

	public void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
		if (!eventTable.ContainsKey(eventType))
		{
			eventTable.Add(eventType, null);
		}
	}

	public void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
	{
	}

	public void OnListenerRemoved(string eventType)
	{
		if ((object)eventTable[eventType] == null)
		{
			eventTable.Remove(eventType);
		}
	}

	public void OnBroadcasting(string eventType)
	{
	}

	public BroadcastException CreateBroadcastSignatureException(string eventType)
	{
		return new BroadcastException($"Broadcasting message \"{eventType}\" but listeners have a different signature than the broadcaster.");
	}

	public void AddListener(string eventType, Callback handler)
	{
		OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback)Delegate.Combine((Callback)eventTable[eventType], handler);
	}

	public void AddListener<T>(string eventType, Callback<T> handler)
	{
		OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback<T>)Delegate.Combine((Callback<T>)eventTable[eventType], handler);
	}

	public void AddListener<T, U>(string eventType, Callback<T, U> handler)
	{
		OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback<T, U>)Delegate.Combine((Callback<T, U>)eventTable[eventType], handler);
	}

	public void AddListener<T, U, V>(string eventType, Callback<T, U, V> handler)
	{
		OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback<T, U, V>)Delegate.Combine((Callback<T, U, V>)eventTable[eventType], handler);
	}

	public void AddListener<T, U, V, W>(string eventType, Callback<T, U, V, W> handler)
	{
		OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback<T, U, V, W>)Delegate.Combine((Callback<T, U, V, W>)eventTable[eventType], handler);
	}

	public void RemoveListener(string eventType, Callback handler)
	{
		if (eventTable.ContainsKey(eventType))
		{
			OnListenerRemoving(eventType, handler);
			eventTable[eventType] = (Callback)Delegate.Remove((Callback)eventTable[eventType], handler);
			OnListenerRemoved(eventType);
		}
	}

	public void RemoveListener<T>(string eventType, Callback<T> handler)
	{
		if (eventTable.ContainsKey(eventType))
		{
			OnListenerRemoving(eventType, handler);
			eventTable[eventType] = (Callback<T>)Delegate.Remove((Callback<T>)eventTable[eventType], handler);
			OnListenerRemoved(eventType);
		}
	}

	public void RemoveListener<T, U>(string eventType, Callback<T, U> handler)
	{
		if (eventTable.ContainsKey(eventType))
		{
			OnListenerRemoving(eventType, handler);
			eventTable[eventType] = (Callback<T, U>)Delegate.Remove((Callback<T, U>)eventTable[eventType], handler);
			OnListenerRemoved(eventType);
		}
	}

	public void RemoveListener<T, U, V>(string eventType, Callback<T, U, V> handler)
	{
		if (eventTable.ContainsKey(eventType))
		{
			OnListenerRemoving(eventType, handler);
			eventTable[eventType] = (Callback<T, U, V>)Delegate.Remove((Callback<T, U, V>)eventTable[eventType], handler);
			OnListenerRemoved(eventType);
		}
	}

	public void RemoveListener<T, U, V, W>(string eventType, Callback<T, U, V, W> handler)
	{
		if (eventTable.ContainsKey(eventType))
		{
			OnListenerRemoving(eventType, handler);
			eventTable[eventType] = (Callback<T, U, V, W>)Delegate.Remove((Callback<T, U, V, W>)eventTable[eventType], handler);
			OnListenerRemoved(eventType);
		}
	}

	public void Broadcast(string eventType)
	{
		OnBroadcasting(eventType);
		if (eventTable.TryGetValue(eventType, out var value))
		{
			Delegate[] invocationList = value.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object target = invocationList[i].Target;
				MethodInfo method = invocationList[i].Method;
				method.Invoke(target, new object[0]);
			}
		}
	}

	public void Broadcast<T>(string eventType, T arg1)
	{
		OnBroadcasting(eventType);
		if (eventTable.TryGetValue(eventType, out var value))
		{
			Delegate[] invocationList = value.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object target = invocationList[i].Target;
				MethodInfo method = invocationList[i].Method;
				method.Invoke(target, new object[1] { arg1 });
			}
		}
	}

	public void Broadcast<T, U>(string eventType, T arg1, U arg2)
	{
		OnBroadcasting(eventType);
		if (eventTable.TryGetValue(eventType, out var value))
		{
			Delegate[] invocationList = value.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object target = invocationList[i].Target;
				MethodInfo method = invocationList[i].Method;
				method.Invoke(target, new object[2] { arg1, arg2 });
			}
		}
	}

	public void Broadcast<T, U, V>(string eventType, T arg1, U arg2, V arg3)
	{
		OnBroadcasting(eventType);
		if (eventTable.TryGetValue(eventType, out var value))
		{
			Delegate[] invocationList = value.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object target = invocationList[i].Target;
				MethodInfo method = invocationList[i].Method;
				method.Invoke(target, new object[3] { arg1, arg2, arg3 });
			}
		}
	}

	public void Broadcast<T, U, V, W>(string eventType, T arg1, U arg2, V arg3, W arg4)
	{
		OnBroadcasting(eventType);
		if (eventTable.TryGetValue(eventType, out var value))
		{
			Delegate[] invocationList = value.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				object target = invocationList[i].Target;
				MethodInfo method = invocationList[i].Method;
				method.Invoke(target, new object[4] { arg1, arg2, arg3, arg4 });
			}
		}
	}
}
