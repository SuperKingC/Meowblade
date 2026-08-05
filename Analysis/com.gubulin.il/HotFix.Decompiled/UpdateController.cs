using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using HotFix;
using ObjectPool;
using RSG;
using UI.UpdateResources;
using UnityEngine;

public class UpdateController : MonoBehaviour
{
	public static UpdateController Instance;

	public UI_UpdateResources UpdateResourcesPanel;

	public Coroutine UpdateResources;

	private GTweener _updateBarTweener;

	private int _noDataIncomingTick;

	private void Awake()
	{
		Instance = this;
		CallActionAfterPublishResourcesLoaded(delegate
		{
			UnityUiService.Instance.OpenPanel(UI_UpdateResources.Name, new Dictionary<string, object> { { "UpdateController", this } }, multiMode: false, ignoreQueue: false, delegate(Exception ex)
			{
				Debug.LogException(ex);
				((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
				HotFix_Utils.Restart();
			});
		});
		UiAudioManager.Instance.BgmAndSoundSwitchInit();
	}

	private void OnDestroy()
	{
		if ((Object)(object)VersionManager.Instance != (Object)null)
		{
			((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
		}
		((MonoBehaviour)this).StopAllCoroutines();
		Instance = null;
	}

	public void OnResourcesReady()
	{
		StartUpMono.LoadScene(StartUpMono.eSceneName.Game);
	}

	private static void CallActionAfterPublishResourcesLoaded(Action action)
	{
		PooledList<Promise<AssetBundle>> list = ObjectPool<PooledList<Promise<AssetBundle>>>.Spawn((Func<PooledList<Promise<AssetBundle>>>)(() => new PooledList<Promise<AssetBundle>>()));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResources/PublicResources_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResources/PublicResources_res.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResourcesRGB/PublicResourcesRGB_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResourcesRGB/PublicResourcesRGB_res.ab"));
		Promise<AssetBundle>.All((IEnumerable<IPromise<AssetBundle>>)list).Then((Action<IEnumerable<AssetBundle>>)delegate(IEnumerable<AssetBundle> assetBundles)
		{
			AssetBundle val = null;
			AssetBundle val2 = null;
			AssetBundle val3 = null;
			AssetBundle val4 = null;
			int num = 0;
			foreach (AssetBundle assetBundle in assetBundles)
			{
				switch (num)
				{
				case 0:
					val = assetBundle;
					break;
				case 1:
					val2 = assetBundle;
					break;
				case 2:
					val3 = assetBundle;
					break;
				case 3:
					val4 = assetBundle;
					break;
				}
				num++;
			}
			if (val != null && val2 != null)
			{
				UIPackage.AddPackage(val, val2);
			}
			else
			{
				Debug.LogWarning((object)"FGUI publicresource load failed.");
				((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
				LoadController.ClearCacheAndRestart();
			}
			if (val3 != null && val4 != null)
			{
				UIPackage.AddPackage(val3, val4);
				action();
			}
			else
			{
				Debug.LogWarning((object)"FGUI publicresourcergb load failed.");
				((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
				LoadController.ClearCacheAndRestart();
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			Debug.LogException(ex);
			((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
			HotFix_Utils.Restart();
		})
			.Finally((Action)delegate
			{
				list.UnSpawn();
			});
	}

	public void OpenUpdateResources()
	{
		if (UpdateResourcesPanel != null)
		{
			UpdateResources = ((MonoBehaviour)this).StartCoroutine(UpdateResourcesBar());
		}
	}

	public void CloseUpdateResources()
	{
		if (UpdateResources != null)
		{
			((MonoBehaviour)this).StopCoroutine(UpdateResources);
			UpdateResources = null;
		}
	}

	private IEnumerator UpdateResourcesBar()
	{
		UpdateResourcesPanel.pageSwitch.selectedIndex = 0;
		while (true)
		{
			if (UpdateResourcesPanel.curDataSize != VersionManager.Instance._currentDownLoadBytes)
			{
				_noDataIncomingTick = 0;
				UpdateResourcesPanel.curDataSize = VersionManager.Instance._currentDownLoadBytes;
				float end = (float)UpdateResourcesPanel.curDataSize * 1f / (float)UpdateResourcesPanel.AllDataSize * 100f;
				GTweener updateBarTweener = _updateBarTweener;
				if (updateBarTweener != null)
				{
					updateBarTweener.Kill(false);
				}
				_updateBarTweener = ((GProgressBar)UpdateResourcesPanel.updateProgressBar).TweenValue((double)end, 0.5f).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
				{
					float num = (float)UpdateResourcesPanel.AllDataSize / 1048576f;
					float num2 = (float)UpdateResourcesPanel.curDataSize / 1048576f;
					UpdateResourcesPanel.curBarValue = Mathf.RoundToInt((float)tweener.value.d);
					float curBarValue = UpdateResourcesPanel.curBarValue;
					string arg = curBarValue.ToString();
					((GObject)UpdateResourcesPanel.updateProgressBar.progress).text = $"{num2:F}MB/{num:F}MB {arg}%";
				});
			}
			else
			{
				_noDataIncomingTick++;
			}
			if (UpdateResourcesPanel.curDataSize >= UpdateResourcesPanel.AllDataSize)
			{
				break;
			}
			if (_noDataIncomingTick > 60)
			{
				UpdateResourcesPanel.ShowRestartTips("检测到超过30秒未下载到任何数据，是否要重新载入游戏再试？");
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}
}
