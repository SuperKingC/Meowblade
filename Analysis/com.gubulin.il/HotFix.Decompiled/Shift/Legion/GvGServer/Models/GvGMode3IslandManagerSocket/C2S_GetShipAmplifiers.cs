using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipAmplifiers : SocketManager.BaseSocketPackageBodyContext
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
		public string jsonAmplifiers;

		public Dictionary<int, int> Amplifiers
		{
			get
			{
				return JsonHelper.ToObject<Dictionary<int, int>>(jsonAmplifiers);
			}
			set
			{
				jsonAmplifiers = JsonHelper.ToJson(value);
			}
		}
	}

	public C2S_GetShipAmplifiers()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetShipAmplifiers;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
