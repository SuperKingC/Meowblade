using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class ClaimVerifyIdentityBonusResponse : IPacketBody
{
	[ProtoMember(3)]
	public string _jsonClaimResult;

	private Dictionary<string, int> _claimResult;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, int> ClaimResult
	{
		get
		{
			if (_claimResult == null && !string.IsNullOrEmpty(_jsonClaimResult))
			{
				_claimResult = JsonHelper.ToObject<Dictionary<string, int>>(_jsonClaimResult);
			}
			return _claimResult;
		}
		set
		{
			_claimResult = value;
			_jsonClaimResult = JsonHelper.ToJson(_claimResult);
		}
	}

	public int PacketId => PacketIds.USER_CLAIM_VERIFY_IDENTITY_BONUS_REQUEST;
}
