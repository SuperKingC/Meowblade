using Entitas;
using GameMaths;
using UnityEngine;

public class UnityCamera : MonoBehaviour, ICamera, IAnyCameraPositionListener, IAnyCameraActiveListener, IAnyCameraRotationListener, IAnyCameraSizeListener
{
	private Camera _camera;

	private GameStateEntity _gameStateEntity;

	private GameEntity _entity;

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_entity = entity;
		_gameStateEntity = ((Context<GameStateEntity>)contexts.gameState).CreateEntity();
		GameObject val = GameObject.Find("MainCamera");
		_camera = val.GetComponent<Camera>();
		_entity.ReplacePosition(Vector3.op_Implicit(((Component)this).transform.position));
		_entity.ReplaceCamera(this);
		RegisterListeners();
	}

	public void RegisterListeners()
	{
		_gameStateEntity.AddAnyCameraActiveListener(this);
		_gameStateEntity.AddAnyCameraPositionListener(this);
		_gameStateEntity.AddAnyCameraRotationListener(this);
		_gameStateEntity.AddAnyCameraSizeListener(this);
	}

	public void UnregisterListeners()
	{
		_gameStateEntity.RemoveAnyCameraActiveListener(this);
		_gameStateEntity.RemoveAnyCameraPositionListener(this);
		_gameStateEntity.RemoveAnyCameraRotationListener(this);
		_gameStateEntity.RemoveAnyCameraSizeListener(this);
	}

	public void OnAnyCameraPosition(GameStateEntity entity, Vector3 value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_entity.ReplacePosition(value);
	}

	public void OnAnyCameraActive(GameStateEntity entity, bool value)
	{
		((Component)_camera).gameObject.SetActive(value);
	}

	public void OnAnyCameraRotation(GameStateEntity entity, Quaternion value)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		((Component)_camera).transform.rotation = Quaternion.op_Implicit(value);
	}

	public void OnAnyCameraSize(GameStateEntity entity, float value)
	{
		_camera.orthographicSize = value;
	}

	public Vector3 WorldToScreenPoint(Vector3 position)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return Vector3.op_Implicit(_camera.WorldToScreenPoint(Vector3.op_Implicit(position)));
	}
}
