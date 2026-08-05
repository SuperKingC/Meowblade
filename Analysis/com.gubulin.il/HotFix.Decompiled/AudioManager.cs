using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	[SerializeField]
	private AudioClip[] _audioClips;

	[SerializeField]
	private CustomAudioSource _audioSourcePrefab;

	private Queue<CustomAudioSource> _audioSourcesQueue = new Queue<CustomAudioSource>();

	private Dictionary<string, AudioClip> _audioClipsDict = new Dictionary<string, AudioClip>();

	private CustomAudioSource _musicAudiosource;

	public CustomAudioSource MusicAudioSource
	{
		get
		{
			return _musicAudiosource;
		}
		set
		{
			_musicAudiosource = value;
		}
	}

	private void Awake()
	{
		Instance = this;
		for (int i = 0; i < 20; i++)
		{
			CreateAudioSource();
		}
		AudioClip[] audioClips = _audioClips;
		foreach (AudioClip val in audioClips)
		{
			_audioClipsDict.Add(((Object)val).name, val);
		}
	}

	private void CreateAudioSource()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		CustomAudioSource customAudioSource = Object.Instantiate<CustomAudioSource>(_audioSourcePrefab, ((Component)this).transform.position, Quaternion.identity);
		_audioSourcesQueue.Enqueue(customAudioSource);
		((Component)customAudioSource).transform.SetParent(((Component)this).transform);
	}

	public CustomAudioSource Play2dSound(string soundKey, int volume, bool looping = false)
	{
		if (_audioClipsDict.ContainsKey(soundKey) && _audioSourcesQueue.Count > 0)
		{
			CustomAudioSource customAudioSource = _audioSourcesQueue.Dequeue();
			customAudioSource.PlaySound(_audioClipsDict[soundKey], volume, looping);
			return customAudioSource;
		}
		return null;
	}

	public CustomAudioSource Play3dSound(string soundKey, int volume, GameObject sourceObj, bool looping = false)
	{
		if (_audioClipsDict.ContainsKey(soundKey) && _audioSourcesQueue.Count > 0)
		{
			CustomAudioSource customAudioSource = _audioSourcesQueue.Dequeue();
			customAudioSource.PlaySound3dFollow(_audioClipsDict[soundKey], volume, sourceObj, looping);
			return customAudioSource;
		}
		return null;
	}

	public CustomAudioSource Play3dSound(string soundKey, int volume, Vector3 position, bool looping = false)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (_audioClipsDict.ContainsKey(soundKey) && _audioSourcesQueue.Count > 0)
		{
			CustomAudioSource customAudioSource = _audioSourcesQueue.Dequeue();
			customAudioSource.PlaySound3dStatic(_audioClipsDict[soundKey], volume, position, looping);
			return customAudioSource;
		}
		return null;
	}

	public void AudioSourceEndedCallback(CustomAudioSource audioSource)
	{
		_audioSourcesQueue.Enqueue(audioSource);
	}
}
