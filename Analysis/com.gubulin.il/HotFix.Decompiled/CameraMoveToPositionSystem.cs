using System.Collections.Generic;
using Entitas;
using GameMaths;

public class CameraMoveToPositionSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public CameraMoveToPositionSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Camera, GameMatcher.CameraMoveToPosition));
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			Vector3 value = item.cameraMoveToPosition.value;
			float num = Mathf.Min(item.cameraMoveToPositionElapsedTime.value / item.cameraMoveToPositionDuration.value, 1f);
			Vector3 newValue = Vector3.Lerp(item.position.value, value, num);
			item.ReplacePosition(newValue);
			item.cameraMoveToPositionElapsedTime.value += _contexts.input.deltaTime.value;
			if (num >= 1f)
			{
				item.RemoveCameraMoveToPosition();
				item.RemoveCameraMoveToPositionDuration();
				item.RemoveCameraMoveToPositionElapsedTime();
			}
		}
	}
}
