using System;
using System.Collections;
using FairyGUI;
using GvG2.Common.Models;
using HotFix.Sources.Base.Scripts.UI.PvpSelectSoldiers;
using HotFix.Sources.Base.Scripts.Utils;
using UI.GvGWorldMap2;
using UnityEngine;

namespace GvG2;

public class MapVfxManager
{
	private Transform Container;

	private UI_GvGWorldMap2 MainUI;

	public MapVfxManager(UI_GvGWorldMap2 mainUI, GameObject GvGWorldMap, MapDataManager mapDataManager)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		MainUI = mainUI;
		Transform transform = new GameObject("HighlightContainer").transform;
		transform.SetParent(GvGWorldMap.transform, false);
		transform.localPosition = Vector3.zero;
		Container = transform;
	}

	public void HighlightIsland(Island island)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = GvGWorldMapController.Instance.InstantiateFromPrefab("highlight");
		val.transform.SetParent(Container, false);
		val.transform.localPosition = island.IslandObject.transform.localPosition;
		((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(DelayRemoveHighlight(val));
	}

	public void LaunchLightBallFromIsland(Island island, int targetCampId, Action OnFinished)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)island.IslandPlane == (Object)null)
		{
			OnFinished?.Invoke();
			return;
		}
		if (targetCampId < 1 || targetCampId > MainUI.CampScore.List.numItems)
		{
			ILRuntimeDebug.LogError($"LaunchLightBallFromIsland: 找不到对应的 CampId = {targetCampId}");
			return;
		}
		GObject child = ((GComponent)MainUI).GetChild($"CampPos{targetCampId}");
		if (child == null)
		{
			ILRuntimeDebug.LogError($"LaunchLightBallFromIsland: 界面中找不到相应 CampId={targetCampId} 的CampPos");
			return;
		}
		Vector2 xy = child.xy;
		Vector2 startPos = EffectHelper.WorldToFguiPos(island.IslandObject.transform.position);
		((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(PlayLightBallLaunch(startPos, xy, OnFinished));
	}

	private IEnumerator DelayRemoveHighlight(GameObject highlight)
	{
		yield return (object)new WaitForSeconds(3f);
		if (!((Object)(object)highlight == (Object)null))
		{
			highlight.SetActive(false);
			Object.Destroy((Object)(object)highlight);
		}
	}

	private IEnumerator PlayLightBallLaunch(Vector2 startPos, Vector2 targetPos, Action OnFinished)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		LightBall lightBall = new LightBall(startPos, 100f);
		LightBall_Fusion fusion = new LightBall_Fusion(((GObject)lightBall.Container).xy, 100f);
		((GComponent)MainUI).AddChild((GObject)(object)lightBall.Container);
		((GComponent)MainUI).AddChild((GObject)(object)fusion.Container);
		float effectTime = 0f;
		Vector2 delta = startPos - targetPos;
		while (effectTime < 1.2f)
		{
			yield return (object)new WaitForFixedUpdate();
			if (((GObject)MainUI).isDisposed)
			{
				yield break;
			}
			effectTime += Time.deltaTime;
			if (effectTime > 1.2f)
			{
				effectTime = 1.2f;
			}
			float progress = effectTime / 1.2f;
			progress = 1f - Mathf.Pow(progress, 6f);
			lightBall.Scale = progress * 0.6f + 0.4f;
			lightBall.Position = delta * progress + targetPos;
		}
		yield return (object)new WaitForSeconds(0.1f);
		lightBall.Destroy();
		fusion.Destroy();
		OnFinished?.Invoke();
	}
}
