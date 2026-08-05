using GameMaths;

public class Quat
{
	public float x;

	public float y;

	public float z;

	public float w;

	public Quat()
	{
	}

	public Quat(float _x, float _y, float _z, float _w)
	{
		x = _x;
		y = _y;
		z = _z;
		w = _w;
	}

	public bool Equal(Quat q)
	{
		return x == q.x && y == q.y && z == q.z && w == q.w;
	}

	public bool Equal(Quaternion q)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		return x == q.X && y == q.Y && z == q.Z && w == q.W;
	}
}
