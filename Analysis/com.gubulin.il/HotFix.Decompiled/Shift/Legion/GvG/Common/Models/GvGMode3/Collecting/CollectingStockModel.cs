using System;
using System.Linq;
using GameDataEditor;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

[ProtoContract]
public class CollectingStockModel
{
	private string _itemId;

	[ProtoMember(1)]
	public string ProductId { get; set; }

	[ProtoMember(3)]
	public string TypeString { get; set; }

	[ProtoMember(4)]
	public int MaxStock { get; set; }

	[ProtoMember(6)]
	public int CurStock { get; set; }

	[ProtoMember(8)]
	public string Data { get; set; }

	[ProtoMember(9)]
	public int ExpirationTimestamp { get; set; }

	[ProtoMember(10)]
	public bool IsShared { get; set; }

	[ProtoMember(11)]
	public int SharedCampId { get; set; }

	[ProtoMember(12)]
	public int SharedByUserId { get; set; }

	public static string StockTypeToTypeString(eCollectingStockType collectingStockType)
	{
		if (collectingStockType.ToString().Contains($"{eCollectingStockType.Mission}"))
		{
			throw new Exception("[CollectingStockModel] Mission类型的TypeString需要通过‘MissionToTypeString()’生成");
		}
		return collectingStockType.ToString();
	}

	public static string MissionToTypeString(eGvGMode3CampMissionType missionType, int muid)
	{
		return $"{eCollectingStockType.Mission}_{missionType}_{muid}";
	}

	public void Init(string productId, int maxStock, string typeString, string data = "")
	{
		ProductId = productId;
		MaxStock = maxStock;
		CurStock = maxStock;
		TypeString = typeString;
		Data = data;
	}

	public string GetModelId()
	{
		return ProductId + "#" + TypeString;
	}

	public string GetMiningConfigStr(int prior)
	{
		return GetMiningConfigStr(GetModelId(), prior);
	}

	public static string GetMiningConfigStr(string modelId, int prior)
	{
		prior = ((prior != 0) ? 1 : 0);
		return $"{modelId}##{prior}";
	}

	public static string GetProductId(string ModelId)
	{
		return ModelId.Split('#').First();
	}

	public eCollectingStockType GetStockType()
	{
		if (TypeString.StartsWith(eCollectingStockType.Normal.ToString()))
		{
			return eCollectingStockType.Normal;
		}
		if (TypeString.StartsWith(eCollectingStockType.Hidden.ToString()))
		{
			return eCollectingStockType.Hidden;
		}
		if (TypeString.StartsWith($"{eCollectingStockType.Mission}_{eGvGMode3CampMissionType.Talent_额外发现}"))
		{
			return eCollectingStockType.Mission_Talent_额外发现;
		}
		if (TypeString.StartsWith($"{eCollectingStockType.Mission}_{eGvGMode3CampMissionType.RE}"))
		{
			return eCollectingStockType.Mission_RE_Collecting;
		}
		if (TypeString.StartsWith(eCollectingStockType.Mission.ToString()))
		{
			return eCollectingStockType.Mission;
		}
		return eCollectingStockType.NoInit;
	}

	public void Refresh()
	{
		CurStock = MaxStock;
	}

	public string GetItemId()
	{
		if (string.IsNullOrEmpty(_itemId) && !string.IsNullOrEmpty(ProductId))
		{
			_itemId = GDMgr.Get<GDEProductData>(ProductId).ItemId;
		}
		return _itemId;
	}
}
