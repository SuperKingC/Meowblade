using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetGvGMode3ShipTemporaryData : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string jsonShipTemporaryData;

		public GvGMode3ShipTemporaryData ShipTemporaryData
		{
			get
			{
				return JsonHelper.ToObject<GvGMode3ShipTemporaryData>(jsonShipTemporaryData);
			}
			set
			{
				jsonShipTemporaryData = JsonHelper.ToJson(value);
			}
		}
	}

	public C2S_GetGvGMode3ShipTemporaryData()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3ShipTemporaryData;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
