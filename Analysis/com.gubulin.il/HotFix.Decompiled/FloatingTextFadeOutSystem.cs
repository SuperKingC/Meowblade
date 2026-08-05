using System.Collections.Generic;
using Entitas;
using GameMaths;

public class FloatingTextFadeOutSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _group;

	private List<GameEntity> _buffer;

	public FloatingTextFadeOutSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.FloatingText);
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			Vector3 value = item.position.value;
			item.ReplacePosition(new Vector3(value.x, value.y + 0.02f, value.z));
			item.ReplaceFloatingTextAlpha(item.floatingTextAlpha.value - 0.02f);
		}
	}
}
