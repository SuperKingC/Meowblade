using Spine.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class HotFix_DestroySelf : MonoBehaviour
{
	public float destroyTime;

	public SkeletonGraphic spine;

	public ParticleSystem particleSystem;

	private void Start()
	{
		if ((Object)(object)((Component)this).GetComponent<ParticleSystem>() != (Object)null)
		{
			destroyTime += 0.5f;
		}
		Object.Destroy((Object)(object)((Component)this).gameObject, destroyTime);
	}

	private void Update()
	{
		if ((Object)(object)spine != (Object)null && (Object)(object)spine.skeletonDataAsset == (Object)null)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject, destroyTime);
		}
	}

	private void OnDestroy()
	{
		Addressables.ReleaseInstance(((Component)this).gameObject);
	}
}
