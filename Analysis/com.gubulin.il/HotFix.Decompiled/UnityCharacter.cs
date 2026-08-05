using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameMaths;
using HotFix;
using ObjectPool;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

public class UnityCharacter : MonoBehaviour, IPooled, ICharacter, IView, IEventListener, IPositionListener, IRotationListener, IScaleListener, IAssetRemovedListener, IGameDestroyedListener, IShowGizmosListener, IUnitStatsListener, IShowHealthBarListener, IShowHealthBarRemovedListener, IShowCastingBarListener, IShowCastingBarRemovedListener, ICastingAbilityElapsedTimeListener, ISkeletonListener, IVisibleListener, IVisibleRemovedListener, IAnimationInitializedListener, ICollisionRadiusListener, IUnitScaleListener
{
	[SerializeField]
	private GameObject _shadow_normal;

	[SerializeField]
	private GameObject _shadow_boss;

	[SerializeField]
	private GameObject _model;

	[SerializeField]
	private GameObject _baseImage;

	private SpriteRenderer _baseImageRenderer;

	[SerializeField]
	private GameObject _healthBar;

	[SerializeField]
	private GameObject _healthBarImage;

	[SerializeField]
	private GameObject _healthBarBaseShieldImage;

	[SerializeField]
	private SpriteRenderer _healthBarBaseShieldImageRenderer;

	[SerializeField]
	private GameObject _healthBarSpecialShieldImage;

	[SerializeField]
	private SpriteRenderer _healthBarSpecialShieldImageRenderer;

	[SerializeField]
	private GameObject _healthBarReduceImage;

	[SerializeField]
	private GameObject _castBar;

	[SerializeField]
	private GameObject _castBarImage;

	[SerializeField]
	private GameObject _indicatorNormal;

	[SerializeField]
	private GameObject _indicatorSprite;

	private SpriteRenderer _indicatorSpriteRenderer;

	private string _indicatorImageName;

	private string _baseImageName;

	private Tweener _tweener;

	private HealthBarData _healthBarData;

	private GameEntity _entity;

	[SerializeField]
	private int _id;

	private UnityViewBehaviour _uvb;

	public Vector3 Position;

	public Quaternion Rotation;

	public float Scale;

	private float _currentHeight;

	public bool ShowGizmos { get; set; }

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	private void Awake()
	{
		_shadow_normal = ((Component)((Component)this).transform.Find("shadow_normal")).gameObject;
		_shadow_boss = ((Component)((Component)this).transform.Find("shadow_boss")).gameObject;
		_model = ((Component)((Component)this).transform.Find("Model")).gameObject;
		_baseImage = ((Component)((Component)this).transform.Find("Model/Base")).gameObject;
		_healthBar = ((Component)((Component)this).transform.Find("Model/HealthBar")).gameObject;
		_healthBarImage = ((Component)((Component)this).transform.Find("Model/HealthBar/HealthPoints")).gameObject;
		_healthBarBaseShieldImage = ((Component)((Component)this).transform.Find("Model/HealthBar/BaseShieldPoints")).gameObject;
		_healthBarBaseShieldImageRenderer = _healthBarBaseShieldImage.GetComponent<SpriteRenderer>();
		_healthBarSpecialShieldImage = ((Component)((Component)this).transform.Find("Model/HealthBar/SpecialShieldPoints")).gameObject;
		_healthBarSpecialShieldImageRenderer = _healthBarSpecialShieldImage.GetComponent<SpriteRenderer>();
		_healthBarReduceImage = ((Component)((Component)this).transform.Find("Model/HealthBar/Reduce")).gameObject;
		_castBar = ((Component)((Component)this).transform.Find("Model/CastBar")).gameObject;
		_castBarImage = ((Component)((Component)this).transform.Find("Model/CastBar/Current")).gameObject;
		_indicatorNormal = ((Component)((Component)this).transform.Find("Model/_Indicator_Normal")).gameObject;
		_indicatorSprite = ((Component)((Component)this).transform.Find("Model/_Indicator_Sprite")).gameObject;
		_indicatorSpriteRenderer = _indicatorSprite.GetComponent<SpriteRenderer>();
		_baseImageRenderer = _baseImage.GetComponent<SpriteRenderer>();
		if ((Object)(object)_uvb == (Object)null)
		{
			_uvb = ((Component)this).gameObject.AddComponent<UnityViewBehaviour>();
		}
	}

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		_entity = entity;
		_id = _entity.id.value;
		if (entity.isVisible)
		{
			OnVisible(entity);
		}
		if ((Object)(object)_healthBar != (Object)null)
		{
			if (entity.isShowHealthBar)
			{
				OnShowHealthBar(entity);
			}
			else
			{
				OnShowHealthBarRemoved(entity);
			}
		}
		if ((Object)(object)_castBar != (Object)null)
		{
			if (entity.isShowCastingBar)
			{
				OnShowHealthBar(entity);
			}
			else
			{
				OnShowHealthBarRemoved(entity);
			}
		}
		if ((Object)(object)_model != (Object)null && entity.hasUnitScale)
		{
			OnUnitScale(entity, entity.unitScale.value);
		}
		if (entity.hasCollisionRadius)
		{
			OnCollisionRadius(entity, entity.collisionRadius.value);
		}
		if (entity.hasUnitImageIndicator && !string.IsNullOrEmpty(entity.unitImageIndicator.value))
		{
			string text = (_indicatorImageName = entity.unitImageIndicator.value);
			int entityId = entity.id.value;
			AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
			{
				//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_018a: Unknown result type (might be due to invalid IL or missing references)
				if (entityId == _entity.id.value && _indicatorSprite.activeInHierarchy)
				{
					_indicatorSpriteRenderer.sprite = asset;
					Color32 val = default(Color32);
					((Color32)(ref val))._002Ector((byte)243, (byte)101, (byte)51, byte.MaxValue);
					int num = 1;
					if (entity.team.value == Team.Blue)
					{
						((Color32)(ref val))._002Ector((byte)56, (byte)151, (byte)240, byte.MaxValue);
						num = -1;
					}
					_indicatorSpriteRenderer.color = Color32.op_Implicit(val);
					Vector3 localScale = default(Vector3);
					((Vector3)(ref localScale))._002Ector(7f, 7f, 1f);
					string value = entity.unitIdentifier.value;
					List<string> entityTags = GameEntityData.GetEntityTags(value);
					if (entityTags.Contains("建筑") && entityTags.Contains("BOSS"))
					{
						((Vector3)(ref localScale))._002Ector(40f, -50f, 1f);
					}
					else if (entityTags.Contains("IS_BOSS"))
					{
						((Vector3)(ref localScale))._002Ector((float)(num * 20), (float)(num * 25), 1f);
					}
					((Component)_indicatorSpriteRenderer).gameObject.transform.localScale = localScale;
				}
			});
			_indicatorNormal.SetActive(false);
		}
		if (!entity.hasUnitBaseImage || string.IsNullOrEmpty(entity.unitBaseImage.value))
		{
			return;
		}
		string text2 = (_baseImageName = entity.unitBaseImage.value);
		int entityId2 = entity.id.value;
		AssetsManager.Instance.LoadAsset<Sprite>(text2).Then((Action<Sprite>)delegate(Sprite asset)
		{
			if (entityId2 == _entity.id.value && _baseImage.activeInHierarchy)
			{
				_baseImageRenderer.sprite = asset;
			}
		});
	}

	public void AddSubView(IView view)
	{
		MonoBehaviour val = (MonoBehaviour)((view is MonoBehaviour) ? view : null);
		if (val != null)
		{
			((Component)val).transform.SetParent(((Component)this).transform);
		}
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
		_healthBarData = ObjectPool<HealthBarData>.Spawn((Func<HealthBarData>)(() => new HealthBarData()));
	}

	public void OnUnSpawn()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		Position = Vector3.op_Implicit(Vector3.zero);
		Rotation = Quaternion.identity;
		UnregisterListeners();
		_entity = null;
		ShowGizmos = false;
		if ((Object)(object)_healthBar != (Object)null)
		{
			_healthBarImage.transform.localPosition = Vector3.zero;
			_healthBar.SetActive(false);
		}
		if (Object.op_Implicit((Object)(object)_castBar))
		{
			_castBarImage.transform.localPosition = new Vector3(-4f, 0f, 0f);
			_castBar.SetActive(false);
		}
		if (!string.IsNullOrEmpty(_baseImageName))
		{
			_baseImageRenderer.sprite = null;
			AssetsManager.Instance.UnloadAsset<Sprite>(_baseImageName);
			_baseImageName = string.Empty;
		}
		if (!string.IsNullOrEmpty(_indicatorImageName))
		{
			_indicatorSpriteRenderer.sprite = null;
			AssetsManager.Instance.UnloadAsset<Sprite>(_indicatorImageName);
			_indicatorImageName = string.Empty;
		}
		_indicatorNormal.SetActive(true);
		_model.SetActive(true);
		Tweener tweener = _tweener;
		if (tweener != null)
		{
			TweenExtensions.Kill((Tween)(object)tweener, false);
		}
		_tweener = null;
		ObjectPool<HealthBarData>.UnSpawn(_healthBarData);
	}

	public void OnShowGizmos(GameEntity entity, bool value)
	{
		ShowGizmos = value;
	}

	public void OnUnitStats(GameEntity entity, UnitStats value)
	{
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		if (value.CurrentHealth < _healthBarData.CurrentHealthPoints)
		{
			_healthBarData.ReducingTime = 0.3f;
		}
		_healthBarData.MaxHealthPoints = value.MaxHealthPoints;
		_healthBarData.CurrentHealthPoints = value.CurrentHealth;
		float baseShield = value.BaseShield;
		float specialShield = value.SpecialShield;
		_healthBarData.ShouldShieldAlignWithRightSide = _healthBarData.CurrentHealthPoints + baseShield + specialShield > _healthBarData.MaxHealthPoints;
		_healthBarData.HealthPointsPercentage = ((_healthBarData.MaxHealthPoints == 0f) ? 0f : (_healthBarData.CurrentHealthPoints / _healthBarData.MaxHealthPoints));
		_healthBarData.BaseShieldPointsPercentage = Mathf.Min((_healthBarData.MaxHealthPoints == 0f) ? 0f : (baseShield / _healthBarData.MaxHealthPoints), 1f);
		_healthBarData.SpecialShieldPointsPercentage = Mathf.Min((_healthBarData.MaxHealthPoints == 0f) ? 0f : ((baseShield + specialShield) / _healthBarData.MaxHealthPoints), 1f);
		if ((_healthBarData.HealthPointsPercentage != 1f || baseShield + specialShield > 0f) && GameController.Contexts.config.healBarSwitcher.value && GameController.Contexts.Service<ReplayPlayerService>().ShowHealthBar)
		{
			_entity.isShowHealthBar = true;
		}
		if (_entity.isShowHealthBar && _healthBarData.ReducingTime > 0f)
		{
			Tweener tweener = _tweener;
			if (tweener != null)
			{
				TweenExtensions.Kill((Tween)(object)tweener, false);
			}
			_tweener = (Tweener)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => _healthBarData.ReducingHealthPointsPercentage), (DOSetter<float>)delegate(float x)
			{
				_healthBarData.ReducingHealthPointsPercentage = x;
			}, _healthBarData.HealthPointsPercentage, _healthBarData.ReducingTime), (TweenCallback)delegate
			{
				_healthBarData.ReducingTime = Mathf.Max(0f, _healthBarData.ReducingTime - 0.02f);
				SetHealthBarReduceImagePosition(_healthBarData.ReducingHealthPointsPercentage);
			});
		}
		else
		{
			SetHealthBarReduceImagePosition(_healthBarData.HealthPointsPercentage);
		}
		Vector3 localPosition = _healthBarImage.transform.localPosition;
		localPosition.x = (0f - (1f - _healthBarData.HealthPointsPercentage)) * 4f;
		_healthBarImage.transform.localPosition = localPosition;
		SetHealthBarShieldImagePosition(_healthBarData.BaseShieldPointsPercentage, _healthBarData.SpecialShieldPointsPercentage, _healthBarData.ShouldShieldAlignWithRightSide);
	}

	private void SetHealthBarReduceImagePosition(float percent)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Vector3 localPosition = _healthBarReduceImage.transform.localPosition;
		localPosition.x = (0f - (1f - percent)) * 4f;
		_healthBarReduceImage.transform.localPosition = localPosition;
	}

	private void SetHealthBarShieldImagePosition(float baseShieldPercent, float specialShieldPercent, bool alignRight = false)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (!alignRight)
		{
			baseShieldPercent = Mathf.Min(_healthBarData.HealthPointsPercentage + baseShieldPercent, 2f);
			specialShieldPercent = Mathf.Min(_healthBarData.HealthPointsPercentage + specialShieldPercent, 2f);
		}
		Vector3 localPosition = _healthBarBaseShieldImage.transform.localPosition;
		localPosition.x = (float)(alignRight ? 1 : (-1)) * (1f - baseShieldPercent) * 4f;
		_healthBarBaseShieldImage.transform.localPosition = localPosition;
		((Renderer)_healthBarBaseShieldImageRenderer).sortingOrder = (alignRight ? 7 : 4);
		Vector3 localPosition2 = _healthBarSpecialShieldImage.transform.localPosition;
		localPosition2.x = (float)(alignRight ? 1 : (-1)) * (1f - specialShieldPercent) * 4f;
		_healthBarSpecialShieldImage.transform.localPosition = localPosition2;
		((Renderer)_healthBarSpecialShieldImageRenderer).sortingOrder = (alignRight ? 6 : 3);
	}

	public void OnShowHealthBar(GameEntity entity)
	{
		_healthBar.SetActive(true);
	}

	public void OnShowHealthBarRemoved(GameEntity entity)
	{
		_healthBar.SetActive(false);
	}

	public void OnShowCastingBar(GameEntity entity)
	{
		_castBar.SetActive(true);
	}

	public void OnShowCastingBarRemoved(GameEntity entity)
	{
		_castBar.SetActive(false);
	}

	public void OnCastingAbilityElapsedTime(GameEntity entity, float value)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		float num = Mathf.Min(value / entity.castingAbilityCastTime.value, 1f);
		Vector3 localPosition = _castBarImage.transform.localPosition;
		localPosition.x = (0f - (1f - num)) * 4f;
		_castBarImage.transform.localPosition = localPosition;
	}

	public void RegisterListeners()
	{
		_entity.AddGameDestroyedListener(this);
		_entity.AddPositionListener(this);
		_entity.AddScaleListener(this);
		_entity.AddAssetRemovedListener(this);
		_entity.AddUnitStatsListener(this);
		_entity.AddShowHealthBarListener(this);
		_entity.AddShowHealthBarRemovedListener(this);
		_entity.AddShowCastingBarListener(this);
		_entity.AddShowCastingBarRemovedListener(this);
		_entity.AddCastingAbilityElapsedTimeListener(this);
		_entity.AddShowGizmosListener(this);
		_entity.AddRotationListener(this);
		_entity.AddSkeletonListener(this);
		_entity.AddUnitScaleListener(this);
		_entity.AddVisibleListener(this);
		_entity.AddVisibleRemovedListener(this);
		_entity.AddCollisionRadiusListener(this);
	}

	public void UnregisterListeners()
	{
		_entity.RemoveGameDestroyedListener(this);
		_entity.RemovePositionListener(this);
		_entity.RemoveScaleListener(this);
		_entity.RemoveAssetRemovedListener(this);
		_entity.RemoveUnitStatsListener(this);
		_entity.RemoveShowHealthBarListener(this);
		_entity.RemoveShowHealthBarRemovedListener(this);
		_entity.RemoveShowCastingBarListener(this);
		_entity.RemoveShowCastingBarRemovedListener(this);
		_entity.RemoveCastingAbilityElapsedTimeListener(this);
		_entity.RemoveShowGizmosListener(this);
		_entity.RemoveRotationListener(this);
		_entity.RemoveSkeletonListener(this);
		_entity.RemoveUnitScaleListener(this);
		_entity.RemoveVisibleListener(this);
		_entity.RemoveVisibleRemovedListener(this);
		_entity.RemoveCollisionRadiusListener(this);
	}

	public void OnUnitScale(GameEntity entity, float value)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		_model.transform.localScale = new Vector3(0.15f * value, 0.21210001f * value, 0.15f * value);
		RefreshBarPosition();
	}

	public void OnSkeleton(GameEntity entity, ISkeleton value)
	{
		RefreshBarPosition();
	}

	private void RefreshBarPosition()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (_entity != null && _entity.hasSkeleton && _entity.isAnimationInitialized && _entity.skeleton.value != null)
		{
			Vector3 bonePosition = _entity.skeleton.value.GetBonePosition("health_bar");
			_healthBar.transform.position = new Vector3(bonePosition.x, bonePosition.y, bonePosition.z);
			_castBar.transform.position = new Vector3(bonePosition.x, bonePosition.y - 0.1f, bonePosition.z);
		}
	}

	public void OnVisible(GameEntity entity)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (entity.hasPosition)
		{
			OnPosition(entity, entity.position.value);
		}
		if (entity.hasRotation)
		{
			OnRotation(entity, entity.rotation.value);
		}
		if (entity.hasScale)
		{
			OnScale(entity, entity.scale.value);
		}
		_model.SetActive(true);
	}

	public void OnVisibleRemoved(GameEntity entity)
	{
		_model.SetActive(false);
		_shadow_normal.SetActive(false);
		_shadow_boss.SetActive(false);
	}

	public void OnRotation(GameEntity entity, Quaternion value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		Rotation = value;
		_uvb.OnRotation(value.X, value.Y, value.Z, value.W);
		if (value == RotationHelper.Left)
		{
			_healthBar.transform.localRotation = Quaternion.op_Implicit(RotationHelper.Left);
			_castBar.transform.localRotation = Quaternion.op_Implicit(RotationHelper.Left);
			_baseImage.transform.localRotation = Quaternion.op_Implicit(RotationHelper.UnitBaseImageLeft);
			_baseImageRenderer.flipX = false;
			_indicatorSpriteRenderer.flipX = false;
			_indicatorSpriteRenderer.flipY = false;
		}
		else
		{
			_healthBar.transform.localRotation = Quaternion.op_Implicit(RotationHelper.Right);
			_castBar.transform.localRotation = Quaternion.op_Implicit(RotationHelper.Right);
			_baseImage.transform.localRotation = Quaternion.op_Implicit(RotationHelper.UnitBaseImageRight);
			_baseImageRenderer.flipX = true;
			_indicatorSpriteRenderer.flipX = true;
			_indicatorSpriteRenderer.flipY = true;
		}
	}

	public void OnCollisionRadius(GameEntity entity, float value)
	{
	}

	public void OnAnimationInitialized(GameEntity entity)
	{
		RefreshBarPosition();
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		Position = new Vector3(value.x, 0f, value.z);
		_uvb.OnPosition(value.x, 0f, value.z);
		_currentHeight = value.y;
		UpdateHeight();
	}

	public void OnScale(GameEntity entity, float value)
	{
		Scale = value;
		_uvb.OnScale(value);
		UpdateHeight();
	}

	private void UpdateHeight()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (Math.Abs(_currentHeight - _model.transform.position.y) > float.Epsilon)
		{
			Vector3 position = _model.transform.position;
			position.y = _currentHeight;
			_model.transform.position = position;
		}
	}

	public void OnAssetRemoved(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}

	public void OnDestroyed(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}
}
