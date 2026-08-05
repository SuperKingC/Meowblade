using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_FillupSoldiers : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.GvGMode3UnitInfo")]
		public List<GvGMode3UnitInfo> On_Group;

		[ProtoMember(3, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.GvGMode3UnitInfo")]
		public List<GvGMode3UnitInfo> On_BackUpGroup;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> ChangedSoldiers;

		[ProtoMember(5)]
		public int ShipEntityId;

		[ProtoMember(6)]
		public int ReasonPackageId;

		[ProtoMember(7)]
		public bool IsFull;

		[ProtoMember(8)]
		public bool CanFillNextTime;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_FillupSoldiers()
	{
		base.PackageId = SocketManager.ePackageId.S2C_FillupSoldiers;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
