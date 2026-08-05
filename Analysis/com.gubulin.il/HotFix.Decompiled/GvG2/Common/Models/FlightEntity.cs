using UnityEngine;

namespace GvG2.Common.Models;

public class FlightEntity
{
	public int Id;

	public int StartTime;

	public int EndTime;

	public float TotalTime;

	public float TotalDist;

	private NavLineProps[] Lines;

	private float[] PointsPercent;

	public Ship Ship;

	private int listI = 0;

	private float startPer;

	private Vector3 marchingVec;

	private Vector3 lastNodeStart;

	public FlightEntity(int id, int startTime, int endTime, NavLineProps[] lineRoute, Ship ship)
	{
		Ship = ship;
		Id = id;
		Lines = lineRoute;
		StartTime = startTime;
		EndTime = endTime;
		TotalTime = EndTime - StartTime;
		TotalDist = 0f;
		PointsPercent = new float[Lines.Length + 1];
		for (int i = 0; i < Lines.Length; i++)
		{
			PointsPercent[i] = TotalDist;
			TotalDist += Lines[i].Len;
		}
		for (int j = 0; j < PointsPercent.Length - 1; j++)
		{
			PointsPercent[j] /= TotalDist;
		}
		PointsPercent[PointsPercent.Length - 1] = 1f;
	}

	private void OnReachTarget()
	{
	}

	public bool UpdateFlightPos(int curTime, float deltaInSecond)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		float num = ((float)(curTime - StartTime) + deltaInSecond) / TotalTime;
		if (num < 0f)
		{
			return false;
		}
		if (num > PointsPercent[listI])
		{
			if (num >= 1f)
			{
				NavLineProps navLineProps = Lines[Lines.Length - 1];
				Ship.ShipTrans.localPosition = navLineProps.Dir + navLineProps.Start;
				OnReachTarget();
				return true;
			}
			int i;
			for (i = listI; i < PointsPercent.Length && !(num <= PointsPercent[i]); i++)
			{
			}
			listI = i;
			NavLineProps navLineProps2 = Lines[i - 1];
			float num2 = PointsPercent[i];
			startPer = PointsPercent[i - 1];
			marchingVec = navLineProps2.Dir / (num2 - startPer);
			lastNodeStart = navLineProps2.Start;
			Ship.OnChangeDirection(navLineProps2.Dir);
		}
		Ship.ShipTrans.localPosition = (num - startPer) * marchingVec + lastNodeStart;
		return false;
	}
}
