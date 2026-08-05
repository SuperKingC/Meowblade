using System;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_火力支援
{
	[ProtoMember(1)]
	public int ActivateByUser;

	[ProtoMember(2)]
	public int ExpireTimestamp;

	[ProtoMember(3)]
	public int ActivateTimestamp;

	public bool StillValid(int timestamp)
	{
		return ExpireTimestamp < 0 || ExpireTimestamp > timestamp;
	}

	public int RemainingTime(int timestamp)
	{
		return Math.Max(0, ExpireTimestamp - timestamp);
	}
}
