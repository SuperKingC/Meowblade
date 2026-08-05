using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2CreateShipSummaryResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string Cost { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_CREATE_SHIP_SUMMARY;

	public Dictionary<string, int> GetSoldierStockCost()
	{
		Dictionary<string, int> result = new Dictionary<string, int>();
		if (!string.IsNullOrEmpty(Cost))
		{
			result = JsonHelper.ToObject<Dictionary<string, int>>(Cost);
		}
		return result;
	}
}
