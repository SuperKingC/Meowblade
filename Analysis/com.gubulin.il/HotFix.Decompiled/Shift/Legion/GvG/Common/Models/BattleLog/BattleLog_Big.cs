using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using ILRuntime_LitJson;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class BattleLog_Big
{
	public int IslandId;

	public int IslandOriginalCampId;

	public bool HasBoss;

	public int AKill;

	public int ALoss;

	public long Timestamp_ms;

	public BattleLogShipInfo ShipInfoA;

	public BattleLogShipInfo ShipInfoB;

	public List<BattleLog_Small> SmallLogs = new List<BattleLog_Small>();

	[JsonIgnore]
	private string _timeText;

	[JsonIgnore]
	private string _islandName;

	[JsonIgnore]
	private string _bossHp;

	[JsonIgnore]
	private int _myCampId;

	[JsonIgnore]
	private BattleLogShipInfo _redInfo;

	[JsonIgnore]
	private BattleLogShipInfo _blueInfo;

	[JsonIgnore]
	private int _kill;

	[JsonIgnore]
	private int _loss;

	[JsonIgnore]
	public string TimeStampText
	{
		get
		{
			if (string.IsNullOrEmpty(_timeText))
			{
				_timeText = DateTimeHelper.ParseMillisecondsTimeStamp(Timestamp_ms).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
			}
			return _timeText;
		}
	}

	[JsonIgnore]
	public string IslandName
	{
		get
		{
			try
			{
				if (string.IsNullOrEmpty(_islandName))
				{
					_islandName = WorldMapConfigHelper.Configs.TryGetIsland(IslandId).Name;
				}
				return _islandName;
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
	}

	[JsonIgnore]
	public string BossHp
	{
		get
		{
			if (string.IsNullOrEmpty(_bossHp))
			{
				long num = 0L;
				foreach (BattleLog_Small smallLog in SmallLogs)
				{
					num += smallLog.BossHp;
				}
				_bossHp = (HasBoss ? num.ShortNumberFormat() : string.Empty);
			}
			return _bossHp;
		}
	}

	[JsonIgnore]
	public BattleLogShipInfo RedInfo => _redInfo;

	[JsonIgnore]
	public BattleLogShipInfo BlueInfo => _blueInfo;

	[JsonIgnore]
	public int Kill => _kill;

	[JsonIgnore]
	public int Loss => _loss;

	public string Guid { get; set; }

	public string ProcessId { get; set; }

	[JsonIgnore]
	public string LogKey { get; set; }

	public void DataInit(int myCampId)
	{
		_myCampId = myCampId;
		List<BattleLogShipInfo> list = new List<BattleLogShipInfo> { ShipInfoA, ShipInfoB };
		list.Sort(UserSort);
		_redInfo = list[0];
		_blueInfo = list[1];
		eBattleLogShipAlias eBattleLogShipAlias2 = ((_redInfo.UserId != ShipInfoA.UserId) ? eBattleLogShipAlias.B : eBattleLogShipAlias.A);
		bool flag = eBattleLogShipAlias2 == eBattleLogShipAlias.A;
		_kill = (flag ? AKill : ALoss);
		_loss = (flag ? ALoss : AKill);
		foreach (BattleLog_Small smallLog in SmallLogs)
		{
			bool flag2 = smallLog.RedAlias == eBattleLogShipAlias2;
			bool flag3 = smallLog.Winner == 200;
			smallLog.Win = (flag2 ? flag3 : (!flag3));
			smallLog.Offensive = flag2;
		}
	}

	private int UserSort(BattleLogShipInfo a, BattleLogShipInfo b)
	{
		if (a.UserId == -1 && b.UserId != -1)
		{
			return 1;
		}
		if (a.UserId != -1 && b.UserId == -1)
		{
			return -1;
		}
		if (a.CampId == _myCampId && b.CampId != _myCampId)
		{
			return -1;
		}
		if (a.CampId != _myCampId && b.CampId == _myCampId)
		{
			return 1;
		}
		return a.CampId.CompareTo(b.CampId);
	}

	public void PlayerLogInit(string processId, string logKey)
	{
		try
		{
			ProcessId = processId;
			LogKey = logKey;
			string[] array = LogKey.Split(new string[1] { "_" }, StringSplitOptions.None);
			Guid = array[1];
		}
		catch (Exception arg)
		{
			ILRuntimeDebug.LogError($"[BattleLog_Big]:PlayerLogInit_{arg}");
		}
	}
}
