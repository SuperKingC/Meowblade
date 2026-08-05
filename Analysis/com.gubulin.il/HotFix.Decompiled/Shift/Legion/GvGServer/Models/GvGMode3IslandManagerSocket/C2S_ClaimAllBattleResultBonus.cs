using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ClaimAllBattleResultBonus : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NoStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_StorehouseCurValueChanges;

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

	public C2S_ClaimAllBattleResultBonus()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ClaimAllBattleResultBonus;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
