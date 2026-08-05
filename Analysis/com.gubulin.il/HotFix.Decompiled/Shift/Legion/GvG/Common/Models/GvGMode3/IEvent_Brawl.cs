using ProtoBuf;
using Shift.Legion.GvG.Common.Enums;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_Brawl
{
	[ProtoMember(3)]
	public string MConfigId;

	[ProtoMember(4)]
	public int BrawlEventDuration;

	[ProtoMember(5)]
	public int SubType;

	[ProtoMember(7, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.IEvent_Brawl_Icon")]
	public IEvent_Brawl_Icon IconInfo;

	[ProtoMember(8)]
	public int WinnerCamp;

	public eGvGMode3CampMissionSubType GetSubType()
	{
		return (eGvGMode3CampMissionSubType)SubType;
	}
}
