using System.Collections.Generic;
using Shift.Legion.Helpers;
using UI.GameActivity;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Services.UiService;

public class ProfilerPanelOpenTime
{
	private class Item
	{
		public string Id;

		public int OC;

		public double TT;

		public double AT;

		public double IT;
	}

	private static ProfilerPanelOpenTime _instance;

	private const string FILE_KEY = "PanelOpenTimeLog";

	private const string UPLOAD_LOG_TIME_KEY = "PanelOpenTimeUploadTime";

	private HashSet<string> _specialPanels;

	private HashSet<string> _ignorePanels;

	private Dictionary<string, double> _startOpenTime;

	private Dictionary<string, Item> _logs;

	public static void Init()
	{
		if (HotUpdateProcess.Instance.Configs.TryGetValue("PanelProfiler", out var value) && !(value == "0") && _instance == null)
		{
			_instance = new ProfilerPanelOpenTime();
			_instance.Start();
		}
	}

	private void Start()
	{
		_specialPanels = new HashSet<string> { UI_ActivityPanel.Name };
		_ignorePanels = new HashSet<string> { UI_SomeTipPanel.Name };
		_startOpenTime = new Dictionary<string, double>();
		_logs = new Dictionary<string, Item>();
		if (PlayerPrefs.HasKey("PanelOpenTimeLog"))
		{
			string json = PlayerPrefs.GetString("PanelOpenTimeLog");
			List<Item> list = JsonHelper.ToObject<List<Item>>(json);
			foreach (Item item in list)
			{
				_logs[item.Id] = item;
			}
		}
		bool flag = PlayerPrefs.HasKey("PanelOpenTimeUploadTime");
		int serverTimestamp = GameController.Instance.GetServerTimestamp();
		if (flag)
		{
			int num = PlayerPrefs.GetInt("PanelOpenTimeUploadTime");
			if (serverTimestamp > num)
			{
				UploadLogs();
				int num2 = serverTimestamp + 86400;
				PlayerPrefs.SetInt("PanelOpenTimeUploadTime", num2);
				PlayerPrefs.DeleteKey("PanelOpenTimeLog");
				_logs.Clear();
			}
		}
		else
		{
			int num3 = serverTimestamp + 86400;
			PlayerPrefs.SetInt("PanelOpenTimeUploadTime", num3);
		}
		SharedMessenger.AddListener<string>("START_LOADING_UI", OnPanelOpenStart);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnPanelOpenEnd);
		SharedMessenger.AddListener<string>("SPECIAL_OPEN_UI", OnPanelShowComplete);
	}

	private void OnPanelOpenStart(string identifier)
	{
		if (!_ignorePanels.Contains(identifier))
		{
			_startOpenTime[identifier] = GetTime();
		}
	}

	private void OnPanelOpenEnd(string identifier, Dictionary<string, object> param)
	{
		if (!_specialPanels.Contains(identifier))
		{
			OnPanelOpenComplete(identifier);
		}
	}

	private void OnPanelShowComplete(string identifier)
	{
		if (_specialPanels.Contains(identifier))
		{
			OnPanelOpenComplete(identifier);
		}
	}

	private void OnPanelOpenComplete(string identifier)
	{
		if (_startOpenTime.ContainsKey(identifier))
		{
			double time = GetTime();
			double time2 = time - _startOpenTime[identifier];
			_startOpenTime.Remove(identifier);
			AddLog(identifier, time2);
		}
	}

	private static double GetTime()
	{
		return GameController.Instance.GetServerRealtimeSeconds();
	}

	private void AddLog(string identifier, double time)
	{
		if (!(time <= 0.1))
		{
			Item value = null;
			if (_logs.TryGetValue(identifier, out value))
			{
				value.OC++;
				value.TT += time;
				value.AT = Mathf.Max((float)value.AT, (float)time);
				value.IT = Mathf.Min((float)value.IT, (float)time);
			}
			else
			{
				value = new Item
				{
					Id = identifier,
					OC = 1,
					TT = time,
					AT = time,
					IT = time
				};
				_logs[identifier] = value;
			}
			SaveLogs();
		}
	}

	private void SaveLogs()
	{
		List<Item> obj = new List<Item>(_logs.Values);
		string text = JsonHelper.ToJson(obj);
		PlayerPrefs.SetString("PanelOpenTimeLog", text);
	}

	private void UploadLogs()
	{
		foreach (Item value in _logs.Values)
		{
			double num = value.TT / (double)Mathf.Max(1, value.OC);
			ThinkingDataHelper.Instance.Track("panel_open_time", new Dictionary<string, object>
			{
				{ "panel_name", value.Id },
				{ "open_count", value.OC },
				{ "average_time", num },
				{ "max_time", value.AT },
				{ "min_time", value.IT }
			});
		}
	}
}
