using Entitas;
using HotFix;
using UnityEngine;

public class UnityParticle : MonoBehaviour, IParticle, IEventListener, IPooled, IAnyReplayStateListener
{
	private const int ParticleStateStopped = 0;

	private const int ParticleStatePlaying = 1;

	private const int ParticleStatePaused = 2;

	private GameEntity _entity;

	private GameStateEntity _stateEntity;

	private ParticleSystem _particleSystem;

	private int _lastParticleState;

	private int _lastReplayState;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		_entity = entity;
		_stateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		int sortingLayerID = SortingLayer.NameToID("Entities");
		if (_entity.isParticleFullscreen)
		{
			sortingLayerID = SortingLayer.NameToID("UI");
		}
		ParticleSystem[] componentsInChildren = ((Component)this).GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] array = componentsInChildren;
		foreach (ParticleSystem val in array)
		{
			ParticleSystemRenderer component = ((Component)val).GetComponent<ParticleSystemRenderer>();
			((Renderer)component).sortingLayerID = sortingLayerID;
		}
		SpriteRenderer[] componentsInChildren2 = ((Component)this).GetComponentsInChildren<SpriteRenderer>();
		SpriteRenderer[] array2 = componentsInChildren2;
		foreach (SpriteRenderer val2 in array2)
		{
			((Renderer)val2).sortingLayerID = sortingLayerID;
		}
		_particleSystem = ((Component)this).GetComponent<ParticleSystem>();
		Stop();
	}

	public void Play()
	{
		_particleSystem.Play();
		_lastParticleState = 1;
	}

	public void Restart()
	{
		Stop();
		Play();
	}

	public void Pause()
	{
		_particleSystem.Pause();
		_lastParticleState = 2;
	}

	public void Stop()
	{
		_particleSystem.Stop(true, (ParticleSystemStopBehavior)0);
		_lastParticleState = 0;
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
		_lastReplayState = 1;
	}

	public void OnUnSpawn()
	{
		if (_entity != null)
		{
			UnregisterListeners();
			Stop();
			if (_stateEntity != null)
			{
				((Entity)_stateEntity).Destroy();
				_stateEntity = null;
			}
			_entity = null;
			_particleSystem = null;
		}
	}

	public void RegisterListeners()
	{
		_stateEntity.AddAnyReplayStateListener(this);
	}

	public void UnregisterListeners()
	{
		_stateEntity.RemoveAnyReplayStateListener(this);
	}

	public void OnAnyReplayState(GameStateEntity entity, int value)
	{
		if (value != 1)
		{
			_particleSystem.Pause();
		}
		else if (_lastReplayState != 1)
		{
			switch (_lastParticleState)
			{
			case 0:
				Stop();
				break;
			case 1:
				Play();
				break;
			case 2:
				Pause();
				break;
			}
		}
		_lastReplayState = value;
	}
}
