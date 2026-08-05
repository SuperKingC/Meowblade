using Assets.Scripts.UI;
using GvG2.Common.Models;
using UnityEngine;

namespace GvG2;

public class IslandTimeCounter : MonoBehaviour
{
	private int TargetTime = 0;

	private TextMesh[] Texts;

	private IslandStateManager IslandStateManager;

	private eIslandState LastState;

	public void Init(IslandStateManager parentManager)
	{
		Transform val = ((Component)this).transform.Find("counting/number");
		Texts = ((Component)val).GetComponentsInChildren<TextMesh>();
		SetText("");
		IslandStateManager = parentManager;
		RefreshCounting();
	}

	public void RefreshCounting()
	{
		LastState = IslandStateManager.IslandSummary.IslandUIState;
		if (LastState == eIslandState.WaitingFight)
		{
			TargetTime = IslandStateManager.IslandSummary.IslandAllowFightingTimestamp;
		}
		else if (LastState == eIslandState.Fighting)
		{
			TargetTime = IslandStateManager.IslandSummary.IslandCloseTimestamp;
		}
		else
		{
			TargetTime = -1;
		}
	}

	private void SetText(string text)
	{
		TextMesh[] texts = Texts;
		foreach (TextMesh val in texts)
		{
			val.text = text;
		}
	}

	private void FixedUpdate()
	{
		if (TargetTime == -1)
		{
			return;
		}
		int num = TargetTime - (int)GameController.Instance.GetServerTime();
		if (num < 0)
		{
			if (LastState != IslandStateManager.IslandSummary.IslandUIState)
			{
				LastState = IslandStateManager.IslandSummary.IslandUIState;
				IslandStateManager.UpdateState();
			}
			num = 0;
		}
		if (LastState == eIslandState.WaitingFight)
		{
			SetText(UiHelper.ParseTime(num));
		}
	}
}
