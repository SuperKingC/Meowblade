using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2ShipFillUpResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string Cost { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_SHIP_FILL_UP;

	public void UpdateCostStock()
	{
		if (string.IsNullOrEmpty(Cost))
		{
			return;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(Cost);
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 107,
				ContextValue = item.Key,
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
	}
}
