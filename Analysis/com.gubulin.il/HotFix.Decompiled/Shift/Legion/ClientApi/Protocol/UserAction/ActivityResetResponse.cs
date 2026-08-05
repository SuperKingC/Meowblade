using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ActivityResetResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string _jsonActivityConfig;

	private ActivityConfig _activityConfig;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public ActivityConfig ActivityConfig
	{
		get
		{
			if (_activityConfig == null && !string.IsNullOrEmpty(_jsonActivityConfig))
			{
				_activityConfig = JsonHelper.ToObject<ActivityConfig>(_jsonActivityConfig);
			}
			return _activityConfig;
		}
		set
		{
			_activityConfig = value;
			_jsonActivityConfig = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_ACTIVITY_RESET_REQUEST;
}
