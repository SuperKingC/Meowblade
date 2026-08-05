using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class InputContext : Context<InputEntity>
{
	public InputEntity deltaTimeEntity => base.GetGroup(InputMatcher.DeltaTime).GetSingleEntity();

	public DeltaTimeComponent deltaTime => deltaTimeEntity.deltaTime;

	public bool hasDeltaTime => deltaTimeEntity != null;

	public InputEntity fixedDeltaTimeEntity => base.GetGroup(InputMatcher.FixedDeltaTime).GetSingleEntity();

	public FixedDeltaTimeComponent fixedDeltaTime => fixedDeltaTimeEntity.fixedDeltaTime;

	public bool hasFixedDeltaTime => fixedDeltaTimeEntity != null;

	public InputEntity mouseScrollDeltaEntity => base.GetGroup(InputMatcher.MouseScrollDelta).GetSingleEntity();

	public MouseScrollDeltaComponent mouseScrollDelta => mouseScrollDeltaEntity.mouseScrollDelta;

	public bool hasMouseScrollDelta => mouseScrollDeltaEntity != null;

	public InputEntity tickEntity => base.GetGroup(InputMatcher.Tick).GetSingleEntity();

	public TickComponent tick => tickEntity.tick;

	public bool hasTick => tickEntity != null;

	public InputEntity touchesEntity => base.GetGroup(InputMatcher.Touches).GetSingleEntity();

	public TouchesComponent touches => touchesEntity.touches;

	public bool hasTouches => touchesEntity != null;

	public InputEntity zoomDeltaEntity => base.GetGroup(InputMatcher.ZoomDelta).GetSingleEntity();

	public ZoomDeltaComponent zoomDelta => zoomDeltaEntity.zoomDelta;

	public bool hasZoomDelta => zoomDeltaEntity != null;

	public InputEntity SetDeltaTime(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasDeltaTime)
		{
			throw new EntitasException("Could not set DeltaTime!\n" + ((object)this)?.ToString() + " already has an entity with DeltaTimeComponent!", "You should check if the context already has a deltaTimeEntity before setting it or use context.ReplaceDeltaTime().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddDeltaTime(newValue);
		return inputEntity;
	}

	public void ReplaceDeltaTime(float newValue)
	{
		InputEntity inputEntity = deltaTimeEntity;
		if (inputEntity == null)
		{
			inputEntity = SetDeltaTime(newValue);
		}
		else
		{
			inputEntity.ReplaceDeltaTime(newValue);
		}
	}

	public void RemoveDeltaTime()
	{
		((Entity)deltaTimeEntity).Destroy();
	}

	public InputEntity SetFixedDeltaTime(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasFixedDeltaTime)
		{
			throw new EntitasException("Could not set FixedDeltaTime!\n" + ((object)this)?.ToString() + " already has an entity with FixedDeltaTimeComponent!", "You should check if the context already has a fixedDeltaTimeEntity before setting it or use context.ReplaceFixedDeltaTime().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddFixedDeltaTime(newValue);
		return inputEntity;
	}

	public void ReplaceFixedDeltaTime(float newValue)
	{
		InputEntity inputEntity = fixedDeltaTimeEntity;
		if (inputEntity == null)
		{
			inputEntity = SetFixedDeltaTime(newValue);
		}
		else
		{
			inputEntity.ReplaceFixedDeltaTime(newValue);
		}
	}

	public void RemoveFixedDeltaTime()
	{
		((Entity)fixedDeltaTimeEntity).Destroy();
	}

	public InputEntity SetMouseScrollDelta(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasMouseScrollDelta)
		{
			throw new EntitasException("Could not set MouseScrollDelta!\n" + ((object)this)?.ToString() + " already has an entity with MouseScrollDeltaComponent!", "You should check if the context already has a mouseScrollDeltaEntity before setting it or use context.ReplaceMouseScrollDelta().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddMouseScrollDelta(newValue);
		return inputEntity;
	}

	public void ReplaceMouseScrollDelta(float newValue)
	{
		InputEntity inputEntity = mouseScrollDeltaEntity;
		if (inputEntity == null)
		{
			inputEntity = SetMouseScrollDelta(newValue);
		}
		else
		{
			inputEntity.ReplaceMouseScrollDelta(newValue);
		}
	}

	public void RemoveMouseScrollDelta()
	{
		((Entity)mouseScrollDeltaEntity).Destroy();
	}

	public InputEntity SetTick(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasTick)
		{
			throw new EntitasException("Could not set Tick!\n" + ((object)this)?.ToString() + " already has an entity with TickComponent!", "You should check if the context already has a tickEntity before setting it or use context.ReplaceTick().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddTick(newValue);
		return inputEntity;
	}

	public void ReplaceTick(int newValue)
	{
		InputEntity inputEntity = tickEntity;
		if (inputEntity == null)
		{
			inputEntity = SetTick(newValue);
		}
		else
		{
			inputEntity.ReplaceTick(newValue);
		}
	}

	public void RemoveTick()
	{
		((Entity)tickEntity).Destroy();
	}

	public InputEntity SetTouches(int newCount, List<Touch> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasTouches)
		{
			throw new EntitasException("Could not set Touches!\n" + ((object)this)?.ToString() + " already has an entity with TouchesComponent!", "You should check if the context already has a touchesEntity before setting it or use context.ReplaceTouches().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddTouches(newCount, newValue);
		return inputEntity;
	}

	public void ReplaceTouches(int newCount, List<Touch> newValue)
	{
		InputEntity inputEntity = touchesEntity;
		if (inputEntity == null)
		{
			inputEntity = SetTouches(newCount, newValue);
		}
		else
		{
			inputEntity.ReplaceTouches(newCount, newValue);
		}
	}

	public void RemoveTouches()
	{
		((Entity)touchesEntity).Destroy();
	}

	public InputEntity SetZoomDelta(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasZoomDelta)
		{
			throw new EntitasException("Could not set ZoomDelta!\n" + ((object)this)?.ToString() + " already has an entity with ZoomDeltaComponent!", "You should check if the context already has a zoomDeltaEntity before setting it or use context.ReplaceZoomDelta().");
		}
		InputEntity inputEntity = base.CreateEntity();
		inputEntity.AddZoomDelta(newValue);
		return inputEntity;
	}

	public void ReplaceZoomDelta(float newValue)
	{
		InputEntity inputEntity = zoomDeltaEntity;
		if (inputEntity == null)
		{
			inputEntity = SetZoomDelta(newValue);
		}
		else
		{
			inputEntity.ReplaceZoomDelta(newValue);
		}
	}

	public void RemoveZoomDelta()
	{
		((Entity)zoomDeltaEntity).Destroy();
	}

	public InputContext()
		: base(10, 0, new ContextInfo("Input", InputComponentsLookup.componentNames, InputComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<InputEntity>)(() => new InputEntity()))
	{
	}//IL_0013: Unknown result type (might be due to invalid IL or missing references)
	//IL_005b: Expected O, but got Unknown

}
