using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class RandomLevelTestResponse : IPacketBody
{
	[ProtoMember(6)]
	public string _jsonStatsByLevelId;

	private Dictionary<string, string> _statsByLevelId;

	[ProtoMember(7)]
	public string _jsonStatsByLevelDifficulty;

	private Dictionary<int, string> _statsByLevelDifficulty;

	[ProtoMember(8)]
	public string _jsonLotteryBonuses;

	private List<KeyValuePair<string, Dictionary<string, int>>> _lotteryBonuses;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string Message { get; set; }

	[ProtoMember(3)]
	public int TotalRepeat { get; set; }

	[ProtoMember(4)]
	public int TotalLevels { get; set; }

	[ProtoMember(5)]
	public int OffensiveClearStages { get; set; }

	public Dictionary<string, string> StatsByLevelId
	{
		get
		{
			if (_statsByLevelId == null && !string.IsNullOrEmpty(_jsonStatsByLevelId))
			{
				_statsByLevelId = JsonHelper.ToObject<Dictionary<string, string>>(_jsonStatsByLevelId);
			}
			return _statsByLevelId;
		}
		set
		{
			_statsByLevelId = value;
			_jsonStatsByLevelId = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, string> StatsByLevelDifficulty
	{
		get
		{
			if (_statsByLevelDifficulty == null && !string.IsNullOrEmpty(_jsonStatsByLevelDifficulty))
			{
				_statsByLevelDifficulty = JsonHelper.ToObject<Dictionary<int, string>>(_jsonStatsByLevelDifficulty);
			}
			return _statsByLevelDifficulty;
		}
		set
		{
			_statsByLevelDifficulty = value;
			_jsonStatsByLevelDifficulty = JsonHelper.ToJson(value);
		}
	}

	public List<KeyValuePair<string, Dictionary<string, int>>> LotteryBonuses
	{
		get
		{
			if (_lotteryBonuses == null && !string.IsNullOrEmpty(_jsonLotteryBonuses))
			{
				_lotteryBonuses = JsonHelper.ToObject<List<KeyValuePair<string, Dictionary<string, int>>>>(_jsonLotteryBonuses);
			}
			return _lotteryBonuses;
		}
		set
		{
			_lotteryBonuses = value;
			_jsonLotteryBonuses = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.MODULES_VERIFY_N_VALIDATE_RANDOM_LEVEL_TEST;
}
