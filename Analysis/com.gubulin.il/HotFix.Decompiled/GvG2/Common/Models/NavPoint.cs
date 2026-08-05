using UnityEngine;

namespace GvG2.Common.Models;

public class NavPoint
{
	public int Id { get; set; }

	public float X { get; set; }

	public float Z { get; set; }

	public Vector3 Vec => new Vector3(X, 0f, Z);
}
