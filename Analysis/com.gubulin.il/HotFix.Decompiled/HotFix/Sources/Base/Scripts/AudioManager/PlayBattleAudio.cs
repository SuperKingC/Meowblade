using UnityEngine;

namespace HotFix.Sources.Base.Scripts.AudioManager;

public class PlayBattleAudio
{
	public string AudioSourceName;

	public bool PlayStart;

	public bool PlayFinish;

	public float Volume;

	public float PlayStartTime;

	public float PlayDuration;

	private GameObject audioGameObject;

	public AudioSource audioSource;

	private PlayMode AudioPlayMode;

	private float PlayDelayTime;

	public PlayBattleAudio(string audioName, float volume, PlayMode playMode = PlayMode.PlayImmediately, float playDelayTime = 0f)
	{
		AudioSourceName = audioName;
		PlayStart = false;
		PlayFinish = false;
		Volume = volume;
		AudioPlayMode = playMode;
		PlayDelayTime = playDelayTime;
	}

	public void PlayBattleAudioReset(string audioName, float volume, PlayMode playMode = PlayMode.PlayImmediately, float playDelayTime = 0f)
	{
		AudioSourceName = audioName;
		PlayStart = false;
		PlayFinish = false;
		Volume = volume;
		AudioPlayMode = playMode;
		PlayStartTime = 0f;
		PlayDelayTime = playDelayTime;
		audioGameObject = null;
		audioSource = null;
		PlayDuration = 0f;
	}

	public void AddAudioSource(GameObject gameObject)
	{
		audioGameObject = gameObject;
		audioSource = audioGameObject.GetComponent<AudioSource>();
		PlayDuration = audioSource.clip.length;
	}

	public void TryToPlay(float time)
	{
		if (AudioPlayMode == PlayMode.PlayImmediately)
		{
			StartPlay(time);
		}
		else if (AudioPlayMode == PlayMode.PlayInOrder)
		{
			StartPlayInOrder(time);
		}
	}

	private void StartPlay(float time)
	{
		if (audioSource != null)
		{
			PlayStartTime = time;
			if ((Object)(object)audioSource.clip == (Object)null)
			{
				PlayFinish = true;
				return;
			}
			if (audioSource.isPlaying)
			{
				PlayFinish = true;
				return;
			}
			audioSource.volume = Mathf.Max(Mathf.Min(Volume, 1f), 0f);
			audioSource.Play();
			audioSource.spatialBlend = 1f;
			audioSource.dopplerLevel = 0f;
			audioSource.spread = 360f;
			PlayStart = true;
		}
	}

	private void StartPlayInOrder(float time)
	{
		if (audioSource == null)
		{
			return;
		}
		if (PlayStartTime <= 0f)
		{
			PlayStartTime = time;
		}
		if ((Object)(object)audioSource.clip == (Object)null)
		{
			PlayFinish = true;
			return;
		}
		if (audioSource.isPlaying)
		{
			PlayFinish = true;
			return;
		}
		float num = PlayStartTime + PlayDelayTime;
		if (time > num)
		{
			audioSource.volume = Mathf.Max(Mathf.Min(Volume, 1f), 0f);
			audioSource.Play();
			audioSource.spatialBlend = 1f;
			audioSource.dopplerLevel = 0f;
			audioSource.spread = 360f;
			PlayStart = true;
		}
	}

	public bool FinishPlay()
	{
		if (audioSource == null)
		{
			return PlayFinish;
		}
		if (Time.time <= PlayStartTime + PlayDelayTime + PlayDuration)
		{
			return PlayFinish;
		}
		audioSource.Stop();
		PlayFinish = true;
		return PlayFinish;
	}
}
