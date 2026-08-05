using System.Collections.Generic;

public class BattleInfo
{
	public QuickPlayReplayKeyFrame RedTeamHealthZeroFrame;

	public QuickPlayReplayKeyFrame BlueTeamHealthZeroFrame;

	public QuickPlayReplayKeyFrame RedTeamHealthMaxFrame;

	public QuickPlayReplayKeyFrame BlueTeamHealthMaxFrame;

	public Dictionary<int, int> Frame_SubLevelIndexRecord = new Dictionary<int, int>();

	public Dictionary<int, int> Frame_SubLevelWinnerRecord = new Dictionary<int, int>();
}
