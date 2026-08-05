using ProtoBuf;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class ForgedExtraItem
{
	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2)]
	public int Count;

	[ProtoMember(4)]
	public int src;

	public eTalentSrc TalentSrc
	{
		get
		{
			return (eTalentSrc)src;
		}
		set
		{
			src = (int)value;
		}
	}
}
