using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol.Building;

[ProtoContract]
public class ProduceState
{
	public bool UIFinish = false;

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] CurProduceRecords;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public StockChangeRecord[] CurCostRecords;

	[ProtoMember(5)]
	public long ProduceStartAt;

	[ProtoMember(6)]
	public long ProduceEndAt;

	[ProtoMember(1)]
	public string BuildingType { get; set; }

	[ProtoMember(2)]
	public int WorkbenchIndex { get; set; }

	[ProtoMember(7)]
	public int WorkerStatus { get; set; }

	[ProtoMember(8)]
	public int ProduceStatus { get; set; }

	[ProtoMember(9)]
	public int CurStock { get; set; }
}
