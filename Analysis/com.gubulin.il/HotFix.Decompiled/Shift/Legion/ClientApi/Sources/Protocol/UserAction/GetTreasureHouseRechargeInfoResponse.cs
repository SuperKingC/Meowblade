using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetTreasureHouseRechargeInfoResponse : IPacketBody
{
	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(5)]
	public string _jsonTreasureHouseRechargeInfo;

	private TreasureHouseRechargeInfo _treasureHouseRechargeInfo;

	public TreasureHouseRechargeInfo TreasureHouseRechargeInfo
	{
		get
		{
			if (_treasureHouseRechargeInfo == null && !string.IsNullOrEmpty(_jsonTreasureHouseRechargeInfo))
			{
				_treasureHouseRechargeInfo = JsonHelper.ToObject<TreasureHouseRechargeInfo>(_jsonTreasureHouseRechargeInfo);
			}
			return _treasureHouseRechargeInfo;
		}
	}

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_TREASURE_LTTR_REQUEST;
}
