using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.GiftOfLord;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.MainCity;

public class GiftOfLordEntrance : MonoBehaviour
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Constants
	{
		public const string UNLOCK_ENTRANCE_LEVEL_ID = "P520";

		public const string NAME = "GiftOfLordEntrance";
	}

	public static GiftOfLordEntrance Instance;

	private GameObject _open;

	private GameObject _close;

	private bool _entranceAvailable;

	private void Awake()
	{
		Instance = this;
		_open = ((Component)((Component)this).transform.Find("Open")).gameObject;
		_close = ((Component)((Component)this).transform.Find("Close")).gameObject;
	}

	private void Start()
	{
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", UpdateOnCompleteLevelId);
		GameManagers.Instance.AchievementManager.AddActionOnGiftOfLordRewardsStatusChange(UpdateRedNote);
		UpdateEntrance();
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", UpdateOnCompleteLevelId);
		GameManagers.Instance.AchievementManager.RemoveActionOnGiftOfLordRewardsStatusChange(UpdateRedNote);
	}

	private void UpdateOnCompleteLevelId(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (level.LevelId == "P520")
		{
			UpdateVisible();
		}
	}

	private void UpdateEntrance()
	{
		UpdateVisible();
		UpdateRedNote(GameManagers.Instance.AchievementManager.HasAnyPendingToClaimRewards());
	}

	private void UpdateVisible()
	{
		_entranceAvailable = UnlockLevelComplete();
		((Component)this).gameObject.SetActive(_entranceAvailable);
		static bool UnlockLevelComplete()
		{
			foreach (List<string> value in GameManagers.Instance.UserArchiveManager.GetLevelProgress().Values)
			{
				if (value.Contains("P520"))
				{
					return true;
				}
			}
			return false;
		}
	}

	private void UpdateRedNote(bool hasRewards)
	{
		_open.SetActive(hasRewards);
		_close.SetActive(!hasRewards);
	}

	public void OnClick()
	{
		if (_entranceAvailable)
		{
			UI_main_GiftOfLord.OpenPanel();
		}
	}
}
