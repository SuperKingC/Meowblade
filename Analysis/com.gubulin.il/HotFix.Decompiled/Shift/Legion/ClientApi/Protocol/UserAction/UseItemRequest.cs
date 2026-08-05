using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseItemRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string ItemId;

	[ProtoMember(3)]
	public int Qty;

	[ProtoMember(4)]
	public string _jsonContext;

	private object _context;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public object Context
	{
		get
		{
			if (_context == null && !string.IsNullOrEmpty(_jsonContext))
			{
				_context = JsonHelper.ToObject<object>(_jsonContext);
			}
			return _context;
		}
		set
		{
			_context = value;
			_jsonContext = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_USE_ITEM_REQUEST;
}
