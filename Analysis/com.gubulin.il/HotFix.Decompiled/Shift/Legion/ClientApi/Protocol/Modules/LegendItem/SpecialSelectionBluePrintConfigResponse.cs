using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem;

[ProtoContract]
public class SpecialSelectionBluePrintConfigResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string JsonConfig { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_SPECIAL_BLUEPRINT_Config;

	public List<ConfigItem> ConfigItems => JsonHelper.ToObject<List<ConfigItem>>(JsonConfig);
}
