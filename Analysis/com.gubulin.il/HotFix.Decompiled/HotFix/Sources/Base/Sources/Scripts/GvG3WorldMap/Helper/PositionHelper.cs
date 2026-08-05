using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;

public static class PositionHelper
{
	public static Vec2 GetScreenToFloorPos(Vector2 screenPos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Ray val = Camera.main.ScreenPointToRay(Vector2.op_Implicit(screenPos));
		Vector3 direction = ((Ray)(ref val)).direction;
		Vector3 normalized = ((Vector3)(ref direction)).normalized;
		Vector3 val2 = normalized * (((Ray)(ref val)).origin.y / Mathf.Abs(normalized.y)) + ((Ray)(ref val)).origin;
		return new Vec2(val2.x, val2.z / 1.414f);
	}

	public static float ManhattanDistance(Vec2 a, Vec2 b)
	{
		return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
	}
}
