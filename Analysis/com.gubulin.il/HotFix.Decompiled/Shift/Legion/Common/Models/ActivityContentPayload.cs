using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class ActivityContentPayload
{
	public int ContentIndex = -1;

	public Activity Activity;

	public Dictionary<string, List<float>> CaseConfig;

	public List<string> Tips;

	public string Type;

	public ActivityContentPayload(Dictionary<string, object> data)
	{
		if (data.TryGetValue("Type", out var value))
		{
			Type = value.ToString();
		}
		if (data.TryGetValue("Case", out var value2))
		{
			CaseConfig = new Dictionary<string, List<float>>();
			foreach (string key in ((Dictionary<string, object>)value2).Keys)
			{
				CaseConfig.Add(key, new List<float>());
				object obj = ((Dictionary<string, object>)value2)[key];
				foreach (object item in (IList)obj)
				{
					CaseConfig[key].Add(NumericParser.Float(item.ToString()));
				}
			}
		}
		Tips = new List<string>();
		if (data.TryGetValue("Tips", out var value3))
		{
			for (int i = 0; i < ((ArrayList)value3).Count; i++)
			{
				Tips.Add((string)((ArrayList)value3)[i]);
			}
		}
	}

	public virtual void BeforeReset(GameManagers managers, bool autoReset = false)
	{
	}

	public virtual void AfterReset(GameManagers managers)
	{
	}

	public virtual void Reset(GameManagers managers, bool autoReset = false)
	{
	}

	public virtual bool HasAnyNewMsg(GameManagers managers)
	{
		return false;
	}

	public virtual void OnBegin(GameManagers managers)
	{
	}

	public virtual void OnFinish(GameManagers managers)
	{
	}

	public virtual void OnContentChanged(object content)
	{
	}
}
