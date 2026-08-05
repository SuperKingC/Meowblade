using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class SpriteExtensions
{
	private static GLoader IconLoader;

	private static readonly Vector2 CenterPivot = new Vector2(0.5f, 0.5f);

	public static void LoadFguiIcon(this SpriteRenderer spriteRenderer, string url, float pixelsPerUnit = -1f)
	{
		spriteRenderer.sprite = url.FguiIconToSprite(pixelsPerUnit);
	}

	public static Sprite FguiIconToSprite(this string url, float pixelsPerUnit = -1f)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		if (IconLoader == null)
		{
			IconLoader = new GLoader();
		}
		IconLoader.url = url;
		if (IconLoader.texture == null)
		{
			return null;
		}
		Rect uvRect = IconLoader.texture.uvRect;
		Texture2D val = (Texture2D)IconLoader.texture.nativeTexture;
		float num = ((Rect)(ref uvRect)).width * (float)((Texture)val).width;
		float num2 = ((Rect)(ref uvRect)).height * (float)((Texture)val).height;
		if (pixelsPerUnit == -1f)
		{
			pixelsPerUnit = ((num > num2) ? num : num2);
		}
		return Sprite.Create(val, new Rect(((Rect)(ref uvRect)).x * (float)((Texture)val).width, ((Rect)(ref uvRect)).y * (float)((Texture)val).height, num, num2), CenterPivot, pixelsPerUnit);
	}

	public static void LoadFguiIcon(this GameObject gameObject, string url, float pixelsPerUnit = -1f)
	{
		gameObject.GetComponent<SpriteRenderer>().LoadFguiIcon(url, pixelsPerUnit);
	}

	public static void LoadFguiIcon(this Transform trans, string url, float pixelsPerUnit = -1f)
	{
		((Component)trans).GetComponent<SpriteRenderer>().LoadFguiIcon(url, pixelsPerUnit);
	}
}
