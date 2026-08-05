using System;
using HotFix;
using UnityEngine;

public class UnityAudioClip : MonoBehaviour, IAudioClip, IEventListener, IAudioClipNameListener, IAudioVolumeListener, IPooled
{
	private GameEntity _entity;

	private AudioSource _audioSource;

	private string _audioClipName;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		_entity = entity;
		_audioSource = ((Component)this).GetComponent<AudioSource>();
		_audioSource.playOnAwake = false;
		_audioClipName = "";
	}

	public void Play()
	{
		if (!_audioSource.isPlaying)
		{
			_audioSource.Play();
		}
	}

	public void Restart()
	{
		Stop();
		Play();
	}

	public void Pause()
	{
		if (_audioSource.isPlaying)
		{
			_audioSource.Pause();
		}
	}

	public void Stop()
	{
		if (_audioSource.isPlaying)
		{
			_audioSource.Stop();
		}
	}

	public void RegisterListeners()
	{
		_entity.AddAudioClipNameListener(this);
		_entity.AddAudioVolumeListener(this);
	}

	public void UnregisterListeners()
	{
		_entity.RemoveAudioClipNameListener(this);
		_entity.RemoveAudioVolumeListener(this);
	}

	public void OnAudioClipName(GameEntity entity, string value)
	{
		if (!(_audioClipName == entity.audioClipName.value))
		{
			Stop();
			AssetsManager.Instance.UnloadAsset<AudioClip>(_audioClipName);
			_audioClipName = "";
			AssetsManager.Instance.LoadAsset<AudioClip>(entity.audioClipName.value).Then((Action<AudioClip>)delegate(AudioClip clip)
			{
				_audioSource.clip = clip;
				_audioClipName = entity.audioClipName.value;
				Play();
			});
		}
	}

	private void OnDestroy()
	{
		if (_audioClipName != null && _audioClipName != "")
		{
			AssetsManager.Instance.UnloadAsset<AudioClip>(_audioClipName);
		}
	}

	public void OnAudioVolume(GameEntity entity, int value)
	{
		_audioSource.volume = Mathf.Max(Mathf.Min((float)value / 100f, 1f), 0f);
	}

	public void OnInstantiate()
	{
	}

	public void OnUnSpawn()
	{
		if (_entity != null)
		{
			Stop();
			_entity = null;
		}
	}

	public void UnSpawn()
	{
	}
}
