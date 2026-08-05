using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetNeutralInstanceAdInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(2)]
	public string _jsonAdInfo;

	private List<Dictionary<string, string>> _adInfo;

	public List<Dictionary<string, string>> AdInfo
	{
		get
		{
			if (_adInfo == null && !string.IsNullOrEmpty(_jsonAdInfo))
			{
				_adInfo = JsonHelper.ToObject<List<Dictionary<string, string>>>(_jsonAdInfo);
			}
			return _adInfo;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_NEUTRAL_DUNGEON_REQUEST;
}
