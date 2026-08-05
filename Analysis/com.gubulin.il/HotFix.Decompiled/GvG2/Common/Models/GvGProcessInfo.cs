using ProtoBuf;
using Shift.Legion.Helpers;

namespace GvG2.Common.Models;

[ProtoContract]
public class GvGProcessInfo
{
	private WBInfo _BossInfo;

	[ProtoMember(1)]
	public string ServerName { get; set; }

	[ProtoMember(3)]
	public int Pid { get; set; }

	[ProtoMember(4)]
	public int ExternalSocketPort { get; set; }

	[ProtoMember(5)]
	public string IZConfigId { get; set; }

	[ProtoMember(6)]
	public string SeasonName { get; set; }

	[ProtoMember(7)]
	public string IZId { get; set; }

	[ProtoMember(8)]
	public int IslandId { get; set; }

	[ProtoMember(9)]
	public string MapId { get; set; }

	[ProtoMember(11)]
	public int ProcessType { get; set; }

	[ProtoMember(12)]
	public string Info { get; set; }

	public WBInfo BossInfo
	{
		get
		{
			if (ProcessType != 2 || string.IsNullOrEmpty(Info))
			{
				return null;
			}
			if (_BossInfo == null)
			{
				_BossInfo = JsonHelper.ToObject<WBInfo>(Info);
			}
			return _BossInfo;
		}
	}
}
