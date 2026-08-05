using System;

namespace Shift.Legion.CodeGeneration.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandFlagAttribute : Attribute
{
	public bool GenerateSystem { get; }

	public CommandFlagAttribute()
		: this(generateSystem: true)
	{
	}

	public CommandFlagAttribute(bool generateSystem)
	{
		GenerateSystem = generateSystem;
	}
}
