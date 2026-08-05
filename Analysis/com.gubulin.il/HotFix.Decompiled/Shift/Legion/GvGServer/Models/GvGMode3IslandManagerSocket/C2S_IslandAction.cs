using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_IslandAction : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int StartId;

		[ProtoMember(3)]
		public int EndId;

		[ProtoMember(4)]
		public int Action;

		[ProtoMember(5)]
		public string ActionData;

		[ProtoMember(6)]
		public int NextAction;

		[ProtoMember(7)]
		public string NextActionData;

		public eIslandAction ActionEnum
		{
			get
			{
				return (eIslandAction)Action;
			}
			set
			{
				Action = (int)value;
			}
		}

		public eIslandAction NextActionEnum
		{
			get
			{
				return (eIslandAction)NextAction;
			}
			set
			{
				NextAction = (int)value;
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_IslandAction()
	{
		base.PackageId = SocketManager.ePackageId.C2S_IslandAction;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
