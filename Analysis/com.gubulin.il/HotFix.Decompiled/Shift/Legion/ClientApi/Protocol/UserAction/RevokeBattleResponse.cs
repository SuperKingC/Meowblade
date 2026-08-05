using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class RevokeBattleResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(10)]
	public string _pbRedTeamRevivedSoldiers;

	private Dictionary<string, int> _redTeamRevivedSoldiers;

	[ProtoMember(11)]
	public string _pbBlueTeamHp;

	private List<List<float>> _blueTeamHp;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, int> RedTeamRevivedSoldiers
	{
		get
		{
			if (_pbRedTeamRevivedSoldiers == null)
			{
				return null;
			}
			return _redTeamRevivedSoldiers ?? (_redTeamRevivedSoldiers = JsonHelper.ToObject<Dictionary<string, int>>(_pbRedTeamRevivedSoldiers));
		}
		set
		{
			_redTeamRevivedSoldiers = value;
			_pbRedTeamRevivedSoldiers = JsonHelper.ToJson(value);
		}
	}

	public List<List<float>> BlueTeamHp
	{
		get
		{
			if (_pbBlueTeamHp == null)
			{
				return null;
			}
			return _blueTeamHp ?? (_blueTeamHp = JsonHelper.ToObject<List<List<float>>>(_pbBlueTeamHp));
		}
		set
		{
			_blueTeamHp = value;
			_pbBlueTeamHp = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_REVOKE_BATTLE_REQUEST;
}
