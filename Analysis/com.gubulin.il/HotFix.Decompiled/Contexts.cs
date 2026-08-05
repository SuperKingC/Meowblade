using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

public class Contexts : IContexts
{
	private static Contexts _sharedInstance;

	public const string Id = "Id";

	public const string OwnerId = "OwnerId";

	private static readonly Dictionary<string, IContext> ContextsLookup = new Dictionary<string, IContext>();

	public ILRandom Random;

	private Dictionary<Type, IService> _services;

	private IService[] _servicesArray;

	public static Contexts sharedInstance
	{
		get
		{
			if (_sharedInstance == null)
			{
				_sharedInstance = new Contexts();
			}
			return _sharedInstance;
		}
		set
		{
			_sharedInstance = value;
		}
	}

	public CommandContext command { get; set; }

	public ConfigContext config { get; set; }

	public GameContext game { get; set; }

	public GameStateContext gameState { get; set; }

	public InputContext input { get; set; }

	public TimerContext timer { get; set; }

	public UiContext ui { get; set; }

	public IContext[] allContexts => (IContext[])(object)new IContext[7]
	{
		(IContext)command,
		(IContext)config,
		(IContext)game,
		(IContext)gameState,
		(IContext)input,
		(IContext)timer,
		(IContext)ui
	};

	public IService[] Services => _servicesArray;

	public Contexts()
	{
		command = new CommandContext();
		config = new ConfigContext();
		game = new GameContext();
		gameState = new GameStateContext();
		input = new InputContext();
		timer = new TimerContext();
		ui = new UiContext();
		IEnumerable<MethodInfo> enumerable = from method in GetType().GetMethods()
			where Attribute.IsDefined(method, typeof(PostConstructorAttribute))
			select method;
		foreach (MethodInfo item in enumerable)
		{
			item.Invoke(this, null);
		}
	}

	public void Reset()
	{
		IContext[] array = allContexts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Reset();
		}
	}

	[PostConstructor]
	public void InitializeEntityIndices()
	{
		((Context<GameEntity>)game).AddEntityIndex((IEntityIndex)(object)new PrimaryEntityIndex<GameEntity, int>("Id", ((Context<GameEntity>)game).GetGroup(GameMatcher.Id), (Func<GameEntity, IComponent, int>)((GameEntity e, IComponent c) => ((IdComponent)(object)c).value)));
		((Context<TimerEntity>)timer).AddEntityIndex((IEntityIndex)(object)new PrimaryEntityIndex<TimerEntity, int>("Id", ((Context<TimerEntity>)timer).GetGroup(TimerMatcher.Id), (Func<TimerEntity, IComponent, int>)((TimerEntity e, IComponent c) => ((IdComponent)(object)c).value)));
		((Context<GameEntity>)game).AddEntityIndex((IEntityIndex)(object)new EntityIndex<GameEntity, int>("OwnerId", ((Context<GameEntity>)game).GetGroup(GameMatcher.OwnerId), (Func<GameEntity, IComponent, int>)((GameEntity e, IComponent c) => ((OwnerIdComponent)(object)c).value)));
	}

	public void SubscribeId()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		IContext[] array = allContexts;
		foreach (IContext val in array)
		{
			if (Array.FindIndex(val.contextInfo.componentTypes, (Type v) => v == typeof(IdComponent)) >= 0)
			{
				val.OnEntityCreated += new ContextEntityChanged(AddId);
			}
		}
	}

	public static void AddId(IContext context, IEntity entity)
	{
		(entity as IIdEntity)?.ReplaceId(entity.creationIndex);
	}

	public IContext GetContextByName(string name)
	{
		if (ContextsLookup.Count == 0)
		{
			SetContextsDictionary(this);
		}
		return ContextsLookup[name];
	}

	private static void SetContextsDictionary(Contexts contexts)
	{
		IContext[] array = contexts.allContexts;
		foreach (IContext val in array)
		{
			ContextsLookup.Add(val.contextInfo.name, val);
		}
	}

	public Contexts(ILRandom random)
	{
		Random = random;
		_services = new Dictionary<Type, IService>();
	}

	public T Service<T>() where T : IService
	{
		if (_services == null)
		{
			_services = new Dictionary<Type, IService>();
		}
		if (_services.TryGetValue(typeof(T), out var value))
		{
			return (T)value;
		}
		throw new Exception("不存在的Service " + typeof(T).FullName);
	}

	public void AddService<T>(Type type, T service) where T : IService
	{
		try
		{
			if (_services == null)
			{
				_services = new Dictionary<Type, IService>();
			}
			if (!_services.ContainsKey(type))
			{
				_services.Add(type, service);
				SentrySdk.AddBreadcrumb("Contexts Add Service: " + type?.FullName);
			}
			else
			{
				SentrySdk.AddBreadcrumb("Contexts Skip Add Service: " + type?.FullName);
			}
			_servicesArray = _services.Values.ToArray();
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("Contexts Add Service " + type?.FullName + " Failed: " + ex.Message);
			throw;
		}
	}

	public void RemoveService(Type type)
	{
		if (_services == null)
		{
			_services = new Dictionary<Type, IService>();
		}
		if (_services.ContainsKey(type))
		{
			_services.Remove(type);
			_servicesArray = _services.Values.ToArray();
		}
	}

	public void ClearServices()
	{
		try
		{
			if (_services == null)
			{
				_services = new Dictionary<Type, IService>();
			}
			foreach (KeyValuePair<Type, IService> service in _services)
			{
				service.Value.RemoveEventsListener();
				service.Value.Destroy();
			}
			_services.Clear();
			_servicesArray = null;
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("Contexts Clear Services Failed: " + ex.Message);
			throw;
		}
	}
}
