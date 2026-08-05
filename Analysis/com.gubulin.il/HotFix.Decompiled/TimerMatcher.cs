using Entitas;

public sealed class TimerMatcher
{
	private static IMatcher<TimerEntity> _matcherCallbackAction;

	private static IMatcher<TimerEntity> _matcherDestroyable;

	private static IMatcher<TimerEntity> _matcherDestroyed;

	private static IMatcher<TimerEntity> _matcherDuration;

	private static IMatcher<TimerEntity> _matcherElapsedTime;

	private static IMatcher<TimerEntity> _matcherId;

	private static IMatcher<TimerEntity> _matcherName;

	private static IMatcher<TimerEntity> _matcherReadyToTrigger;

	private static IMatcher<TimerEntity> _matcherRepeat;

	private static IMatcher<TimerEntity> _matcherTickElapsedTime;

	private static IMatcher<TimerEntity> _matcherTickInterval;

	private static IMatcher<TimerEntity> _matcherTimerDestroyedListener;

	public static IMatcher<TimerEntity> CallbackAction
	{
		get
		{
			if (_matcherCallbackAction == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1]);
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherCallbackAction = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherCallbackAction;
		}
	}

	public static IMatcher<TimerEntity> Destroyable
	{
		get
		{
			if (_matcherDestroyable == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 1 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherDestroyable = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherDestroyable;
		}
	}

	public static IMatcher<TimerEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 2 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherDestroyed = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherDestroyed;
		}
	}

	public static IMatcher<TimerEntity> Duration
	{
		get
		{
			if (_matcherDuration == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 3 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherDuration = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherDuration;
		}
	}

	public static IMatcher<TimerEntity> ElapsedTime
	{
		get
		{
			if (_matcherElapsedTime == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 4 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherElapsedTime = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherElapsedTime;
		}
	}

	public static IMatcher<TimerEntity> Id
	{
		get
		{
			if (_matcherId == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 5 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherId = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherId;
		}
	}

	public static IMatcher<TimerEntity> Name
	{
		get
		{
			if (_matcherName == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 6 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherName = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherName;
		}
	}

	public static IMatcher<TimerEntity> ReadyToTrigger
	{
		get
		{
			if (_matcherReadyToTrigger == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 7 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherReadyToTrigger = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherReadyToTrigger;
		}
	}

	public static IMatcher<TimerEntity> Repeat
	{
		get
		{
			if (_matcherRepeat == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 8 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherRepeat = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherRepeat;
		}
	}

	public static IMatcher<TimerEntity> TickElapsedTime
	{
		get
		{
			if (_matcherTickElapsedTime == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 9 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherTickElapsedTime = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherTickElapsedTime;
		}
	}

	public static IMatcher<TimerEntity> TickInterval
	{
		get
		{
			if (_matcherTickInterval == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 10 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherTickInterval = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherTickInterval;
		}
	}

	public static IMatcher<TimerEntity> TimerDestroyedListener
	{
		get
		{
			if (_matcherTimerDestroyedListener == null)
			{
				Matcher<TimerEntity> val = (Matcher<TimerEntity>)(object)Matcher<TimerEntity>.AllOf(new int[1] { 11 });
				val.componentNames = TimerComponentsLookup.componentNames;
				_matcherTimerDestroyedListener = (IMatcher<TimerEntity>)(object)val;
			}
			return _matcherTimerDestroyedListener;
		}
	}

	public static IAllOfMatcher<TimerEntity> AllOf(params int[] indices)
	{
		return Matcher<TimerEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<TimerEntity> AllOf(params IMatcher<TimerEntity>[] matchers)
	{
		return Matcher<TimerEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<TimerEntity> AnyOf(params int[] indices)
	{
		return Matcher<TimerEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<TimerEntity> AnyOf(params IMatcher<TimerEntity>[] matchers)
	{
		return Matcher<TimerEntity>.AnyOf(matchers);
	}
}
