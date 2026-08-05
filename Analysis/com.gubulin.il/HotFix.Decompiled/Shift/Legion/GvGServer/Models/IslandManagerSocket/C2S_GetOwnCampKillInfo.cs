using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_GetOwnCampKillInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int CampId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string Info;

		public Dictionary<int, int> GetUserKillInfo()
		{
			if (string.IsNullOrEmpty(Info))
			{
				return null;
			}
			return JsonHelper.ToObject<Dictionary<int, int>>(Info);
		}
	}

	public C2S_GetOwnCampKillInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetOwnCampKillInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
