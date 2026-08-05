using UnityEngine;

namespace Shift.Legion.GvG.Common.Model;

public class GvGRect
{
	public float minX;

	public float maxX;

	public float minZ;

	public float maxZ;

	public GvGRect MoveTo(Vector3 v)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		return new GvGRect
		{
			minX = minX + v.x,
			maxX = maxX + v.x,
			minZ = minZ + v.z,
			maxZ = maxZ + v.z
		};
	}
}
