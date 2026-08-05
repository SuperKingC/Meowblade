using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeWorkshopProduceConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string BuildingType;

	[ProtoMember(3)]
	public string _pbWorkers;

	private Dictionary<int, int> _workers;

	[ProtoMember(4)]
	public string _pbProducts;

	private Dictionary<int, List<string>> _products;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public Dictionary<int, int> Workers
	{
		get
		{
			if (_pbWorkers == null)
			{
				return null;
			}
			return _workers ?? (_workers = JsonHelper.ToObject<Dictionary<int, int>>(_pbWorkers));
		}
		set
		{
			_workers = value;
			_pbWorkers = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, List<string>> Products
	{
		get
		{
			if (_pbProducts == null)
			{
				return null;
			}
			return _products ?? (_products = JsonHelper.ToObject<Dictionary<int, List<string>>>(_pbProducts));
		}
		set
		{
			_products = value;
			_pbProducts = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_CHANGE_WORKSHOP_PRODUCE_CONFIG_REQUEST;
}
