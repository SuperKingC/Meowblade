using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FairyGUI;
using HotFix;
using Shift.Legion.ClientLib.Services;
using Shift.Legion.Helpers;
using UI.MaskCover;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadController : MonoBehaviour
{
	[SerializeField]
	private Text _connectionErrorText;

	[SerializeField]
	private Text _errorText;

	[SerializeField]
	private Text _deletePreviousAssetsText;

	[SerializeField]
	private GameObject _restartBtn;

	[SerializeField]
	private GameObject _clearCacheAndRestartBtn;

	private GameObject _Canvas;

	private void Awake()
	{
		Screen.sleepTimeout = -1;
		Input.simulateMouseWithTouches = true;
		VersionManager instance = VersionManager.Instance;
		instance.OnPreviousAssetsDeleted = (Action)Delegate.Combine(instance.OnPreviousAssetsDeleted, new Action(OnPreviousAssetsDeleted));
	}

	private void Start()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		_Canvas = GameObject.Find("Canvas");
		if ((Object)(object)_Canvas != (Object)null)
		{
			_restartBtn = ((Component)_Canvas.transform.Find("RestartBtn")).gameObject;
			_clearCacheAndRestartBtn = ((Component)_Canvas.transform.Find("ClearCacheAndRestartBtn")).gameObject;
			_connectionErrorText = ((Component)_Canvas.transform.Find("ConnectionErrorTip")).GetComponent<Text>();
			_errorText = ((Component)_Canvas.transform.Find("ErrorTip")).GetComponent<Text>();
		}
		if ((Object)(object)_restartBtn != (Object)null)
		{
			Button component = _restartBtn.GetComponent<Button>();
			((UnityEvent)component.onClick).AddListener(new UnityAction(Restart));
		}
		if ((Object)(object)_clearCacheAndRestartBtn != (Object)null)
		{
			Button component2 = _clearCacheAndRestartBtn.GetComponent<Button>();
			((UnityEvent)component2.onClick).AddListener(new UnityAction(ClearCacheAndRestart));
		}
		((MonoBehaviour)this).StartCoroutine(LoadConfigs());
	}

	private void OnDestroy()
	{
		VersionManager instance = VersionManager.Instance;
		instance.OnPreviousAssetsDeleted = (Action)Delegate.Remove(instance.OnPreviousAssetsDeleted, new Action(OnPreviousAssetsDeleted));
		((MonoBehaviour)this).StopAllCoroutines();
	}

	private void OnPreviousAssetsDeleted()
	{
		((MonoBehaviour)this).StartCoroutine(PlayDeletePreviousAnimation());
	}

	private IEnumerator PlayDeletePreviousAnimation()
	{
		((Component)_deletePreviousAssetsText).gameObject.SetActive(true);
		for (int i = 0; i < 3; i++)
		{
			_deletePreviousAssetsText.text = ".";
			yield return (object)new WaitForSeconds(0.3f);
			_deletePreviousAssetsText.text = string.Empty;
			yield return (object)new WaitForSeconds(0.2f);
		}
		yield return (object)new WaitForSeconds(0.2f);
	}

	private IEnumerator ShowTips()
	{
		yield return (object)new WaitForSeconds(5f);
		if ((Object)(object)_connectionErrorText != (Object)null)
		{
			((Component)_connectionErrorText).gameObject.SetActive(true);
		}
	}

	private void ShowRestartButtons()
	{
		if ((Object)(object)_restartBtn != (Object)null)
		{
			_restartBtn.SetActive(true);
		}
		if ((Object)(object)_clearCacheAndRestartBtn != (Object)null)
		{
			_clearCacheAndRestartBtn.SetActive(true);
		}
	}

	public static void SoftRestart()
	{
		if (Application.version.IndexOf("1.2.5") >= 0 || Application.version.IndexOf("1.2.6") >= 0)
		{
			UnityUiService.Instance.CloseAll();
			UI_MaskCover maskCover = UnityUiService.Instance.maskCover;
			if (maskCover != null)
			{
				((GObject)maskCover).Dispose();
			}
			UnityUiService.Instance.maskCover = null;
			((GComponent)GRoot.inst).RemoveChildren();
			RestartManager.Instance.Restart();
		}
		else
		{
			GameController.Quit();
		}
	}

	public static void Restart()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 0 || (int)Application.platform == 7)
		{
			UnityUiService.Instance.CloseAll();
			UI_MaskCover maskCover = UnityUiService.Instance.maskCover;
			if (maskCover != null)
			{
				((GObject)maskCover).Dispose();
			}
			UnityUiService.Instance.maskCover = null;
			RestartManager.Instance.Restart();
		}
		else
		{
			GameController.Quit();
		}
	}

	public static void ClearCacheAndRestart()
	{
		string assetBundleFilePathWithoutLastSeparator = AssetsHelper.AssetBundleFilePathWithoutLastSeparator;
		if (Directory.Exists(assetBundleFilePathWithoutLastSeparator))
		{
			Directory.Delete(assetBundleFilePathWithoutLastSeparator, recursive: true);
		}
		if (File.Exists(NetworkService.tokenPath))
		{
			StreamWriter streamWriter = new StreamWriter(NetworkService.tokenPath, append: false, Encoding.UTF8);
			try
			{
				streamWriter.Write(string.Empty);
				streamWriter.Close();
			}
			catch (Exception)
			{
			}
		}
		Restart();
	}

	private IEnumerator LoadConfigs(int delayMs = 0)
	{
		if (delayMs > 0)
		{
			yield return (object)new WaitForSeconds((float)delayMs / 1000f);
		}
		if ((int)Application.platform != 0 && (int)Application.platform != 7)
		{
			((MonoBehaviour)this).StartCoroutine(ShowTips());
			string userAgent = (string.IsNullOrEmpty(GameController.UserAgent) ? "normal" : GameController.UserAgent);
			string url = HotUpdateProcess.Instance.RegionModel.Zone.url.config[0] + "/s/" + Application.version + "/" + userAgent + ".json";
			VersionManager.Instance.DownLoad(url).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
			{
				try
				{
					Dictionary<string, string> dictionary = JsonHelper.ToObject<Dictionary<string, string>>(uwr.downloadHandler.text);
					StartSentry();
				}
				catch (Exception)
				{
					((MonoBehaviour)this).StartCoroutine(LoadConfigs(500));
				}
			}, (Action<Exception>)delegate
			{
				((MonoBehaviour)this).StartCoroutine(LoadConfigs(500));
			});
		}
		else
		{
			StartSentry();
		}
	}

	private void StartSentry()
	{
		PrepareAssets();
	}

	public static string GetErrorId()
	{
		string text = DateTimeHelper.Now.ToString("yyMMddHHmmss");
		return text + Mathf.RoundToInt((float)Random.Range(0, 999)).ToString().PadLeft(3, '0');
	}

	private async void PrepareAssets()
	{
		(await VersionManager.Instance.CopyAssetsToPersistentFolder()).Then((Action)InitAssets).Catch((Action<Exception>)delegate(Exception ex)
		{
			string errorId = GetErrorId();
			string text = "解压缩资源文件失败，错误[ID:" + errorId + "]:" + ex.Message + "\n\n联系客服反馈问题时请提供本界面截图。\n可尝试重启游戏看是否能正常进入游戏。\n\n-------\n古卜林游戏";
			_errorText.text = text;
			((Component)_errorText).gameObject.SetActive(true);
			ShowRestartButtons();
			Debug.LogException(ex);
		});
	}

	private void InitAssets()
	{
		try
		{
			AssetsManager.Instance.Init();
			LoadUpdateScene();
		}
		catch (Exception ex)
		{
			string errorId = GetErrorId();
			string text = "加载资源文件失败，错误[ID:" + errorId + "]:" + ex.Message + "\n\n联系客服反馈问题时请提供本界面截图。\n可尝试重启游戏看是否能正常进入游戏。\n\n-------\n古卜林游戏";
			_errorText.text = text;
			((Component)_errorText).gameObject.SetActive(true);
			ShowRestartButtons();
			Debug.LogException(ex);
		}
	}

	private void LoadUpdateScene()
	{
		StartUpMono.LoadScene(StartUpMono.eSceneName.Update);
	}
}
