using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;

[ProtoContract]
public class LegendItemEnhancementEnhanceResponse : IPacketBody
{
	[ProtoMember(3)]
	public string _jsonDevouredItems;

	private List<long> _devouredItems;

	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem")]
	public Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem EnhancedItem { get; set; }

	public List<long> DevouredItems
	{
		get
		{
			if (_devouredItems == null && !string.IsNullOrEmpty(_jsonDevouredItems))
			{
				_devouredItems = JsonHelper.ToObject<List<long>>(_jsonDevouredItems);
			}
			return _devouredItems;
		}
		set
		{
			_devouredItems = value;
			_jsonDevouredItems = JsonHelper.ToJson(value);
		}
	}

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] Costs { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.MODULES_LEGEND_ITEM_ENHANCEMENT_ENHANCE;
}
