using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_ForgeAmplifier : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> RItems_StorehouseCurValueChanges;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItemInt")]
		public List<RItemInt> RItems_AmplifierStorageChanges;

		[ProtoMember(4)]
		public List<int> CriticalAmps;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> GsItems;

		[ProtoMember(6)]
		public int StockInContext;

		[ProtoMember(7, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraAmplifier")]
		public List<ForgedExtraAmplifier> ExtraAmps;

		[ProtoMember(8, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraItem")]
		public List<ForgedExtraItem> ExtraItems;

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

		public Dictionary<int, int> AmplifierStorageChanges
		{
			get
			{
				return RItems_AmplifierStorageChanges.ToDict();
			}
			set
			{
				RItems_AmplifierStorageChanges = value.ToRItemList();
			}
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_ForgeAmplifier()
	{
		base.PackageId = SocketManager.ePackageId.S2C_ForgeAmplifier;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
