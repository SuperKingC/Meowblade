using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ShipChangeOrderRequest : IRequestPacket, IPacketBody
{
	private Dictionary<int, string> _Order;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string _jsonOrder { get; set; }

	public Dictionary<int, string> Order
	{
		get
		{
			if (_Order == null && !string.IsNullOrEmpty(_jsonOrder))
			{
				_Order = JsonHelper.ToObject<Dictionary<int, string>>(_jsonOrder);
			}
			return _Order;
		}
		set
		{
			_Order = value;
			_jsonOrder = JsonHelper.ToJson(_Order);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_SHIP_CHANGE_ORDER;
}
