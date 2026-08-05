using System;
using GameMaths;
using UnityEngine;

public class GvGProjectile : MonoBehaviour
{
	private const float FrameDuration = 1f / 60f;

	public float ProjectileRatio;

	public bool UseMoveTime;

	public float MoveSpeed;

	public float MoveTime;

	public Vector3 TargetPos;

	public Vector3 StartPos;

	public int MoveType;

	public bool isChildrenRotationFixed = false;

	private float tm;

	private float total_fly_tm;

	public Action OnHit;

	private void Awake()
	{
		((Behaviour)this).enabled = false;
	}

	public void StartMove(Action onHit = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		OnHit = onHit;
		((Component)this).transform.position = StartPos;
		tm = 0f;
		total_fly_tm = Time.fixedDeltaTime;
		switch (MoveType)
		{
		case 0:
			BlinkMove();
			break;
		case 1:
			LinearMove();
			break;
		case 2:
			ParabolaMove();
			break;
		}
		((Behaviour)this).enabled = true;
	}

	private void Update()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		tm += Time.deltaTime;
		total_fly_tm += Time.deltaTime;
		if (tm < 1f / 60f)
		{
			return;
		}
		tm -= 1f / 60f;
		switch (MoveType)
		{
		case 0:
			BlinkMove();
			break;
		case 1:
			LinearMove();
			break;
		case 2:
			ParabolaMove();
			break;
		}
		Vector3 val = ((Component)this).transform.position - TargetPos;
		if (isChildrenRotationFixed)
		{
			for (int i = 0; i < ((Component)this).transform.childCount; i++)
			{
				if (val.x > 0f)
				{
					((Component)this).transform.GetChild(i).rotation = Quaternion.op_Implicit(RotationHelper.Right);
				}
				else
				{
					((Component)this).transform.GetChild(i).rotation = Quaternion.op_Implicit(RotationHelper.FlipLeft);
				}
			}
		}
		if (((Vector3)(ref val)).sqrMagnitude < 0.01f)
		{
			((Behaviour)this).enabled = false;
			((Component)this).gameObject.SetActive(false);
			OnHit?.Invoke();
		}
	}

	private void BlinkMove()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.position = TargetPos;
	}

	private void LinearMove()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3.MoveTowards(((Component)this).transform.position, TargetPos, MoveSpeed * Time.fixedDeltaTime);
		Vector3 val2 = TargetPos - val;
		((Component)this).transform.position = val;
		if (((Vector3)(ref val2)).sqrMagnitude > 0.001f)
		{
			((Component)this).transform.rotation = Quaternion.LookRotation(val2, Vector3.up);
		}
	}

	private void ParabolaMove()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		float num = (UseMoveTime ? MoveTime : (VectorHelper.Distance2(Vector3.op_Implicit(StartPos), Vector3.op_Implicit(TargetPos)) / MoveSpeed));
		Vector3 val = CalcParabolaPosition(StartPos, TargetPos, ProjectileRatio, total_fly_tm / num);
		Vector3 val2 = val - ((Component)this).transform.position;
		((Component)this).transform.position = val;
		if (((Vector3)(ref val2)).sqrMagnitude > float.Epsilon)
		{
			((Component)this).transform.rotation = Quaternion.LookRotation(val2, Vector3.up);
		}
	}

	private static Vector3 CalcParabolaPosition(Vector3 startPos, Vector3 endPos, float ratio, float t)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		t = Mathf.Max(0f, Mathf.Min(1f, t));
		Vector2 val = VectorHelper.ToVector2(Vector3.op_Implicit(endPos)) - VectorHelper.ToVector2(Vector3.op_Implicit(startPos));
		float magnitude = ((Vector2)(ref val)).magnitude;
		float num = endPos.y - startPos.y;
		float num2 = magnitude * ratio;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = magnitude / 2f;
		float num6 = num2;
		float num7 = magnitude;
		float num8 = 0f;
		float num9 = ((num8 - num4) * (num3 + num5) - (num3 + num7) * (num6 - num4)) / ((num7 * num7 - num3 * num3) * (num3 + num5) + (num3 * num3 - num5 * num5) * (num3 + num7));
		float num10 = (num6 - num4 + num9 * (num3 * num3 - num5 * num5)) / (num3 + num5);
		float num11 = num4 - num9 * num3 * num3 - num10 * num3;
		float num12 = magnitude * t;
		float num13 = num9 * num12 * num12 + num10 * num12 + num11;
		Vector2 val2 = ((Vector2)(ref val)).normalized * num12;
		return startPos + new Vector3(val2.x, num13 + num * t, val2.y);
	}
}
