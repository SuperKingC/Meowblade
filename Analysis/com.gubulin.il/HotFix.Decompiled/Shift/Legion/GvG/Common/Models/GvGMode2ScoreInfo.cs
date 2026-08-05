using UnityEngine;

namespace Shift.Legion.GvG.Common.Models;

public class GvGMode2ScoreInfo
{
	public int UserId = -1;

	public int Kill = 0;

	public int Loss = 0;

	public int HoldingPoints = 0;

	public int CampId = -1;

	public int BestKillCount = 0;

	public int CurBestKillCount = 0;

	public int FinalCampRank = -1;

	public int FinalScore = -1;

	public int RankInSelfCamp = -1;

	public int ScorePar
	{
		get
		{
			if (FinalCampRank == 1)
			{
				return 2000;
			}
			if (FinalCampRank == 2)
			{
				return 1500;
			}
			if (FinalCampRank == 3)
			{
				return 1250;
			}
			if (FinalCampRank == 4)
			{
				return 1000;
			}
			return 0;
		}
	}

	public void CalcFinalScore()
	{
		int num = (int)Mathf.Ceil((float)Kill / 10f);
		if (num >= 1500)
		{
			num = 1500;
		}
		int num2 = HoldingPoints;
		if (num2 >= 1000)
		{
			num2 = 1000;
		}
		FinalScore = (int)Mathf.Ceil((float)((num + num2) * ScorePar) / 1000f);
	}
}
