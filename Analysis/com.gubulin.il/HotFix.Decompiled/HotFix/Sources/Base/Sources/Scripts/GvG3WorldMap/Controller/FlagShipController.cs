using System;
using System.Collections;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine.Unity;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class FlagShipController : MonoBehaviour
{
	private enum eFlagShipUIState
	{
		Idle,
		JumpIn,
		JumpOut,
		Shoot
	}

	private WorldStateManager WorldStateManager;

	private bool IsInit;

	private int CampId;

	private Transform ShootTrans;

	public Transform BeamTrans;

	private TransPageController<eFlagShipUIState> StatePages;

	private SkeletonAnimation SpineAnimation;

	private CoroutineQueue AnimCoroutineQueue;

	private FlagShipAttackEvent AttackEvent;

	private Action UpdateStrategy;

	private int CurStayIslandId;

	public void Load(int campId)
	{
		WorldStateManager = Singleton<WorldStateManager>.Instance;
		RenderStaticData(campId);
		RegisterModel(campId);
	}

	public void Unload()
	{
		UnRegisterModel();
		((Behaviour)this).enabled = false;
	}

	public void RegisterModel(int campId)
	{
		FlagShipStateModel flagShipStateModel = WorldStateManager.TryGetFlagShipByCampId(campId);
		RenderState(flagShipStateModel);
		flagShipStateModel.OnChangeStayIslandId = (Action<FlagShipStateModel>)Delegate.Combine(flagShipStateModel.OnChangeStayIslandId, new Action<FlagShipStateModel>(UpdateStayIslandId));
		flagShipStateModel.OnChangeAttackEvent = (Action<FlagShipStateModel>)Delegate.Combine(flagShipStateModel.OnChangeAttackEvent, new Action<FlagShipStateModel>(UpdateAttackEvent));
	}

	public void UnRegisterModel()
	{
		FlagShipStateModel flagShipStateModel = WorldStateManager.TryGetFlagShipByCampId(CampId);
		flagShipStateModel.OnChangeStayIslandId = (Action<FlagShipStateModel>)Delegate.Remove(flagShipStateModel.OnChangeStayIslandId, new Action<FlagShipStateModel>(UpdateStayIslandId));
		flagShipStateModel.OnChangeAttackEvent = (Action<FlagShipStateModel>)Delegate.Remove(flagShipStateModel.OnChangeAttackEvent, new Action<FlagShipStateModel>(UpdateAttackEvent));
	}

	private void RenderStaticData(int campId)
	{
		IsInit = true;
		CampId = campId;
		((Object)((Component)this).gameObject).name = $"{CampId}";
		CurStayIslandId = -1;
		AnimCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		((Object)((Component)this).transform.Find("Collider")).name = eObjectType.Flagship.ToString();
		ShootTrans = ((Component)this).transform.Find("Shoot");
		BeamTrans = ((Component)this).transform.Find("Shoot/Beam");
		StatePages = new TransPageController<eFlagShipUIState>(((Component)this).transform, eFlagShipUIState.Idle);
		SpineAnimation = ((Component)((Component)this).transform.Find("Spine")).GetComponent<SkeletonAnimation>();
		((SkeletonRenderer)SpineAnimation).Skeleton.SetSkin($"Camp{CampId}");
	}

	private void RenderState(FlagShipStateModel flagShipState)
	{
		UpdateStayIslandId(flagShipState);
		UpdateAttackEvent(flagShipState);
	}

	private void UpdateAttackEvent(FlagShipStateModel flagShipState)
	{
		AttackEvent = flagShipState.AttackEvent;
		double num = GameController.Instance.GetServerRealtimeSeconds() * 1000.0;
		if (AttackEvent != null && num < (double)AttackEvent.EndTimestamp_ms)
		{
			AnimCoroutineQueue.AddCoroutine(PlayAttacking());
		}
		else
		{
			AnimCoroutineQueue.AddCoroutine(PlayIdle());
		}
	}

	private void UpdateStayIslandId(FlagShipStateModel flagShipState)
	{
		if (IsInit)
		{
			IsInit = false;
			SetPosToIsland(flagShipState.StayIslandId);
		}
		else
		{
			AnimCoroutineQueue.AddCoroutine(PlayJumpToIsland(flagShipState.StayIslandId));
		}
	}

	private IEnumerator PlayJumpToIsland(int stayIslandId)
	{
		yield return null;
		if (CurStayIslandId != stayIslandId)
		{
			yield return PlayState(eFlagShipUIState.JumpOut);
			SetPosToIsland(stayIslandId);
			yield return PlayState(eFlagShipUIState.JumpIn);
			yield return PlayState(eFlagShipUIState.Idle);
		}
	}

	private IEnumerator PlayAttacking()
	{
		yield return null;
		eMissileType type = (eMissileType)AttackEvent.MissileType;
		int targetIslandId = AttackEvent.MissileDest;
		Vector3 targetPos = WorldMapConfigHelper.Configs.TryGetIsland(targetIslandId).Position;
		Vector3 gunPos = ((Component)GvGWorldMapController.Instance).transform.InverseTransformPoint(ShootTrans.position);
		Vector3 dir = targetPos - gunPos;
		ShootTrans.localRotation = Quaternion.LookRotation(dir, Vector3.up);
		Transform prefabTrans = GvGWorldMapController.Instance.GetIslandPrefabByIslandId(targetIslandId).transform;
		float targetShieldRadius = prefabTrans.Find("plane/Shield/Damaged/Icon").localScale.x;
		float targetDist = ((Vector3)(ref dir)).magnitude - targetShieldRadius;
		if (type == eMissileType.Laser)
		{
			((Component)BeamTrans).gameObject.SetActive(true);
			BeamTrans.localScale = new Vector3(1f, 1f, targetDist);
			UpdateStrategy = Update_LaserAttack;
		}
		if (AttackEvent.WaitForJumpAnimation)
		{
			AttackEvent.StartTimestamp_ms = (long)GameController.Instance.GetServerRealtimeSeconds() * 1000;
		}
		int curTargetId = AttackEvent.MissileDest;
		IslandStateModel curTarget = WorldStateManager.TryGetIsland(curTargetId);
		curTarget.SyncAttackEventFromFlagShip(AttackEvent);
		((Behaviour)this).enabled = true;
		yield return PlayState(eFlagShipUIState.Shoot);
	}

	private IEnumerator PlayIdle()
	{
		UpdateStrategy = null;
		((Behaviour)this).enabled = false;
		yield return null;
		yield return PlayState(eFlagShipUIState.Idle);
	}

	private IEnumerator PlayState(eFlagShipUIState state)
	{
		StatePages.SelectedPage = state;
		string animName = $"{state}";
		bool isLoop = state == eFlagShipUIState.Idle || state == eFlagShipUIState.Shoot;
		SpineAnimation.AnimationState.SetAnimation(0, animName, isLoop);
		if (!isLoop)
		{
			while (!SpineAnimation.AnimationState.GetCurrent(0).IsComplete)
			{
				yield return null;
			}
		}
	}

	private void Update_LaserAttack()
	{
		double num = GameController.Instance.GetServerRealtimeSeconds() * 1000.0;
		if (AttackEvent == null || (double)AttackEvent.EndTimestamp_ms < num)
		{
			AnimCoroutineQueue.AddCoroutine(PlayIdle());
		}
	}

	private void Update()
	{
		UpdateStrategy?.Invoke();
	}

	private void SetPosToIsland(int stayIslandId)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		CurStayIslandId = stayIslandId;
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(stayIslandId);
		Transform transform = GvGWorldMapController.Instance.GetIslandPrefabByIslandId(stayIslandId).transform;
		Vector3 position = islandConfigData.Position;
		Vector3 val = transform.InverseTransformPoint(transform.Find("plane/FlagShipSign").position) * islandConfigData.Props.S;
		((Component)this).transform.localPosition = position + val;
	}
}
