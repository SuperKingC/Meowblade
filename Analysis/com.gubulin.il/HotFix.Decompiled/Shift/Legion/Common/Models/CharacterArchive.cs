using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class CharacterArchive
{
	public readonly int UserId;

	private readonly Dictionary<string, UserData> _data;

	public Dictionary<string, UserData>.KeyCollection Keys => _data?.Keys;

	public CharacterArchive(int userId)
	{
		UserId = userId;
		_data = new Dictionary<string, UserData>();
	}

	public void Load(Dictionary<string, UserData> data)
	{
		Clear();
		foreach (KeyValuePair<string, UserData> datum in data)
		{
			_data.Add(datum.Key, datum.Value);
		}
	}

	public void Load(IEnumerable<UserData> data)
	{
		Clear();
		foreach (UserData datum in data)
		{
			_data.Add(datum.Key, datum);
		}
	}

	public void Clear()
	{
		_data.Clear();
	}

	public bool Contains(string key)
	{
		return _data.ContainsKey(key);
	}

	public UserData Get(string key)
	{
		_data.TryGetValue(key, out var value);
		return value;
	}

	public void Set(string key, UserData data)
	{
		_data[key] = data;
	}

	public void Remove(string key)
	{
		_data.Remove(key);
	}
}
