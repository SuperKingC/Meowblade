using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Entitas;
using GameMaths;
using ObjectPool;
using Shift.Legion.Common.Enums;

public static class ScriptApi
{
	public static int CreateTimer(float duration, Action callback, int repeat = 1)
	{
		return CreateTimer(Contexts.sharedInstance, duration, callback, repeat);
	}

	public static void StopTimer(int timerid)
	{
		TimerEntity entityWithId = Contexts.sharedInstance.timer.GetEntityWithId(timerid);
		entityWithId.isDestroyed = true;
	}

	public static int CreateTimer(Contexts contexts, float duration, Action callback, int repeat = 1)
	{
		TimerEntity timerEntity = ((Context<TimerEntity>)contexts.timer).CreateEntity();
		timerEntity.AddRepeat(repeat);
		timerEntity.AddDuration(Math.Max(0f, duration));
		timerEntity.AddElapsedTime(0f);
		timerEntity.AddCallbackAction(callback);
		return timerEntity.id.value;
	}

	public static float GetDistanceSqr(float x1, float y1, float x2, float y2)
	{
		return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
	}

	public static float GetDistanceSqr(Vector3 pos1, Vector3 pos2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return GetDistanceSqr(pos1.x, pos1.z, pos2.x, pos2.z);
	}

	public static float GetDistanceSqr(Vector3 pos1, float x, float z)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetDistanceSqr(pos1.x, pos1.z, x, z);
	}

	public static float GetDistanceSqr(GameEntity e1, GameEntity e2)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return GetDistanceSqr(e1.position.value, e2.position.value);
	}

	public static float GetDistanceSqr(GameEntity e1, float x, float z)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetDistanceSqr(e1.position.value, x, z);
	}

	public static float GetDistanceSqr(float x, float z, GameEntity e1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetDistanceSqr(e1.position.value, x, z);
	}

	public static void ClearAllParticle(Contexts contexts, GameEntity owner)
	{
		if (owner == null)
		{
			return;
		}
		HashSet<GameEntity> entitiesWithOwnerId = contexts.game.GetEntitiesWithOwnerId(owner.id.value);
		PooledList<GameEntity> val = ObjectPool<PooledList<GameEntity>>.Spawn((Func<PooledList<GameEntity>>)(() => new PooledList<GameEntity>()));
		foreach (GameEntity item in entitiesWithOwnerId)
		{
			if (item.isParticleLiveWithOwner)
			{
				((List<GameEntity>)(object)val).Add(item);
			}
		}
		foreach (GameEntity item2 in (List<GameEntity>)(object)val)
		{
			item2.isDestroyed = true;
		}
		val.UnSpawn();
	}

	public static void CreateFloatingText(Contexts contexts, float actual, float over, bool isCritical, DamageType damageType, GameEntity target)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		Color black = Color.black;
		string text = string.Empty + FloatExtension.Truncate(actual, 2) + ((over > 0f) ? string.Format("\n{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText742"), FloatExtension.Truncate(over, 2)) : string.Empty);
		switch (damageType)
		{
		case DamageType.True:
			black = Color.white;
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText740") + text;
			break;
		default:
			if (isCritical)
			{
				text = LanguagesManager.GetDesc("CsharpCodeZhTcText741") + text;
			}
			black = (isCritical ? Color.red : Color.black);
			break;
		case DamageType.None:
			black = Color.green;
			if (isCritical)
			{
				text = LanguagesManager.GetDesc("CsharpCodeZhTcText741") + text;
			}
			break;
		}
		GameEntity gameEntity = ((Context<GameEntity>)contexts.game).CreateEntity();
		gameEntity.ReplaceParentId(-1);
		if (target.hasSkeleton)
		{
			gameEntity.ReplacePosition(target.skeleton.value.GetBonePosition("health_bar"));
		}
		else
		{
			gameEntity.ReplacePosition(target.position.value);
		}
		gameEntity.ReplaceFloatingText(Color.op_Implicit(black), text);
		gameEntity.ReplaceFloatingTextAlpha(1f);
		gameEntity.ReplaceAsset("BattleText");
		gameEntity.ReplaceDuration(1f);
		gameEntity.ReplaceElapsedTime(0f);
	}
}
