using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Enums;

public class ProjectileMoveSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _projectileGroup;

	private List<GameEntity> _projectileBuffer;

	public ProjectileMoveSystem(Contexts contexts)
		: base(contexts)
	{
		_projectileGroup = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Projectile, GameMatcher.ProjectileFlying, GameMatcher.ProjectileMoveType, GameMatcher.Position));
		_projectileBuffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		List<GameEntity> entities = _projectileGroup.GetEntities(_projectileBuffer);
		foreach (GameEntity item in entities)
		{
			if (!item.hasTargetId || item.hasTargetPosition)
			{
				if (!item.hasStartPosition)
				{
					item.ReplaceStartPosition(item.position.value);
				}
				Vector3 value = item.position.value;
				switch (item.projectileMoveType.value)
				{
				case ProjectileMoveType.Blink:
					BlinkMove(item);
					break;
				case ProjectileMoveType.Linear:
					LinearMove(item);
					break;
				case ProjectileMoveType.Parabola:
					ParabolaMove(item);
					break;
				case ProjectileMoveType.Custom:
					CustomMove(item);
					break;
				}
				Vector3 value2 = item.position.value;
				if (value.x < value2.x)
				{
					item.ReplaceFaceDirection(FaceDirection.Right);
				}
				else if (value.x > value2.x)
				{
					item.ReplaceFaceDirection(FaceDirection.Left);
				}
			}
		}
	}

	private void BlinkMove(GameEntity projectile)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		projectile.ReplacePosition(projectile.targetPosition.value);
	}

	private void LinearMove(GameEntity projectile)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		Vector3 value = projectile.targetPosition.value;
		Vector3 val = Vector3.MoveTowards(projectile.position.value, value, projectile.moveSpeed.value * _contexts.input.fixedDeltaTime.value);
		projectile.ReplacePosition(val);
		Vector3 val2 = value - val;
		if (((Vector3)(ref val2)).sqrMagnitude > 0.001f)
		{
			projectile.ReplaceRotation(Quaternion.LookRotation(val2, Vector3.up));
		}
	}

	private void ParabolaMove(GameEntity projectile)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		Vector3 value = projectile.position.value;
		Vector3 value2 = projectile.startPosition.value;
		Vector3 value3 = projectile.targetPosition.value;
		float num = VectorHelper.Distance2(value2, value3) / projectile.moveSpeed.value;
		float value4 = projectile.elapsedTime.value;
		Vector3 val = CalcParabolaPosition(value2, value3, projectile.projectileRatio.value, value4 / num);
		projectile.ReplacePosition(val);
		Vector3 val2 = val - value;
		if (((Vector3)(ref val2)).sqrMagnitude > float.Epsilon)
		{
			projectile.ReplaceRotation(Quaternion.LookRotation(val2, Vector3.up));
		}
	}

	private static Vector3 CalcParabolaPosition(Vector3 startPos, Vector3 endPos, float ratio, float t)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		t = Mathf.Max(0f, Mathf.Min(1f, t));
		Vector2 val = VectorHelper.ToVector2(endPos) - VectorHelper.ToVector2(startPos);
		float magnitude = ((Vector2)(ref val)).magnitude;
		float num = endPos.y - startPos.y;
		float num2 = magnitude * ratio;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = magnitude / 2f;
		float num6 = num2;
		float num7 = magnitude;
		float num8 = 0f;
		float num9 = ((num8 - num4) * (num3 + num5) - (num3 + num7) * (num6 - num4)) / ((num7 * num7 - num3 * num3) * (num3 + num5) + (num3 * num3 - num5 * num5) * (num3 + num7));
		float num10 = (num6 - num4 + num9 * (num3 * num3 - num5 * num5)) / (num3 + num5);
		float num11 = num4 - num9 * num3 * num3 - num10 * num3;
		float num12 = magnitude * t;
		float num13 = num9 * num12 * num12 + num10 * num12 + num11;
		Vector2 val2 = ((Vector2)(ref val)).normalized * num12;
		return startPos + new Vector3(val2.x, num13 + num * t, val2.y);
	}

	private static void CustomMove(GameEntity projectile)
	{
	}
}
