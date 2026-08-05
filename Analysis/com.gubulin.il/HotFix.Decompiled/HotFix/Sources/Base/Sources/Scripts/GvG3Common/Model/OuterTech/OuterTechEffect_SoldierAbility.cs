using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

public class OuterTechEffect_SoldierAbility
{
	public Dictionary<string, AbilityConfig> Special = new Dictionary<string, AbilityConfig>();

	public AbilityConfig Base { get; set; } = new AbilityConfig();

	public AbilityConfig Additional { get; set; } = new AbilityConfig();

	public Dictionary<string, int> GetAllAbilityConfig(int count)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add(Base.AbilityId, Base.Level);
		if (count > 1 && Additional != null)
		{
			if (dictionary.ContainsKey(Additional.AbilityId))
			{
				dictionary[Additional.AbilityId] += Additional.Level * (count - 1);
			}
			else
			{
				dictionary.Add(Additional.AbilityId, Additional.Level * (count - 1));
			}
		}
		foreach (KeyValuePair<string, AbilityConfig> item in Special)
		{
			if (count >= int.Parse(item.Key))
			{
				if (dictionary.ContainsKey(item.Value.AbilityId))
				{
					dictionary[item.Value.AbilityId] += item.Value.Level;
				}
				else
				{
					dictionary.Add(item.Value.AbilityId, item.Value.Level);
				}
			}
		}
		return dictionary;
	}
}
