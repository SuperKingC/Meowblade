using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;

internal static class ILRuntimeDebug
{
	[Conditional("Debug")]
	public static void LogWarning(string _str, params object[] _params)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_params.Length != 0)
		{
			stringBuilder.AppendFormat(_str, _params);
		}
		else
		{
			stringBuilder.Append(_str);
		}
		Debug.LogWarning((object)stringBuilder);
		stringBuilder.Clear();
		_str = null;
		stringBuilder = null;
	}

	public static void Log(Exception exception)
	{
		Debug.LogException(exception);
	}

	public static void LogException(Exception exception)
	{
		Debug.LogException(exception);
	}

	public static void LogError(string _str, params object[] _params)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_params.Length != 0)
		{
			stringBuilder.AppendFormat(_str, _params);
		}
		else
		{
			stringBuilder.Append(_str);
		}
		Debug.LogError((object)stringBuilder);
		stringBuilder.Clear();
		stringBuilder = null;
	}

	public static void CatchErrorBySentry(string _str, params object[] _params)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(_str, _params);
		Debug.LogError((object)stringBuilder);
		SentryController.Instance.ReportException(stringBuilder.ToString(), "");
	}

	[Conditional("Debug")]
	public static void Log(string _str, params object[] _params)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_params.Length != 0)
		{
			stringBuilder.AppendFormat(_str, _params);
		}
		else
		{
			stringBuilder.Append(_str);
		}
		Debug.Log((object)stringBuilder);
		stringBuilder.Clear();
		stringBuilder = null;
	}

	public static void Exeption(Exception e)
	{
		Debug.LogException(e);
	}
}
