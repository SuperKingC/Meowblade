using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetTreasureHuntActivityProgressResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public List<KeyValuePair<string, int>> Soldiers;

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Models.TreasureHuntLevelInfo")]
	public List<TreasureHuntLevelInfo> LevelsStatus;

	[ProtoMember(6, TypeName = "Shift.Legion.ClientApi.Models.TreasureHuntLevelInfo")]
	public List<TreasureHuntLevelInfo> BossLevelsStatus;

	[ProtoMember(7)]
	public int ScoreToBoss;

	[ProtoMember(8)]
	public int ExpireAt;

	[ProtoMember(9)]
	public int MaxDifficulty;

	[ProtoMember(10)]
	public string _jsonBonusStats;

	private Dictionary<string, int> _bonusStats;

	[ProtoMember(11)]
	public int MaxLegionSize;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, int> BonusStats
	{
		get
		{
			if (_bonusStats == null && !string.IsNullOrEmpty(_jsonBonusStats))
			{
				_bonusStats = JsonHelper.ToObject<Dictionary<string, int>>(_jsonBonusStats);
			}
			return _bonusStats;
		}
		set
		{
			_bonusStats = value;
			_jsonBonusStats = JsonHelper.ToJson(_bonusStats);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_TREASUREHUNT_ACTIVITY_PROGRESS;
}
