using System.Collections.Generic;
using Entitas;

public class UnitDeadDisappearSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	private const int RemoveAssetTick = 60;

	private const int StartAlphaTick = 15;

	private const int HideHealthBarTick = 15;

	public UnitDeadDisappearSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.DeadElapsedTick);
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if (!item.hasTags || !item.tags.value.Contains("堡垒"))
			{
				if (item.deadElapsedTick.value == 15)
				{
					item.ReplaceAlpha(0f, 45f * _contexts.input.fixedDeltaTime.value);
				}
				if (item.deadElapsedTick.value == 15)
				{
					item.isShowHealthBar = false;
				}
				if (item.hasAsset && item.deadElapsedTick.value == 60)
				{
					item.RemoveAsset();
					item.RemoveDeadElapsedTick();
				}
			}
		}
	}
}
