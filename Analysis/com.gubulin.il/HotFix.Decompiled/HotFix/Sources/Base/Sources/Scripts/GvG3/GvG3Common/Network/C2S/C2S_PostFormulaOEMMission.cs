using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;

[ProtoContract]
public class C2S_PostFormulaOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int AmpIdx;

		[ProtoMember(2)]
		public int Cnt;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_PostFormulaOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_PostFormulaOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
