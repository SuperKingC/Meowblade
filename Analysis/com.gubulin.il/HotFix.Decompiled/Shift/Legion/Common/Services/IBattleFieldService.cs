using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public interface IBattleFieldService : IService, IAnyBattleConfigListener, IAnySubLevelWinnerListener, IAnyBattleWaveTimeLeftListener, IAnySceneLoadedListener, IAnyBattleFieldLevelListener, IAnyFormationUnitsListener, IAnyCurrentFormationListener, IAnyWinnerListener, IAnyBattleFieldSubLevelIndexListener
{
	int CurrentLevelIndex { get; }

	Level CurrentLevel { get; }

	Level Level { get; set; }

	string LevelFormationContext { get; }

	void ClearBattleConfig();

	void ClearUnits(Team team = Team.None);

	void EnterNextLevel();

	void Destroy(GameEntity entity);

	void CheckStoryPlayList(string storyId = null);

	void INTERNAL_RESET(bool showStrategyReminder = false);

	void QuickBattle_OnAnyBattleFieldLevel(Level level);

	void GetRankBattleResult();

	void ProcessRankBattleResult(GetRankBattleResultResponse response, string battleId);

	void GetBattleResult(bool try_again = true);

	void ProcessBattleResult(GetBattleResultResponse response, string battleId);

	void ClearAllGameObject();
}
