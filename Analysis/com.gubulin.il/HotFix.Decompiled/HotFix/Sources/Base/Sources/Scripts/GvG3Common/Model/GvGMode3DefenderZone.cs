using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class GvGMode3DefenderZone
{
	public List<GvGMode3DefenderZoneNpc> Boss { get; set; }

	public List<GvGMode3DefenderZoneNpc> Normal { get; set; }

	public int NPCReborn { get; set; }

	public int NPCRecovery { get; set; }

	public int NPCRebellion { get; set; }

	public int NPCRebellionMax { get; set; }

	public int ProtectedPeriod { get; set; }
}
