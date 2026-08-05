using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class GetFriendsResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string _jsonFriends;

	private List<UserInfo> _friends;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<UserInfo> Friends
	{
		get
		{
			if (_friends == null && !string.IsNullOrEmpty(_jsonFriends))
			{
				_friends = JsonHelper.ToObject<List<UserInfo>>(_jsonFriends);
			}
			return _friends;
		}
		set
		{
			_friends = value;
			_jsonFriends = JsonHelper.ToJson(_friends);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_FRIENDS;
}
