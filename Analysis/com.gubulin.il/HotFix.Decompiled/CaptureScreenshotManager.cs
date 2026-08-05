using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScreenshotManager : MonoBehaviour
{
	public static CaptureScreenshotManager Instance;

	public static Text text;

	private static string _name = "";

	private void Awake()
	{
		Instance = this;
	}

	public string CaptureScreenshot()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		_name = "";
		_name = "Screenshot_" + GetCurTime() + ".png";
		string result = "";
		if ((int)Application.platform == 8)
		{
			((MonoBehaviour)this).StartCoroutine(CutImage(_name));
			result = Application.persistentDataPath + "/Screenshot/" + _name;
		}
		else if ((int)Application.platform == 11)
		{
			((MonoBehaviour)this).StartCoroutine(CutImage(_name));
			result = Application.persistentDataPath + "/Screenshot/" + _name;
		}
		return result;
	}

	private IEnumerator CutImage(string name)
	{
		FGUIManager.Instance.StageCamera.clearFlags = (CameraClearFlags)3;
		yield return (object)new WaitForEndOfFrame();
		FGUIManager.Instance.StageCamera.clearFlags = (CameraClearFlags)2;
		Texture2D tex = new Texture2D(Screen.width, Screen.height, (TextureFormat)3, true);
		yield return (object)new WaitForEndOfFrame();
		tex.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, true);
		tex.Apply();
		yield return tex;
		byte[] byt = ImageConversion.EncodeToPNG(tex);
		string path = Application.persistentDataPath + "/Screenshot";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		File.WriteAllBytes(path + "/" + name, byt);
		Object.Destroy((Object)(object)tex);
		yield return (object)new WaitForEndOfFrame();
		FGUIManager.Instance.StageCamera.clearFlags = (CameraClearFlags)3;
	}

	private void ScanFile(string[] path)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		AndroidJavaClass val = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		try
		{
			AndroidJavaObject val2 = ((AndroidJavaObject)val).GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject val3 = new AndroidJavaObject("android.media.MediaScannerConnection", new object[2] { val2, null });
			try
			{
				val3.CallStatic("scanFile", new object[4] { val2, path, null, null });
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static string GetCurTime()
	{
		return DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
	}
}
