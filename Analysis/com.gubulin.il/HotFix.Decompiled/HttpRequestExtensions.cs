using System;
using System.Net.Http;

public static class HttpRequestExtensions
{
	private const string TimeoutPropertyKey = "RequestTimeout";

	public static void SetTimeout(this HttpRequestMessage request, TimeSpan? timeout)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		request.Properties["RequestTimeout"] = timeout;
	}

	public static TimeSpan? GetTimeout(this HttpRequestMessage request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (request.Properties.TryGetValue("RequestTimeout", out object value) && value is TimeSpan value2)
		{
			return value2;
		}
		return null;
	}
}
