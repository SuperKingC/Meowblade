using System.Collections;
using UnityEngine;

public class CustomAudioSource : MonoBehaviour
{
	private SoundType _soundType = SoundType.Sound2d;

	protected AudioSource _audioSource;

	protected bool _active = false;

	private GameObject _objToFollow;

	private void Awake()
	{
		_audioSource = ((Component)this).GetComponent<AudioSource>();
	}

	private void Update()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (!_active)
		{
			return;
		}
		switch (_soundType)
		{
		case SoundType.Sound2d:
			break;
		case SoundType.Sound3dFollow:
			if (Object.op_Implicit((Object)(object)_objToFollow))
			{
				((Component)this).transform.position = _objToFollow.transform.position;
			}
			break;
		case SoundType.Sound3dStatic:
			break;
		}
	}

	public virtual void PlaySound(AudioClip audioClip, int volume, bool looping)
	{
		_audioSource.loop = looping;
		_audioSource.volume = (float)volume / 100f;
		_audioSource.clip = audioClip;
		_audioSource.spatialBlend = 0f;
		_audioSource.Play();
		if (!looping)
		{
			((MonoBehaviour)AudioManager.Instance).StartCoroutine(SoundStopCoroutine(audioClip.length));
		}
		_active = true;
	}

	public virtual void PlaySound3dFollow(AudioClip audioClip, int volume, GameObject obj, bool looping)
	{
		_audioSource.loop = looping;
		_audioSource.volume = (float)volume / 100f;
		_audioSource.clip = audioClip;
		_audioSource.spatialBlend = 1f;
		_audioSource.Play();
		if (!looping)
		{
			((MonoBehaviour)AudioManager.Instance).StartCoroutine(SoundStopCoroutine(audioClip.length));
		}
		_objToFollow = obj;
		_active = true;
	}

	public virtual void PlaySound3dStatic(AudioClip audioClip, int volume, Vector3 pos, bool looping)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		_audioSource.loop = looping;
		_audioSource.volume = (float)volume / 100f;
		_audioSource.clip = audioClip;
		_audioSource.spatialBlend = 1f;
		_audioSource.Play();
		if (!looping)
		{
			((MonoBehaviour)AudioManager.Instance).StartCoroutine(SoundStopCoroutine(audioClip.length));
		}
		_active = true;
		((Component)this).transform.position = pos;
	}

	public void StopSound()
	{
		_audioSource.Stop();
		AudioManager.Instance.AudioSourceEndedCallback(this);
	}

	private IEnumerator SoundStopCoroutine(float time)
	{
		yield return (object)new WaitForSeconds(time);
		_active = false;
		AudioManager.Instance.AudioSourceEndedCallback(this);
	}
}
