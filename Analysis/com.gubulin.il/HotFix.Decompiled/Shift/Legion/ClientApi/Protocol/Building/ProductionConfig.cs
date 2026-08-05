using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Building;

[ProtoContract]
public class ProductionConfig
{
	[ProtoMember(1)]
	public List<string> ProductList { get; set; }

	[ProtoMember(2)]
	public int Workers { get; set; }
}
