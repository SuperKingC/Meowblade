using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class UserArchiveManager : Manager
{
	public const string IsFirstArchiveKey = "IsFirstArchive";

	private CharacterArchive _archive;

	private Dictionary<string, UserData> _commonSettings;

	private Dictionary<string, object> _configurationDict;

	public UserArchiveManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		_archive = Managers.Archive;
		_commonSettings = new Dictionary<string, UserData>();
		if (Managers.CommonSettings != null)
		{
			foreach (UserData commonSetting in Managers.CommonSettings)
			{
				_commonSettings.Add(commonSetting.Key, commonSetting);
			}
		}
		_configurationDict = new Dictionary<string, object>();
		return null;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", CheckStock);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", CheckStock);
	}

	public void ReLoad()
	{
		_configurationDict = new Dictionary<string, object>();
	}

	public bool Contains(string key)
	{
		bool flag = _archive.Contains(key);
		if (!flag && _commonSettings.ContainsKey(key))
		{
			return true;
		}
		return flag;
	}

	public IConfigUserData GetConfigObject(string key)
	{
		_configurationDict.TryGetValue(key, out var value);
		return (IConfigUserData)value;
	}

	public bool TryGetConfigValue<T>(string key, out T val)
	{
		val = default(T);
		if (!Contains(key))
		{
			return false;
		}
		val = GetConfigValue<T>(key);
		return true;
	}

	public Config<T> GetConfig<T>(string key, bool isServerOnly = false)
	{
		if (!_configurationDict.TryGetValue(key, out var value))
		{
			UserData value2 = _archive.Get(key);
			if (value2 == null)
			{
				_commonSettings.TryGetValue(key, out value2);
				if (value2 == null)
				{
					Type typeFromHandle = typeof(T);
					bool flag = typeFromHandle.IsPrimitive || typeFromHandle == typeof(string);
					UserData obj = new UserData
					{
						UserId = _archive.UserId
					};
					object data;
					if (!flag)
					{
						data = JsonHelper.ToJson(default(T));
					}
					else
					{
						T val = default(T);
						data = ((val != null) ? val.ToString() : null);
					}
					obj.Data = (string)data;
					obj.Key = key;
					obj.Type = ((!flag) ? 1 : 0);
					obj.Version = 0;
					value2 = obj;
					_archive.Set(key, value2);
				}
			}
			Config<T> config = new Config<T>(key, value2);
			config.DataChanged = (Action<UserData>)Delegate.Combine(config.DataChanged, new Action<UserData>(OnConfigDataChanged));
			_configurationDict.Add(key, config);
			value = config;
		}
		return (Config<T>)value;
	}

	private void OnConfigDataChanged(UserData userData)
	{
	}

	private void OnDataRemoved(UserData userData)
	{
	}

	public void SetConfigValue<T>(string key, T value)
	{
		Config<T> config = GetConfig<T>(key);
		if (config != null)
		{
			config.SetValue(value);
			return;
		}
		throw new Exception("错误！不存在用户配置: " + key);
	}

	public void RemoveConfig(string key)
	{
		if (_configurationDict.ContainsKey(key))
		{
			if (_archive.Contains(key))
			{
				OnDataRemoved(_archive.Get(key));
				_archive.Remove(key);
			}
			else if (_commonSettings.ContainsKey(key))
			{
				_commonSettings.Remove(key);
			}
			_configurationDict.Remove(key);
		}
	}

	public T GetConfigValue<T>(string key)
	{
		Config<T> config = GetConfig<T>(key);
		if (config != null)
		{
			return config.GetValue();
		}
		return default(T);
	}

	public T GetValueOfDictConfig<T>(string key, string itemId)
	{
		Config<Dictionary<string, T>> config = GetConfig<Dictionary<string, T>>(key);
		if (config != null)
		{
			Dictionary<string, T> value = config.GetValue();
			if (value.TryGetValue(itemId, out var value2))
			{
				return value2;
			}
		}
		return default(T);
	}

	public void SetValueOfDictConfig<T>(string key, string itemId, T itemValue, bool acceptInsert = false)
	{
		Config<Dictionary<string, T>> config = GetConfig<Dictionary<string, T>>(key);
		Dictionary<string, T> value = config.GetValue();
		if (value == null)
		{
			throw new Exception("错误！不存在用户配置: " + key + " => " + itemId);
		}
		if (value.ContainsKey(itemId))
		{
			value[itemId] = itemValue;
			config.SetValue(value);
			return;
		}
		if (acceptInsert)
		{
			value.Add(itemId, itemValue);
			config.SetValue(value);
			return;
		}
		throw new Exception("设置用户配置失败: " + key + " => " + itemId);
	}

	public void AddToDictConfig<T>(string key, string itemId, T itemValue)
	{
		Config<Dictionary<string, T>> config = GetConfig<Dictionary<string, T>>(key);
		Dictionary<string, T> value = config.GetValue();
		if (!value.ContainsKey(itemId))
		{
			value.Add(itemId, itemValue);
			config.SetValue(value);
		}
	}

	public void RemoveFromDictConfig<T>(string key, string itemId)
	{
		Config<Dictionary<string, T>> config = GetConfig<Dictionary<string, T>>(key);
		Dictionary<string, T> configValue = GetConfigValue<Dictionary<string, T>>(key);
		if (configValue != null && configValue.ContainsKey(itemId))
		{
			configValue.Remove(itemId);
			config.SetValue(configValue);
		}
	}

	public void AddToList<T>(string key, T item)
	{
		Config<List<T>> config = GetConfig<List<T>>(key);
		List<T> value = config.GetValue();
		if (!value.Contains(item))
		{
			value.Add(item);
			config.SetValue(value);
		}
	}

	public void RemoveFromList<T>(string key, T itemId)
	{
		Config<List<T>> config = GetConfig<List<T>>(key);
		List<T> value = config.GetValue();
		int num = value.IndexOf(itemId);
		if (num >= 0)
		{
			value.RemoveAt(num);
			config.SetValue(value);
		}
	}

	public void RemoveAtFromList<T>(string key, int index)
	{
		Config<List<T>> config = GetConfig<List<T>>(key);
		List<T> value = config.GetValue();
		if (index >= 0)
		{
			value.RemoveAt(index);
			config.SetValue(value);
		}
	}

	private void CheckStock(string itemId, int offset, (StockInContext, string) context)
	{
		if (itemId.Equals("I67408"))
		{
			Managers.UserArchiveManager.SetGvGSoldierStockLimitIncrement(new GvGSoldierStockLimitIncrease
			{
				LimitIncrease = OuterTechHelper.Calculate战时扩编SoldierStockLimitIncrease()
			});
		}
	}
}
