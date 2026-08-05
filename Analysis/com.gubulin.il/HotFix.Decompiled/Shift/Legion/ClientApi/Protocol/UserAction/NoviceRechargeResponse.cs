using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class NoviceRechargeResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(10)]
	public string _jsonNoviceRechargeData;

	private NoviceRechargeData _noviceRechargeData;

	public NoviceRechargeData NoviceRechargeData
	{
		get
		{
			if (_noviceRechargeData == null && !string.IsNullOrEmpty(_jsonNoviceRechargeData))
			{
				_noviceRechargeData = JsonHelper.ToObject<NoviceRechargeData>(_jsonNoviceRechargeData);
			}
			return _noviceRechargeData;
		}
	}

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_FIRSTANDCONTINUOUS_RECHARGE_REQUEST;
}
