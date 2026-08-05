using System.Collections.Generic;
using Shift.Legion.GvG.Common.Model;
using UnityEngine;

public class tShipAttr
{
	public int UserId;

	public int ShipLevel;

	public int GuildId;

	public eGvGRole Role;

	public int Channel;

	private Vector3 ShipBornPoint = Vector3.zero;

	public Dictionary<string, GvGSingleBattleSoldierSummary> SoldierSummary;

	public GvGShip ShipInstance;

	public Vector3 GetShipBornPoint()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (!((Vector3)(ref ShipBornPoint)).Equals(Vector3.zero))
		{
			ShipBornPoint = new Vector3(-11f, 0f, (float)(4 - Channel));
		}
		return ShipBornPoint;
	}
}
