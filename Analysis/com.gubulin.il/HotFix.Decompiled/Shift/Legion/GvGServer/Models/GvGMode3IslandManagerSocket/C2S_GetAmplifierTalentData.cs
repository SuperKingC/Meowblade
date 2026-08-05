using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetAmplifierTalentData : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.RealTimeAmplifierTalentModel")]
		public RealTimeAmplifierTalentModel Model;
	}

	public C2S_GetAmplifierTalentData()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetAmplifierTalentData;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
