using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models.InstanceZoneModels;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.Map;

[ProtoContract]
public class InstanceZone_Protocol
{
	private Dictionary<string, List<CampMission>> _CampMissions;

	private Dictionary<string, List<CampMissionConfig>> _CampUserMissionConfigs;

	private Dictionary<string, CampData_Protocol> _CampDatas;

	[ProtoMember(1)]
	public string IZId { get; set; }

	[ProtoMember(2)]
	public string IZConfigId { get; set; }

	[ProtoMember(3)]
	public int IZProgress { get; set; }

	[ProtoMember(4)]
	public int BeginTimestamp { get; set; }

	[ProtoMember(5)]
	public int EndTimestamp { get; set; }

	[ProtoMember(6)]
	public int IZStatus { get; set; }

	[ProtoMember(7)]
	public string _jsonCampMissions { get; set; }

	public Dictionary<string, List<CampMission>> CampMissions
	{
		get
		{
			if (_CampMissions == null && !string.IsNullOrEmpty(_jsonCampMissions))
			{
				_CampMissions = JsonHelper.ToObject<Dictionary<string, List<CampMission>>>(_jsonCampMissions);
			}
			return _CampMissions;
		}
		set
		{
			_CampMissions = value;
			_jsonCampMissions = JsonHelper.ToJson(_CampMissions);
		}
	}

	[ProtoMember(8)]
	public string _jsonCampUserMissionConfigs { get; set; }

	public Dictionary<string, List<CampMissionConfig>> CampUserMissionConfigs
	{
		get
		{
			if (_CampUserMissionConfigs == null && !string.IsNullOrEmpty(_jsonCampUserMissionConfigs))
			{
				_CampUserMissionConfigs = JsonHelper.ToObject<Dictionary<string, List<CampMissionConfig>>>(_jsonCampUserMissionConfigs);
			}
			return _CampUserMissionConfigs;
		}
		set
		{
			_CampUserMissionConfigs = value;
			_jsonCampUserMissionConfigs = JsonHelper.ToJson(_CampUserMissionConfigs);
		}
	}

	[ProtoMember(9)]
	public string _jsonCampDatas { get; set; }

	public Dictionary<string, CampData_Protocol> CampDatas
	{
		get
		{
			if (_CampDatas == null && !string.IsNullOrEmpty(_jsonCampDatas))
			{
				_CampDatas = JsonHelper.ToObject<Dictionary<string, CampData_Protocol>>(_jsonCampDatas);
			}
			return _CampDatas;
		}
		set
		{
			_CampDatas = value;
			_jsonCampDatas = JsonHelper.ToJson(_CampDatas);
		}
	}
}
