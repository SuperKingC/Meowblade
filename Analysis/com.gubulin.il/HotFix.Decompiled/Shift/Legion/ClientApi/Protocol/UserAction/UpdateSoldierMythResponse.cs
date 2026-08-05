using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UpdateSoldierMythResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int CurLevel { get; set; }

	[ProtoMember(2)]
	public string _jsonCost { get; set; }

	public int PacketId => PacketIds.USER_ACTION_UPDATE_SOLDIER_MYTH;

	public void UpdateCostStock()
	{
		if (string.IsNullOrEmpty(_jsonCost))
		{
			return;
		}
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(_jsonCost);
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 112,
				ContextValue = CurLevel.ToString(),
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
	}
}
