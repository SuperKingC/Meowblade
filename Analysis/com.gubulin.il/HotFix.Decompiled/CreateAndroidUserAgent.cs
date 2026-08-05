using System;
using UnityEngine;

public class CreateAndroidUserAgent : MonoBehaviour
{
	public static CreateAndroidUserAgent Instance;

	private AndroidJavaClass EmptyActivityClass = null;

	private void Awake()
	{
		Instance = this;
		EmptyActivityClass = null;
	}

	public void Start()
	{
		createEmptyActivity();
	}

	private void createEmptyActivity()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		if ((int)Application.platform == 11)
		{
			try
			{
				EmptyActivityClass = new AndroidJavaClass("com.gubulin.il.tapsdk.EmptyActivity");
			}
			catch (Exception)
			{
				EmptyActivityClass = null;
				return;
			}
			if (EmptyActivityClass != null)
			{
				AndroidJavaClass val = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject val2 = ((AndroidJavaObject)val).GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaObject val3 = new AndroidJavaObject("android.content.Intent", Array.Empty<object>());
				val3.Call<AndroidJavaObject>("setClassName", new object[2] { "com.gubulin.il", "com.gubulin.il.tapsdk.EmptyActivity" });
				val2.Call("startActivity", new object[1] { val3 });
			}
		}
	}

	public string GetUA()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform != 11 || EmptyActivityClass == null)
		{
			return string.Empty;
		}
		AndroidJavaObject val = ((AndroidJavaObject)EmptyActivityClass).CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		return val.Call<string>("getUserAgent", Array.Empty<object>());
	}
}
