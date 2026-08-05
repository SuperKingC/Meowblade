using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGClaimUserCampMissionResponse : IPacketBody
{
	[ProtoMember(3)]
	public string _jsonClaimed;

	private Dictionary<string, float> _Claimed;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, float> Claimed
	{
		get
		{
			if (_jsonClaimed == null)
			{
				return null;
			}
			return _Claimed ?? (_Claimed = JsonHelper.ToObject<Dictionary<string, float>>(_jsonClaimed));
		}
		set
		{
			_Claimed = value;
			_jsonClaimed = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GVG_CLAIM_USER_CAMPMISSION;
}
