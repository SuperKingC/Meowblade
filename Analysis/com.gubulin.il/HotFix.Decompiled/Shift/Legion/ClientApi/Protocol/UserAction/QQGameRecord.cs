using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class QQGameRecord
{
	[ProtoMember(1)]
	public bool NewUserBonusClaimed { get; set; }

	[ProtoMember(2)]
	public List<int> LevelBonusClaimed { get; set; }

	[ProtoMember(3)]
	public int LastActiveBonusClaimed { get; set; }

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.DawankaBonusClaimRecord")]
	public List<DawankaBonusClaimRecord> DawankaBonusClaimRecords { get; set; }
}
