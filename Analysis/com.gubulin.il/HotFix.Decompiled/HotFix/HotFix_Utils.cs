using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using GameMaths;
using HotFix.Sources.ThirdParty.SDKs.Android;
using UI.Tips;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace HotFix;

public static class HotFix_Utils
{
	public const float DevWidth = 1920f;

	public const float DevHieght = 1080f;

	public static Vec3 GetPosition_from_ConfigPosition(UnitPosition _unit_pos)
	{
		return new Vec3((float)_unit_pos.X / 1000f, (float)_unit_pos.Y / 1000f, (float)_unit_pos.Z / 1000f);
	}

	public static Quat GetRotation_from_ConfigPosition(short rotation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Quaternion unitRotationFromShortValue = RotationHelper.GetUnitRotationFromShortValue(rotation);
		return new Quat(unitRotationFromShortValue.X, unitRotationFromShortValue.Y, unitRotationFromShortValue.Z, unitRotationFromShortValue.W);
	}

	public static DateTime ConvertLongToDateTime(int d)
	{
		DateTime dateTime = new DateTime(1970, 1, 1).ToLocalTime();
		long ticks = long.Parse(d + "0000000");
		TimeSpan value = new TimeSpan(ticks);
		return dateTime.Add(value);
	}

	public static bool TrySetPlayTime(float _playtime)
	{
		string s = GameLocalDataManager.GetString("CurLoginTime");
		int.TryParse(s, out var result);
		if (result != 0)
		{
			DateTime dateTime = ConvertLongToDateTime((int)GameController.Instance.GetServerTime());
			DateTime time = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 6, 0, 0);
			int timeStamp = DateTimeHelper.GetTimeStamp(time);
			if (result < timeStamp)
			{
				GameLocalDataManager.SetString("TodayPlayTime", "0");
				return false;
			}
		}
		GameLocalDataManager.SetString("TodayPlayTime", $"{(int)_playtime}");
		return true;
	}

	public static string GetBattleModelQualityStringSetting()
	{
		string text = "";
		string text2 = GameLocalDataManager.GetString("BattleModelQualityStringSetting");
		if (text2 == "_low")
		{
			return "_low";
		}
		return "";
	}

	public static bool SetBattleModelQualityStringSetting(string quality_string)
	{
		if ("" == quality_string || "_low" == quality_string)
		{
			GameLocalDataManager.SetString("BattleModelQualityStringSetting", quality_string);
			return true;
		}
		return false;
	}

	public static string GetMouseEffectSetting()
	{
		string text = GameLocalDataManager.GetString("MouseEffectSetting");
		if (text != "")
		{
			return text;
		}
		return "off";
	}

	public static bool SetMouseEffectSetting(string effectString)
	{
		if (effectString == "on" || effectString == "off")
		{
			GameLocalDataManager.SetString("MouseEffectSetting", effectString);
			return true;
		}
		return false;
	}

	public static void CloneDirectory(string root, string dest)
	{
		string[] directories = Directory.GetDirectories(root);
		foreach (string text in directories)
		{
			string fileName = Path.GetFileName(text);
			if (!Directory.Exists(Path.Combine(dest, fileName)))
			{
				Directory.CreateDirectory(Path.Combine(dest, fileName));
			}
			CloneDirectory(text, Path.Combine(dest, fileName));
		}
		string[] files = Directory.GetFiles(root);
		foreach (string text2 in files)
		{
			File.Copy(text2, Path.Combine(dest, Path.GetFileName(text2)));
		}
	}

	public static IEnumerator getTextureByPath(string imagePath)
	{
		if (!imagePath.StartsWith("file://"))
		{
			imagePath = "file://" + imagePath;
		}
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(imagePath);
		yield return request.SendWebRequest();
		if (request.isNetworkError || request.isHttpError)
		{
			yield return null;
		}
		else
		{
			yield return ((DownloadHandlerTexture)request.downloadHandler).texture;
		}
	}

	public static Dictionary<string, HotUpdateFileInfo> ParseVersionString(string text)
	{
		Dictionary<string, HotUpdateFileInfo> dictionary = new Dictionary<string, HotUpdateFileInfo>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlElement documentElement = xmlDocument.DocumentElement;
		IEnumerator enumerator = documentElement.GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlElement xmlElement = enumerator.Current as XmlElement;
			string attribute = xmlElement.GetAttribute("md5");
			string attribute2 = xmlElement.GetAttribute("fpath");
			string attribute3 = xmlElement.GetAttribute("size");
			dictionary.Add(attribute2, new HotUpdateFileInfo(attribute2, int.Parse(attribute3), attribute));
		}
		return dictionary;
	}

	public static string GetpPrsistentDataURL(string path)
	{
		return Path.Combine(Application.persistentDataPath, path);
	}

	public static string CreateMD5(byte[] fileContent)
	{
		using MD5 mD = MD5.Create();
		byte[] array = mD.ComputeHash(fileContent);
		string text = BitConverter.ToString(array);
		return text.Replace("-", "").ToLower();
	}

	public static string CreateMD5(string input)
	{
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		string text = BitConverter.ToString(array);
		return text.Replace("-", "").ToLower();
	}

	public static string GetLocalVersionVerURL()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		RuntimePlatform platform = Application.platform;
		RuntimePlatform val = platform;
		if ((int)val <= 8)
		{
			if ((int)val <= 1)
			{
				goto IL_0057;
			}
			if ((int)val == 8)
			{
				return "file://" + Application.streamingAssetsPath + "/dlls/CodeVersion.ver";
			}
		}
		else
		{
			if ((int)val == 11)
			{
				return Application.streamingAssetsPath + "/dlls/CodeVersion.ver";
			}
			if ((int)val == 13 || (int)val == 16)
			{
				goto IL_0057;
			}
		}
		return "file:///" + Application.streamingAssetsPath + "/dlls/CodeVersion.ver";
		IL_0057:
		return "file://" + Application.streamingAssetsPath + "/dlls/CodeVersion.ver";
	}

	public static string GetCatalogURL()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		RuntimePlatform platform = Application.platform;
		RuntimePlatform val = platform;
		if ((int)val <= 8)
		{
			if ((int)val <= 1)
			{
				goto IL_0057;
			}
			if ((int)val == 8)
			{
				return "file://" + Application.persistentDataPath + "/AssetBundles/Addressables/catalog_1.json";
			}
		}
		else
		{
			if ((int)val == 11)
			{
				return Application.persistentDataPath + "/AssetBundles/Addressables/catalog_1.json";
			}
			if ((int)val == 13 || (int)val == 16)
			{
				goto IL_0057;
			}
		}
		return "file:///" + Application.persistentDataPath + "/AssetBundles/Addressables/catalog_1.json";
		IL_0057:
		return "file://" + Application.persistentDataPath + "/AssetBundles/Addressables/catalog_1.json";
	}

	public static void Restart()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		Transform val = ((Component)Camera.main).transform.Find("LoginPrefab");
		if ((Object)(object)val != (Object)null)
		{
			((Component)val).gameObject.SetActive(false);
		}
		string text = Path.Combine(Application.persistentDataPath, "AssetBundles", "Addressables", "catalog_1.json");
		AsyncOperationHandle<IResourceLocator> val2 = Addressables.LoadContentCatalogAsync(text, (string)null);
		val2.Completed += delegate(AsyncOperationHandle<IResourceLocator> obj)
		{
			Addressables.ClearResourceLocators();
			Addressables.AddResourceLocator(obj.Result, (string)null, (IResourceLocation)null);
			RestartManager.Instance.Restart();
		};
	}

	public static void Quit()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			if ((int)Application.platform == 8)
			{
				RestartManager.Instance.FroceCrash();
			}
			else if ((int)Application.platform == 7)
			{
				RestartManager.Instance.FroceCrash();
			}
			else
			{
				Application.Quit();
			}
			return;
		}
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			((BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK]).StopHeart();
		}
		if ((int)Application.platform == 2)
		{
			Application.Quit();
		}
		else
		{
			RestartManager.Instance.FroceCrash();
		}
	}

	public static void ShowAppClosedTip(CloseAppReason reason = CloseAppReason.Other)
	{
		UnityUiService.Instance.OpenPanel(UI_popup_AppClosedTip.Name, new Dictionary<string, object> { { "CloseReason", reason } });
	}

	public static string GetAndroidID()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		if ((int)Application.platform == 11)
		{
			AndroidJavaClass val = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject val2 = ((AndroidJavaObject)val).GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject val3 = val2.Call<AndroidJavaObject>("getContentResolver", Array.Empty<object>());
			AndroidJavaClass val4 = new AndroidJavaClass("android.provider.Settings$Secure");
			return ((AndroidJavaObject)val4).CallStatic<string>("getString", new object[2] { val3, "android_id" });
		}
		return string.Empty;
	}

	public static List<int> GetFormationFilter(string formationId)
	{
		switch (formationId)
		{
		case "F01":
		case "FA01":
			return new List<int> { 2, 4, 6, 5, 8 };
		case "F02":
		case "FA03":
			return new List<int> { 2, 4, 6, 7, 9 };
		case "F03":
		case "FA02":
			return new List<int> { 1, 3, 5, 7, 9 };
		case "F05":
		case "FA05":
			return new List<int> { 1, 3, 4, 6, 8 };
		case "F06":
		case "FA06":
			return new List<int> { 1, 2, 3, 5, 8 };
		case "F07":
		case "FA07":
			return new List<int> { 2, 5, 7, 8, 9 };
		case "F08":
		case "FA08":
			return new List<int> { 1, 2, 3, 4, 6 };
		case "F09":
		case "FA09":
			return new List<int> { 4, 6, 7, 8, 9 };
		case "F10":
		case "FA10":
			return new List<int> { 3, 6, 4, 5, 7 };
		case "F11":
		case "FA11":
			return new List<int> { 1, 4, 5, 6, 9 };
		default:
			return null;
		}
	}
}
