public class BattleConfig_Pos
{
	public int portalId;

	public int LevelIndex;

	public string soldier_id;

	public BattleConfig_Pos(int _LevelIndex, int _portalId, string _soldier_id)
	{
		LevelIndex = _LevelIndex;
		portalId = _portalId;
		soldier_id = _soldier_id;
	}
}
