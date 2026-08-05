using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.Store;

[ProtoContract]
public class StoreItem
{
	[ProtoMember(1)]
	public string StoreItemId;

	[ProtoMember(3)]
	public string Name;

	[ProtoMember(4)]
	public string Icon;

	[ProtoMember(5)]
	public string Desc;

	[ProtoMember(6)]
	public string SubDesc;

	[ProtoMember(7)]
	public int Rarity;

	[ProtoMember(8)]
	public int Category;

	[ProtoMember(9)]
	public bool DoubleAtFirst;

	[ProtoMember(10)]
	public string _pbBonusAtFirst;

	private Dictionary<string, int> _bonusAtFirst;

	[ProtoMember(11)]
	public List<string> Tags;

	[ProtoMember(12)]
	public int ValidTime;

	[ProtoMember(13)]
	public string _kickOffTimeStr;

	private DateTimeOffset _kickOffTime;

	[ProtoMember(130)]
	public int KickOffTimestamp;

	[ProtoMember(14)]
	public string _expireAtStr;

	private DateTimeOffset _expireAt;

	[ProtoMember(140)]
	public int ExpireTimestamp;

	[ProtoMember(15)]
	public string _pbContent;

	private Dictionary<string, int> _content;

	[ProtoMember(16)]
	public string _pbDisplayContent;

	private List<List<string>> _displayContent;

	[ProtoMember(17)]
	public string _pbOriginPrice;

	private List<Dictionary<string, float>> _originPrice;

	[ProtoMember(18)]
	public string _pbPrice;

	private List<Dictionary<string, float>> _price;

	[ProtoMember(19)]
	public float Discount = 1f;

	[ProtoMember(20)]
	public int PurchaseLimit;

	[ProtoMember(21)]
	public int PurchaseLimitPeriod = 0;

	[ProtoMember(22)]
	public bool IsExpo = false;

	[ProtoMember(23)]
	public string Substitution;

	[ProtoMember(24)]
	public bool IsResident = false;

	[ProtoMember(25)]
	public int UserLevelFilter;

	[ProtoMember(26)]
	public int DungeonLevelFilter;

	[ProtoMember(27)]
	public List<string> GameLevelFilter;

	[ProtoMember(28)]
	public List<string> MissionFilter;

	[ProtoMember(29)]
	public string _pbOwnedItemFilter;

	private Dictionary<string, int> _ownedItemFilter;

	[ProtoMember(30)]
	public string _pbPurchaseFilter;

	private Dictionary<string, int> _purchaseFilter;

	public Dictionary<string, int> BonusAtFirst
	{
		get
		{
			if (_pbBonusAtFirst == null)
			{
				return null;
			}
			return _bonusAtFirst ?? (_bonusAtFirst = JsonHelper.ToObject<Dictionary<string, int>>(_pbBonusAtFirst));
		}
		set
		{
			_bonusAtFirst = value;
			_pbBonusAtFirst = JsonHelper.ToJson(value);
		}
	}

	public DateTimeOffset KickOffTime
	{
		get
		{
			if (_kickOffTime == default(DateTimeOffset) && !string.IsNullOrEmpty(_kickOffTimeStr))
			{
				_kickOffTime = DateTimeOffset.Parse(_kickOffTimeStr).ToUniversalTime();
			}
			return _kickOffTime;
		}
		set
		{
			_kickOffTime = value.ToUniversalTime();
			_kickOffTimeStr = _kickOffTime.ToString();
		}
	}

	public DateTimeOffset ExpireAt
	{
		get
		{
			if (_expireAt == default(DateTimeOffset) && !string.IsNullOrEmpty(_expireAtStr))
			{
				_expireAt = DateTimeOffset.Parse(_expireAtStr).ToUniversalTime();
			}
			return _expireAt;
		}
		set
		{
			_expireAt = value.ToUniversalTime();
			_expireAtStr = _expireAt.ToString();
		}
	}

	public Dictionary<string, int> Content
	{
		get
		{
			if (_pbContent == null)
			{
				return null;
			}
			return _content ?? (_content = JsonHelper.ToObject<Dictionary<string, int>>(_pbContent));
		}
		set
		{
			_content = value;
			_pbContent = JsonHelper.ToJson(value);
		}
	}

	public List<List<string>> DisplayContent
	{
		get
		{
			if (_pbDisplayContent == null)
			{
				return null;
			}
			return _displayContent ?? (_displayContent = JsonHelper.ToObject<List<List<string>>>(_pbDisplayContent));
		}
		set
		{
			_displayContent = value;
			_pbDisplayContent = JsonHelper.ToJson(value);
		}
	}

	public List<Dictionary<string, float>> OriginPrice
	{
		get
		{
			if (_pbOriginPrice == null)
			{
				return null;
			}
			return _originPrice ?? (_originPrice = JsonHelper.ToObject<List<Dictionary<string, float>>>(_pbOriginPrice));
		}
		set
		{
			_originPrice = value;
			_pbOriginPrice = JsonHelper.ToJson(value);
		}
	}

	public List<Dictionary<string, float>> Price
	{
		get
		{
			if (_pbPrice == null)
			{
				return null;
			}
			return _price ?? (_price = JsonHelper.ToObject<List<Dictionary<string, float>>>(_pbPrice));
		}
		set
		{
			_price = value;
			_pbPrice = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, int> OwnedItemFilter
	{
		get
		{
			if (_pbOwnedItemFilter == null)
			{
				return null;
			}
			return _ownedItemFilter ?? (_ownedItemFilter = JsonHelper.ToObject<Dictionary<string, int>>(_pbOwnedItemFilter));
		}
		set
		{
			_ownedItemFilter = value;
			_pbOwnedItemFilter = JsonHelper.ToJson(value);
		}
	}

	public Dictionary<string, int> PurchaseFilter
	{
		get
		{
			if (_pbPurchaseFilter == null)
			{
				return null;
			}
			return _purchaseFilter ?? (_purchaseFilter = JsonHelper.ToObject<Dictionary<string, int>>(_pbPurchaseFilter));
		}
		set
		{
			_purchaseFilter = value;
			_pbPurchaseFilter = JsonHelper.ToJson(value);
		}
	}
}
