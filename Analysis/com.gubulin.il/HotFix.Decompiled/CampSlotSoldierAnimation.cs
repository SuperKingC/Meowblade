using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

public class CampSlotSoldierAnimation : MonoBehaviour
{
	public Transform[] PortalToStartPath1;

	public float WorkerSpeed;

	public MeshRenderer SoldierRenderer;

	public int PortalNum;

	private Tweener _portalToStartTweener1;

	private SkeletonAnimation _animation;

	private string _soldierId;

	private float _x;

	public bool Interrupt;

	private int _timerId = -1;

	private void Awake()
	{
		_animation = ((Component)((Component)this).gameObject.transform).GetComponent<SkeletonAnimation>();
		SoldierRenderer = ((Component)this).gameObject.GetComponent<MeshRenderer>();
		GameController.Contexts.Service<BaseSceneService>().AddMonoBehaviour((MonoBehaviour)(object)this);
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		if (_timerId > 0)
		{
			ScriptApi.StopTimer(_timerId);
		}
	}

	private void Update()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (_animation.AnimationName == "run")
		{
			if ((double)(((Component)this).transform.position.x - _x) >= 0.0001)
			{
				((SkeletonRenderer)_animation).skeleton.FlipX = false;
			}
			else if ((double)(((Component)this).transform.position.x - _x) <= -0.0001)
			{
				((SkeletonRenderer)_animation).skeleton.FlipX = true;
			}
		}
		_x = ((Component)this).transform.position.x;
	}

	public void InitAnimation(SkeletonDataAsset asset, string soldierId, float initX)
	{
		_soldierId = soldierId;
		_x = initX;
		((SkeletonRenderer)_animation).skeletonDataAsset = asset;
		int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
		int num = (soldierPotentialLevel + 2) / 2;
		((SkeletonRenderer)_animation).initialSkinName = $"skin{num}";
		((SkeletonRenderer)_animation).Initialize(true);
		((SkeletonRenderer)_animation).skeleton.FlipX = false;
	}

	public void SetSoldierAnimationInfoOnProducting(float time, Transform[] transformsArray, List<GameObject> soldierList)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		Interrupt = false;
		PortalToStartPath1 = transformsArray;
		_animation.AnimationName = "idle";
		MaterialPropertyBlock val = new MaterialPropertyBlock();
		val.SetFloat("_IsOpenOverlay", 1f);
		((Renderer)SoldierRenderer).SetPropertyBlock(val);
		((Renderer)SoldierRenderer).sortingOrder = 3;
		((Component)this).gameObject.SetActive(true);
		WorkerSpeed = GDMgr.Get<GDESoldierData>(_soldierId).MoveSpeed;
		_timerId = ScriptApi.CreateTimer(time + 0.5f, delegate
		{
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			_timerId = -1;
			((Component)this).gameObject.SetActive(false);
			if ((Object)(object)_animation != (Object)null)
			{
				_animation.AnimationName = "run";
				MaterialPropertyBlock val2 = new MaterialPropertyBlock();
				val2.SetFloat("_IsOpenOverlay", 0f);
				((Renderer)SoldierRenderer).SetPropertyBlock(val2);
			}
			if (!Interrupt)
			{
				((Component)this).gameObject.SetActive(true);
			}
			PortalToStart(soldierList);
		});
	}

	public void SetSoldierAnimationInfoOnDouble(float time, Transform[] transformsArray, List<GameObject> soldierList)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		Interrupt = false;
		PortalToStartPath1 = transformsArray;
		_animation.AnimationName = "run";
		MaterialPropertyBlock val = new MaterialPropertyBlock();
		val.SetFloat("_IsOpenOverlay", 0f);
		((Renderer)SoldierRenderer).SetPropertyBlock(val);
		((Renderer)SoldierRenderer).sortingOrder = 3;
		((Component)this).gameObject.SetActive(true);
		WorkerSpeed = GDMgr.Get<GDESoldierData>(_soldierId).MoveSpeed;
		((Component)this).gameObject.SetActive(false);
		_timerId = ScriptApi.CreateTimer(time, delegate
		{
			_timerId = -1;
			if (!Interrupt)
			{
				((Component)this).gameObject.SetActive(true);
			}
			PortalToStart(soldierList);
		});
	}

	public void SetSoldierAnimationInfoOnWaitProduct(int sortingOrder = 3)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		_animation.AnimationName = "idle";
		MaterialPropertyBlock val = new MaterialPropertyBlock();
		val.SetFloat("_IsOpenOverlay", 1f);
		((Renderer)SoldierRenderer).SetPropertyBlock(val);
		((Renderer)SoldierRenderer).sortingOrder = sortingOrder;
		((Component)this).gameObject.SetActive(true);
	}

	public void PortalToStart(List<GameObject> soldierList)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		if (_portalToStartTweener1 != null)
		{
			TweenExtensions.Restart((Tween)(object)_portalToStartTweener1, true, -1f);
			return;
		}
		TweenExtensions.Kill((Tween)(object)_portalToStartTweener1, false);
		Vector3[] array = TransformListToPosArray(PortalToStartPath1);
		_portalToStartTweener1 = (Tweener)(object)TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetAutoKill<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetSpeedBased<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(((Component)this).transform, array, WorkerSpeed, (PathType)1, (PathMode)1, 10, (Color?)null), (Ease)1), true), false), (TweenCallback)delegate
		{
			if (soldierList == null)
			{
				Object.Destroy((Object)(object)((Component)this).gameObject);
			}
			else
			{
				((Component)this).gameObject.SetActive(false);
				soldierList.Add(((Component)this).gameObject);
			}
		});
	}

	public Vector3[] TransformListToPosArray(Transform[] transformsArray)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < transformsArray.Length; i++)
		{
			list.Add(transformsArray[i].position);
		}
		return list.ToArray();
	}
}
