using Shift.Legion.Common.Models;

public interface IAnyBattleConfigListener
{
	void OnAnyBattleConfig(ConfigEntity entity, BattleConfig red, BattleConfig blue, float battleFieldLength);
}
