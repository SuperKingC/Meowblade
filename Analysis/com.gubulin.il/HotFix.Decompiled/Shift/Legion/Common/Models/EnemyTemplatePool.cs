using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class EnemyTemplatePool
{
	public string PoolId;

	private List<EnemyTemplate> _enemyTemplates;

	public void AddTemplate(GDEEnemyTemplatePoolData data)
	{
		_enemyTemplates.Add(new EnemyTemplate
		{
			FormationId = data.BlueFormationId,
			Enemy1 = data.Enemy1,
			Enemy2 = data.Enemy2,
			Enemy3 = data.Enemy3,
			Enemy4 = data.Enemy4,
			Enemy5 = data.Enemy5,
			Enemy6 = data.Enemy6,
			Enemy7 = data.Enemy7,
			Enemy8 = data.Enemy8,
			Enemy9 = data.Enemy9,
			Enemy10 = data.Enemy10,
			Enemy11 = data.Enemy11,
			Enemy12 = data.Enemy12,
			Number1 = data.Number1,
			Number2 = data.Number2,
			Number3 = data.Number3,
			Number4 = data.Number4,
			Number5 = data.Number5,
			Number6 = data.Number6,
			Number7 = data.Number7,
			Number8 = data.Number8,
			Number9 = data.Number9,
			Number10 = data.Number10,
			Number11 = data.Number11,
			Number12 = data.Number12
		});
	}

	public EnemyTemplate GetEnemyTemplate(GameManagers managers)
	{
		if (_enemyTemplates.Count < 1)
		{
			return null;
		}
		return _enemyTemplates[managers.RandomManager.Int(0, _enemyTemplates.Count)];
	}
}
