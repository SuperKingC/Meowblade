using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GameMaths;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;

public class Gvg3GroupBrawlFight : GvG3Group
{
	private Coroutine _rebornCoroutine;

	private bool _inited = false;

	public EntityInfo Info;

	public override void SetDead()
	{
		IsDead = true;
		Info.IsDead = true;
		AvatarWrapper.FadeOut(delegate
		{
			Hide();
		});
		if (IsCurUser)
		{
			NoticeMyLeavingToMyTarget();
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_DEAD");
		}
	}

	public void Hide()
	{
		((Component)this).gameObject.SetActive(false);
		((GObject)AvatarWrapper).visible = false;
	}

	public void Show()
	{
		((Component)this).gameObject.SetActive(true);
		((GObject)AvatarWrapper).visible = true;
		AvatarWrapper.UndoFadeOut();
	}

	public void StopShowAnimation()
	{
		AvatarWrapper.StopShowAnimation();
	}

	public override void SetState(eGvGMode3FightingState state, float x, float y, int role, byte[] bin, int holdingSpeed)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		List<eGvGMode3FightingState> list = new List<eGvGMode3FightingState>
		{
			eGvGMode3FightingState.Fighting,
			eGvGMode3FightingState.PeaceMarching,
			eGvGMode3FightingState.MovingHoldPos,
			eGvGMode3FightingState.InFightingZone,
			eGvGMode3FightingState.InReborn
		};
		if (list.Contains(state) && bin == null)
		{
			ILRuntimeDebug.LogError($"Wrong state info Skip -- {state}: bin == null");
			return;
		}
		base.SetState(state, x, y, role, bin, holdingSpeed);
		if (state == eGvGMode3FightingState.InReborn)
		{
			GvGStateChange_InReborn gvGStateChange_InReborn = bin.Deserialize<GvGStateChange_InReborn>();
			SetLocation(Vector3.op_Implicit(new Vector3(gvGStateChange_InReborn.X, 0f, gvGStateChange_InReborn.Y) / 1000f));
			_rebornCoroutine = ((MonoBehaviour)this).StartCoroutine(StartRebornCoroutine(gvGStateChange_InReborn.DeadFrame, gvGStateChange_InReborn.RebornFrame));
		}
	}

	private IEnumerator StartRebornCoroutine(long deadFrame, long rebornFrame)
	{
		GvG3BrawlFightRecordPlayer player = (GvG3BrawlFightRecordPlayer)GvG3IslandController.Instance;
		double endSeconds = (double)rebornFrame / 15.0;
		double beginSeconds = (double)deadFrame / 15.0;
		double maxSeconds = endSeconds - beginSeconds;
		bool isWaited = false;
		while ((double)player.CurrentTime <= endSeconds)
		{
			isWaited = true;
			float currentTime = player.CurrentTime;
			float percent = (float)((endSeconds - (double)currentTime) / maxSeconds);
			AvatarWrapper.SetRebornProgress(percent);
			yield return null;
		}
		if (!isWaited)
		{
			yield return null;
		}
		SetSoldierNum(SoldierNumOnInit);
		_rebornCoroutine = null;
	}

	public void OnBrawlFightKeyFrame()
	{
		IsMoving = false;
		CoroutineQueue.Clear();
		if (_rebornCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(_rebornCoroutine);
			_rebornCoroutine = null;
		}
		IsCurUserTarget = false;
		SetToBeGeneral();
	}

	protected override void SetFightingTarget(int targetId)
	{
		GvG3BrawlFightRecordPlayer gvG3BrawlFightRecordPlayer = (GvG3BrawlFightRecordPlayer)GvG3IslandController.Instance;
		gvG3BrawlFightRecordPlayer.SetFightingTarget(EntityId, targetId);
	}

	public override void SetAnim(eAnimName animName)
	{
		if (_inited && CurAnimName == animName)
		{
			return;
		}
		_inited = true;
		CurAnimName = animName;
		if (SoldiersMeshRenderer_Dict != null)
		{
			foreach (KeyValuePair<string, List<MeshRenderer>> item in SoldiersMeshRenderer_Dict)
			{
				Material animMat = Singleton<AnimMapCacheManager>.Instance.GetAnimMat(item.Key, CurAnimName);
				foreach (MeshRenderer item2 in item.Value)
				{
					((Renderer)item2).material = animMat;
				}
			}
		}
		if (animName == eAnimName.attack)
		{
			foreach (GvG3Unit matrixUnit in MatrixUnits)
			{
				matrixUnit.PlaySfx();
			}
			return;
		}
		foreach (GvG3Unit matrixUnit2 in MatrixUnits)
		{
			matrixUnit2.StopSfx();
		}
	}
}
