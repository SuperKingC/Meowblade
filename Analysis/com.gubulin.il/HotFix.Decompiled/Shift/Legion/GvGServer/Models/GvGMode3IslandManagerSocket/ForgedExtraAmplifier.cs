using ProtoBuf;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class ForgedExtraAmplifier
{
	public enum ExtraType
	{
		None = 0,
		锻造双倍 = 0,
		锻造共鸣 = 1
	}

	[ProtoMember(1)]
	public int Idx;

	[ProtoMember(2)]
	public int Count;

	[ProtoMember(3)]
	public bool IsCritical;

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

	public ExtraType Type
	{
		get
		{
			if (TalentSrc == eTalentSrc.泰坦造物)
			{
				return ExtraType.None;
			}
			if (TalentSrc == eTalentSrc.锻造师 || TalentSrc == eTalentSrc.工程师 || TalentSrc == eTalentSrc.机械师 || TalentSrc == eTalentSrc.神工巧匠)
			{
				return ExtraType.锻造共鸣;
			}
			return ExtraType.None;
		}
	}
}
