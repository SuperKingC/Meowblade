using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using Entitas;
using GameDataEditor;
using GameMaths;
using HotFix;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Spine;
using Spine.Unity;
using UnityEngine;

public class UnitySkeletonAnimator : MonoBehaviour, IPooled, IAnimator, IAnimationListener, IAnimationDurationListener, IEventListener, IModelListener, ISkinListener, IAlphaListener, IAnimationInitializedListener, IFxController, ISpecialFxListener, ISpecialFxRemovedListener, IFlowLightFxListener, IFlowLightFxRemovedListener, IAnyReplayStateListener
{
	private bool _isDisposed = false;

	private GameEntity _entity;

	private GameStateEntity _stateEntity;

	private float _oldTimeScale;

	private Transform _shadow_boss;

	private Transform _shadow_normal;

	[SerializeField]
	private Transform _animationParentTransform;

	private SkeletonAnimation _animation;

	private string _model;

	private TrackEntry _trackEntry;

	private bool _isPaused;

	private int _runAnimationDelay;

	private bool _initializing;

	private string _currentModel;

	private string _currentSkin;

	private bool _refreshModel;

	private bool _refreshSkin;

	private bool _refreshAnimation;

	private bool _refreshAnimationDuration;

	private bool _refreshAlpha;

	private string quality_string;

	public Texture StoneFxTexture;

	public Texture FreezeFxTexture;

	public Texture FlowLightWhiteFxTexture;

	public Texture FlowLightRedFxTexture;

	public Texture FlowLightGoldFxTexture;

	public MeshRenderer MeshRenderer;

	private MaterialPropertyBlock _mpb;

	private Material _baseMaterial;

	private Material _fxMaterial;

	private static readonly int IsOpenFlowLight = Shader.PropertyToID("_IsOpenFlowLight");

	private static readonly int FlowLightPower = Shader.PropertyToID("_FlowLightPower");

	private static readonly int FlowLightSpeed = Shader.PropertyToID("_FlowLightSpeed");

	private static readonly int FlowLightTex = Shader.PropertyToID("_FlowLightTex");

	private static readonly int MainTex = Shader.PropertyToID("_MainTex");

	private static readonly int IsOpenOverlay = Shader.PropertyToID("_IsOpenOverlay");

	private static readonly int IsOverlayAddMode = Shader.PropertyToID("_IsOverlayAddMode");

	private static readonly int OverlayPower = Shader.PropertyToID("_OverlayPower");

	private static readonly int IsOpenGrayScale = Shader.PropertyToID("_IsOpenGrayScale");

	private static readonly int OverlayTex = Shader.PropertyToID("_OverlayTex");

	private int _lastReplayState;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Init()
	{
		_isDisposed = false;
		_animationParentTransform = ((Component)this).transform.Find("Model");
		StoneFxTexture = Resources.Load<Texture>("Texture/stone_fx_texture");
		FreezeFxTexture = Resources.Load<Texture>("Texture/freeze_fx_texture");
		FlowLightWhiteFxTexture = Resources.Load<Texture>("Texture/shine_fx_texture_v");
		FlowLightRedFxTexture = Resources.Load<Texture>("Texture/shine_fx_texture_v_red");
		FlowLightGoldFxTexture = Resources.Load<Texture>("Texture/shine_fx_texture_v_gold");
		MeshRenderer = null;
		_shadow_boss = ((Component)this).transform.Find("shadow_boss");
		_shadow_normal = ((Component)this).transform.Find("shadow_normal");
	}

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		_entity = entity;
		quality_string = HotFix_Utils.GetBattleModelQualityStringSetting();
		if ((_entity.hasUnitScale && _entity.unitScale.value >= 1.5f) || (_entity.hasTags && _entity.tags.value.Contains("障碍物")))
		{
			quality_string = "";
		}
		_stateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		if (_entity.hasModel)
		{
			_refreshSkin = true;
			_refreshAnimation = true;
			_refreshAnimationDuration = true;
			_refreshAlpha = true;
			OnModel(_entity, _entity.model.value);
		}
	}

	public void PlayAnimationOnTrack(AnimationName animation, int trackIndex = 1, bool loop = false)
	{
		string text = AnimationManager.StateToString(animation);
		if (!((Object)(object)_animation == (Object)null) && ((SkeletonRenderer)_animation).Skeleton != null && ((SkeletonRenderer)_animation).Skeleton.Data != null)
		{
			Animation val = ((SkeletonRenderer)_animation).Skeleton.Data.FindAnimation(text);
			if (val != null && !_entity.hasSpecialFx)
			{
				PlayByTime(text, trackIndex, loop);
			}
		}
	}

	public void ClearTrack(int trackIndex = 1)
	{
		if (_entity.isAnimationInitialized)
		{
			_animation.state.SetEmptyAnimation(trackIndex, 0f);
			_animation.state.ClearTrack(trackIndex);
		}
	}

	public void ResumeAnimation()
	{
		_isPaused = false;
		SetAnimationDuration(_entity.animationDuration.value);
	}

	public void PauseAnimation()
	{
		_isPaused = true;
		if (_entity.isAnimationInitialized)
		{
			_animation.state.TimeScale = 0f;
		}
	}

	private async void LoadAnimation(string model)
	{
		if ((Object)(object)_animation != (Object)null && _currentModel != model)
		{
			SpawnManager.Instance.UnloadUnitModel(((Component)_animation).gameObject, _model, quality_string);
			_animation = null;
			_model = null;
		}
		_initializing = true;
		_currentModel = model;
		int entityId = _entity.id.value;
		if ((Object)(object)_animation == (Object)null)
		{
			GameObject unitModel = await SpawnManager.Instance.LoadUnitModel(model, quality_string);
			unitModel.transform.SetParent(_animationParentTransform, false);
			unitModel.transform.localPosition = Vector3.zero;
			unitModel.transform.localScale = Vector3.one;
			_model = model;
			_animation = unitModel.GetComponent<SkeletonAnimation>();
			_animation.timeScale = 1f;
			if (_animation.AnimationState != null)
			{
				_initializing = false;
				_entity.isAnimationInitialized = true;
				RefreshAfterInitialization();
				return;
			}
		}
		if ((Object)(object)((SkeletonRenderer)_animation).skeletonDataAsset != (Object)null)
		{
			((SkeletonRenderer)_animation).skeletonDataAsset.Clear();
		}
		string spineName = model;
		if (_entity.hasSkin && _entity.skin.value != "" && _entity.skin.value != "default")
		{
			spineName = spineName + "_" + _entity.skin.value;
		}
		SpawnManager.Instance.LoadSoldierSpine(((Component)_animation).gameObject, spineName).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			_initializing = false;
			if (_entity != null && entityId == _entity.id.value)
			{
				if (_refreshModel)
				{
					_refreshModel = false;
					LoadAnimation(_entity.model.value);
				}
				else
				{
					((SkeletonRenderer)_animation).skeletonDataAsset = asset;
					if ((Object)(object)((SkeletonRenderer)_animation).skeletonDataAsset != (Object)null)
					{
						AtlasAsset[] atlasAssets = ((SkeletonRenderer)_animation).skeletonDataAsset.atlasAssets;
						foreach (AtlasAsset val in atlasAssets)
						{
							if ((Object)(object)val != (Object)null)
							{
								val.Clear();
							}
						}
					}
					if (_entity.hasSkin)
					{
						((SkeletonRenderer)_animation).initialSkinName = _entity.skin.value;
					}
					else
					{
						AnimationStateData animationStateData = ((SkeletonRenderer)_animation).SkeletonDataAsset.GetAnimationStateData();
						if (animationStateData.SkeletonData.Skins.Count > 0)
						{
							((SkeletonRenderer)_animation).initialSkinName = animationStateData.SkeletonData.Skins.Items[0].Name;
						}
					}
					((SkeletonRenderer)_animation).Initialize(true);
					_entity.isAnimationInitialized = true;
					RefreshAfterInitialization();
				}
			}
		}, (Action<Exception>)delegate
		{
			_initializing = false;
			if (_refreshModel)
			{
				_refreshModel = false;
				LoadAnimation(_entity.model.value);
			}
		});
	}

	public void OnModel(GameEntity entity, string value)
	{
		if (!(_currentModel == value))
		{
			if (_initializing)
			{
				_refreshModel = true;
			}
			else
			{
				LoadAnimation(value);
			}
		}
	}

	public void OnSkin(GameEntity entity, string value)
	{
		if (value == _currentSkin)
		{
			return;
		}
		if (!_entity.isAnimationInitialized)
		{
			_refreshSkin = true;
			return;
		}
		_currentSkin = value;
		SpineHelper.SetSkin((ISkeletonAnimation)(object)_animation, value);
		if (entity.hasAnimation)
		{
			OnAnimation(entity, entity.animation.value);
		}
	}

	public void OnAnimation(GameEntity entity, AnimationName value)
	{
		if (!_entity.isAnimationInitialized)
		{
			_refreshAnimation = true;
			return;
		}
		string text = AnimationManager.StateToString(value);
		if (entity.model.value == "S043" || entity.model.value == "S044")
		{
			text = "idle_ui";
		}
		Animation val = ((SkeletonRenderer)_animation).Skeleton.Data.FindAnimation(text);
		if (val != null && !_entity.hasSpecialFx)
		{
			_trackEntry = PlayByTime(text, 0, IsCurrentAnimationLoop());
		}
	}

	public void OnAnimationDuration(GameEntity entity, float value)
	{
		if (!_entity.isAnimationInitialized)
		{
			_refreshAnimationDuration = true;
		}
		else
		{
			SetAnimationDuration(value);
		}
	}

	public void SetAnimationDuration(float duration)
	{
		if (_trackEntry != null && !_entity.hasSpecialFx && !(duration < float.Epsilon))
		{
			_animation.state.TimeScale = _trackEntry.AnimationEnd / duration;
		}
	}

	public void Stop()
	{
		if ((Object)(object)_animation != (Object)null)
		{
			AnimationState state = _animation.state;
			if (state != null)
			{
				state.ClearTracks();
			}
		}
		_trackEntry = null;
	}

	public TrackEntry PlayByTime(string animationName, int trackIndex = 0, bool loop = false, float fromTime = -1f, float toTime = -1f)
	{
		if (animationName == "run" && _runAnimationDelay >= 0 && fromTime == -1f)
		{
			fromTime = (float)_runAnimationDelay / 1000f;
		}
		ResumeAnimation();
		_animation.state.ClearTrack(trackIndex);
		TrackEntry val = _animation.state.SetAnimation(trackIndex, animationName, loop);
		if (trackIndex == 0)
		{
			((SkeletonRenderer)_animation).Skeleton.SetToSetupPose();
			_trackEntry = val;
			if (fromTime >= 0f)
			{
				_trackEntry.TrackTime = fromTime;
			}
			if (toTime >= 0f)
			{
				_trackEntry.TrackEnd = toTime;
			}
			SetAnimationDuration(_entity.animationDuration.value);
		}
		return val;
	}

	private bool IsCurrentAnimationLoop()
	{
		Dictionary<AnimationName, GDEAnimationData> animationsForModel = Singleton<AnimationManager>.Instance.GetAnimationsForModel(_entity.model.value);
		if (animationsForModel == null)
		{
			return true;
		}
		if (animationsForModel.ContainsKey(_entity.animation.value))
		{
			return animationsForModel[_entity.animation.value].Loop;
		}
		return true;
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_mpb = new MaterialPropertyBlock();
		_lastReplayState = 1;
	}

	public void OnUnSpawn()
	{
		_isDisposed = true;
		if ((Object)(object)MeshRenderer != (Object)null)
		{
			((Renderer)MeshRenderer).SetPropertyBlock((MaterialPropertyBlock)null);
		}
		MeshRenderer = null;
		_mpb = null;
		_baseMaterial = null;
		_currentModel = string.Empty;
		_currentSkin = string.Empty;
		if (!string.IsNullOrEmpty(_model))
		{
			Stop();
			SpawnManager.Instance.UnloadUnitModel(((Component)_animation).gameObject, _model, quality_string);
			_animation = null;
			_model = null;
		}
		if (_entity != null)
		{
			if (_entity.isAnimationInitialized)
			{
				_entity.isAnimationInitialized = false;
			}
			_isPaused = false;
			UnregisterListeners();
			if (_stateEntity != null)
			{
				((Entity)_stateEntity).Destroy();
				_stateEntity = null;
			}
			_entity = null;
		}
	}

	public void RegisterListeners()
	{
		_entity.AddModelListener(this);
		_entity.AddSkinListener(this);
		_entity.AddAnimationListener(this);
		_entity.AddAnimationDurationListener(this);
		_entity.AddAlphaListener(this);
		_entity.AddSpecialFxListener(this);
		_entity.AddSpecialFxRemovedListener(this);
		_entity.AddFlowLightFxListener(this);
		_entity.AddFlowLightFxRemovedListener(this);
		_stateEntity.AddAnyReplayStateListener(this);
	}

	public void UnregisterListeners()
	{
		_entity.RemoveModelListener(this);
		_entity.RemoveSkinListener(this);
		_entity.RemoveAnimationListener(this);
		_entity.RemoveAnimationDurationListener(this);
		_entity.RemoveAlphaListener(this);
		_entity.RemoveSpecialFxListener(this);
		_entity.RemoveSpecialFxRemovedListener(this);
		_entity.RemoveFlowLightFxListener(this);
		_entity.RemoveFlowLightFxRemovedListener(this);
		_stateEntity.RemoveAnyReplayStateListener(this);
	}

	public void OnAnimationInitialized(GameEntity entity)
	{
	}

	private void RefreshAfterInitialization()
	{
		if (_refreshModel)
		{
			OnModel(_entity, _entity.model.value);
			return;
		}
		_runAnimationDelay = Mathf.RoundToInt((float)Random.Range(0, 200));
		if (_refreshAlpha && _entity.hasAlpha)
		{
			OnAlpha(_entity, _entity.alpha.value, _entity.alpha.duration);
			_refreshAlpha = false;
		}
		if (_refreshSkin && _entity.hasSkin)
		{
			OnSkin(_entity, _entity.skin.value);
			_refreshSkin = false;
			_refreshAnimation = false;
		}
		else if (_refreshAnimation && _entity.hasAnimation)
		{
			OnAnimation(_entity, _entity.animation.value);
			_refreshAnimation = false;
		}
		if (_refreshAnimationDuration && _entity.hasAnimationDuration)
		{
			OnAnimationDuration(_entity, _entity.animationDuration.value);
			_refreshAnimationDuration = false;
		}
		if (_isPaused)
		{
			PauseAnimation();
		}
		OnAnimationInitialized();
	}

	public void OnAlpha(GameEntity entity, float value, float duration)
	{
		if (!_entity.isAnimationInitialized)
		{
			_refreshAlpha = true;
		}
		else if (duration > 0f)
		{
			DOTween.To((DOGetter<float>)(() => ((Object)(object)_animation != (Object)null && ((SkeletonRenderer)_animation).Skeleton != null) ? ((SkeletonRenderer)_animation).Skeleton.A : value), (DOSetter<float>)delegate(float x)
			{
				if ((Object)(object)_animation != (Object)null && ((SkeletonRenderer)_animation).Skeleton != null)
				{
					((SkeletonRenderer)_animation).Skeleton.A = x;
				}
			}, value, duration);
		}
		else if ((Object)(object)_animation != (Object)null && ((SkeletonRenderer)_animation).Skeleton != null)
		{
			((SkeletonRenderer)_animation).Skeleton.A = value;
		}
	}

	public void OnSpecialFx(GameEntity entity, int value)
	{
		switch (value)
		{
		case 0:
			return;
		case 1:
			_mpb.SetTexture(OverlayTex, StoneFxTexture);
			_mpb.SetFloat(IsOpenOverlay, 1f);
			_mpb.SetFloat(IsOpenGrayScale, 1f);
			_mpb.SetFloat(IsOverlayAddMode, 0f);
			_mpb.SetFloat(OverlayPower, 0f);
			break;
		case 2:
			_mpb.SetTexture(OverlayTex, FreezeFxTexture);
			_mpb.SetFloat(IsOpenOverlay, 1f);
			_mpb.SetFloat(IsOpenGrayScale, 0f);
			_mpb.SetFloat(IsOverlayAddMode, 1f);
			_mpb.SetFloat(OverlayPower, 1f);
			break;
		}
		((Renderer)MeshRenderer).SetPropertyBlock(_mpb);
	}

	public void OnSpecialFxRemoved(GameEntity entity)
	{
		_mpb.SetFloat(IsOpenOverlay, 0f);
		_mpb.SetFloat(IsOpenGrayScale, 0f);
		((Renderer)MeshRenderer).SetPropertyBlock(_mpb);
	}

	public void OnFlowLightFx(GameEntity entity, int id, float power, float speed)
	{
		_mpb.SetFloat(IsOpenFlowLight, 1f);
		_mpb.SetFloat(FlowLightPower, power);
		_mpb.SetFloat(FlowLightSpeed, speed);
		switch (id)
		{
		case 1:
			_mpb.SetTexture(FlowLightTex, FlowLightWhiteFxTexture);
			break;
		case 2:
			_mpb.SetTexture(FlowLightTex, FlowLightRedFxTexture);
			break;
		case 3:
			_mpb.SetTexture(FlowLightTex, FlowLightGoldFxTexture);
			break;
		}
		((Renderer)MeshRenderer).SetPropertyBlock(_mpb);
	}

	public void OnFlowLightFxRemoved(GameEntity entity)
	{
		_mpb.SetFloat(IsOpenFlowLight, 0f);
		((Renderer)MeshRenderer).SetPropertyBlock(_mpb);
	}

	public void OnAnimationInitialized()
	{
		if (!_isDisposed)
		{
			MeshRenderer = ((Component)_animation).gameObject.GetComponent<MeshRenderer>();
			_baseMaterial = ((Renderer)MeshRenderer).sharedMaterial;
			if (_baseMaterial.mainTexture != null)
			{
				_mpb.SetTexture(MainTex, _baseMaterial.mainTexture);
			}
			_mpb.SetTexture(OverlayTex, StoneFxTexture);
			_mpb.SetFloat(IsOpenOverlay, 0f);
			_mpb.SetFloat(IsOpenGrayScale, 0f);
			_mpb.SetFloat(IsOpenFlowLight, 0f);
			((Renderer)MeshRenderer).SetPropertyBlock(_mpb);
			if (_entity.hasSpecialFx)
			{
				OnSpecialFx(_entity, _entity.specialFx.value);
			}
			if (_entity.hasFlowLightFx)
			{
				OnFlowLightFx(_entity, _entity.flowLightFx.id, _entity.flowLightFx.power, _entity.flowLightFx.speed);
			}
			RefreshShadow(_entity);
		}
	}

	private void RefreshShadow(GameEntity entity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		Vector3 zero = Vector3.zero;
		zero = ((!entity.hasSkeleton) ? Vector3.op_Implicit(entity.position.value) : Vector3.op_Implicit(entity.skeleton.value.GetBonePosition("floor")));
		if (entity.tags.value.Contains("IS_BOSS"))
		{
			((Component)_shadow_boss).gameObject.SetActive(true);
			((Component)_shadow_normal).gameObject.SetActive(false);
			if (entity.team.value == Team.Red)
			{
				((Component)_shadow_boss).gameObject.SetActive(false);
			}
			_shadow_boss.position = zero;
			ParticleSystemRenderer componentInChildren = ((Component)_shadow_boss).GetComponentInChildren<ParticleSystemRenderer>();
			if ((Object)(object)componentInChildren != (Object)null)
			{
				((Renderer)componentInChildren).material.renderQueue = 3000;
			}
		}
		else
		{
			((Component)_shadow_boss).gameObject.SetActive(false);
			((Component)_shadow_normal).gameObject.SetActive(true);
			_shadow_normal.position = zero;
			ParticleSystemRenderer componentInChildren2 = ((Component)_shadow_normal).GetComponentInChildren<ParticleSystemRenderer>();
			if ((Object)(object)componentInChildren2 != (Object)null)
			{
				((Renderer)componentInChildren2).material.renderQueue = 2999;
			}
		}
	}

	public void OnAnyReplayState(GameStateEntity entity, int value)
	{
		if ((Object)(object)_animation == (Object)null)
		{
			_lastReplayState = value;
			return;
		}
		if (value != 1)
		{
			_oldTimeScale = _animation.timeScale;
			_animation.timeScale = 0f;
		}
		else if (_lastReplayState != 1)
		{
			_animation.timeScale = _oldTimeScale;
		}
		_lastReplayState = value;
	}
}
