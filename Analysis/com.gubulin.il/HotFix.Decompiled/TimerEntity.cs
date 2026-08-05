using System;
using System.Collections.Generic;
using Entitas;

public sealed class TimerEntity : Entity, IDestroyableEntity, IDestroyedEntity, IDurationEntity, IElapsedTimeEntity, IIdEntity, INameEntity, ITickElapsedTimeEntity, ITickIntervalEntity
{
	private static readonly DestroyableComponent destroyableComponent = new DestroyableComponent();

	private static readonly DestroyedComponent destroyedComponent = new DestroyedComponent();

	private static readonly ReadyToTriggerComponent readyToTriggerComponent = new ReadyToTriggerComponent();

	public CallbackActionComponent callbackAction => (CallbackActionComponent)(object)((Entity)this).GetComponent(0);

	public bool hasCallbackAction => ((Entity)this).HasComponent(0);

	public bool isDestroyable
	{
		get
		{
			return ((Entity)this).HasComponent(1);
		}
		set
		{
			if (value == isDestroyable)
			{
				return;
			}
			int num = 1;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)destroyableComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public bool isDestroyed
	{
		get
		{
			return ((Entity)this).HasComponent(2);
		}
		set
		{
			if (value == isDestroyed)
			{
				return;
			}
			int num = 2;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)destroyedComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public DurationComponent duration => (DurationComponent)(object)((Entity)this).GetComponent(3);

	public bool hasDuration => ((Entity)this).HasComponent(3);

	public ElapsedTimeComponent elapsedTime => (ElapsedTimeComponent)(object)((Entity)this).GetComponent(4);

	public bool hasElapsedTime => ((Entity)this).HasComponent(4);

	public IdComponent id => (IdComponent)(object)((Entity)this).GetComponent(5);

	public bool hasId => ((Entity)this).HasComponent(5);

	public NameComponent name => (NameComponent)(object)((Entity)this).GetComponent(6);

	public bool hasName => ((Entity)this).HasComponent(6);

	public bool isReadyToTrigger
	{
		get
		{
			return ((Entity)this).HasComponent(7);
		}
		set
		{
			if (value == isReadyToTrigger)
			{
				return;
			}
			int num = 7;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)readyToTriggerComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public RepeatComponent repeat => (RepeatComponent)(object)((Entity)this).GetComponent(8);

	public bool hasRepeat => ((Entity)this).HasComponent(8);

	public TickElapsedTimeComponent tickElapsedTime => (TickElapsedTimeComponent)(object)((Entity)this).GetComponent(9);

	public bool hasTickElapsedTime => ((Entity)this).HasComponent(9);

	public TickIntervalComponent tickInterval => (TickIntervalComponent)(object)((Entity)this).GetComponent(10);

	public bool hasTickInterval => ((Entity)this).HasComponent(10);

	public TimerDestroyedListenerComponent timerDestroyedListener => (TimerDestroyedListenerComponent)(object)((Entity)this).GetComponent(11);

	public bool hasTimerDestroyedListener => ((Entity)this).HasComponent(11);

	public void AddCallbackAction(Action newValue)
	{
		int num = 0;
		CallbackActionComponent callbackActionComponent = (CallbackActionComponent)(object)((Entity)this).CreateComponent(num, typeof(CallbackActionComponent));
		callbackActionComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)callbackActionComponent);
	}

	public void ReplaceCallbackAction(Action newValue)
	{
		int num = 0;
		CallbackActionComponent callbackActionComponent = (CallbackActionComponent)(object)((Entity)this).CreateComponent(num, typeof(CallbackActionComponent));
		callbackActionComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)callbackActionComponent);
	}

	public void RemoveCallbackAction()
	{
		((Entity)this).RemoveComponent(0);
	}

	public void AddDuration(float newValue)
	{
		int num = 3;
		DurationComponent durationComponent = (DurationComponent)(object)((Entity)this).CreateComponent(num, typeof(DurationComponent));
		durationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)durationComponent);
	}

	public void ReplaceDuration(float newValue)
	{
		int num = 3;
		DurationComponent durationComponent = (DurationComponent)(object)((Entity)this).CreateComponent(num, typeof(DurationComponent));
		durationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)durationComponent);
	}

	public void RemoveDuration()
	{
		((Entity)this).RemoveComponent(3);
	}

	public void AddElapsedTime(float newValue)
	{
		int num = 4;
		ElapsedTimeComponent elapsedTimeComponent = (ElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ElapsedTimeComponent));
		elapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)elapsedTimeComponent);
	}

	public void ReplaceElapsedTime(float newValue)
	{
		int num = 4;
		ElapsedTimeComponent elapsedTimeComponent = (ElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(ElapsedTimeComponent));
		elapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)elapsedTimeComponent);
	}

	public void RemoveElapsedTime()
	{
		((Entity)this).RemoveComponent(4);
	}

	public void AddId(int newValue)
	{
		int num = 5;
		IdComponent idComponent = (IdComponent)(object)((Entity)this).CreateComponent(num, typeof(IdComponent));
		idComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)idComponent);
	}

	public void ReplaceId(int newValue)
	{
		int num = 5;
		IdComponent idComponent = (IdComponent)(object)((Entity)this).CreateComponent(num, typeof(IdComponent));
		idComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)idComponent);
	}

	public void RemoveId()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddName(string newValue)
	{
		int num = 6;
		NameComponent nameComponent = (NameComponent)(object)((Entity)this).CreateComponent(num, typeof(NameComponent));
		nameComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)nameComponent);
	}

	public void ReplaceName(string newValue)
	{
		int num = 6;
		NameComponent nameComponent = (NameComponent)(object)((Entity)this).CreateComponent(num, typeof(NameComponent));
		nameComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)nameComponent);
	}

	public void RemoveName()
	{
		((Entity)this).RemoveComponent(6);
	}

	public void AddRepeat(int newValue)
	{
		int num = 8;
		RepeatComponent repeatComponent = (RepeatComponent)(object)((Entity)this).CreateComponent(num, typeof(RepeatComponent));
		repeatComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)repeatComponent);
	}

	public void ReplaceRepeat(int newValue)
	{
		int num = 8;
		RepeatComponent repeatComponent = (RepeatComponent)(object)((Entity)this).CreateComponent(num, typeof(RepeatComponent));
		repeatComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)repeatComponent);
	}

	public void RemoveRepeat()
	{
		((Entity)this).RemoveComponent(8);
	}

	public void AddTickElapsedTime(float newValue)
	{
		int num = 9;
		TickElapsedTimeComponent tickElapsedTimeComponent = (TickElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(TickElapsedTimeComponent));
		tickElapsedTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tickElapsedTimeComponent);
	}

	public void ReplaceTickElapsedTime(float newValue)
	{
		int num = 9;
		TickElapsedTimeComponent tickElapsedTimeComponent = (TickElapsedTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(TickElapsedTimeComponent));
		tickElapsedTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tickElapsedTimeComponent);
	}

	public void RemoveTickElapsedTime()
	{
		((Entity)this).RemoveComponent(9);
	}

	public void AddTickInterval(float newValue)
	{
		int num = 10;
		TickIntervalComponent tickIntervalComponent = (TickIntervalComponent)(object)((Entity)this).CreateComponent(num, typeof(TickIntervalComponent));
		tickIntervalComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tickIntervalComponent);
	}

	public void ReplaceTickInterval(float newValue)
	{
		int num = 10;
		TickIntervalComponent tickIntervalComponent = (TickIntervalComponent)(object)((Entity)this).CreateComponent(num, typeof(TickIntervalComponent));
		tickIntervalComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tickIntervalComponent);
	}

	public void RemoveTickInterval()
	{
		((Entity)this).RemoveComponent(10);
	}

	public void AddTimerDestroyedListener(List<ITimerDestroyedListener> newValue)
	{
		int num = 11;
		TimerDestroyedListenerComponent timerDestroyedListenerComponent = (TimerDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(TimerDestroyedListenerComponent));
		timerDestroyedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)timerDestroyedListenerComponent);
	}

	public void ReplaceTimerDestroyedListener(List<ITimerDestroyedListener> newValue)
	{
		int num = 11;
		TimerDestroyedListenerComponent timerDestroyedListenerComponent = (TimerDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(TimerDestroyedListenerComponent));
		timerDestroyedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)timerDestroyedListenerComponent);
	}

	public void RemoveTimerDestroyedListener()
	{
		((Entity)this).RemoveComponent(11);
	}

	public void AddTimerDestroyedListener(ITimerDestroyedListener value)
	{
		List<ITimerDestroyedListener> list = (hasTimerDestroyedListener ? timerDestroyedListener.value : new List<ITimerDestroyedListener>());
		list.Add(value);
		ReplaceTimerDestroyedListener(list);
	}

	public void RemoveTimerDestroyedListener(ITimerDestroyedListener value, bool removeComponentWhenEmpty = true)
	{
		List<ITimerDestroyedListener> value2 = timerDestroyedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveTimerDestroyedListener();
		}
		else
		{
			ReplaceTimerDestroyedListener(value2);
		}
	}
}
