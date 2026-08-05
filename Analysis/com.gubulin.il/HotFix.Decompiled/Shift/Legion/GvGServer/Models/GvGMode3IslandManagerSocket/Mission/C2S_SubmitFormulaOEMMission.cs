using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_SubmitFormulaOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.OEMResult")]
		public OEMResult OEMResultTaker;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
		public List<RItem> TakerStorehouseChanged;

		[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItemInt")]
		public List<RItemInt> RItems_AmplifierStorageCurValueChanges;

		public Dictionary<int, int> AmplifierStorageCurValueChanges
		{
			get
			{
				return RItems_AmplifierStorageCurValueChanges.ToDict();
			}
			set
			{
				RItems_AmplifierStorageCurValueChanges = value.ToRItemList();
			}
		}
	}

	public C2S_SubmitFormulaOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_SubmitFormulaOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
