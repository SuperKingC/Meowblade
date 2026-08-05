using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Models;

public class FriendsChatSession
{
	private const int MaxSaveCount = 1000;

	public int FriendsId;

	public long ActiveTimeStamp;

	public List<ChatLog> ChatLogs = new List<ChatLog>();

	public bool HasUnreadMessage;

	public async void ReadMessage()
	{
		if (!HasUnreadMessage)
		{
			return;
		}
		Task<ReadMessageResponse> task = Contexts.sharedInstance.Service<INetworkService>().ReadFriendsChat(FriendsId);
		HasUnreadMessage = false;
		GameManagers.Instance.Messenger.Broadcast("FRIENDS_CHAT_SESSION_UPDATE", this);
		await task;
		ReadMessageResponse result = task.Result;
		if (result.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return;
		}
		foreach (ChatLog chatLog in ChatLogs)
		{
			if (chatLog.Sender == FriendsId)
			{
				chatLog.MsgStatus = 2;
			}
		}
		Save();
	}

	public void ReceiveMessage(ChatLog message)
	{
		foreach (ChatLog chatLog in ChatLogs)
		{
			if (chatLog.Guid == message.Guid)
			{
				return;
			}
		}
		HasUnreadMessage = true;
		ChatLogs.Add(message);
		if (ChatLogs.Count > 1000)
		{
			ChatLogs.RemoveAt(0);
		}
		ActiveTimeStamp = message.Timestamp;
		Save();
		GameManagers.Instance.Messenger.Broadcast("FRIENDS_CHAT_SESSION_UPDATE", this);
	}

	public async void SendMessage(string message)
	{
		Task<SendChatResponse> tasks = Contexts.sharedInstance.Service<INetworkService>().SendFriendsChat(FriendsId, message);
		await tasks;
		SendChatResponse result = tasks.Result;
		if (result.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return;
		}
		ChatLogs.Add(result.Chat);
		ActiveTimeStamp = result.Chat.Timestamp;
		Save();
		GameManagers.Instance.Messenger.Broadcast("FRIENDS_CHAT_SESSION_UPDATE", this);
	}

	public bool IsEmpty()
	{
		return ChatLogs.Count <= 0;
	}

	public void Delete()
	{
		string friendsChatSessionSaveKey = GameLocalDataManager.GetFriendsChatSessionSaveKey(FriendsId);
		GameLocalDataManager.DeleteKey(friendsChatSessionSaveKey);
	}

	private void Save()
	{
		string friendsChatSessionSaveKey = GameLocalDataManager.GetFriendsChatSessionSaveKey(FriendsId);
		string value = JsonHelper.ToJson(this);
		GameLocalDataManager.SetString(friendsChatSessionSaveKey, value);
	}

	public static bool TryLoad(int friendId, out FriendsChatSession session)
	{
		session = null;
		string friendsChatSessionSaveKey = GameLocalDataManager.GetFriendsChatSessionSaveKey(friendId);
		string text = GameLocalDataManager.GetString(friendsChatSessionSaveKey);
		try
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				session = JsonHelper.ToObject<FriendsChatSession>(text);
				session.ChatLogs.Sort(ChatLogComparison);
			}
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("TryLoad FriendsChatSession Failed: " + ex.Message);
		}
		return session != null;
	}

	public static int ChatLogComparison(ChatLog a, ChatLog b)
	{
		return a.Timestamp.CompareTo(b.Timestamp);
	}
}
