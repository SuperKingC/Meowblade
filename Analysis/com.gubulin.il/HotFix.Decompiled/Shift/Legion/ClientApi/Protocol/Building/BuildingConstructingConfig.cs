using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Building;

[ProtoContract]
public class BuildingConstructingConfig
{
	public string BuildingType;

	public long StartTime;

	public long EndTime;

	public int UpgradeTo;

	public int Workers;

	public Dictionary<long, int> History;
}
