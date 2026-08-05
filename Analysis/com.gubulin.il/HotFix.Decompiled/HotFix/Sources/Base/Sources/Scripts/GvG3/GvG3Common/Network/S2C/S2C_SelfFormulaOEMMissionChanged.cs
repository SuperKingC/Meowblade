using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2C_SelfFormulaOEMMissionChanged : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.FormulaOEMMissionsSelfRecord")]
		public FormulaOEMMissionsSelfRecord ChangedMission;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_SelfFormulaOEMMissionChanged()
	{
		base.PackageId = SocketManager.ePackageId.S2C_SelfFormulaOEMMissionChanged;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		Request obj = (Request)base.Req;
		OnPushEvent?.Invoke(obj);
	}
}
