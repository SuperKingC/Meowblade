using System.Collections.Generic;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.AbilitySpecialName;

public class SpecialAbilityName
{
	public string Name { get; }

	public Dictionary<string, int> Tags { get; }

	public SpecialAbilityName(string name, Dictionary<string, int> tags)
	{
		Name = name;
		Tags = tags;
	}
}
