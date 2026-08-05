using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class AddEnterMarkToUnitsCommandExecutor
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public AddEnterMarkToUnitsCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.AiObject, GameMatcher.PortalId));
		_buffer = new List<GameEntity>();
	}

	public void Prepare()
	{
		_group.GetEntities(_buffer);
	}

	public void Execute(AddEnterMarkToUnitsCommand cmd)
	{
		Team team = cmd.team;
		int portalId = cmd.portalId;
		foreach (GameEntity item in _buffer)
		{
			if (item.hasTeam && item.team.value == team && item.portalId.value == portalId && !item.isDead)
			{
				_contexts.Service<ICreateUnitService>().CreateParticleAtTargetBone(-1, "magiczone_yellow", item.id.value, item.id.value, 1000, 0.29999998f, "floor");
			}
		}
	}
}
