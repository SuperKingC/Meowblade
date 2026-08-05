using GameMaths;
using HotFix;
using UnityEngine;

public class SpineSkeleton : MonoBehaviour, IPooled, ISkeleton
{
	private GameEntity _entity;

	private SpineSkeletonBehaviour _skb;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		_entity = entity;
		if ((Object)(object)_skb == (Object)null)
		{
			_skb = ((Component)this).gameObject.AddComponent<SpineSkeletonBehaviour>();
		}
	}

	public Vector3 GetBonePosition(string boneName)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (_entity == null)
		{
			return Vector3.op_Implicit(((Component)this).transform.position);
		}
		return _skb.GetBonePosition(boneName, _entity.unitScale.value);
	}

	public Quaternion GetBoneRotation(string boneName)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return _skb.GetBoneRotation(boneName);
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
	}

	public void OnUnSpawn()
	{
		_entity = null;
		Object.Destroy((Object)(object)_skb);
		_skb = null;
	}
}
