using System;
using GvG2.Common.Models;
using UnityEngine;

namespace GvG2;

public class IslandStateManager
{
	private Island Island;

	public IslandSummary IslandSummary;

	private Action OnChangeState;

	private bool NeedsHighlight;

	public IslandStateManager(Island parentIsland, Action onChangeState)
	{
		Island = parentIsland;
		OnChangeState = onChangeState;
	}

	public void SetState(IslandSummary islandSummary)
	{
		IslandSummary = islandSummary;
		OnChangeState();
		NeedsHighlight = true;
		Render();
	}

	public void UpdateState()
	{
		OnChangeState();
		Render();
	}

	public void Render(GameObject islandPlane = null)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)islandPlane == (Object)null)
		{
			islandPlane = Island.IslandPlane;
		}
		if ((Object)(object)islandPlane == (Object)null)
		{
			return;
		}
		eIslandState islandUIState = IslandSummary.IslandUIState;
		Transform val = islandPlane.transform.Find("plane/ui");
		Transform val2 = val.Find("island_state");
		if (islandUIState == eIslandState.Peace)
		{
			if ((Object)(object)val2 != (Object)null && (Object)(object)((Component)val2).gameObject != (Object)null)
			{
				Object.Destroy((Object)(object)((Component)val2).gameObject);
			}
			return;
		}
		if ((Object)(object)val2 == (Object)null)
		{
			string text = ((Island.Props.Sprite == "i_big") ? "_big" : "_small");
			val2 = GvGWorldMapController.Instance.InstantiateFromPrefab("island_state" + text).transform;
			val2.SetParent(val, false);
			((Object)val2).name = "island_state";
			val2.localPosition = Vector3.zero;
			val2.localScale = Vector3.one;
			val2.localRotation = Quaternion.Euler(Vector3.zero);
			IslandTimeCounter islandTimeCounter = ((Component)val2.Find("state")).gameObject.AddComponent<IslandTimeCounter>();
			islandTimeCounter.Init(this);
		}
		else
		{
			IslandTimeCounter component = ((Component)val2.Find("state")).gameObject.GetComponent<IslandTimeCounter>();
			component.RefreshCounting();
		}
		bool flag = islandUIState == eIslandState.WaitingFight;
		bool active = islandUIState == eIslandState.Fighting;
		((Component)val2.Find("state/counting")).gameObject.SetActive(flag);
		((Component)val2.Find("state/attacking")).gameObject.SetActive(active);
		((Component)val2.Find("attack_vfx")).gameObject.SetActive(active);
		int islandScore = IslandSummary.IslandScore;
		bool flag2 = 100 <= islandScore && islandScore <= 200;
		bool flag3 = 250 <= islandScore && islandScore <= 400;
		bool flag4 = islandScore == 600;
		bool flag5 = islandScore == 1000;
		bool flag6 = flag2 || flag3 || flag4 || flag5;
		((Component)val2.Find("score/0")).gameObject.SetActive(flag2);
		((Component)val2.Find("score/1")).gameObject.SetActive(flag3);
		((Component)val2.Find("score/2")).gameObject.SetActive(flag4);
		((Component)val2.Find("score/3")).gameObject.SetActive(flag5);
		Transform val3 = val2.Find("score/score");
		((Component)val3).gameObject.SetActive(flag6);
		if (flag6)
		{
			GvGHelper.SetOutlineText(val3, $"{islandScore}");
			if (NeedsHighlight && flag)
			{
				NeedsHighlight = false;
				GvGWorldMapController.Instance.HighlightIsland(Island);
			}
		}
		else if (islandScore != -1)
		{
			ILRuntimeDebug.LogError($"岛屿积分错误： 岛屿ID={Island.Id} 积分={islandScore}");
		}
	}
}
