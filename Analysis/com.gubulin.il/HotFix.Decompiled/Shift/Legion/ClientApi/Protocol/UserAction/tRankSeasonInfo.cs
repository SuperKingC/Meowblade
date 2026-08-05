using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class tRankSeasonInfo
{
	public int Id { get; set; }

	public int TurnId { get; set; }

	public string Name { get; set; }

	public List<BigZoneInfo> BigZone { get; set; }

	public List<RankDataHelper.tRankStartGame> TurnsInfo { get; set; }

	public int StartAtTimestamp { get; set; }

	public int EndAtTimestamp { get; set; }

	public List<tRankBaseBonus> ScoreBonus { get; set; } = new List<tRankBaseBonus>();

	public BuffConfig BuffConfig { get; set; }

	public BigZoneInfo GetSomeUserIdBigZoneInfo(int userId)
	{
		if (BigZone == null)
		{
			return null;
		}
		BigZoneInfo bigZoneInfo = null;
		for (int i = 0; i < BigZone.Count; i++)
		{
			if (BigZone[i].UserId_StartIdx <= userId && BigZone[i].UserId_EndIdx >= userId)
			{
				bigZoneInfo = BigZone[i];
				break;
			}
		}
		if (bigZoneInfo != null)
		{
			bigZoneInfo.BigZone = BigZone;
		}
		return bigZoneInfo;
	}

	public RankDataHelper.tRankStartGame GetRankStartGameInfo()
	{
		RankDataHelper.tRankStartGame tRankStartGame = null;
		if (Id != -1 && TurnsInfo != null)
		{
			for (int i = 0; i < TurnsInfo.Count; i++)
			{
				if (TurnsInfo[i].Id == TurnId)
				{
					tRankStartGame = TurnsInfo[i];
					break;
				}
			}
		}
		if (tRankStartGame == null)
		{
			if (TurnsInfo == null)
			{
				tRankStartGame = new RankDataHelper.tRankStartGame();
				tRankStartGame.StartAtTimestamp = 0;
				tRankStartGame.EndAtTimestamp = 0;
				return tRankStartGame;
			}
			int num = (int)GameController.Instance.GetServerTime();
			TurnsInfo.Sort(RankDataHelper.TurnsInfoSortByStartAt);
			for (int j = 0; j < TurnsInfo.Count; j++)
			{
				int startAtTimestamp = TurnsInfo[j].StartAtTimestamp;
				if (num < startAtTimestamp)
				{
					tRankStartGame = TurnsInfo[j];
					break;
				}
			}
			if (tRankStartGame == null)
			{
				tRankStartGame = TurnsInfo[TurnsInfo.Count - 1];
			}
			return tRankStartGame;
		}
		return tRankStartGame;
	}

	public string GetDisplayName()
	{
		Match arg = Regex.Match(Name, "S\\d*");
		string desc = LanguagesManager.GetDesc("CsharpRankSeasonName");
		return $"{desc} {arg}";
	}

	public string GetDisplayDuration()
	{
		string text = DateTimeHelper.Parse(StartAtTimestamp).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/MM/dd HH:mm");
		string text2 = DateTimeHelper.Parse(EndAtTimestamp).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/MM/dd HH:mm");
		return text + " - " + text2;
	}
}
