using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.GvG.Scripts;

public class GvG2GroupSoldiers
{
	public class SameTypeSoldiers
	{
		public int MaxCount_logical = 0;

		public int MaxCount_visible = 0;

		public Material DeadAniMat = null;

		public float AnimLen = 0f;

		public List<Soldier> Soldiers = null;
	}

	public class Soldier
	{
		public float DieTimeStamp;

		public MeshRenderer MR;

		public GameObject GO;
	}

	public Dictionary<string, SameTypeSoldiers> SoldierPosIdMap;

	public List<Soldier> SoldiersWaitToDestroy;

	public Coroutine DestroyCheckerHandle;

	public GvG2Group ParentGroup;

	public GvG2GroupSoldiers(GvG2Group parent)
	{
		ParentGroup = parent;
		SoldiersWaitToDestroy = new List<Soldier>();
		SoldierPosIdMap = new Dictionary<string, SameTypeSoldiers>();
	}

	public void OnDestroy()
	{
		if (DestroyCheckerHandle != null)
		{
			((MonoBehaviour)ParentGroup).StopCoroutine(DestroyCheckerHandle);
		}
		foreach (Soldier item in SoldiersWaitToDestroy)
		{
			Object.Destroy((Object)(object)item.GO);
		}
		foreach (KeyValuePair<string, SameTypeSoldiers> item2 in SoldierPosIdMap)
		{
			Addressables.Release<Material>(item2.Value.DeadAniMat);
		}
	}

	public void AddPosId(string posId, int SoldierMaxCount, string animMapPrefix)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		string text = animMapPrefix + "dead.mat";
		Material val = Addressables.LoadAssetAsync<Material>((object)text).WaitForCompletion();
		SameTypeSoldiers value = new SameTypeSoldiers
		{
			MaxCount_logical = SoldierMaxCount,
			Soldiers = new List<Soldier>(),
			DeadAniMat = val,
			AnimLen = val.GetFloat("_AnimLen")
		};
		SoldierPosIdMap.Add(posId, value);
	}

	public void InitSoldierPosIdMap(List<Transform> allUnitsTransform)
	{
		foreach (KeyValuePair<string, SameTypeSoldiers> item in SoldierPosIdMap)
		{
			string key = item.Key;
			SameTypeSoldiers value = item.Value;
			foreach (Transform item2 in allUnitsTransform)
			{
				Transform val = item2.Find("units/Unit" + key);
				for (int i = 0; i < val.childCount; i++)
				{
					Transform child = val.GetChild(i);
					value.Soldiers.Add(new Soldier
					{
						MR = ((Component)child).GetComponent<MeshRenderer>(),
						GO = ((Component)child).gameObject
					});
				}
			}
			value.MaxCount_visible = value.Soldiers.Count;
			ShuffleSoldierList(value.Soldiers);
		}
	}

	public void ChangePosIdSoldierCount(string posId, int count)
	{
		if (!SoldierPosIdMap.TryGetValue(posId, out var value))
		{
			return;
		}
		float dieTimeStamp = Time.time + value.AnimLen;
		float num = 1f - (float)count / (float)value.MaxCount_logical;
		int num2 = Mathf.CeilToInt((float)value.MaxCount_visible * num);
		for (int i = 0; i < num2; i++)
		{
			Soldier soldier = value.Soldiers[i];
			if (soldier != null)
			{
				value.Soldiers[i] = null;
				((Renderer)soldier.MR).material = value.DeadAniMat;
				soldier.DieTimeStamp = dieTimeStamp;
				SoldiersWaitToDestroy.Add(soldier);
			}
		}
	}

	public void StartCheckDeath()
	{
		if (DestroyCheckerHandle != null)
		{
			((MonoBehaviour)ParentGroup).StopCoroutine(DestroyCheckerHandle);
		}
		DestroyCheckerHandle = ((MonoBehaviour)ParentGroup).StartCoroutine(CheckDeathCoroutine());
	}

	private IEnumerator CheckDeathCoroutine()
	{
		while (SoldiersWaitToDestroy.Count > 0)
		{
			int i = SoldiersWaitToDestroy.Count - 1;
			while (i >= 0)
			{
				Soldier waitToDestroy = SoldiersWaitToDestroy[i];
				if (Time.time > waitToDestroy.DieTimeStamp)
				{
					SoldiersWaitToDestroy.RemoveAt(i);
					waitToDestroy.GO.SetActive(false);
					Object.Destroy((Object)(object)waitToDestroy.GO);
				}
				int num = i - 1;
				i = num;
			}
			yield return null;
		}
		DestroyCheckerHandle = null;
	}

	private void ShuffleSoldierList(List<Soldier> soldiers)
	{
		for (int i = 0; i < soldiers.Count; i++)
		{
			Soldier value = soldiers[i];
			int index = Random.Range(i, soldiers.Count);
			soldiers[i] = soldiers[index];
			soldiers[index] = value;
		}
	}
}
