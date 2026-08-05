using GameMaths;
using HotFix;
using UnityEngine;

public class UnityView : MonoBehaviour, IPooled, IView, IEventListener, IPositionListener, IRotationListener, IScaleListener, IAssetRemovedListener, IGameDestroyedListener
{
	private GameEntity _entity;

	[SerializeField]
	private int _id;

	private Vector3 _initRotation;

	private UnityViewBehaviour _uvb;

	public Vector3 Position;

	public Quaternion Rotation;

	public float Scale;

	public int Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return ((Component)this).gameObject.activeSelf;
		}
		set
		{
			((Component)this).gameObject.SetActive(value);
		}
	}

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		_entity = entity;
		_id = _entity.id.value;
		Quaternion rotation = ((Component)this).transform.rotation;
		_initRotation = ((Quaternion)(ref rotation)).eulerAngles;
		_uvb = ((Component)this).gameObject.GetComponent<UnityViewBehaviour>();
		if ((Object)(object)_uvb == (Object)null)
		{
			_uvb = ((Component)this).gameObject.AddComponent<UnityViewBehaviour>();
		}
		_uvb.SetInitRotation(_initRotation.x, _initRotation.y, _initRotation.z);
		if (entity.isVisible)
		{
			OnVisible(entity);
		}
	}

	public void AddSubView(IView view)
	{
		MonoBehaviour val = (MonoBehaviour)((view is MonoBehaviour) ? view : null);
		if (val != null)
		{
			((Component)val).transform.SetParent(((Component)this).transform);
		}
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Position = value;
		_uvb.OnPosition(value.x, value.y, value.z);
	}

	public void OnRotation(GameEntity entity, Quaternion value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		Rotation = value;
		_uvb.OnRotation_PlusInitRotation(value.X, value.Y, value.Z, value.W);
	}

	public virtual void OnDestroyed(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}

	public void OnScale(GameEntity entity, float value)
	{
		Scale = value;
		_uvb.OnScale(value);
	}

	public void UnSpawn()
	{
	}

	public virtual void OnInstantiate()
	{
	}

	public virtual void OnUnSpawn()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (_entity != null)
		{
			UnregisterListeners();
			Position = Vector3.op_Implicit(Vector3.zero);
			Rotation = Quaternion.op_Implicit(Quaternion.identity);
			_entity = null;
		}
	}

	public virtual void RegisterListeners()
	{
		_entity.AddGameDestroyedListener(this);
		_entity.AddPositionListener(this);
		_entity.AddRotationListener(this);
		_entity.AddScaleListener(this);
		_entity.AddAssetRemovedListener(this);
	}

	public virtual void UnregisterListeners()
	{
		_entity.RemoveGameDestroyedListener(this);
		_entity.RemovePositionListener(this);
		_entity.RemoveRotationListener(this);
		_entity.RemoveScaleListener(this);
		_entity.RemoveAssetRemovedListener(this);
	}

	public void OnVisible(GameEntity entity)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (entity.hasPosition)
		{
			OnPosition(entity, entity.position.value);
		}
		if (entity.hasRotation)
		{
			OnRotation(entity, entity.rotation.value);
		}
		if (entity.hasScale)
		{
			OnScale(entity, entity.scale.value);
		}
	}

	public void OnAssetRemoved(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}
}
