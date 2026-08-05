using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class LegendItemCreateRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string _pbCreateConfig;

	private Dictionary<string, int> _createConfig;

	[ProtoMember(2, TypeName = "Shift.Legion.Common.Models.ItemEffectIdentifiedLegendItem")]
	public string _jsonSpecifiedTemplates;

	private Dictionary<string, ItemEffectIdentifiedLegendItem> _specifiedTemplates;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public Dictionary<string, int> CreateConfig
	{
		get
		{
			if (_pbCreateConfig == null)
			{
				return null;
			}
			return _createConfig ?? (_createConfig = JsonHelper.ToObject<Dictionary<string, int>>(_pbCreateConfig));
		}
		set
		{
			_createConfig = value;
			_pbCreateConfig = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, ItemEffectIdentifiedLegendItem> SpecifiedTemplates
	{
		get
		{
			if (_specifiedTemplates == null && !string.IsNullOrEmpty(_jsonSpecifiedTemplates))
			{
				_specifiedTemplates = JsonHelper.ToObject<Dictionary<string, ItemEffectIdentifiedLegendItem>>(_jsonSpecifiedTemplates);
			}
			return _specifiedTemplates;
		}
		set
		{
			_specifiedTemplates = value;
			_jsonSpecifiedTemplates = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_CREATE;
}
