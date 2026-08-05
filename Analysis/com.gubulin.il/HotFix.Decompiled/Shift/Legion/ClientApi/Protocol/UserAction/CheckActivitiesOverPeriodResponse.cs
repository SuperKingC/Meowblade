using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckActivitiesOverPeriodResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string _jsonActivityConfigs;

	private Dictionary<string, ActivityConfig> _activityConfigs;

	[ProtoMember(5)]
	public string _jsonCurrentRecordSingletonActivities;

	private Dictionary<int, string> _currentRecordSingletonActivities;

	[ProtoMember(6)]
	public string _jsonNewTickets;

	private Dictionary<string, int> _newTickets;

	[ProtoMember(7)]
	public string _jsonDefaultActivities;

	private List<string> _defaultActivities;

	[ProtoMember(8)]
	public string _jsonDefaultActivityContens;

	private Dictionary<string, Dictionary<string, List<string>>> _defaultActivityContents;

	[ProtoMember(9)]
	public string _serverTimeStr = DateTimeOffset.UtcNow.ToString();

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, ActivityConfig> ActivityConfigs
	{
		get
		{
			if (_activityConfigs == null && !string.IsNullOrEmpty(_jsonActivityConfigs))
			{
				_activityConfigs = JsonHelper.ToObject<Dictionary<string, ActivityConfig>>(_jsonActivityConfigs);
			}
			return _activityConfigs;
		}
		set
		{
			_activityConfigs = value;
			_jsonActivityConfigs = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<int, string> CurrentRecordSingletonActivities
	{
		get
		{
			if (_currentRecordSingletonActivities == null && !string.IsNullOrEmpty(_jsonCurrentRecordSingletonActivities))
			{
				_currentRecordSingletonActivities = JsonHelper.ToObject<Dictionary<int, string>>(_jsonCurrentRecordSingletonActivities);
			}
			return _currentRecordSingletonActivities;
		}
		set
		{
			_currentRecordSingletonActivities = value;
			_jsonCurrentRecordSingletonActivities = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, int> NewTickets
	{
		get
		{
			if (_newTickets == null && !string.IsNullOrEmpty(_jsonNewTickets))
			{
				_newTickets = JsonHelper.ToObject<Dictionary<string, int>>(_jsonNewTickets);
			}
			return _newTickets;
		}
		set
		{
			_newTickets = value;
			_jsonNewTickets = JsonHelper.ToJson(value);
		}
	}

	public List<string> DefaultActivities
	{
		get
		{
			if (_defaultActivities == null && !string.IsNullOrEmpty(_jsonDefaultActivities))
			{
				_defaultActivities = JsonHelper.ToObject<List<string>>(_jsonDefaultActivities);
			}
			return _defaultActivities;
		}
		set
		{
			_defaultActivities = value;
			_jsonDefaultActivities = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, Dictionary<string, List<string>>> DefaultActivityContents
	{
		get
		{
			if (_defaultActivityContents == null && !string.IsNullOrEmpty(_jsonDefaultActivityContens))
			{
				_defaultActivityContents = JsonHelper.ToObject<Dictionary<string, Dictionary<string, List<string>>>>(_jsonDefaultActivityContens);
			}
			return _defaultActivityContents;
		}
		set
		{
			_defaultActivityContents = value;
			_jsonDefaultActivityContens = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_CHECK_ACTIVITIES_OVER_PERIOD_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new Dictionary<string, ActivityConfig>();
		new Dictionary<string, Dictionary<string, List<string>>>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
