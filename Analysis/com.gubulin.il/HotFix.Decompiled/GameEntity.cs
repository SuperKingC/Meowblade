using System.Collections.Generic;
using Entitas;
using GameMaths;
using ObjectPool;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using UnityEngine;

public sealed class GameEntity : Entity, IDestroyableEntity, IDestroyedEntity, IDurationEntity, IElapsedTimeEntity, IIdEntity, INameEntity, ITickElapsedTimeEntity, ITickIntervalEntity
{
	private static readonly AiObjectComponent aiObjectComponent = new AiObjectComponent();

	private static readonly AnimationInitializedComponent animationInitializedComponent = new AnimationInitializedComponent();

	private static readonly AnimatorInitedComponent animatorInitedComponent = new AnimatorInitedComponent();

	private static readonly BuildingUnitComponent buildingUnitComponent = new BuildingUnitComponent();

	private static readonly CastingAbilityComponent castingAbilityComponent = new CastingAbilityComponent();

	private static readonly DeadComponent deadComponent = new DeadComponent();

	private static readonly DestroyableComponent destroyableComponent = new DestroyableComponent();

	private static readonly DestroyedComponent destroyedComponent = new DestroyedComponent();

	private static readonly GameObjectComponent gameObjectComponent = new GameObjectComponent();

	private static readonly LoopComponent loopComponent = new LoopComponent();

	private static readonly ParticleFollowTargetComponent particleFollowTargetComponent = new ParticleFollowTargetComponent();

	private static readonly ParticleFollowTargetScaleComponent particleFollowTargetScaleComponent = new ParticleFollowTargetScaleComponent();

	private static readonly ParticleFullscreenComponent particleFullscreenComponent = new ParticleFullscreenComponent();

	private static readonly ParticleLiveWithOwnerComponent particleLiveWithOwnerComponent = new ParticleLiveWithOwnerComponent();

	private static readonly PlayerComponent playerComponent = new PlayerComponent();

	private static readonly ProjectileComponent projectileComponent = new ProjectileComponent();

	private static readonly ProjectileFlyingComponent projectileFlyingComponent = new ProjectileFlyingComponent();

	private static readonly SceneLoadedComponent sceneLoadedComponent = new SceneLoadedComponent();

	private static readonly ShadowComponent shadowComponent = new ShadowComponent();

	private static readonly ShowCastingBarComponent showCastingBarComponent = new ShowCastingBarComponent();

	private static readonly ShowHealthBarComponent showHealthBarComponent = new ShowHealthBarComponent();

	private static readonly UnitComponent unitComponent = new UnitComponent();

	private static readonly VisibleComponent visibleComponent = new VisibleComponent();

	public bool isAiObject
	{
		get
		{
			return ((Entity)this).HasComponent(0);
		}
		set
		{
			if (value == isAiObject)
			{
				return;
			}
			int num = 0;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)aiObjectComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public AlphaComponent alpha => (AlphaComponent)(object)((Entity)this).GetComponent(1);

	public bool hasAlpha => ((Entity)this).HasComponent(1);

	public AlphaListenerComponent alphaListener => (AlphaListenerComponent)(object)((Entity)this).GetComponent(2);

	public bool hasAlphaListener => ((Entity)this).HasComponent(2);

	public AnimationComponent animation => (AnimationComponent)(object)((Entity)this).GetComponent(3);

	public bool hasAnimation => ((Entity)this).HasComponent(3);

	public AnimationDurationComponent animationDuration => (AnimationDurationComponent)(object)((Entity)this).GetComponent(4);

	public bool hasAnimationDuration => ((Entity)this).HasComponent(4);

	public AnimationDurationListenerComponent animationDurationListener => (AnimationDurationListenerComponent)(object)((Entity)this).GetComponent(5);

	public bool hasAnimationDurationListener => ((Entity)this).HasComponent(5);

	public bool isAnimationInitialized
	{
		get
		{
			return ((Entity)this).HasComponent(6);
		}
		set
		{
			if (value == isAnimationInitialized)
			{
				return;
			}
			int num = 6;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)animationInitializedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public AnimationInitializedListenerComponent animationInitializedListener => (AnimationInitializedListenerComponent)(object)((Entity)this).GetComponent(7);

	public bool hasAnimationInitializedListener => ((Entity)this).HasComponent(7);

	public AnimationListenerComponent animationListener => (AnimationListenerComponent)(object)((Entity)this).GetComponent(8);

	public bool hasAnimationListener => ((Entity)this).HasComponent(8);

	public AnimationSpeedComponent animationSpeed => (AnimationSpeedComponent)(object)((Entity)this).GetComponent(9);

	public bool hasAnimationSpeed => ((Entity)this).HasComponent(9);

	public AnimatorComponent animator => (AnimatorComponent)(object)((Entity)this).GetComponent(10);

	public bool hasAnimator => ((Entity)this).HasComponent(10);

	public bool isAnimatorInited
	{
		get
		{
			return ((Entity)this).HasComponent(11);
		}
		set
		{
			if (value == isAnimatorInited)
			{
				return;
			}
			int num = 11;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)animatorInitedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public AnyAssetListenerComponent anyAssetListener => (AnyAssetListenerComponent)(object)((Entity)this).GetComponent(12);

	public bool hasAnyAssetListener => ((Entity)this).HasComponent(12);

	public AnyBattleFieldListenerComponent anyBattleFieldListener => (AnyBattleFieldListenerComponent)(object)((Entity)this).GetComponent(13);

	public bool hasAnyBattleFieldListener => ((Entity)this).HasComponent(13);

	public AnyCameraListenerComponent anyCameraListener => (AnyCameraListenerComponent)(object)((Entity)this).GetComponent(14);

	public bool hasAnyCameraListener => ((Entity)this).HasComponent(14);

	public AnyPlayerListenerComponent anyPlayerListener => (AnyPlayerListenerComponent)(object)((Entity)this).GetComponent(15);

	public bool hasAnyPlayerListener => ((Entity)this).HasComponent(15);

	public AnySceneLoadedListenerComponent anySceneLoadedListener => (AnySceneLoadedListenerComponent)(object)((Entity)this).GetComponent(16);

	public bool hasAnySceneLoadedListener => ((Entity)this).HasComponent(16);

	public AnyUnitListenerComponent anyUnitListener => (AnyUnitListenerComponent)(object)((Entity)this).GetComponent(17);

	public bool hasAnyUnitListener => ((Entity)this).HasComponent(17);

	public AssetComponent asset => (AssetComponent)(object)((Entity)this).GetComponent(18);

	public bool hasAsset => ((Entity)this).HasComponent(18);

	public AssetRemovedListenerComponent assetRemovedListener => (AssetRemovedListenerComponent)(object)((Entity)this).GetComponent(19);

	public bool hasAssetRemovedListener => ((Entity)this).HasComponent(19);

	public AudioClipNameComponent audioClipName => (AudioClipNameComponent)(object)((Entity)this).GetComponent(20);

	public bool hasAudioClipName => ((Entity)this).HasComponent(20);

	public AudioClipNameListenerComponent audioClipNameListener => (AudioClipNameListenerComponent)(object)((Entity)this).GetComponent(21);

	public bool hasAudioClipNameListener => ((Entity)this).HasComponent(21);

	public AudioComponent audio => (AudioComponent)(object)((Entity)this).GetComponent(22);

	public bool hasAudio => ((Entity)this).HasComponent(22);

	public AudioVolumeComponent audioVolume => (AudioVolumeComponent)(object)((Entity)this).GetComponent(23);

	public bool hasAudioVolume => ((Entity)this).HasComponent(23);

	public AudioVolumeListenerComponent audioVolumeListener => (AudioVolumeListenerComponent)(object)((Entity)this).GetComponent(24);

	public bool hasAudioVolumeListener => ((Entity)this).HasComponent(24);

	public BattleCostComponent battleCost => (BattleCostComponent)(object)((Entity)this).GetComponent(25);

	public bool hasBattleCost => ((Entity)this).HasComponent(25);

	public BattleFieldComponent battleField => (BattleFieldComponent)(object)((Entity)this).GetComponent(26);

	public bool hasBattleField => ((Entity)this).HasComponent(26);

	public BattleFieldXMarginComponent battleFieldXMargin => (BattleFieldXMarginComponent)(object)((Entity)this).GetComponent(27);

	public bool hasBattleFieldXMargin => ((Entity)this).HasComponent(27);

	public BattleModeComponent battleMode => (BattleModeComponent)(object)((Entity)this).GetComponent(28);

	public bool hasBattleMode => ((Entity)this).HasComponent(28);

	public BoneNameComponent boneName => (BoneNameComponent)(object)((Entity)this).GetComponent(29);

	public bool hasBoneName => ((Entity)this).HasComponent(29);

	public bool isBuildingUnit
	{
		get
		{
			return ((Entity)this).HasComponent(30);
		}
		set
		{
			if (value == isBuildingUnit)
			{
				return;
			}
			int num = 30;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)buildingUnitComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public CameraComponent camera => (CameraComponent)(object)((Entity)this).GetComponent(31);

	public bool hasCamera => ((Entity)this).HasComponent(31);

	public CameraMoveToPositionComponent cameraMoveToPosition => (CameraMoveToPositionComponent)(object)((Entity)this).GetComponent(32);

	public bool hasCameraMoveToPosition => ((Entity)this).HasComponent(32);

	public CameraMoveToPositionDurationComponent cameraMoveToPositionDuration => (CameraMoveToPositionDurationComponent)(object)((Entity)this).GetComponent(33);

	public bool hasCameraMoveToPositionDuration => ((Entity)this).HasComponent(33);

	public CameraMoveToPositionElapsedTimeComponent cameraMoveToPositionElapsedTime => (CameraMoveToPositionElapsedTimeComponent)(object)((Entity)this).GetComponent(34);

	public bool hasCameraMoveToPositionElapsedTime => ((Entity)this).HasComponent(34);

	public CastingAbilityCastTimeComponent castingAbilityCastTime => (CastingAbilityCastTimeComponent)(object)((Entity)this).GetComponent(35);

	public bool hasCastingAbilityCastTime => ((Entity)this).HasComponent(35);

	public bool isCastingAbility
	{
		get
		{
			return ((Entity)this).HasComponent(36);
		}
		set
		{
			if (value == isCastingAbility)
			{
				return;
			}
			int num = 36;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)castingAbilityComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public CastingAbilityElapsedTimeComponent castingAbilityElapsedTime => (CastingAbilityElapsedTimeComponent)(object)((Entity)this).GetComponent(37);

	public bool hasCastingAbilityElapsedTime => ((Entity)this).HasComponent(37);

	public CastingAbilityElapsedTimeListenerComponent castingAbilityElapsedTimeListener => (CastingAbilityElapsedTimeListenerComponent)(object)((Entity)this).GetComponent(38);

	public bool hasCastingAbilityElapsedTimeListener => ((Entity)this).HasComponent(38);

	public CharacterComponent character => (CharacterComponent)(object)((Entity)this).GetComponent(39);

	public bool hasCharacter => ((Entity)this).HasComponent(39);

	public CollisionRadiusComponent collisionRadius => (CollisionRadiusComponent)(object)((Entity)this).GetComponent(40);

	public bool hasCollisionRadius => ((Entity)this).HasComponent(40);

	public CollisionRadiusListenerComponent collisionRadiusListener => (CollisionRadiusListenerComponent)(object)((Entity)this).GetComponent(41);

	public bool hasCollisionRadiusListener => ((Entity)this).HasComponent(41);

	public CreationTickComponent creationTick => (CreationTickComponent)(object)((Entity)this).GetComponent(42);

	public bool hasCreationTick => ((Entity)this).HasComponent(42);

	public bool isDead
	{
		get
		{
			return ((Entity)this).HasComponent(43);
		}
		set
		{
			if (value == isDead)
			{
				return;
			}
			int num = 43;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)deadComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public DeadElapsedTickComponent deadElapsedTick => (DeadElapsedTickComponent)(object)((Entity)this).GetComponent(44);

	public bool hasDeadElapsedTick => ((Entity)this).HasComponent(44);

	public DeadListenerComponent deadListener => (DeadListenerComponent)(object)((Entity)this).GetComponent(45);

	public bool hasDeadListener => ((Entity)this).HasComponent(45);

	public bool isDestroyable
	{
		get
		{
			return ((Entity)this).HasComponent(46);
		}
		set
		{
			if (value == isDestroyable)
			{
				return;
			}
			int num = 46;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)destroyableComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isDestroyed
	{
		get
		{
			return ((Entity)this).HasComponent(47);
		}
		set
		{
			if (value == isDestroyed)
			{
				return;
			}
			int num = 47;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)destroyedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public DungeonComponent dungeon => (DungeonComponent)(object)((Entity)this).GetComponent(48);

	public bool hasDungeon => ((Entity)this).HasComponent(48);

	public DurationComponent duration => (DurationComponent)(object)((Entity)this).GetComponent(49);

	public bool hasDuration => ((Entity)this).HasComponent(49);

	public ElapsedTimeComponent elapsedTime => (ElapsedTimeComponent)(object)((Entity)this).GetComponent(50);

	public bool hasElapsedTime => ((Entity)this).HasComponent(50);

	public FaceDirectionComponent faceDirection => (FaceDirectionComponent)(object)((Entity)this).GetComponent(51);

	public bool hasFaceDirection => ((Entity)this).HasComponent(51);

	public FloatingTextAlphaComponent floatingTextAlpha => (FloatingTextAlphaComponent)(object)((Entity)this).GetComponent(52);

	public bool hasFloatingTextAlpha => ((Entity)this).HasComponent(52);

	public FloatingTextAlphaListenerComponent floatingTextAlphaListener => (FloatingTextAlphaListenerComponent)(object)((Entity)this).GetComponent(53);

	public bool hasFloatingTextAlphaListener => ((Entity)this).HasComponent(53);

	public FloatingTextComponent floatingText => (FloatingTextComponent)(object)((Entity)this).GetComponent(54);

	public bool hasFloatingText => ((Entity)this).HasComponent(54);

	public FloatingTextListenerComponent floatingTextListener => (FloatingTextListenerComponent)(object)((Entity)this).GetComponent(55);

	public bool hasFloatingTextListener => ((Entity)this).HasComponent(55);

	public FlowLightFxComponent flowLightFx => (FlowLightFxComponent)(object)((Entity)this).GetComponent(56);

	public bool hasFlowLightFx => ((Entity)this).HasComponent(56);

	public FlowLightFxListenerComponent flowLightFxListener => (FlowLightFxListenerComponent)(object)((Entity)this).GetComponent(57);

	public bool hasFlowLightFxListener => ((Entity)this).HasComponent(57);

	public FlowLightFxRemovedListenerComponent flowLightFxRemovedListener => (FlowLightFxRemovedListenerComponent)(object)((Entity)this).GetComponent(58);

	public bool hasFlowLightFxRemovedListener => ((Entity)this).HasComponent(58);

	public FxControllerComponent fxController => (FxControllerComponent)(object)((Entity)this).GetComponent(59);

	public bool hasFxController => ((Entity)this).HasComponent(59);

	public GameDestroyedListenerComponent gameDestroyedListener => (GameDestroyedListenerComponent)(object)((Entity)this).GetComponent(60);

	public bool hasGameDestroyedListener => ((Entity)this).HasComponent(60);

	public bool isGameObject
	{
		get
		{
			return ((Entity)this).HasComponent(61);
		}
		set
		{
			if (value == isGameObject)
			{
				return;
			}
			int num = 61;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)gameObjectComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public GroupSourceIdComponent groupSourceId => (GroupSourceIdComponent)(object)((Entity)this).GetComponent(62);

	public bool hasGroupSourceId => ((Entity)this).HasComponent(62);

	public GroupTargetIdComponent groupTargetId => (GroupTargetIdComponent)(object)((Entity)this).GetComponent(63);

	public bool hasGroupTargetId => ((Entity)this).HasComponent(63);

	public GroupUnitIdComponent groupUnitId => (GroupUnitIdComponent)(object)((Entity)this).GetComponent(64);

	public bool hasGroupUnitId => ((Entity)this).HasComponent(64);

	public GroupUnitsComponent groupUnits => (GroupUnitsComponent)(object)((Entity)this).GetComponent(65);

	public bool hasGroupUnits => ((Entity)this).HasComponent(65);

	public HeightComponent height => (HeightComponent)(object)((Entity)this).GetComponent(66);

	public bool hasHeight => ((Entity)this).HasComponent(66);

	public HeightListenerComponent heightListener => (HeightListenerComponent)(object)((Entity)this).GetComponent(67);

	public bool hasHeightListener => ((Entity)this).HasComponent(67);

	public IdComponent id => (IdComponent)(object)((Entity)this).GetComponent(68);

	public bool hasId => ((Entity)this).HasComponent(68);

	public LandingBoneComponent landingBone => (LandingBoneComponent)(object)((Entity)this).GetComponent(69);

	public bool hasLandingBone => ((Entity)this).HasComponent(69);

	public LaunchBoneComponent launchBone => (LaunchBoneComponent)(object)((Entity)this).GetComponent(70);

	public bool hasLaunchBone => ((Entity)this).HasComponent(70);

	public LeftTimeComponent leftTime => (LeftTimeComponent)(object)((Entity)this).GetComponent(71);

	public bool hasLeftTime => ((Entity)this).HasComponent(71);

	public LevelIdComponent levelId => (LevelIdComponent)(object)((Entity)this).GetComponent(72);

	public bool hasLevelId => ((Entity)this).HasComponent(72);

	public LevelInstComponent levelInst => (LevelInstComponent)(object)((Entity)this).GetComponent(73);

	public bool hasLevelInst => ((Entity)this).HasComponent(73);

	public bool isLoop
	{
		get
		{
			return ((Entity)this).HasComponent(74);
		}
		set
		{
			if (value == isLoop)
			{
				return;
			}
			int num = 74;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)loopComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ModelComponent model => (ModelComponent)(object)((Entity)this).GetComponent(75);

	public bool hasModel => ((Entity)this).HasComponent(75);

	public ModelListenerComponent modelListener => (ModelListenerComponent)(object)((Entity)this).GetComponent(76);

	public bool hasModelListener => ((Entity)this).HasComponent(76);

	public MoveSpeedComponent moveSpeed => (MoveSpeedComponent)(object)((Entity)this).GetComponent(77);

	public bool hasMoveSpeed => ((Entity)this).HasComponent(77);

	public MoveSpeedListenerComponent moveSpeedListener => (MoveSpeedListenerComponent)(object)((Entity)this).GetComponent(78);

	public bool hasMoveSpeedListener => ((Entity)this).HasComponent(78);

	public NameComponent name => (NameComponent)(object)((Entity)this).GetComponent(79);

	public bool hasName => ((Entity)this).HasComponent(79);

	public OwnerIdComponent ownerId => (OwnerIdComponent)(object)((Entity)this).GetComponent(80);

	public bool hasOwnerId => ((Entity)this).HasComponent(80);

	public ParabolaSpeedComponent parabolaSpeed => (ParabolaSpeedComponent)(object)((Entity)this).GetComponent(81);

	public bool hasParabolaSpeed => ((Entity)this).HasComponent(81);

	public ParentComponent parent => (ParentComponent)(object)((Entity)this).GetComponent(82);

	public bool hasParent => ((Entity)this).HasComponent(82);

	public ParentIdComponent parentId => (ParentIdComponent)(object)((Entity)this).GetComponent(83);

	public bool hasParentId => ((Entity)this).HasComponent(83);

	public ParticleBaseScaleComponent particleBaseScale => (ParticleBaseScaleComponent)(object)((Entity)this).GetComponent(84);

	public bool hasParticleBaseScale => ((Entity)this).HasComponent(84);

	public ParticleComponent particle => (ParticleComponent)(object)((Entity)this).GetComponent(85);

	public bool hasParticle => ((Entity)this).HasComponent(85);

	public bool isParticleFollowTarget
	{
		get
		{
			return ((Entity)this).HasComponent(86);
		}
		set
		{
			if (value == isParticleFollowTarget)
			{
				return;
			}
			int num = 86;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)particleFollowTargetComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isParticleFollowTargetScale
	{
		get
		{
			return ((Entity)this).HasComponent(87);
		}
		set
		{
			if (value == isParticleFollowTargetScale)
			{
				return;
			}
			int num = 87;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)particleFollowTargetScaleComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isParticleFullscreen
	{
		get
		{
			return ((Entity)this).HasComponent(88);
		}
		set
		{
			if (value == isParticleFullscreen)
			{
				return;
			}
			int num = 88;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)particleFullscreenComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ParticleFullscreenEndPositionComponent particleFullscreenEndPosition => (ParticleFullscreenEndPositionComponent)(object)((Entity)this).GetComponent(89);

	public bool hasParticleFullscreenEndPosition => ((Entity)this).HasComponent(89);

	public ParticleFullscreenLayerComponent particleFullscreenLayer => (ParticleFullscreenLayerComponent)(object)((Entity)this).GetComponent(90);

	public bool hasParticleFullscreenLayer => ((Entity)this).HasComponent(90);

	public ParticleFullscreenMoveDurationComponent particleFullscreenMoveDuration => (ParticleFullscreenMoveDurationComponent)(object)((Entity)this).GetComponent(91);

	public bool hasParticleFullscreenMoveDuration => ((Entity)this).HasComponent(91);

	public ParticleFullscreenMoveElapsedTimeComponent particleFullscreenMoveElapsedTime => (ParticleFullscreenMoveElapsedTimeComponent)(object)((Entity)this).GetComponent(92);

	public bool hasParticleFullscreenMoveElapsedTime => ((Entity)this).HasComponent(92);

	public ParticleFullscreenStartPositionComponent particleFullscreenStartPosition => (ParticleFullscreenStartPositionComponent)(object)((Entity)this).GetComponent(93);

	public bool hasParticleFullscreenStartPosition => ((Entity)this).HasComponent(93);

	public bool isParticleLiveWithOwner
	{
		get
		{
			return ((Entity)this).HasComponent(94);
		}
		set
		{
			if (value == isParticleLiveWithOwner)
			{
				return;
			}
			int num = 94;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)particleLiveWithOwnerComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ParticleStateComponent particleState => (ParticleStateComponent)(object)((Entity)this).GetComponent(95);

	public bool hasParticleState => ((Entity)this).HasComponent(95);

	public bool isPlayer
	{
		get
		{
			return ((Entity)this).HasComponent(96);
		}
		set
		{
			if (value == isPlayer)
			{
				return;
			}
			int num = 96;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)playerComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public PortalIdComponent portalId => (PortalIdComponent)(object)((Entity)this).GetComponent(97);

	public bool hasPortalId => ((Entity)this).HasComponent(97);

	public PortalUnitIndexComponent portalUnitIndex => (PortalUnitIndexComponent)(object)((Entity)this).GetComponent(98);

	public bool hasPortalUnitIndex => ((Entity)this).HasComponent(98);

	public PositionComponent position => (PositionComponent)(object)((Entity)this).GetComponent(99);

	public bool hasPosition => ((Entity)this).HasComponent(99);

	public PositionListenerComponent positionListener => (PositionListenerComponent)(object)((Entity)this).GetComponent(100);

	public bool hasPositionListener => ((Entity)this).HasComponent(100);

	public PriorityComponent priority => (PriorityComponent)(object)((Entity)this).GetComponent(101);

	public bool hasPriority => ((Entity)this).HasComponent(101);

	public bool isProjectile
	{
		get
		{
			return ((Entity)this).HasComponent(102);
		}
		set
		{
			if (value == isProjectile)
			{
				return;
			}
			int num = 102;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)projectileComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isProjectileFlying
	{
		get
		{
			return ((Entity)this).HasComponent(103);
		}
		set
		{
			if (value == isProjectileFlying)
			{
				return;
			}
			int num = 103;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)projectileFlyingComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ProjectileIdentifierComponent projectileIdentifier => (ProjectileIdentifierComponent)(object)((Entity)this).GetComponent(104);

	public bool hasProjectileIdentifier => ((Entity)this).HasComponent(104);

	public ProjectileMoveTypeComponent projectileMoveType => (ProjectileMoveTypeComponent)(object)((Entity)this).GetComponent(105);

	public bool hasProjectileMoveType => ((Entity)this).HasComponent(105);

	public ProjectileRatioComponent projectileRatio => (ProjectileRatioComponent)(object)((Entity)this).GetComponent(106);

	public bool hasProjectileRatio => ((Entity)this).HasComponent(106);

	public RotationComponent rotation => (RotationComponent)(object)((Entity)this).GetComponent(107);

	public bool hasRotation => ((Entity)this).HasComponent(107);

	public RotationListenerComponent rotationListener => (RotationListenerComponent)(object)((Entity)this).GetComponent(108);

	public bool hasRotationListener => ((Entity)this).HasComponent(108);

	public ScaleComponent scale => (ScaleComponent)(object)((Entity)this).GetComponent(109);

	public bool hasScale => ((Entity)this).HasComponent(109);

	public ScaleListenerComponent scaleListener => (ScaleListenerComponent)(object)((Entity)this).GetComponent(110);

	public bool hasScaleListener => ((Entity)this).HasComponent(110);

	public SceneArgumentsComponent sceneArguments => (SceneArgumentsComponent)(object)((Entity)this).GetComponent(111);

	public bool hasSceneArguments => ((Entity)this).HasComponent(111);

	public bool isSceneLoaded
	{
		get
		{
			return ((Entity)this).HasComponent(112);
		}
		set
		{
			if (value == isSceneLoaded)
			{
				return;
			}
			int num = 112;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)sceneLoadedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public SceneNameComponent sceneName => (SceneNameComponent)(object)((Entity)this).GetComponent(113);

	public bool hasSceneName => ((Entity)this).HasComponent(113);

	public bool isShadow
	{
		get
		{
			return ((Entity)this).HasComponent(114);
		}
		set
		{
			if (value == isShadow)
			{
				return;
			}
			int num = 114;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)shadowComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ShadowScaleComponent shadowScale => (ShadowScaleComponent)(object)((Entity)this).GetComponent(115);

	public bool hasShadowScale => ((Entity)this).HasComponent(115);

	public ShadowScaleListenerComponent shadowScaleListener => (ShadowScaleListenerComponent)(object)((Entity)this).GetComponent(116);

	public bool hasShadowScaleListener => ((Entity)this).HasComponent(116);

	public bool isShowCastingBar
	{
		get
		{
			return ((Entity)this).HasComponent(117);
		}
		set
		{
			if (value == isShowCastingBar)
			{
				return;
			}
			int num = 117;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)showCastingBarComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ShowCastingBarListenerComponent showCastingBarListener => (ShowCastingBarListenerComponent)(object)((Entity)this).GetComponent(118);

	public bool hasShowCastingBarListener => ((Entity)this).HasComponent(118);

	public ShowCastingBarRemovedListenerComponent showCastingBarRemovedListener => (ShowCastingBarRemovedListenerComponent)(object)((Entity)this).GetComponent(119);

	public bool hasShowCastingBarRemovedListener => ((Entity)this).HasComponent(119);

	public ShowGizmosComponent showGizmos => (ShowGizmosComponent)(object)((Entity)this).GetComponent(120);

	public bool hasShowGizmos => ((Entity)this).HasComponent(120);

	public ShowGizmosListenerComponent showGizmosListener => (ShowGizmosListenerComponent)(object)((Entity)this).GetComponent(121);

	public bool hasShowGizmosListener => ((Entity)this).HasComponent(121);

	public bool isShowHealthBar
	{
		get
		{
			return ((Entity)this).HasComponent(122);
		}
		set
		{
			if (value == isShowHealthBar)
			{
				return;
			}
			int num = 122;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)showHealthBarComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public ShowHealthBarListenerComponent showHealthBarListener => (ShowHealthBarListenerComponent)(object)((Entity)this).GetComponent(123);

	public bool hasShowHealthBarListener => ((Entity)this).HasComponent(123);

	public ShowHealthBarRemovedListenerComponent showHealthBarRemovedListener => (ShowHealthBarRemovedListenerComponent)(object)((Entity)this).GetComponent(124);

	public bool hasShowHealthBarRemovedListener => ((Entity)this).HasComponent(124);

	public SizeComponent size => (SizeComponent)(object)((Entity)this).GetComponent(125);

	public bool hasSize => ((Entity)this).HasComponent(125);

	public SkeletonComponent skeleton => (SkeletonComponent)(object)((Entity)this).GetComponent(126);

	public bool hasSkeleton => ((Entity)this).HasComponent(126);

	public SkeletonListenerComponent skeletonListener => (SkeletonListenerComponent)(object)((Entity)this).GetComponent(127);

	public bool hasSkeletonListener => ((Entity)this).HasComponent(127);

	public SkinComponent skin => (SkinComponent)(object)((Entity)this).GetComponent(128);

	public bool hasSkin => ((Entity)this).HasComponent(128);

	public SkinListenerComponent skinListener => (SkinListenerComponent)(object)((Entity)this).GetComponent(129);

	public bool hasSkinListener => ((Entity)this).HasComponent(129);

	public SourceIdComponent sourceId => (SourceIdComponent)(object)((Entity)this).GetComponent(130);

	public bool hasSourceId => ((Entity)this).HasComponent(130);

	public SpecialFxComponent specialFx => (SpecialFxComponent)(object)((Entity)this).GetComponent(131);

	public bool hasSpecialFx => ((Entity)this).HasComponent(131);

	public SpecialFxListenerComponent specialFxListener => (SpecialFxListenerComponent)(object)((Entity)this).GetComponent(132);

	public bool hasSpecialFxListener => ((Entity)this).HasComponent(132);

	public SpecialFxRemovedListenerComponent specialFxRemovedListener => (SpecialFxRemovedListenerComponent)(object)((Entity)this).GetComponent(133);

	public bool hasSpecialFxRemovedListener => ((Entity)this).HasComponent(133);

	public StartPositionComponent startPosition => (StartPositionComponent)(object)((Entity)this).GetComponent(134);

	public bool hasStartPosition => ((Entity)this).HasComponent(134);

	public TagsComponent tags => (TagsComponent)(object)((Entity)this).GetComponent(135);

	public bool hasTags => ((Entity)this).HasComponent(135);

	public TargetIdComponent targetId => (TargetIdComponent)(object)((Entity)this).GetComponent(136);

	public bool hasTargetId => ((Entity)this).HasComponent(136);

	public TargetPositionComponent targetPosition => (TargetPositionComponent)(object)((Entity)this).GetComponent(137);

	public bool hasTargetPosition => ((Entity)this).HasComponent(137);

	public TargetPositionListenerComponent targetPositionListener => (TargetPositionListenerComponent)(object)((Entity)this).GetComponent(138);

	public bool hasTargetPositionListener => ((Entity)this).HasComponent(138);

	public TeamComponent team => (TeamComponent)(object)((Entity)this).GetComponent(139);

	public bool hasTeam => ((Entity)this).HasComponent(139);

	public TickElapsedTimeComponent tickElapsedTime => (TickElapsedTimeComponent)(object)((Entity)this).GetComponent(140);

	public bool hasTickElapsedTime => ((Entity)this).HasComponent(140);

	public TickIntervalComponent tickInterval => (TickIntervalComponent)(object)((Entity)this).GetComponent(141);

	public bool hasTickInterval => ((Entity)this).HasComponent(141);

	public UnitBaseImageComponent unitBaseImage => (UnitBaseImageComponent)(object)((Entity)this).GetComponent(142);

	public bool hasUnitBaseImage => ((Entity)this).HasComponent(142);

	public UnitBaseImageListenerComponent unitBaseImageListener => (UnitBaseImageListenerComponent)(object)((Entity)this).GetComponent(143);

	public bool hasUnitBaseImageListener => ((Entity)this).HasComponent(143);

	public UnitBaseImageRemovedListenerComponent unitBaseImageRemovedListener => (UnitBaseImageRemovedListenerComponent)(object)((Entity)this).GetComponent(144);

	public bool hasUnitBaseImageRemovedListener => ((Entity)this).HasComponent(144);

	public bool isUnit
	{
		get
		{
			return ((Entity)this).HasComponent(145);
		}
		set
		{
			if (value == isUnit)
			{
				return;
			}
			int num = 145;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)unitComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public UnitIdentifierComponent unitIdentifier => (UnitIdentifierComponent)(object)((Entity)this).GetComponent(146);

	public bool hasUnitIdentifier => ((Entity)this).HasComponent(146);

	public UnitImageIndicatorComponent unitImageIndicator => (UnitImageIndicatorComponent)(object)((Entity)this).GetComponent(147);

	public bool hasUnitImageIndicator => ((Entity)this).HasComponent(147);

	public UnitImageIndicatorListenerComponent unitImageIndicatorListener => (UnitImageIndicatorListenerComponent)(object)((Entity)this).GetComponent(148);

	public bool hasUnitImageIndicatorListener => ((Entity)this).HasComponent(148);

	public UnitImageIndicatorRemovedListenerComponent unitImageIndicatorRemovedListener => (UnitImageIndicatorRemovedListenerComponent)(object)((Entity)this).GetComponent(149);

	public bool hasUnitImageIndicatorRemovedListener => ((Entity)this).HasComponent(149);

	public UnitIndicatorComponent unitIndicator => (UnitIndicatorComponent)(object)((Entity)this).GetComponent(150);

	public bool hasUnitIndicator => ((Entity)this).HasComponent(150);

	public UnitIndicatorListenerComponent unitIndicatorListener => (UnitIndicatorListenerComponent)(object)((Entity)this).GetComponent(151);

	public bool hasUnitIndicatorListener => ((Entity)this).HasComponent(151);

	public UnitIndicatorRemovedListenerComponent unitIndicatorRemovedListener => (UnitIndicatorRemovedListenerComponent)(object)((Entity)this).GetComponent(152);

	public bool hasUnitIndicatorRemovedListener => ((Entity)this).HasComponent(152);

	public UnitScaleComponent unitScale => (UnitScaleComponent)(object)((Entity)this).GetComponent(153);

	public bool hasUnitScale => ((Entity)this).HasComponent(153);

	public UnitScaleListenerComponent unitScaleListener => (UnitScaleListenerComponent)(object)((Entity)this).GetComponent(154);

	public bool hasUnitScaleListener => ((Entity)this).HasComponent(154);

	public UnitStatsComponent unitStats => (UnitStatsComponent)(object)((Entity)this).GetComponent(155);

	public bool hasUnitStats => ((Entity)this).HasComponent(155);

	public UnitStatsListenerComponent unitStatsListener => (UnitStatsListenerComponent)(object)((Entity)this).GetComponent(156);

	public bool hasUnitStatsListener => ((Entity)this).HasComponent(156);

	public ViewComponent view => (ViewComponent)(object)((Entity)this).GetComponent(157);

	public bool hasView => ((Entity)this).HasComponent(157);

	public bool isVisible
	{
		get
		{
			return ((Entity)this).HasComponent(158);
		}
		set
		{
			if (value == isVisible)
			{
				return;
			}
			int num = 158;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)visibleComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public VisibleListenerComponent visibleListener => (VisibleListenerComponent)(object)((Entity)this).GetComponent(159);

	public bool hasVisibleListener => ((Entity)this).HasComponent(159);

	public VisibleRemovedListenerComponent visibleRemovedListener => (VisibleRemovedListenerComponent)(object)((Entity)this).GetComponent(160);

	public bool hasVisibleRemovedListener => ((Entity)this).HasComponent(160);

	public void AddAlpha(float newValue, float newDuration)
	{
		int num = 1;
		AlphaComponent alphaComponent = (AlphaComponent)(object)((Entity)this).CreateComponent(num, typeof(AlphaComponent));
		alphaComponent.value = newValue;
		alphaComponent.duration = newDuration;
		((Entity)this).AddComponent(num, (IComponent)(object)alphaComponent);
	}

	public void ReplaceAlpha(float newValue, float newDuration)
	{
		int num = 1;
		AlphaComponent alphaComponent = (AlphaComponent)(object)((Entity)this).CreateComponent(num, typeof(AlphaComponent));
		alphaComponent.value = newValue;
		alphaComponent.duration = newDuration;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)alphaComponent);
	}

	public void RemoveAlpha()
	{
		((Entity)this).RemoveComponent(1);
	}

	public void AddAlphaListener(List<IAlphaListener> newValue)
	{
		int num = 2;
		AlphaListenerComponent alphaListenerComponent = (AlphaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AlphaListenerComponent));
		alphaListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)alphaListenerComponent);
	}

	public void ReplaceAlphaListener(List<IAlphaListener> newValue)
	{
		int num = 2;
		AlphaListenerComponent alphaListenerComponent = (AlphaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AlphaListenerComponent));
		alphaListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)alphaListenerComponent);
	}

	public void RemoveAlphaListener()
	{
		((Entity)this).RemoveComponent(2);
	}

	public void AddAlphaListener(IAlphaListener value)
	{
		List<IAlphaListener> list = (hasAlphaListener ? alphaListener.value : new List<IAlphaListener>());
		list.Add(value);
		ReplaceAlphaListener(list);
	}

	public void RemoveAlphaListener(IAlphaListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAlphaListener> value2 = alphaListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAlphaListener();
		}
		else
		{
			ReplaceAlphaListener(value2);
		}
	}

	public void AddAnimation(AnimationName newValue)
	{
		int num = 3;
		AnimationComponent animationComponent = (AnimationComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationComponent));
		animationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationComponent);
	}

	public void ReplaceAnimation(AnimationName newValue)
	{
		int num = 3;
		AnimationComponent animationComponent = (AnimationComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationComponent));
		animationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationComponent);
	}

	public void RemoveAnimation()
	{
		((Entity)this).RemoveComponent(3);
	}

	public void AddAnimationDuration(float newValue)
	{
		int num = 4;
		AnimationDurationComponent animationDurationComponent = (AnimationDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationDurationComponent));
		animationDurationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationDurationComponent);
	}

	public void ReplaceAnimationDuration(float newValue)
	{
		int num = 4;
		AnimationDurationComponent animationDurationComponent = (AnimationDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationDurationComponent));
		animationDurationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationDurationComponent);
	}

	public void RemoveAnimationDuration()
	{
		((Entity)this).RemoveComponent(4);
	}

	public void AddAnimationDurationListener(List<IAnimationDurationListener> newValue)
	{
		int num = 5;
		AnimationDurationListenerComponent animationDurationListenerComponent = (AnimationDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationDurationListenerComponent));
		animationDurationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationDurationListenerComponent);
	}

	public void ReplaceAnimationDurationListener(List<IAnimationDurationListener> newValue)
	{
		int num = 5;
		AnimationDurationListenerComponent animationDurationListenerComponent = (AnimationDurationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationDurationListenerComponent));
		animationDurationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationDurationListenerComponent);
	}

	public void RemoveAnimationDurationListener()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddAnimationDurationListener(IAnimationDurationListener value)
	{
		List<IAnimationDurationListener> list = (hasAnimationDurationListener ? animationDurationListener.value : new List<IAnimationDurationListener>());
		list.Add(value);
		ReplaceAnimationDurationListener(list);
	}

	public void RemoveAnimationDurationListener(IAnimationDurationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnimationDurationListener> value2 = animationDurationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnimationDurationListener();
		}
		else
		{
			ReplaceAnimationDurationListener(value2);
		}
	}

	public void AddAnimationInitializedListener(List<IAnimationInitializedListener> newValue)
	{
		int num = 7;
		AnimationInitializedListenerComponent animationInitializedListenerComponent = (AnimationInitializedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationInitializedListenerComponent));
		animationInitializedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationInitializedListenerComponent);
	}

	public void ReplaceAnimationInitializedListener(List<IAnimationInitializedListener> newValue)
	{
		int num = 7;
		AnimationInitializedListenerComponent animationInitializedListenerComponent = (AnimationInitializedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationInitializedListenerComponent));
		animationInitializedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationInitializedListenerComponent);
	}

	public void RemoveAnimationInitializedListener()
	{
		((Entity)this).RemoveComponent(7);
	}

	public void AddAnimationInitializedListener(IAnimationInitializedListener value)
	{
		List<IAnimationInitializedListener> list = (hasAnimationInitializedListener ? animationInitializedListener.value : new List<IAnimationInitializedListener>());
		list.Add(value);
		ReplaceAnimationInitializedListener(list);
	}

	public void RemoveAnimationInitializedListener(IAnimationInitializedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnimationInitializedListener> value2 = animationInitializedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnimationInitializedListener();
		}
		else
		{
			ReplaceAnimationInitializedListener(value2);
		}
	}

	public void AddAnimationListener(List<IAnimationListener> newValue)
	{
		int num = 8;
		AnimationListenerComponent animationListenerComponent = (AnimationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationListenerComponent));
		animationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationListenerComponent);
	}

	public void ReplaceAnimationListener(List<IAnimationListener> newValue)
	{
		int num = 8;
		AnimationListenerComponent animationListenerComponent = (AnimationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationListenerComponent));
		animationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationListenerComponent);
	}

	public void RemoveAnimationListener()
	{
		((Entity)this).RemoveComponent(8);
	}

	public void AddAnimationListener(IAnimationListener value)
	{
		List<IAnimationListener> list = (hasAnimationListener ? animationListener.value : new List<IAnimationListener>());
		list.Add(value);
		ReplaceAnimationListener(list);
	}

	public void RemoveAnimationListener(IAnimationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnimationListener> value2 = animationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnimationListener();
		}
		else
		{
			ReplaceAnimationListener(value2);
		}
	}

	public void AddAnimationSpeed(float newValue)
	{
		int num = 9;
		AnimationSpeedComponent animationSpeedComponent = (AnimationSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationSpeedComponent));
		animationSpeedComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animationSpeedComponent);
	}

	public void ReplaceAnimationSpeed(float newValue)
	{
		int num = 9;
		AnimationSpeedComponent animationSpeedComponent = (AnimationSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimationSpeedComponent));
		animationSpeedComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animationSpeedComponent);
	}

	public void RemoveAnimationSpeed()
	{
		((Entity)this).RemoveComponent(9);
	}

	public void AddAnimator(IAnimator newValue)
	{
		int num = 10;
		AnimatorComponent animatorComponent = (AnimatorComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimatorComponent));
		animatorComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)animatorComponent);
	}

	public void ReplaceAnimator(IAnimator newValue)
	{
		int num = 10;
		AnimatorComponent animatorComponent = (AnimatorComponent)(object)((Entity)this).CreateComponent(num, typeof(AnimatorComponent));
		animatorComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)animatorComponent);
	}

	public void RemoveAnimator()
	{
		((Entity)this).RemoveComponent(10);
	}

	public void AddAnyAssetListener(List<IAnyAssetListener> newValue)
	{
		int num = 12;
		AnyAssetListenerComponent anyAssetListenerComponent = (AnyAssetListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyAssetListenerComponent));
		anyAssetListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyAssetListenerComponent);
	}

	public void ReplaceAnyAssetListener(List<IAnyAssetListener> newValue)
	{
		int num = 12;
		AnyAssetListenerComponent anyAssetListenerComponent = (AnyAssetListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyAssetListenerComponent));
		anyAssetListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyAssetListenerComponent);
	}

	public void RemoveAnyAssetListener()
	{
		((Entity)this).RemoveComponent(12);
	}

	public void AddAnyAssetListener(IAnyAssetListener value)
	{
		List<IAnyAssetListener> list = (hasAnyAssetListener ? anyAssetListener.value : new List<IAnyAssetListener>());
		list.Add(value);
		ReplaceAnyAssetListener(list);
	}

	public void RemoveAnyAssetListener(IAnyAssetListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyAssetListener> value2 = anyAssetListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyAssetListener();
		}
		else
		{
			ReplaceAnyAssetListener(value2);
		}
	}

	public void AddAnyBattleFieldListener(List<IAnyBattleFieldListener> newValue)
	{
		int num = 13;
		AnyBattleFieldListenerComponent anyBattleFieldListenerComponent = (AnyBattleFieldListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldListenerComponent));
		anyBattleFieldListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleFieldListenerComponent);
	}

	public void ReplaceAnyBattleFieldListener(List<IAnyBattleFieldListener> newValue)
	{
		int num = 13;
		AnyBattleFieldListenerComponent anyBattleFieldListenerComponent = (AnyBattleFieldListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleFieldListenerComponent));
		anyBattleFieldListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleFieldListenerComponent);
	}

	public void RemoveAnyBattleFieldListener()
	{
		((Entity)this).RemoveComponent(13);
	}

	public void AddAnyBattleFieldListener(IAnyBattleFieldListener value)
	{
		List<IAnyBattleFieldListener> list = (hasAnyBattleFieldListener ? anyBattleFieldListener.value : new List<IAnyBattleFieldListener>());
		list.Add(value);
		ReplaceAnyBattleFieldListener(list);
	}

	public void RemoveAnyBattleFieldListener(IAnyBattleFieldListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleFieldListener> value2 = anyBattleFieldListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleFieldListener();
		}
		else
		{
			ReplaceAnyBattleFieldListener(value2);
		}
	}

	public void AddAnyCameraListener(List<IAnyCameraListener> newValue)
	{
		int num = 14;
		AnyCameraListenerComponent anyCameraListenerComponent = (AnyCameraListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraListenerComponent));
		anyCameraListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCameraListenerComponent);
	}

	public void ReplaceAnyCameraListener(List<IAnyCameraListener> newValue)
	{
		int num = 14;
		AnyCameraListenerComponent anyCameraListenerComponent = (AnyCameraListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCameraListenerComponent));
		anyCameraListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCameraListenerComponent);
	}

	public void RemoveAnyCameraListener()
	{
		((Entity)this).RemoveComponent(14);
	}

	public void AddAnyCameraListener(IAnyCameraListener value)
	{
		List<IAnyCameraListener> list = (hasAnyCameraListener ? anyCameraListener.value : new List<IAnyCameraListener>());
		list.Add(value);
		ReplaceAnyCameraListener(list);
	}

	public void RemoveAnyCameraListener(IAnyCameraListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCameraListener> value2 = anyCameraListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCameraListener();
		}
		else
		{
			ReplaceAnyCameraListener(value2);
		}
	}

	public void AddAnyPlayerListener(List<IAnyPlayerListener> newValue)
	{
		int num = 15;
		AnyPlayerListenerComponent anyPlayerListenerComponent = (AnyPlayerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyPlayerListenerComponent));
		anyPlayerListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyPlayerListenerComponent);
	}

	public void ReplaceAnyPlayerListener(List<IAnyPlayerListener> newValue)
	{
		int num = 15;
		AnyPlayerListenerComponent anyPlayerListenerComponent = (AnyPlayerListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyPlayerListenerComponent));
		anyPlayerListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyPlayerListenerComponent);
	}

	public void RemoveAnyPlayerListener()
	{
		((Entity)this).RemoveComponent(15);
	}

	public void AddAnyPlayerListener(IAnyPlayerListener value)
	{
		List<IAnyPlayerListener> list = (hasAnyPlayerListener ? anyPlayerListener.value : new List<IAnyPlayerListener>());
		list.Add(value);
		ReplaceAnyPlayerListener(list);
	}

	public void RemoveAnyPlayerListener(IAnyPlayerListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyPlayerListener> value2 = anyPlayerListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyPlayerListener();
		}
		else
		{
			ReplaceAnyPlayerListener(value2);
		}
	}

	public void AddAnySceneLoadedListener(List<IAnySceneLoadedListener> newValue)
	{
		int num = 16;
		AnySceneLoadedListenerComponent anySceneLoadedListenerComponent = (AnySceneLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnySceneLoadedListenerComponent));
		anySceneLoadedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anySceneLoadedListenerComponent);
	}

	public void ReplaceAnySceneLoadedListener(List<IAnySceneLoadedListener> newValue)
	{
		int num = 16;
		AnySceneLoadedListenerComponent anySceneLoadedListenerComponent = (AnySceneLoadedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnySceneLoadedListenerComponent));
		anySceneLoadedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anySceneLoadedListenerComponent);
	}

	public void RemoveAnySceneLoadedListener()
	{
		((Entity)this).RemoveComponent(16);
	}

	public void AddAnySceneLoadedListener(IAnySceneLoadedListener value)
	{
		List<IAnySceneLoadedListener> list = (hasAnySceneLoadedListener ? anySceneLoadedListener.value : new List<IAnySceneLoadedListener>());
		list.Add(value);
		ReplaceAnySceneLoadedListener(list);
	}

	public void RemoveAnySceneLoadedListener(IAnySceneLoadedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnySceneLoadedListener> value2 = anySceneLoadedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnySceneLoadedListener();
		}
		else
		{
			ReplaceAnySceneLoadedListener(value2);
		}
	}

	public void AddAnyUnitListener(List<IAnyUnitListener> newValue)
	{
		int num = 17;
		AnyUnitListenerComponent anyUnitListenerComponent = (AnyUnitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnitListenerComponent));
		anyUnitListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyUnitListenerComponent);
	}

	public void ReplaceAnyUnitListener(List<IAnyUnitListener> newValue)
	{
		int num = 17;
		AnyUnitListenerComponent anyUnitListenerComponent = (AnyUnitListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnitListenerComponent));
		anyUnitListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyUnitListenerComponent);
	}

	public void RemoveAnyUnitListener()
	{
		((Entity)this).RemoveComponent(17);
	}

	public void AddAnyUnitListener(IAnyUnitListener value)
	{
		List<IAnyUnitListener> list = (hasAnyUnitListener ? anyUnitListener.value : new List<IAnyUnitListener>());
		list.Add(value);
		ReplaceAnyUnitListener(list);
	}

	public void RemoveAnyUnitListener(IAnyUnitListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyUnitListener> value2 = anyUnitListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyUnitListener();
		}
		else
		{
			ReplaceAnyUnitListener(value2);
		}
	}

	public void AddAsset(string newValue)
	{
		int num = 18;
		AssetComponent assetComponent = (AssetComponent)(object)((Entity)this).CreateComponent(num, typeof(AssetComponent));
		assetComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)assetComponent);
	}

	public void ReplaceAsset(string newValue)
	{
		int num = 18;
		AssetComponent assetComponent = (AssetComponent)(object)((Entity)this).CreateComponent(num, typeof(AssetComponent));
		assetComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)assetComponent);
	}

	public void RemoveAsset()
	{
		((Entity)this).RemoveComponent(18);
	}

	public void AddAssetRemovedListener(List<IAssetRemovedListener> newValue)
	{
		int num = 19;
		AssetRemovedListenerComponent assetRemovedListenerComponent = (AssetRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AssetRemovedListenerComponent));
		assetRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)assetRemovedListenerComponent);
	}

	public void ReplaceAssetRemovedListener(List<IAssetRemovedListener> newValue)
	{
		int num = 19;
		AssetRemovedListenerComponent assetRemovedListenerComponent = (AssetRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AssetRemovedListenerComponent));
		assetRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)assetRemovedListenerComponent);
	}

	public void RemoveAssetRemovedListener()
	{
		((Entity)this).RemoveComponent(19);
	}

	public void AddAssetRemovedListener(IAssetRemovedListener value)
	{
		List<IAssetRemovedListener> list = (hasAssetRemovedListener ? assetRemovedListener.value : new List<IAssetRemovedListener>());
		list.Add(value);
		ReplaceAssetRemovedListener(list);
	}

	public void RemoveAssetRemovedListener(IAssetRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAssetRemovedListener> value2 = assetRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAssetRemovedListener();
		}
		else
		{
			ReplaceAssetRemovedListener(value2);
		}
	}

	public void AddAudioClipName(string newValue)
	{
		int num = 20;
		AudioClipNameComponent audioClipNameComponent = (AudioClipNameComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioClipNameComponent));
		audioClipNameComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)audioClipNameComponent);
	}

	public void ReplaceAudioClipName(string newValue)
	{
		int num = 20;
		AudioClipNameComponent audioClipNameComponent = (AudioClipNameComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioClipNameComponent));
		audioClipNameComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)audioClipNameComponent);
	}

	public void RemoveAudioClipName()
	{
		((Entity)this).RemoveComponent(20);
	}

	public void AddAudioClipNameListener(List<IAudioClipNameListener> newValue)
	{
		int num = 21;
		AudioClipNameListenerComponent audioClipNameListenerComponent = (AudioClipNameListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioClipNameListenerComponent));
		audioClipNameListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)audioClipNameListenerComponent);
	}

	public void ReplaceAudioClipNameListener(List<IAudioClipNameListener> newValue)
	{
		int num = 21;
		AudioClipNameListenerComponent audioClipNameListenerComponent = (AudioClipNameListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioClipNameListenerComponent));
		audioClipNameListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)audioClipNameListenerComponent);
	}

	public void RemoveAudioClipNameListener()
	{
		((Entity)this).RemoveComponent(21);
	}

	public void AddAudioClipNameListener(IAudioClipNameListener value)
	{
		List<IAudioClipNameListener> list = (hasAudioClipNameListener ? audioClipNameListener.value : new List<IAudioClipNameListener>());
		list.Add(value);
		ReplaceAudioClipNameListener(list);
	}

	public void RemoveAudioClipNameListener(IAudioClipNameListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAudioClipNameListener> value2 = audioClipNameListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAudioClipNameListener();
		}
		else
		{
			ReplaceAudioClipNameListener(value2);
		}
	}

	public void AddAudio(IAudioClip newValue)
	{
		int num = 22;
		AudioComponent audioComponent = (AudioComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioComponent));
		audioComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)audioComponent);
	}

	public void ReplaceAudio(IAudioClip newValue)
	{
		int num = 22;
		AudioComponent audioComponent = (AudioComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioComponent));
		audioComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)audioComponent);
	}

	public void RemoveAudio()
	{
		((Entity)this).RemoveComponent(22);
	}

	public void AddAudioVolume(int newValue)
	{
		int num = 23;
		AudioVolumeComponent audioVolumeComponent = (AudioVolumeComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioVolumeComponent));
		audioVolumeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)audioVolumeComponent);
	}

	public void ReplaceAudioVolume(int newValue)
	{
		int num = 23;
		AudioVolumeComponent audioVolumeComponent = (AudioVolumeComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioVolumeComponent));
		audioVolumeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)audioVolumeComponent);
	}

	public void RemoveAudioVolume()
	{
		((Entity)this).RemoveComponent(23);
	}

	public void AddAudioVolumeListener(List<IAudioVolumeListener> newValue)
	{
		int num = 24;
		AudioVolumeListenerComponent audioVolumeListenerComponent = (AudioVolumeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioVolumeListenerComponent));
		audioVolumeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)audioVolumeListenerComponent);
	}

	public void ReplaceAudioVolumeListener(List<IAudioVolumeListener> newValue)
	{
		int num = 24;
		AudioVolumeListenerComponent audioVolumeListenerComponent = (AudioVolumeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AudioVolumeListenerComponent));
		audioVolumeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)audioVolumeListenerComponent);
	}

	public void RemoveAudioVolumeListener()
	{
		((Entity)this).RemoveComponent(24);
	}

	public void AddAudioVolumeListener(IAudioVolumeListener value)
	{
		List<IAudioVolumeListener> list = (hasAudioVolumeListener ? audioVolumeListener.value : new List<IAudioVolumeListener>());
		list.Add(value);
		ReplaceAudioVolumeListener(list);
	}

	public void RemoveAudioVolumeListener(IAudioVolumeListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAudioVolumeListener> value2 = audioVolumeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAudioVolumeListener();
		}
		else
		{
			ReplaceAudioVolumeListener(value2);
		}
	}

	public void AddBattleCost(Dictionary<string, int> newValue)
	{
		int num = 25;
		BattleCostComponent battleCostComponent = (BattleCostComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleCostComponent));
		battleCostComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleCostComponent);
	}

	public void ReplaceBattleCost(Dictionary<string, int> newValue)
	{
		int num = 25;
		BattleCostComponent battleCostComponent = (BattleCostComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleCostComponent));
		battleCostComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleCostComponent);
	}

	public void RemoveBattleCost()
	{
		((Entity)this).RemoveComponent(25);
	}

	public void AddBattleField(IBattleField newValue)
	{
		int num = 26;
		BattleFieldComponent battleFieldComponent = (BattleFieldComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldComponent));
		battleFieldComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldComponent);
	}

	public void ReplaceBattleField(IBattleField newValue)
	{
		int num = 26;
		BattleFieldComponent battleFieldComponent = (BattleFieldComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldComponent));
		battleFieldComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldComponent);
	}

	public void RemoveBattleField()
	{
		((Entity)this).RemoveComponent(26);
	}

	public void AddBattleFieldXMargin(float newValue)
	{
		int num = 27;
		BattleFieldXMarginComponent battleFieldXMarginComponent = (BattleFieldXMarginComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldXMarginComponent));
		battleFieldXMarginComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleFieldXMarginComponent);
	}

	public void ReplaceBattleFieldXMargin(float newValue)
	{
		int num = 27;
		BattleFieldXMarginComponent battleFieldXMarginComponent = (BattleFieldXMarginComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleFieldXMarginComponent));
		battleFieldXMarginComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleFieldXMarginComponent);
	}

	public void RemoveBattleFieldXMargin()
	{
		((Entity)this).RemoveComponent(27);
	}

	public void AddBattleMode(BattleMode newValue)
	{
		int num = 28;
		BattleModeComponent battleModeComponent = (BattleModeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleModeComponent));
		battleModeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleModeComponent);
	}

	public void ReplaceBattleMode(BattleMode newValue)
	{
		int num = 28;
		BattleModeComponent battleModeComponent = (BattleModeComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleModeComponent));
		battleModeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleModeComponent);
	}

	public void RemoveBattleMode()
	{
		((Entity)this).RemoveComponent(28);
	}

	public void AddBoneName(string newValue)
	{
		int num = 29;
		BoneNameComponent boneNameComponent = (BoneNameComponent)(object)((Entity)this).CreateComponent(num, typeof(BoneNameComponent));
		boneNameComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)boneNameComponent);
	}

	public void ReplaceBoneName(string newValue)
	{
		int num = 29;
		BoneNameComponent boneNameComponent = (BoneNameComponent)(object)((Entity)this).CreateComponent(num, typeof(BoneNameComponent));
		boneNameComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)boneNameComponent);
	}

	public void RemoveBoneName()
	{
		((Entity)this).RemoveComponent(29);
	}

	public void AddCamera(ICamera newValue)
	{
		int num = 31;
		CameraComponent cameraComponent = (CameraComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraComponent));
		cameraComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraComponent);
	}

	public void ReplaceCamera(ICamera newValue)
	{
		int num = 31;
		CameraComponent cameraComponent = (CameraComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraComponent));
		cameraComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraComponent);
	}

	public void RemoveCamera()
	{
		((Entity)this).RemoveComponent(31);
	}

	public void AddCameraMoveToPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 32;
		CameraMoveToPositionComponent cameraMoveToPositionComponent = (CameraMoveToPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionComponent));
		cameraMoveToPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraMoveToPositionComponent);
	}

	public void ReplaceCameraMoveToPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 32;
		CameraMoveToPositionComponent cameraMoveToPositionComponent = (CameraMoveToPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionComponent));
		cameraMoveToPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraMoveToPositionComponent);
	}

	public void RemoveCameraMoveToPosition()
	{
		((Entity)this).RemoveComponent(32);
	}

	public void AddCameraMoveToPositionDuration(float newValue)
	{
		int num = 33;
		CameraMoveToPositionDurationComponent cameraMoveToPositionDurationComponent = (CameraMoveToPositionDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionDurationComponent));
		cameraMoveToPositionDurationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraMoveToPositionDurationComponent);
	}

	public void ReplaceCameraMoveToPositionDuration(float newValue)
	{
		int num = 33;
		CameraMoveToPositionDurationComponent cameraMoveToPositionDurationComponent = (CameraMoveToPositionDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionDurationComponent));
		cameraMoveToPositionDurationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraMoveToPositionDurationComponent);
	}

	public void RemoveCameraMoveToPositionDuration()
	{
		((Entity)this).RemoveComponent(33);
	}

	public void AddCameraMoveToPositionElapsedTime(float newValue)
	{
		int num = 34;
		CameraMoveToPositionElapsedTimeComponent cameraMoveToPositionElapsedTimeComponent = (CameraMoveToPositionElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionElapsedTimeComponent));
		cameraMoveToPositionElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)cameraMoveToPositionElapsedTimeComponent);
	}

	public void ReplaceCameraMoveToPositionElapsedTime(float newValue)
	{
		int num = 34;
		CameraMoveToPositionElapsedTimeComponent cameraMoveToPositionElapsedTimeComponent = (CameraMoveToPositionElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CameraMoveToPositionElapsedTimeComponent));
		cameraMoveToPositionElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)cameraMoveToPositionElapsedTimeComponent);
	}

	public void RemoveCameraMoveToPositionElapsedTime()
	{
		((Entity)this).RemoveComponent(34);
	}

	public void AddCastingAbilityCastTime(float newValue)
	{
		int num = 35;
		CastingAbilityCastTimeComponent castingAbilityCastTimeComponent = (CastingAbilityCastTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityCastTimeComponent));
		castingAbilityCastTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)castingAbilityCastTimeComponent);
	}

	public void ReplaceCastingAbilityCastTime(float newValue)
	{
		int num = 35;
		CastingAbilityCastTimeComponent castingAbilityCastTimeComponent = (CastingAbilityCastTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityCastTimeComponent));
		castingAbilityCastTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)castingAbilityCastTimeComponent);
	}

	public void RemoveCastingAbilityCastTime()
	{
		((Entity)this).RemoveComponent(35);
	}

	public void AddCastingAbilityElapsedTime(float newValue)
	{
		int num = 37;
		CastingAbilityElapsedTimeComponent castingAbilityElapsedTimeComponent = (CastingAbilityElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityElapsedTimeComponent));
		castingAbilityElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)castingAbilityElapsedTimeComponent);
	}

	public void ReplaceCastingAbilityElapsedTime(float newValue)
	{
		int num = 37;
		CastingAbilityElapsedTimeComponent castingAbilityElapsedTimeComponent = (CastingAbilityElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityElapsedTimeComponent));
		castingAbilityElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)castingAbilityElapsedTimeComponent);
	}

	public void RemoveCastingAbilityElapsedTime()
	{
		((Entity)this).RemoveComponent(37);
	}

	public void AddCastingAbilityElapsedTimeListener(List<ICastingAbilityElapsedTimeListener> newValue)
	{
		int num = 38;
		CastingAbilityElapsedTimeListenerComponent castingAbilityElapsedTimeListenerComponent = (CastingAbilityElapsedTimeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityElapsedTimeListenerComponent));
		castingAbilityElapsedTimeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)castingAbilityElapsedTimeListenerComponent);
	}

	public void ReplaceCastingAbilityElapsedTimeListener(List<ICastingAbilityElapsedTimeListener> newValue)
	{
		int num = 38;
		CastingAbilityElapsedTimeListenerComponent castingAbilityElapsedTimeListenerComponent = (CastingAbilityElapsedTimeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CastingAbilityElapsedTimeListenerComponent));
		castingAbilityElapsedTimeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)castingAbilityElapsedTimeListenerComponent);
	}

	public void RemoveCastingAbilityElapsedTimeListener()
	{
		((Entity)this).RemoveComponent(38);
	}

	public void AddCastingAbilityElapsedTimeListener(ICastingAbilityElapsedTimeListener value)
	{
		List<ICastingAbilityElapsedTimeListener> list = (hasCastingAbilityElapsedTimeListener ? castingAbilityElapsedTimeListener.value : new List<ICastingAbilityElapsedTimeListener>());
		list.Add(value);
		ReplaceCastingAbilityElapsedTimeListener(list);
	}

	public void RemoveCastingAbilityElapsedTimeListener(ICastingAbilityElapsedTimeListener value, bool removeComponentWhenEmpty = true)
	{
		List<ICastingAbilityElapsedTimeListener> value2 = castingAbilityElapsedTimeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveCastingAbilityElapsedTimeListener();
		}
		else
		{
			ReplaceCastingAbilityElapsedTimeListener(value2);
		}
	}

	public void AddCharacter(ICharacter newValue)
	{
		int num = 39;
		CharacterComponent characterComponent = (CharacterComponent)(object)((Entity)this).CreateComponent(num, typeof(CharacterComponent));
		characterComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)characterComponent);
	}

	public void ReplaceCharacter(ICharacter newValue)
	{
		int num = 39;
		CharacterComponent characterComponent = (CharacterComponent)(object)((Entity)this).CreateComponent(num, typeof(CharacterComponent));
		characterComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)characterComponent);
	}

	public void RemoveCharacter()
	{
		((Entity)this).RemoveComponent(39);
	}

	public void AddCollisionRadius(float newValue)
	{
		int num = 40;
		CollisionRadiusComponent collisionRadiusComponent = (CollisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(CollisionRadiusComponent));
		collisionRadiusComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)collisionRadiusComponent);
	}

	public void ReplaceCollisionRadius(float newValue)
	{
		int num = 40;
		CollisionRadiusComponent collisionRadiusComponent = (CollisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(CollisionRadiusComponent));
		collisionRadiusComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)collisionRadiusComponent);
	}

	public void RemoveCollisionRadius()
	{
		((Entity)this).RemoveComponent(40);
	}

	public void AddCollisionRadiusListener(List<ICollisionRadiusListener> newValue)
	{
		int num = 41;
		CollisionRadiusListenerComponent collisionRadiusListenerComponent = (CollisionRadiusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CollisionRadiusListenerComponent));
		collisionRadiusListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)collisionRadiusListenerComponent);
	}

	public void ReplaceCollisionRadiusListener(List<ICollisionRadiusListener> newValue)
	{
		int num = 41;
		CollisionRadiusListenerComponent collisionRadiusListenerComponent = (CollisionRadiusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(CollisionRadiusListenerComponent));
		collisionRadiusListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)collisionRadiusListenerComponent);
	}

	public void RemoveCollisionRadiusListener()
	{
		((Entity)this).RemoveComponent(41);
	}

	public void AddCollisionRadiusListener(ICollisionRadiusListener value)
	{
		List<ICollisionRadiusListener> list = (hasCollisionRadiusListener ? collisionRadiusListener.value : new List<ICollisionRadiusListener>());
		list.Add(value);
		ReplaceCollisionRadiusListener(list);
	}

	public void RemoveCollisionRadiusListener(ICollisionRadiusListener value, bool removeComponentWhenEmpty = true)
	{
		List<ICollisionRadiusListener> value2 = collisionRadiusListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveCollisionRadiusListener();
		}
		else
		{
			ReplaceCollisionRadiusListener(value2);
		}
	}

	public void AddCreationTick(int newValue)
	{
		int num = 42;
		CreationTickComponent creationTickComponent = (CreationTickComponent)(object)((Entity)this).CreateComponent(num, typeof(CreationTickComponent));
		creationTickComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)creationTickComponent);
	}

	public void ReplaceCreationTick(int newValue)
	{
		int num = 42;
		CreationTickComponent creationTickComponent = (CreationTickComponent)(object)((Entity)this).CreateComponent(num, typeof(CreationTickComponent));
		creationTickComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)creationTickComponent);
	}

	public void RemoveCreationTick()
	{
		((Entity)this).RemoveComponent(42);
	}

	public void AddDeadElapsedTick(int newValue)
	{
		int num = 44;
		DeadElapsedTickComponent deadElapsedTickComponent = (DeadElapsedTickComponent)(object)((Entity)this).CreateComponent(num, typeof(DeadElapsedTickComponent));
		deadElapsedTickComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)deadElapsedTickComponent);
	}

	public void ReplaceDeadElapsedTick(int newValue)
	{
		int num = 44;
		DeadElapsedTickComponent deadElapsedTickComponent = (DeadElapsedTickComponent)(object)((Entity)this).CreateComponent(num, typeof(DeadElapsedTickComponent));
		deadElapsedTickComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)deadElapsedTickComponent);
	}

	public void RemoveDeadElapsedTick()
	{
		((Entity)this).RemoveComponent(44);
	}

	public void AddDeadListener(List<IDeadListener> newValue)
	{
		int num = 45;
		DeadListenerComponent deadListenerComponent = (DeadListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(DeadListenerComponent));
		deadListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)deadListenerComponent);
	}

	public void ReplaceDeadListener(List<IDeadListener> newValue)
	{
		int num = 45;
		DeadListenerComponent deadListenerComponent = (DeadListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(DeadListenerComponent));
		deadListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)deadListenerComponent);
	}

	public void RemoveDeadListener()
	{
		((Entity)this).RemoveComponent(45);
	}

	public void AddDeadListener(IDeadListener value)
	{
		List<IDeadListener> list = (hasDeadListener ? deadListener.value : new List<IDeadListener>());
		list.Add(value);
		ReplaceDeadListener(list);
	}

	public void RemoveDeadListener(IDeadListener value, bool removeComponentWhenEmpty = true)
	{
		List<IDeadListener> value2 = deadListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveDeadListener();
		}
		else
		{
			ReplaceDeadListener(value2);
		}
	}

	public void AddDungeon(Dungeon newValue)
	{
		int num = 48;
		DungeonComponent dungeonComponent = (DungeonComponent)(object)((Entity)this).CreateComponent(num, typeof(DungeonComponent));
		dungeonComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)dungeonComponent);
	}

	public void ReplaceDungeon(Dungeon newValue)
	{
		int num = 48;
		DungeonComponent dungeonComponent = (DungeonComponent)(object)((Entity)this).CreateComponent(num, typeof(DungeonComponent));
		dungeonComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)dungeonComponent);
	}

	public void RemoveDungeon()
	{
		((Entity)this).RemoveComponent(48);
	}

	public void AddDuration(float newValue)
	{
		int num = 49;
		DurationComponent durationComponent = (DurationComponent)(object)((Entity)this).CreateComponent(num, typeof(DurationComponent));
		durationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)durationComponent);
	}

	public void ReplaceDuration(float newValue)
	{
		int num = 49;
		DurationComponent durationComponent = (DurationComponent)(object)((Entity)this).CreateComponent(num, typeof(DurationComponent));
		durationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)durationComponent);
	}

	public void RemoveDuration()
	{
		((Entity)this).RemoveComponent(49);
	}

	public void AddElapsedTime(float newValue)
	{
		int num = 50;
		ElapsedTimeComponent elapsedTimeComponent = (ElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ElapsedTimeComponent));
		elapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)elapsedTimeComponent);
	}

	public void ReplaceElapsedTime(float newValue)
	{
		int num = 50;
		ElapsedTimeComponent elapsedTimeComponent = (ElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ElapsedTimeComponent));
		elapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)elapsedTimeComponent);
	}

	public void RemoveElapsedTime()
	{
		((Entity)this).RemoveComponent(50);
	}

	public void AddFaceDirection(FaceDirection newValue)
	{
		int num = 51;
		FaceDirectionComponent faceDirectionComponent = (FaceDirectionComponent)(object)((Entity)this).CreateComponent(num, typeof(FaceDirectionComponent));
		faceDirectionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)faceDirectionComponent);
	}

	public void ReplaceFaceDirection(FaceDirection newValue)
	{
		int num = 51;
		FaceDirectionComponent faceDirectionComponent = (FaceDirectionComponent)(object)((Entity)this).CreateComponent(num, typeof(FaceDirectionComponent));
		faceDirectionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)faceDirectionComponent);
	}

	public void RemoveFaceDirection()
	{
		((Entity)this).RemoveComponent(51);
	}

	public void AddFloatingTextAlpha(float newValue)
	{
		int num = 52;
		FloatingTextAlphaComponent floatingTextAlphaComponent = (FloatingTextAlphaComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextAlphaComponent));
		floatingTextAlphaComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)floatingTextAlphaComponent);
	}

	public void ReplaceFloatingTextAlpha(float newValue)
	{
		int num = 52;
		FloatingTextAlphaComponent floatingTextAlphaComponent = (FloatingTextAlphaComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextAlphaComponent));
		floatingTextAlphaComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)floatingTextAlphaComponent);
	}

	public void RemoveFloatingTextAlpha()
	{
		((Entity)this).RemoveComponent(52);
	}

	public void AddFloatingTextAlphaListener(List<IFloatingTextAlphaListener> newValue)
	{
		int num = 53;
		FloatingTextAlphaListenerComponent floatingTextAlphaListenerComponent = (FloatingTextAlphaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextAlphaListenerComponent));
		floatingTextAlphaListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)floatingTextAlphaListenerComponent);
	}

	public void ReplaceFloatingTextAlphaListener(List<IFloatingTextAlphaListener> newValue)
	{
		int num = 53;
		FloatingTextAlphaListenerComponent floatingTextAlphaListenerComponent = (FloatingTextAlphaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextAlphaListenerComponent));
		floatingTextAlphaListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)floatingTextAlphaListenerComponent);
	}

	public void RemoveFloatingTextAlphaListener()
	{
		((Entity)this).RemoveComponent(53);
	}

	public void AddFloatingTextAlphaListener(IFloatingTextAlphaListener value)
	{
		List<IFloatingTextAlphaListener> list = (hasFloatingTextAlphaListener ? floatingTextAlphaListener.value : new List<IFloatingTextAlphaListener>());
		list.Add(value);
		ReplaceFloatingTextAlphaListener(list);
	}

	public void RemoveFloatingTextAlphaListener(IFloatingTextAlphaListener value, bool removeComponentWhenEmpty = true)
	{
		List<IFloatingTextAlphaListener> value2 = floatingTextAlphaListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveFloatingTextAlphaListener();
		}
		else
		{
			ReplaceFloatingTextAlphaListener(value2);
		}
	}

	public void AddFloatingText(Color newColor, string newText)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 54;
		FloatingTextComponent floatingTextComponent = (FloatingTextComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextComponent));
		floatingTextComponent.color = newColor;
		floatingTextComponent.text = newText;
		((Entity)this).AddComponent(num, (IComponent)(object)floatingTextComponent);
	}

	public void ReplaceFloatingText(Color newColor, string newText)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 54;
		FloatingTextComponent floatingTextComponent = (FloatingTextComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextComponent));
		floatingTextComponent.color = newColor;
		floatingTextComponent.text = newText;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)floatingTextComponent);
	}

	public void RemoveFloatingText()
	{
		((Entity)this).RemoveComponent(54);
	}

	public void AddFloatingTextListener(List<IFloatingTextListener> newValue)
	{
		int num = 55;
		FloatingTextListenerComponent floatingTextListenerComponent = (FloatingTextListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextListenerComponent));
		floatingTextListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)floatingTextListenerComponent);
	}

	public void ReplaceFloatingTextListener(List<IFloatingTextListener> newValue)
	{
		int num = 55;
		FloatingTextListenerComponent floatingTextListenerComponent = (FloatingTextListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FloatingTextListenerComponent));
		floatingTextListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)floatingTextListenerComponent);
	}

	public void RemoveFloatingTextListener()
	{
		((Entity)this).RemoveComponent(55);
	}

	public void AddFloatingTextListener(IFloatingTextListener value)
	{
		List<IFloatingTextListener> list = (hasFloatingTextListener ? floatingTextListener.value : new List<IFloatingTextListener>());
		list.Add(value);
		ReplaceFloatingTextListener(list);
	}

	public void RemoveFloatingTextListener(IFloatingTextListener value, bool removeComponentWhenEmpty = true)
	{
		List<IFloatingTextListener> value2 = floatingTextListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveFloatingTextListener();
		}
		else
		{
			ReplaceFloatingTextListener(value2);
		}
	}

	public void AddFlowLightFx(int newId, float newPower, float newSpeed)
	{
		int num = 56;
		FlowLightFxComponent flowLightFxComponent = (FlowLightFxComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxComponent));
		flowLightFxComponent.id = newId;
		flowLightFxComponent.power = newPower;
		flowLightFxComponent.speed = newSpeed;
		((Entity)this).AddComponent(num, (IComponent)(object)flowLightFxComponent);
	}

	public void ReplaceFlowLightFx(int newId, float newPower, float newSpeed)
	{
		int num = 56;
		FlowLightFxComponent flowLightFxComponent = (FlowLightFxComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxComponent));
		flowLightFxComponent.id = newId;
		flowLightFxComponent.power = newPower;
		flowLightFxComponent.speed = newSpeed;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)flowLightFxComponent);
	}

	public void RemoveFlowLightFx()
	{
		((Entity)this).RemoveComponent(56);
	}

	public void AddFlowLightFxListener(List<IFlowLightFxListener> newValue)
	{
		int num = 57;
		FlowLightFxListenerComponent flowLightFxListenerComponent = (FlowLightFxListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxListenerComponent));
		flowLightFxListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)flowLightFxListenerComponent);
	}

	public void ReplaceFlowLightFxListener(List<IFlowLightFxListener> newValue)
	{
		int num = 57;
		FlowLightFxListenerComponent flowLightFxListenerComponent = (FlowLightFxListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxListenerComponent));
		flowLightFxListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)flowLightFxListenerComponent);
	}

	public void RemoveFlowLightFxListener()
	{
		((Entity)this).RemoveComponent(57);
	}

	public void AddFlowLightFxListener(IFlowLightFxListener value)
	{
		List<IFlowLightFxListener> list = (hasFlowLightFxListener ? flowLightFxListener.value : new List<IFlowLightFxListener>());
		list.Add(value);
		ReplaceFlowLightFxListener(list);
	}

	public void RemoveFlowLightFxListener(IFlowLightFxListener value, bool removeComponentWhenEmpty = true)
	{
		List<IFlowLightFxListener> value2 = flowLightFxListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveFlowLightFxListener();
		}
		else
		{
			ReplaceFlowLightFxListener(value2);
		}
	}

	public void AddFlowLightFxRemovedListener(List<IFlowLightFxRemovedListener> newValue)
	{
		int num = 58;
		FlowLightFxRemovedListenerComponent flowLightFxRemovedListenerComponent = (FlowLightFxRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxRemovedListenerComponent));
		flowLightFxRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)flowLightFxRemovedListenerComponent);
	}

	public void ReplaceFlowLightFxRemovedListener(List<IFlowLightFxRemovedListener> newValue)
	{
		int num = 58;
		FlowLightFxRemovedListenerComponent flowLightFxRemovedListenerComponent = (FlowLightFxRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(FlowLightFxRemovedListenerComponent));
		flowLightFxRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)flowLightFxRemovedListenerComponent);
	}

	public void RemoveFlowLightFxRemovedListener()
	{
		((Entity)this).RemoveComponent(58);
	}

	public void AddFlowLightFxRemovedListener(IFlowLightFxRemovedListener value)
	{
		List<IFlowLightFxRemovedListener> list = (hasFlowLightFxRemovedListener ? flowLightFxRemovedListener.value : new List<IFlowLightFxRemovedListener>());
		list.Add(value);
		ReplaceFlowLightFxRemovedListener(list);
	}

	public void RemoveFlowLightFxRemovedListener(IFlowLightFxRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IFlowLightFxRemovedListener> value2 = flowLightFxRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveFlowLightFxRemovedListener();
		}
		else
		{
			ReplaceFlowLightFxRemovedListener(value2);
		}
	}

	public void AddFxController(IFxController newValue)
	{
		int num = 59;
		FxControllerComponent fxControllerComponent = (FxControllerComponent)(object)((Entity)this).CreateComponent(num, typeof(FxControllerComponent));
		fxControllerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)fxControllerComponent);
	}

	public void ReplaceFxController(IFxController newValue)
	{
		int num = 59;
		FxControllerComponent fxControllerComponent = (FxControllerComponent)(object)((Entity)this).CreateComponent(num, typeof(FxControllerComponent));
		fxControllerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)fxControllerComponent);
	}

	public void RemoveFxController()
	{
		((Entity)this).RemoveComponent(59);
	}

	public void AddGameDestroyedListener(List<IGameDestroyedListener> newValue)
	{
		int num = 60;
		GameDestroyedListenerComponent gameDestroyedListenerComponent = (GameDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(GameDestroyedListenerComponent));
		gameDestroyedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)gameDestroyedListenerComponent);
	}

	public void ReplaceGameDestroyedListener(List<IGameDestroyedListener> newValue)
	{
		int num = 60;
		GameDestroyedListenerComponent gameDestroyedListenerComponent = (GameDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(GameDestroyedListenerComponent));
		gameDestroyedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)gameDestroyedListenerComponent);
	}

	public void RemoveGameDestroyedListener()
	{
		((Entity)this).RemoveComponent(60);
	}

	public void AddGameDestroyedListener(IGameDestroyedListener value)
	{
		List<IGameDestroyedListener> list = (hasGameDestroyedListener ? gameDestroyedListener.value : new List<IGameDestroyedListener>());
		list.Add(value);
		ReplaceGameDestroyedListener(list);
	}

	public void RemoveGameDestroyedListener(IGameDestroyedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IGameDestroyedListener> value2 = gameDestroyedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveGameDestroyedListener();
		}
		else
		{
			ReplaceGameDestroyedListener(value2);
		}
	}

	public void AddGroupSourceId(int newValue)
	{
		int num = 62;
		GroupSourceIdComponent groupSourceIdComponent = (GroupSourceIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupSourceIdComponent));
		groupSourceIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)groupSourceIdComponent);
	}

	public void ReplaceGroupSourceId(int newValue)
	{
		int num = 62;
		GroupSourceIdComponent groupSourceIdComponent = (GroupSourceIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupSourceIdComponent));
		groupSourceIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)groupSourceIdComponent);
	}

	public void RemoveGroupSourceId()
	{
		((Entity)this).RemoveComponent(62);
	}

	public void AddGroupTargetId(int newValue)
	{
		int num = 63;
		GroupTargetIdComponent groupTargetIdComponent = (GroupTargetIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupTargetIdComponent));
		groupTargetIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)groupTargetIdComponent);
	}

	public void ReplaceGroupTargetId(int newValue)
	{
		int num = 63;
		GroupTargetIdComponent groupTargetIdComponent = (GroupTargetIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupTargetIdComponent));
		groupTargetIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)groupTargetIdComponent);
	}

	public void RemoveGroupTargetId()
	{
		((Entity)this).RemoveComponent(63);
	}

	public void AddGroupUnitId(int newValue)
	{
		int num = 64;
		GroupUnitIdComponent groupUnitIdComponent = (GroupUnitIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupUnitIdComponent));
		groupUnitIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)groupUnitIdComponent);
	}

	public void ReplaceGroupUnitId(int newValue)
	{
		int num = 64;
		GroupUnitIdComponent groupUnitIdComponent = (GroupUnitIdComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupUnitIdComponent));
		groupUnitIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)groupUnitIdComponent);
	}

	public void RemoveGroupUnitId()
	{
		((Entity)this).RemoveComponent(64);
	}

	public void AddGroupUnits(PooledList<int> newValue)
	{
		int num = 65;
		GroupUnitsComponent groupUnitsComponent = (GroupUnitsComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupUnitsComponent));
		groupUnitsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)groupUnitsComponent);
	}

	public void ReplaceGroupUnits(PooledList<int> newValue)
	{
		int num = 65;
		GroupUnitsComponent groupUnitsComponent = (GroupUnitsComponent)(object)((Entity)this).CreateComponent(num, typeof(GroupUnitsComponent));
		groupUnitsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)groupUnitsComponent);
	}

	public void RemoveGroupUnits()
	{
		((Entity)this).RemoveComponent(65);
	}

	public void AddHeight(float newValue)
	{
		int num = 66;
		HeightComponent heightComponent = (HeightComponent)(object)((Entity)this).CreateComponent(num, typeof(HeightComponent));
		heightComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)heightComponent);
	}

	public void ReplaceHeight(float newValue)
	{
		int num = 66;
		HeightComponent heightComponent = (HeightComponent)(object)((Entity)this).CreateComponent(num, typeof(HeightComponent));
		heightComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)heightComponent);
	}

	public void RemoveHeight()
	{
		((Entity)this).RemoveComponent(66);
	}

	public void AddHeightListener(List<IHeightListener> newValue)
	{
		int num = 67;
		HeightListenerComponent heightListenerComponent = (HeightListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(HeightListenerComponent));
		heightListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)heightListenerComponent);
	}

	public void ReplaceHeightListener(List<IHeightListener> newValue)
	{
		int num = 67;
		HeightListenerComponent heightListenerComponent = (HeightListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(HeightListenerComponent));
		heightListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)heightListenerComponent);
	}

	public void RemoveHeightListener()
	{
		((Entity)this).RemoveComponent(67);
	}

	public void AddHeightListener(IHeightListener value)
	{
		List<IHeightListener> list = (hasHeightListener ? heightListener.value : new List<IHeightListener>());
		list.Add(value);
		ReplaceHeightListener(list);
	}

	public void RemoveHeightListener(IHeightListener value, bool removeComponentWhenEmpty = true)
	{
		List<IHeightListener> value2 = heightListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveHeightListener();
		}
		else
		{
			ReplaceHeightListener(value2);
		}
	}

	public void AddId(int newValue)
	{
		int num = 68;
		IdComponent idComponent = (IdComponent)(object)((Entity)this).CreateComponent(num, typeof(IdComponent));
		idComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)idComponent);
	}

	public void ReplaceId(int newValue)
	{
		int num = 68;
		IdComponent idComponent = (IdComponent)(object)((Entity)this).CreateComponent(num, typeof(IdComponent));
		idComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)idComponent);
	}

	public void RemoveId()
	{
		((Entity)this).RemoveComponent(68);
	}

	public void AddLandingBone(string newValue)
	{
		int num = 69;
		LandingBoneComponent landingBoneComponent = (LandingBoneComponent)(object)((Entity)this).CreateComponent(num, typeof(LandingBoneComponent));
		landingBoneComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)landingBoneComponent);
	}

	public void ReplaceLandingBone(string newValue)
	{
		int num = 69;
		LandingBoneComponent landingBoneComponent = (LandingBoneComponent)(object)((Entity)this).CreateComponent(num, typeof(LandingBoneComponent));
		landingBoneComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)landingBoneComponent);
	}

	public void RemoveLandingBone()
	{
		((Entity)this).RemoveComponent(69);
	}

	public void AddLaunchBone(string newValue)
	{
		int num = 70;
		LaunchBoneComponent launchBoneComponent = (LaunchBoneComponent)(object)((Entity)this).CreateComponent(num, typeof(LaunchBoneComponent));
		launchBoneComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)launchBoneComponent);
	}

	public void ReplaceLaunchBone(string newValue)
	{
		int num = 70;
		LaunchBoneComponent launchBoneComponent = (LaunchBoneComponent)(object)((Entity)this).CreateComponent(num, typeof(LaunchBoneComponent));
		launchBoneComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)launchBoneComponent);
	}

	public void RemoveLaunchBone()
	{
		((Entity)this).RemoveComponent(70);
	}

	public void AddLeftTime(float newValue)
	{
		int num = 71;
		LeftTimeComponent leftTimeComponent = (LeftTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(LeftTimeComponent));
		leftTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)leftTimeComponent);
	}

	public void ReplaceLeftTime(float newValue)
	{
		int num = 71;
		LeftTimeComponent leftTimeComponent = (LeftTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(LeftTimeComponent));
		leftTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)leftTimeComponent);
	}

	public void RemoveLeftTime()
	{
		((Entity)this).RemoveComponent(71);
	}

	public void AddLevelId(string newValue)
	{
		int num = 72;
		LevelIdComponent levelIdComponent = (LevelIdComponent)(object)((Entity)this).CreateComponent(num, typeof(LevelIdComponent));
		levelIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)levelIdComponent);
	}

	public void ReplaceLevelId(string newValue)
	{
		int num = 72;
		LevelIdComponent levelIdComponent = (LevelIdComponent)(object)((Entity)this).CreateComponent(num, typeof(LevelIdComponent));
		levelIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)levelIdComponent);
	}

	public void RemoveLevelId()
	{
		((Entity)this).RemoveComponent(72);
	}

	public void AddLevelInst(Level newValue)
	{
		int num = 73;
		LevelInstComponent levelInstComponent = (LevelInstComponent)(object)((Entity)this).CreateComponent(num, typeof(LevelInstComponent));
		levelInstComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)levelInstComponent);
	}

	public void ReplaceLevelInst(Level newValue)
	{
		int num = 73;
		LevelInstComponent levelInstComponent = (LevelInstComponent)(object)((Entity)this).CreateComponent(num, typeof(LevelInstComponent));
		levelInstComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)levelInstComponent);
	}

	public void RemoveLevelInst()
	{
		((Entity)this).RemoveComponent(73);
	}

	public void AddModel(string newValue)
	{
		int num = 75;
		ModelComponent modelComponent = (ModelComponent)(object)((Entity)this).CreateComponent(num, typeof(ModelComponent));
		modelComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)modelComponent);
	}

	public void ReplaceModel(string newValue)
	{
		int num = 75;
		ModelComponent modelComponent = (ModelComponent)(object)((Entity)this).CreateComponent(num, typeof(ModelComponent));
		modelComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)modelComponent);
	}

	public void RemoveModel()
	{
		((Entity)this).RemoveComponent(75);
	}

	public void AddModelListener(List<IModelListener> newValue)
	{
		int num = 76;
		ModelListenerComponent modelListenerComponent = (ModelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ModelListenerComponent));
		modelListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)modelListenerComponent);
	}

	public void ReplaceModelListener(List<IModelListener> newValue)
	{
		int num = 76;
		ModelListenerComponent modelListenerComponent = (ModelListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ModelListenerComponent));
		modelListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)modelListenerComponent);
	}

	public void RemoveModelListener()
	{
		((Entity)this).RemoveComponent(76);
	}

	public void AddModelListener(IModelListener value)
	{
		List<IModelListener> list = (hasModelListener ? modelListener.value : new List<IModelListener>());
		list.Add(value);
		ReplaceModelListener(list);
	}

	public void RemoveModelListener(IModelListener value, bool removeComponentWhenEmpty = true)
	{
		List<IModelListener> value2 = modelListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveModelListener();
		}
		else
		{
			ReplaceModelListener(value2);
		}
	}

	public void AddMoveSpeed(float newValue)
	{
		int num = 77;
		MoveSpeedComponent moveSpeedComponent = (MoveSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(MoveSpeedComponent));
		moveSpeedComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)moveSpeedComponent);
	}

	public void ReplaceMoveSpeed(float newValue)
	{
		int num = 77;
		MoveSpeedComponent moveSpeedComponent = (MoveSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(MoveSpeedComponent));
		moveSpeedComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)moveSpeedComponent);
	}

	public void RemoveMoveSpeed()
	{
		((Entity)this).RemoveComponent(77);
	}

	public void AddMoveSpeedListener(List<IMoveSpeedListener> newValue)
	{
		int num = 78;
		MoveSpeedListenerComponent moveSpeedListenerComponent = (MoveSpeedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(MoveSpeedListenerComponent));
		moveSpeedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)moveSpeedListenerComponent);
	}

	public void ReplaceMoveSpeedListener(List<IMoveSpeedListener> newValue)
	{
		int num = 78;
		MoveSpeedListenerComponent moveSpeedListenerComponent = (MoveSpeedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(MoveSpeedListenerComponent));
		moveSpeedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)moveSpeedListenerComponent);
	}

	public void RemoveMoveSpeedListener()
	{
		((Entity)this).RemoveComponent(78);
	}

	public void AddMoveSpeedListener(IMoveSpeedListener value)
	{
		List<IMoveSpeedListener> list = (hasMoveSpeedListener ? moveSpeedListener.value : new List<IMoveSpeedListener>());
		list.Add(value);
		ReplaceMoveSpeedListener(list);
	}

	public void RemoveMoveSpeedListener(IMoveSpeedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IMoveSpeedListener> value2 = moveSpeedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveMoveSpeedListener();
		}
		else
		{
			ReplaceMoveSpeedListener(value2);
		}
	}

	public void AddName(string newValue)
	{
		int num = 79;
		NameComponent nameComponent = (NameComponent)(object)((Entity)this).CreateComponent(num, typeof(NameComponent));
		nameComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)nameComponent);
	}

	public void ReplaceName(string newValue)
	{
		int num = 79;
		NameComponent nameComponent = (NameComponent)(object)((Entity)this).CreateComponent(num, typeof(NameComponent));
		nameComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)nameComponent);
	}

	public void RemoveName()
	{
		((Entity)this).RemoveComponent(79);
	}

	public void AddOwnerId(int newValue)
	{
		int num = 80;
		OwnerIdComponent ownerIdComponent = (OwnerIdComponent)(object)((Entity)this).CreateComponent(num, typeof(OwnerIdComponent));
		ownerIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)ownerIdComponent);
	}

	public void ReplaceOwnerId(int newValue)
	{
		int num = 80;
		OwnerIdComponent ownerIdComponent = (OwnerIdComponent)(object)((Entity)this).CreateComponent(num, typeof(OwnerIdComponent));
		ownerIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)ownerIdComponent);
	}

	public void RemoveOwnerId()
	{
		((Entity)this).RemoveComponent(80);
	}

	public void AddParabolaSpeed(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 81;
		ParabolaSpeedComponent parabolaSpeedComponent = (ParabolaSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(ParabolaSpeedComponent));
		parabolaSpeedComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)parabolaSpeedComponent);
	}

	public void ReplaceParabolaSpeed(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 81;
		ParabolaSpeedComponent parabolaSpeedComponent = (ParabolaSpeedComponent)(object)((Entity)this).CreateComponent(num, typeof(ParabolaSpeedComponent));
		parabolaSpeedComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)parabolaSpeedComponent);
	}

	public void RemoveParabolaSpeed()
	{
		((Entity)this).RemoveComponent(81);
	}

	public void AddParent(int newValue)
	{
		int num = 82;
		ParentComponent parentComponent = (ParentComponent)(object)((Entity)this).CreateComponent(num, typeof(ParentComponent));
		parentComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)parentComponent);
	}

	public void ReplaceParent(int newValue)
	{
		int num = 82;
		ParentComponent parentComponent = (ParentComponent)(object)((Entity)this).CreateComponent(num, typeof(ParentComponent));
		parentComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)parentComponent);
	}

	public void RemoveParent()
	{
		((Entity)this).RemoveComponent(82);
	}

	public void AddParentId(int newValue)
	{
		int num = 83;
		ParentIdComponent parentIdComponent = (ParentIdComponent)(object)((Entity)this).CreateComponent(num, typeof(ParentIdComponent));
		parentIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)parentIdComponent);
	}

	public void ReplaceParentId(int newValue)
	{
		int num = 83;
		ParentIdComponent parentIdComponent = (ParentIdComponent)(object)((Entity)this).CreateComponent(num, typeof(ParentIdComponent));
		parentIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)parentIdComponent);
	}

	public void RemoveParentId()
	{
		((Entity)this).RemoveComponent(83);
	}

	public void AddParticleBaseScale(float newValue)
	{
		int num = 84;
		ParticleBaseScaleComponent particleBaseScaleComponent = (ParticleBaseScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleBaseScaleComponent));
		particleBaseScaleComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleBaseScaleComponent);
	}

	public void ReplaceParticleBaseScale(float newValue)
	{
		int num = 84;
		ParticleBaseScaleComponent particleBaseScaleComponent = (ParticleBaseScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleBaseScaleComponent));
		particleBaseScaleComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleBaseScaleComponent);
	}

	public void RemoveParticleBaseScale()
	{
		((Entity)this).RemoveComponent(84);
	}

	public void AddParticle(IParticle newValue)
	{
		int num = 85;
		ParticleComponent particleComponent = (ParticleComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleComponent));
		particleComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleComponent);
	}

	public void ReplaceParticle(IParticle newValue)
	{
		int num = 85;
		ParticleComponent particleComponent = (ParticleComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleComponent));
		particleComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleComponent);
	}

	public void RemoveParticle()
	{
		((Entity)this).RemoveComponent(85);
	}

	public void AddParticleFullscreenEndPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 89;
		ParticleFullscreenEndPositionComponent particleFullscreenEndPositionComponent = (ParticleFullscreenEndPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenEndPositionComponent));
		particleFullscreenEndPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleFullscreenEndPositionComponent);
	}

	public void ReplaceParticleFullscreenEndPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 89;
		ParticleFullscreenEndPositionComponent particleFullscreenEndPositionComponent = (ParticleFullscreenEndPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenEndPositionComponent));
		particleFullscreenEndPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleFullscreenEndPositionComponent);
	}

	public void RemoveParticleFullscreenEndPosition()
	{
		((Entity)this).RemoveComponent(89);
	}

	public void AddParticleFullscreenLayer(int newValue)
	{
		int num = 90;
		ParticleFullscreenLayerComponent particleFullscreenLayerComponent = (ParticleFullscreenLayerComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenLayerComponent));
		particleFullscreenLayerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleFullscreenLayerComponent);
	}

	public void ReplaceParticleFullscreenLayer(int newValue)
	{
		int num = 90;
		ParticleFullscreenLayerComponent particleFullscreenLayerComponent = (ParticleFullscreenLayerComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenLayerComponent));
		particleFullscreenLayerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleFullscreenLayerComponent);
	}

	public void RemoveParticleFullscreenLayer()
	{
		((Entity)this).RemoveComponent(90);
	}

	public void AddParticleFullscreenMoveDuration(float newValue)
	{
		int num = 91;
		ParticleFullscreenMoveDurationComponent particleFullscreenMoveDurationComponent = (ParticleFullscreenMoveDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenMoveDurationComponent));
		particleFullscreenMoveDurationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleFullscreenMoveDurationComponent);
	}

	public void ReplaceParticleFullscreenMoveDuration(float newValue)
	{
		int num = 91;
		ParticleFullscreenMoveDurationComponent particleFullscreenMoveDurationComponent = (ParticleFullscreenMoveDurationComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenMoveDurationComponent));
		particleFullscreenMoveDurationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleFullscreenMoveDurationComponent);
	}

	public void RemoveParticleFullscreenMoveDuration()
	{
		((Entity)this).RemoveComponent(91);
	}

	public void AddParticleFullscreenMoveElapsedTime(float newValue)
	{
		int num = 92;
		ParticleFullscreenMoveElapsedTimeComponent particleFullscreenMoveElapsedTimeComponent = (ParticleFullscreenMoveElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenMoveElapsedTimeComponent));
		particleFullscreenMoveElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleFullscreenMoveElapsedTimeComponent);
	}

	public void ReplaceParticleFullscreenMoveElapsedTime(float newValue)
	{
		int num = 92;
		ParticleFullscreenMoveElapsedTimeComponent particleFullscreenMoveElapsedTimeComponent = (ParticleFullscreenMoveElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenMoveElapsedTimeComponent));
		particleFullscreenMoveElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleFullscreenMoveElapsedTimeComponent);
	}

	public void RemoveParticleFullscreenMoveElapsedTime()
	{
		((Entity)this).RemoveComponent(92);
	}

	public void AddParticleFullscreenStartPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 93;
		ParticleFullscreenStartPositionComponent particleFullscreenStartPositionComponent = (ParticleFullscreenStartPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenStartPositionComponent));
		particleFullscreenStartPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleFullscreenStartPositionComponent);
	}

	public void ReplaceParticleFullscreenStartPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 93;
		ParticleFullscreenStartPositionComponent particleFullscreenStartPositionComponent = (ParticleFullscreenStartPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleFullscreenStartPositionComponent));
		particleFullscreenStartPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleFullscreenStartPositionComponent);
	}

	public void RemoveParticleFullscreenStartPosition()
	{
		((Entity)this).RemoveComponent(93);
	}

	public void AddParticleState(ParticleState newValue)
	{
		int num = 95;
		ParticleStateComponent particleStateComponent = (ParticleStateComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleStateComponent));
		particleStateComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)particleStateComponent);
	}

	public void ReplaceParticleState(ParticleState newValue)
	{
		int num = 95;
		ParticleStateComponent particleStateComponent = (ParticleStateComponent)(object)((Entity)this).CreateComponent(num, typeof(ParticleStateComponent));
		particleStateComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)particleStateComponent);
	}

	public void RemoveParticleState()
	{
		((Entity)this).RemoveComponent(95);
	}

	public void AddPortalId(int newValue)
	{
		int num = 97;
		PortalIdComponent portalIdComponent = (PortalIdComponent)(object)((Entity)this).CreateComponent(num, typeof(PortalIdComponent));
		portalIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)portalIdComponent);
	}

	public void ReplacePortalId(int newValue)
	{
		int num = 97;
		PortalIdComponent portalIdComponent = (PortalIdComponent)(object)((Entity)this).CreateComponent(num, typeof(PortalIdComponent));
		portalIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)portalIdComponent);
	}

	public void RemovePortalId()
	{
		((Entity)this).RemoveComponent(97);
	}

	public void AddPortalUnitIndex(int newValue)
	{
		int num = 98;
		PortalUnitIndexComponent portalUnitIndexComponent = (PortalUnitIndexComponent)(object)((Entity)this).CreateComponent(num, typeof(PortalUnitIndexComponent));
		portalUnitIndexComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)portalUnitIndexComponent);
	}

	public void ReplacePortalUnitIndex(int newValue)
	{
		int num = 98;
		PortalUnitIndexComponent portalUnitIndexComponent = (PortalUnitIndexComponent)(object)((Entity)this).CreateComponent(num, typeof(PortalUnitIndexComponent));
		portalUnitIndexComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)portalUnitIndexComponent);
	}

	public void RemovePortalUnitIndex()
	{
		((Entity)this).RemoveComponent(98);
	}

	public void AddPosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 99;
		PositionComponent positionComponent = (PositionComponent)(object)((Entity)this).CreateComponent(num, typeof(PositionComponent));
		positionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)positionComponent);
	}

	public void ReplacePosition(Vector3 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 99;
		PositionComponent positionComponent = (PositionComponent)(object)((Entity)this).CreateComponent(num, typeof(PositionComponent));
		positionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)positionComponent);
	}

	public void RemovePosition()
	{
		((Entity)this).RemoveComponent(99);
	}

	public void AddPositionListener(List<IPositionListener> newValue)
	{
		int num = 100;
		PositionListenerComponent positionListenerComponent = (PositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(PositionListenerComponent));
		positionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)positionListenerComponent);
	}

	public void ReplacePositionListener(List<IPositionListener> newValue)
	{
		int num = 100;
		PositionListenerComponent positionListenerComponent = (PositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(PositionListenerComponent));
		positionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)positionListenerComponent);
	}

	public void RemovePositionListener()
	{
		((Entity)this).RemoveComponent(100);
	}

	public void AddPositionListener(IPositionListener value)
	{
		List<IPositionListener> list = (hasPositionListener ? positionListener.value : new List<IPositionListener>());
		list.Add(value);
		ReplacePositionListener(list);
	}

	public void RemovePositionListener(IPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<IPositionListener> value2 = positionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemovePositionListener();
		}
		else
		{
			ReplacePositionListener(value2);
		}
	}

	public void AddPriority(int newValue)
	{
		int num = 101;
		PriorityComponent priorityComponent = (PriorityComponent)(object)((Entity)this).CreateComponent(num, typeof(PriorityComponent));
		priorityComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)priorityComponent);
	}

	public void ReplacePriority(int newValue)
	{
		int num = 101;
		PriorityComponent priorityComponent = (PriorityComponent)(object)((Entity)this).CreateComponent(num, typeof(PriorityComponent));
		priorityComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)priorityComponent);
	}

	public void RemovePriority()
	{
		((Entity)this).RemoveComponent(101);
	}

	public void AddProjectileIdentifier(string newValue)
	{
		int num = 104;
		ProjectileIdentifierComponent projectileIdentifierComponent = (ProjectileIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileIdentifierComponent));
		projectileIdentifierComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)projectileIdentifierComponent);
	}

	public void ReplaceProjectileIdentifier(string newValue)
	{
		int num = 104;
		ProjectileIdentifierComponent projectileIdentifierComponent = (ProjectileIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileIdentifierComponent));
		projectileIdentifierComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)projectileIdentifierComponent);
	}

	public void RemoveProjectileIdentifier()
	{
		((Entity)this).RemoveComponent(104);
	}

	public void AddProjectileMoveType(ProjectileMoveType newValue)
	{
		int num = 105;
		ProjectileMoveTypeComponent projectileMoveTypeComponent = (ProjectileMoveTypeComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileMoveTypeComponent));
		projectileMoveTypeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)projectileMoveTypeComponent);
	}

	public void ReplaceProjectileMoveType(ProjectileMoveType newValue)
	{
		int num = 105;
		ProjectileMoveTypeComponent projectileMoveTypeComponent = (ProjectileMoveTypeComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileMoveTypeComponent));
		projectileMoveTypeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)projectileMoveTypeComponent);
	}

	public void RemoveProjectileMoveType()
	{
		((Entity)this).RemoveComponent(105);
	}

	public void AddProjectileRatio(float newValue)
	{
		int num = 106;
		ProjectileRatioComponent projectileRatioComponent = (ProjectileRatioComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileRatioComponent));
		projectileRatioComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)projectileRatioComponent);
	}

	public void ReplaceProjectileRatio(float newValue)
	{
		int num = 106;
		ProjectileRatioComponent projectileRatioComponent = (ProjectileRatioComponent)(object)((Entity)this).CreateComponent(num, typeof(ProjectileRatioComponent));
		projectileRatioComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)projectileRatioComponent);
	}

	public void RemoveProjectileRatio()
	{
		((Entity)this).RemoveComponent(106);
	}

	public void AddRotation(Quaternion newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 107;
		RotationComponent rotationComponent = (RotationComponent)(object)((Entity)this).CreateComponent(num, typeof(RotationComponent));
		rotationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)rotationComponent);
	}

	public void ReplaceRotation(Quaternion newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 107;
		RotationComponent rotationComponent = (RotationComponent)(object)((Entity)this).CreateComponent(num, typeof(RotationComponent));
		rotationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)rotationComponent);
	}

	public void RemoveRotation()
	{
		((Entity)this).RemoveComponent(107);
	}

	public void AddRotationListener(List<IRotationListener> newValue)
	{
		int num = 108;
		RotationListenerComponent rotationListenerComponent = (RotationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(RotationListenerComponent));
		rotationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)rotationListenerComponent);
	}

	public void ReplaceRotationListener(List<IRotationListener> newValue)
	{
		int num = 108;
		RotationListenerComponent rotationListenerComponent = (RotationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(RotationListenerComponent));
		rotationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)rotationListenerComponent);
	}

	public void RemoveRotationListener()
	{
		((Entity)this).RemoveComponent(108);
	}

	public void AddRotationListener(IRotationListener value)
	{
		List<IRotationListener> list = (hasRotationListener ? rotationListener.value : new List<IRotationListener>());
		list.Add(value);
		ReplaceRotationListener(list);
	}

	public void RemoveRotationListener(IRotationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IRotationListener> value2 = rotationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveRotationListener();
		}
		else
		{
			ReplaceRotationListener(value2);
		}
	}

	public void AddScale(float newValue)
	{
		int num = 109;
		ScaleComponent scaleComponent = (ScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ScaleComponent));
		scaleComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)scaleComponent);
	}

	public void ReplaceScale(float newValue)
	{
		int num = 109;
		ScaleComponent scaleComponent = (ScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ScaleComponent));
		scaleComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)scaleComponent);
	}

	public void RemoveScale()
	{
		((Entity)this).RemoveComponent(109);
	}

	public void AddScaleListener(List<IScaleListener> newValue)
	{
		int num = 110;
		ScaleListenerComponent scaleListenerComponent = (ScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ScaleListenerComponent));
		scaleListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)scaleListenerComponent);
	}

	public void ReplaceScaleListener(List<IScaleListener> newValue)
	{
		int num = 110;
		ScaleListenerComponent scaleListenerComponent = (ScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ScaleListenerComponent));
		scaleListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)scaleListenerComponent);
	}

	public void RemoveScaleListener()
	{
		((Entity)this).RemoveComponent(110);
	}

	public void AddScaleListener(IScaleListener value)
	{
		List<IScaleListener> list = (hasScaleListener ? scaleListener.value : new List<IScaleListener>());
		list.Add(value);
		ReplaceScaleListener(list);
	}

	public void RemoveScaleListener(IScaleListener value, bool removeComponentWhenEmpty = true)
	{
		List<IScaleListener> value2 = scaleListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveScaleListener();
		}
		else
		{
			ReplaceScaleListener(value2);
		}
	}

	public void AddSceneArguments(SceneArguments newValue)
	{
		int num = 111;
		SceneArgumentsComponent sceneArgumentsComponent = (SceneArgumentsComponent)(object)((Entity)this).CreateComponent(num, typeof(SceneArgumentsComponent));
		sceneArgumentsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)sceneArgumentsComponent);
	}

	public void ReplaceSceneArguments(SceneArguments newValue)
	{
		int num = 111;
		SceneArgumentsComponent sceneArgumentsComponent = (SceneArgumentsComponent)(object)((Entity)this).CreateComponent(num, typeof(SceneArgumentsComponent));
		sceneArgumentsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)sceneArgumentsComponent);
	}

	public void RemoveSceneArguments()
	{
		((Entity)this).RemoveComponent(111);
	}

	public void AddSceneName(string newValue)
	{
		int num = 113;
		SceneNameComponent sceneNameComponent = (SceneNameComponent)(object)((Entity)this).CreateComponent(num, typeof(SceneNameComponent));
		sceneNameComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)sceneNameComponent);
	}

	public void ReplaceSceneName(string newValue)
	{
		int num = 113;
		SceneNameComponent sceneNameComponent = (SceneNameComponent)(object)((Entity)this).CreateComponent(num, typeof(SceneNameComponent));
		sceneNameComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)sceneNameComponent);
	}

	public void RemoveSceneName()
	{
		((Entity)this).RemoveComponent(113);
	}

	public void AddShadowScale(float newValue)
	{
		int num = 115;
		ShadowScaleComponent shadowScaleComponent = (ShadowScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ShadowScaleComponent));
		shadowScaleComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)shadowScaleComponent);
	}

	public void ReplaceShadowScale(float newValue)
	{
		int num = 115;
		ShadowScaleComponent shadowScaleComponent = (ShadowScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(ShadowScaleComponent));
		shadowScaleComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)shadowScaleComponent);
	}

	public void RemoveShadowScale()
	{
		((Entity)this).RemoveComponent(115);
	}

	public void AddShadowScaleListener(List<IShadowScaleListener> newValue)
	{
		int num = 116;
		ShadowScaleListenerComponent shadowScaleListenerComponent = (ShadowScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShadowScaleListenerComponent));
		shadowScaleListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)shadowScaleListenerComponent);
	}

	public void ReplaceShadowScaleListener(List<IShadowScaleListener> newValue)
	{
		int num = 116;
		ShadowScaleListenerComponent shadowScaleListenerComponent = (ShadowScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShadowScaleListenerComponent));
		shadowScaleListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)shadowScaleListenerComponent);
	}

	public void RemoveShadowScaleListener()
	{
		((Entity)this).RemoveComponent(116);
	}

	public void AddShadowScaleListener(IShadowScaleListener value)
	{
		List<IShadowScaleListener> list = (hasShadowScaleListener ? shadowScaleListener.value : new List<IShadowScaleListener>());
		list.Add(value);
		ReplaceShadowScaleListener(list);
	}

	public void RemoveShadowScaleListener(IShadowScaleListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShadowScaleListener> value2 = shadowScaleListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShadowScaleListener();
		}
		else
		{
			ReplaceShadowScaleListener(value2);
		}
	}

	public void AddShowCastingBarListener(List<IShowCastingBarListener> newValue)
	{
		int num = 118;
		ShowCastingBarListenerComponent showCastingBarListenerComponent = (ShowCastingBarListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowCastingBarListenerComponent));
		showCastingBarListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showCastingBarListenerComponent);
	}

	public void ReplaceShowCastingBarListener(List<IShowCastingBarListener> newValue)
	{
		int num = 118;
		ShowCastingBarListenerComponent showCastingBarListenerComponent = (ShowCastingBarListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowCastingBarListenerComponent));
		showCastingBarListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showCastingBarListenerComponent);
	}

	public void RemoveShowCastingBarListener()
	{
		((Entity)this).RemoveComponent(118);
	}

	public void AddShowCastingBarListener(IShowCastingBarListener value)
	{
		List<IShowCastingBarListener> list = (hasShowCastingBarListener ? showCastingBarListener.value : new List<IShowCastingBarListener>());
		list.Add(value);
		ReplaceShowCastingBarListener(list);
	}

	public void RemoveShowCastingBarListener(IShowCastingBarListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShowCastingBarListener> value2 = showCastingBarListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShowCastingBarListener();
		}
		else
		{
			ReplaceShowCastingBarListener(value2);
		}
	}

	public void AddShowCastingBarRemovedListener(List<IShowCastingBarRemovedListener> newValue)
	{
		int num = 119;
		ShowCastingBarRemovedListenerComponent showCastingBarRemovedListenerComponent = (ShowCastingBarRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowCastingBarRemovedListenerComponent));
		showCastingBarRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showCastingBarRemovedListenerComponent);
	}

	public void ReplaceShowCastingBarRemovedListener(List<IShowCastingBarRemovedListener> newValue)
	{
		int num = 119;
		ShowCastingBarRemovedListenerComponent showCastingBarRemovedListenerComponent = (ShowCastingBarRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowCastingBarRemovedListenerComponent));
		showCastingBarRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showCastingBarRemovedListenerComponent);
	}

	public void RemoveShowCastingBarRemovedListener()
	{
		((Entity)this).RemoveComponent(119);
	}

	public void AddShowCastingBarRemovedListener(IShowCastingBarRemovedListener value)
	{
		List<IShowCastingBarRemovedListener> list = (hasShowCastingBarRemovedListener ? showCastingBarRemovedListener.value : new List<IShowCastingBarRemovedListener>());
		list.Add(value);
		ReplaceShowCastingBarRemovedListener(list);
	}

	public void RemoveShowCastingBarRemovedListener(IShowCastingBarRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShowCastingBarRemovedListener> value2 = showCastingBarRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShowCastingBarRemovedListener();
		}
		else
		{
			ReplaceShowCastingBarRemovedListener(value2);
		}
	}

	public void AddShowGizmos(bool newValue)
	{
		int num = 120;
		ShowGizmosComponent showGizmosComponent = (ShowGizmosComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowGizmosComponent));
		showGizmosComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showGizmosComponent);
	}

	public void ReplaceShowGizmos(bool newValue)
	{
		int num = 120;
		ShowGizmosComponent showGizmosComponent = (ShowGizmosComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowGizmosComponent));
		showGizmosComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showGizmosComponent);
	}

	public void RemoveShowGizmos()
	{
		((Entity)this).RemoveComponent(120);
	}

	public void AddShowGizmosListener(List<IShowGizmosListener> newValue)
	{
		int num = 121;
		ShowGizmosListenerComponent showGizmosListenerComponent = (ShowGizmosListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowGizmosListenerComponent));
		showGizmosListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showGizmosListenerComponent);
	}

	public void ReplaceShowGizmosListener(List<IShowGizmosListener> newValue)
	{
		int num = 121;
		ShowGizmosListenerComponent showGizmosListenerComponent = (ShowGizmosListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowGizmosListenerComponent));
		showGizmosListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showGizmosListenerComponent);
	}

	public void RemoveShowGizmosListener()
	{
		((Entity)this).RemoveComponent(121);
	}

	public void AddShowGizmosListener(IShowGizmosListener value)
	{
		List<IShowGizmosListener> list = (hasShowGizmosListener ? showGizmosListener.value : new List<IShowGizmosListener>());
		list.Add(value);
		ReplaceShowGizmosListener(list);
	}

	public void RemoveShowGizmosListener(IShowGizmosListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShowGizmosListener> value2 = showGizmosListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShowGizmosListener();
		}
		else
		{
			ReplaceShowGizmosListener(value2);
		}
	}

	public void AddShowHealthBarListener(List<IShowHealthBarListener> newValue)
	{
		int num = 123;
		ShowHealthBarListenerComponent showHealthBarListenerComponent = (ShowHealthBarListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowHealthBarListenerComponent));
		showHealthBarListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showHealthBarListenerComponent);
	}

	public void ReplaceShowHealthBarListener(List<IShowHealthBarListener> newValue)
	{
		int num = 123;
		ShowHealthBarListenerComponent showHealthBarListenerComponent = (ShowHealthBarListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowHealthBarListenerComponent));
		showHealthBarListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showHealthBarListenerComponent);
	}

	public void RemoveShowHealthBarListener()
	{
		((Entity)this).RemoveComponent(123);
	}

	public void AddShowHealthBarListener(IShowHealthBarListener value)
	{
		List<IShowHealthBarListener> list = (hasShowHealthBarListener ? showHealthBarListener.value : new List<IShowHealthBarListener>());
		list.Add(value);
		ReplaceShowHealthBarListener(list);
	}

	public void RemoveShowHealthBarListener(IShowHealthBarListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShowHealthBarListener> value2 = showHealthBarListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShowHealthBarListener();
		}
		else
		{
			ReplaceShowHealthBarListener(value2);
		}
	}

	public void AddShowHealthBarRemovedListener(List<IShowHealthBarRemovedListener> newValue)
	{
		int num = 124;
		ShowHealthBarRemovedListenerComponent showHealthBarRemovedListenerComponent = (ShowHealthBarRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowHealthBarRemovedListenerComponent));
		showHealthBarRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)showHealthBarRemovedListenerComponent);
	}

	public void ReplaceShowHealthBarRemovedListener(List<IShowHealthBarRemovedListener> newValue)
	{
		int num = 124;
		ShowHealthBarRemovedListenerComponent showHealthBarRemovedListenerComponent = (ShowHealthBarRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(ShowHealthBarRemovedListenerComponent));
		showHealthBarRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)showHealthBarRemovedListenerComponent);
	}

	public void RemoveShowHealthBarRemovedListener()
	{
		((Entity)this).RemoveComponent(124);
	}

	public void AddShowHealthBarRemovedListener(IShowHealthBarRemovedListener value)
	{
		List<IShowHealthBarRemovedListener> list = (hasShowHealthBarRemovedListener ? showHealthBarRemovedListener.value : new List<IShowHealthBarRemovedListener>());
		list.Add(value);
		ReplaceShowHealthBarRemovedListener(list);
	}

	public void RemoveShowHealthBarRemovedListener(IShowHealthBarRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IShowHealthBarRemovedListener> value2 = showHealthBarRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveShowHealthBarRemovedListener();
		}
		else
		{
			ReplaceShowHealthBarRemovedListener(value2);
		}
	}

	public void AddSize(float newValue)
	{
		int num = 125;
		SizeComponent sizeComponent = (SizeComponent)(object)((Entity)this).CreateComponent(num, typeof(SizeComponent));
		sizeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)sizeComponent);
	}

	public void ReplaceSize(float newValue)
	{
		int num = 125;
		SizeComponent sizeComponent = (SizeComponent)(object)((Entity)this).CreateComponent(num, typeof(SizeComponent));
		sizeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)sizeComponent);
	}

	public void RemoveSize()
	{
		((Entity)this).RemoveComponent(125);
	}

	public void AddSkeleton(ISkeleton newValue)
	{
		int num = 126;
		SkeletonComponent skeletonComponent = (SkeletonComponent)(object)((Entity)this).CreateComponent(num, typeof(SkeletonComponent));
		skeletonComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)skeletonComponent);
	}

	public void ReplaceSkeleton(ISkeleton newValue)
	{
		int num = 126;
		SkeletonComponent skeletonComponent = (SkeletonComponent)(object)((Entity)this).CreateComponent(num, typeof(SkeletonComponent));
		skeletonComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)skeletonComponent);
	}

	public void RemoveSkeleton()
	{
		((Entity)this).RemoveComponent(126);
	}

	public void AddSkeletonListener(List<ISkeletonListener> newValue)
	{
		int num = 127;
		SkeletonListenerComponent skeletonListenerComponent = (SkeletonListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SkeletonListenerComponent));
		skeletonListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)skeletonListenerComponent);
	}

	public void ReplaceSkeletonListener(List<ISkeletonListener> newValue)
	{
		int num = 127;
		SkeletonListenerComponent skeletonListenerComponent = (SkeletonListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SkeletonListenerComponent));
		skeletonListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)skeletonListenerComponent);
	}

	public void RemoveSkeletonListener()
	{
		((Entity)this).RemoveComponent(127);
	}

	public void AddSkeletonListener(ISkeletonListener value)
	{
		List<ISkeletonListener> list = (hasSkeletonListener ? skeletonListener.value : new List<ISkeletonListener>());
		list.Add(value);
		ReplaceSkeletonListener(list);
	}

	public void RemoveSkeletonListener(ISkeletonListener value, bool removeComponentWhenEmpty = true)
	{
		List<ISkeletonListener> value2 = skeletonListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveSkeletonListener();
		}
		else
		{
			ReplaceSkeletonListener(value2);
		}
	}

	public void AddSkin(string newValue)
	{
		int num = 128;
		SkinComponent skinComponent = (SkinComponent)(object)((Entity)this).CreateComponent(num, typeof(SkinComponent));
		skinComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)skinComponent);
	}

	public void ReplaceSkin(string newValue)
	{
		int num = 128;
		SkinComponent skinComponent = (SkinComponent)(object)((Entity)this).CreateComponent(num, typeof(SkinComponent));
		skinComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)skinComponent);
	}

	public void RemoveSkin()
	{
		((Entity)this).RemoveComponent(128);
	}

	public void AddSkinListener(List<ISkinListener> newValue)
	{
		int num = 129;
		SkinListenerComponent skinListenerComponent = (SkinListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SkinListenerComponent));
		skinListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)skinListenerComponent);
	}

	public void ReplaceSkinListener(List<ISkinListener> newValue)
	{
		int num = 129;
		SkinListenerComponent skinListenerComponent = (SkinListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SkinListenerComponent));
		skinListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)skinListenerComponent);
	}

	public void RemoveSkinListener()
	{
		((Entity)this).RemoveComponent(129);
	}

	public void AddSkinListener(ISkinListener value)
	{
		List<ISkinListener> list = (hasSkinListener ? skinListener.value : new List<ISkinListener>());
		list.Add(value);
		ReplaceSkinListener(list);
	}

	public void RemoveSkinListener(ISkinListener value, bool removeComponentWhenEmpty = true)
	{
		List<ISkinListener> value2 = skinListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveSkinListener();
		}
		else
		{
			ReplaceSkinListener(value2);
		}
	}

	public void AddSourceId(int newValue)
	{
		int num = 130;
		SourceIdComponent sourceIdComponent = (SourceIdComponent)(object)((Entity)this).CreateComponent(num, typeof(SourceIdComponent));
		sourceIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)sourceIdComponent);
	}

	public void ReplaceSourceId(int newValue)
	{
		int num = 130;
		SourceIdComponent sourceIdComponent = (SourceIdComponent)(object)((Entity)this).CreateComponent(num, typeof(SourceIdComponent));
		sourceIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)sourceIdComponent);
	}

	public void RemoveSourceId()
	{
		((Entity)this).RemoveComponent(130);
	}

	public void AddSpecialFx(int newValue)
	{
		int num = 131;
		SpecialFxComponent specialFxComponent = (SpecialFxComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxComponent));
		specialFxComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)specialFxComponent);
	}

	public void ReplaceSpecialFx(int newValue)
	{
		int num = 131;
		SpecialFxComponent specialFxComponent = (SpecialFxComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxComponent));
		specialFxComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)specialFxComponent);
	}

	public void RemoveSpecialFx()
	{
		((Entity)this).RemoveComponent(131);
	}

	public void AddSpecialFxListener(List<ISpecialFxListener> newValue)
	{
		int num = 132;
		SpecialFxListenerComponent specialFxListenerComponent = (SpecialFxListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxListenerComponent));
		specialFxListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)specialFxListenerComponent);
	}

	public void ReplaceSpecialFxListener(List<ISpecialFxListener> newValue)
	{
		int num = 132;
		SpecialFxListenerComponent specialFxListenerComponent = (SpecialFxListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxListenerComponent));
		specialFxListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)specialFxListenerComponent);
	}

	public void RemoveSpecialFxListener()
	{
		((Entity)this).RemoveComponent(132);
	}

	public void AddSpecialFxListener(ISpecialFxListener value)
	{
		List<ISpecialFxListener> list = (hasSpecialFxListener ? specialFxListener.value : new List<ISpecialFxListener>());
		list.Add(value);
		ReplaceSpecialFxListener(list);
	}

	public void RemoveSpecialFxListener(ISpecialFxListener value, bool removeComponentWhenEmpty = true)
	{
		List<ISpecialFxListener> value2 = specialFxListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveSpecialFxListener();
		}
		else
		{
			ReplaceSpecialFxListener(value2);
		}
	}

	public void AddSpecialFxRemovedListener(List<ISpecialFxRemovedListener> newValue)
	{
		int num = 133;
		SpecialFxRemovedListenerComponent specialFxRemovedListenerComponent = (SpecialFxRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxRemovedListenerComponent));
		specialFxRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)specialFxRemovedListenerComponent);
	}

	public void ReplaceSpecialFxRemovedListener(List<ISpecialFxRemovedListener> newValue)
	{
		int num = 133;
		SpecialFxRemovedListenerComponent specialFxRemovedListenerComponent = (SpecialFxRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(SpecialFxRemovedListenerComponent));
		specialFxRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)specialFxRemovedListenerComponent);
	}

	public void RemoveSpecialFxRemovedListener()
	{
		((Entity)this).RemoveComponent(133);
	}

	public void AddSpecialFxRemovedListener(ISpecialFxRemovedListener value)
	{
		List<ISpecialFxRemovedListener> list = (hasSpecialFxRemovedListener ? specialFxRemovedListener.value : new List<ISpecialFxRemovedListener>());
		list.Add(value);
		ReplaceSpecialFxRemovedListener(list);
	}

	public void RemoveSpecialFxRemovedListener(ISpecialFxRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<ISpecialFxRemovedListener> value2 = specialFxRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveSpecialFxRemovedListener();
		}
		else
		{
			ReplaceSpecialFxRemovedListener(value2);
		}
	}

	public void AddStartPosition(Vector3 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 134;
		StartPositionComponent startPositionComponent = (StartPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(StartPositionComponent));
		startPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)startPositionComponent);
	}

	public void ReplaceStartPosition(Vector3 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 134;
		StartPositionComponent startPositionComponent = (StartPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(StartPositionComponent));
		startPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)startPositionComponent);
	}

	public void RemoveStartPosition()
	{
		((Entity)this).RemoveComponent(134);
	}

	public void AddTags(List<string> newValue)
	{
		int num = 135;
		TagsComponent tagsComponent = (TagsComponent)(object)((Entity)this).CreateComponent(num, typeof(TagsComponent));
		tagsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tagsComponent);
	}

	public void ReplaceTags(List<string> newValue)
	{
		int num = 135;
		TagsComponent tagsComponent = (TagsComponent)(object)((Entity)this).CreateComponent(num, typeof(TagsComponent));
		tagsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tagsComponent);
	}

	public void RemoveTags()
	{
		((Entity)this).RemoveComponent(135);
	}

	public void AddTargetId(int newValue)
	{
		int num = 136;
		TargetIdComponent targetIdComponent = (TargetIdComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetIdComponent));
		targetIdComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)targetIdComponent);
	}

	public void ReplaceTargetId(int newValue)
	{
		int num = 136;
		TargetIdComponent targetIdComponent = (TargetIdComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetIdComponent));
		targetIdComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)targetIdComponent);
	}

	public void RemoveTargetId()
	{
		((Entity)this).RemoveComponent(136);
	}

	public void AddTargetPosition(Vector3 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 137;
		TargetPositionComponent targetPositionComponent = (TargetPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetPositionComponent));
		targetPositionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)targetPositionComponent);
	}

	public void ReplaceTargetPosition(Vector3 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 137;
		TargetPositionComponent targetPositionComponent = (TargetPositionComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetPositionComponent));
		targetPositionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)targetPositionComponent);
	}

	public void RemoveTargetPosition()
	{
		((Entity)this).RemoveComponent(137);
	}

	public void AddTargetPositionListener(List<ITargetPositionListener> newValue)
	{
		int num = 138;
		TargetPositionListenerComponent targetPositionListenerComponent = (TargetPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetPositionListenerComponent));
		targetPositionListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)targetPositionListenerComponent);
	}

	public void ReplaceTargetPositionListener(List<ITargetPositionListener> newValue)
	{
		int num = 138;
		TargetPositionListenerComponent targetPositionListenerComponent = (TargetPositionListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(TargetPositionListenerComponent));
		targetPositionListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)targetPositionListenerComponent);
	}

	public void RemoveTargetPositionListener()
	{
		((Entity)this).RemoveComponent(138);
	}

	public void AddTargetPositionListener(ITargetPositionListener value)
	{
		List<ITargetPositionListener> list = (hasTargetPositionListener ? targetPositionListener.value : new List<ITargetPositionListener>());
		list.Add(value);
		ReplaceTargetPositionListener(list);
	}

	public void RemoveTargetPositionListener(ITargetPositionListener value, bool removeComponentWhenEmpty = true)
	{
		List<ITargetPositionListener> value2 = targetPositionListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveTargetPositionListener();
		}
		else
		{
			ReplaceTargetPositionListener(value2);
		}
	}

	public void AddTeam(Team newValue)
	{
		int num = 139;
		TeamComponent teamComponent = (TeamComponent)(object)((Entity)this).CreateComponent(num, typeof(TeamComponent));
		teamComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)teamComponent);
	}

	public void ReplaceTeam(Team newValue)
	{
		int num = 139;
		TeamComponent teamComponent = (TeamComponent)(object)((Entity)this).CreateComponent(num, typeof(TeamComponent));
		teamComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)teamComponent);
	}

	public void RemoveTeam()
	{
		((Entity)this).RemoveComponent(139);
	}

	public void AddTickElapsedTime(float newValue)
	{
		int num = 140;
		TickElapsedTimeComponent tickElapsedTimeComponent = (TickElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(TickElapsedTimeComponent));
		tickElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tickElapsedTimeComponent);
	}

	public void ReplaceTickElapsedTime(float newValue)
	{
		int num = 140;
		TickElapsedTimeComponent tickElapsedTimeComponent = (TickElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(TickElapsedTimeComponent));
		tickElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tickElapsedTimeComponent);
	}

	public void RemoveTickElapsedTime()
	{
		((Entity)this).RemoveComponent(140);
	}

	public void AddTickInterval(float newValue)
	{
		int num = 141;
		TickIntervalComponent tickIntervalComponent = (TickIntervalComponent)(object)((Entity)this).CreateComponent(num, typeof(TickIntervalComponent));
		tickIntervalComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tickIntervalComponent);
	}

	public void ReplaceTickInterval(float newValue)
	{
		int num = 141;
		TickIntervalComponent tickIntervalComponent = (TickIntervalComponent)(object)((Entity)this).CreateComponent(num, typeof(TickIntervalComponent));
		tickIntervalComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tickIntervalComponent);
	}

	public void RemoveTickInterval()
	{
		((Entity)this).RemoveComponent(141);
	}

	public void AddUnitBaseImage(string newValue)
	{
		int num = 142;
		UnitBaseImageComponent unitBaseImageComponent = (UnitBaseImageComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageComponent));
		unitBaseImageComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitBaseImageComponent);
	}

	public void ReplaceUnitBaseImage(string newValue)
	{
		int num = 142;
		UnitBaseImageComponent unitBaseImageComponent = (UnitBaseImageComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageComponent));
		unitBaseImageComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitBaseImageComponent);
	}

	public void RemoveUnitBaseImage()
	{
		((Entity)this).RemoveComponent(142);
	}

	public void AddUnitBaseImageListener(List<IUnitBaseImageListener> newValue)
	{
		int num = 143;
		UnitBaseImageListenerComponent unitBaseImageListenerComponent = (UnitBaseImageListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageListenerComponent));
		unitBaseImageListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitBaseImageListenerComponent);
	}

	public void ReplaceUnitBaseImageListener(List<IUnitBaseImageListener> newValue)
	{
		int num = 143;
		UnitBaseImageListenerComponent unitBaseImageListenerComponent = (UnitBaseImageListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageListenerComponent));
		unitBaseImageListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitBaseImageListenerComponent);
	}

	public void RemoveUnitBaseImageListener()
	{
		((Entity)this).RemoveComponent(143);
	}

	public void AddUnitBaseImageListener(IUnitBaseImageListener value)
	{
		List<IUnitBaseImageListener> list = (hasUnitBaseImageListener ? unitBaseImageListener.value : new List<IUnitBaseImageListener>());
		list.Add(value);
		ReplaceUnitBaseImageListener(list);
	}

	public void RemoveUnitBaseImageListener(IUnitBaseImageListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitBaseImageListener> value2 = unitBaseImageListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitBaseImageListener();
		}
		else
		{
			ReplaceUnitBaseImageListener(value2);
		}
	}

	public void AddUnitBaseImageRemovedListener(List<IUnitBaseImageRemovedListener> newValue)
	{
		int num = 144;
		UnitBaseImageRemovedListenerComponent unitBaseImageRemovedListenerComponent = (UnitBaseImageRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageRemovedListenerComponent));
		unitBaseImageRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitBaseImageRemovedListenerComponent);
	}

	public void ReplaceUnitBaseImageRemovedListener(List<IUnitBaseImageRemovedListener> newValue)
	{
		int num = 144;
		UnitBaseImageRemovedListenerComponent unitBaseImageRemovedListenerComponent = (UnitBaseImageRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitBaseImageRemovedListenerComponent));
		unitBaseImageRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitBaseImageRemovedListenerComponent);
	}

	public void RemoveUnitBaseImageRemovedListener()
	{
		((Entity)this).RemoveComponent(144);
	}

	public void AddUnitBaseImageRemovedListener(IUnitBaseImageRemovedListener value)
	{
		List<IUnitBaseImageRemovedListener> list = (hasUnitBaseImageRemovedListener ? unitBaseImageRemovedListener.value : new List<IUnitBaseImageRemovedListener>());
		list.Add(value);
		ReplaceUnitBaseImageRemovedListener(list);
	}

	public void RemoveUnitBaseImageRemovedListener(IUnitBaseImageRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitBaseImageRemovedListener> value2 = unitBaseImageRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitBaseImageRemovedListener();
		}
		else
		{
			ReplaceUnitBaseImageRemovedListener(value2);
		}
	}

	public void AddUnitIdentifier(string newValue)
	{
		int num = 146;
		UnitIdentifierComponent unitIdentifierComponent = (UnitIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIdentifierComponent));
		unitIdentifierComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitIdentifierComponent);
	}

	public void ReplaceUnitIdentifier(string newValue)
	{
		int num = 146;
		UnitIdentifierComponent unitIdentifierComponent = (UnitIdentifierComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIdentifierComponent));
		unitIdentifierComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitIdentifierComponent);
	}

	public void RemoveUnitIdentifier()
	{
		((Entity)this).RemoveComponent(146);
	}

	public void AddUnitImageIndicator(string newValue)
	{
		int num = 147;
		UnitImageIndicatorComponent unitImageIndicatorComponent = (UnitImageIndicatorComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorComponent));
		unitImageIndicatorComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitImageIndicatorComponent);
	}

	public void ReplaceUnitImageIndicator(string newValue)
	{
		int num = 147;
		UnitImageIndicatorComponent unitImageIndicatorComponent = (UnitImageIndicatorComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorComponent));
		unitImageIndicatorComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitImageIndicatorComponent);
	}

	public void RemoveUnitImageIndicator()
	{
		((Entity)this).RemoveComponent(147);
	}

	public void AddUnitImageIndicatorListener(List<IUnitImageIndicatorListener> newValue)
	{
		int num = 148;
		UnitImageIndicatorListenerComponent unitImageIndicatorListenerComponent = (UnitImageIndicatorListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorListenerComponent));
		unitImageIndicatorListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitImageIndicatorListenerComponent);
	}

	public void ReplaceUnitImageIndicatorListener(List<IUnitImageIndicatorListener> newValue)
	{
		int num = 148;
		UnitImageIndicatorListenerComponent unitImageIndicatorListenerComponent = (UnitImageIndicatorListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorListenerComponent));
		unitImageIndicatorListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitImageIndicatorListenerComponent);
	}

	public void RemoveUnitImageIndicatorListener()
	{
		((Entity)this).RemoveComponent(148);
	}

	public void AddUnitImageIndicatorListener(IUnitImageIndicatorListener value)
	{
		List<IUnitImageIndicatorListener> list = (hasUnitImageIndicatorListener ? unitImageIndicatorListener.value : new List<IUnitImageIndicatorListener>());
		list.Add(value);
		ReplaceUnitImageIndicatorListener(list);
	}

	public void RemoveUnitImageIndicatorListener(IUnitImageIndicatorListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitImageIndicatorListener> value2 = unitImageIndicatorListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitImageIndicatorListener();
		}
		else
		{
			ReplaceUnitImageIndicatorListener(value2);
		}
	}

	public void AddUnitImageIndicatorRemovedListener(List<IUnitImageIndicatorRemovedListener> newValue)
	{
		int num = 149;
		UnitImageIndicatorRemovedListenerComponent unitImageIndicatorRemovedListenerComponent = (UnitImageIndicatorRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorRemovedListenerComponent));
		unitImageIndicatorRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitImageIndicatorRemovedListenerComponent);
	}

	public void ReplaceUnitImageIndicatorRemovedListener(List<IUnitImageIndicatorRemovedListener> newValue)
	{
		int num = 149;
		UnitImageIndicatorRemovedListenerComponent unitImageIndicatorRemovedListenerComponent = (UnitImageIndicatorRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitImageIndicatorRemovedListenerComponent));
		unitImageIndicatorRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitImageIndicatorRemovedListenerComponent);
	}

	public void RemoveUnitImageIndicatorRemovedListener()
	{
		((Entity)this).RemoveComponent(149);
	}

	public void AddUnitImageIndicatorRemovedListener(IUnitImageIndicatorRemovedListener value)
	{
		List<IUnitImageIndicatorRemovedListener> list = (hasUnitImageIndicatorRemovedListener ? unitImageIndicatorRemovedListener.value : new List<IUnitImageIndicatorRemovedListener>());
		list.Add(value);
		ReplaceUnitImageIndicatorRemovedListener(list);
	}

	public void RemoveUnitImageIndicatorRemovedListener(IUnitImageIndicatorRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitImageIndicatorRemovedListener> value2 = unitImageIndicatorRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitImageIndicatorRemovedListener();
		}
		else
		{
			ReplaceUnitImageIndicatorRemovedListener(value2);
		}
	}

	public void AddUnitIndicator(Color32 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 150;
		UnitIndicatorComponent unitIndicatorComponent = (UnitIndicatorComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorComponent));
		unitIndicatorComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitIndicatorComponent);
	}

	public void ReplaceUnitIndicator(Color32 newValue)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int num = 150;
		UnitIndicatorComponent unitIndicatorComponent = (UnitIndicatorComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorComponent));
		unitIndicatorComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitIndicatorComponent);
	}

	public void RemoveUnitIndicator()
	{
		((Entity)this).RemoveComponent(150);
	}

	public void AddUnitIndicatorListener(List<IUnitIndicatorListener> newValue)
	{
		int num = 151;
		UnitIndicatorListenerComponent unitIndicatorListenerComponent = (UnitIndicatorListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorListenerComponent));
		unitIndicatorListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitIndicatorListenerComponent);
	}

	public void ReplaceUnitIndicatorListener(List<IUnitIndicatorListener> newValue)
	{
		int num = 151;
		UnitIndicatorListenerComponent unitIndicatorListenerComponent = (UnitIndicatorListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorListenerComponent));
		unitIndicatorListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitIndicatorListenerComponent);
	}

	public void RemoveUnitIndicatorListener()
	{
		((Entity)this).RemoveComponent(151);
	}

	public void AddUnitIndicatorListener(IUnitIndicatorListener value)
	{
		List<IUnitIndicatorListener> list = (hasUnitIndicatorListener ? unitIndicatorListener.value : new List<IUnitIndicatorListener>());
		list.Add(value);
		ReplaceUnitIndicatorListener(list);
	}

	public void RemoveUnitIndicatorListener(IUnitIndicatorListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitIndicatorListener> value2 = unitIndicatorListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitIndicatorListener();
		}
		else
		{
			ReplaceUnitIndicatorListener(value2);
		}
	}

	public void AddUnitIndicatorRemovedListener(List<IUnitIndicatorRemovedListener> newValue)
	{
		int num = 152;
		UnitIndicatorRemovedListenerComponent unitIndicatorRemovedListenerComponent = (UnitIndicatorRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorRemovedListenerComponent));
		unitIndicatorRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitIndicatorRemovedListenerComponent);
	}

	public void ReplaceUnitIndicatorRemovedListener(List<IUnitIndicatorRemovedListener> newValue)
	{
		int num = 152;
		UnitIndicatorRemovedListenerComponent unitIndicatorRemovedListenerComponent = (UnitIndicatorRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitIndicatorRemovedListenerComponent));
		unitIndicatorRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitIndicatorRemovedListenerComponent);
	}

	public void RemoveUnitIndicatorRemovedListener()
	{
		((Entity)this).RemoveComponent(152);
	}

	public void AddUnitIndicatorRemovedListener(IUnitIndicatorRemovedListener value)
	{
		List<IUnitIndicatorRemovedListener> list = (hasUnitIndicatorRemovedListener ? unitIndicatorRemovedListener.value : new List<IUnitIndicatorRemovedListener>());
		list.Add(value);
		ReplaceUnitIndicatorRemovedListener(list);
	}

	public void RemoveUnitIndicatorRemovedListener(IUnitIndicatorRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitIndicatorRemovedListener> value2 = unitIndicatorRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitIndicatorRemovedListener();
		}
		else
		{
			ReplaceUnitIndicatorRemovedListener(value2);
		}
	}

	public void AddUnitScale(float newValue)
	{
		int num = 153;
		UnitScaleComponent unitScaleComponent = (UnitScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitScaleComponent));
		unitScaleComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitScaleComponent);
	}

	public void ReplaceUnitScale(float newValue)
	{
		int num = 153;
		UnitScaleComponent unitScaleComponent = (UnitScaleComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitScaleComponent));
		unitScaleComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitScaleComponent);
	}

	public void RemoveUnitScale()
	{
		((Entity)this).RemoveComponent(153);
	}

	public void AddUnitScaleListener(List<IUnitScaleListener> newValue)
	{
		int num = 154;
		UnitScaleListenerComponent unitScaleListenerComponent = (UnitScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitScaleListenerComponent));
		unitScaleListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitScaleListenerComponent);
	}

	public void ReplaceUnitScaleListener(List<IUnitScaleListener> newValue)
	{
		int num = 154;
		UnitScaleListenerComponent unitScaleListenerComponent = (UnitScaleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitScaleListenerComponent));
		unitScaleListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitScaleListenerComponent);
	}

	public void RemoveUnitScaleListener()
	{
		((Entity)this).RemoveComponent(154);
	}

	public void AddUnitScaleListener(IUnitScaleListener value)
	{
		List<IUnitScaleListener> list = (hasUnitScaleListener ? unitScaleListener.value : new List<IUnitScaleListener>());
		list.Add(value);
		ReplaceUnitScaleListener(list);
	}

	public void RemoveUnitScaleListener(IUnitScaleListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitScaleListener> value2 = unitScaleListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitScaleListener();
		}
		else
		{
			ReplaceUnitScaleListener(value2);
		}
	}

	public void AddUnitStats(UnitStats newValue)
	{
		int num = 155;
		UnitStatsComponent unitStatsComponent = (UnitStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitStatsComponent));
		unitStatsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitStatsComponent);
	}

	public void ReplaceUnitStats(UnitStats newValue)
	{
		int num = 155;
		UnitStatsComponent unitStatsComponent = (UnitStatsComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitStatsComponent));
		unitStatsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitStatsComponent);
	}

	public void RemoveUnitStats()
	{
		((Entity)this).RemoveComponent(155);
	}

	public void AddUnitStatsListener(List<IUnitStatsListener> newValue)
	{
		int num = 156;
		UnitStatsListenerComponent unitStatsListenerComponent = (UnitStatsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitStatsListenerComponent));
		unitStatsListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitStatsListenerComponent);
	}

	public void ReplaceUnitStatsListener(List<IUnitStatsListener> newValue)
	{
		int num = 156;
		UnitStatsListenerComponent unitStatsListenerComponent = (UnitStatsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitStatsListenerComponent));
		unitStatsListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitStatsListenerComponent);
	}

	public void RemoveUnitStatsListener()
	{
		((Entity)this).RemoveComponent(156);
	}

	public void AddUnitStatsListener(IUnitStatsListener value)
	{
		List<IUnitStatsListener> list = (hasUnitStatsListener ? unitStatsListener.value : new List<IUnitStatsListener>());
		list.Add(value);
		ReplaceUnitStatsListener(list);
	}

	public void RemoveUnitStatsListener(IUnitStatsListener value, bool removeComponentWhenEmpty = true)
	{
		List<IUnitStatsListener> value2 = unitStatsListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveUnitStatsListener();
		}
		else
		{
			ReplaceUnitStatsListener(value2);
		}
	}

	public void AddView(IView newValue)
	{
		int num = 157;
		ViewComponent viewComponent = (ViewComponent)(object)((Entity)this).CreateComponent(num, typeof(ViewComponent));
		viewComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)viewComponent);
	}

	public void ReplaceView(IView newValue)
	{
		int num = 157;
		ViewComponent viewComponent = (ViewComponent)(object)((Entity)this).CreateComponent(num, typeof(ViewComponent));
		viewComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)viewComponent);
	}

	public void RemoveView()
	{
		((Entity)this).RemoveComponent(157);
	}

	public void AddVisibleListener(List<IVisibleListener> newValue)
	{
		int num = 159;
		VisibleListenerComponent visibleListenerComponent = (VisibleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(VisibleListenerComponent));
		visibleListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)visibleListenerComponent);
	}

	public void ReplaceVisibleListener(List<IVisibleListener> newValue)
	{
		int num = 159;
		VisibleListenerComponent visibleListenerComponent = (VisibleListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(VisibleListenerComponent));
		visibleListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)visibleListenerComponent);
	}

	public void RemoveVisibleListener()
	{
		((Entity)this).RemoveComponent(159);
	}

	public void AddVisibleListener(IVisibleListener value)
	{
		List<IVisibleListener> list = (hasVisibleListener ? visibleListener.value : new List<IVisibleListener>());
		list.Add(value);
		ReplaceVisibleListener(list);
	}

	public void RemoveVisibleListener(IVisibleListener value, bool removeComponentWhenEmpty = true)
	{
		List<IVisibleListener> value2 = visibleListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveVisibleListener();
		}
		else
		{
			ReplaceVisibleListener(value2);
		}
	}

	public void AddVisibleRemovedListener(List<IVisibleRemovedListener> newValue)
	{
		int num = 160;
		VisibleRemovedListenerComponent visibleRemovedListenerComponent = (VisibleRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(VisibleRemovedListenerComponent));
		visibleRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)visibleRemovedListenerComponent);
	}

	public void ReplaceVisibleRemovedListener(List<IVisibleRemovedListener> newValue)
	{
		int num = 160;
		VisibleRemovedListenerComponent visibleRemovedListenerComponent = (VisibleRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(VisibleRemovedListenerComponent));
		visibleRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)visibleRemovedListenerComponent);
	}

	public void RemoveVisibleRemovedListener()
	{
		((Entity)this).RemoveComponent(160);
	}

	public void AddVisibleRemovedListener(IVisibleRemovedListener value)
	{
		List<IVisibleRemovedListener> list = (hasVisibleRemovedListener ? visibleRemovedListener.value : new List<IVisibleRemovedListener>());
		list.Add(value);
		ReplaceVisibleRemovedListener(list);
	}

	public void RemoveVisibleRemovedListener(IVisibleRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IVisibleRemovedListener> value2 = visibleRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveVisibleRemovedListener();
		}
		else
		{
			ReplaceVisibleRemovedListener(value2);
		}
	}
}
