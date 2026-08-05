using System;
using UnityEngine;

public class NativeGalleryHelper
{
	public static void PickImage(Action<Texture2D> action)
	{
		HotFixManager.Instance.PickImage(action, -1, false, false, false);
	}

	public static Texture2D CropTexture(Texture2D texture2D, int NewSize)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		tKeyValue<int, int> tKeyValue2 = TryResizeToMax(((Texture)texture2D).width, ((Texture)texture2D).height, NewSize);
		Texture2D val = Resize(texture2D, tKeyValue2.Key, tKeyValue2.Value);
		int num = ((Texture)val).width / 2 - NewSize / 2;
		if (num < 0)
		{
			num = 0;
		}
		int num2 = ((Texture)val).height / 2 - NewSize / 2;
		if (num2 < 0)
		{
			num2 = 0;
		}
		int num3 = ((tKeyValue2.Key > NewSize) ? NewSize : tKeyValue2.Key);
		int num4 = ((tKeyValue2.Value > NewSize) ? NewSize : tKeyValue2.Value);
		Color[] pixels = val.GetPixels(num, num2, num3, num4);
		Texture2D val2 = new Texture2D(num3, num4);
		val2.SetPixels(pixels);
		val2.Apply();
		Object.Destroy((Object)(object)val);
		return val2;
	}

	private static Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		RenderTexture val = (RenderTexture.active = new RenderTexture(targetX, targetY, 24));
		Graphics.Blit((Texture)(object)texture2D, val);
		Texture2D val3 = new Texture2D(targetX, targetY);
		val3.ReadPixels(new Rect(0f, 0f, (float)targetX, (float)targetY), 0, 0);
		val3.Apply();
		Object.Destroy((Object)(object)val);
		return val3;
	}

	private static tKeyValue<int, int> TryResizeToMax(int width, int height, int max)
	{
		int num = 0;
		int num2 = 0;
		if (width > height)
		{
			if (height < max)
			{
				num = width;
				num2 = height;
			}
			else
			{
				num2 = max;
				num = (int)((float)width / (1f * (float)height / (float)max));
			}
		}
		else if (width < max)
		{
			num = width;
			num2 = height;
		}
		else
		{
			num = max;
			num2 = (int)((float)height / (1f * (float)width / (float)max));
		}
		return new tKeyValue<int, int>(num, num2);
	}
}
