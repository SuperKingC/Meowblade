using System;

public static class TimerComponentsLookup
{
	public const int CallbackAction = 0;

	public const int Destroyable = 1;

	public const int Destroyed = 2;

	public const int Duration = 3;

	public const int ElapsedTime = 4;

	public const int Id = 5;

	public const int Name = 6;

	public const int ReadyToTrigger = 7;

	public const int Repeat = 8;

	public const int TickElapsedTime = 9;

	public const int TickInterval = 10;

	public const int TimerDestroyedListener = 11;

	public const int TotalComponents = 12;

	public static readonly string[] componentNames = new string[12]
	{
		"CallbackAction", "Destroyable", "Destroyed", "Duration", "ElapsedTime", "Id", "Name", "ReadyToTrigger", "Repeat", "TickElapsedTime",
		"TickInterval", "TimerDestroyedListener"
	};

	public static readonly Type[] componentTypes = new Type[12]
	{
		typeof(CallbackActionComponent),
		typeof(DestroyableComponent),
		typeof(DestroyedComponent),
		typeof(DurationComponent),
		typeof(ElapsedTimeComponent),
		typeof(IdComponent),
		typeof(NameComponent),
		typeof(ReadyToTriggerComponent),
		typeof(RepeatComponent),
		typeof(TickElapsedTimeComponent),
		typeof(TickIntervalComponent),
		typeof(TimerDestroyedListenerComponent)
	};
}
