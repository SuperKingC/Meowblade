using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.OuterTech;

[ProtoContract]
public class OuterTechModel
{
	[ProtoMember(1)]
	public int o刚刚搞错了_LimitTime;

	[ProtoMember(2)]
	public int o努力加餐饭_LimitTime;

	[ProtoMember(3)]
	public int o绿色通道_LimitTime;

	[ProtoMember(4)]
	public int o魔的第八天_LimitTime;

	[ProtoMember(20)]
	public int o绿色通道_EndTime;

	[ProtoMember(5)]
	public int o代理作战_LimitTime { get; set; }

	[ProtoMember(6)]
	public int o邪魔外道_LimitTime { get; set; }

	[ProtoMember(7)]
	public int o蛰伏_LimitTime { get; set; }

	[ProtoMember(8)]
	public bool o蛰伏_Valid { get; set; }

	[ProtoMember(9)]
	public int o远程通信_LimitTime { get; set; }
}
