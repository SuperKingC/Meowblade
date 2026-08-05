using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.Map;

[ProtoContract]
public class GvGProcessInfo
{
	private WBInfo _BossInfo;

	public object _Info = null;

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

	public object GetInfo()
	{
		if (_Info == null)
		{
			switch ((eGvGProcessType)ProcessType)
			{
			case eGvGProcessType.WorldBoss:
				_Info = JsonHelper.ToObject<WBInfo>(Info);
				break;
			case eGvGProcessType.GvGMode3IslandManager:
				_Info = JsonHelper.ToObject<GvGMode3IslandManagerInfo>(Info);
				break;
			}
		}
		return _Info;
	}
}
