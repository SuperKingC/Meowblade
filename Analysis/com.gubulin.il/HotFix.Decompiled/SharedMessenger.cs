using System;

public static class SharedMessenger
{
	public static readonly Messenger messengerInstance = new Messenger();

	public static void Cleanup()
	{
		messengerInstance.Cleanup();
	}

	public static void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
		messengerInstance.OnListenerAdding(eventType, listenerBeingAdded);
	}

	public static void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
	{
		messengerInstance.OnListenerRemoving(eventType, listenerBeingRemoved);
	}

	public static void OnListenerRemoved(string eventType)
	{
		messengerInstance.OnListenerRemoved(eventType);
	}

	public static void OnBroadcasting(string eventType)
	{
		messengerInstance.OnBroadcasting(eventType);
	}

	public static Messenger.BroadcastException CreateBroadcastSignatureException(string eventType)
	{
		return messengerInstance.CreateBroadcastSignatureException(eventType);
	}

	public static void AddListener(string eventType, Callback handler)
	{
		messengerInstance.AddListener(eventType, handler);
	}

	public static void AddListener<T>(string eventType, Callback<T> handler)
	{
		messengerInstance.AddListener(eventType, handler);
	}

	public static void AddListener<T, U>(string eventType, Callback<T, U> handler)
	{
		messengerInstance.AddListener(eventType, handler);
	}

	public static void AddListener<T, U, V>(string eventType, Callback<T, U, V> handler)
	{
		messengerInstance.AddListener(eventType, handler);
	}

	public static void AddListener<T, U, V, W>(string eventType, Callback<T, U, V, W> handler)
	{
		messengerInstance.AddListener(eventType, handler);
	}

	public static void RemoveListener(string eventType, Callback handler)
	{
		try
		{
			messengerInstance.RemoveListener(eventType, handler);
		}
		catch (Exception)
		{
		}
	}

	public static void RemoveListener<T>(string eventType, Callback<T> handler)
	{
		try
		{
			messengerInstance.RemoveListener(eventType, handler);
		}
		catch (Exception)
		{
		}
	}

	public static void RemoveListener<T, U>(string eventType, Callback<T, U> handler)
	{
		try
		{
			messengerInstance.RemoveListener(eventType, handler);
		}
		catch (Exception)
		{
		}
	}

	public static void RemoveListener<T, U, V>(string eventType, Callback<T, U, V> handler)
	{
		try
		{
			messengerInstance.RemoveListener(eventType, handler);
		}
		catch (Exception)
		{
		}
	}

	public static void RemoveListener<T, U, V, W>(string eventType, Callback<T, U, V, W> handler)
	{
		try
		{
			messengerInstance.RemoveListener(eventType, handler);
		}
		catch (Exception)
		{
		}
	}

	public static void Broadcast(string eventType)
	{
		messengerInstance.Broadcast(eventType);
	}

	public static void Broadcast<T>(string eventType, T arg1)
	{
		messengerInstance.Broadcast(eventType, arg1);
	}

	public static void Broadcast<T, U>(string eventType, T arg1, U arg2)
	{
		messengerInstance.Broadcast(eventType, arg1, arg2);
	}

	public static void Broadcast<T, U, V>(string eventType, T arg1, U arg2, V arg3)
	{
		messengerInstance.Broadcast(eventType, arg1, arg2, arg3);
	}

	public static void Broadcast<T, U, V, W>(string eventType, T arg1, U arg2, V arg3, W arg4)
	{
		messengerInstance.Broadcast(eventType, arg1, arg2, arg3, arg4);
	}
}
