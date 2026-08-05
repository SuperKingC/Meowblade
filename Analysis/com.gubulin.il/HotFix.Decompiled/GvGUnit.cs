using GameDataEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GvGUnit
{
	public GameObject GO;

	public static int AttackSfxCount;

	private GvGGroup ParentGroup;

	private bool HasFightingTarget;

	private Vector3 MovingStart;

	private Vector3 MovingDelta;

	public float MovingDist;

	public Vector3 StartPos;

	public Vector3 MarchingPos;

	public Vector3 MarchingDelta;

	public Vector3 PreFightingPos;

	public Vector3 PreFightingGlobalPos;

	public Vector3 PreFightingDelta;

	public float TotalPreFightingMoveTime;

	public Vector3 FightingPos;

	public Vector3 FightingDelta;

	public float TotalFightingMoveTime;

	private GameObject AttackSfx;

	public GvGUnit(GameObject go, int index, GvGGroup parentGroup)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		GO = go;
		ParentGroup = parentGroup;
		if (!ParentGroup.IsBoss)
		{
			Transform groupCollider = ParentGroup.GroupCollider;
			int num = 15;
			int num2 = 5;
			Transform val = groupCollider.Find($"target{index}");
			if ((Object)(object)val != (Object)null)
			{
				MarchingPos = val.localPosition;
			}
			else
			{
				MarchingPos = ParentGroup.MatrixUnits[index - (num - num2)].MarchingPos + new Vector3(-2f, 0f, 0f);
			}
			Vector3 localPosition = ParentGroup.Target0Trasnform.localPosition;
			Vector3 val2 = MarchingPos - localPosition;
			val2.x *= Random.Range(0.95f, 1.35f);
			val2.z *= Random.Range(0.6f, 0.9f);
			StartPos = GO.transform.localPosition;
			MarchingPos = val2 + localPosition;
			MarchingDelta = MarchingPos - StartPos;
			Transform val3 = groupCollider.Find($"target{index % num}");
			PreFightingPos = new Vector3(val3.localPosition.x - Random.Range(0.1f, 2f), MarchingPos.y, MarchingPos.z);
			HasFightingTarget = false;
			if (AttackSfxCount < 50)
			{
				AttackSfxCount++;
				InitSfx();
			}
		}
	}

	internal void OnDestroy()
	{
		if ((Object)(object)AttackSfx != (Object)null)
		{
			AttackSfxCount--;
			Addressables.ReleaseInstance(AttackSfx);
		}
	}

	public void SetFightingTargetGroup(GvGGroup targetGroup)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (!HasFightingTarget)
		{
			HasFightingTarget = true;
			GvGUnit gvGUnit = ListExtensions.Random<GvGUnit>(targetGroup.MatrixUnits);
			MovingStart = GO.transform.position;
			MovingDelta = gvGUnit.GO.transform.position - MovingStart;
			MovingDist = ((Vector3)(ref MovingDelta)).magnitude;
		}
	}

	public void SetFightingPos(Vector3 targetPos)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (!HasFightingTarget)
		{
			HasFightingTarget = true;
			MovingStart = GO.transform.position;
			MovingDelta = targetPos - MovingStart;
			MovingDist = ((Vector3)(ref MovingDelta)).magnitude;
		}
	}

	public bool Move(float curMovingTime, float speed, bool isImmediate)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		float num = MovingDist / (speed + Mathf.Epsilon);
		float num2 = (isImmediate ? 1f : (curMovingTime / num));
		bool result = false;
		if (num2 >= 1f)
		{
			num2 = 1f;
			result = true;
		}
		GO.transform.position = MovingStart + MovingDelta * num2;
		return result;
	}

	public void InitSfx()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		AttackSfx = Addressables.InstantiateAsync((object)"FX/Prefabs/skill_gvg_battling", GO.transform, false, true).WaitForCompletion();
		((Object)AttackSfx).name = "AttackSfx";
		AttackSfx.transform.localPosition = Vector3.zero;
		AttackSfx.SetActive(false);
	}

	public void PlaySfx()
	{
		if ((Object)(object)AttackSfx != (Object)null)
		{
			AttackSfx.SetActive(true);
		}
	}

	public void StopSfx()
	{
		if ((Object)(object)AttackSfx != (Object)null)
		{
			AttackSfx.SetActive(false);
		}
	}

	public Vector3 GetFightingPos()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return GO.transform.position;
	}
}
