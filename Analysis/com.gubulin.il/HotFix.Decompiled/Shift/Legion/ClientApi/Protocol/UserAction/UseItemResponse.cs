using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseItemResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> Bonuses;

	[ProtoMember(5)]
	public int TimeMachineSeconds;

	[ProtoMember(6, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(7)]
	public int Seed;

	[ProtoMember(8)]
	public string _jsonBuildingConstructingConfigs;

	private List<BuildingConstructingConfig> _buildingConstructingConfigs;

	[ProtoMember(9, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> LegendItems;

	[ProtoMember(10)]
	public string _jsonClaimedContent;

	private Dictionary<string, float> _claimedContent;

	[ProtoMember(11)]
	public string NewBlueprints;

	public List<BuildingConstructingConfig> BuildingConstructingConfigs
	{
		get
		{
			if (_buildingConstructingConfigs == null && !string.IsNullOrEmpty(_jsonBuildingConstructingConfigs))
			{
				_buildingConstructingConfigs = JsonHelper.ToObject<List<BuildingConstructingConfig>>(_jsonBuildingConstructingConfigs);
			}
			return _buildingConstructingConfigs;
		}
		set
		{
			_buildingConstructingConfigs = value;
			_jsonBuildingConstructingConfigs = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, float> ClaimedContent
	{
		get
		{
			if (_claimedContent == null && !string.IsNullOrEmpty(_jsonClaimedContent))
			{
				_claimedContent = JsonHelper.ToObject<Dictionary<string, float>>(_jsonClaimedContent);
			}
			return _claimedContent;
		}
		set
		{
			_claimedContent = value;
			_jsonClaimedContent = JsonHelper.ToJson(value);
		}
	}

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_USE_ITEM_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ModelsBonus>();
		new List<StockChangeRecord>();
		new List<BuildingConstructingConfig>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
