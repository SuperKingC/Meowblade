using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class LastestBuyRecord
{
	[ProtoMember(1)]
	public int UserId = -1;

	[ProtoMember(2)]
	public int CampId = -1;

	[ProtoMember(3)]
	public long Timestamp_ms = -1L;

	[ProtoMember(4)]
	public int BuyCnt = -1;

	public void Copy(LastestBuyRecord other)
	{
		UserId = other.UserId;
		CampId = other.CampId;
		Timestamp_ms = other.Timestamp_ms;
		BuyCnt = other.BuyCnt;
	}

	public void Clear()
	{
		UserId = -1;
		CampId = -1;
		Timestamp_ms = -1L;
		BuyCnt = -1;
	}
}
