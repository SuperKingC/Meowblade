using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class HotFix_AddressablesAutoRelease : MonoBehaviour
{
	private List<AsyncOperationHandle> _handleList;

	private List<Material> _materialsList;

	public void AddMaterial(Material m)
	{
		if (_materialsList == null)
		{
			_materialsList = new List<Material>();
		}
		_materialsList.Add(m);
	}

	public void AddHandle(AsyncOperationHandle handle)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (_handleList == null)
		{
			_handleList = new List<AsyncOperationHandle>();
		}
		_handleList.Add(handle);
	}

	public void AddHandle(List<AsyncOperationHandle> list)
	{
		if (_handleList == null)
		{
			_handleList = new List<AsyncOperationHandle>();
		}
		_handleList.AddRange(list);
	}

	private void OnDestroy()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (_materialsList != null)
		{
			foreach (Material materials in _materialsList)
			{
				Object.Destroy((Object)(object)materials);
			}
			_materialsList.Clear();
		}
		if (_handleList == null)
		{
			return;
		}
		foreach (AsyncOperationHandle handle in _handleList)
		{
			Addressables.Release(handle);
		}
		_handleList.Clear();
	}
}
