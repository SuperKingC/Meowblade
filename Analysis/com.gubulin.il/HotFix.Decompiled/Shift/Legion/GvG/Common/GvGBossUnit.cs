using System.Collections.Generic;
using Shift.Legion.Common.Models;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.GvG.Common;

public class GvGBossUnit
{
	private BossAttackInfo AttackInfo;

	private GvGGroup ParentGroup;

	private SkeletonAnimation BossSkeletonAnimation;

	private string LaunchBoneName;

	private Bone LaunchBone;

	private GameObject ProjectileObj;

	private GvGProjectile Projectile;

	private GameObject SfxObj;

	private ParticleSystem SfxParticle;

	public GvGBossUnit(string wbId, GvGGroup parentGroup, SkeletonAnimation animation)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wbId);
		BossAttackInfo attackInfo = gvGWorldBossInfoByWBId.attackInfo;
		ParentGroup = parentGroup;
		LaunchBoneName = "launch_point";
		LaunchBone = null;
		BossSkeletonAnimation = animation;
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
		BossSkeletonAnimation.state.Event += (TrackEntryEventDelegate)delegate(TrackEntry trackEntry, Event e)
		{
			string name = e.Data.Name;
			string text = name;
			if (!(text == "OnHit"))
			{
				if (text == "OnShoot")
				{
					LaunchProjectile();
				}
			}
			else
			{
				CreateMeleeAttack();
			}
		};
	}

	public void Destroy()
	{
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
	}

	public void StartAnimation(eAnimName animName)
	{
		BossSkeletonAnimation.AnimationName = ((animName == eAnimName.attack) ? "gvg_boss_attack1" : animName.ToString());
		BossSkeletonAnimation.loop = true;
	}

	private void CreateMeleeAttack()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		SfxObj.transform.position = ((Component)ParentGroup).transform.position;
		SfxParticle.Clear();
		SfxParticle.Play();
		SfxObj.SetActive(true);
	}

	private void LaunchProjectile()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		RandomChooseTarget();
		Projectile.StartPos = GetBonePosition(LaunchBoneName);
		ProjectileObj.SetActive(true);
		Projectile.StartMove(delegate
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			SfxObj.transform.position = ((Component)Projectile).transform.position;
			SfxParticle.Clear();
			SfxParticle.Play();
			SfxObj.SetActive(true);
		});
	}

	private void RandomChooseTarget()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, GvGGroup> dict_GvGGroup = GvGWorldController.Instance.Dict_GvGGroup;
		if (dict_GvGGroup == null || dict_GvGGroup.Count <= 1 || (Object)(object)Projectile == (Object)null)
		{
			Projectile.TargetPos = new Vector3(40.69f, -18.8f, 93.51f);
			return;
		}
		int num = 0;
		int num2 = Random.Range(0, dict_GvGGroup.Count - 1);
		List<Transform> units = new List<Transform>();
		foreach (KeyValuePair<string, GvGGroup> item in dict_GvGGroup)
		{
			GvGGroup value = item.Value;
			if (!value.IsBoss)
			{
				if (num == num2 && value.AllUnitsTransform != null)
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
		float x = ((Component)ParentGroup).transform.position.x;
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
		zero.x = (0f - zero.x) * (float)ParentGroup.RoleFace;
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
