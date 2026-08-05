using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

public class EntityCheck
{
	public string Op;

	public List<EntityCheckCondition> Chk;

	public List<long> GetEntityCheckConditionContent => EntityCheckConditionContent();

	private List<long> EntityCheckConditionContent()
	{
		List<long> list = new List<long>();
		foreach (EntityCheckCondition item in Chk)
		{
			list.Add(item.Val);
		}
		return list;
	}
}
