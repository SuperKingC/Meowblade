using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SoulStoneMaxCompositeToResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(4)]
	public string _pbCompositeResult;

	private Dictionary<string, int> _compositeResult;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, int> CompositeResult
	{
		get
		{
			if (_pbCompositeResult == null)
			{
				return null;
			}
			return _compositeResult ?? (_compositeResult = JsonHelper.ToObject<Dictionary<string, int>>(_pbCompositeResult));
		}
		set
		{
			_compositeResult = value;
			_pbCompositeResult = JsonHelper.ToJson(value);
		}
	}

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Protocol.CompositeInformData")]
	public List<CompositeInformData> CompositeInformData { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SOUL_STONE_MAX_COMPOSITE_TO_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<CompositeInformData>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
