using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class PvPRankGame
{
	[ProtoMember(1)]
	public string SeasonName;

	[ProtoMember(2)]
	public int Turn;

	[ProtoMember(3)]
	public string ZoneName;

	[ProtoMember(4)]
	public string _startAtStr;

	private DateTimeOffset _startAt;

	[ProtoMember(5)]
	public string _endAtStr;

	private DateTimeOffset _endAt;

	[ProtoMember(6)]
	public string _battleStartAtStr;

	private DateTimeOffset _battleStartAt;

	[ProtoMember(7)]
	public string _battleEndAtStr;

	private DateTimeOffset _battleEndAt;

	[ProtoMember(8)]
	public int UnlockedBlocks;

	[ProtoMember(9)]
	public string _jsonRankBonus;

	private List<tRankBaseBonus> _rankBonus;

	[ProtoMember(10)]
	public string _jsonScoreBonus;

	private List<tRankBaseBonus> _scoreBonus;

	[ProtoMember(11)]
	public int Id;

	[ProtoMember(40)]
	public int StartAtTimestamp;

	[ProtoMember(50)]
	public int EndAtTimestamp;

	[ProtoMember(60)]
	public int BattleStartAtTimestamp;

	[ProtoMember(70)]
	public int BattleEndAtTimestamp;

	public int StartAt => StartAtTimestamp;

	public int EndAt => EndAtTimestamp;

	public int BattleStartAt => BattleStartAtTimestamp;

	public int BattleEndAt => BattleEndAtTimestamp;

	public List<tRankBaseBonus> RankBonus
	{
		get
		{
			if (_rankBonus == null && !string.IsNullOrEmpty(_jsonRankBonus))
			{
				_rankBonus = JsonHelper.ToObject<List<tRankBaseBonus>>(_jsonRankBonus);
			}
			return _rankBonus;
		}
		set
		{
			_rankBonus = value;
			_jsonRankBonus = JsonHelper.ToJson(_rankBonus);
		}
	}

	public List<tRankBaseBonus> ScoreBonus
	{
		get
		{
			if (_scoreBonus == null && !string.IsNullOrEmpty(_jsonScoreBonus))
			{
				_scoreBonus = JsonHelper.ToObject<List<tRankBaseBonus>>(_jsonScoreBonus);
			}
			return _scoreBonus;
		}
		set
		{
			_scoreBonus = value;
			_jsonScoreBonus = JsonHelper.ToJson(_scoreBonus);
		}
	}
}
