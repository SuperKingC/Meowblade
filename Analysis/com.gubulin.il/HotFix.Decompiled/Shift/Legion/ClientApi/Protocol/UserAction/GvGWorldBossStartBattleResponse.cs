using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBossStartBattleResponse : IPacketBody
{
	private Dictionary<string, int> _Cost;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string _jsonCost { get; set; }

	public Dictionary<string, int> Cost
	{
		get
		{
			if (_jsonCost == null)
			{
				return null;
			}
			return _Cost ?? (_Cost = JsonHelper.ToObject<Dictionary<string, int>>(_jsonCost));
		}
		set
		{
			_Cost = value;
			_jsonCost = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GVG_WORLDBOSS_START_BATTLE;
}
