using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetNeutralInstanceResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	public string Message;

	[ProtoMember(4)]
	public string _jsonNeutralInstanceActivityData;

	private Dictionary<string, object> _neutralInstanceActivityData;

	public Dictionary<string, object> NeutralInstanceActivityData
	{
		get
		{
			if (_neutralInstanceActivityData == null && !string.IsNullOrEmpty(_jsonNeutralInstanceActivityData))
			{
				_neutralInstanceActivityData = JsonHelper.ToObject<Dictionary<string, object>>(_jsonNeutralInstanceActivityData);
			}
			return _neutralInstanceActivityData;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_NEUTRAL_DUNGEON_REQUEST;
}
