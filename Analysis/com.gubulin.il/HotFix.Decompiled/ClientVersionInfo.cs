using UnityEngine;

public class ClientVersionInfo
{
	private static ClientVersionInfo _Instance;

	public readonly string Code;

	public readonly string Res;

	public readonly string fmt_UserAgent;

	public static ClientVersionInfo Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new ClientVersionInfo();
			}
			return _Instance;
		}
	}

	private ClientVersionInfo()
	{
		string text = PlayerPrefs.GetString("HotUpdateFlag");
		string[] array = text.Split('_');
		if (array.Length == 2)
		{
			Code = array[1];
			Res = array[0];
		}
		else
		{
			Code = string.Empty;
			Res = string.Empty;
		}
		fmt_UserAgent = $"IL/{Application.version} ({0}; c:{Code}; r:{Res})";
	}

	public string UserAgent(string env)
	{
		return string.Format(fmt_UserAgent, env);
	}
}
