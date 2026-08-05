using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix;
using RSG;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;
using UI.Tips;
using UnityEngine;
using UnityEngine.Networking;

public class VersionManager : MonoBehaviour
{
	private VersionFile _versionFile = new VersionFile();

	private VersionResourceFile _serverVersionFile;

	private VersionResourceFile _localVersionFile;

	private string _curVersion;

	private string _curIdentifier;

	public int _allNeedDownLoadSize;

	public int _currentDownLoadSize;

	public int _allNeedDownLoadBytes;

	public int _currentDownLoadBytes;

	private List<string> _deleteAssets;

	private List<string> _updateAssets;

	private List<int> _updateAssetsSize;

	private bool _complete;

	private int _maxRepeatDownLoadTimes = 5;

	private bool _forceTermination;

	private bool _networkConnections;

	private bool _needCheckNetWorkConnections;

	private float _checkNetWorkConnectionsMaxTimes;

	public Action OnPreviousAssetsDeleted;

	public static VersionManager Instance;

	public static bool LegendItemSwitch;

	public static bool LegendItemDrawSwitch;

	public string DllMd5;

	public string TIPS_1;

	public string TIPS_2;

	public string TIPS_3;

	public string TIPS_4;

	public string TIPS_5;

	public string TIPS_6;

	public string TIPS_7;

	private UnityWebRequest req_dll;

	public VersionResourceFile LocalVersionFile => _localVersionFile;

	private void Awake()
	{
		Instance = this;
		_versionFile = new VersionFile();
		TIPS_1 = "资源更新完成，需要重启游戏才能生效";
		TIPS_2 = "网络异常{0}，无法获取应用程序资源，请重启游戏";
		TIPS_3 = "网络异常{0}，无法获取应用程序校验资源，请重启游戏";
		TIPS_4 = "更新已完成，需要重启游戏才能生效";
		TIPS_5 = "程序更新中 {0}% ...";
		TIPS_6 = "网络异常，无法更新游戏资源，请重启游戏";
		TIPS_7 = "程序更新异常，请检查网络。";
	}

	private void ParseVersionFile(string text, string channel, ref VersionFile version)
	{
		List<VersionFile> list = JsonHelper.ToObject<List<VersionFile>>(text);
		foreach (VersionFile item in list)
		{
			if (item.Name == channel)
			{
				version.Name = item.Name;
				version.Version = item.Version;
				version.ForceUpdate = item.ForceUpdate;
				version.Size = item.Size;
				version.Type = item.Type;
				version.Date = item.Date;
				version.Tip = item.Tip;
				version.UpdateAddress = item.UpdateAddress;
			}
		}
	}

	private void ParseResourceVersionFile(string text, ref VersionResourceFile file)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlElement documentElement = xmlDocument.DocumentElement;
		file.Number = documentElement.GetAttribute("Number");
		file.Big = Convert.ToBoolean(documentElement.GetAttribute("Big"));
		IEnumerator enumerator = documentElement.GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlElement xmlElement = enumerator.Current as XmlElement;
			file.Md5.Add(xmlElement.GetAttribute("fpath"), xmlElement.GetAttribute("md5"));
			file.Size.Add(xmlElement.GetAttribute("fpath"), Convert.ToInt32(xmlElement.GetAttribute("size")));
		}
	}

	public async Task<Promise> CopyAssetsToPersistentFolder()
	{
		Promise promise = new Promise();
		if ((int)Application.platform == 0 || (int)Application.platform == 7 || (int)Application.platform == 2)
		{
			promise.Resolve();
			return promise;
		}
		string path = AssetsHelper.AssetBundleFilePath;
		string vFile = Path.Combine(Application.persistentDataPath, "v.bin");
		if (Directory.Exists(path))
		{
			if (File.Exists(vFile))
			{
				string v = File.ReadAllText(vFile).Trim();
				if (Application.version == v)
				{
					promise.Resolve();
					return promise;
				}
			}
			File.Delete(vFile);
			Directory.Delete(path, recursive: true);
			OnPreviousAssetsDeleted?.Invoke();
			await Task.Delay(2000);
		}
		else
		{
			UiHelper.needShowXiaomiTipOnLogin = true;
		}
		File.WriteAllText(vFile, Application.version);
		((MonoBehaviour)this).StartCoroutine(InternalCopyAssetsToPersistentFolder(promise));
		return promise;
	}

	private IEnumerator InternalCopyAssetsToPersistentFolder(Promise promise)
	{
		string targetPath = Application.persistentDataPath + "/AssetBundles";
		string sourcePkg = Application.streamingAssetsPath + "/AssetBundles.zip";
		if ((int)Application.platform == 0 || (int)Application.platform == 7 || (int)Application.platform == 2)
		{
			string folder;
			if ((int)Application.platform == 0)
			{
				folder = "MacOS";
			}
			else
			{
				if ((int)Application.platform != 7 && (int)Application.platform != 2)
				{
					throw new Exception("不支持的平台");
				}
				folder = "PC";
			}
			sourcePkg = Path.Combine(Application.dataPath, "..", "AssetBundles", folder);
			CloneDirectory(sourcePkg, targetPath);
			yield return null;
		}
		else if ((int)Application.platform == 11)
		{
			string tmpPkg = Application.persistentDataPath + "/AssetBundles.zip";
			UnityWebRequest uwr = new UnityWebRequest(sourcePkg);
			uwr.method = "GET";
			DownloadHandlerFile dh = new DownloadHandlerFile(tmpPkg);
			dh.removeFileOnAbort = true;
			uwr.downloadHandler = (DownloadHandler)(object)dh;
			yield return uwr.SendWebRequest();
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				promise.Resolve();
				yield break;
			}
			ZipHelper.UnZip(tmpPkg, targetPath);
			File.Delete(tmpPkg);
		}
		else
		{
			if (!File.Exists(sourcePkg))
			{
				promise.Resolve();
				yield break;
			}
			ZipHelper.UnZip(sourcePkg, targetPath);
		}
		promise.Resolve();
	}

	private static void CloneDirectory(string root, string dest)
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

	public Promise<bool> UpdateVersion()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		Promise<bool> promise = new Promise<bool>();
		_networkConnections = true;
		_curVersion = Application.version;
		if ((int)Application.platform == 11 || (int)Application.platform == 8)
		{
			_curIdentifier = Application.identifier;
		}
		else
		{
			_curIdentifier = "com.gubulin.il";
		}
		string url = AssetsHelper.ServerAssetPathBase + "version.json";
		DownLoad(url).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
		{
			try
			{
				ParseVersionFile(uwr.downloadHandler.text, _curIdentifier, ref _versionFile);
				if (_versionFile.Version == null)
				{
					promise.Reject(new Exception("资源文件异常，未找到匹配的版本"));
				}
				else if (_versionFile.Version != _curVersion && _versionFile.Type == "package" && _versionFile.UpdateAddress != "")
				{
					UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
					{
						{ "Content", _versionFile.Tip },
						{
							"Buttons",
							new Dictionary<string, Action> { 
							{
								"Confirm",
								delegate
								{
									UiHelper.OpenUrl(_versionFile.UpdateAddress);
								}
							} }
						},
						{ "PageIndex", 4 },
						{ "ClickSound", "Confirm" },
						{ "CloseAfterClick", false },
						{ "Order", 999999 }
					}, multiMode: false, ignoreQueue: true);
					promise.Resolve(false);
				}
				else if (_versionFile.Type == "resource")
				{
					UpdateResources().Then((Action<bool>)delegate(bool result)
					{
						//IL_0015: Unknown result type (might be due to invalid IL or missing references)
						//IL_001c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0022: Invalid comparison between Unknown and I4
						//IL_0024: Unknown result type (might be due to invalid IL or missing references)
						//IL_002a: Invalid comparison between Unknown and I4
						if ((int)Application.platform == 0 || (int)Application.platform == 7 || (int)Application.platform == 2)
						{
							((MonoBehaviour)this).StartCoroutine(GetLocalDllMd5(delegate(string md5)
							{
								DllMd5 = md5;
								if (result)
								{
									OpenRestartPanel(TIPS_1);
								}
								GDMgr.LoadData();
								promise.Resolve(true);
							}));
						}
						else
						{
							((MonoBehaviour)this).StartCoroutine(HotFixDllUpdate(result, delegate
							{
								GDMgr.LoadData();
								promise.Resolve(true);
							}));
						}
					}).Catch((Action<Exception>)delegate(Exception ex2)
					{
						promise.Reject(ex2);
					});
				}
				else
				{
					promise.Reject(new Exception("更新失败，未找到待更新的版本"));
				}
			}
			catch (Exception ex)
			{
				promise.Reject(ex);
			}
		}).Catch((Action<Exception>)promise.Reject);
		return promise;
	}

	private string GetLocalVersionVerURL()
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

	private IEnumerator GetLocalDllMd5(Action<string> callback)
	{
		string local_version_ver_path = GetLocalVersionVerURL();
		UnityWebRequest req_version_ver_path = UnityWebRequest.Get(local_version_ver_path);
		yield return req_version_ver_path.SendWebRequest();
		if (req_version_ver_path.isNetworkError || req_version_ver_path.isHttpError)
		{
			callback(string.Empty);
			yield break;
		}
		string text = req_version_ver_path.downloadHandler.text;
		string md5 = text.Replace("\n", "").Replace("\r", "").Replace(" ", "");
		callback(md5);
	}

	private IEnumerator HotFixDllUpdate(bool resource_updated, Action no_update_action)
	{
		bool isLocalDLL = false;
		string local_hotfixdll_md5 = PlayerPrefs.GetString("hotfixdll_md5");
		string local_hotfixdll_string = PlayerPrefs.GetString("hotfixdll_string");
		if (string.IsNullOrEmpty(local_hotfixdll_md5))
		{
			string local_version_ver_path = GetLocalVersionVerURL();
			UnityWebRequest req_version_ver_path = UnityWebRequest.Get(local_version_ver_path);
			yield return req_version_ver_path.SendWebRequest();
			if (req_version_ver_path.isNetworkError || req_version_ver_path.isHttpError)
			{
				local_hotfixdll_md5 = string.Empty;
			}
			else
			{
				local_hotfixdll_md5 = req_version_ver_path.downloadHandler.text;
				local_hotfixdll_md5 = local_hotfixdll_md5.Replace("\n", "").Replace("\r", "").Replace(" ", "");
				isLocalDLL = true;
				DllMd5 = local_hotfixdll_md5;
			}
		}
		if ((int)Application.platform == 8 && local_hotfixdll_string.StartsWith(Application.persistentDataPath))
		{
			string local_hotfixdll_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + local_hotfixdll_md5 + "/";
			if (!Directory.Exists(local_hotfixdll_path))
			{
				local_hotfixdll_md5 = string.Empty;
			}
		}
		if (!string.IsNullOrEmpty(local_hotfixdll_md5) && !isLocalDLL)
		{
			DllMd5 = local_hotfixdll_md5;
			string floder_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + local_hotfixdll_md5 + "/";
			string download_hotfixdll_path = floder_path + "HotFix.dll.bin";
			string cur_MD5 = "file://" + download_hotfixdll_path;
			UnityWebRequest req_cur_MD5 = UnityWebRequest.Get(cur_MD5);
			yield return req_cur_MD5.SendWebRequest();
			if (req_cur_MD5.isNetworkError || req_cur_MD5.isHttpError)
			{
				local_hotfixdll_md5 = string.Empty;
				ILRuntimeDebug.LogError("[热更] 获取本地DLL 失败  ");
			}
			else
			{
				string cur_use_md5 = GetFileMD5(req_cur_MD5.downloadHandler.data).ToLower();
				if (!cur_use_md5.Equals(local_hotfixdll_md5))
				{
					ILRuntimeDebug.LogError("[热更] 本地使用的dll的MD5 和 本地记录的MD5 不匹配");
					local_hotfixdll_md5 = string.Empty;
				}
			}
		}
		UnityWebRequest req = UnityWebRequest.Get(AssetsHelper.HotFix_CodeVersion);
		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError)
		{
			ILRuntimeDebug.LogError("[热更] 获取热更MD5失败!  error=" + req.error + " , URL = " + AssetsHelper.HotFix_CodeVersion);
			if (!resource_updated)
			{
				no_update_action?.Invoke();
			}
			else
			{
				OpenRestartPanel(TIPS_1);
			}
			yield return null;
			yield break;
		}
		string remote_md5 = req.downloadHandler.text;
		remote_md5 = remote_md5.Replace("\n", "").Replace("\r", "").Replace(" ", "");
		if (remote_md5.Equals(local_hotfixdll_md5))
		{
			DllMd5 = local_hotfixdll_md5;
			if (!resource_updated)
			{
				no_update_action?.Invoke();
			}
			else
			{
				OpenRestartPanel(TIPS_1);
			}
			yield return null;
			yield break;
		}
		string floder_path2 = Application.persistentDataPath + "/IdleLegionHotFixDll_" + remote_md5 + "/";
		string last_floder_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + local_hotfixdll_md5 + "/";
		if (!Directory.Exists(floder_path2))
		{
			Directory.CreateDirectory(floder_path2);
		}
		string download_hotfixdll_path2 = floder_path2 + "HotFix.dll.bin";
		req_dll = UnityWebRequest.Get(AssetsHelper.HotFix_dll);
		OpenDownloadHotFixPanel();
		yield return req_dll.SendWebRequest();
		if (req_dll.isNetworkError || req_dll.isHttpError)
		{
			ILRuntimeDebug.LogError("[热更] 获取热更DLL失败!  error=" + req_dll.error + " , URL = " + AssetsHelper.HotFix_dll);
			OpenRestartPanel(string.Format(TIPS_2, req_dll.error));
			yield return null;
		}
		else
		{
			FileStream stream = new FileStream(download_hotfixdll_path2, FileMode.OpenOrCreate);
			stream.SetLength(0L);
			stream.Flush();
			stream.Write(req_dll.downloadHandler.data, 0, req_dll.downloadHandler.data.Length);
			stream.Flush();
			stream.Close();
			stream.Dispose();
			string save_path = "file://" + download_hotfixdll_path2;
			string download_md5 = GetFileMD5(req_dll.downloadHandler.data).ToLower();
			if (!download_md5.Equals(remote_md5))
			{
				OpenRestartPanel(TIPS_7);
				yield break;
			}
			PlayerPrefs.SetString("hotfixdll_string", save_path);
		}
		if ((int)Application.platform == 0 || (int)Application.platform == 7 || (int)Application.platform == 2)
		{
			string download_hotfixpdb_path = floder_path2 + "HotFix.pdb.bin";
			UnityWebRequest req_pdb = UnityWebRequest.Get(AssetsHelper.HotFix_pdb);
			yield return req_pdb.SendWebRequest();
			if (req_pdb.isNetworkError || req_pdb.isHttpError)
			{
				ILRuntimeDebug.LogError("[热更] 获取热更PDB失败!  error=" + req_pdb.error + " , URL = " + AssetsHelper.HotFix_pdb);
				OpenRestartPanel(string.Format(TIPS_3, req_pdb.error));
				yield return null;
			}
			FileStream stream_dll = new FileStream(download_hotfixpdb_path, FileMode.OpenOrCreate);
			stream_dll.SetLength(0L);
			stream_dll.Flush();
			stream_dll.Write(req_pdb.downloadHandler.data, 0, req_pdb.downloadHandler.data.Length);
			stream_dll.Flush();
			stream_dll.Close();
			stream_dll.Dispose();
			string save_path2 = "file://" + download_hotfixpdb_path;
			PlayerPrefs.SetString("hotfixpdb_string", save_path2);
		}
		PlayerPrefs.SetString("hotfixdll_md5", remote_md5);
		string need_to_del = PlayerPrefs.GetString("hotfix_last_dll_need_to_delete");
		if (Directory.Exists(need_to_del))
		{
			Directory.Delete(need_to_del, recursive: true);
		}
		PlayerPrefs.SetString("hotfix_last_dll_need_to_delete", last_floder_path);
		OpenRestartPanel(TIPS_4);
	}

	private IEnumerator UpdateDownloadHotFixPanel()
	{
		int progress = 0;
		while (req_dll != null && progress < 100)
		{
			yield return (object)new WaitForSeconds(0.2f);
			progress = (int)(req_dll.downloadProgress * 100f);
			if (progress >= 100)
			{
				break;
			}
			if (UnityUiService.Instance.DictUI.ContainsKey(UI_UniversalConfirmPopup.Name))
			{
				(UnityUiService.Instance.DictUI[UI_UniversalConfirmPopup.Name] as UI_UniversalConfirmPopup)?.Change_ConfirmDialog_Tip(string.Format(TIPS_5, progress));
			}
		}
	}

	private void OpenDownloadHotFixPanel()
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				string.Format(TIPS_5, 0)
			},
			{ "CanNotClick", 0 },
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		}, multiMode: false, ignoreQueue: true);
		((MonoBehaviour)this).StartCoroutine(UpdateDownloadHotFixPanel());
	}

	public void OpenRestartPanel(string message)
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "Content", message },
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					LoadController.SoftRestart
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		}, multiMode: false, ignoreQueue: true);
	}

	public Promise<bool> UpdateResources()
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Invalid comparison between Unknown and I4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		Promise<bool> promise = new Promise<bool>();
		_localVersionFile = new VersionResourceFile();
		_serverVersionFile = new VersionResourceFile();
		_deleteAssets = new List<string>();
		_updateAssets = new List<string>();
		_updateAssetsSize = new List<int>();
		_allNeedDownLoadSize = 0;
		_currentDownLoadSize = 0;
		_allNeedDownLoadBytes = 0;
		_currentDownLoadBytes = 0;
		_complete = false;
		_maxRepeatDownLoadTimes = 5;
		_networkConnections = true;
		_needCheckNetWorkConnections = false;
		_checkNetWorkConnectionsMaxTimes = 10f;
		StreamReader streamReader = AssetsHelper.OpenText("Version", ".xml");
		ParseResourceVersionFile(streamReader.ReadToEnd(), ref _localVersionFile);
		streamReader.Close();
		string url = AssetsHelper.GetServerPath("Version.xml");
		if ((int)Application.platform == 7 || (int)Application.platform == 0 || (int)Application.platform == 2)
		{
			url = AssetsHelper.GetLocalPath("Version.xml");
		}
		DownLoad(url).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
		{
			try
			{
				ParseResourceVersionFile(uwr.downloadHandler.text, ref _serverVersionFile);
				if (NeedUpdate(_localVersionFile, _serverVersionFile, _updateAssets, _updateAssetsSize, _deleteAssets))
				{
					_allNeedDownLoadSize = _updateAssets.Count;
					UpdateController.Instance.UpdateResourcesPanel.needUpdate = true;
					((GComponent)UpdateController.Instance.UpdateResourcesPanel).GetChild("legionTip").visible = false;
					((GObject)UpdateController.Instance.UpdateResourcesPanel.updateProgressBar).visible = true;
					float num = (float)_allNeedDownLoadBytes / 1048576f;
					((GObject)UpdateController.Instance.UpdateResourcesPanel.updateProgressBar.progress).text = $"{0}MB/{num:F}MB 0%";
					UpdateController.Instance.UpdateResourcesPanel.AllDataNum = _allNeedDownLoadSize;
					UpdateController.Instance.UpdateResourcesPanel.AllDataSize = _allNeedDownLoadBytes;
					UpdateController.Instance.OpenUpdateResources();
					DownLoadAssets().Then((Action)delegate
					{
						try
						{
							ReplaceLocalRes("Version.xml", uwr.downloadHandler.data);
							DeleteExpiredRes();
							_complete = true;
							promise.Resolve(true);
						}
						catch (Exception ex2)
						{
							promise.Reject(ex2);
						}
					}).Catch((Action<Exception>)promise.Reject);
				}
				else
				{
					_complete = true;
					promise.Resolve(false);
				}
			}
			catch (Exception ex)
			{
				promise.Reject(ex);
			}
		}).Catch((Action<Exception>)promise.Reject);
		return promise;
	}

	public static string GetFileMD5(byte[] fileContent)
	{
		MD5 mD = MD5.Create();
		byte[] array = mD.ComputeHash(fileContent);
		string text = BitConverter.ToString(array);
		return text.Replace("-", "");
	}

	private bool NeedUpdate(VersionResourceFile local, VersionResourceFile server, List<string> update, List<int> updateSize, List<string> delete)
	{
		foreach (string key in server.Md5.Keys)
		{
			string text = server.Md5[key];
			if (local.Md5.ContainsKey(key))
			{
				string fileMD = HotFixUtils.GetFileMD5(AssetsHelper.AssetBundleFilePath + key);
				if (fileMD != server.Md5[key])
				{
					update.Add(key);
					_allNeedDownLoadBytes += server.Size[key];
					updateSize.Add(server.Size[key]);
				}
			}
			else
			{
				update.Add(key);
				_allNeedDownLoadBytes += server.Size[key];
				updateSize.Add(server.Size[key]);
			}
		}
		foreach (KeyValuePair<string, string> item in local.Md5)
		{
			if (!server.Md5.ContainsKey(item.Key))
			{
				delete.Add(item.Key);
			}
		}
		foreach (string item2 in update)
		{
		}
		foreach (string item3 in delete)
		{
		}
		return update.Count > 0;
	}

	public IPromise<UnityWebRequest> DownLoad(string url)
	{
		Promise<UnityWebRequest> val = new Promise<UnityWebRequest>();
		((MonoBehaviour)this).StartCoroutine(UnityDownload(val, url));
		return (IPromise<UnityWebRequest>)(object)val;
	}

	private IEnumerator UnityDownload(Promise<UnityWebRequest> promise, string url)
	{
		UnityWebRequest uwr = UnityWebRequest.Get(CheckUrl(ref url));
		yield return uwr.SendWebRequest();
		if (uwr.isNetworkError || uwr.isHttpError)
		{
			CheckNetworkReachability().Then((Action<bool>)delegate
			{
				DownLoad(url).Then((Action<UnityWebRequest>)promise.Resolve).Catch((Action<Exception>)promise.Reject);
			});
		}
		else
		{
			promise.Resolve(uwr);
		}
	}

	private IPromise<bool> CheckNetworkReachability()
	{
		Promise<bool> val = new Promise<bool>();
		((MonoBehaviour)this).StartCoroutine(CheckNetworkReachabilityCoroutine(val));
		return (IPromise<bool>)(object)val;
	}

	private IEnumerator CheckNetworkReachabilityCoroutine(Promise<bool> promise)
	{
		_needCheckNetWorkConnections = true;
		string url = HotUpdateProcess.Instance.RegionModel.Zone.url.res[0] + "/cnc.txt";
		while (_needCheckNetWorkConnections)
		{
			UnityWebRequest uwr = UnityWebRequest.Get(CheckUrl(ref url));
			uwr.timeout = 4;
			yield return uwr.SendWebRequest();
			if (!uwr.isNetworkError && !uwr.isHttpError && uwr.downloadHandler.text.Trim() == "1")
			{
				_needCheckNetWorkConnections = false;
				_networkConnections = true;
				promise.Resolve(true);
				break;
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private string CheckUrl(ref string url)
	{
		string text = url.Replace(" ", "%20");
		return text.Replace("#", "%23");
	}

	private Promise DownLoadAssets()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Promise val = new Promise();
		((MonoBehaviour)this).StartCoroutine(DownloadAssets(val));
		return val;
	}

	private IEnumerator DownloadAssets(Promise promise)
	{
		for (int i = 0; i < _updateAssets.Count; i++)
		{
			string asset = _updateAssets[i];
			string path = asset;
			string url = AssetsHelper.GetServerPath(asset);
			url = CheckUrl(ref url);
			UnityWebRequest uwr = UnityWebRequest.Get(url);
			uwr.SendWebRequest();
			int last_downloadedBytes = 0;
			while (uwr.downloadProgress < 1f && !uwr.isNetworkError && !uwr.isHttpError)
			{
				_currentDownLoadBytes += (int)uwr.downloadedBytes - last_downloadedBytes;
				last_downloadedBytes = (int)uwr.downloadedBytes;
				yield return (object)new WaitForSeconds(0.2f);
			}
			if (uwr.downloadProgress >= 1f)
			{
				_currentDownLoadBytes += (int)uwr.downloadedBytes - last_downloadedBytes;
			}
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				_currentDownLoadBytes -= last_downloadedBytes;
				promise.Reject((Exception)null);
				yield break;
			}
			string download_md5 = GetFileMD5(uwr.downloadHandler.data);
			if (!_serverVersionFile.Md5.TryGetValue(path, out var serverMd5) || serverMd5 != download_md5)
			{
				i--;
				continue;
			}
			ReplaceLocalRes(path, uwr.downloadHandler.data);
			_currentDownLoadSize++;
			_updateAssetsSize.RemoveAt(0);
			serverMd5 = null;
		}
		_updateAssets.Clear();
		promise.Resolve();
	}

	private void ReplaceLocalRes(string file, byte[] data)
	{
		string text = AssetsHelper.AssetBundleFilePath + file;
		AssetsHelper.CheckFolder(AssetsHelper.GetPath(text));
		FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
		fileStream.SetLength(0L);
		fileStream.Flush();
		fileStream.Write(data, 0, data.Length);
		fileStream.Flush();
		fileStream.Close();
		fileStream.Dispose();
	}

	private void DeleteExpiredRes()
	{
		foreach (string deleteAsset in _deleteAssets)
		{
			if (!string.IsNullOrEmpty(deleteAsset))
			{
				string path = AssetsHelper.AssetBundleFilePath + deleteAsset;
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(AssetsHelper.AssetBundleFilePath);
		foreach (FileInfo item in directoryInfo.EnumerateFiles())
		{
			string text = item.FullName.Replace("\\", "/").Replace(AssetsHelper.AssetBundleFilePath, "");
			if (!_serverVersionFile.Md5.ContainsKey(text) && !text.EndsWith("Version.xml"))
			{
				item.Delete();
			}
		}
		foreach (DirectoryInfo item2 in directoryInfo.EnumerateDirectories())
		{
			if (AssetsHelper.IsDirectoryEmpty(item2.FullName))
			{
				item2.Delete();
			}
		}
	}
}
