using System;
using System.Globalization;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Store;

[ProtoContract]
public class Order
{
	[ProtoMember(15)]
	public string _dateAddedStr;

	private DateTimeOffset _dateAdded;

	[ProtoMember(16)]
	public string _datePaidStr;

	private DateTimeOffset _datePaid;

	[ProtoMember(1)]
	public int OrderId { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(3)]
	public string ReferenceId { get; set; }

	[ProtoMember(4)]
	public string StoreItemId { get; set; }

	[ProtoMember(5)]
	public string Desc { get; set; }

	[ProtoMember(6)]
	public string Remark { get; set; }

	[ProtoMember(7)]
	public float Total { get; set; }

	[ProtoMember(8)]
	public float PaidTotal { get; set; }

	[ProtoMember(9)]
	public string Currency { get; set; }

	[ProtoMember(10)]
	public string Payment { get; set; }

	[ProtoMember(11)]
	public string TransactionId { get; set; }

	[ProtoMember(12)]
	public string Payload { get; set; }

	[ProtoMember(13)]
	public string ExtraPayload { get; set; }

	[ProtoMember(14)]
	public int Status { get; set; }

	public DateTimeOffset DateAdded
	{
		get
		{
			if (_dateAdded == default(DateTimeOffset) && !string.IsNullOrEmpty(_dateAddedStr))
			{
				_dateAdded = DateTimeOffset.Parse(_dateAddedStr, CultureInfo.InvariantCulture).ToUniversalTime();
			}
			return _dateAdded;
		}
		set
		{
			_dateAdded = value.ToUniversalTime();
			_dateAddedStr = _dateAdded.ToString(CultureInfo.InvariantCulture);
		}
	}

	public DateTimeOffset DatePaid
	{
		get
		{
			if (_datePaid == default(DateTimeOffset) && !string.IsNullOrEmpty(_datePaidStr))
			{
				_datePaid = DateTimeOffset.Parse(_datePaidStr, CultureInfo.InvariantCulture).ToUniversalTime();
			}
			return _datePaid;
		}
		set
		{
			_datePaid = value.ToUniversalTime();
			_datePaidStr = _datePaid.ToString(CultureInfo.InvariantCulture);
		}
	}

	[ProtoMember(17)]
	public string ExtraInfo { get; set; }
}
