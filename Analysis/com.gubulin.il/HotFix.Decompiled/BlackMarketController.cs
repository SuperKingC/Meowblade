using System;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

public class BlackMarketController : MonoBehaviour
{
	private const string AnimationWorking = "work";

	private const string AnimationRun = "run";

	private const string AnimationIdle = "idle";

	private const int AnimationRunIndex = 1;

	private SkeletonAnimation _workerAnimation;

	public Tweener CycleTweener;

	public Transform[] CyclePath;

	public GameObject Merchant;

	private float _x;

	private void Awake()
	{
		GameController.Contexts.Service<BaseSceneService>().AddMonoBehaviour((MonoBehaviour)(object)this);
	}

	private void Start()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", MerchantCycle);
		_workerAnimation = Merchant.GetComponent<SkeletonAnimation>();
		Vector3 position = CyclePath.First().position;
		Merchant.transform.position = position;
		_x = position.x;
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			MerchantInit();
		}
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", MerchantCycle);
	}

	private void Update()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)((SkeletonRenderer)_workerAnimation).skeletonDataAsset != (Object)null)
		{
			float num = Merchant.transform.position.x - _x;
			if (Math.Abs(num) > float.Epsilon)
			{
				((SkeletonRenderer)_workerAnimation).skeleton.FlipX = num > 0f;
			}
			_x += num;
		}
	}

	private void MerchantInit()
	{
		SpawnManager.Instance.LoadAnimation("merchant").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)asset != (Object)null)
			{
				((SkeletonRenderer)_workerAnimation).skeletonDataAsset = asset;
				((SkeletonRenderer)_workerAnimation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)_workerAnimation, "skin1");
				_workerAnimation.timeScale = 1f;
				ScriptApi.CreateTimer(3f, SetMerchantCycle);
			}
		});
	}

	private void SetMerchantCycle()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (CycleTweener != null && !TweenExtensions.IsComplete((Tween)(object)CycleTweener))
		{
			TweenExtensions.Complete((Tween)(object)CycleTweener, false);
		}
		TweenCallback val = (TweenCallback)delegate
		{
			CycleTweener = null;
			SetMerchantCycle();
		};
		TweenCallback<int> val2 = delegate
		{
			int num = Random.Range(0, 3);
			float duration = 1.333f;
			if (num == 1)
			{
				_workerAnimation.AnimationName = "work";
				_workerAnimation.loop = false;
			}
			else
			{
				_workerAnimation.AnimationName = "idle";
				_workerAnimation.loop = true;
				duration = Random.Range(1f, 6f);
			}
			TweenExtensions.Pause<Tweener>(CycleTweener);
			ScriptApi.CreateTimer(duration, delegate
			{
				_workerAnimation.AnimationName = "run";
				_workerAnimation.loop = true;
				TweenExtensions.Play<Tweener>(CycleTweener);
			});
		};
		_workerAnimation.AnimationName = "run";
		CycleTweener = (Tweener)(object)TweenSettingsExtensions.SetAutoKill<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetSpeedBased<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnWaypointChange<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(Merchant.transform, TransformListToPosArray(CyclePath), 1f, (PathType)0, (PathMode)2, 10, (Color?)null), val), val2), (Ease)1), true), false);
	}

	private void MerchantCycle(string buildingType, int level)
	{
		if (buildingType == "16" && level == 1)
		{
			MerchantInit();
		}
	}

	public Vector3[] TransformListToPosArray(Transform[] transformsArray)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] array = (Vector3[])(object)new Vector3[transformsArray.Length];
		for (int i = 0; i < transformsArray.Length; i++)
		{
			array[i] = transformsArray[i].position;
		}
		return array;
	}
}
