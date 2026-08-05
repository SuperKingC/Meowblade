using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Store;

[ProtoContract]
public class StoreItemList
{
	[ProtoMember(1)]
	public int CompletedMissionsNode;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Store.StoreItem")]
	public List<StoreItem> Items;
}
