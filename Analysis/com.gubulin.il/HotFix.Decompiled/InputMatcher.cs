using Entitas;

public sealed class InputMatcher
{
	private static IMatcher<InputEntity> _matcherAnyMouseScrollDeltaListener;

	private static IMatcher<InputEntity> _matcherAnyZoomDeltaListener;

	private static IMatcher<InputEntity> _matcherDeltaTime;

	private static IMatcher<InputEntity> _matcherDestroyed;

	private static IMatcher<InputEntity> _matcherFixedDeltaTime;

	private static IMatcher<InputEntity> _matcherInputDestroyedListener;

	private static IMatcher<InputEntity> _matcherMouseScrollDelta;

	private static IMatcher<InputEntity> _matcherTick;

	private static IMatcher<InputEntity> _matcherTouches;

	private static IMatcher<InputEntity> _matcherZoomDelta;

	public static IMatcher<InputEntity> AnyMouseScrollDeltaListener
	{
		get
		{
			if (_matcherAnyMouseScrollDeltaListener == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1]);
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherAnyMouseScrollDeltaListener = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherAnyMouseScrollDeltaListener;
		}
	}

	public static IMatcher<InputEntity> AnyZoomDeltaListener
	{
		get
		{
			if (_matcherAnyZoomDeltaListener == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 1 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherAnyZoomDeltaListener = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherAnyZoomDeltaListener;
		}
	}

	public static IMatcher<InputEntity> DeltaTime
	{
		get
		{
			if (_matcherDeltaTime == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 2 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherDeltaTime = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherDeltaTime;
		}
	}

	public static IMatcher<InputEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 3 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherDestroyed = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherDestroyed;
		}
	}

	public static IMatcher<InputEntity> FixedDeltaTime
	{
		get
		{
			if (_matcherFixedDeltaTime == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 4 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherFixedDeltaTime = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherFixedDeltaTime;
		}
	}

	public static IMatcher<InputEntity> InputDestroyedListener
	{
		get
		{
			if (_matcherInputDestroyedListener == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 5 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherInputDestroyedListener = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherInputDestroyedListener;
		}
	}

	public static IMatcher<InputEntity> MouseScrollDelta
	{
		get
		{
			if (_matcherMouseScrollDelta == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 6 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherMouseScrollDelta = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherMouseScrollDelta;
		}
	}

	public static IMatcher<InputEntity> Tick
	{
		get
		{
			if (_matcherTick == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 7 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherTick = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherTick;
		}
	}

	public static IMatcher<InputEntity> Touches
	{
		get
		{
			if (_matcherTouches == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 8 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherTouches = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherTouches;
		}
	}

	public static IMatcher<InputEntity> ZoomDelta
	{
		get
		{
			if (_matcherZoomDelta == null)
			{
				Matcher<InputEntity> val = (Matcher<InputEntity>)(object)Matcher<InputEntity>.AllOf(new int[1] { 9 });
				val.componentNames = InputComponentsLookup.componentNames;
				_matcherZoomDelta = (IMatcher<InputEntity>)(object)val;
			}
			return _matcherZoomDelta;
		}
	}

	public static IAllOfMatcher<InputEntity> AllOf(params int[] indices)
	{
		return Matcher<InputEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<InputEntity> AllOf(params IMatcher<InputEntity>[] matchers)
	{
		return Matcher<InputEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<InputEntity> AnyOf(params int[] indices)
	{
		return Matcher<InputEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<InputEntity> AnyOf(params IMatcher<InputEntity>[] matchers)
	{
		return Matcher<InputEntity>.AnyOf(matchers);
	}
}
