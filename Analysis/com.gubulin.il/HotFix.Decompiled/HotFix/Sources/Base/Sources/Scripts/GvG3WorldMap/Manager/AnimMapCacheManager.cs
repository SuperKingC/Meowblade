using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class AnimMapCacheManager : Singleton<AnimMapCacheManager>
{
	private List<AsyncOperationHandle> _HandleList = new List<AsyncOperationHandle>();

	private Dictionary<string, MeshRenderer> AnimMapModel_Dict = new Dictionary<string, MeshRenderer>();

	private Dictionary<string, Material> AnimMapMaterial_Dict = new Dictionary<string, Material>();

	private Texture2D NoiseTexture;

	private Shader AnimMapShader;

	private Transform _Container;

	private Transform Container
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			if ((Object)(object)_Container == (Object)null)
			{
				GameObject val = new GameObject("AnimMapCacheManager");
				_Container = val.transform;
			}
			return _Container;
		}
	}

	private void EnsureShaderInit()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)AnimMapShader == (Object)null)
		{
			AsyncOperationHandle<Shader> val = Addressables.LoadAssetAsync<Shader>((object)"GvGAniMapSoldier/AnimMapShader2");
			_HandleList.Add(AsyncOperationHandle<Shader>.op_Implicit(val));
			AnimMapShader = val.WaitForCompletion();
		}
		if ((Object)(object)NoiseTexture == (Object)null)
		{
			AsyncOperationHandle<Texture2D> val2 = Addressables.LoadAssetAsync<Texture2D>((object)"GvGAniMapSoldier/AnimMapShaderNoise.asset");
			_HandleList.Add(AsyncOperationHandle<Texture2D>.op_Implicit(val2));
			NoiseTexture = Object.Instantiate<Texture2D>(val2.WaitForCompletion());
		}
	}

	public GameObject GetModel(string soldierId, string skin, eAnimName anim)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		string text = soldierId + "_" + skin;
		if (!AnimMapModel_Dict.TryGetValue(text, out var value))
		{
			AsyncOperationHandle<GameObject> val = Addressables.LoadAssetAsync<GameObject>((object)$"GvGAniMapSoldier/{text}_{anim}");
			_HandleList.Add(AsyncOperationHandle<GameObject>.op_Implicit(val));
			GameObject val2 = Object.Instantiate<GameObject>(val.WaitForCompletion());
			val2.SetActive(false);
			val2.transform.SetParent(Container, false);
			((Object)val2).name = text;
			value = val2.GetComponent<MeshRenderer>();
			AnimMapModel_Dict.Add(text, value);
			string key = $"{text}_{anim}";
			if (!AnimMapMaterial_Dict.ContainsKey(key))
			{
				AddMaterial(key, Object.Instantiate<Material>(((Renderer)value).sharedMaterial));
			}
		}
		Material animMat = GetAnimMat(text, anim);
		((Renderer)value).sharedMaterial = animMat;
		return ((Component)value).gameObject;
	}

	public Material GetAnimMat(string modelKey, eAnimName anim)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		string text = $"{modelKey}_{anim}";
		if (!AnimMapMaterial_Dict.TryGetValue(text, out var value))
		{
			value = Addressables.LoadAssetAsync<Material>((object)("GvGAniMapSoldier/" + text + ".mat")).WaitForCompletion();
			AddMaterial(text, Object.Instantiate<Material>(value));
		}
		return value;
	}

	private void AddMaterial(string key, Material mat)
	{
		EnsureShaderInit();
		mat.shader = AnimMapShader;
		mat.SetTexture("_NoiseMap", (Texture)(object)NoiseTexture);
		AnimMapMaterial_Dict.Add(key, mat);
	}

	public void Clear()
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, MeshRenderer> item in AnimMapModel_Dict)
		{
			Object.Destroy((Object)(object)item.Value);
		}
		foreach (KeyValuePair<string, Material> item2 in AnimMapMaterial_Dict)
		{
			Object.Destroy((Object)(object)item2.Value);
		}
		AnimMapModel_Dict.Clear();
		AnimMapMaterial_Dict.Clear();
		if ((Object)(object)NoiseTexture != (Object)null)
		{
			Object.DestroyImmediate((Object)(object)NoiseTexture);
			NoiseTexture = null;
		}
		if ((Object)(object)AnimMapShader != (Object)null)
		{
			Object.DestroyImmediate((Object)(object)AnimMapShader);
			AnimMapShader = null;
		}
		if ((Object)(object)_Container != (Object)null)
		{
			Object.DestroyImmediate((Object)(object)((Component)_Container).gameObject);
			_Container = null;
		}
		foreach (AsyncOperationHandle handle in _HandleList)
		{
			AsyncOperationHandle current = handle;
			if (((AsyncOperationHandle)(ref current)).IsValid())
			{
				Addressables.Release(current);
			}
		}
		_HandleList.Clear();
	}
}
