namespace Shift.Legion.ClientApi;

public class Log
{
	private readonly string _category;

	public Log(string category)
	{
		_category = category;
	}

	public void LogError(string format, params object[] args)
	{
	}

	public void LogWarning(string format, params object[] args)
	{
	}

	public void LogDebug(string format, params object[] args)
	{
	}
}
