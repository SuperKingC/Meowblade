using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class S2C_Purification : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> AllPurified { get; set; } = new List<RItem>();

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> NotPurified { get; set; } = new List<RItem>();

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> Cost { get; set; }

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> StorehouseChanged { get; set; } = new List<RItem>();

		public ePurificationResult GetUiResultState()
		{
			bool flag = AllPurified != null && AllPurified.Count > 0;
			bool flag2 = NotPurified != null && NotPurified.Count > 0;
			if (flag && flag2)
			{
				return ePurificationResult.HasNotPurified;
			}
			return (!flag) ? ePurificationResult.AllNotPurified : ePurificationResult.AllPurified;
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public enum ePurificationResult
	{
		AllPurified,
		HasNotPurified,
		AllNotPurified
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_Purification()
	{
		base.PackageId = SocketManager.ePackageId.S2C_Purification;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
