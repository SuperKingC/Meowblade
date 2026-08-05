using System;
using System.Collections.Generic;
using Entitas;
using GameMaths;
using ObjectPool;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public class CreateUnitService : Service, ICreateUnitService, IService
{
	private readonly IStagingService _stagingService;

	public CreateUnitService(Contexts contexts)
		: base(contexts)
	{
		_stagingService = contexts.Service<IStagingService>();
	}

	public GameEntity CreateSoldier(int parentViewId, GameEntityData data, Team team, int portalId, int portalUnitIndex, int portalUnitTotal, float visionRadius)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (data == null)
		{
			return null;
		}
		Vector2 stagingPoint = _stagingService.GetStagingPoint(team, portalId, data.Radius, portalUnitIndex, portalUnitTotal);
		GameEntity gameEntity = CreateSoldier(parentViewId, data, team, VectorHelper.ToVector3(stagingPoint, 0f), visionRadius);
		gameEntity.ReplacePortalId(portalId);
		gameEntity.ReplacePortalUnitIndex(portalUnitIndex);
		return gameEntity;
	}

	public GameEntity CreateSoldier(int parentViewId, GameEntityData data, Team team, Vector3 position, float visionRadius)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		GameEntity gameEntity = CreateUnit(data.Identifier, team, position, (team == Team.Red) ? RotationHelper.Right : RotationHelper.Left, data);
		gameEntity.ReplaceParentId(parentViewId);
		gameEntity.ReplacePortalId(-1);
		gameEntity.ReplacePortalUnitIndex(-1);
		return gameEntity;
	}

	public int CreateParticleAtTargetBone(int parentViewId, string particle, int sourceId, int targetId, int duration = -1, float scale = 1f, string bone = "", bool follow = true, bool autoSize = false, string audioFx = null, int audioVolume = 100, bool audioLoop = false)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(particle))
		{
			return -1;
		}
		GameEntity entity = base.Contexts.GetEntity(sourceId);
		GameEntity entityWithId = base.Contexts.game.GetEntityWithId(targetId);
		if (entityWithId == null || !((Entity)entityWithId).isEnabled || entity == null || !((Entity)entity).isEnabled)
		{
			return -1;
		}
		GetClosestGroupSubEntity(entity, entityWithId, out var _, out var subTargetEntity);
		GameEntity gameEntity = CreateParticle(parentViewId, particle, duration, scale, audioFx, audioVolume, audioLoop);
		if (duration == -1)
		{
			gameEntity.isParticleLiveWithOwner = true;
		}
		if (subTargetEntity.hasSkeleton)
		{
			gameEntity.ReplacePosition(subTargetEntity.skeleton.value.GetBonePosition(bone));
		}
		else if (subTargetEntity.hasPosition)
		{
			gameEntity.ReplacePosition(subTargetEntity.position.value);
		}
		gameEntity.ReplaceGroupTargetId(targetId);
		gameEntity.ReplaceTargetId(subTargetEntity.id.value);
		gameEntity.ReplaceOwnerId(targetId);
		if (!string.IsNullOrEmpty(bone))
		{
			gameEntity.ReplaceBoneName(bone);
		}
		gameEntity.isParticleFollowTarget = follow;
		gameEntity.isParticleFollowTargetScale = autoSize;
		return gameEntity.id.value;
	}

	private void GetClosestGroupSubEntity(GameEntity source, GameEntity target, out GameEntity subSourceEntity, out GameEntity subTargetEntity)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		subSourceEntity = source;
		subTargetEntity = target;
		if (source == null || target == null || source.id.value == target.id.value)
		{
			return;
		}
		PooledList<GameEntity> groupUnits = GetGroupUnits(source);
		PooledList<GameEntity> groupUnits2 = GetGroupUnits(target);
		float num = float.MaxValue;
		foreach (GameEntity item in (List<GameEntity>)(object)groupUnits)
		{
			foreach (GameEntity item2 in (List<GameEntity>)(object)groupUnits2)
			{
				Vector3 val = item.position.value - item2.position.value;
				float sqrMagnitude = ((Vector3)(ref val)).sqrMagnitude;
				if (!(sqrMagnitude >= num))
				{
					num = sqrMagnitude;
					subSourceEntity = item;
					subTargetEntity = item2;
				}
			}
		}
		groupUnits.UnSpawn();
		groupUnits2.UnSpawn();
	}

	private PooledList<GameEntity> GetGroupUnits(GameEntity entity)
	{
		PooledList<GameEntity> val = ObjectPool<PooledList<GameEntity>>.Spawn((Func<PooledList<GameEntity>>)(() => new PooledList<GameEntity>()));
		if (entity.hasGroupUnits)
		{
			PooledList<int> value = entity.groupUnits.value;
			foreach (int item in (List<int>)(object)value)
			{
				GameEntity entity2 = base.Contexts.GetEntity(item);
				if (entity2 != null)
				{
					((List<GameEntity>)(object)val).Add(entity2);
				}
			}
		}
		else
		{
			((List<GameEntity>)(object)val).Add(entity);
		}
		return val;
	}

	public GameEntity CreateParticle(int parentViewId, string particle, int duration = -1, float scale = 1f, string audioFx = null, int audioVolume = 100, bool audioLoop = false)
	{
		GameEntity gameEntity = ((Context<GameEntity>)base.Contexts.game).CreateEntity();
		gameEntity.ReplaceCreationTick(base.Contexts.input.tick.value);
		if (duration > 0)
		{
			gameEntity.ReplaceDuration((float)duration / 1000f);
			gameEntity.ReplaceElapsedTime(0f);
		}
		gameEntity.ReplaceParentId(parentViewId);
		gameEntity.ReplaceName(particle);
		gameEntity.ReplaceParticleState(ParticleState.Init);
		gameEntity.ReplaceAsset(particle);
		gameEntity.ReplaceParticleBaseScale(scale);
		gameEntity.ReplaceScale(scale);
		gameEntity.isVisible = false;
		gameEntity.isGameObject = true;
		if (string.IsNullOrEmpty(particle))
		{
			gameEntity.isDestroyed = true;
		}
		if (!gameEntity.isDestroyed && !string.IsNullOrEmpty(audioFx))
		{
			gameEntity.ReplaceAudioClipName(audioFx);
			gameEntity.ReplaceAudioVolume(audioVolume);
		}
		return gameEntity;
	}

	private GameEntity CreateUnit(string unitId, Team team, Vector3 position, Quaternion rotation, GameEntityData data)
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		GameEntity gameEntity = ((Context<GameEntity>)base.Contexts.game).CreateEntity();
		gameEntity.ReplaceCreationTick(base.Contexts.input.tick.value);
		if (team == Team.Red)
		{
			gameEntity.ReplaceAsset("RedStandardUnitModel");
		}
		else
		{
			gameEntity.ReplaceAsset("BlueStandardUnitModel");
		}
		gameEntity.ReplaceUnitIdentifier(unitId);
		gameEntity.ReplaceModel(data.ModelName);
		string[] array = (data.Skin ?? string.Empty).Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length > 1)
		{
			Random random = new Random();
			int num = random.Next(0, array.Length);
			gameEntity.ReplaceSkin(array[num]);
		}
		else
		{
			gameEntity.ReplaceSkin(data.Skin);
		}
		gameEntity.ReplaceAlpha(1f, 1.5f);
		gameEntity.ReplaceAnimation(AnimationName.idle);
		if (gameEntity.model.value == "S043")
		{
			gameEntity.ReplaceAnimationDuration(20.6f);
		}
		else if (gameEntity.model.value == "S044")
		{
			gameEntity.ReplaceAnimationDuration(4f);
		}
		else
		{
			gameEntity.ReplaceAnimationDuration(1f);
		}
		gameEntity.ReplaceUnitScale(data.ScaleRatio);
		gameEntity.ReplaceShadowScale(data.ShadowScaleRatio);
		if (!string.IsNullOrEmpty(data.MiniMapIcon))
		{
			gameEntity.ReplaceUnitImageIndicator(data.MiniMapIcon);
		}
		else
		{
			gameEntity.ReplaceUnitIndicator(new Color32((byte)1, (byte)1, (byte)1, (byte)1));
		}
		if (!string.IsNullOrEmpty(data.BaseImage))
		{
			gameEntity.ReplaceUnitBaseImage(data.BaseImage);
		}
		gameEntity.isUnit = true;
		gameEntity.isGameObject = true;
		gameEntity.isVisible = true;
		gameEntity.isAiObject = true;
		gameEntity.isShowHealthBar = false;
		gameEntity.ReplaceShowGizmos(newValue: false);
		PooledList<string> val = ObjectPool<PooledList<string>>.Spawn((Func<PooledList<string>>)(() => new PooledList<string>()));
		gameEntity.ReplaceTags((List<string>)(object)val);
		((List<string>)(object)val).Add(team.ToString());
		if (!((List<string>)(object)val).Contains(unitId))
		{
			((List<string>)(object)val).Add(unitId);
		}
		if (data.Tags != null && data.Tags.Count > 0)
		{
			((List<string>)(object)val).AddRange((IEnumerable<string>)data.Tags);
		}
		gameEntity.ReplacePosition(position);
		gameEntity.ReplaceRotation(rotation);
		gameEntity.ReplaceTeam(team);
		gameEntity.ReplaceCollisionRadius(data.Radius);
		return gameEntity;
	}
}
