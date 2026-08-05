using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeCampProduceConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string _pbConfig;

	private Dictionary<int, string> _config;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public Dictionary<int, string> Config
	{
		get
		{
			if (_pbConfig == null)
			{
				return null;
			}
			return _config ?? (_config = JsonHelper.ToObject<Dictionary<int, string>>(_pbConfig));
		}
		set
		{
			_config = value;
			_pbConfig = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_CHANGE_CAMP_PRODUCE_CONFIG_REQUEST;
}
