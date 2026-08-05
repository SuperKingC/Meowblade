using System;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Config<T> : IConfigUserData
{
	private T _value;

	private UserData _data;

	public readonly string Key;

	public Action<UserData> DataChanged;

	public Config(string key, UserData data)
	{
		Key = key;
		SetUserData(data);
	}

	public static T ConvertValueType(string value)
	{
		return (T)Convert.ChangeType(value, typeof(T));
	}

	public UserData GetData()
	{
		return _data;
	}

	public T GetValue()
	{
		return _value;
	}

	public void SetValue(T value)
	{
		_value = value;
		Save();
	}

	public void Save()
	{
	}

	public void SetOriginalValue(string value)
	{
		string data = _data.Data;
		_data.Data = value;
		if (_data.Type == 1)
		{
			_value = JsonHelper.ToObject<T>(_data.Data);
		}
		else
		{
			try
			{
				_value = ConvertValueType(_data.Data);
			}
			catch (Exception)
			{
				_value = default(T);
			}
		}
		if (data != _data.Data)
		{
			DataChanged?.Invoke(_data);
		}
	}

	public void SetUserData(UserData data)
	{
		_data = data;
		if (_data.Type == 1)
		{
			_value = JsonHelper.ToObject<T>(data.Data);
			return;
		}
		if (data.Data == null)
		{
			_value = default(T);
			return;
		}
		try
		{
			_value = ConvertValueType(data.Data);
		}
		catch (Exception)
		{
			_value = default(T);
		}
	}
}
