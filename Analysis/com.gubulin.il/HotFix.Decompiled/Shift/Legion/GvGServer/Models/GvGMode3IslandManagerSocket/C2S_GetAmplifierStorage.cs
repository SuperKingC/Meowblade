using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetAmplifierStorage : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2)]
		public string jsonAmplifierStorage;

		[ProtoMember(3)]
		public string jsonLoadedAmplifiers;

		[ProtoMember(4)]
		public List<string> HasUnlockAmp;

		public Dictionary<int, int> AmplifierStorage
		{
			get
			{
				return JsonHelper.ToObject<Dictionary<int, int>>(jsonAmplifierStorage);
			}
			set
			{
				jsonAmplifierStorage = JsonHelper.ToJson(value);
			}
		}

		public Dictionary<int, int> LoadedAmplifiers
		{
			get
			{
				return JsonHelper.ToObject<Dictionary<int, int>>(jsonLoadedAmplifiers);
			}
			set
			{
				jsonLoadedAmplifiers = JsonHelper.ToJson(value);
			}
		}
	}

	public C2S_GetAmplifierStorage()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetAmplifierStorage;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
