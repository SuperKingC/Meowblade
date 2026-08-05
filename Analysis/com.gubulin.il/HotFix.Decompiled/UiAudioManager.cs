using System;
using System.Collections.Generic;
using FairyGUI;
using ObjectPool;
using RSG;
using Shift.Legion.Common.Services;
using UnityEngine;

public class UiAudioManager : MonoBehaviour
{
	public enum BgmType
	{
		LevelUp,
		MainCity,
		Login
	}

	public enum SoldierVoiceType
	{
		Onomatopoeia,
		Voice
	}

	private class AudioCache
	{
		public AudioSource action;

		public bool isLoop;

		public string auidoName;
	}

	public static UiAudioManager Instance;

	[SerializeField]
	private AudioSource backgroundMusicAudioSource;

	[SerializeField]
	private AudioSource backgroundSoundAudioSource;

	[SerializeField]
	private AudioSource soundEffectAudioSource;

	private List<string> privateAudios;

	private List<string> privateBgm;

	public float MaxUiBgmVolume = 0.5f;

	public float MiddleBgmVolume = 0.2f;

	public float MaxSoundEffectVolume = 1f;

	public bool bgmSwitch;

	public bool soundSwitch;

	private Dictionary<string, List<AudioCache>> _loadingAudios;

	public static Dictionary<string, int> UiPublicResourcesDic = new Dictionary<string, int>();

	private void Awake()
	{
		MaxUiBgmVolume = 0.5f;
		MiddleBgmVolume = 0.2f;
		MaxSoundEffectVolume = 1f;
		_loadingAudios = new Dictionary<string, List<AudioCache>>();
		Instance = this;
		privateAudios = new List<string>
		{
			"BattleWinBgm", "SoldierUp", "BattleFail", "BoxFlashing", "Building4Bgs", "ConstructionSite", "Ha", "LordAppear", "MiniLevelWin", "Oh",
			"Trombone", "portal", "equipSlotUnlock"
		};
		privateBgm = new List<string> { "LevelUpBgm", "MaincityBGM1", "MaincityBGM2", "loginBgm" };
		backgroundMusicAudioSource = ((Component)this).gameObject.AddComponent<AudioSource>();
		backgroundSoundAudioSource = ((Component)this).gameObject.AddComponent<AudioSource>();
		soundEffectAudioSource = ((Component)this).gameObject.AddComponent<AudioSource>();
	}

	private void Start()
	{
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", BuildingUpgradeCompleteTip);
		SetUiBgmVolume(MaxUiBgmVolume);
		SetSoundEffectVolume(MaxSoundEffectVolume);
		BgmAndSoundSwitchInit();
	}

	public static void UnloadAudioTest(string uiBagName = "PublicResourceAudio")
	{
		if (!UiPublicResourcesDic.ContainsKey(uiBagName) || uiBagName == "PublicResources")
		{
			return;
		}
		int num = UiPublicResourcesDic[uiBagName];
		if (num > 1)
		{
			UiPublicResourcesDic[uiBagName]--;
			return;
		}
		string text = "FGUI/" + uiBagName + "/" + uiBagName;
		AssetsManager.Instance.UnloadAssetBundle(text + "_desc.ab");
		if (AssetsManager.Instance.IsAssetBundleExists(text + "_res.ab"))
		{
			AssetsManager.Instance.UnloadAssetBundle(text + "_res.ab");
		}
		if (!AssetsManager.Instance.IsAssetBundleInUsing(text + "_desc.ab"))
		{
			UiPublicResourcesDic.Remove(uiBagName);
			UIPackage.RemovePackage(uiBagName);
		}
	}

	private void LoadAudioTest(AudioSource action, bool isLoop, string auidoName, string uiBagName = "PublicResourceAudio")
	{
		if ((Object)(object)action == (Object)null)
		{
			return;
		}
		if (UiPublicResourcesDic.ContainsKey(uiBagName))
		{
			UiPublicResourcesDic[uiBagName]++;
			action.clip = LoadAudioFromUiPack(auidoName);
			action.loop = isLoop;
			action.Play();
			ScriptApi.CreateTimer(action.clip.length, delegate
			{
				UnloadAudioTest(uiBagName);
			});
			return;
		}
		AudioCache item = new AudioCache
		{
			action = action,
			isLoop = isLoop,
			auidoName = auidoName
		};
		if (_loadingAudios.ContainsKey(uiBagName))
		{
			_loadingAudios[uiBagName].Add(item);
			return;
		}
		_loadingAudios.Add(uiBagName, new List<AudioCache> { item });
		PooledList<Promise<AssetBundle>> list = ObjectPool<PooledList<Promise<AssetBundle>>>.Spawn((Func<PooledList<Promise<AssetBundle>>>)(() => new PooledList<Promise<AssetBundle>>()));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/" + uiBagName + "/" + uiBagName + "_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/" + uiBagName + "/" + uiBagName + "_res.ab"));
		Promise<AssetBundle>.All((IEnumerable<IPromise<AssetBundle>>)list).Then((Action<IEnumerable<AssetBundle>>)delegate(IEnumerable<AssetBundle> assetBundles)
		{
			AssetBundle val = null;
			AssetBundle val2 = null;
			int num = 0;
			foreach (AssetBundle assetBundle in assetBundles)
			{
				switch (num)
				{
				case 0:
					val = assetBundle;
					break;
				case 1:
					val2 = assetBundle;
					break;
				}
				num++;
			}
			if (val != null && val2 != null)
			{
				UIPackage.AddPackage(val, val2);
				List<AudioCache> list2 = _loadingAudios[uiBagName];
				_loadingAudios.Remove(uiBagName);
				{
					foreach (AudioCache item2 in list2)
					{
						if (UiPublicResourcesDic.ContainsKey(uiBagName))
						{
							UiPublicResourcesDic[uiBagName]++;
						}
						else
						{
							UiPublicResourcesDic.Add(uiBagName, 1);
						}
						if ((Object)(object)item2.action == (Object)null)
						{
							if (!item2.isLoop)
							{
								UnloadAudioTest(uiBagName);
							}
							break;
						}
						item2.action.clip = LoadAudioFromUiPack(item2.auidoName);
						item2.action.loop = item2.isLoop;
						item2.action.Play();
						if (!item2.isLoop)
						{
							ScriptApi.CreateTimer(item2.action.clip.length, delegate
							{
								UnloadAudioTest(uiBagName);
							});
						}
					}
					return;
				}
			}
			Debug.LogError((object)"FGUI PublicResourceAudio load failed.");
		}).Finally((Action)delegate
		{
			list.UnSpawn();
		});
	}

	public void BgmAndSoundSwitchInit()
	{
		if (GameLocalDataManager.HasKey("BgmSwitch"))
		{
			if (GameLocalDataManager.GetBool("BgmSwitch"))
			{
				((Behaviour)backgroundMusicAudioSource).enabled = true;
				bgmSwitch = true;
			}
			else
			{
				((Behaviour)backgroundMusicAudioSource).enabled = false;
				bgmSwitch = false;
			}
		}
		else
		{
			((Behaviour)backgroundMusicAudioSource).enabled = true;
			bgmSwitch = true;
			GameLocalDataManager.SetBool("BgmSwitch", value: true);
		}
		if (GameLocalDataManager.HasKey("SoundSwitch"))
		{
			if (GameLocalDataManager.GetBool("SoundSwitch"))
			{
				((Behaviour)backgroundSoundAudioSource).enabled = true;
				((Behaviour)soundEffectAudioSource).enabled = true;
				GRoot.inst.EnableSound();
				soundSwitch = true;
			}
			else
			{
				((Behaviour)backgroundSoundAudioSource).enabled = false;
				((Behaviour)soundEffectAudioSource).enabled = false;
				GRoot.inst.DisableSound();
				soundSwitch = false;
			}
		}
		else
		{
			GRoot.inst.EnableSound();
			((Behaviour)backgroundSoundAudioSource).enabled = true;
			((Behaviour)soundEffectAudioSource).enabled = true;
			soundSwitch = true;
			GameLocalDataManager.SetBool("SoundSwitch", value: true);
		}
	}

	public void UpdateBgmSwitch(bool _switch)
	{
		((Behaviour)backgroundMusicAudioSource).enabled = _switch;
		bgmSwitch = _switch;
	}

	public void UpdateSoundSwitch(bool _switch)
	{
		backgroundSoundAudioSource.clip = null;
		soundEffectAudioSource.clip = null;
		((Behaviour)backgroundSoundAudioSource).enabled = _switch;
		((Behaviour)soundEffectAudioSource).enabled = _switch;
		if (_switch)
		{
			GRoot.inst.EnableSound();
		}
		else
		{
			GRoot.inst.DisableSound();
		}
		soundSwitch = _switch;
	}

	private string GetUiBgmName(BgmType type)
	{
		string result = "";
		switch (type)
		{
		case BgmType.LevelUp:
			result = "LevelUpBgm";
			break;
		case BgmType.MainCity:
		{
			int num = Random.Range(1, 3);
			result = $"MaincityBGM{num}";
			break;
		}
		case BgmType.Login:
			result = "loginBgm";
			break;
		}
		return result;
	}

	private void BuildingUpgradeCompleteTip(string buildingType)
	{
		Instance.PlaySoundEffect("Ding");
	}

	public void SetMainCityBgmVolume(float _value)
	{
		backgroundMusicAudioSource.volume = _value;
	}

	private string GetUiPackName(string audioName)
	{
		string result = "PublicResources";
		if (privateAudios.Contains(audioName))
		{
			result = "PublicResourceAudio";
		}
		else if (privateBgm.Contains(audioName))
		{
			result = "PublicResourceBgm";
		}
		return result;
	}

	private AudioClip LoadAudioFromUiPack(string audioName)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		string uiPackName = GetUiPackName(audioName);
		return ((NAudioClip)UIPackage.GetItemAssetByURL("ui://" + uiPackName + "/" + audioName))?.nativeClip;
	}

	public void LoadSoundsForSfx(GameObject sfxGameObject, string audioName, bool playLoop = false, float volume = 1f, bool limitForScene = false)
	{
		if (soundSwitch)
		{
			AudioClip clip = LoadAudioFromUiPack(audioName);
			AudioSource val = sfxGameObject.GetComponent<AudioSource>();
			if ((Object)(object)val == (Object)null)
			{
				val = sfxGameObject.AddComponent<AudioSource>();
			}
			if ((Object)(object)val == (Object)null)
			{
				val = sfxGameObject.GetComponent<AudioSource>();
			}
			val.volume = ((limitForScene && GameController.Contexts.Service<BaseSceneService>().IsSceneBattleField) ? 0f : volume);
			if (privateAudios.Contains(audioName))
			{
				LoadAudioTest(val, playLoop, audioName, GetUiPackName(audioName));
				return;
			}
			val.loop = playLoop;
			val.clip = clip;
			val.Play();
		}
	}

	public void PlayBackgroundMusic(BgmType bgmType, bool playLoop = true)
	{
		string uiBgmName = GetUiBgmName(bgmType);
		if (!string.IsNullOrEmpty(uiBgmName))
		{
			if (privateBgm.Contains(uiBgmName))
			{
				LoadAudioTest(backgroundMusicAudioSource, playLoop, uiBgmName, GetUiPackName(uiBgmName));
				return;
			}
			backgroundMusicAudioSource.clip = LoadAudioFromUiPack(uiBgmName);
			backgroundMusicAudioSource.loop = playLoop;
			backgroundMusicAudioSource.Play();
		}
	}

	public void PlaySoundEffect(string auidoName)
	{
		soundEffectAudioSource.Pause();
		if (privateAudios.Contains(auidoName))
		{
			LoadAudioTest(soundEffectAudioSource, isLoop: false, auidoName, GetUiPackName(auidoName));
			return;
		}
		soundEffectAudioSource.clip = LoadAudioFromUiPack(auidoName);
		soundEffectAudioSource.loop = false;
		soundEffectAudioSource.Play();
	}

	public void PlaySoldierVoice(string soldierId, SoldierVoiceType voiceType)
	{
		string audioName = "";
		switch (voiceType)
		{
		case SoldierVoiceType.Onomatopoeia:
			audioName = soldierId + "_Onomatopoeia";
			break;
		case SoldierVoiceType.Voice:
			audioName = soldierId + "_Voice";
			break;
		}
		PlayBackgroundSound(audioName);
	}

	public void PlayBackgroundSound(string audioName, bool playLoop = false, float volume = 0.5f)
	{
		if (privateAudios.Contains(audioName))
		{
			LoadAudioTest(backgroundSoundAudioSource, playLoop, audioName, GetUiPackName(audioName));
			return;
		}
		backgroundSoundAudioSource.clip = LoadAudioFromUiPack(audioName);
		backgroundSoundAudioSource.loop = playLoop;
		backgroundSoundAudioSource.volume = volume;
		backgroundSoundAudioSource.Play();
	}

	public void StopBackgroundMusic(bool isPause = false, BgmType bgmType = BgmType.MainCity)
	{
		if (isPause)
		{
			backgroundMusicAudioSource.Pause();
			return;
		}
		backgroundMusicAudioSource.Stop();
		string uiBgmName = GetUiBgmName(bgmType);
		if (!string.IsNullOrEmpty(uiBgmName))
		{
			UnloadAudioTest(GetUiPackName(uiBgmName));
		}
	}

	public void StopSoundEffect()
	{
		soundEffectAudioSource.Stop();
	}

	public void StopBackgroundSound(string bgmName)
	{
		backgroundSoundAudioSource.Stop();
		UnloadAudioTest(GetUiPackName(bgmName));
	}

	public void StopBackgroundSound(BgmType bgmType)
	{
		string uiBgmName = GetUiBgmName(bgmType);
		if (!string.IsNullOrEmpty(uiBgmName))
		{
			backgroundSoundAudioSource.Stop();
			UnloadAudioTest(GetUiPackName(uiBgmName));
		}
	}

	public void SetUiBgmVolume(float volume)
	{
		backgroundMusicAudioSource.volume = volume;
		backgroundSoundAudioSource.volume = volume;
	}

	public void SetSoundEffectVolume(float volume)
	{
		soundEffectAudioSource.volume = volume;
		GRoot.inst.soundVolume = volume;
	}
}
