using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class TalentRItem
{
	[ProtoMember(1)]
	public string ItemId { get; set; }

	[ProtoMember(2)]
	public int cnt { get; set; }

	[ProtoMember(3)]
	public List<int> TalentSrcList { get; set; }

	public TalentRItem Clone()
	{
		return new TalentRItem
		{
			ItemId = ItemId,
			cnt = cnt,
			TalentSrcList = new List<int>(TalentSrcList)
		};
	}
}
