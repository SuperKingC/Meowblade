using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicCardPoolActivityResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	public string Message;

	[ProtoMember(4)]
	public string _jsonDynamicCardPoolActivityData;

	private DynamicCardPoolActivityData _dynamicCardPoolActivityData = null;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public DynamicCardPoolActivityData DynamicCardPoolActivityData
	{
		get
		{
			if (_dynamicCardPoolActivityData == null && !string.IsNullOrEmpty(_jsonDynamicCardPoolActivityData))
			{
				_dynamicCardPoolActivityData = JsonHelper.ToObject<DynamicCardPoolActivityData>(_jsonDynamicCardPoolActivityData);
			}
			return _dynamicCardPoolActivityData;
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_CARDPOOL_ACTIVITY_REQUEST;
}
