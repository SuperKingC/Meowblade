using UnityEngine;

namespace Shift.Legion.GvG.Common.Model;

public class GvG3Rect
{
	public float minX;

	public float maxX;

	public float minZ;

	public float maxZ;

	public GvG3Rect MoveTo(Vector3 v)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		return new GvG3Rect
		{
			minX = minX + v.x,
			maxX = maxX + v.x,
			minZ = minZ + v.z,
			maxZ = maxZ + v.z
		};
	}
}
