using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ActivateTalent : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int TalentIdx;

		[ProtoMember(2)]
		public bool UseOuterTech;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public List<int> ActiveSpecialTalent;

		[ProtoMember(4)]
		public int NextAvailableResetTime;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_StorehouseCurValueChanges;

		[ProtoMember(6)]
		public int LeftOuterTechTimes;

		public Dictionary<string, int> StorehouseCurValueChanges
		{
			get
			{
				return RItems_StorehouseCurValueChanges.ToDict();
			}
			set
			{
				RItems_StorehouseCurValueChanges = value.ToRItemList();
			}
		}
	}

	public C2S_ActivateTalent()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ActivateTalent;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
