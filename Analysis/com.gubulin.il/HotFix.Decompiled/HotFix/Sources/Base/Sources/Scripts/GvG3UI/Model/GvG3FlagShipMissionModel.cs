using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvG3FlagShipMissionModel
{
	private int? _consumeCampEnergy;

	private List<long> _checkValues;

	private int? _changeCampBuffLevel;

	private int? _addCampEnergy;

	private string _bonusItemId;

	private int? _bonusNumber;

	private string _showBonusItemId;

	private int? _showBonusNumber;

	public string MissionConfigId { get; }

	public int MUid { get; set; }

	public eMissionEntityState MState { get; set; }

	public List<long> ProgressValue { get; }

	public bool HasClaimed { get; private set; }

	public long ExpiredTimestamp { get; set; }

	public GvGMode3CampMissionConfigModel Data { get; set; }

	public int UiStatus { get; set; }

	public int ConsumeCampEnergy
	{
		get
		{
			int? consumeCampEnergy = _consumeCampEnergy;
			if (consumeCampEnergy.HasValue)
			{
				return _consumeCampEnergy.Value;
			}
			object value;
			if (Data.TriggerOnAccept == null)
			{
				_consumeCampEnergy = 0;
			}
			else if (Data.TriggerOnAccept.TryGetValue("ConsumeCampEnergy", out value))
			{
				_consumeCampEnergy = (int)value;
			}
			else
			{
				_consumeCampEnergy = 0;
			}
			return _consumeCampEnergy.Value;
		}
	}

	public List<long> CheckValues
	{
		get
		{
			if (_checkValues != null)
			{
				return _checkValues;
			}
			_checkValues = ((Data.SucessCheckValue == null) ? new List<long>() : Data.SucessCheckValue.GetEntityCheckConditionContent);
			return _checkValues;
		}
	}

	public int ChangeCampBuffLevel
	{
		get
		{
			int? changeCampBuffLevel = _changeCampBuffLevel;
			if (changeCampBuffLevel.HasValue)
			{
				return _changeCampBuffLevel.Value;
			}
			object value;
			if (Data.TriggerOnFinish == null)
			{
				_changeCampBuffLevel = 0;
			}
			else if (Data.TriggerOnFinish.TryGetValue("ChangeCampBuffLevel", out value))
			{
				_changeCampBuffLevel = (int)value;
			}
			else
			{
				_changeCampBuffLevel = 0;
			}
			return _changeCampBuffLevel.Value;
		}
	}

	public int AddCampEnergy
	{
		get
		{
			int? addCampEnergy = _addCampEnergy;
			if (addCampEnergy.HasValue)
			{
				return _addCampEnergy.Value;
			}
			object value;
			if (Data.TriggerOnFinish == null)
			{
				_addCampEnergy = 0;
			}
			else if (Data.TriggerOnFinish.TryGetValue("AddCampEnergy", out value))
			{
				_addCampEnergy = (int)value;
			}
			else
			{
				_addCampEnergy = 0;
			}
			return _addCampEnergy.Value;
		}
	}

	public string BonusItemId => _bonusItemId ?? (_bonusItemId = Data.MissionBonus?.Taker?.Keys.ToList()[0]);

	public int BonusNumber
	{
		get
		{
			int? bonusNumber = _bonusNumber;
			if (!bonusNumber.HasValue)
			{
				_bonusNumber = Data.MissionBonus?.Taker?.Values.ToList()[0];
			}
			return _bonusNumber.GetValueOrDefault();
		}
	}

	public string ShowBonusItemId => _showBonusItemId ?? (_showBonusItemId = Data.ShowBonus?.Keys.ToList()[0]);

	public int ShowBonusNumber
	{
		get
		{
			int? showBonusNumber = _showBonusNumber;
			if (!showBonusNumber.HasValue)
			{
				_showBonusNumber = Data.ShowBonus?.Values.ToList()[0];
			}
			return _showBonusNumber.GetValueOrDefault();
		}
	}

	public GvG3FlagShipMissionModel(string configId)
	{
		MissionConfigId = configId;
		ProgressValue = new List<long>();
		Data = GvG3FlagShipMissionsConfigHelper.MissionConfig_Dict[configId];
		if (Data == null)
		{
			throw new Exception("GvG3FlagShipMissionModel init error:Data is null, MissionConfigId=" + MissionConfigId);
		}
	}

	public void SyncMissionState(MissionStateRecordWithProgress progress)
	{
		MUid = progress.MUID;
		MState = (eMissionEntityState)progress.MState;
		ProgressValue.Clear();
		if (progress.ProgressValue != null)
		{
			ProgressValue.AddRange(progress.ProgressValue);
		}
		HasClaimed = progress.HasClaimed;
		ExpiredTimestamp = progress.ExpiredTimestamp_ms / 1000;
	}
}
