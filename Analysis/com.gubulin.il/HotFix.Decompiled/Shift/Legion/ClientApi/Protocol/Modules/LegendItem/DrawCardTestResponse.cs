using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class DrawCardTestResponse : IPacketBody
{
	[ProtoMember(5)]
	public string _jsonStatsByItemId;

	private Dictionary<string, string> _statsByItemId;

	[ProtoMember(6)]
	public string _jsonStatsByShining;

	private Dictionary<int, string> _statsByShining;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	[ProtoMember(3)]
	public int TotalDrawRepeat { get; set; }

	[ProtoMember(4)]
	public int TotalBonusQty { get; set; }

	public Dictionary<string, string> StatsByItemId
	{
		get
		{
			if (_statsByItemId == null && !string.IsNullOrEmpty(_jsonStatsByItemId))
			{
				_statsByItemId = JsonHelper.ToObject<Dictionary<string, string>>(_jsonStatsByItemId);
			}
			return _statsByItemId;
		}
		set
		{
			_statsByItemId = value;
			_jsonStatsByItemId = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, string> StatsByShining
	{
		get
		{
			if (_statsByShining == null && !string.IsNullOrEmpty(_jsonStatsByShining))
			{
				_statsByShining = JsonHelper.ToObject<Dictionary<int, string>>(_jsonStatsByShining);
			}
			return _statsByShining;
		}
		set
		{
			_statsByShining = value;
			_jsonStatsByShining = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.MODULES_VERIFY_N_VALIDATE_DRAW_CARD_TEST;
}
