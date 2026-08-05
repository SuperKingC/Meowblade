using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_GvGStorehouseChange : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_StorehouseCurValueChanges;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_RewardItems;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.TalentRItem")]
		public List<TalentRItem> TalentRItems;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_Amplifiers;

		public Dictionary<string, int> StorehouseCurValueChanges
		{
			get
			{
				return RItems_StorehouseCurValueChanges.ToDict();
			}
			set
			{
				RItems_StorehouseCurValueChanges = value.ToRItemList();
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_GvGStorehouseChange()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GvGStorehouseChange;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
