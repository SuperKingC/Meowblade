using System.Collections.Generic;

namespace HotFix.Sources.Base.Scripts.AudioManager;

public class PlayBattleAudioPreparationDic
{
	public string AudioSourceName;

	public int MaxCount;

	public int Priority;

	public List<PlayBattleAudioPreparation> AllAudioPreparations;

	public bool IsPlayInOrder;

	public float PlayDelayTime;

	public PlayBattleAudioPreparationDic(string audioName, int maxCount, int priority, bool isPlayInOrder, float delayTime)
	{
		AudioSourceName = audioName;
		MaxCount = maxCount;
		Priority = priority;
		IsPlayInOrder = isPlayInOrder;
		AllAudioPreparations = new List<PlayBattleAudioPreparation>();
		PlayDelayTime = delayTime;
	}

	public void ClearAllAudioPreparations()
	{
		for (int num = AllAudioPreparations.Count - 1; num >= 0; num--)
		{
			if (!AllAudioPreparations[num].Added)
			{
				AllAudioPreparations[num].Added = true;
			}
		}
	}

	public void ClearAddedAudioPreparations()
	{
		for (int num = AllAudioPreparations.Count - 1; num >= 0; num--)
		{
			if (AllAudioPreparations[num].Added)
			{
				AllAudioPreparations.RemoveAt(num);
			}
		}
	}
}
