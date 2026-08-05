using System.Threading.Tasks;
using GameMaths;
using RSG;
using Shift.Legion.Common.Services;
using UnityEngine;

public class UnityAddressableInstantiator : IViewInstantiator
{
	public object Initialize(string viewName, Vector3 pos, int poolSize = 5)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		if (SpawnManager.Instance.Contains(viewName))
		{
			return SpawnManager.Instance.InstantiatePool(viewName, Vector3.op_Implicit(pos), poolSize);
		}
		GameObject val = Resources.Load<GameObject>(viewName);
		if ((Object)(object)val == (Object)null)
		{
			return null;
		}
		GameObject val2 = Object.Instantiate<GameObject>(val);
		val2.transform.position = Vector3.op_Implicit(pos);
		return val2;
	}

	public async Task<object> InstantiateAsync(string viewName, Vector3 pos)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (AddressableHelper.Instance.ResourceExists((object)("FX/Prefabs/" + viewName)))
		{
			GameObject _resource = await SpawnManager.Instance.InstantiatePoolAsync("FX/Prefabs/" + viewName, Vector3.op_Implicit(pos), 1);
			TryToAddScript(viewName, _resource);
			_resource.transform.position = Vector3.op_Implicit(pos);
			return _resource;
		}
		if (AddressableHelper.Instance.ResourceExists((object)viewName))
		{
			GameObject _resource2 = await SpawnManager.Instance.InstantiatePoolAsync(viewName, Vector3.op_Implicit(pos), 1);
			TryToAddScript(viewName, _resource2);
			_resource2.transform.position = Vector3.op_Implicit(pos);
			return _resource2;
		}
		if (SpawnManager.Instance.Contains(viewName))
		{
			return SpawnManager.Instance.InstantiatePool(viewName, Vector3.op_Implicit(pos));
		}
		GameObject instance = await AddressableHelper.Instance.InstantiateAsync(viewName);
		if ((Object)(object)instance == (Object)null)
		{
			Debug.LogError((object)("InstantiateAsync " + viewName + " Failed"));
		}
		else
		{
			TryToAddScript(viewName, instance);
			instance.transform.position = Vector3.op_Implicit(pos);
		}
		return instance;
	}

	private void TryToAddScript(string viewName, GameObject instance)
	{
		if (viewName.Equals("empty"))
		{
			if ((Object)(object)instance.GetComponent<UnityView>() == (Object)null)
			{
				instance.AddComponent<UnityView>();
			}
			if ((Object)(object)instance.GetComponent<UnityParticle>() == (Object)null)
			{
				instance.AddComponent<UnityParticle>();
			}
			if ((Object)(object)instance.GetComponent<UnityAudioClip>() == (Object)null)
			{
				instance.AddComponent<UnityAudioClip>();
			}
		}
		else if (viewName.StartsWith("FX/Prefabs/shadow_normal"))
		{
			if ((Object)(object)instance.GetComponent<UnityView>() == (Object)null)
			{
				instance.AddComponent<UnityView>();
			}
			if ((Object)(object)instance.GetComponent<UnityParticle>() == (Object)null)
			{
				instance.AddComponent<UnityParticle>();
			}
		}
		else if (viewName.StartsWith("FX/Prefabs/"))
		{
			if ((Object)(object)instance.GetComponent<UnityView>() == (Object)null)
			{
				instance.AddComponent<UnityView>();
			}
			if ((Object)(object)instance.GetComponent<UnityParticle>() == (Object)null)
			{
				instance.AddComponent<UnityParticle>();
			}
			if ((Object)(object)instance.GetComponent<UnityAudioClip>() == (Object)null)
			{
				instance.AddComponent<UnityAudioClip>();
			}
			if ((Object)(object)instance.GetComponent<AudioSource>() == (Object)null)
			{
				instance.AddComponent<AudioSource>();
			}
		}
		if (viewName.StartsWith("FX/Prefabs/SpineParticle"))
		{
			instance.AddComponent<UnitySkeletonAnimator>();
		}
	}

	public Promise<object> InitializeAsync(string viewName, Vector3 pos, int poolSize = 5)
	{
		return null;
	}
}
