using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class NewbieGACHAResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public int Progress;

	[ProtoMember(4)]
	public int Select;

	public string Message;

	[ProtoMember(5)]
	public string _jsonBonusLists;

	private List<List<ModelsBonus>> _bonusLists;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<List<ModelsBonus>> BonusLists
	{
		get
		{
			if (_bonusLists == null && !string.IsNullOrEmpty(_jsonBonusLists))
			{
				_bonusLists = JsonHelper.ToObject<List<List<ModelsBonus>>>(_jsonBonusLists);
			}
			return _bonusLists;
		}
		set
		{
			_bonusLists = value;
			_jsonBonusLists = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_NEWBIE_GACHA_REQUEST;
}
