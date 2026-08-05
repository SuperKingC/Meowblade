using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class AccessoryRecordModel
{
	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Models.AcquiredRecord")]
	public List<AcquiredRecord> AcquiredRecords;

	[ProtoMember(3)]
	public bool Equip;
}
