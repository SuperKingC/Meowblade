using System;
using System.Collections.Generic;
using DG.Tweening;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI;

public class HitArea : MonoBehaviour
{
	[Serializable]
	public class HitData
	{
		public string name;

		public string id;

		public GameObject background;

		public GameObject mask;

		public GameObject decoration;

		public GameObject builders;

		public Transform[] points;

		public GameObject conveyor;
	}

	private HitData _hitData;

	public float repairBuildTime;

	public float repairBuildTimeTemp;

	public bool isStartRepair;

	public bool haveSmoke;

	public List<GameObject> smokes = new List<GameObject>();

	public HitData hitData
	{
		get
		{
			if (_hitData == null)
			{
				_hitData = new HitData();
			}
			return _hitData;
		}
		set
		{
			_hitData = value;
		}
	}

	public void RepairBuild(int num, int time)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		isStartRepair = true;
		haveSmoke = false;
		hitData.builders.SetActive(true);
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				hitData.builders.transform.GetChild(i).position = hitData.points[i].position;
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
				int index = i;
				if (i == 0)
				{
					((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
					GameObject val = SpawnManager.Instance.InstantiatePool("Smoke96comb", Vector3.zero);
					if ((Object)(object)val != (Object)null)
					{
						val.GetComponent<Renderer>().sortingLayerName = "UI";
						for (int j = 0; j < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; j++)
						{
							((Component)val.transform).GetComponentsInChildren<Renderer>()[j].sortingLayerName = "UI";
						}
						val.transform.position = hitData.points[i].position;
						val.transform.eulerAngles = hitData.points[i].eulerAngles;
						smokes.Add(val);
					}
				}
				else
				{
					float duration = Random.Range(0.1f, 0.5f);
					ScriptApi.CreateTimer(duration, delegate
					{
						//IL_0067: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
						//IL_010e: Unknown result type (might be due to invalid IL or missing references)
						((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
						((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
						GameObject val2 = SpawnManager.Instance.InstantiatePool("Smoke96comb", Vector3.zero);
						if ((Object)(object)val2 != (Object)null)
						{
							val2.GetComponent<Renderer>().sortingLayerName = "Default";
							for (int k = 0; k < ((Component)val2.transform).GetComponentsInChildren<Renderer>().Length; k++)
							{
								((Component)val2.transform).GetComponentsInChildren<Renderer>()[k].sortingLayerName = "Default";
							}
							val2.transform.position = hitData.points[index].position;
							val2.transform.eulerAngles = hitData.points[index].eulerAngles;
							smokes.Add(val2);
						}
					});
				}
			}
			else
			{
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
			hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(hitData.builders.transform.GetChild(i).localEulerAngles.x, 0f, hitData.builders.transform.GetChild(i).localEulerAngles.z);
			if ((i + 1) % 2 != 0)
			{
				((SkeletonRenderer)((Component)hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
			}
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	private void GetWorkerSmoke(Transform transform)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = SpawnManager.Instance.InstantiatePool("Smoke96comb", Vector3.zero);
		if ((Object)(object)val != (Object)null)
		{
			val.GetComponent<Renderer>().sortingLayerName = "UI";
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = "UI";
			}
			val.transform.position = transform.position;
			val.transform.eulerAngles = transform.eulerAngles;
			smokes.Add(val);
		}
	}

	private void CampLevelUp5To6(int num, int time)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		isStartRepair = true;
		haveSmoke = false;
		hitData.builders.SetActive(true);
		Vector3 aimPos = ((Component)((Component)this).gameObject.GetComponent<CampController>()).transform.position + new Vector3(0f, -0.5f, 0f);
		for (int i = 0; i < 5; i++)
		{
			Transform child = hitData.builders.transform.GetChild(i);
			if (i < num)
			{
				GameObject builder = ((Component)child).gameObject;
				builder.SetActive(false);
				builder.transform.position = SetCollectionBuilderPos(num, i, aimPos, 1f, out var orientation, 1f);
				builder.transform.eulerAngles = new Vector3(builder.transform.eulerAngles.x, 0f, builder.transform.eulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)builder.GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				if (i == 0)
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
					GetWorkerSmoke(builder.transform);
					continue;
				}
				float duration = Random.Range(0.1f, 0.5f);
				ScriptApi.CreateTimer(duration, delegate
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
					GetWorkerSmoke(builder.transform);
				});
			}
			else
			{
				((Component)child).gameObject.SetActive(false);
			}
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	public Vector3 SetCollectionBuilderPos(int totalNum, int index, Vector3 aimPos, float spacingY, out float orientation, float xOffSet = 0f)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = ((Component)hitData.builders.transform.GetChild(0)).gameObject;
		float num = ((SkeletonRenderer)gameObject.GetComponent<SkeletonAnimation>()).SkeletonDataAsset.GetSkeletonData(true).Width / 100f * gameObject.transform.lossyScale.x + xOffSet;
		float num2 = ((SkeletonRenderer)gameObject.GetComponent<SkeletonAnimation>()).SkeletonDataAsset.GetSkeletonData(true).Height / 100f * gameObject.transform.lossyScale.y;
		switch (totalNum)
		{
		case 1:
			orientation = 0f;
			return new Vector3(aimPos.x, aimPos.y, aimPos.z - 0.2f);
		case 2:
			switch (index)
			{
			case 0:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y, aimPos.z - 0.2f);
			case 1:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y, aimPos.z - 0.3f);
			}
			break;
		case 3:
			switch (index)
			{
			case 0:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y + num2 / 4f * spacingY, aimPos.z - 0.2f);
			case 1:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y, aimPos.z - 0.3f);
			case 2:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y - num2 / 4f * spacingY, aimPos.z - 0.4f);
			}
			break;
		case 4:
			switch (index)
			{
			case 0:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y + num2 / 4f * spacingY, aimPos.z - 0.2f);
			case 1:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y + num2 / 4f * spacingY, aimPos.z - 0.3f);
			case 2:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y - num2 / 4f * spacingY, aimPos.z - 0.4f);
			case 3:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y - num2 / 4f * spacingY, aimPos.z - 0.5f);
			}
			break;
		case 5:
			switch (index)
			{
			case 0:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y + num2 / 2f * spacingY, aimPos.z - 0.2f);
			case 1:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y + num2 / 4f * spacingY, aimPos.z - 0.3f);
			case 2:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y, aimPos.z - 0.4f);
			case 3:
				orientation = 180f;
				return new Vector3(aimPos.x - num, aimPos.y - num2 / 4f * spacingY, aimPos.z - 0.5f);
			case 4:
				orientation = 0f;
				return new Vector3(aimPos.x + num, aimPos.y - num2 / 2f * spacingY, aimPos.z - 0.6f);
			}
			break;
		}
		orientation = 0f;
		return Vector3.one;
	}

	public void RepairCollection(int num, int time)
	{
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		isStartRepair = true;
		haveSmoke = false;
		hitData.builders.SetActive(true);
		float orientation = 0f;
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				hitData.builders.transform.GetChild(i).position = SetCollectionBuilderPos(num, i, hitData.points[0].position, 1f, out orientation);
				hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(hitData.builders.transform.GetChild(i).localEulerAngles.x, 0f, hitData.builders.transform.GetChild(i).localEulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)((Component)hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
				int index = i;
				if (i == 0)
				{
					((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
					continue;
				}
				ScriptApi.CreateTimer(Random.Range(0.1f, 0.5f), delegate
				{
					((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
				});
			}
			else
			{
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
		}
		GameObject val = SpawnManager.Instance.InstantiatePool("Smoke95comb", Vector3.zero);
		if ((Object)(object)val != (Object)null)
		{
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int num2 = 0; num2 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num2++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[num2].sortingLayerName = "Default";
			}
			MainModule main = val.GetComponent<ParticleSystem>().main;
			((MainModule)(ref main)).loop = true;
			val.transform.position = hitData.points[0].position + new Vector3(0f, 0.5f, 0f);
			val.transform.eulerAngles = hitData.points[0].eulerAngles;
			smokes.Add(val);
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	public void UnlockSlotCollection(global::WorkShop workShop, int num, int time)
	{
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		if (workShop.Slot < workShop.SomeLevelSlot(1))
		{
			return;
		}
		haveSmoke = false;
		isStartRepair = true;
		float orientation = 0f;
		hitData.builders.SetActive(true);
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				hitData.builders.transform.GetChild(i).position = SetCollectionBuilderPos(num, i, hitData.points[0].position, 1f, out orientation);
				hitData.builders.transform.GetChild(i).localEulerAngles = new Vector3(hitData.builders.transform.GetChild(i).localEulerAngles.x, 0f, hitData.builders.transform.GetChild(i).localEulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)((Component)hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				int index = i;
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
				if (i == 0)
				{
					((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
					continue;
				}
				ScriptApi.CreateTimer(Random.Range(0.1f, 0.5f), delegate
				{
					((Component)hitData.builders.transform.GetChild(index)).GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					((Component)hitData.builders.transform.GetChild(index)).gameObject.SetActive(true);
				});
			}
			else
			{
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
		}
		GameObject val = SpawnManager.Instance.InstantiatePool("Smoke95comb", Vector3.zero);
		if ((Object)(object)val != (Object)null)
		{
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int num2 = 0; num2 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num2++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[num2].sortingLayerName = "Default";
			}
			val.transform.position = hitData.points[0].position + new Vector3(0f, 0.5f, 0f);
			MainModule main = val.GetComponent<ParticleSystem>().main;
			((MainModule)(ref main)).loop = true;
			val.transform.eulerAngles = ((Component)hitData.builders.transform.GetChild(0)).transform.eulerAngles;
			smokes.Add(val);
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	public void UnlockSlot(global::WorkShop workShop, int num, int time)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		if (workShop.Slot < workShop.SomeLevelSlot(1))
		{
			return;
		}
		haveSmoke = false;
		isStartRepair = true;
		hitData.builders.SetActive(true);
		Vector3 aimPos;
		float spacingY;
		if (workShop.SomeLevelSlot(workShop.NextLevel) > 8)
		{
			Vector3 position = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[7].transform.position;
			Vector3 position2 = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[11].transform.position;
			aimPos = position - (position - position2) / 2f + new Vector3(0f, -0.5f, 0f);
			spacingY = 2f;
		}
		else
		{
			Vector3 position3 = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[workShop.SomeLevelSlot(workShop.NextLevel) - 1].transform.position;
			Vector3 position4 = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[workShop.SomeLevelSlot(workShop.NextLevel) - 2].transform.position;
			aimPos = position3 - (position3 - position4) / 2f;
			spacingY = 1f;
		}
		for (int i = 0; i < 5; i++)
		{
			((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			GameObject builder = ((Component)hitData.builders.transform.GetChild(i)).gameObject;
			if (i < num)
			{
				builder.transform.position = SetCollectionBuilderPos(num, i, aimPos, spacingY, out var orientation);
				builder.transform.eulerAngles = new Vector3(builder.transform.eulerAngles.x, 0f, builder.transform.eulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)builder.GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				int num2 = i;
				if (i == 0)
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
					continue;
				}
				float duration = Random.Range(0.1f, 0.5f);
				ScriptApi.CreateTimer(duration, delegate
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
				});
			}
			else
			{
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
		}
		float num3 = GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).GetUpgradeTime(num);
		float num4 = (num3 - (float)time) / num3 * 0.4f;
		for (int num5 = workShop.Slot; num5 < workShop.SomeLevelSlot(workShop.NextLevel); num5++)
		{
			GameObject val = SpawnManager.Instance.InstantiatePool("Smoke95comb", Vector3.zero);
			if ((Object)(object)val != (Object)null)
			{
				val.GetComponent<Renderer>().sortingLayerName = "Default";
				for (int num6 = 0; num6 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num6++)
				{
					((Component)val.transform).GetComponentsInChildren<Renderer>()[num6].sortingLayerName = "Default";
				}
				val.transform.eulerAngles = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform.eulerAngles;
				val.transform.SetParent(((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform);
				val.transform.localPosition = new Vector3(0f, 0f, -1f);
				smokes.Add(val);
			}
			((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform.Find("Progress").localScale = new Vector3(num4, 0.25f, 0.25f);
			((Component)((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform.Find("Progress")).gameObject.SetActive(true);
			ShortcutExtensions.DOScaleX(((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform.Find("Progress"), 0.4f, (float)time);
			((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num5].transform.Find("Progress").SetAsLastSibling();
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	public void UnlockCampSlot(Camp camp, int num, int time)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		if (camp.Slot < camp.SomeLevelSlot(1))
		{
			return;
		}
		if (camp.NextLevel == 6)
		{
			CampLevelUp5To6(num, time);
			return;
		}
		int slotIndex = camp.SomeLevelSlot(camp.NextLevel) - 1;
		isStartRepair = true;
		haveSmoke = false;
		hitData.builders.SetActive(true);
		Vector3 aimPos = ((Component)this).gameObject.GetComponent<CampController>().GetSlotPosForLevelUp(slotIndex) + new Vector3(0f, -0.2f, 0f);
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				int num2 = i;
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
				GameObject builder = ((Component)hitData.builders.transform.GetChild(i)).gameObject;
				builder.transform.position = SetCollectionBuilderPos(num, i, aimPos, 1f, out var orientation);
				builder.transform.eulerAngles = new Vector3(builder.transform.eulerAngles.x, 0f, builder.transform.eulerAngles.z);
				if (orientation > 0f)
				{
					((SkeletonRenderer)builder.GetComponent<SkeletonAnimation>()).skeleton.FlipX = true;
				}
				if (i == 0)
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
					continue;
				}
				float duration = Random.Range(0.1f, 0.5f);
				ScriptApi.CreateTimer(duration, delegate
				{
					builder.GetComponent<SkeletonAnimation>().AnimationName = "work1_1";
					builder.SetActive(true);
				});
			}
			else
			{
				((Component)hitData.builders.transform.GetChild(i)).gameObject.SetActive(false);
			}
		}
		float num3 = GameManagers.Instance.BuildingManager.GetBuildingByType(hitData.id).GetUpgradeTime(num);
		float num4 = (num3 - (float)time) / num3 * 0.4f;
		for (int num5 = camp.Slot; num5 < camp.SomeLevelSlot(camp.NextLevel); num5++)
		{
			GameObject val = SpawnManager.Instance.InstantiatePool("Smoke95comb", Vector3.zero);
			GameObject slotGameObject = ((Component)this).gameObject.GetComponent<CampController>().GetSlotGameObject(num5);
			if ((Object)(object)val != (Object)null)
			{
				val.GetComponent<Renderer>().sortingLayerName = "Default";
				for (int num6 = 0; num6 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num6++)
				{
					((Component)val.transform).GetComponentsInChildren<Renderer>()[num6].sortingLayerName = "Default";
				}
				val.transform.position = ((Component)this).gameObject.GetComponent<CampController>().GetSlotPosForLevelUp(num5);
				val.transform.eulerAngles = slotGameObject.transform.eulerAngles;
				val.AddComponent<HotFix_DestroySelf>().destroyTime = (float)time + 0.1f;
			}
			GameObject val2 = ((num5 >= 5) ? ((Component)CampController.Instance.SlotControllers[num5 % 5]).gameObject : ((Component)this).gameObject.GetComponent<CampController>().GetSlotGameObject(num5, isOld: true));
			Transform val3 = val2.transform.Find("Progress");
			val3.localScale = new Vector3(num4, 0.25f, 0.25f);
			((Component)val3).gameObject.SetActive(true);
			ShortcutExtensions.DOScaleX(val3, 0.4f, (float)time);
			val3.SetAsLastSibling();
		}
		FGUIManager.Instance.BuildingUpgradeBarInitSet(hitData.id);
	}

	private void Awake()
	{
		if (smokes == null)
		{
			smokes = new List<GameObject>();
		}
	}

	private void Start()
	{
		isStartRepair = false;
		repairBuildTimeTemp = repairBuildTime;
		SkeletonAnimation[] componentsInChildren = ((Component)this).GetComponentsInChildren<SkeletonAnimation>();
		SkeletonAnimation[] array = componentsInChildren;
		foreach (SkeletonAnimation s in array)
		{
			GameController.Contexts.Service<BaseSceneService>().AddSkeletonAnimation(s);
		}
	}
}
