public class Vec3
{
	public float x;

	public float y;

	public float z;

	public Vec3()
	{
	}

	public Vec3(float _x, float _y, float _z)
	{
		x = _x;
		y = _y;
		z = _z;
	}

	public bool Equal(Vec3 v3)
	{
		return v3.x == x && v3.y == y && v3.z == z;
	}
}
