using System;

namespace ProtoBuf;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class ProtoEnumAttribute : Attribute
{
	private bool hasValue;

	private int enumValue;

	public int Value
	{
		get
		{
			return enumValue;
		}
		set
		{
			enumValue = value;
			hasValue = true;
		}
	}

	public string Name { get; set; }

	public bool HasValue()
	{
		return hasValue;
	}
}
