using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IslandEventInfo
{
	[ProtoMember(1)]
	public int _eIE;

	[ProtoMember(2)]
	public int MUID;

	[ProtoMember(3)]
	public byte[] Data;

	[ProtoMember(4)]
	public int IconIdx { get; set; }

	public eIslandEvent eIE
	{
		get
		{
			return (eIslandEvent)_eIE;
		}
		set
		{
			_eIE = (int)value;
		}
	}
}
