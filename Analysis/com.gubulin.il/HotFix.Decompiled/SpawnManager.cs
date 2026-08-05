using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotFix;
using RSG;
using Spine.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
	public List<GameObject> Prefabs = new List<GameObject>();

	public HashSet<GameObject> FxPrefabs = new HashSet<GameObject>();

	public Dictionary<string, List<GameObject>> PoolObjects = new Dictionary<string, List<GameObject>>();

	public Dictionary<string, int> PoolIndex = new Dictionary<string, int>();

	public Dictionary<string, GameObject> PrefabsDict = new Dictionary<string, GameObject>();

	public Dictionary<string, Quaternion> PrefabRotationDict = new Dictionary<string, Quaternion>();

	private List<string> _prefabs = new List<string> { "Prefabs/SpriteWrap", "Prefabs/StagingArea" };

	private Dictionary<string, Promise<SkeletonDataAsset>> _loadingAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);

	private Dictionary<string, Promise<SkeletonDataAsset>> _loadingMaskAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);

	private Dictionary<string, SkeletonDataAsset> _loadedSkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);

	private Dictionary<string, SkeletonDataAsset> _loadedMaskSkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);

	private Dictionary<string, int> _animationReferenceCount = new Dictionary<string, int>(20);

	private Dictionary<string, int> _animationReferenceCount_mask = new Dictionary<string, int>(20);

	private Dictionary<string, Promise<SkeletonDataAsset>> _loadingQualityAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);

	private Dictionary<string, SkeletonDataAsset> _loadedQualitySkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);

	private Dictionary<string, int> _QualityanimationReferenceCount = new Dictionary<string, int>(20);

	public Dictionary<string, GameObject> BuildingCache;

	public static SpawnManager Instance;

	public List<GameObject> CacheBattleTag;

	private List<string> addressable_keys;

	public bool FinishInit = false;

	private int _fxLoadedCount;

	private const string PREFAB_PREFIX = "FX/Prefabs/{0}";

	private Dictionary<string, int> _unitModelReferenceCount = new Dictionary<string, int>();

	private Dictionary<string, Stack<GameObject>> _unitModelPool = new Dictionary<string, Stack<GameObject>>();

	private const string ModelAnimationPrefabName = "ModelAnimation";

	public bool FxLoaded => _fxLoadedCount == 2;

	private void Awake()
	{
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		FinishInit = false;
		CacheBattleTag = new List<GameObject>();
		Prefabs = new List<GameObject>();
		FxPrefabs = new HashSet<GameObject>();
		PoolObjects = new Dictionary<string, List<GameObject>>();
		PoolIndex = new Dictionary<string, int>();
		PrefabsDict = new Dictionary<string, GameObject>();
		PrefabRotationDict = new Dictionary<string, Quaternion>();
		_prefabs = new List<string> { "Prefabs/SpriteWrap", "Prefabs/StagingArea" };
		_loadingAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);
		_loadingMaskAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);
		_loadedSkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);
		_loadedMaskSkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);
		_animationReferenceCount = new Dictionary<string, int>(20);
		_animationReferenceCount_mask = new Dictionary<string, int>(20);
		_loadingQualityAnimation = new Dictionary<string, Promise<SkeletonDataAsset>>(100);
		_loadedQualitySkeletonDataAssets = new Dictionary<string, SkeletonDataAsset>(20);
		_QualityanimationReferenceCount = new Dictionary<string, int>(20);
		_unitModelReferenceCount = new Dictionary<string, int>();
		_unitModelPool = new Dictionary<string, Stack<GameObject>>();
		Instance = this;
		_fxLoadedCount = 0;
		foreach (string prefab2 in _prefabs)
		{
			GameObject prefab = Resources.Load<GameObject>(prefab2);
			AddPrefab(prefab);
		}
		AsyncOperationHandle<IList<GameObject>> val = Addressables.LoadAssetsAsync<GameObject>((object)"Buildings", (Action<GameObject>)null);
		val.Completed += delegate(AsyncOperationHandle<IList<GameObject>> res)
		{
			BuildingCache = new Dictionary<string, GameObject>();
			foreach (GameObject item in res.Result)
			{
				BuildingCache.Add("Prefabs/Buildings/" + ((Object)item).name, item);
			}
			FinishInit = true;
		};
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (((Scene)(ref scene)).name == "Load")
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Object.Destroy((Object)(object)this);
		}
	}

	private void AddPrefab(GameObject prefab)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Prefabs.Add(prefab);
		if (!PrefabRotationDict.ContainsKey(((Object)prefab).name))
		{
			PrefabRotationDict.Add(((Object)prefab).name, prefab.transform.rotation);
		}
		PrefabsDict.Add(((Object)prefab).name, prefab);
	}

	public Quaternion GetPrefabDefaultRotation(string prefabName)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (PrefabRotationDict.ContainsKey(prefabName))
		{
			return PrefabRotationDict[prefabName];
		}
		return Quaternion.identity;
	}

	public bool Contains(string prefabName)
	{
		return PrefabsDict.ContainsKey(prefabName);
	}

	public void CreatePool(GameObject prefab, int poolSize = 5)
	{
		if (!PrefabsDict.ContainsKey(((Object)prefab).name))
		{
			PrefabsDict.Add(((Object)prefab).name, prefab);
		}
		if (!PoolObjects.ContainsKey(((Object)prefab).name))
		{
			PoolObjects.Add(((Object)prefab).name, new List<GameObject>(poolSize));
			PoolIndex.Add(((Object)prefab).name, 0);
			CreateInstancesToPool(prefab, poolSize, PoolObjects[((Object)prefab).name]);
		}
	}

	private void CreateInstancesToPool(GameObject prefab, int size, List<GameObject> pool)
	{
		pool.Capacity = pool.Count + size;
		for (int i = 0; i < size; i++)
		{
			GameObject val = Object.Instantiate<GameObject>(prefab);
			val.SetActive(false);
			val.transform.SetParent(((Component)this).transform);
			((Object)val).name = ((Object)prefab).name;
			if (FxPrefabs.Contains(prefab))
			{
				if ((Object)(object)val.GetComponent<UnityView>() == (Object)null)
				{
					val.AddComponent<UnityView>();
				}
				if ((Object)(object)val.GetComponent<UnityParticle>() == (Object)null)
				{
					val.AddComponent<UnityParticle>();
				}
				if ((Object)(object)val.GetComponent<UnityAudioClip>() == (Object)null)
				{
					val.AddComponent<UnityAudioClip>();
				}
				if ((Object)(object)val.GetComponent<AudioSource>() == (Object)null)
				{
					val.AddComponent<AudioSource>();
				}
			}
			pool.Add(val);
		}
	}

	private async Task CreateInstancesToPoolAsync(string prefabName, int size, List<GameObject> pool)
	{
		for (int i = 0; i < size; i++)
		{
			GameObject instance = await AddressableHelper.Instance.InstantiateAsync(prefabName);
			if (prefabName == "Prefabs/BattleField")
			{
				CacheBattleTag.Add(instance);
				instance.AddComponent<UnityAudioClip>();
				instance.AddComponent<UnityBattleField>();
			}
			if (prefabName == "BlueStandardUnitModel")
			{
				CacheBattleTag.Add(instance);
				UnitySkeletonAnimator _UnitySkeletonAnimator = instance.AddComponent<UnitySkeletonAnimator>();
				_UnitySkeletonAnimator.Init();
				instance.AddComponent<UnityCharacter>();
				instance.AddComponent<SpineSkeleton>();
				instance.AddComponent<UnityAudioClip>();
			}
			if (prefabName == "RedStandardUnitModel")
			{
				CacheBattleTag.Add(instance);
				UnitySkeletonAnimator _UnitySkeletonAnimator2 = instance.AddComponent<UnitySkeletonAnimator>();
				_UnitySkeletonAnimator2.Init();
				instance.AddComponent<UnityCharacter>();
				instance.AddComponent<SpineSkeleton>();
				instance.AddComponent<UnityAudioClip>();
			}
			if (!PrefabRotationDict.ContainsKey(prefabName))
			{
				PrefabRotationDict.Add(prefabName, instance.transform.rotation);
			}
			instance.SetActive(false);
			instance.transform.SetParent(((Component)this).transform);
			pool.Add(instance);
		}
	}

	public GameObject InstantiatePool(string prefabName, Vector3 pos, int poolSize = 5)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (PrefabsDict.ContainsKey(prefabName))
		{
			return InstantiatePool(PrefabsDict[prefabName], pos, GetPrefabDefaultRotation(prefabName), poolSize);
		}
		string text = $"FX/Prefabs/{prefabName}";
		GameObject result = null;
		IList<IResourceLocation> list = Addressables.LoadResourceLocationsAsync((object)text, (Type)null).WaitForCompletion();
		if (list != null && list.Count > 0)
		{
			result = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion();
		}
		else
		{
			list = Addressables.LoadResourceLocationsAsync((object)prefabName, (Type)null).WaitForCompletion();
			if (list != null && list.Count > 0)
			{
				result = Addressables.InstantiateAsync((object)prefabName, (Transform)null, false, true).WaitForCompletion();
			}
			else
			{
				Debug.LogError((object)("资源没找到！！！  Prefab Name Not Found: " + prefabName));
			}
		}
		return result;
	}

	public IEnumerator InstantiatePoolCoroutine(string prefabName, Vector3 pos, Action<GameObject> onSuccess, int poolSize = 5)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (PrefabsDict.ContainsKey(prefabName))
		{
			GameObject newObj = InstantiatePool(PrefabsDict[prefabName], pos, GetPrefabDefaultRotation(prefabName), poolSize);
			onSuccess(newObj);
			yield break;
		}
		string address_name = $"FX/Prefabs/{prefabName}";
		AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync((object)address_name, (Transform)null, false, true);
		yield return handler;
		if ((Object)(object)handler.Result != (Object)null)
		{
			handler.Result.AddComponent<AddressablesAutoRelease>().AddHandle(AsyncOperationHandle<GameObject>.op_Implicit(handler));
			onSuccess(handler.Result);
			yield break;
		}
		Addressables.Release<GameObject>(handler);
		AsyncOperationHandle<GameObject> handler2 = Addressables.InstantiateAsync((object)prefabName, (Transform)null, false, true);
		yield return handler2;
		if ((Object)(object)handler2.Result != (Object)null)
		{
			handler2.Result.AddComponent<AddressablesAutoRelease>().AddHandle(AsyncOperationHandle<GameObject>.op_Implicit(handler2));
			onSuccess(handler2.Result);
		}
		else
		{
			Debug.LogError((object)("资源没找到！！！  Prefab Name Not Found: " + prefabName));
			onSuccess(null);
		}
	}

	private GameObject InstantiatePool(GameObject obj, Vector3 pos, Quaternion rot, int poolSize = 5)
	{
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		if (!PoolObjects.ContainsKey(((Object)obj).name))
		{
			CreatePool(obj, poolSize);
		}
		int num = PoolIndex[((Object)obj).name];
		List<GameObject> list = PoolObjects[((Object)obj).name];
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			int num2 = (num + i) % count;
			GameObject val = list[num2];
			if ((Object)(object)val != (Object)null && !val.activeSelf)
			{
				PoolIndex[((Object)obj).name] = (num2 + 1) % count;
				val.transform.position = pos;
				val.transform.rotation = rot;
				Component[] components = val.GetComponents(typeof(IPooled));
				Component[] array = components;
				foreach (Component val2 in array)
				{
					((IPooled)val2).OnInstantiate();
					((IPooled)val2).Active = true;
				}
				val.SetActive(true);
				return val;
			}
		}
		CreateInstancesToPool(obj, poolSize, PoolObjects[((Object)obj).name]);
		List<GameObject> list2 = PoolObjects[((Object)obj).name];
		GameObject val3 = list2[list2.Count - poolSize];
		val3.transform.position = pos;
		val3.transform.rotation = rot;
		((Object)val3).name = ((Object)obj).name;
		val3.SetActive(true);
		Component[] components2 = val3.GetComponents(typeof(IPooled));
		Component[] array2 = components2;
		foreach (Component val4 in array2)
		{
			((IPooled)val4).OnInstantiate();
			((IPooled)val4).Active = true;
		}
		if (count == 0)
		{
			count = PoolObjects[((Object)obj).name].Count;
		}
		PoolIndex[((Object)obj).name] = (list2.Count - poolSize + 1) % count;
		return val3;
	}

	public async Task<GameObject> InstantiatePoolAsync(string prefabName, Vector3 pos, int poolSize = 5)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!PoolObjects.ContainsKey(prefabName))
		{
			PoolObjects.Add(prefabName, new List<GameObject>(poolSize));
			PoolIndex.Add(prefabName, 0);
		}
		int currentIndex = PoolIndex[prefabName];
		List<GameObject> pooledObjects = PoolObjects[prefabName];
		int length = pooledObjects.Count;
		for (int i = 0; i < length; i++)
		{
			int temI = (currentIndex + i) % length;
			GameObject instance = pooledObjects[temI];
			if ((Object)(object)instance != (Object)null && !instance.activeSelf)
			{
				PoolIndex[prefabName] = (temI + 1) % length;
				instance.transform.position = pos;
				instance.transform.rotation = GetPrefabDefaultRotation(prefabName);
				Component[] pooledObjs = instance.GetComponents(typeof(IPooled));
				Component[] array = pooledObjs;
				foreach (Component pooled in array)
				{
					((IPooled)pooled).OnInstantiate();
					((IPooled)pooled).Active = true;
				}
				instance.SetActive(true);
				return instance;
			}
		}
		await CreateInstancesToPoolAsync(prefabName, poolSize, PoolObjects[prefabName]);
		return await InstantiatePoolAsync(prefabName, pos, poolSize);
	}

	public void DestroyPool(GameObject spawned)
	{
		Component[] components = spawned.GetComponents(typeof(IPooled));
		Component[] array = components;
		foreach (Component val in array)
		{
			((IPooled)val).OnUnSpawn();
			((IPooled)val).Active = false;
		}
		Destroy(spawned);
	}

	public void Destroy(GameObject spawned)
	{
		if ((Object)(object)spawned != (Object)null)
		{
			spawned.transform.SetParent(((Component)this).transform);
			spawned.SetActive(false);
		}
	}

	public Promise<SkeletonDataAsset> LoadSoldierSpine(GameObject obj, string model, bool isMask = false)
	{
		model = "/Spine/Soldier/" + model;
		Promise<SkeletonDataAsset> val = new Promise<SkeletonDataAsset>();
		((MonoBehaviour)this).StartCoroutine(LoadSoldierSpineAsync(obj, model, val, isMask));
		return val;
	}

	public IEnumerator LoadSoldierSpineAsync(GameObject obj, string name, Promise<SkeletonDataAsset> promise, bool isMask = false)
	{
		AsyncOperationHandle<IList<IResourceLocation>> locHandle = Addressables.LoadResourceLocationsAsync((object)(name + ".atlas"), (Type)null);
		yield return locHandle;
		IList<IResourceLocation> loc = locHandle.Result;
		if (loc == null || loc.Count == 0)
		{
			promise.Reject(new Exception("LoadSoldierSpineAsync Failed , AssetName = " + name + ".atlas"));
			yield break;
		}
		AsyncOperationHandle<TextAsset> atlasHandle = Addressables.LoadAssetAsync<TextAsset>((object)(name + ".atlas"));
		yield return atlasHandle;
		AsyncOperationHandle<TextAsset> skelHandle = Addressables.LoadAssetAsync<TextAsset>((object)(name + ".skel"));
		yield return skelHandle;
		AsyncOperationHandle<Material> materialHandle = Addressables.LoadAssetAsync<Material>((object)(name + "_Material"));
		yield return materialHandle;
		if ((Object)(object)obj == (Object)null)
		{
			Addressables.Release<TextAsset>(atlasHandle);
			Addressables.Release<TextAsset>(skelHandle);
			Addressables.Release<Material>(materialHandle);
			promise.Reject(new Exception("obj is null when loading spine animation!"));
			yield break;
		}
		CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, atlasHandle.Result, skelHandle.Result, materialHandle.Result, isMask, out var newMat);
		HotFix_AddressablesAutoRelease autoRelease = obj.GetComponent<HotFix_AddressablesAutoRelease>() ?? obj.AddComponent<HotFix_AddressablesAutoRelease>();
		autoRelease.AddHandle(new List<AsyncOperationHandle>
		{
			AsyncOperationHandle<TextAsset>.op_Implicit(atlasHandle),
			AsyncOperationHandle<TextAsset>.op_Implicit(skelHandle),
			AsyncOperationHandle<Material>.op_Implicit(materialHandle)
		});
		autoRelease.AddMaterial(newMat);
		yield return promise;
	}

	private void CreateSkeletonDataAsset(IPendingPromise<SkeletonDataAsset> promise, TextAsset atlas, TextAsset json, Material material, bool isMask, out Material newMaterial)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if (isMask)
		{
			newMaterial = new Material(FGUIManager.Instance._FairyGUI_Image);
			newMaterial.SetTexture("_MainTex", material.mainTexture);
			newMaterial.SetInt("_StencilComp", 3);
			newMaterial.SetInt("_Stencil", 1);
			newMaterial.SetInt("_StencilReadMask", 1);
		}
		else
		{
			newMaterial = new Material(FGUIManager.Instance._IdleLegion_CharacterFX);
			newMaterial.CopyPropertiesFromMaterial(material);
		}
		Material[] materials = (Material[])(object)new Material[1] { newMaterial };
		AtlasAsset val = ScriptableObject.CreateInstance<AtlasAsset>();
		val.atlasFile = atlas;
		val.materials = materials;
		val.Clear();
		SkeletonDataAsset val2 = ScriptableObject.CreateInstance<SkeletonDataAsset>();
		val2.atlasAssets = (AtlasAsset[])(object)new AtlasAsset[1] { val };
		val2.skeletonJSON = json;
		val2.fromAnimation = new string[0];
		val2.toAnimation = new string[0];
		val2.duration = new float[0];
		val2.scale = 0.01f;
		val2.Clear();
		promise.Resolve(val2);
	}

	public Promise<SkeletonDataAsset> LoadAnimation_Quality(string model, string quality_string, bool isMask = false)
	{
		if (string.IsNullOrEmpty(model))
		{
			Promise<SkeletonDataAsset> val = new Promise<SkeletonDataAsset>();
			val.Reject((Exception)new ArgumentException("LoadAnimation model为空!"));
			return val;
		}
		if (quality_string.Equals(""))
		{
			return LoadAnimation(model, isMask);
		}
		string text = model + quality_string;
		if (isMask)
		{
			text += "_Mask";
		}
		if (!_QualityanimationReferenceCount.ContainsKey(text))
		{
			_QualityanimationReferenceCount[text] = 1;
		}
		else
		{
			_QualityanimationReferenceCount[text] += 1;
		}
		Promise<SkeletonDataAsset> promise = new Promise<SkeletonDataAsset>();
		if (_loadedQualitySkeletonDataAssets.ContainsKey(text))
		{
			if (_loadedQualitySkeletonDataAssets[text].GetSkeletonData(true) == null || (Object)(object)_loadedQualitySkeletonDataAssets[text].skeletonJSON == (Object)null || _loadedQualitySkeletonDataAssets[text].atlasAssets.Length == 0 || (Object)(object)_loadedQualitySkeletonDataAssets[text].atlasAssets[0] == (Object)null)
			{
				_loadedQualitySkeletonDataAssets.Remove(text);
				return promise;
			}
			promise.Resolve(_loadedQualitySkeletonDataAssets[text]);
			return promise;
		}
		if (_loadingQualityAnimation.ContainsKey(text))
		{
			return _loadingQualityAnimation[text];
		}
		_loadingQualityAnimation[text] = promise;
		string text2 = model + quality_string + ".atlas";
		string text3 = model + quality_string + ".skel";
		string text4 = model + quality_string + "_Material";
		TextAsset atlas = null;
		TextAsset json = null;
		Material material = null;
		IPromise<TextAsset> val2 = AssetsManager.Instance.LoadAsset<TextAsset>(text2);
		IPromise<TextAsset> val3 = AssetsManager.Instance.LoadAsset<TextAsset>(text3);
		IPromise<Material> val4 = AssetsManager.Instance.LoadAsset<Material>(text4);
		val2.Then((Action<TextAsset>)delegate(TextAsset asset)
		{
			atlas = asset;
			if (atlas != null && json != null && material != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, quality_string, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		val3.Then((Action<TextAsset>)delegate(TextAsset asset)
		{
			json = asset;
			if (atlas != null && json != null && material != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, quality_string, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		val4.Then((Action<Material>)delegate(Material asset)
		{
			material = asset;
			if (atlas != null && json != null && material != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, quality_string, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		return promise;
	}

	private void CreateSkeletonDataAsset(IPendingPromise<SkeletonDataAsset> promise, string model, TextAsset atlas, TextAsset json, Material material, string quality_string, bool isMask)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		string text = model + quality_string;
		if (isMask)
		{
			text += "_Mask";
		}
		if (_loadingQualityAnimation.ContainsKey(text))
		{
			_loadingQualityAnimation.Remove(text);
		}
		Material val;
		if (isMask)
		{
			val = new Material(FGUIManager.Instance._FairyGUI_Image);
			val.SetTexture("_MainTex", material.mainTexture);
			val.SetInt("_StencilComp", 3);
			val.SetInt("_Stencil", 1);
			val.SetInt("_StencilReadMask", 1);
		}
		else
		{
			val = new Material(FGUIManager.Instance._IdleLegion_CharacterFX);
			val.CopyPropertiesFromMaterial(material);
		}
		Material[] materials = (Material[])(object)new Material[1] { val };
		AtlasAsset val2 = ScriptableObject.CreateInstance<AtlasAsset>();
		val2.atlasFile = atlas;
		val2.materials = materials;
		val2.Clear();
		SkeletonDataAsset val3 = ScriptableObject.CreateInstance<SkeletonDataAsset>();
		val3.atlasAssets = (AtlasAsset[])(object)new AtlasAsset[1] { val2 };
		val3.skeletonJSON = json;
		val3.fromAnimation = new string[0];
		val3.toAnimation = new string[0];
		val3.duration = new float[0];
		val3.scale = 0.01f;
		val3.Clear();
		_loadedQualitySkeletonDataAssets[text] = val3;
		promise.Resolve(val3);
	}

	public void UnloadAnimation_Quality(string model, string quality_string, bool isMask = false)
	{
		if (string.IsNullOrEmpty(model))
		{
			return;
		}
		if (quality_string.Equals(""))
		{
			UnloadAnimation(model, isMask);
			return;
		}
		string text = model + quality_string;
		if (isMask)
		{
			text += "_Mask";
		}
		int num = 0;
		if (_QualityanimationReferenceCount.ContainsKey(text))
		{
			num = Math.Max(_QualityanimationReferenceCount[text] - 1, 0);
			_QualityanimationReferenceCount[text] = num;
		}
		if (num <= 0)
		{
			((MonoBehaviour)this).StartCoroutine(UnloadAnimationWithDelay_Quality(model, quality_string, isMask));
		}
	}

	private IEnumerator UnloadAnimationWithDelay_Quality(string model, string quality_string, bool isMask)
	{
		yield return (object)new WaitForSeconds(5f);
		string cache_name = model + quality_string;
		if (isMask)
		{
			cache_name += "_Mask";
		}
		_QualityanimationReferenceCount.TryGetValue(cache_name, out var count);
		if (count <= 0)
		{
			_loadedQualitySkeletonDataAssets.Remove(cache_name);
			AssetsManager.Instance.UnloadAsset<TextAsset>(model + quality_string + ".atlas");
			AssetsManager.Instance.UnloadAsset<TextAsset>(model + quality_string + ".skel");
			AssetsManager.Instance.UnloadAsset<Material>(model + quality_string + "_Material");
		}
	}

	public Promise<SkeletonDataAsset> LoadAnimation(string model, bool isMask = false)
	{
		if (string.IsNullOrEmpty(model))
		{
			Promise<SkeletonDataAsset> val = new Promise<SkeletonDataAsset>();
			val.Reject((Exception)new ArgumentException("LoadAnimation model为空!"));
			return val;
		}
		if (isMask)
		{
			if (!_animationReferenceCount_mask.ContainsKey(model))
			{
				_animationReferenceCount_mask[model] = 1;
			}
			else
			{
				_animationReferenceCount_mask[model] += 1;
			}
		}
		else if (!_animationReferenceCount.ContainsKey(model))
		{
			_animationReferenceCount[model] = 1;
		}
		else
		{
			_animationReferenceCount[model] += 1;
		}
		Promise<SkeletonDataAsset> promise = new Promise<SkeletonDataAsset>();
		if (isMask)
		{
			if (_loadedMaskSkeletonDataAssets.ContainsKey(model))
			{
				if (_loadedMaskSkeletonDataAssets[model].GetSkeletonData(true) != null && !((Object)(object)_loadedMaskSkeletonDataAssets[model].skeletonJSON == (Object)null) && _loadedMaskSkeletonDataAssets[model].atlasAssets.Length != 0 && !((Object)(object)_loadedMaskSkeletonDataAssets[model].atlasAssets[0] == (Object)null))
				{
					promise.Resolve(_loadedMaskSkeletonDataAssets[model]);
					return promise;
				}
				_loadedMaskSkeletonDataAssets.Remove(model);
			}
			if (_loadingMaskAnimation.ContainsKey(model))
			{
				return _loadingMaskAnimation[model];
			}
			_loadingMaskAnimation[model] = promise;
		}
		else
		{
			if (_loadedSkeletonDataAssets.ContainsKey(model))
			{
				if (_loadedSkeletonDataAssets[model].GetSkeletonData(true) != null && !((Object)(object)_loadedSkeletonDataAssets[model].skeletonJSON == (Object)null) && _loadedSkeletonDataAssets[model].atlasAssets.Length != 0 && !((Object)(object)_loadedSkeletonDataAssets[model].atlasAssets[0] == (Object)null))
				{
					promise.Resolve(_loadedSkeletonDataAssets[model]);
					return promise;
				}
				_loadedSkeletonDataAssets.Remove(model);
			}
			if (_loadingAnimation.ContainsKey(model))
			{
				return _loadingAnimation[model];
			}
			_loadingAnimation[model] = promise;
		}
		string text = model + ".atlas";
		string text2 = model + ".skel";
		string text3 = model + "_Material";
		string text4 = model + "_Material_Mask";
		TextAsset atlas = null;
		TextAsset json = null;
		Material material = null;
		Material materialMask = null;
		IPromise<TextAsset> val2 = AssetsManager.Instance.LoadAsset<TextAsset>(text);
		IPromise<TextAsset> val3 = AssetsManager.Instance.LoadAsset<TextAsset>(text2);
		IPromise<Material> val4 = AssetsManager.Instance.LoadAsset<Material>(text3);
		IPromise<Material> val5 = AssetsManager.Instance.LoadAsset<Material>(text4);
		val2.Then((Action<TextAsset>)delegate(TextAsset asset)
		{
			atlas = asset;
			if (atlas != null && json != null && material != null && materialMask != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, materialMask, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		val3.Then((Action<TextAsset>)delegate(TextAsset asset)
		{
			json = asset;
			if (atlas != null && json != null && material != null && materialMask != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, materialMask, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		val4.Then((Action<Material>)delegate(Material asset)
		{
			material = asset;
			if (atlas != null && json != null && material != null && materialMask != null)
			{
				CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, materialMask, isMask);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		val5.Then((Action<Material>)delegate(Material asset)
		{
			materialMask = asset;
			if (atlas != null && json != null && material != null && materialMask != null)
			{
				AssetsManager.Instance.LoadAsset<Shader>("spine-skeleton-mask").Then((Action<Shader>)delegate(Shader shader)
				{
					materialMask.shader = shader;
					materialMask.SetFloat("_StencilComp", 3f);
					materialMask.SetFloat("_Stencil", 1f);
					materialMask.SetFloat("_StencilOp", 0f);
					materialMask.SetFloat("_StencilWriteMask", 255f);
					materialMask.SetFloat("_StencilReadMask", 1f);
					CreateSkeletonDataAsset((IPendingPromise<SkeletonDataAsset>)(object)promise, model, atlas, json, material, materialMask, isMask);
				}).Catch((Action<Exception>)delegate(Exception ex)
				{
					throw ex;
				});
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Invalid comparison between Unknown and I4
			if ((int)promise.CurState == 0)
			{
				promise.Reject(ex);
			}
		});
		return promise;
	}

	public void UnloadAnimation(string model, bool isMask = false)
	{
		if (string.IsNullOrEmpty(model))
		{
			return;
		}
		int num = 0;
		if (isMask)
		{
			if (_animationReferenceCount_mask.ContainsKey(model))
			{
				num = Math.Max(_animationReferenceCount_mask[model] - 1, 0);
				_animationReferenceCount_mask[model] = num;
			}
		}
		else if (_animationReferenceCount.ContainsKey(model))
		{
			num = Math.Max(_animationReferenceCount[model] - 1, 0);
			_animationReferenceCount[model] = num;
		}
		if (num <= 0)
		{
			((MonoBehaviour)this).StartCoroutine(UnloadAnimationWithDelay(model, isMask));
		}
	}

	private IEnumerator UnloadAnimationWithDelay(string model, bool isMask = false)
	{
		yield return (object)new WaitForSeconds(5f);
		int count = 0;
		if (isMask)
		{
			if (!_animationReferenceCount_mask.TryGetValue(model, out count))
			{
				yield break;
			}
			if (count == 0)
			{
				_animationReferenceCount_mask.Remove(model);
			}
		}
		else
		{
			if (!_animationReferenceCount.TryGetValue(model, out count))
			{
				yield break;
			}
			if (count == 0)
			{
				_animationReferenceCount.Remove(model);
			}
		}
		if (count > 0)
		{
			yield break;
		}
		if (isMask)
		{
			if (_loadedMaskSkeletonDataAssets.ContainsKey(model))
			{
				SkeletonDataAsset obj = _loadedMaskSkeletonDataAssets[model];
				if (obj != null)
				{
					obj.Clear();
				}
				_loadedMaskSkeletonDataAssets[model] = null;
				_loadedMaskSkeletonDataAssets.Remove(model);
			}
		}
		else if (_loadedSkeletonDataAssets.ContainsKey(model))
		{
			SkeletonDataAsset obj2 = _loadedSkeletonDataAssets[model];
			if (obj2 != null)
			{
				obj2.Clear();
			}
			_loadedSkeletonDataAssets[model] = null;
			_loadedSkeletonDataAssets.Remove(model);
		}
		AssetsManager.Instance.UnloadAsset<TextAsset>(model + ".atlas");
		AssetsManager.Instance.UnloadAsset<TextAsset>(model + ".skel");
		AssetsManager.Instance.UnloadAsset<Material>(model + "_Material");
		AssetsManager.Instance.UnloadAsset<Material>(model + "_Material_Mask");
	}

	private void CreateSkeletonDataAsset(IPendingPromise<SkeletonDataAsset> promise, string model, TextAsset atlas, TextAsset json, Material material, Material materialMask, bool isMask)
	{
		if (isMask)
		{
			if (_loadingMaskAnimation.ContainsKey(model))
			{
				_loadingMaskAnimation.Remove(model);
			}
		}
		else if (_loadingAnimation.ContainsKey(model))
		{
			_loadingAnimation.Remove(model);
		}
		material.shader = Shader.Find("IdleLegion/CharacterFX");
		material.SetTexture("_MainTex", material.mainTexture);
		Material[] materials = (Material[])(object)new Material[1] { isMask ? materialMask : material };
		AtlasAsset val = ScriptableObject.CreateInstance<AtlasAsset>();
		val.atlasFile = atlas;
		val.materials = materials;
		val.Clear();
		SkeletonDataAsset val2 = ScriptableObject.CreateInstance<SkeletonDataAsset>();
		val2.atlasAssets = (AtlasAsset[])(object)new AtlasAsset[1] { val };
		val2.skeletonJSON = json;
		val2.fromAnimation = new string[0];
		val2.toAnimation = new string[0];
		val2.duration = new float[0];
		val2.scale = 0.01f;
		val2.Clear();
		if (isMask)
		{
			_loadedMaskSkeletonDataAssets[model] = val2;
		}
		else
		{
			_loadedSkeletonDataAssets[model] = val2;
		}
		promise.Resolve(val2);
	}

	public async Task<GameObject> LoadUnitModel(string model, string quality_string = "HAS_NOT_QUALITY")
	{
		model += quality_string;
		_unitModelPool.TryGetValue(model, out var pool);
		if (pool == null)
		{
			pool = new Stack<GameObject>();
			_unitModelPool[model] = pool;
		}
		GameObject instance;
		if (pool.Count == 0)
		{
			instance = await AddressableHelper.Instance.InstantiateAsync("ModelAnimation");
			((Object)instance).name = "ModelAnimation";
			if (!PrefabRotationDict.ContainsKey("ModelAnimation"))
			{
				PrefabRotationDict.Add("ModelAnimation", instance.transform.rotation);
			}
		}
		else
		{
			instance = pool.Pop();
		}
		instance.transform.rotation = GetPrefabDefaultRotation("ModelAnimation");
		instance.transform.position = Vector3.zero;
		_unitModelReferenceCount.TryGetValue(model, out var count);
		_unitModelReferenceCount[model] = count + 1;
		return instance;
	}

	public void UnloadUnitModel(GameObject instance, string model, string quality_string = "HAS_NOT_QUALITY")
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		_unitModelReferenceCount.TryGetValue(model + quality_string, out var value);
		value = Math.Max(value - 1, 0);
		_unitModelReferenceCount[model + quality_string] = value;
		instance.transform.SetParent(((Component)this).transform);
		instance.transform.position = Vector3.up * 10000f;
		_unitModelPool.TryGetValue(model + quality_string, out var value2);
		if (value2 == null)
		{
			value2 = new Stack<GameObject>();
			_unitModelPool[model + quality_string] = value2;
		}
		value2.Push(instance);
		if (value == 0)
		{
			((MonoBehaviour)this).StartCoroutine(UnloadAllUnitModelsWithDelay(model, quality_string));
		}
	}

	private IEnumerator UnloadAllUnitModelsWithDelay(string model, string quality_string)
	{
		yield return (object)new WaitForSeconds(3f);
		if (!_unitModelReferenceCount.TryGetValue(model + quality_string, out var count) || count > 0)
		{
			yield break;
		}
		_unitModelReferenceCount.Remove(model + quality_string);
		_unitModelPool.TryGetValue(model + quality_string, out var pool);
		if (pool == null)
		{
			yield break;
		}
		while (pool.Count > 0)
		{
			GameObject instance = pool.Pop();
			SkeletonAnimation skeletonAnimation = instance.GetComponent<SkeletonAnimation>();
			if (skeletonAnimation.AnimationState != null)
			{
			}
			Object.DestroyImmediate((Object)(object)instance);
		}
	}
}
