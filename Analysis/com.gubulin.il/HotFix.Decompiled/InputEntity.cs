using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class InputEntity : Entity, IDestroyedEntity
{
	private static readonly DestroyedComponent destroyedComponent = new DestroyedComponent();

	public AnyMouseScrollDeltaListenerComponent anyMouseScrollDeltaListener => (AnyMouseScrollDeltaListenerComponent)(object)((Entity)this).GetComponent(0);

	public bool hasAnyMouseScrollDeltaListener => ((Entity)this).HasComponent(0);

	public AnyZoomDeltaListenerComponent anyZoomDeltaListener => (AnyZoomDeltaListenerComponent)(object)((Entity)this).GetComponent(1);

	public bool hasAnyZoomDeltaListener => ((Entity)this).HasComponent(1);

	public DeltaTimeComponent deltaTime => (DeltaTimeComponent)(object)((Entity)this).GetComponent(2);

	public bool hasDeltaTime => ((Entity)this).HasComponent(2);

	public bool isDestroyed
	{
		get
		{
			return ((Entity)this).HasComponent(3);
		}
		set
		{
			if (value == isDestroyed)
			{
				return;
			}
			int num = 3;
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

	public FixedDeltaTimeComponent fixedDeltaTime => (FixedDeltaTimeComponent)(object)((Entity)this).GetComponent(4);

	public bool hasFixedDeltaTime => ((Entity)this).HasComponent(4);

	public InputDestroyedListenerComponent inputDestroyedListener => (InputDestroyedListenerComponent)(object)((Entity)this).GetComponent(5);

	public bool hasInputDestroyedListener => ((Entity)this).HasComponent(5);

	public MouseScrollDeltaComponent mouseScrollDelta => (MouseScrollDeltaComponent)(object)((Entity)this).GetComponent(6);

	public bool hasMouseScrollDelta => ((Entity)this).HasComponent(6);

	public TickComponent tick => (TickComponent)(object)((Entity)this).GetComponent(7);

	public bool hasTick => ((Entity)this).HasComponent(7);

	public TouchesComponent touches => (TouchesComponent)(object)((Entity)this).GetComponent(8);

	public bool hasTouches => ((Entity)this).HasComponent(8);

	public ZoomDeltaComponent zoomDelta => (ZoomDeltaComponent)(object)((Entity)this).GetComponent(9);

	public bool hasZoomDelta => ((Entity)this).HasComponent(9);

	public void AddAnyMouseScrollDeltaListener(List<IAnyMouseScrollDeltaListener> newValue)
	{
		int num = 0;
		AnyMouseScrollDeltaListenerComponent anyMouseScrollDeltaListenerComponent = (AnyMouseScrollDeltaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyMouseScrollDeltaListenerComponent));
		anyMouseScrollDeltaListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyMouseScrollDeltaListenerComponent);
	}

	public void ReplaceAnyMouseScrollDeltaListener(List<IAnyMouseScrollDeltaListener> newValue)
	{
		int num = 0;
		AnyMouseScrollDeltaListenerComponent anyMouseScrollDeltaListenerComponent = (AnyMouseScrollDeltaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyMouseScrollDeltaListenerComponent));
		anyMouseScrollDeltaListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyMouseScrollDeltaListenerComponent);
	}

	public void RemoveAnyMouseScrollDeltaListener()
	{
		((Entity)this).RemoveComponent(0);
	}

	public void AddAnyMouseScrollDeltaListener(IAnyMouseScrollDeltaListener value)
	{
		List<IAnyMouseScrollDeltaListener> list = (hasAnyMouseScrollDeltaListener ? anyMouseScrollDeltaListener.value : new List<IAnyMouseScrollDeltaListener>());
		list.Add(value);
		ReplaceAnyMouseScrollDeltaListener(list);
	}

	public void RemoveAnyMouseScrollDeltaListener(IAnyMouseScrollDeltaListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyMouseScrollDeltaListener> value2 = anyMouseScrollDeltaListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyMouseScrollDeltaListener();
		}
		else
		{
			ReplaceAnyMouseScrollDeltaListener(value2);
		}
	}

	public void AddAnyZoomDeltaListener(List<IAnyZoomDeltaListener> newValue)
	{
		int num = 1;
		AnyZoomDeltaListenerComponent anyZoomDeltaListenerComponent = (AnyZoomDeltaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyZoomDeltaListenerComponent));
		anyZoomDeltaListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyZoomDeltaListenerComponent);
	}

	public void ReplaceAnyZoomDeltaListener(List<IAnyZoomDeltaListener> newValue)
	{
		int num = 1;
		AnyZoomDeltaListenerComponent anyZoomDeltaListenerComponent = (AnyZoomDeltaListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyZoomDeltaListenerComponent));
		anyZoomDeltaListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyZoomDeltaListenerComponent);
	}

	public void RemoveAnyZoomDeltaListener()
	{
		((Entity)this).RemoveComponent(1);
	}

	public void AddAnyZoomDeltaListener(IAnyZoomDeltaListener value)
	{
		List<IAnyZoomDeltaListener> list = (hasAnyZoomDeltaListener ? anyZoomDeltaListener.value : new List<IAnyZoomDeltaListener>());
		list.Add(value);
		ReplaceAnyZoomDeltaListener(list);
	}

	public void RemoveAnyZoomDeltaListener(IAnyZoomDeltaListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyZoomDeltaListener> value2 = anyZoomDeltaListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyZoomDeltaListener();
		}
		else
		{
			ReplaceAnyZoomDeltaListener(value2);
		}
	}

	public void AddDeltaTime(float newValue)
	{
		int num = 2;
		DeltaTimeComponent deltaTimeComponent = (DeltaTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(DeltaTimeComponent));
		deltaTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)deltaTimeComponent);
	}

	public void ReplaceDeltaTime(float newValue)
	{
		int num = 2;
		DeltaTimeComponent deltaTimeComponent = (DeltaTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(DeltaTimeComponent));
		deltaTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)deltaTimeComponent);
	}

	public void RemoveDeltaTime()
	{
		((Entity)this).RemoveComponent(2);
	}

	public void AddFixedDeltaTime(float newValue)
	{
		int num = 4;
		FixedDeltaTimeComponent fixedDeltaTimeComponent = (FixedDeltaTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(FixedDeltaTimeComponent));
		fixedDeltaTimeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)fixedDeltaTimeComponent);
	}

	public void ReplaceFixedDeltaTime(float newValue)
	{
		int num = 4;
		FixedDeltaTimeComponent fixedDeltaTimeComponent = (FixedDeltaTimeComponent)(object)((Entity)this).CreateComponent(num, typeof(FixedDeltaTimeComponent));
		fixedDeltaTimeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)fixedDeltaTimeComponent);
	}

	public void RemoveFixedDeltaTime()
	{
		((Entity)this).RemoveComponent(4);
	}

	public void AddInputDestroyedListener(List<IInputDestroyedListener> newValue)
	{
		int num = 5;
		InputDestroyedListenerComponent inputDestroyedListenerComponent = (InputDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(InputDestroyedListenerComponent));
		inputDestroyedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)inputDestroyedListenerComponent);
	}

	public void ReplaceInputDestroyedListener(List<IInputDestroyedListener> newValue)
	{
		int num = 5;
		InputDestroyedListenerComponent inputDestroyedListenerComponent = (InputDestroyedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(InputDestroyedListenerComponent));
		inputDestroyedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)inputDestroyedListenerComponent);
	}

	public void RemoveInputDestroyedListener()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddInputDestroyedListener(IInputDestroyedListener value)
	{
		List<IInputDestroyedListener> list = (hasInputDestroyedListener ? inputDestroyedListener.value : new List<IInputDestroyedListener>());
		list.Add(value);
		ReplaceInputDestroyedListener(list);
	}

	public void RemoveInputDestroyedListener(IInputDestroyedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IInputDestroyedListener> value2 = inputDestroyedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveInputDestroyedListener();
		}
		else
		{
			ReplaceInputDestroyedListener(value2);
		}
	}

	public void AddMouseScrollDelta(float newValue)
	{
		int num = 6;
		MouseScrollDeltaComponent mouseScrollDeltaComponent = (MouseScrollDeltaComponent)(object)((Entity)this).CreateComponent(num, typeof(MouseScrollDeltaComponent));
		mouseScrollDeltaComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)mouseScrollDeltaComponent);
	}

	public void ReplaceMouseScrollDelta(float newValue)
	{
		int num = 6;
		MouseScrollDeltaComponent mouseScrollDeltaComponent = (MouseScrollDeltaComponent)(object)((Entity)this).CreateComponent(num, typeof(MouseScrollDeltaComponent));
		mouseScrollDeltaComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)mouseScrollDeltaComponent);
	}

	public void RemoveMouseScrollDelta()
	{
		((Entity)this).RemoveComponent(6);
	}

	public void AddTick(int newValue)
	{
		int num = 7;
		TickComponent tickComponent = (TickComponent)(object)((Entity)this).CreateComponent(num, typeof(TickComponent));
		tickComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)tickComponent);
	}

	public void ReplaceTick(int newValue)
	{
		int num = 7;
		TickComponent tickComponent = (TickComponent)(object)((Entity)this).CreateComponent(num, typeof(TickComponent));
		tickComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)tickComponent);
	}

	public void RemoveTick()
	{
		((Entity)this).RemoveComponent(7);
	}

	public void AddTouches(int newCount, List<Touch> newValue)
	{
		int num = 8;
		TouchesComponent touchesComponent = (TouchesComponent)(object)((Entity)this).CreateComponent(num, typeof(TouchesComponent));
		touchesComponent.count = newCount;
		touchesComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)touchesComponent);
	}

	public void ReplaceTouches(int newCount, List<Touch> newValue)
	{
		int num = 8;
		TouchesComponent touchesComponent = (TouchesComponent)(object)((Entity)this).CreateComponent(num, typeof(TouchesComponent));
		touchesComponent.count = newCount;
		touchesComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)touchesComponent);
	}

	public void RemoveTouches()
	{
		((Entity)this).RemoveComponent(8);
	}

	public void AddZoomDelta(float newValue)
	{
		int num = 9;
		ZoomDeltaComponent zoomDeltaComponent = (ZoomDeltaComponent)(object)((Entity)this).CreateComponent(num, typeof(ZoomDeltaComponent));
		zoomDeltaComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)zoomDeltaComponent);
	}

	public void ReplaceZoomDelta(float newValue)
	{
		int num = 9;
		ZoomDeltaComponent zoomDeltaComponent = (ZoomDeltaComponent)(object)((Entity)this).CreateComponent(num, typeof(ZoomDeltaComponent));
		zoomDeltaComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)zoomDeltaComponent);
	}

	public void RemoveZoomDelta()
	{
		((Entity)this).RemoveComponent(9);
	}
}
