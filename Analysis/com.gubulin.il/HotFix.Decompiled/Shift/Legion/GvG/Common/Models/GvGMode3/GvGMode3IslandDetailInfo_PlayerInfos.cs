using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3IslandDetailInfo_PlayerInfos
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public int ShipCount;

	public GvGMode3IslandDetailInfo_PlayerInfos Clone()
	{
		return new GvGMode3IslandDetailInfo_PlayerInfos
		{
			CampId = CampId,
			UserId = UserId,
			ShipCount = ShipCount
		};
	}
}
