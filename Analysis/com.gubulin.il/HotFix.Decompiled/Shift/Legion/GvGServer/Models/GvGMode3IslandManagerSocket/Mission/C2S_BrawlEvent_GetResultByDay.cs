using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_GetResultByDay : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Day;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string jsonResult;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3ChatRecord")]
		public List<GvGMode3ChatRecord> DailyCampRankInfo;

		private List<BrawlCampRankInfos> _rankInfos;

		public List<BrawlCampRankInfos> RankInfos
		{
			get
			{
				if (_rankInfos == null && DailyCampRankInfo != null)
				{
					_rankInfos = DailyCampRankInfo.Select((GvGMode3ChatRecord info) => GvGMode3MessageConfigHelper.ParseBrawlCampRankInfos(info.MessageToShow)).ToList();
				}
				return _rankInfos;
			}
		}
	}

	public C2S_BrawlEvent_GetResultByDay()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_GetResultByDay;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
