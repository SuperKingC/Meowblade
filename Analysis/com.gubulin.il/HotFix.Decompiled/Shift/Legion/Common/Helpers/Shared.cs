namespace Shift.Legion.Common.Helpers;

public class Shared<T> where T : new()
{
	public static T Inst = new T();
}
