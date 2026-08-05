using System;

namespace Shift.Legion.CodeGeneration.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParametersKeyDescAttribute : Attribute
{
	public string ParameterType { get; }

	public string Name { get; }

	public string Description { get; }

	public string DefaultValue { get; }

	public bool IsCloneable { get; }

	public bool IsPooled { get; }

	public ParametersKeyDescAttribute(string parameterType, string name, string description, string defaultValue, bool isCloneable, bool isPooled)
	{
		ParameterType = parameterType;
		Name = name;
		Description = description;
		DefaultValue = defaultValue;
		IsCloneable = isCloneable;
		IsPooled = isPooled;
	}
}
