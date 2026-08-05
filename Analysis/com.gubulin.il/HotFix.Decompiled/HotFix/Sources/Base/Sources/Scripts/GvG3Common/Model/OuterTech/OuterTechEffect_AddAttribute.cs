using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

public class OuterTechEffect_AddAttribute
{
	public class AddAttribute
	{
		public OuterTechName OuterTechName;

		public float Buff;
	}

	public AddAttribute Base { get; set; } = new AddAttribute();

	public AddAttribute Additional { get; set; } = new AddAttribute();

	public Dictionary<string, AddAttribute> Special { get; set; } = new Dictionary<string, AddAttribute>();

	public Dictionary<OuterTechName, float> GetAllGvGAttributeBuff(int count)
	{
		Dictionary<OuterTechName, float> dictionary = new Dictionary<OuterTechName, float>();
		dictionary.Add(Base.OuterTechName, Base.Buff);
		if (dictionary.ContainsKey(Additional.OuterTechName))
		{
			dictionary[Additional.OuterTechName] += Additional.Buff * (float)(count - 1);
		}
		else
		{
			dictionary.Add(Additional.OuterTechName, Additional.Buff * (float)(count - 1));
		}
		foreach (KeyValuePair<string, AddAttribute> item in Special)
		{
			if (count >= int.Parse(item.Key))
			{
				if (dictionary.ContainsKey(item.Value.OuterTechName))
				{
					dictionary[item.Value.OuterTechName] += item.Value.Buff;
				}
				else
				{
					dictionary.Add(item.Value.OuterTechName, item.Value.Buff);
				}
			}
		}
		return dictionary;
	}
}
