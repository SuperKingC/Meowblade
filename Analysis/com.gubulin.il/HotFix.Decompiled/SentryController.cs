using System;
using UnityEngine;

public class SentryController : MonoBehaviour
{
	[NonSerialized]
	private SentrySdk _sentry;

	public static SentryController Instance;

	private void Awake()
	{
		Instance = this;
		Init();
	}

	public void Init()
	{
		if ((Object)(object)_sentry == (Object)null)
		{
			((Component)this).gameObject.AddComponent<SentrySdk>();
			_sentry = ((Component)this).gameObject.GetComponent<SentrySdk>();
			_sentry.Debug = false;
		}
		if ((Object)(object)_sentry != (Object)null)
		{
			if (!GameController.Configs.TryGetValue("ErrDsn", out var value))
			{
				value = "https://c15e466bbe7946c9b0c1a7a37e4d7bf3@sentry.io/1356671";
			}
			_sentry.Dsn = value;
		}
	}

	public void ReportException(string condition, string stackTrace)
	{
		if (!((Object)(object)_sentry == (Object)null))
		{
			_sentry.OnLogMessageReceived(condition, stackTrace, (LogType)4);
		}
	}

	public void SetUserId(int userId)
	{
		if (!((Object)(object)_sentry == (Object)null))
		{
			_sentry.SetUserId(userId.ToString());
		}
	}

	public void SetLogEnable(bool isEnable)
	{
		((Component)this).gameObject.SetActive(isEnable);
	}
}
