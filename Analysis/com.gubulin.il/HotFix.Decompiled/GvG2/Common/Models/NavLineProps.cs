using System.Collections.Generic;
using UnityEngine;

namespace GvG2.Common.Models;

public class NavLineProps
{
	public string Id;

	public List<NavPoint> Pts;

	public float Len;

	private bool IsInit = false;

	private Vector3 _Start;

	private Vector3 _Dir;

	public Vector3 Dir
	{
		get
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			if (!IsInit)
			{
				_Dir = Pts[Pts.Count - 1].Vec - Pts[0].Vec;
				_Start = Pts[0].Vec;
				IsInit = true;
			}
			return _Dir;
		}
	}

	public Vector3 Start
	{
		get
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			if (!IsInit)
			{
				_Dir = Pts[Pts.Count - 1].Vec - Pts[0].Vec;
				_Start = Pts[0].Vec;
				IsInit = true;
			}
			return _Start;
		}
	}
}
