using System;

public static class InputComponentsLookup
{
	public const int AnyMouseScrollDeltaListener = 0;

	public const int AnyZoomDeltaListener = 1;

	public const int DeltaTime = 2;

	public const int Destroyed = 3;

	public const int FixedDeltaTime = 4;

	public const int InputDestroyedListener = 5;

	public const int MouseScrollDelta = 6;

	public const int Tick = 7;

	public const int Touches = 8;

	public const int ZoomDelta = 9;

	public const int TotalComponents = 10;

	public static readonly string[] componentNames = new string[10] { "AnyMouseScrollDeltaListener", "AnyZoomDeltaListener", "DeltaTime", "Destroyed", "FixedDeltaTime", "InputDestroyedListener", "MouseScrollDelta", "Tick", "Touches", "ZoomDelta" };

	public static readonly Type[] componentTypes = new Type[10]
	{
		typeof(AnyMouseScrollDeltaListenerComponent),
		typeof(AnyZoomDeltaListenerComponent),
		typeof(DeltaTimeComponent),
		typeof(DestroyedComponent),
		typeof(FixedDeltaTimeComponent),
		typeof(InputDestroyedListenerComponent),
		typeof(MouseScrollDeltaComponent),
		typeof(TickComponent),
		typeof(TouchesComponent),
		typeof(ZoomDeltaComponent)
	};
}
