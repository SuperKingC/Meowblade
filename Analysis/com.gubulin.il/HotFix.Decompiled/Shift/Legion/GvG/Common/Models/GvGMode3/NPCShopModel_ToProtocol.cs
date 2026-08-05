using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class NPCShopModel_ToProtocol
{
	[ProtoMember(1)]
	public string ShopItemName { get; set; }

	[ProtoMember(2)]
	public int UserBuyCnt { get; set; }

	[ProtoMember(3)]
	public int UserBuyLimit { get; set; }

	[ProtoMember(4)]
	public int CampBuyCnt { get; set; }

	[ProtoMember(5)]
	public int CampBuyLimit { get; set; }

	[ProtoMember(6)]
	public int CurStock { get; set; }

	[ProtoMember(7)]
	public int AllStock { get; set; }
}
