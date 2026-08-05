using System.Collections;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipDetail;

public class OarDeckWorker
{
	public enum AnimState
	{
		sailorworker_chuanqi,
		sailorworker_work,
		chezi
	}

	private const float AnimScale = 18f;

	private GameObject SpineGameObject;

	private SkeletonAnimation Animation;

	private float WorkingAnimDuration = -1f;

	private AnimState CurState;

	private bool IsActive;

	private CoroutineQueue AnimCoroutineQueue;

	public bool IsWorking => CurState == AnimState.sailorworker_work;

	public OarDeckWorker(GGraph loader, bool isActive)
	{
		SpineGameObject = UiHelper.LoadSpine_AB(loader, "Goblinworker_001", 18f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin_sailorworker");
			Animation = animation;
			WorkingAnimDuration = ((SkeletonRenderer)Animation).Skeleton.Data.FindAnimation(AnimState.sailorworker_work.ToString()).Duration;
			SetAnimState(CurState);
		});
		if (isActive)
		{
			IsActive = isActive;
			AnimCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
			SetAnimState(AnimState.sailorworker_work);
		}
		else
		{
			SetAnimState(AnimState.chezi);
		}
	}

	public void Destroy()
	{
		AnimCoroutineQueue?.Clear();
		if ((Object)(object)SpineGameObject != (Object)null)
		{
			Object.Destroy((Object)(object)SpineGameObject);
		}
	}

	public void StartSlackingOff()
	{
		if (IsActive && !(WorkingAnimDuration < 0f))
		{
			float seconds = Random.Range(1f, 12f);
			float seconds2 = WorkingAnimDuration - Time.time % WorkingAnimDuration;
			AnimCoroutineQueue.AddCoroutine(WaitForSeconds(seconds2));
			AnimCoroutineQueue.AddCoroutine(UpdateToIdle());
			AnimCoroutineQueue.AddCoroutine(WaitForSeconds(seconds));
			AnimCoroutineQueue.AddCoroutine(UpdateToWork());
			AnimCoroutineQueue.AddCoroutine(WaitForSeconds(1f));
		}
	}

	private IEnumerator UpdateToIdle()
	{
		SetAnimState(AnimState.sailorworker_chuanqi);
		yield break;
	}

	private IEnumerator WaitForSeconds(float seconds)
	{
		yield return (object)new WaitForSeconds(seconds);
	}

	private IEnumerator UpdateToWork()
	{
		SetAnimState(AnimState.sailorworker_work);
		yield break;
	}

	private void SetAnimState(AnimState state)
	{
		CurState = state;
		if (!((Object)(object)Animation == (Object)null))
		{
			string text = state.ToString();
			TrackEntry val = Animation.AnimationState.SetAnimation(0, text, true);
			val.MixDuration = 0.2f;
			if (state == AnimState.sailorworker_work)
			{
				val.TrackTime = Time.time % WorkingAnimDuration;
			}
		}
	}
}
