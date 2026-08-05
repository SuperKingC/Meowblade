using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public abstract class ObjectPoolingLoaderBase<KEY, T> where T : MonoBehaviour
{
	protected Transform PoolTrans;

	protected Transform ActiveObjectsTrans;

	protected StackPool<T> ObjectPool;

	public Dictionary<KEY, T> ActiveObjects;

	public bool IsLoading;

	public bool NeedInterruptionAndReload;

	private string AddressableAssetKey;

	public ObjectPoolingLoaderBase(Transform worldTrans, string addressableAssetKey, string containerName, int maxPoolSize)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		AddressableAssetKey = addressableAssetKey;
		GameObject val = new GameObject(containerName);
		val.transform.SetParent(worldTrans, false);
		ActiveObjectsTrans = val.transform;
		GameObject val2 = new GameObject("Pool");
		val2.transform.SetParent(ActiveObjectsTrans, false);
		PoolTrans = val2.transform;
		ActiveObjects = new Dictionary<KEY, T>();
		ObjectPool = new StackPool<T>(maxPoolSize, OnCreate, OnGetFromPool, OnReleaseToPool, OnDestroy);
	}

	public abstract IEnumerator LazyUpdate();

	private T OnCreate()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		T val = Addressables.InstantiateAsync((object)AddressableAssetKey, (Transform)null, false, true).WaitForCompletion().AddComponent<T>();
		OnGetFromPool(val);
		return val;
	}

	private void OnGetFromPool(T controller)
	{
		((Component)(object)controller).gameObject.SetActive(true);
		((Component)(object)controller).transform.SetParent(ActiveObjectsTrans, false);
	}

	private void OnReleaseToPool(T controller)
	{
		((Component)(object)controller).gameObject.SetActive(false);
		((Component)(object)controller).transform.SetParent(PoolTrans, false);
	}

	private void OnDestroy(T controller)
	{
		((Component)(object)controller).gameObject.SetActive(false);
		Addressables.ReleaseInstance(((Component)(object)controller).gameObject);
	}

	public virtual void UnloadAll()
	{
		ObjectPool.Clear();
	}

	public void SetContainerActive(bool isActive)
	{
		((Component)ActiveObjectsTrans).gameObject.SetActive(isActive);
	}
}
