using Entitas;

public sealed class GameMatcher
{
	private static IMatcher<GameEntity> _matcherAiObject;

	private static IMatcher<GameEntity> _matcherAlpha;

	private static IMatcher<GameEntity> _matcherAlphaListener;

	private static IMatcher<GameEntity> _matcherAnimation;

	private static IMatcher<GameEntity> _matcherAnimationDuration;

	private static IMatcher<GameEntity> _matcherAnimationDurationListener;

	private static IMatcher<GameEntity> _matcherAnimationInitialized;

	private static IMatcher<GameEntity> _matcherAnimationInitializedListener;

	private static IMatcher<GameEntity> _matcherAnimationListener;

	private static IMatcher<GameEntity> _matcherAnimationSpeed;

	private static IMatcher<GameEntity> _matcherAnimator;

	private static IMatcher<GameEntity> _matcherAnimatorInited;

	private static IMatcher<GameEntity> _matcherAnyAssetListener;

	private static IMatcher<GameEntity> _matcherAnyBattleFieldListener;

	private static IMatcher<GameEntity> _matcherAnyCameraListener;

	private static IMatcher<GameEntity> _matcherAnyPlayerListener;

	private static IMatcher<GameEntity> _matcherAnySceneLoadedListener;

	private static IMatcher<GameEntity> _matcherAnyUnitListener;

	private static IMatcher<GameEntity> _matcherAsset;

	private static IMatcher<GameEntity> _matcherAssetRemovedListener;

	private static IMatcher<GameEntity> _matcherAudioClipName;

	private static IMatcher<GameEntity> _matcherAudioClipNameListener;

	private static IMatcher<GameEntity> _matcherAudio;

	private static IMatcher<GameEntity> _matcherAudioVolume;

	private static IMatcher<GameEntity> _matcherAudioVolumeListener;

	private static IMatcher<GameEntity> _matcherBattleCost;

	private static IMatcher<GameEntity> _matcherBattleField;

	private static IMatcher<GameEntity> _matcherBattleFieldXMargin;

	private static IMatcher<GameEntity> _matcherBattleMode;

	private static IMatcher<GameEntity> _matcherBoneName;

	private static IMatcher<GameEntity> _matcherBuildingUnit;

	private static IMatcher<GameEntity> _matcherCamera;

	private static IMatcher<GameEntity> _matcherCameraMoveToPosition;

	private static IMatcher<GameEntity> _matcherCameraMoveToPositionDuration;

	private static IMatcher<GameEntity> _matcherCameraMoveToPositionElapsedTime;

	private static IMatcher<GameEntity> _matcherCastingAbilityCastTime;

	private static IMatcher<GameEntity> _matcherCastingAbility;

	private static IMatcher<GameEntity> _matcherCastingAbilityElapsedTime;

	private static IMatcher<GameEntity> _matcherCastingAbilityElapsedTimeListener;

	private static IMatcher<GameEntity> _matcherCharacter;

	private static IMatcher<GameEntity> _matcherCollisionRadius;

	private static IMatcher<GameEntity> _matcherCollisionRadiusListener;

	private static IMatcher<GameEntity> _matcherCreationTick;

	private static IMatcher<GameEntity> _matcherDead;

	private static IMatcher<GameEntity> _matcherDeadElapsedTick;

	private static IMatcher<GameEntity> _matcherDeadListener;

	private static IMatcher<GameEntity> _matcherDestroyable;

	private static IMatcher<GameEntity> _matcherDestroyed;

	private static IMatcher<GameEntity> _matcherDungeon;

	private static IMatcher<GameEntity> _matcherDuration;

	private static IMatcher<GameEntity> _matcherElapsedTime;

	private static IMatcher<GameEntity> _matcherFaceDirection;

	private static IMatcher<GameEntity> _matcherFloatingTextAlpha;

	private static IMatcher<GameEntity> _matcherFloatingTextAlphaListener;

	private static IMatcher<GameEntity> _matcherFloatingText;

	private static IMatcher<GameEntity> _matcherFloatingTextListener;

	private static IMatcher<GameEntity> _matcherFlowLightFx;

	private static IMatcher<GameEntity> _matcherFlowLightFxListener;

	private static IMatcher<GameEntity> _matcherFlowLightFxRemovedListener;

	private static IMatcher<GameEntity> _matcherFxController;

	private static IMatcher<GameEntity> _matcherGameDestroyedListener;

	private static IMatcher<GameEntity> _matcherGameObject;

	private static IMatcher<GameEntity> _matcherGroupSourceId;

	private static IMatcher<GameEntity> _matcherGroupTargetId;

	private static IMatcher<GameEntity> _matcherGroupUnitId;

	private static IMatcher<GameEntity> _matcherGroupUnits;

	private static IMatcher<GameEntity> _matcherHeight;

	private static IMatcher<GameEntity> _matcherHeightListener;

	private static IMatcher<GameEntity> _matcherId;

	private static IMatcher<GameEntity> _matcherLandingBone;

	private static IMatcher<GameEntity> _matcherLaunchBone;

	private static IMatcher<GameEntity> _matcherLeftTime;

	private static IMatcher<GameEntity> _matcherLevelId;

	private static IMatcher<GameEntity> _matcherLevelInst;

	private static IMatcher<GameEntity> _matcherLoop;

	private static IMatcher<GameEntity> _matcherModel;

	private static IMatcher<GameEntity> _matcherModelListener;

	private static IMatcher<GameEntity> _matcherMoveSpeed;

	private static IMatcher<GameEntity> _matcherMoveSpeedListener;

	private static IMatcher<GameEntity> _matcherName;

	private static IMatcher<GameEntity> _matcherOwnerId;

	private static IMatcher<GameEntity> _matcherParabolaSpeed;

	private static IMatcher<GameEntity> _matcherParent;

	private static IMatcher<GameEntity> _matcherParentId;

	private static IMatcher<GameEntity> _matcherParticleBaseScale;

	private static IMatcher<GameEntity> _matcherParticle;

	private static IMatcher<GameEntity> _matcherParticleFollowTarget;

	private static IMatcher<GameEntity> _matcherParticleFollowTargetScale;

	private static IMatcher<GameEntity> _matcherParticleFullscreen;

	private static IMatcher<GameEntity> _matcherParticleFullscreenEndPosition;

	private static IMatcher<GameEntity> _matcherParticleFullscreenLayer;

	private static IMatcher<GameEntity> _matcherParticleFullscreenMoveDuration;

	private static IMatcher<GameEntity> _matcherParticleFullscreenMoveElapsedTime;

	private static IMatcher<GameEntity> _matcherParticleFullscreenStartPosition;

	private static IMatcher<GameEntity> _matcherParticleLiveWithOwner;

	private static IMatcher<GameEntity> _matcherParticleState;

	private static IMatcher<GameEntity> _matcherPlayer;

	private static IMatcher<GameEntity> _matcherPortalId;

	private static IMatcher<GameEntity> _matcherPortalUnitIndex;

	private static IMatcher<GameEntity> _matcherPosition;

	private static IMatcher<GameEntity> _matcherPositionListener;

	private static IMatcher<GameEntity> _matcherPriority;

	private static IMatcher<GameEntity> _matcherProjectile;

	private static IMatcher<GameEntity> _matcherProjectileFlying;

	private static IMatcher<GameEntity> _matcherProjectileIdentifier;

	private static IMatcher<GameEntity> _matcherProjectileMoveType;

	private static IMatcher<GameEntity> _matcherProjectileRatio;

	private static IMatcher<GameEntity> _matcherRotation;

	private static IMatcher<GameEntity> _matcherRotationListener;

	private static IMatcher<GameEntity> _matcherScale;

	private static IMatcher<GameEntity> _matcherScaleListener;

	private static IMatcher<GameEntity> _matcherSceneArguments;

	private static IMatcher<GameEntity> _matcherSceneLoaded;

	private static IMatcher<GameEntity> _matcherSceneName;

	private static IMatcher<GameEntity> _matcherShadow;

	private static IMatcher<GameEntity> _matcherShadowScale;

	private static IMatcher<GameEntity> _matcherShadowScaleListener;

	private static IMatcher<GameEntity> _matcherShowCastingBar;

	private static IMatcher<GameEntity> _matcherShowCastingBarListener;

	private static IMatcher<GameEntity> _matcherShowCastingBarRemovedListener;

	private static IMatcher<GameEntity> _matcherShowGizmos;

	private static IMatcher<GameEntity> _matcherShowGizmosListener;

	private static IMatcher<GameEntity> _matcherShowHealthBar;

	private static IMatcher<GameEntity> _matcherShowHealthBarListener;

	private static IMatcher<GameEntity> _matcherShowHealthBarRemovedListener;

	private static IMatcher<GameEntity> _matcherSize;

	private static IMatcher<GameEntity> _matcherSkeleton;

	private static IMatcher<GameEntity> _matcherSkeletonListener;

	private static IMatcher<GameEntity> _matcherSkin;

	private static IMatcher<GameEntity> _matcherSkinListener;

	private static IMatcher<GameEntity> _matcherSourceId;

	private static IMatcher<GameEntity> _matcherSpecialFx;

	private static IMatcher<GameEntity> _matcherSpecialFxListener;

	private static IMatcher<GameEntity> _matcherSpecialFxRemovedListener;

	private static IMatcher<GameEntity> _matcherStartPosition;

	private static IMatcher<GameEntity> _matcherTags;

	private static IMatcher<GameEntity> _matcherTargetId;

	private static IMatcher<GameEntity> _matcherTargetPosition;

	private static IMatcher<GameEntity> _matcherTargetPositionListener;

	private static IMatcher<GameEntity> _matcherTeam;

	private static IMatcher<GameEntity> _matcherTickElapsedTime;

	private static IMatcher<GameEntity> _matcherTickInterval;

	private static IMatcher<GameEntity> _matcherUnitBaseImage;

	private static IMatcher<GameEntity> _matcherUnitBaseImageListener;

	private static IMatcher<GameEntity> _matcherUnitBaseImageRemovedListener;

	private static IMatcher<GameEntity> _matcherUnit;

	private static IMatcher<GameEntity> _matcherUnitIdentifier;

	private static IMatcher<GameEntity> _matcherUnitImageIndicator;

	private static IMatcher<GameEntity> _matcherUnitImageIndicatorListener;

	private static IMatcher<GameEntity> _matcherUnitImageIndicatorRemovedListener;

	private static IMatcher<GameEntity> _matcherUnitIndicator;

	private static IMatcher<GameEntity> _matcherUnitIndicatorListener;

	private static IMatcher<GameEntity> _matcherUnitIndicatorRemovedListener;

	private static IMatcher<GameEntity> _matcherUnitScale;

	private static IMatcher<GameEntity> _matcherUnitScaleListener;

	private static IMatcher<GameEntity> _matcherUnitStats;

	private static IMatcher<GameEntity> _matcherUnitStatsListener;

	private static IMatcher<GameEntity> _matcherView;

	private static IMatcher<GameEntity> _matcherVisible;

	private static IMatcher<GameEntity> _matcherVisibleListener;

	private static IMatcher<GameEntity> _matcherVisibleRemovedListener;

	public static IMatcher<GameEntity> AiObject
	{
		get
		{
			if (_matcherAiObject == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1]);
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAiObject = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAiObject;
		}
	}

	public static IMatcher<GameEntity> Alpha
	{
		get
		{
			if (_matcherAlpha == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 1 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAlpha = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAlpha;
		}
	}

	public static IMatcher<GameEntity> AlphaListener
	{
		get
		{
			if (_matcherAlphaListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 2 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAlphaListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAlphaListener;
		}
	}

	public static IMatcher<GameEntity> Animation
	{
		get
		{
			if (_matcherAnimation == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 3 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimation = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimation;
		}
	}

	public static IMatcher<GameEntity> AnimationDuration
	{
		get
		{
			if (_matcherAnimationDuration == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 4 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationDuration = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationDuration;
		}
	}

	public static IMatcher<GameEntity> AnimationDurationListener
	{
		get
		{
			if (_matcherAnimationDurationListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 5 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationDurationListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationDurationListener;
		}
	}

	public static IMatcher<GameEntity> AnimationInitialized
	{
		get
		{
			if (_matcherAnimationInitialized == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 6 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationInitialized = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationInitialized;
		}
	}

	public static IMatcher<GameEntity> AnimationInitializedListener
	{
		get
		{
			if (_matcherAnimationInitializedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 7 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationInitializedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationInitializedListener;
		}
	}

	public static IMatcher<GameEntity> AnimationListener
	{
		get
		{
			if (_matcherAnimationListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 8 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationListener;
		}
	}

	public static IMatcher<GameEntity> AnimationSpeed
	{
		get
		{
			if (_matcherAnimationSpeed == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 9 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimationSpeed = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimationSpeed;
		}
	}

	public static IMatcher<GameEntity> Animator
	{
		get
		{
			if (_matcherAnimator == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 10 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimator = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimator;
		}
	}

	public static IMatcher<GameEntity> AnimatorInited
	{
		get
		{
			if (_matcherAnimatorInited == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 11 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnimatorInited = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnimatorInited;
		}
	}

	public static IMatcher<GameEntity> AnyAssetListener
	{
		get
		{
			if (_matcherAnyAssetListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 12 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnyAssetListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnyAssetListener;
		}
	}

	public static IMatcher<GameEntity> AnyBattleFieldListener
	{
		get
		{
			if (_matcherAnyBattleFieldListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 13 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnyBattleFieldListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnyBattleFieldListener;
		}
	}

	public static IMatcher<GameEntity> AnyCameraListener
	{
		get
		{
			if (_matcherAnyCameraListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 14 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnyCameraListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnyCameraListener;
		}
	}

	public static IMatcher<GameEntity> AnyPlayerListener
	{
		get
		{
			if (_matcherAnyPlayerListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 15 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnyPlayerListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnyPlayerListener;
		}
	}

	public static IMatcher<GameEntity> AnySceneLoadedListener
	{
		get
		{
			if (_matcherAnySceneLoadedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 16 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnySceneLoadedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnySceneLoadedListener;
		}
	}

	public static IMatcher<GameEntity> AnyUnitListener
	{
		get
		{
			if (_matcherAnyUnitListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 17 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAnyUnitListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAnyUnitListener;
		}
	}

	public static IMatcher<GameEntity> Asset
	{
		get
		{
			if (_matcherAsset == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 18 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAsset = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAsset;
		}
	}

	public static IMatcher<GameEntity> AssetRemovedListener
	{
		get
		{
			if (_matcherAssetRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 19 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAssetRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAssetRemovedListener;
		}
	}

	public static IMatcher<GameEntity> AudioClipName
	{
		get
		{
			if (_matcherAudioClipName == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 20 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAudioClipName = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAudioClipName;
		}
	}

	public static IMatcher<GameEntity> AudioClipNameListener
	{
		get
		{
			if (_matcherAudioClipNameListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 21 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAudioClipNameListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAudioClipNameListener;
		}
	}

	public static IMatcher<GameEntity> Audio
	{
		get
		{
			if (_matcherAudio == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 22 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAudio = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAudio;
		}
	}

	public static IMatcher<GameEntity> AudioVolume
	{
		get
		{
			if (_matcherAudioVolume == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 23 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAudioVolume = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAudioVolume;
		}
	}

	public static IMatcher<GameEntity> AudioVolumeListener
	{
		get
		{
			if (_matcherAudioVolumeListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 24 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherAudioVolumeListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherAudioVolumeListener;
		}
	}

	public static IMatcher<GameEntity> BattleCost
	{
		get
		{
			if (_matcherBattleCost == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 25 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBattleCost = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBattleCost;
		}
	}

	public static IMatcher<GameEntity> BattleField
	{
		get
		{
			if (_matcherBattleField == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 26 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBattleField = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBattleField;
		}
	}

	public static IMatcher<GameEntity> BattleFieldXMargin
	{
		get
		{
			if (_matcherBattleFieldXMargin == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 27 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBattleFieldXMargin = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBattleFieldXMargin;
		}
	}

	public static IMatcher<GameEntity> BattleMode
	{
		get
		{
			if (_matcherBattleMode == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 28 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBattleMode = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBattleMode;
		}
	}

	public static IMatcher<GameEntity> BoneName
	{
		get
		{
			if (_matcherBoneName == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 29 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBoneName = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBoneName;
		}
	}

	public static IMatcher<GameEntity> BuildingUnit
	{
		get
		{
			if (_matcherBuildingUnit == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 30 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherBuildingUnit = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherBuildingUnit;
		}
	}

	public static IMatcher<GameEntity> Camera
	{
		get
		{
			if (_matcherCamera == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 31 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCamera = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCamera;
		}
	}

	public static IMatcher<GameEntity> CameraMoveToPosition
	{
		get
		{
			if (_matcherCameraMoveToPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 32 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCameraMoveToPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCameraMoveToPosition;
		}
	}

	public static IMatcher<GameEntity> CameraMoveToPositionDuration
	{
		get
		{
			if (_matcherCameraMoveToPositionDuration == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 33 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCameraMoveToPositionDuration = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCameraMoveToPositionDuration;
		}
	}

	public static IMatcher<GameEntity> CameraMoveToPositionElapsedTime
	{
		get
		{
			if (_matcherCameraMoveToPositionElapsedTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 34 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCameraMoveToPositionElapsedTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCameraMoveToPositionElapsedTime;
		}
	}

	public static IMatcher<GameEntity> CastingAbilityCastTime
	{
		get
		{
			if (_matcherCastingAbilityCastTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 35 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCastingAbilityCastTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCastingAbilityCastTime;
		}
	}

	public static IMatcher<GameEntity> CastingAbility
	{
		get
		{
			if (_matcherCastingAbility == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 36 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCastingAbility = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCastingAbility;
		}
	}

	public static IMatcher<GameEntity> CastingAbilityElapsedTime
	{
		get
		{
			if (_matcherCastingAbilityElapsedTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 37 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCastingAbilityElapsedTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCastingAbilityElapsedTime;
		}
	}

	public static IMatcher<GameEntity> CastingAbilityElapsedTimeListener
	{
		get
		{
			if (_matcherCastingAbilityElapsedTimeListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 38 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCastingAbilityElapsedTimeListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCastingAbilityElapsedTimeListener;
		}
	}

	public static IMatcher<GameEntity> Character
	{
		get
		{
			if (_matcherCharacter == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 39 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCharacter = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCharacter;
		}
	}

	public static IMatcher<GameEntity> CollisionRadius
	{
		get
		{
			if (_matcherCollisionRadius == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 40 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCollisionRadius = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCollisionRadius;
		}
	}

	public static IMatcher<GameEntity> CollisionRadiusListener
	{
		get
		{
			if (_matcherCollisionRadiusListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 41 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCollisionRadiusListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCollisionRadiusListener;
		}
	}

	public static IMatcher<GameEntity> CreationTick
	{
		get
		{
			if (_matcherCreationTick == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 42 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherCreationTick = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherCreationTick;
		}
	}

	public static IMatcher<GameEntity> Dead
	{
		get
		{
			if (_matcherDead == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 43 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDead = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDead;
		}
	}

	public static IMatcher<GameEntity> DeadElapsedTick
	{
		get
		{
			if (_matcherDeadElapsedTick == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 44 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDeadElapsedTick = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDeadElapsedTick;
		}
	}

	public static IMatcher<GameEntity> DeadListener
	{
		get
		{
			if (_matcherDeadListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 45 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDeadListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDeadListener;
		}
	}

	public static IMatcher<GameEntity> Destroyable
	{
		get
		{
			if (_matcherDestroyable == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 46 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDestroyable = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDestroyable;
		}
	}

	public static IMatcher<GameEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 47 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDestroyed = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDestroyed;
		}
	}

	public static IMatcher<GameEntity> Dungeon
	{
		get
		{
			if (_matcherDungeon == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 48 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDungeon = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDungeon;
		}
	}

	public static IMatcher<GameEntity> Duration
	{
		get
		{
			if (_matcherDuration == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 49 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherDuration = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherDuration;
		}
	}

	public static IMatcher<GameEntity> ElapsedTime
	{
		get
		{
			if (_matcherElapsedTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 50 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherElapsedTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherElapsedTime;
		}
	}

	public static IMatcher<GameEntity> FaceDirection
	{
		get
		{
			if (_matcherFaceDirection == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 51 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFaceDirection = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFaceDirection;
		}
	}

	public static IMatcher<GameEntity> FloatingTextAlpha
	{
		get
		{
			if (_matcherFloatingTextAlpha == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 52 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFloatingTextAlpha = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFloatingTextAlpha;
		}
	}

	public static IMatcher<GameEntity> FloatingTextAlphaListener
	{
		get
		{
			if (_matcherFloatingTextAlphaListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 53 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFloatingTextAlphaListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFloatingTextAlphaListener;
		}
	}

	public static IMatcher<GameEntity> FloatingText
	{
		get
		{
			if (_matcherFloatingText == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 54 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFloatingText = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFloatingText;
		}
	}

	public static IMatcher<GameEntity> FloatingTextListener
	{
		get
		{
			if (_matcherFloatingTextListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 55 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFloatingTextListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFloatingTextListener;
		}
	}

	public static IMatcher<GameEntity> FlowLightFx
	{
		get
		{
			if (_matcherFlowLightFx == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 56 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFlowLightFx = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFlowLightFx;
		}
	}

	public static IMatcher<GameEntity> FlowLightFxListener
	{
		get
		{
			if (_matcherFlowLightFxListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 57 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFlowLightFxListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFlowLightFxListener;
		}
	}

	public static IMatcher<GameEntity> FlowLightFxRemovedListener
	{
		get
		{
			if (_matcherFlowLightFxRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 58 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFlowLightFxRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFlowLightFxRemovedListener;
		}
	}

	public static IMatcher<GameEntity> FxController
	{
		get
		{
			if (_matcherFxController == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 59 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherFxController = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherFxController;
		}
	}

	public static IMatcher<GameEntity> GameDestroyedListener
	{
		get
		{
			if (_matcherGameDestroyedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 60 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGameDestroyedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGameDestroyedListener;
		}
	}

	public static IMatcher<GameEntity> GameObject
	{
		get
		{
			if (_matcherGameObject == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 61 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGameObject = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGameObject;
		}
	}

	public static IMatcher<GameEntity> GroupSourceId
	{
		get
		{
			if (_matcherGroupSourceId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 62 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGroupSourceId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGroupSourceId;
		}
	}

	public static IMatcher<GameEntity> GroupTargetId
	{
		get
		{
			if (_matcherGroupTargetId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 63 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGroupTargetId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGroupTargetId;
		}
	}

	public static IMatcher<GameEntity> GroupUnitId
	{
		get
		{
			if (_matcherGroupUnitId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 64 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGroupUnitId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGroupUnitId;
		}
	}

	public static IMatcher<GameEntity> GroupUnits
	{
		get
		{
			if (_matcherGroupUnits == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 65 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherGroupUnits = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherGroupUnits;
		}
	}

	public static IMatcher<GameEntity> Height
	{
		get
		{
			if (_matcherHeight == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 66 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherHeight = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherHeight;
		}
	}

	public static IMatcher<GameEntity> HeightListener
	{
		get
		{
			if (_matcherHeightListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 67 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherHeightListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherHeightListener;
		}
	}

	public static IMatcher<GameEntity> Id
	{
		get
		{
			if (_matcherId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 68 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherId;
		}
	}

	public static IMatcher<GameEntity> LandingBone
	{
		get
		{
			if (_matcherLandingBone == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 69 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLandingBone = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLandingBone;
		}
	}

	public static IMatcher<GameEntity> LaunchBone
	{
		get
		{
			if (_matcherLaunchBone == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 70 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLaunchBone = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLaunchBone;
		}
	}

	public static IMatcher<GameEntity> LeftTime
	{
		get
		{
			if (_matcherLeftTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 71 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLeftTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLeftTime;
		}
	}

	public static IMatcher<GameEntity> LevelId
	{
		get
		{
			if (_matcherLevelId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 72 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLevelId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLevelId;
		}
	}

	public static IMatcher<GameEntity> LevelInst
	{
		get
		{
			if (_matcherLevelInst == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 73 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLevelInst = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLevelInst;
		}
	}

	public static IMatcher<GameEntity> Loop
	{
		get
		{
			if (_matcherLoop == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 74 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherLoop = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherLoop;
		}
	}

	public static IMatcher<GameEntity> Model
	{
		get
		{
			if (_matcherModel == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 75 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherModel = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherModel;
		}
	}

	public static IMatcher<GameEntity> ModelListener
	{
		get
		{
			if (_matcherModelListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 76 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherModelListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherModelListener;
		}
	}

	public static IMatcher<GameEntity> MoveSpeed
	{
		get
		{
			if (_matcherMoveSpeed == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 77 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherMoveSpeed = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherMoveSpeed;
		}
	}

	public static IMatcher<GameEntity> MoveSpeedListener
	{
		get
		{
			if (_matcherMoveSpeedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 78 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherMoveSpeedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherMoveSpeedListener;
		}
	}

	public static IMatcher<GameEntity> Name
	{
		get
		{
			if (_matcherName == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 79 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherName = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherName;
		}
	}

	public static IMatcher<GameEntity> OwnerId
	{
		get
		{
			if (_matcherOwnerId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 80 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherOwnerId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherOwnerId;
		}
	}

	public static IMatcher<GameEntity> ParabolaSpeed
	{
		get
		{
			if (_matcherParabolaSpeed == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 81 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParabolaSpeed = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParabolaSpeed;
		}
	}

	public static IMatcher<GameEntity> Parent
	{
		get
		{
			if (_matcherParent == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 82 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParent = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParent;
		}
	}

	public static IMatcher<GameEntity> ParentId
	{
		get
		{
			if (_matcherParentId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 83 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParentId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParentId;
		}
	}

	public static IMatcher<GameEntity> ParticleBaseScale
	{
		get
		{
			if (_matcherParticleBaseScale == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 84 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleBaseScale = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleBaseScale;
		}
	}

	public static IMatcher<GameEntity> Particle
	{
		get
		{
			if (_matcherParticle == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 85 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticle = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticle;
		}
	}

	public static IMatcher<GameEntity> ParticleFollowTarget
	{
		get
		{
			if (_matcherParticleFollowTarget == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 86 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFollowTarget = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFollowTarget;
		}
	}

	public static IMatcher<GameEntity> ParticleFollowTargetScale
	{
		get
		{
			if (_matcherParticleFollowTargetScale == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 87 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFollowTargetScale = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFollowTargetScale;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreen
	{
		get
		{
			if (_matcherParticleFullscreen == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 88 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreen = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreen;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreenEndPosition
	{
		get
		{
			if (_matcherParticleFullscreenEndPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 89 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreenEndPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreenEndPosition;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreenLayer
	{
		get
		{
			if (_matcherParticleFullscreenLayer == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 90 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreenLayer = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreenLayer;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreenMoveDuration
	{
		get
		{
			if (_matcherParticleFullscreenMoveDuration == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 91 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreenMoveDuration = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreenMoveDuration;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreenMoveElapsedTime
	{
		get
		{
			if (_matcherParticleFullscreenMoveElapsedTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 92 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreenMoveElapsedTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreenMoveElapsedTime;
		}
	}

	public static IMatcher<GameEntity> ParticleFullscreenStartPosition
	{
		get
		{
			if (_matcherParticleFullscreenStartPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 93 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleFullscreenStartPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleFullscreenStartPosition;
		}
	}

	public static IMatcher<GameEntity> ParticleLiveWithOwner
	{
		get
		{
			if (_matcherParticleLiveWithOwner == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 94 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleLiveWithOwner = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleLiveWithOwner;
		}
	}

	public static IMatcher<GameEntity> ParticleState
	{
		get
		{
			if (_matcherParticleState == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 95 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherParticleState = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherParticleState;
		}
	}

	public static IMatcher<GameEntity> Player
	{
		get
		{
			if (_matcherPlayer == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 96 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPlayer = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPlayer;
		}
	}

	public static IMatcher<GameEntity> PortalId
	{
		get
		{
			if (_matcherPortalId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 97 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPortalId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPortalId;
		}
	}

	public static IMatcher<GameEntity> PortalUnitIndex
	{
		get
		{
			if (_matcherPortalUnitIndex == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 98 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPortalUnitIndex = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPortalUnitIndex;
		}
	}

	public static IMatcher<GameEntity> Position
	{
		get
		{
			if (_matcherPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 99 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPosition;
		}
	}

	public static IMatcher<GameEntity> PositionListener
	{
		get
		{
			if (_matcherPositionListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 100 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPositionListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPositionListener;
		}
	}

	public static IMatcher<GameEntity> Priority
	{
		get
		{
			if (_matcherPriority == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 101 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherPriority = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherPriority;
		}
	}

	public static IMatcher<GameEntity> Projectile
	{
		get
		{
			if (_matcherProjectile == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 102 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherProjectile = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherProjectile;
		}
	}

	public static IMatcher<GameEntity> ProjectileFlying
	{
		get
		{
			if (_matcherProjectileFlying == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 103 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherProjectileFlying = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherProjectileFlying;
		}
	}

	public static IMatcher<GameEntity> ProjectileIdentifier
	{
		get
		{
			if (_matcherProjectileIdentifier == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 104 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherProjectileIdentifier = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherProjectileIdentifier;
		}
	}

	public static IMatcher<GameEntity> ProjectileMoveType
	{
		get
		{
			if (_matcherProjectileMoveType == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 105 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherProjectileMoveType = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherProjectileMoveType;
		}
	}

	public static IMatcher<GameEntity> ProjectileRatio
	{
		get
		{
			if (_matcherProjectileRatio == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 106 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherProjectileRatio = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherProjectileRatio;
		}
	}

	public static IMatcher<GameEntity> Rotation
	{
		get
		{
			if (_matcherRotation == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 107 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherRotation = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherRotation;
		}
	}

	public static IMatcher<GameEntity> RotationListener
	{
		get
		{
			if (_matcherRotationListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 108 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherRotationListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherRotationListener;
		}
	}

	public static IMatcher<GameEntity> Scale
	{
		get
		{
			if (_matcherScale == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 109 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherScale = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherScale;
		}
	}

	public static IMatcher<GameEntity> ScaleListener
	{
		get
		{
			if (_matcherScaleListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 110 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherScaleListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherScaleListener;
		}
	}

	public static IMatcher<GameEntity> SceneArguments
	{
		get
		{
			if (_matcherSceneArguments == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 111 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSceneArguments = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSceneArguments;
		}
	}

	public static IMatcher<GameEntity> SceneLoaded
	{
		get
		{
			if (_matcherSceneLoaded == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 112 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSceneLoaded = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSceneLoaded;
		}
	}

	public static IMatcher<GameEntity> SceneName
	{
		get
		{
			if (_matcherSceneName == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 113 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSceneName = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSceneName;
		}
	}

	public static IMatcher<GameEntity> Shadow
	{
		get
		{
			if (_matcherShadow == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 114 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShadow = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShadow;
		}
	}

	public static IMatcher<GameEntity> ShadowScale
	{
		get
		{
			if (_matcherShadowScale == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 115 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShadowScale = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShadowScale;
		}
	}

	public static IMatcher<GameEntity> ShadowScaleListener
	{
		get
		{
			if (_matcherShadowScaleListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 116 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShadowScaleListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShadowScaleListener;
		}
	}

	public static IMatcher<GameEntity> ShowCastingBar
	{
		get
		{
			if (_matcherShowCastingBar == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 117 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowCastingBar = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowCastingBar;
		}
	}

	public static IMatcher<GameEntity> ShowCastingBarListener
	{
		get
		{
			if (_matcherShowCastingBarListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 118 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowCastingBarListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowCastingBarListener;
		}
	}

	public static IMatcher<GameEntity> ShowCastingBarRemovedListener
	{
		get
		{
			if (_matcherShowCastingBarRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 119 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowCastingBarRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowCastingBarRemovedListener;
		}
	}

	public static IMatcher<GameEntity> ShowGizmos
	{
		get
		{
			if (_matcherShowGizmos == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 120 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowGizmos = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowGizmos;
		}
	}

	public static IMatcher<GameEntity> ShowGizmosListener
	{
		get
		{
			if (_matcherShowGizmosListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 121 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowGizmosListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowGizmosListener;
		}
	}

	public static IMatcher<GameEntity> ShowHealthBar
	{
		get
		{
			if (_matcherShowHealthBar == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 122 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowHealthBar = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowHealthBar;
		}
	}

	public static IMatcher<GameEntity> ShowHealthBarListener
	{
		get
		{
			if (_matcherShowHealthBarListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 123 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowHealthBarListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowHealthBarListener;
		}
	}

	public static IMatcher<GameEntity> ShowHealthBarRemovedListener
	{
		get
		{
			if (_matcherShowHealthBarRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 124 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherShowHealthBarRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherShowHealthBarRemovedListener;
		}
	}

	public static IMatcher<GameEntity> Size
	{
		get
		{
			if (_matcherSize == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 125 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSize = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSize;
		}
	}

	public static IMatcher<GameEntity> Skeleton
	{
		get
		{
			if (_matcherSkeleton == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 126 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSkeleton = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSkeleton;
		}
	}

	public static IMatcher<GameEntity> SkeletonListener
	{
		get
		{
			if (_matcherSkeletonListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 127 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSkeletonListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSkeletonListener;
		}
	}

	public static IMatcher<GameEntity> Skin
	{
		get
		{
			if (_matcherSkin == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 128 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSkin = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSkin;
		}
	}

	public static IMatcher<GameEntity> SkinListener
	{
		get
		{
			if (_matcherSkinListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 129 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSkinListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSkinListener;
		}
	}

	public static IMatcher<GameEntity> SourceId
	{
		get
		{
			if (_matcherSourceId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 130 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSourceId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSourceId;
		}
	}

	public static IMatcher<GameEntity> SpecialFx
	{
		get
		{
			if (_matcherSpecialFx == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 131 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSpecialFx = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSpecialFx;
		}
	}

	public static IMatcher<GameEntity> SpecialFxListener
	{
		get
		{
			if (_matcherSpecialFxListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 132 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSpecialFxListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSpecialFxListener;
		}
	}

	public static IMatcher<GameEntity> SpecialFxRemovedListener
	{
		get
		{
			if (_matcherSpecialFxRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 133 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherSpecialFxRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherSpecialFxRemovedListener;
		}
	}

	public static IMatcher<GameEntity> StartPosition
	{
		get
		{
			if (_matcherStartPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 134 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherStartPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherStartPosition;
		}
	}

	public static IMatcher<GameEntity> Tags
	{
		get
		{
			if (_matcherTags == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 135 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTags = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTags;
		}
	}

	public static IMatcher<GameEntity> TargetId
	{
		get
		{
			if (_matcherTargetId == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 136 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTargetId = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTargetId;
		}
	}

	public static IMatcher<GameEntity> TargetPosition
	{
		get
		{
			if (_matcherTargetPosition == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 137 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTargetPosition = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTargetPosition;
		}
	}

	public static IMatcher<GameEntity> TargetPositionListener
	{
		get
		{
			if (_matcherTargetPositionListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 138 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTargetPositionListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTargetPositionListener;
		}
	}

	public static IMatcher<GameEntity> Team
	{
		get
		{
			if (_matcherTeam == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 139 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTeam = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTeam;
		}
	}

	public static IMatcher<GameEntity> TickElapsedTime
	{
		get
		{
			if (_matcherTickElapsedTime == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 140 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTickElapsedTime = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTickElapsedTime;
		}
	}

	public static IMatcher<GameEntity> TickInterval
	{
		get
		{
			if (_matcherTickInterval == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 141 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherTickInterval = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherTickInterval;
		}
	}

	public static IMatcher<GameEntity> UnitBaseImage
	{
		get
		{
			if (_matcherUnitBaseImage == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 142 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitBaseImage = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitBaseImage;
		}
	}

	public static IMatcher<GameEntity> UnitBaseImageListener
	{
		get
		{
			if (_matcherUnitBaseImageListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 143 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitBaseImageListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitBaseImageListener;
		}
	}

	public static IMatcher<GameEntity> UnitBaseImageRemovedListener
	{
		get
		{
			if (_matcherUnitBaseImageRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 144 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitBaseImageRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitBaseImageRemovedListener;
		}
	}

	public static IMatcher<GameEntity> Unit
	{
		get
		{
			if (_matcherUnit == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 145 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnit = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnit;
		}
	}

	public static IMatcher<GameEntity> UnitIdentifier
	{
		get
		{
			if (_matcherUnitIdentifier == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 146 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitIdentifier = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitIdentifier;
		}
	}

	public static IMatcher<GameEntity> UnitImageIndicator
	{
		get
		{
			if (_matcherUnitImageIndicator == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 147 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitImageIndicator = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitImageIndicator;
		}
	}

	public static IMatcher<GameEntity> UnitImageIndicatorListener
	{
		get
		{
			if (_matcherUnitImageIndicatorListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 148 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitImageIndicatorListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitImageIndicatorListener;
		}
	}

	public static IMatcher<GameEntity> UnitImageIndicatorRemovedListener
	{
		get
		{
			if (_matcherUnitImageIndicatorRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 149 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitImageIndicatorRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitImageIndicatorRemovedListener;
		}
	}

	public static IMatcher<GameEntity> UnitIndicator
	{
		get
		{
			if (_matcherUnitIndicator == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 150 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitIndicator = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitIndicator;
		}
	}

	public static IMatcher<GameEntity> UnitIndicatorListener
	{
		get
		{
			if (_matcherUnitIndicatorListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 151 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitIndicatorListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitIndicatorListener;
		}
	}

	public static IMatcher<GameEntity> UnitIndicatorRemovedListener
	{
		get
		{
			if (_matcherUnitIndicatorRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 152 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitIndicatorRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitIndicatorRemovedListener;
		}
	}

	public static IMatcher<GameEntity> UnitScale
	{
		get
		{
			if (_matcherUnitScale == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 153 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitScale = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitScale;
		}
	}

	public static IMatcher<GameEntity> UnitScaleListener
	{
		get
		{
			if (_matcherUnitScaleListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 154 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitScaleListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitScaleListener;
		}
	}

	public static IMatcher<GameEntity> UnitStats
	{
		get
		{
			if (_matcherUnitStats == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 155 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitStats = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitStats;
		}
	}

	public static IMatcher<GameEntity> UnitStatsListener
	{
		get
		{
			if (_matcherUnitStatsListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 156 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherUnitStatsListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherUnitStatsListener;
		}
	}

	public static IMatcher<GameEntity> View
	{
		get
		{
			if (_matcherView == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 157 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherView = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherView;
		}
	}

	public static IMatcher<GameEntity> Visible
	{
		get
		{
			if (_matcherVisible == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 158 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherVisible = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherVisible;
		}
	}

	public static IMatcher<GameEntity> VisibleListener
	{
		get
		{
			if (_matcherVisibleListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 159 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherVisibleListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherVisibleListener;
		}
	}

	public static IMatcher<GameEntity> VisibleRemovedListener
	{
		get
		{
			if (_matcherVisibleRemovedListener == null)
			{
				Matcher<GameEntity> val = (Matcher<GameEntity>)(object)Matcher<GameEntity>.AllOf(new int[1] { 160 });
				val.componentNames = GameComponentsLookup.componentNames;
				_matcherVisibleRemovedListener = (IMatcher<GameEntity>)(object)val;
			}
			return _matcherVisibleRemovedListener;
		}
	}

	public static IAllOfMatcher<GameEntity> AllOf(params int[] indices)
	{
		return Matcher<GameEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<GameEntity> AllOf(params IMatcher<GameEntity>[] matchers)
	{
		return Matcher<GameEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<GameEntity> AnyOf(params int[] indices)
	{
		return Matcher<GameEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<GameEntity> AnyOf(params IMatcher<GameEntity>[] matchers)
	{
		return Matcher<GameEntity>.AnyOf(matchers);
	}
}
