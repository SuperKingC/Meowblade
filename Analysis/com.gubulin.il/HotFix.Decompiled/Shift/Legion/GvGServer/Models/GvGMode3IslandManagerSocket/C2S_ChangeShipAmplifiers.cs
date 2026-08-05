using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ChangeShipAmplifiers : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public string jsonShipAmplifierChanges;

		public Dictionary<int, int> ShipAmplifierChanges
		{
			get
			{
				return JsonHelper.ToObject<Dictionary<int, int>>(jsonShipAmplifierChanges);
			}
			set
			{
				jsonShipAmplifierChanges = JsonHelper.ToJson(value);
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ChangeShipAmplifiers()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeShipAmplifiers;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
