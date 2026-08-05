using System;
using DG.Tweening;
using FairyGUI;
using Shift.Legion.Common.Enums;
using Spine;
using Spine.Unity;
using UnityEngine;

public class StagingArea : MonoBehaviour
{
	[SerializeField]
	public GameObject frame;

	[SerializeField]
	public SpriteRenderer frameRenderer;

	[SerializeField]
	public GameObject portal;

	[SerializeField]
	public SkeletonAnimation portalAnimation;

	[SerializeField]
	public GameObject halo;

	[HideInInspector]
	public GComponent haloCom;

	private string _levelId;

	private void Awake()
	{
		frame = ((Component)((Component)this).transform.Find("Frame")).gameObject;
		frameRenderer = frame.GetComponent<SpriteRenderer>();
		portal = ((Component)((Component)this).transform.Find("Portal")).gameObject;
		portalAnimation = portal.GetComponent<SkeletonAnimation>();
		halo = ((Component)((Component)this).transform.Find("Halo")).gameObject;
	}

	public void SetMode(BattleMode battleMode, string levelId, bool isIsAssistanceSlot = false)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		if (!Object.op_Implicit((Object)(object)((Component)this).gameObject))
		{
			return;
		}
		bool flag = battleMode == BattleMode.MultiWaveAttackMode;
		frame.SetActive(!flag);
		portal.SetActive(flag);
		halo.SetActive(battleMode == BattleMode.DefenceMode);
		LoadHaloCom(battleMode == BattleMode.DefenceMode);
		if (flag)
		{
			SpawnManager.Instance.LoadAnimation("bettle_field_slot").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				((SkeletonRenderer)portalAnimation).skeletonDataAsset = asset;
				if ((Object)(object)((SkeletonRenderer)portalAnimation).skeletonDataAsset != (Object)null)
				{
					AtlasAsset[] atlasAssets = ((SkeletonRenderer)portalAnimation).skeletonDataAsset.atlasAssets;
					foreach (AtlasAsset val in atlasAssets)
					{
						if ((Object)(object)val != (Object)null)
						{
							val.Clear();
						}
					}
					((SkeletonRenderer)portalAnimation).skeletonDataAsset.Clear();
				}
				AnimationStateData animationStateData = ((SkeletonRenderer)portalAnimation).SkeletonDataAsset.GetAnimationStateData();
				if (animationStateData.SkeletonData.Skins.Count > 0)
				{
					((SkeletonRenderer)portalAnimation).initialSkinName = animationStateData.SkeletonData.Skins.Items[0].Name;
				}
				((SkeletonRenderer)portalAnimation).Initialize(true);
				PlayAnimation();
			});
		}
		else
		{
			((Renderer)frameRenderer).sortingOrder = -1;
			string text = (isIsAssistanceSlot ? "frame_grid_formation_helper" : "formation_mark");
			AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
			{
				frameRenderer.sprite = asset;
			});
			if ((Object)(object)((Component)this).transform == (Object)null || (Object)(object)((Component)this).transform.parent == (Object)null || (Object)(object)((Component)this).transform.parent.parent == (Object)null)
			{
				return;
			}
			Vector3 localScale = ((Component)this).transform.parent.parent.localScale;
			TweenSettingsExtensions.SetEase<Tweener>(TweenSettingsExtensions.SetLoops<Tweener>(ShortcutExtensions.DOScale(((Component)this).transform, new Vector3(0.97f / localScale.x, 0.97f / localScale.y, 0.97f / localScale.z), 1f), -1, (LoopType)1), (Ease)1);
			if (levelId != _levelId)
			{
				ScriptApi.CreateTimer(0.5f, delegate
				{
					((Renderer)frameRenderer).sortingOrder = 4;
				});
			}
			else
			{
				((Renderer)frameRenderer).sortingOrder = 4;
			}
		}
		_levelId = levelId;
	}

	private void LoadHaloCom(bool isDefence)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (isDefence && haloCom == null)
		{
			UIPanel val = halo.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "Halo";
			val.container.renderMode = (RenderMode)2;
			val.sortingOrder = 0;
			val.SetSortingOrder(4, true);
			val.CreateUI();
			((Component)val).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
			((GObject)val.ui).alpha = 0f;
			haloCom = val.ui;
			((GObject)haloCom).visible = !GameLocalDataManager.HasKey("AlertHaloSwitch") || GameLocalDataManager.GetBool("AlertHaloSwitch");
		}
	}

	public void PlayAnimation()
	{
		portalAnimation.state.ClearTrack(0);
	}

	public GameObject CreatePortalAnimation()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.Instance.InstantiatePool("battlefield_slot_start", Vector3.zero);
		SpawnManager.Instance.CacheBattleTag.Add(val);
		val.SetActive(false);
		int sortingLayerID = SortingLayer.NameToID("Entities");
		ParticleSystem[] componentsInChildren = val.GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] array = componentsInChildren;
		foreach (ParticleSystem val2 in array)
		{
			ParticleSystemRenderer component = ((Component)val2).GetComponent<ParticleSystemRenderer>();
			((Renderer)component).sortingLayerID = sortingLayerID;
		}
		SpriteRenderer[] componentsInChildren2 = val.GetComponentsInChildren<SpriteRenderer>();
		SpriteRenderer[] array2 = componentsInChildren2;
		foreach (SpriteRenderer val3 in array2)
		{
			((Renderer)val3).sortingLayerID = sortingLayerID;
		}
		val.transform.position = ((Component)this).transform.position;
		val.transform.localScale = Vector3.one;
		return val;
	}

	public async void PlayPortalAnimation(bool onChangeSoldier = false)
	{
		if (!onChangeSoldier)
		{
			portalAnimation.state.SetAnimation(0, "idle", true);
		}
		GameObject fx = await SpawnManager.Instance.InstantiatePoolAsync("FX/Prefabs/battlefield_slot_start", Vector3.zero);
		SpawnManager.Instance.CacheBattleTag.Add(fx);
		fx.SetActive(false);
		int entitiesLayerId = SortingLayer.NameToID("Entities");
		ParticleSystem[] particleSystems = fx.GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] array = particleSystems;
		foreach (ParticleSystem system in array)
		{
			ParticleSystemRenderer particleSystemRenderer = ((Component)system).GetComponent<ParticleSystemRenderer>();
			((Renderer)particleSystemRenderer).sortingLayerID = entitiesLayerId;
		}
		SpriteRenderer[] spriteRenderers = fx.GetComponentsInChildren<SpriteRenderer>();
		SpriteRenderer[] array2 = spriteRenderers;
		foreach (SpriteRenderer spriteRenderer in array2)
		{
			((Renderer)spriteRenderer).sortingLayerID = entitiesLayerId;
		}
		fx.transform.parent = ((Component)this).transform;
		fx.transform.localScale = Vector3.one;
		fx.transform.localPosition = Vector3.zero;
		fx.SetActive(true);
		ScriptApi.CreateTimer(1.5f, delegate
		{
			SpawnManager.Instance.Destroy(fx);
		});
	}

	public void SetFrameSize(Vector2 size)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		frameRenderer.size = size;
	}

	public void SetFrameColor(Color32 color)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		frameRenderer.color = Color32.op_Implicit(color);
	}

	public void HideEffect()
	{
		frame.SetActive(false);
		portal.SetActive(false);
		SkeletonAnimation obj = portalAnimation;
		if (obj != null)
		{
			SkeletonDataAsset skeletonDataAsset = ((SkeletonRenderer)obj).skeletonDataAsset;
			if (skeletonDataAsset != null)
			{
				skeletonDataAsset.Clear();
			}
		}
	}
}
