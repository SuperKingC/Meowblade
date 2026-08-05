using System.Collections.Generic;

public class QuickPlayReplayFrame
{
	public int frame_index;

	public Dictionary<int, UnitShowInfo> Dict_UnitShowInfo;

	public float redTeamCurHealth = -1f;

	public float redTeamTotalHealth = -1f;

	public float blueTeamCurHealth = -1f;

	public float blueTeamTotalHealth = -1f;
}
