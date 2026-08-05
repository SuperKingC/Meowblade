using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class LotteryPendingResult
{
	[ProtoMember(1)]
	public string From;

	[ProtoMember(2)]
	public string _createdAtStr;

	private DateTimeOffset _createdAt;

	[ProtoMember(3)]
	public int TotalPick;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> BonusList;

	public DateTimeOffset CreatedAt
	{
		get
		{
			if (_createdAt == default(DateTimeOffset) && !string.IsNullOrEmpty(_createdAtStr))
			{
				_createdAt = DateTimeOffset.Parse(_createdAtStr).ToUniversalTime();
			}
			return _createdAt;
		}
		set
		{
			_createdAt = value.ToUniversalTime();
			_createdAtStr = _createdAt.ToString();
		}
	}
}
