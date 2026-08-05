using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.AudioManager;

public class PlayBattleAudioList
{
	public string AudioSourceName;

	public List<PlayBattleAudio> AllBattleAudios;

	private int priority;

	private bool playInOrder;

	public int Priority
	{
		get
		{
			if (CurrentPlayingNum() > 0)
			{
				return priority;
			}
			return 5;
		}
	}

	public PlayMode AudioPlayMode
	{
		get
		{
			if (playInOrder)
			{
				return PlayMode.PlayInOrder;
			}
			return PlayMode.PlayImmediately;
		}
	}

	public float LatestPlayTime => GetLatestPlayTime();

	public int AllAudiosCount => CurrentPlayingNum();

	public PlayBattleAudioList(string audioSourceName, int priority, bool playInOrder = false)
	{
		AudioSourceName = audioSourceName;
		AllBattleAudios = new List<PlayBattleAudio>();
		this.priority = priority;
		this.playInOrder = playInOrder;
	}

	private float GetLatestPlayTime()
	{
		float num = 0f;
		for (int i = 0; i < AllBattleAudios.Count; i++)
		{
			if (AllBattleAudios[i].PlayStart && !AllBattleAudios[i].PlayFinish)
			{
				float playStartTime = AllBattleAudios[i].PlayStartTime;
				if (playStartTime > num)
				{
					num = playStartTime;
				}
			}
		}
		return num;
	}

	private int CurrentPlayingNum()
	{
		int num = 0;
		for (int i = 0; i < AllBattleAudios.Count; i++)
		{
			if (AllBattleAudios[i].PlayStart && !AllBattleAudios[i].PlayFinish)
			{
				num++;
			}
		}
		return num;
	}

	public void AllBattleAudiosAdd(PlayBattleAudio audio)
	{
		AllBattleAudios.Add(audio);
	}

	public List<AudioSource> ClearFinishedAudios()
	{
		List<AudioSource> list = new List<AudioSource>();
		for (int num = AllBattleAudios.Count - 1; num >= 0; num--)
		{
			if (AllBattleAudios[num].PlayStart)
			{
				if (AllBattleAudios[num].PlayFinish)
				{
					list.Add(AllBattleAudios[num].audioSource);
					AllBattleAudios.RemoveAt(num);
				}
				else if (AllBattleAudios[num].FinishPlay())
				{
					list.Add(AllBattleAudios[num].audioSource);
					AllBattleAudios.RemoveAt(num);
				}
			}
		}
		return list;
	}

	public void StartPlayAudios()
	{
		for (int i = 0; i < AllBattleAudios.Count; i++)
		{
			if (!AllBattleAudios[i].PlayStart)
			{
				AllBattleAudios[i].TryToPlay(Time.time);
			}
		}
	}
}
