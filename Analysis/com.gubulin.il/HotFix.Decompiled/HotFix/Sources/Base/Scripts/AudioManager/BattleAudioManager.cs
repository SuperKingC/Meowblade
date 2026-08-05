using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using GameMaths;
using ILRuntime_LitJson;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace HotFix.Sources.Base.Scripts.AudioManager;

public class BattleAudioManager : MonoBehaviour
{
	private const string AudioAAFormat = "Audio/BattleAudio/{0}";

	private const int DefaultPriority = 5;

	private const float AudioDistance = 2f;

	private static object _lock = new object();

	private float playInterval;

	private Dictionary<string, float> playAttenuation;

	private Dictionary<string, BattleAudioStaticData> allBattleAudioConfig;

	private Dictionary<string, PlayBattleAudioPreparationDic> allAudioPreparationDics;

	private Dictionary<string, PlayBattleAudioList> allAudioLists;

	private GComponent timer;

	private Dictionary<string, AsyncOperationHandle<AudioClip>> AssetsList;

	public bool Enabled { get; set; }

	private void Awake()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		AssetsList = new Dictionary<string, AsyncOperationHandle<AudioClip>>();
		TextAsset val = Addressables.LoadAssetAsync<TextAsset>((object)"BattleAudioPlayConfig").WaitForCompletion();
		BattleAudioPlayConfig battleAudioPlayConfig = JsonMapper.ToObject<BattleAudioPlayConfig>(val.text);
		playInterval = battleAudioPlayConfig.PlayInterval;
		playAttenuation = new Dictionary<string, float>(battleAudioPlayConfig.PlayAttenuation);
		List<GDEBattleAudioConfigData> list = GDMgr.GetAllItems<GDEBattleAudioConfigData>().ToList();
		allBattleAudioConfig = new Dictionary<string, BattleAudioStaticData>();
		foreach (GDEBattleAudioConfigData item in list)
		{
			allBattleAudioConfig.Add(item.Name, new BattleAudioStaticData
			{
				AudioSourceName = item.Name,
				MaxCount = item.MaxCount,
				Priority = item.Priority,
				IsPlayInOrder = item.PlayInOrder,
				PlayDelayTime = (string.IsNullOrEmpty(item.DelayTime) ? 0f : NumericParser.Float(item.DelayTime))
			});
		}
		lock (_lock)
		{
			allAudioPreparationDics = new Dictionary<string, PlayBattleAudioPreparationDic>();
			allAudioLists = new Dictionary<string, PlayBattleAudioList>();
			timer = new GComponent();
		}
	}

	private void Update()
	{
		if (Enabled)
		{
			AllAudioPreparationDicUpdate();
			AllAudioListsClearUpdate();
			AudioListsAddUpdate();
			AllAudioListsPlayUpdate();
		}
	}

	public void ClearAllAudioDic()
	{
		Enabled = true;
		lock (_lock)
		{
			allAudioPreparationDics.Clear();
			allAudioLists.Clear();
		}
	}

	private Vector3 GetPlayAudioPos()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(0f, 0.5f, 34.6f);
		ICameraService cameraService = GameController.Contexts.Service<ICameraService>();
		Vector3 position = cameraService.Position;
		float x = position.x;
		if (PlayFrameService.GetInstance().HasRedTeamTargetX())
		{
			x = PlayFrameService.GetInstance().GetRedTeamTargetX();
			return new Vector3(x, position.y, position.z);
		}
		if (PlayFrameService.GetInstance().HasBlueTeamTargetX())
		{
			x = PlayFrameService.GetInstance().GetBlueTeamTargetX();
			return new Vector3(x, position.y, position.z);
		}
		return new Vector3(x, position.y, position.z);
	}

	public void PlayFullScreenSound(string audionName)
	{
		string assetName = $"Audio/BattleAudio/{audionName}";
		UnityGameObjectPool.GetInstance().Get((EnumType)3, assetName, (Action<GameObject, bool>)delegate(GameObject go, bool isNew)
		{
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			AudioSource source;
			if (isNew)
			{
				AudioClip audioClip = GetAudioClip(assetName);
				if (!((Object)(object)audioClip != (Object)null))
				{
					return;
				}
				go = new GameObject();
				((Object)go).name = "Battle_Audio_" + ((Object)audioClip).name;
				source = go.AddComponent<AudioSource>();
				source.playOnAwake = false;
				source.loop = false;
				source.clip = audioClip;
				Singleton<CameraService>.Instance.SetCameraParent(go.transform);
				go.transform.localPosition = new Vector3(0f, 0f, 2f);
			}
			else
			{
				source = go.GetComponent<AudioSource>();
			}
			source.Play();
			timer.SetTimeout(source.clip.length).OnComplete((GTweenCallback)delegate
			{
				RecycleAudioSourceToPool(source);
			});
		}, false);
	}

	public void AudioPreparationDicAdd(string audioName, float volume)
	{
		if (!Enabled)
		{
			return;
		}
		lock (_lock)
		{
			if (!allAudioPreparationDics.ContainsKey(audioName))
			{
				int audioSourceMaxCount = GetAudioSourceMaxCount(audioName);
				int audioSourcePriority = GetAudioSourcePriority(audioName);
				bool isPlayInOrder = AudioSourceIsPlayInOrder(audioName);
				float audioSourcePlayDelayTime = GetAudioSourcePlayDelayTime(audioName);
				allAudioPreparationDics.Add(audioName, new PlayBattleAudioPreparationDic(audioName, audioSourceMaxCount, audioSourcePriority, isPlayInOrder, audioSourcePlayDelayTime));
			}
			PlayBattleAudioPreparation item = new PlayBattleAudioPreparation(audioName, allAudioPreparationDics[audioName].MaxCount, allAudioPreparationDics[audioName].Priority, volume, allAudioPreparationDics[audioName].PlayDelayTime);
			allAudioPreparationDics[audioName].AllAudioPreparations.Add(item);
		}
	}

	private void AudioListsAddUpdate()
	{
		lock (_lock)
		{
			foreach (KeyValuePair<string, PlayBattleAudioPreparationDic> allAudioPreparationDic in allAudioPreparationDics)
			{
				string key = allAudioPreparationDic.Key;
				PlayBattleAudioPreparationDic value = allAudioPreparationDic.Value;
				if (value.AllAudioPreparations.Count <= 0)
				{
					continue;
				}
				int maxCount = value.MaxCount;
				int priority = value.Priority;
				bool isPlayInOrder = value.IsPlayInOrder;
				if (!allAudioLists.ContainsKey(key))
				{
					allAudioLists.Add(key, new PlayBattleAudioList(key, priority, isPlayInOrder));
				}
				int num = 5;
				if (allAudioLists[key].AudioPlayMode == PlayMode.PlayInOrder)
				{
					num = GetCurrentPlayingAudioMaxPriority();
					PlayInOderAudiosHandle(value.AllAudioPreparations, num, key);
					continue;
				}
				int allAudiosCount = allAudioLists[key].AllAudiosCount;
				if (maxCount != 0 && allAudiosCount >= maxCount)
				{
					value.ClearAllAudioPreparations();
					continue;
				}
				float latestPlayTime = allAudioLists[key].LatestPlayTime;
				if (Time.time - latestPlayTime <= playInterval)
				{
					value.ClearAllAudioPreparations();
					continue;
				}
				num = GetCurrentPlayingAudioMaxPriority();
				for (int num2 = value.AllAudioPreparations.Count - 1; num2 >= 0; num2--)
				{
					PlayBattleAudioPreparation playBattleAudioPreparation = value.AllAudioPreparations[num2];
					float audioClipVolume = GetAudioClipVolume(playBattleAudioPreparation.Volume, playBattleAudioPreparation.Priority, num);
					playBattleAudioPreparation.Added = true;
					PlayBattleAudio playBattleAudio = new PlayBattleAudio(playBattleAudioPreparation.AudioSourceName, audioClipVolume);
					allAudioLists[key].AllBattleAudiosAdd(playBattleAudio);
					LoadAudioSourceFromPool(playBattleAudioPreparation.AudioSourceName, playBattleAudio);
				}
			}
		}
	}

	private void PlayInOderAudiosHandle(List<PlayBattleAudioPreparation> allAudioPreparations, int currentMaxPriority, string audioName)
	{
		int num = ((allAudioPreparations.Count <= 6) ? allAudioPreparations.Count : (6 + Mathf.CeilToInt((float)(allAudioPreparations.Count - 6) / 4f)));
		for (int num2 = allAudioPreparations.Count - 1; num2 >= 0; num2--)
		{
			PlayBattleAudioPreparation playBattleAudioPreparation = allAudioPreparations[num2];
			playBattleAudioPreparation.Added = true;
			if (num2 < num)
			{
				float playDelayTime = playBattleAudioPreparation.PlayDelayTime * (float)num2;
				float audioClipVolume = GetAudioClipVolume(playBattleAudioPreparation.Volume, playBattleAudioPreparation.Priority, currentMaxPriority);
				PlayBattleAudio playBattleAudio = new PlayBattleAudio(playBattleAudioPreparation.AudioSourceName, audioClipVolume, PlayMode.PlayInOrder, playDelayTime);
				allAudioLists[audioName].AllBattleAudiosAdd(playBattleAudio);
				LoadAudioSourceFromPool(playBattleAudioPreparation.AudioSourceName, playBattleAudio);
			}
		}
	}

	private void AllAudioPreparationDicUpdate()
	{
		lock (_lock)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, PlayBattleAudioPreparationDic> allAudioPreparationDic in allAudioPreparationDics)
			{
				allAudioPreparationDic.Value.ClearAddedAudioPreparations();
				if (allAudioPreparationDic.Value.AllAudioPreparations.Count <= 0)
				{
					list.Add(allAudioPreparationDic.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				allAudioPreparationDics.Remove(list[i]);
			}
		}
	}

	private void AllAudioListsClearUpdate()
	{
		lock (_lock)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, PlayBattleAudioList> allAudioList in allAudioLists)
			{
				List<AudioSource> list2 = allAudioList.Value.ClearFinishedAudios();
				if (allAudioList.Value.AllBattleAudios.Count <= 0)
				{
					list.Add(allAudioList.Key);
				}
				for (int i = 0; i < list2.Count; i++)
				{
					RecycleAudioSourceToPool(list2[i]);
				}
			}
			foreach (string item in list)
			{
				allAudioLists.Remove(item);
			}
		}
	}

	private void AllAudioListsPlayUpdate()
	{
		lock (_lock)
		{
			foreach (KeyValuePair<string, PlayBattleAudioList> allAudioList in allAudioLists)
			{
				allAudioList.Value.StartPlayAudios();
			}
		}
	}

	private AudioClip GetAudioClip(string asset_name)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (AssetsList.TryGetValue(asset_name, out var value))
		{
			return value.WaitForCompletion();
		}
		IList<IResourceLocation> list = Addressables.LoadResourceLocationsAsync((object)asset_name, (Type)null).WaitForCompletion();
		if (list.Count > 0)
		{
			AsyncOperationHandle<AudioClip> value2 = Addressables.LoadAssetAsync<AudioClip>((object)asset_name);
			AssetsList.Add(asset_name, value2);
			return AssetsList[asset_name].WaitForCompletion();
		}
		return null;
	}

	private void LoadAudioSourceFromPool(string audioClipName, PlayBattleAudio playData)
	{
		if (string.IsNullOrEmpty(audioClipName))
		{
			return;
		}
		string asset_name = $"Audio/BattleAudio/{audioClipName}";
		UnityGameObjectPool.GetInstance().Get((EnumType)3, asset_name, (Action<GameObject, bool>)delegate(GameObject go, bool isNew)
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			if (isNew)
			{
				AudioClip audioClip = GetAudioClip(asset_name);
				if (!((Object)(object)audioClip != (Object)null))
				{
					return;
				}
				go = new GameObject();
				((Object)go).name = "Battle_Audio_" + ((Object)audioClip).name;
				AudioSource val = go.AddComponent<AudioSource>();
				val.playOnAwake = false;
				val.loop = false;
				val.clip = audioClip;
			}
			Singleton<CameraService>.Instance.SetCameraParent(go.transform);
			go.transform.localPosition = new Vector3(0f, 0f, 2f);
			playData.AddAudioSource(go);
		}, false);
	}

	private void RecycleAudioSourceToPool(AudioSource source)
	{
		string text = $"Audio/BattleAudio/{((Object)source.clip).name}";
		Dictionary<EnumType, Dictionary<string, Queue<GameObject>>> cache = UnityGameObjectPool.GetInstance().GetCache();
		if (!cache[(EnumType)3].ContainsKey(text))
		{
			Object.Destroy((Object)(object)((Component)source).gameObject);
		}
		else
		{
			UnityGameObjectPool.GetInstance().Recycle((EnumType)3, text, ((Component)source).gameObject);
		}
	}

	public void AllAudioClipsRelease()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		AllAudioListsClearUpdate();
		foreach (KeyValuePair<string, AsyncOperationHandle<AudioClip>> assets in AssetsList)
		{
			bool flag = Addressables.ReleaseInstance(AsyncOperationHandle<AudioClip>.op_Implicit(assets.Value));
		}
		AssetsList.Clear();
	}

	private int GetCurrentPlayingAudioMaxPriority()
	{
		int num = 5;
		foreach (KeyValuePair<string, PlayBattleAudioList> allAudioList in allAudioLists)
		{
			if (allAudioList.Value.Priority < num)
			{
				num = allAudioList.Value.Priority;
			}
		}
		return num;
	}

	private int GetAudioSourceMaxCount(string audioSourceName)
	{
		if (allBattleAudioConfig == null || allBattleAudioConfig.Count <= 0)
		{
			return 0;
		}
		if (!allBattleAudioConfig.ContainsKey(audioSourceName))
		{
			return 0;
		}
		return allBattleAudioConfig[audioSourceName].MaxCount;
	}

	private int GetAudioSourcePriority(string audioSourceName)
	{
		if (allBattleAudioConfig == null || allBattleAudioConfig.Count <= 0)
		{
			return 5;
		}
		if (!allBattleAudioConfig.ContainsKey(audioSourceName))
		{
			return 5;
		}
		return allBattleAudioConfig[audioSourceName].Priority;
	}

	private bool AudioSourceIsPlayInOrder(string audioSourceName)
	{
		if (allBattleAudioConfig == null || allBattleAudioConfig.Count <= 0)
		{
			return false;
		}
		if (!allBattleAudioConfig.ContainsKey(audioSourceName))
		{
			return false;
		}
		return allBattleAudioConfig[audioSourceName].IsPlayInOrder;
	}

	private float GetAudioSourcePlayDelayTime(string audioSourceName)
	{
		if (allBattleAudioConfig == null || allBattleAudioConfig.Count <= 0)
		{
			return 0f;
		}
		if (!allBattleAudioConfig.ContainsKey(audioSourceName))
		{
			return 0f;
		}
		return allBattleAudioConfig[audioSourceName].PlayDelayTime;
	}

	private float GetAudioClipVolume(float volume, int priority, int currentMax)
	{
		int num = currentMax - priority;
		float result = Mathf.Max(Mathf.Min(volume / 100f, 1f), 0f);
		if (num >= 0)
		{
			return result;
		}
		if (playAttenuation == null || playAttenuation.Count <= 0)
		{
			return result;
		}
		float num2 = volume * playAttenuation[Mathf.Abs(num).ToString()];
		return Mathf.Max(Mathf.Min(num2 / 100f, 1f), 0f);
	}
}
