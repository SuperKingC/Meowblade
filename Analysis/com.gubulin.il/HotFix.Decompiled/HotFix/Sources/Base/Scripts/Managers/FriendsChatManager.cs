using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Scripts.Managers;

public class FriendsChatManager : Manager
{
	public List<int> _chatSessionFriends;

	public List<FriendsChatSession> _chatSessions;

	public bool HasAnyUnreadMessage => _chatSessions.Any((FriendsChatSession x) => x.HasUnreadMessage);

	public FriendsChatManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		return null;
	}

	public void LoadData()
	{
		_chatSessions = new List<FriendsChatSession>();
		_chatSessionFriends = GameLocalDataManager.GetObjectData<List<int>>("FriendsChatSessionIdsKey");
		for (int num = _chatSessionFriends.Count - 1; num >= 0; num--)
		{
			int friendId = _chatSessionFriends[num];
			if (FriendsChatSession.TryLoad(friendId, out var session))
			{
				_chatSessions.Add(session);
			}
			else
			{
				_chatSessionFriends.RemoveAt(num);
			}
		}
		ResortSessions();
		SharedMessenger.AddListener<PushItem>("ON_PING_PUSH_ITEM", OnPingPushItem);
		Task<GetUnreadMessageResponse> task = Contexts.sharedInstance.Service<INetworkService>().GetUnreadFriendsChat();
		task.GetAwaiter().OnCompleted(delegate
		{
			GetUnreadMessageResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else if (result.Messages != null)
			{
				result.Messages.Sort(FriendsChatSession.ChatLogComparison);
				foreach (ChatLog message in result.Messages)
				{
					FriendsChatSession chatSession = GetChatSession(message.Sender);
					chatSession.ReceiveMessage(message);
				}
			}
		});
	}

	private void OnPingPushItem(PushItem item)
	{
		if (item.PacketId != PacketIds.PUSH_CHAT)
		{
			return;
		}
		List<ChatLog> list = JsonHelper.ToObject<List<ChatLog>>(item.Body);
		list.Sort(FriendsChatSession.ChatLogComparison);
		foreach (ChatLog item2 in list)
		{
			FriendsChatSession chatSession = GetChatSession(item2.Sender);
			chatSession.ReceiveMessage(item2);
		}
	}

	public void DeleteFriendsChat(int friendsId)
	{
		int num = _chatSessions.FindIndex((FriendsChatSession x) => x.FriendsId == friendsId);
		if (num >= 0)
		{
			FriendsChatSession friendsChatSession = _chatSessions[num];
			friendsChatSession.Delete();
			_chatSessions.RemoveAt(num);
		}
		_chatSessionFriends.Remove(friendsId);
		GameLocalDataManager.SaveObjectDate("FriendsChatSessionIdsKey", _chatSessionFriends);
	}

	public FriendsChatSession GetChatSession(int friendsId)
	{
		foreach (FriendsChatSession chatSession in _chatSessions)
		{
			if (chatSession.FriendsId == friendsId)
			{
				return chatSession;
			}
		}
		return NewSession(friendsId);
	}

	private FriendsChatSession NewSession(int friendId)
	{
		FriendsChatSession friendsChatSession = new FriendsChatSession();
		friendsChatSession.FriendsId = friendId;
		friendsChatSession.ActiveTimeStamp = GameController.Instance.GetServerTime() * 1000;
		_chatSessionFriends.Add(friendId);
		_chatSessions.Add(friendsChatSession);
		GameLocalDataManager.SaveObjectDate("FriendsChatSessionIdsKey", _chatSessionFriends);
		return friendsChatSession;
	}

	public List<FriendsChatSession> GetAll()
	{
		return _chatSessions.ToList();
	}

	public void ResortSessions()
	{
		_chatSessions.Sort((FriendsChatSession a, FriendsChatSession b) => -a.ActiveTimeStamp.CompareTo(b.ActiveTimeStamp));
	}
}
