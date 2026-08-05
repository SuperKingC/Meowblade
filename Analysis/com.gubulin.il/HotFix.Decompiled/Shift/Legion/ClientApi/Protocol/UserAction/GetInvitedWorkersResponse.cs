using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetInvitedWorkersResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public string _jsonWorkers;

	private Dictionary<int, InvitedWorker> _workers;

	[ProtoMember(4)]
	public string _jsonNewExpiredWorkers;

	private Dictionary<int, InvitedWorker> _newExpiredWorkers;

	[ProtoMember(5)]
	public bool HasNew;

	[ProtoMember(6)]
	public string _jsonBuildingProdConfigs;

	private Dictionary<string, Dictionary<int, ProductionConfig>> _buildingProdConfigs;

	[ProtoMember(7)]
	public string _jsonInvitingSlotsConfig;

	private Dictionary<int, Tuple<int, string, int>> _invitingSlotsConfig;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<int, InvitedWorker> Workers
	{
		get
		{
			if (_workers == null && !string.IsNullOrEmpty(_jsonWorkers))
			{
				Dictionary<string, InvitedWorker> dictionary = JsonHelper.ToObject<Dictionary<string, InvitedWorker>>(_jsonWorkers);
				_workers = new Dictionary<int, InvitedWorker>();
				foreach (string key in dictionary.Keys)
				{
					_workers.Add(int.Parse(key), dictionary[key]);
				}
			}
			return _workers;
		}
		set
		{
			_workers = value;
			_jsonWorkers = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, InvitedWorker> NewExpiredWorkers
	{
		get
		{
			if (_newExpiredWorkers == null && !string.IsNullOrEmpty(_jsonNewExpiredWorkers))
			{
				Dictionary<string, InvitedWorker> dictionary = JsonHelper.ToObject<Dictionary<string, InvitedWorker>>(_jsonNewExpiredWorkers);
				_newExpiredWorkers = new Dictionary<int, InvitedWorker>();
				foreach (string key in dictionary.Keys)
				{
					_newExpiredWorkers.Add(int.Parse(key), dictionary[key]);
				}
			}
			return _newExpiredWorkers;
		}
		set
		{
			_newExpiredWorkers = value;
			_jsonNewExpiredWorkers = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, Dictionary<int, ProductionConfig>> BuildingProdConfigs
	{
		get
		{
			if (_buildingProdConfigs == null && !string.IsNullOrEmpty(_jsonBuildingProdConfigs))
			{
				Dictionary<string, Dictionary<string, ProductionConfig>> dictionary = JsonHelper.ToObject<Dictionary<string, Dictionary<string, ProductionConfig>>>(_jsonBuildingProdConfigs);
				_buildingProdConfigs = new Dictionary<string, Dictionary<int, ProductionConfig>>();
				foreach (string key in dictionary.Keys)
				{
					Dictionary<int, ProductionConfig> dictionary2 = new Dictionary<int, ProductionConfig>();
					foreach (string key2 in dictionary[key].Keys)
					{
						dictionary2.Add(int.Parse(key2), dictionary[key][key2]);
					}
					_buildingProdConfigs.Add(key, dictionary2);
				}
			}
			return _buildingProdConfigs;
		}
		set
		{
			_buildingProdConfigs = value;
			_jsonBuildingProdConfigs = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, Tuple<int, string, int>> InvitingSlotsConfig
	{
		get
		{
			if (_invitingSlotsConfig == null && !string.IsNullOrEmpty(_jsonInvitingSlotsConfig))
			{
				Dictionary<string, Tuple<int, string, int>> dictionary = JsonHelper.ToObject<Dictionary<string, Tuple<int, string, int>>>(_jsonInvitingSlotsConfig);
				_invitingSlotsConfig = new Dictionary<int, Tuple<int, string, int>>();
				foreach (string key in dictionary.Keys)
				{
					_invitingSlotsConfig.Add(int.Parse(key), dictionary[key]);
				}
			}
			return _invitingSlotsConfig;
		}
		set
		{
			_invitingSlotsConfig = value;
			_jsonInvitingSlotsConfig = JsonHelper.ToJson(_invitingSlotsConfig);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_GET_INVITED_WORKERS;
}
