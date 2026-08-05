using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

public class SoldierWithLegendItemId
{
	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public List<long> LegendItemIds { get; set; }

	public void DataCheck()
	{
		if (string.IsNullOrEmpty(SoldierId))
		{
			SoldierId = "";
		}
		if (LegendItemIds == null)
		{
			LegendItemIds = new List<long>();
			for (int i = 0; i < 2; i++)
			{
				LegendItemIds.Add(0L);
			}
		}
		else if (LegendItemIds.Count < 2)
		{
			int count = LegendItemIds.Count;
			for (int j = 0; j < 2 - count; j++)
			{
				LegendItemIds.Add(0L);
			}
		}
	}
}
