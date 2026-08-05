namespace Shift.Legion.Common.Helpers;

public abstract class Singleton<T> where T : new()
{
	private class Nested<T> where T : new()
	{
		public static readonly T Instance;

		static Nested()
		{
			Instance = new T();
		}
	}

	private static T _instance;

	public static T Instance => Nested<T>.Instance;

	protected Singleton()
	{
		InitInstance();
	}

	public virtual void InitInstance()
	{
	}
}
