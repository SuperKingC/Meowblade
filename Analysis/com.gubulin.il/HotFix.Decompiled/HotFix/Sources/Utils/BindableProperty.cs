using System;

namespace HotFix.Sources.Utils;

public class BindableProperty<T> where T : IEquatable<T>
{
	private T _value;

	private Action<T> _propertyChanged;

	public T Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (!value.Equals(_value))
			{
				_value = value;
				_propertyChanged?.Invoke(_value);
			}
		}
	}

	public void AddAction(Action<T> action)
	{
		_propertyChanged = (Action<T>)Delegate.Combine(_propertyChanged, action);
	}

	public void RemoveAction(Action<T> action)
	{
		_propertyChanged = (Action<T>)Delegate.Remove(_propertyChanged, action);
	}
}
