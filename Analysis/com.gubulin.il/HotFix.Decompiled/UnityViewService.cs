using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Services;
using UnityEngine;

public sealed class UnityViewService : Service, IViewService, IService, IAnyAssetListener, IAnyLoadViewFromResourcesListener, IAnyLoadViewFromResourcesRemovedListener
{
	private Transform _root;

	private IViewInstantiator _viewInstantiator;

	private List<IEventListener> _eventListenerBuffer;

	private GameEntity _gameEventListener;

	private ConfigEntity _configEventListener;

	public UnityViewService(Contexts contexts)
		: base(contexts)
	{
		_eventListenerBuffer = new List<IEventListener>(16);
	}

	public override void AddEventsListener()
	{
		_gameEventListener = ((Context<GameEntity>)base.Contexts.game).CreateEntity();
		_gameEventListener.AddAnyAssetListener(this);
		_configEventListener = ((Context<ConfigEntity>)base.Contexts.config).CreateEntity();
		_configEventListener.AddAnyLoadViewFromResourcesListener(this);
		_configEventListener.AddAnyLoadViewFromResourcesRemovedListener(this);
	}

	public override void RemoveEventsListener()
	{
		_gameEventListener.RemoveAnyAssetListener(this);
		((Entity)_gameEventListener).Destroy();
		_configEventListener.RemoveAnyLoadViewFromResourcesListener(this);
		_configEventListener.RemoveAnyLoadViewFromResourcesRemovedListener(this);
		((Entity)_configEventListener).Destroy();
	}

	public Transform GetViewRoot()
	{
		return _root;
	}

	public void SetViewRoot(Contexts contexts, Transform newRoot)
	{
		_root = newRoot;
	}

	public async void OnAnyAsset(GameEntity entity, string value)
	{
		if (_viewInstantiator == null)
		{
			_viewInstantiator = new UnityAddressableInstantiator();
		}
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		object obj = await _viewInstantiator.InstantiateAsync(value, entity.hasPosition ? entity.position.value : Vector3.zero);
		GameObject obj2 = (GameObject)((obj is GameObject) ? obj : null);
		if (obj2 != null)
		{
			if (!InitView(entity, obj2))
			{
				SpawnManager.Instance.Destroy(obj2);
			}
		}
		else
		{
			Debug.LogWarning((object)(value + " not found!"));
		}
	}

	public bool InitView(GameEntity entity, GameObject gameObject)
	{
		if (!((Entity)entity).isEnabled)
		{
			return false;
		}
		gameObject.transform.SetParent(_root);
		IView component = gameObject.GetComponent<IView>();
		if (component != null)
		{
			component.Initialize(base.Contexts, entity);
			entity.ReplaceView(component);
			if (component is ICharacter newValue)
			{
				entity.ReplaceCharacter(newValue);
			}
		}
		IAnimator component2 = gameObject.GetComponent<IAnimator>();
		if (component2 != null)
		{
			component2.Initialize(base.Contexts, entity);
			entity.ReplaceAnimator(component2);
		}
		ISkeleton component3 = gameObject.GetComponent<ISkeleton>();
		if (component3 != null)
		{
			component3.Initialize(base.Contexts, entity);
			entity.ReplaceSkeleton(component3);
		}
		IParticle component4 = gameObject.GetComponent<IParticle>();
		if (component4 != null)
		{
			component4.Initialize(base.Contexts, entity);
			entity.ReplaceParticle(component4);
		}
		IBattleField component5 = gameObject.GetComponent<IBattleField>();
		if (component5 != null)
		{
			component5.Initialize(base.Contexts, entity);
			entity.ReplaceBattleField(component5);
		}
		UnityCamera component6 = gameObject.GetComponent<UnityCamera>();
		if ((Object)(object)component6 != (Object)null)
		{
			component6.Initialize(base.Contexts, entity);
		}
		FloatingTextController component7 = gameObject.GetComponent<FloatingTextController>();
		if ((Object)(object)component7 != (Object)null)
		{
			component7.Initialize(base.Contexts, entity);
		}
		IAudioClip component8 = gameObject.GetComponent<IAudioClip>();
		if (component8 != null)
		{
			component8.Initialize(base.Contexts, entity);
			entity.ReplaceAudio(component8);
		}
		if (entity.hasParentId && entity.parentId.value != -1)
		{
			GameEntity entityWithId = base.Contexts.game.GetEntityWithId(entity.parentId.value);
			if (entityWithId != null && entityWithId.hasView)
			{
				entityWithId.view.value.AddSubView(component);
			}
		}
		Component[] components = gameObject.GetComponents(typeof(IEventListener));
		Component[] array = components;
		foreach (Component val in array)
		{
			((IEventListener)val).RegisterListeners();
		}
		return true;
	}

	public void OnAnyLoadViewFromResources(ConfigEntity entity)
	{
		_viewInstantiator = new UnityAddressableInstantiator();
	}

	public void OnAnyLoadViewFromResourcesRemoved(ConfigEntity entity)
	{
		_viewInstantiator = new UnityAddressableInstantiator();
	}
}
