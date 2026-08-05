using System;

public static class UiComponentsLookup
{
	public const int NewMsgIncoming = 0;

	public const int TotalComponents = 1;

	public static readonly string[] componentNames = new string[1] { "NewMsgIncoming" };

	public static readonly Type[] componentTypes = new Type[1] { typeof(NewMsgIncomingComponent) };
}
