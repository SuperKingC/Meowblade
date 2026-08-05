using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Models;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.GvG.Common;

public class GvGBossAttackManager
{
	private static GvGBossAttackManager _Instance;

	private Coroutine UpdateCoroutineHandler;

	private SkeletonAnimation BossSkeletonAnimation;

	private string LaunchBoneName;

	private Bone LaunchBone;

	private GvGGroup BossGroup;

	private GameObject ProjectileObj;

	private GvGProjectile Projectile;

	private BossAttackInfo AttackInfo;

	private GameObject SfxObj;

	private ParticleSystem SfxParticle;

	private float AttackAnimDuration;

	public static GvGBossAttackManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new GvGBossAttackManager();
			}
			return _Instance;
		}
	}

	public void SetBossInfo(string wbId, GvGGroup bossGroup)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wbId);
		BossAttackInfo attackInfo = gvGWorldBossInfoByWBId.attackInfo;
		BossGroup = bossGroup;
		LaunchBoneName = "launch_point";
		LaunchBone = null;
		BossSkeletonAnimation = bossGroup.BossAnimation;
		ProjectileObj = null;
		SfxObj = null;
		if (!attackInfo.isMelee && !string.IsNullOrEmpty(attackInfo.projectileName))
		{
			ProjectileObj = Addressables.InstantiateAsync((object)attackInfo.projectileName, GvGWorldController.Instance.AttackSfxContainer, false, true).WaitForCompletion();
			ProjectileObj.SetActive(false);
			float projectileScale = attackInfo.projectileScale;
			Projectile = ProjectileObj.AddComponent<GvGProjectile>();
			Projectile.ProjectileRatio = attackInfo.parabolaRatio;
			Projectile.MoveType = 2;
			Projectile.UseMoveTime = true;
			Projectile.MoveTime = attackInfo.projectileHitTime;
			((Component)Projectile).transform.localScale = new Vector3(projectileScale, projectileScale, projectileScale);
		}
		if (!string.IsNullOrEmpty(attackInfo.sfxName))
		{
			float sfxScale = attackInfo.sfxScale;
			SfxObj = Addressables.InstantiateAsync((object)attackInfo.sfxName, GvGWorldController.Instance.AttackSfxContainer, false, true).WaitForCompletion();
			SfxObj.SetActive(false);
			SfxObj.transform.localScale = new Vector3(sfxScale, sfxScale, sfxScale);
			SfxParticle = SfxObj.GetComponent<ParticleSystem>();
		}
		AttackInfo = attackInfo;
	}

	public void SetProjectileTargetPos(Vector3 target)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)Projectile == (Object)null))
		{
			Projectile.TargetPos = target;
		}
	}

	public void StartAttack(bool isLoop = true)
	{
		if (AttackInfo == null)
		{
			return;
		}
		if (isLoop)
		{
			if (UpdateCoroutineHandler != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(UpdateCoroutineHandler);
				UpdateCoroutineHandler = null;
			}
			UpdateCoroutineHandler = FGUIManager.Instance.OpenIEnumerator(CreateAttackLoop());
		}
		else
		{
			CreateSingleAttack();
		}
	}

	public void StopAttacking()
	{
		if (UpdateCoroutineHandler != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(UpdateCoroutineHandler);
			UpdateCoroutineHandler = null;
		}
		if ((Object)(object)ProjectileObj != (Object)null)
		{
			Addressables.ReleaseInstance(ProjectileObj);
			ProjectileObj = null;
		}
		if ((Object)(object)SfxObj != (Object)null)
		{
			Addressables.ReleaseInstance(SfxObj);
			SfxObj = null;
		}
		AttackInfo = null;
	}

	private IEnumerator CreateAttackLoop()
	{
		AttackAnimDuration = ((SkeletonRenderer)BossSkeletonAnimation).Skeleton.Data.FindAnimation(BossSkeletonAnimation.AnimationName).Duration;
		yield return (object)new WaitForSeconds(AttackInfo.launchTimePercent * AttackAnimDuration);
		float nextAttackTime = Time.time;
		float nextHitTime = Time.time + AttackInfo.projectileHitTime;
		while (true)
		{
			if (Time.time >= nextAttackTime)
			{
				nextAttackTime += AttackAnimDuration;
				CreateSingleAttack();
			}
			if (!AttackInfo.isMelee && Time.time >= nextHitTime)
			{
				nextHitTime += AttackAnimDuration;
				CreateSfxAttack();
			}
			yield return null;
		}
	}

	private void CreateSingleAttack()
	{
		if (AttackInfo.isMelee)
		{
			CreateSfxAttack();
			return;
		}
		ChangeTarget();
		LaunchProjectile();
	}

	private void ChangeTarget()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, GvGGroup> dict_GvGGroup = GvGWorldController.Instance.Dict_GvGGroup;
		if (dict_GvGGroup == null || dict_GvGGroup.Count <= 1 || (Object)(object)Projectile == (Object)null)
		{
			Projectile.TargetPos = new Vector3(40.69f, -18.8f, 93.51f);
			return;
		}
		int num = 0;
		int num2 = Random.Range(0, dict_GvGGroup.Count - 1);
		List<Transform> units = null;
		foreach (KeyValuePair<string, GvGGroup> item in dict_GvGGroup)
		{
			GvGGroup value = item.Value;
			if (!value.IsBoss)
			{
				if (num == num2)
				{
					units = value.AllUnitsTransform;
					break;
				}
				num++;
			}
		}
		units = FilterUnits(units);
		if (units == null || units.Count == 0)
		{
			Projectile.TargetPos = new Vector3(40.69f, -18.8f, 93.51f);
			return;
		}
		num2 = Random.Range(0, units.Count);
		Projectile.TargetPos = units[num2].position;
	}

	private List<Transform> FilterUnits(List<Transform> units)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		float x = ((Component)BossGroup).transform.position.x;
		List<Transform> list = new List<Transform>();
		foreach (Transform unit in units)
		{
			if (unit.position.x < x)
			{
				list.Add(unit);
			}
		}
		return list;
	}

	private void CreateSfxAttack()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (AttackInfo.isMelee)
		{
			SfxObj.transform.position = ((Component)BossGroup).transform.position;
		}
		else
		{
			SfxObj.transform.position = ((Component)Projectile).transform.position;
		}
		SfxParticle.Clear();
		SfxParticle.Play();
		SfxObj.SetActive(true);
	}

	private void LaunchProjectile()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		Projectile.StartPos = GetBonePosition(LaunchBoneName);
		ProjectileObj.SetActive(true);
		Projectile.StartMove();
	}

	public Quaternion GetBoneRotation(string boneName)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (LaunchBone == null)
		{
			LaunchBone = ((SkeletonRenderer)BossSkeletonAnimation).Skeleton.FindBone(boneName);
		}
		return SkeletonExtensions.GetQuaternion(LaunchBone);
	}

	public Vector3 GetBonePosition(string boneName)
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)BossSkeletonAnimation).gameObject.transform;
		if (LaunchBone == null)
		{
			LaunchBone = ((SkeletonRenderer)BossSkeletonAnimation).Skeleton.FindBone(boneName);
		}
		Vector3 zero = default(Vector3);
		if (LaunchBone == null)
		{
			PointAttachment val = FindSkeletonPoint(((SkeletonRenderer)BossSkeletonAnimation).Skeleton, boneName);
			if (val == null)
			{
				zero = Vector3.zero;
			}
			else
			{
				((Vector3)(ref zero))._002Ector(val.X, val.Y * transform.localScale.y, 0f);
			}
		}
		else
		{
			((Vector3)(ref zero))._002Ector(LaunchBone.WorldX, LaunchBone.WorldY, 0f);
		}
		zero.x = (0f - zero.x) * (float)BossGroup.RoleFace;
		return transform.TransformPoint(zero);
	}

	private PointAttachment FindSkeletonPoint(Skeleton skeleton, string pointName)
	{
		int num = skeleton.FindSlotIndex(pointName);
		if (num >= 0)
		{
			Attachment attachment = skeleton.GetAttachment(num, pointName);
			return (PointAttachment)(object)((attachment is PointAttachment) ? attachment : null);
		}
		return null;
	}
}
