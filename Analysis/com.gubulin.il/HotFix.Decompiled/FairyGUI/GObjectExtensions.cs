using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace FairyGUI;

public static class GObjectExtensions
{
	public static void SetXY_WithinBounds(this GObject window, Vector2 pos)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		window.SetXY_WithinBounds(pos, Rect.MinMaxRect(0f, 0f, ((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height));
	}

	public static void SetXY_WithinBounds(this GObject window, Vec2 pos)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		window.SetXY_WithinBounds(new Vector2(pos.x, pos.y), Rect.MinMaxRect(0f, 0f, ((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height));
	}

	public static void SetXY_WithinBounds(this GObject window, Vec2 pos, Rect bounds)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		window.SetXY_WithinBounds(new Vector2(pos.x, pos.y), bounds);
	}

	public static void SetXY_WithinBounds(this GObject window, Vector2 pos, Rect bounds)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		float width = window.width;
		float height = window.height;
		Vector2 val = (window.pivotAsAnchor ? window.pivot : (Vector2.one / 2f));
		float num = RepositionWhenOutOfBounds(pos.x, val.x, width, ((Rect)(ref bounds)).xMin, ((Rect)(ref bounds)).xMax);
		float num2 = RepositionWhenOutOfBounds(pos.y, val.y, height, ((Rect)(ref bounds)).yMin, ((Rect)(ref bounds)).yMax);
		window.SetXY(num, num2);
	}

	private static float RepositionWhenOutOfBounds(float pos, float pivot, float width, float min, float max)
	{
		float num = width * (1f - pivot);
		if (max < pos + num)
		{
			return max - num;
		}
		float num2 = width * pivot;
		if (pos - num2 < min)
		{
			return min + num2;
		}
		return pos;
	}

	public static Tween TweenToTarget(this GObject item, GObject target, Vector2 offset, float duration)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		float time = 0f;
		return (Tween)(object)DOTween.To((DOGetter<float>)(() => time), (DOSetter<float>)delegate(float x)
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			if (!item.isDisposed && !target.isDisposed)
			{
				Vector3 val = Vector2.op_Implicit(((GObject)item.parent).GlobalToLocal(target.LocalToGlobal(Vector2.zero)) + offset);
				Vector3 position = item.position;
				float num = duration - x;
				if (num <= 0f)
				{
					item.position = val;
				}
				else
				{
					float num2 = (x - time) / num;
					num2 = Mathf.Min(1f, num2);
					Vector3 position2 = (val - position) * num2 + position;
					item.position = position2;
				}
				time = x;
			}
		}, duration, duration);
	}
}
