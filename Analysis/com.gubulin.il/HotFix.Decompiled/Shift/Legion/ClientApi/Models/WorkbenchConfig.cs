using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WorkbenchConfig
{
	[ProtoMember(1)]
	public int WorkingStatus { get; set; }

	[ProtoMember(2)]
	public int WorkerStatus { get; set; }

	[ProtoMember(3)]
	public List<string> ProdList { get; set; }

	[ProtoMember(4)]
	public DateTimeOffset FinishProduceAt { get; set; }
}
