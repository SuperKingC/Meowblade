using UnityEngine;

namespace Assets.QuadTree;

public static class Rect_Extension
{
	public static bool Contains(this Rect rect, Rect target)
	{
		return ((Rect)(ref rect)).xMin <= ((Rect)(ref target)).xMin && ((Rect)(ref rect)).xMax >= ((Rect)(ref target)).xMax && ((Rect)(ref rect)).yMin <= ((Rect)(ref target)).yMin && ((Rect)(ref rect)).yMax >= ((Rect)(ref target)).yMax;
	}
}
