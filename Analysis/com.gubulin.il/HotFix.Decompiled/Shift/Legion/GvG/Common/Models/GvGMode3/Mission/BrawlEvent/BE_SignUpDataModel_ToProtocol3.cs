using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

[ProtoContract]
public class BE_SignUpDataModel_ToProtocol3
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int CurCnt;

	[ProtoMember(3)]
	public int MaxCnt;

	[ProtoMember(4)]
	public int ReplayDuration;

	[ProtoMember(5)]
	public int WinnerCampId;

	[ProtoMember(6)]
	public int MVPUserId;
}
