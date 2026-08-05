using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using HotFix;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.ResourceLocations;

public static class AssetsHelper
{
	private const string AndroidUnzipFlag = "Android.uzf";

	private const string AndroidAcceptPrivacyFlag = "Android.atpf";

	public static string AndroidUnzipFlagFile = Application.persistentDataPath + "/Android.uzf";

	public static string AndroidAcceptPrivacyFlagFile = Application.persistentDataPath + "/Android.atpf";

	public static string AssetBundleFilePath = Application.persistentDataPath + "/AssetBundles/";

	public static string vFile = Application.persistentDataPath + "/v.bin";

	public static string AssetBundleFilePathWithoutLastSeparator = Application.persistentDataPath + "/AssetBundles";

	public static string AssetBundleFileSuffix = ".ab";

	private static string _serverAssetPath;

	private static string _backup_serverAssetPath;

	private static string _platformType;

	private static readonly string LocalResourceXmlPath = AssetBundleFilePath + "Resource.xml";

	public static string ServerAssetPathBase => HotUpdateProcess.Instance.Configs["ResUrl"];

	public static string BackupServerAssetPathBase => HotUpdateProcess.Instance.Configs["BackupResUrl"];

	public static string ServerAssetPath
	{
		get
		{
			if (_serverAssetPath == null)
			{
				_serverAssetPath = ServerAssetPathBase + "AssetBundles/" + PlatformType;
			}
			return _serverAssetPath;
		}
	}

	public static string BackupServerAssetPath
	{
		get
		{
			if (_backup_serverAssetPath == null)
			{
				_backup_serverAssetPath = BackupServerAssetPathBase + "AssetBundles/" + PlatformType;
			}
			return _backup_serverAssetPath;
		}
	}

	public static string PlatformType
	{
		get
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Invalid comparison between Unknown and I4
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Invalid comparison between Unknown and I4
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Invalid comparison between Unknown and I4
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Invalid comparison between Unknown and I4
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Invalid comparison between Unknown and I4
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Invalid comparison between Unknown and I4
			if (_platformType == null)
			{
				if ((int)Application.platform == 8)
				{
					_platformType = "iOS";
				}
				else if ((int)Application.platform == 11)
				{
					_platformType = "Android";
				}
				else if ((int)Application.platform == 1 || (int)Application.platform == 0)
				{
					_platformType = "MacOS";
				}
				else if ((int)Application.platform == 2 || (int)Application.platform == 7)
				{
					_platformType = "PC";
				}
				else
				{
					_platformType = "PC";
				}
			}
			return _platformType;
		}
	}

	public static string ServerHotFixCodePath => HotUpdateProcess.Instance.Configs["HotFixUrl"];

	public static string HotFix_CodeVersion => ServerHotFixCodePath + "CodeVersion.ver";

	public static string HotFix_dll => ServerHotFixCodePath + "HotFix.dll.bin";

	public static string HotFix_pdb => ServerHotFixCodePath + "HotFix.pdb.bin";

	public static string BackupServerHotFixCodePath => HotUpdateProcess.Instance.Configs["BackupHotFixUrl"];

	public static string BackupHotFix_CodeVersion => BackupServerHotFixCodePath + "CodeVersion.ver";

	public static string BackupHotFix_dll => BackupServerHotFixCodePath + "HotFix.dll.bin";

	public static string BackupHotFix_pdb => BackupServerHotFixCodePath + "HotFix.pdb.bin";

	public static void CheckFolder(string path)
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}

	public static string GetPath(string filePath)
	{
		string text = filePath.Replace("\\", "/");
		int num = text.LastIndexOf("/", StringComparison.Ordinal);
		if (-1 == num)
		{
			throw new Exception("can not find /!!!");
		}
		return text.Substring(0, num);
	}

	public static string GetLocalPath(string path)
	{
		return "file://" + Application.persistentDataPath + "/AssetBundles/" + path;
	}

	public static string GetStreamingAssetPath(string path)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			return Application.streamingAssetsPath + "/AssetBundles/" + path;
		}
		return "file://" + Application.streamingAssetsPath + "/AssetBundles/" + path;
	}

	public static string GetServerPath(string path)
	{
		return ServerAssetPath + "/" + path;
	}

	public static string GetBackupServerPath(string path)
	{
		return BackupServerAssetPath + "/" + path;
	}

	public static Stream Open(string path, string suffix = null)
	{
		if (suffix == null)
		{
			suffix = AssetBundleFileSuffix;
		}
		string text = AssetBundleFilePath + path + suffix;
		if (File.Exists(text))
		{
			return File.Open(text, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
		Debug.LogWarning((object)(text + " 中 没有文件： " + path + suffix));
		Object obj = Resources.Load(path);
		TextAsset val = (TextAsset)(object)((obj is TextAsset) ? obj : null);
		if ((Object)null == (Object)(object)val)
		{
			throw new FileNotFoundException("Resources.Load中也没有， 找不到文件:" + path + suffix);
		}
		return new MemoryStream(val.bytes);
	}

	public static StreamReader OpenText(string path, string suffix = null)
	{
		return new StreamReader(Open(path, suffix), Encoding.Default);
	}

	public static bool IsDirectoryEmpty(string path)
	{
		return !Directory.EnumerateFileSystemEntries(path).Any();
	}

	public static bool IsLocaleAssetBundleExists(string language)
	{
		return File.Exists(Application.streamingAssetsPath + "/" + language + "/AssetBundles.zip");
	}

	public static bool CheckAddressable(object key, Type type)
	{
		IList<IResourceLocation> list = default(IList<IResourceLocation>);
		foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
		{
			if (resourceLocator.Locate(key, type, ref list))
			{
				return true;
			}
		}
		return false;
	}

	public static IEnumerator DownloadIntegratedResourceXml()
	{
		UnityWebRequest uwr = UnityWebRequest.Get(GetStreamingAssetPath("Resource.xml"));
		yield return uwr.SendWebRequest();
		if (uwr.isNetworkError || uwr.isHttpError)
		{
			ILRuntimeDebug.LogError("获取整包Resource.xml失败!  error=" + uwr.error + " , URL = " + uwr.url);
		}
		else
		{
			yield return uwr.downloadHandler.text;
		}
	}

	public static IEnumerator DownloadIntegratedVersionXml()
	{
		UnityWebRequest uwr = UnityWebRequest.Get(GetStreamingAssetPath("Version.xml"));
		yield return uwr.SendWebRequest();
		if (uwr.isNetworkError || uwr.isHttpError)
		{
			ILRuntimeDebug.LogError("获取整包Version.xml失败!  error=" + uwr.error + " , URL = " + uwr.url);
		}
		else
		{
			yield return uwr.downloadHandler.text;
		}
	}

	public static XmlDocument GetResourceXml()
	{
		StreamReader streamReader = OpenText("Resource", ".xml");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(streamReader.ReadToEnd());
		streamReader.Dispose();
		MD5 mD = MD5.Create();
		FileStream fileStream = File.OpenRead(LocalResourceXmlPath);
		byte[] array = mD.ComputeHash(fileStream);
		mD.Dispose();
		fileStream.Flush();
		fileStream.Close();
		fileStream.Dispose();
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
		return xmlDocument;
	}

	public static void UpdateResourceXml(XmlDocument doc)
	{
		doc.Save(LocalResourceXmlPath);
		MD5 mD = MD5.Create();
		FileStream fileStream = File.OpenRead(LocalResourceXmlPath);
		byte[] array = mD.ComputeHash(fileStream);
		mD.Dispose();
		fileStream.Flush();
		fileStream.Close();
		fileStream.Dispose();
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
	}

	public static IEnumerator GetResourceFileMd5(string resName)
	{
		using MD5 md5 = MD5.Create();
		string filePath = Application.persistentDataPath + "/AssetBundles/" + resName;
		if (!File.Exists(filePath))
		{
			filePath = (((int)Application.platform != 11) ? ("file://" + Application.streamingAssetsPath + "/AssetBundles/" + resName) : (Application.streamingAssetsPath + "/AssetBundles/" + resName));
			UnityWebRequest uwr = UnityWebRequest.Get(filePath);
			uwr.SendWebRequest();
			while (!uwr.isDone)
			{
				yield return null;
			}
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				yield return null;
				yield break;
			}
			byte[] resData = uwr.downloadHandler.data;
			uwr.Dispose();
			yield return BitConverter.ToString(md5.ComputeHash(resData)).Replace("-", "");
		}
		else
		{
			FileStream fs = new FileStream(filePath, FileMode.Open);
			byte[] data = md5.ComputeHash(fs);
			fs.Flush();
			fs.Close();
			fs.Dispose();
			yield return BitConverter.ToString(data).Replace("-", "");
		}
	}
}
