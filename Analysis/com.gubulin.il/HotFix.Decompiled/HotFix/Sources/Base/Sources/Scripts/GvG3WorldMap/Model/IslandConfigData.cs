using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class IslandConfigData
{
	public IslandProps Props;

	public Rect ViewRect;

	public Vector3 Position;

	public Vector3 ColliderScale;

	public Vector3 PlaneScale;

	public Quaternion PlaneRotation;

	public Vector3 CampAreaScale;

	public Vector3 FogAreaScale;

	public string Name;

	public Dictionary<int, List<Vec3>> CampSlotPos;

	public Vec2 Pos2D;

	public int CampMaxShipCount => Props.GDEData.CampMaxShipCount;

	public bool IsHiddenIsland => Props.GDEData.DiscoveryLevel > 0;
}
