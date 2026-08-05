namespace HotFix.Sources.Base.Scripts.AudioManager;

public class PlayBattleAudioPreparation
{
	public string AudioSourceName;

	public int MaxCount;

	public int Priority;

	public float Volume;

	public bool Added;

	public float PlayDelayTime;

	public PlayBattleAudioPreparation(string audioName, int maxCount, int priority, float volume, float delayTime)
	{
		AudioSourceName = audioName;
		MaxCount = maxCount;
		Priority = priority;
		Volume = volume;
		Added = false;
		PlayDelayTime = delayTime;
	}
}
