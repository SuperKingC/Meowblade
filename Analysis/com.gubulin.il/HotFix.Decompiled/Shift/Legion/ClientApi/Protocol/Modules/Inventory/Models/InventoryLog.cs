using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

[ProtoContract]
public class InventoryLog
{
	[ProtoMember(14)]
	[NotMapped]
	public string Base64Data;

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }

	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public int Operation { get; set; }

	[ProtoMember(3)]
	public long InstanceId { get; set; }

	[ProtoMember(4)]
	public string ItemId { get; set; }

	[ProtoMember(5)]
	public long QtyDelta { get; set; }

	[ProtoMember(6)]
	public long Qty { get; set; }

	[ProtoMember(7)]
	public long Num1 { get; set; }

	[ProtoMember(8)]
	public long Num2 { get; set; }

	[ProtoMember(9)]
	public long Num3 { get; set; }

	[ProtoMember(10)]
	public string Str1 { get; set; }

	[ProtoMember(11)]
	public string Str2 { get; set; }

	[ProtoMember(12)]
	public string Str3 { get; set; }

	[ProtoMember(13)]
	public byte[] Data { get; set; }

	[ProtoMember(20)]
	public int Score { get; set; }

	public DateTimeOffset CreatedAt { get; set; }
}
