using System;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_额外发现
{
	[ProtoMember(1)]
	public bool CanShare;

	[ProtoMember(2)]
	public int ExpireTimestamp;

	public bool StillValid(int timestamp)
	{
		return ExpireTimestamp < 0 || ExpireTimestamp > timestamp;
	}

	public int RemainingTime(int timestamp)
	{
		return Math.Max(0, ExpireTimestamp - timestamp);
	}
}
