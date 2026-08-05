using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGBattleResultResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(4)]
	public int Winner;

	[ProtoMember(5)]
	public string _pbRedTeamHp;

	private List<List<float>> _redTeamHp;

	[ProtoMember(6)]
	public string _pbBlueTeamHp;

	private List<List<float>> _blueTeamHp;

	[ProtoMember(7)]
	public string _pbRedTeamDamageStats;

	private Dictionary<string, float> _redTeamDamageStats;

	[ProtoMember(8)]
	public string _pbBlueTeamDamageStats;

	private Dictionary<string, float> _blueTeamDamageStats;

	[ProtoMember(9)]
	public string _pbRedTeamDeadStats;

	private Dictionary<string, int> _redTeamDeadStats;

	[ProtoMember(10)]
	public string _pbBlueTeamDeadStats;

	private Dictionary<string, int> _blueTeamDeadStats;

	[ProtoMember(11)]
	public string _pbRedTeamBornRecords;

	private List<UnitBornRecord[]> _redTeamBornRecords;

	[ProtoMember(12)]
	public string _pbBlueTeamBornRecords;

	private List<UnitBornRecord[]> _blueTeamBornRecords;

	[ProtoMember(20)]
	public float RedTeamHpTotal;

	[ProtoMember(21)]
	public float BlueTeamHpTotal;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<List<float>> RedTeamHp
	{
		get
		{
			if (_pbRedTeamHp == null)
			{
				return null;
			}
			return _redTeamHp ?? (_redTeamHp = JsonHelper.ToObject<List<List<float>>>(_pbRedTeamHp));
		}
		set
		{
			_redTeamHp = value;
			_pbRedTeamHp = JsonHelper.ToJson(value);
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

	public Dictionary<string, float> RedTeamDamageStats
	{
		get
		{
			if (_pbRedTeamDamageStats == null)
			{
				return null;
			}
			return _redTeamDamageStats ?? (_redTeamDamageStats = JsonHelper.ToObject<Dictionary<string, float>>(_pbRedTeamDamageStats));
		}
		set
		{
			_redTeamDamageStats = value;
			_pbRedTeamDamageStats = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, float> BlueTeamDamageStats
	{
		get
		{
			if (_pbBlueTeamDamageStats == null)
			{
				return null;
			}
			return _blueTeamDamageStats ?? (_blueTeamDamageStats = JsonHelper.ToObject<Dictionary<string, float>>(_pbBlueTeamDamageStats));
		}
		set
		{
			_blueTeamDamageStats = value;
			_pbBlueTeamDamageStats = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, int> RedTeamDeadStats
	{
		get
		{
			if (_pbRedTeamDeadStats == null)
			{
				return null;
			}
			return _redTeamDeadStats ?? (_redTeamDeadStats = JsonHelper.ToObject<Dictionary<string, int>>(_pbRedTeamDeadStats));
		}
		set
		{
			_redTeamDeadStats = value;
			_pbRedTeamDeadStats = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, int> BlueTeamDeadStats
	{
		get
		{
			if (_pbBlueTeamDeadStats == null)
			{
				return null;
			}
			return _blueTeamDeadStats ?? (_blueTeamDeadStats = JsonHelper.ToObject<Dictionary<string, int>>(_pbBlueTeamDeadStats));
		}
		set
		{
			_blueTeamDeadStats = value;
			_pbBlueTeamDeadStats = JsonHelper.ToJson(value);
		}
	}

	public List<UnitBornRecord[]> RedTeamBornRecords
	{
		get
		{
			if (_pbRedTeamBornRecords == null)
			{
				return null;
			}
			return _redTeamBornRecords ?? (_redTeamBornRecords = JsonHelper.ToObject<List<UnitBornRecord[]>>(_pbRedTeamBornRecords));
		}
		set
		{
			_redTeamBornRecords = value;
			_pbRedTeamBornRecords = JsonHelper.ToJson(value);
		}
	}

	public List<UnitBornRecord[]> BlueTeamBornRecords
	{
		get
		{
			if (_pbBlueTeamBornRecords == null)
			{
				return null;
			}
			return _blueTeamBornRecords ?? (_blueTeamBornRecords = JsonHelper.ToObject<List<UnitBornRecord[]>>(_pbBlueTeamBornRecords));
		}
		set
		{
			_blueTeamBornRecords = value;
			_pbBlueTeamBornRecords = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_BATTLE_RESULT_REQUEST;

	[ProtoMember(61)]
	public string BattleId { get; set; }

	[ProtoMember(62)]
	public int SubLevelIndex { get; set; }

	[ProtoMember(63)]
	public string BattleMode { get; set; }

	[ProtoMember(64)]
	public int ReplaySegments { get; set; }

	[ProtoMember(65)]
	public int ReplayFrames { get; set; }

	[ProtoMember(66)]
	public bool IsRetreat { get; set; }

	[ProtoMember(67)]
	public string BattleServerIP { get; set; }

	[ProtoMember(68)]
	public string BattlerServerMD5 { get; set; }

	[ProtoMember(69)]
	public string BattleServerDataMD5 { get; set; }

	[ProtoMember(70)]
	public int PvP_Idx { get; set; } = -1;

	[ProtoMember(71)]
	public List<int> KingPoints { get; set; }

	[ProtoMember(72)]
	public List<int> PvP_ReplaySegments { get; set; }

	[ProtoMember(73)]
	public List<int> PvP_ReplayFrames { get; set; }

	[ProtoMember(74)]
	public string InterestedSoldierIdsDamagedMeters { get; set; }

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<UnitBornRecord>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
